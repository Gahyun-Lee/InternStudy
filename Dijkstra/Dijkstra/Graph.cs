using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Graph
    {
        private int size; //정점 개수
        private List<int> start; //출발 지점
        private readonly int[,] weights;  //정점 간의 간선 가중치
        //private readonly Dist[] dist; //최단 거리
        private List<Result> results = new List<Result>(); //최단거리(출발, 도착, 거리 저장)


        public Graph(int size, List<int> start) { 
            this.size = size;
            this.start = start;
            weights = new int[size, size];

            //간선 가중치, 최단거리 무한대로 초기화
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    weights[i, j] = Constants.INF;
        }

        public void SetWeights(List<Node> nodes)
        {
            if (nodes == null)
                return;

            foreach(Node node in nodes)
            {
                if (node == null)
                    continue;

                weights[node.Vertex1, node.Vertex2] = node.Weight;
                weights[node.Vertex2, node.Vertex1] = node.Weight;
            }
        }

        public List<Result> Dijkstra()
        {
            foreach(int s in start)
            {
                Dist[] dist = new Dist[size]; //최단 거리 계산을 위한 배열
                
                //거리 무한대로 초기화
                for (int i = 0; i < size; i++)
                {
                    dist[i] = new Dist();
                    dist[i].Vertex = i;
                    dist[i].Distance = Constants.INF;
                }

                dist[s].Distance = 0;

                PriorityQueue pq = new PriorityQueue();
                pq.Enqueue(0, s);

                while (!pq.IsEmpty())
                {
                    int[] now = pq.Peak();
                    int distNow = now[0];
                    int vertexNow = now[1];
                    pq.Dequeue();

                    for (int i = 0; i < size; i++)
                    {
                        int weight = weights[vertexNow, i];
                        if (weight != Constants.INF)
                        {
                            if ((weight + distNow) < dist[i].Distance)
                            {
                                dist[i].Distance = weight + distNow;
                                pq.Enqueue(dist[i].Distance, i);
                            }
                        }
                    }
                }

                //계산 결과 저장
                Result result = new Result(size);
                result.start = s;
                result.dist = dist;
                results.Add(result);
            }

            return results;
        }

        public void PrtGraph()
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

        public void PrtDist()
        {
            foreach (Result r in results)
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Start : {0}", r.start);
                Console.WriteLine("Vertex : Distance");
                foreach (Dist d in r.dist)
                {
                    Console.WriteLine("   {0}   :   {1}", d.Vertex, d.Distance);
                }

            }
        }
    }
}