using System;
using System.Collections.Generic;

namespace Dijkstra
{

    static class Constants
    {
        public const int INF = 1000000;
    }

    /*
    * 우선순위큐 - 리스트로 구현
    * Item - 정점번호와 해당 정점의 최단거리 저장
    * 우선순위큐 - Item을 저장하는 리스트
    * Dequeue() : 우선순위가 높은(최단거리가 가장 작은) Item 삭제
    * Peak() : 우선순위가 높은 Item의 최단거리, 정점 번호 반환
    */
    class Item
    {
        public int Dist { get; set; } //정점의 dist(최단거리) 값
        public int Vertex { get; set; } //정점 번호
    }
    class PriorityQueue
    {
        private List<Item> items;
        
        public PriorityQueue()
        {
            items = new List<Item>();
        }

        public void Enqueue(int dist, int vertex)
        {
            items.Add(new Item { Dist = dist, Vertex = vertex });
        }

        public void Dequeue() //dist값이 작은것부터 삭제
        {
            int idx = getIndex();
            items.RemoveAt(idx);
        }

        public int[] Peak()
        {
            int idx = getIndex();
            int[] peak = { items[idx].Dist, items[idx].Vertex };
            return peak;
        }

        public int getIndex() //dist 값이 작은 인덱스 반환
        {
            int min = items[0].Dist;
            int idx = 0;

            for(int i=1; i<items.Count; i++)
            {
                if(min > items[i].Dist)
                {
                    min = items[i].Dist;
                    idx = i;
                }
            }

            return idx;
        }

        public bool isEmpty()
        {
            if (items.Count == 0)
                return true;
            return false;
        }
    }

    class Graph
    {
        private int size; //정점 개수
        private int[,] weights;  //정점 간의 간선 가중치
        private int[] dist; //최단 거리

        public Graph() { 
            size = 0;
        }

        public Graph(int size) { 
            this.size = size;
            weights = new int[size, size];
            dist = new int[size];

            // 간선 가중치, 최단거리 무한대로 초기화
            for (int i = 0; i < size; i++)
            {
                dist[i] = Constants.INF; 
                for (int j = 0; j < size; j++)
                    weights[i, j] = Constants.INF;
            }

        }

        public void setWeights(int i, int j, int weight)
        {
            weights[i, j] = weight;
            weights[j, i] = weight;
        }

        public void dijkstra(int start)
        {
            dist[start] = 0;

            PriorityQueue pq = new PriorityQueue();
            pq.Enqueue(0, start);

            while(!pq.isEmpty())
            {
                int[] now = pq.Peak();
                int distNow = now[0];
                int vertexNow = now[1];
                pq.Dequeue();

                for(int i=0; i<size; i++)
                {
                    int weight = weights[vertexNow, i];
                    if (weight != Constants.INF)
                    {
                        if((weight+ distNow) < dist[i])
                        {
                            dist[i] = weight + distNow;
                            pq.Enqueue(dist[i], i);
                        }
                    }
                }
            }
        }

        public void prtGraph()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (weights[i, j] == Constants.INF)
                        Console.Write("{0, 5}", "INF");
                    else
                        Console.Write("{0, 5}", weights[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void prtDist()
        {
            for(int i=0; i<size;i++)
                Console.Write("{0, 5}", dist[i]);
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===============Dijkstra===============");

            Console.WriteLine();
            Console.WriteLine("<정점. 간선 그래프 생성>");
            Console.Write("정점 개수 : ");
            int size = Int32.Parse(Console.ReadLine());

            Graph graph = new Graph(size); //그래프 생성 - 모든 값을 INF로 설정

            //그래프 가중치 값 설정
            Console.WriteLine();
            Console.WriteLine("<간선 가중치 값 설정>");
            Console.WriteLine("두 정점 번호와 가중치 값을 입력해주세요.(예시. 1 2 10) 아무것도 입력하지 않거나 exit 입력 시 종료");
            Console.WriteLine();

            while (true)
            {
                int i, j, weight;

                Console.Write("가중치 입력 : ");
                string[] input = Console.ReadLine().Split(" ");

                if (string.IsNullOrEmpty(input[0]) || input[0] == "exit")
                    break;
                if (input.Length != 3 || !int.TryParse(input[0], out i) || !int.TryParse(input[1], out j) || !int.TryParse(input[2], out weight))
                {
                    Console.WriteLine("잘못된 입력 형식입니다. 다시 입력해주세요.");
                    continue;
                }

                if (i < 0 || i >= size || j < 0 || j >= size || i == j)
                {
                    Console.WriteLine("정점 번호를 잘못 입력하였습니다. 다시 입력해주세요");
                    continue;
                }

                graph.setWeights(i, j, weight);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("<가중치 그래프 출력>");
            graph.prtGraph();
            Console.WriteLine();

            Console.WriteLine("<다익스트라 알고리즘 실행>");
            int start;
            while (true) 
            {
                Console.Write("출발 정점 선택 : ");
                start = Int32.Parse(Console.ReadLine());
                if (start < 0 || start >= size)
                    Console.WriteLine("정점 번호를 잘못 입력하였습니다. 다시 입력해주세요.");
                else
                    break;
            }
            graph.dijkstra(start);
            Console.WriteLine();

            Console.WriteLine("최단 거리 계산 결과");
            graph.prtDist();
            Console.WriteLine();

            Console.WriteLine("======================================");

        }
    }
}