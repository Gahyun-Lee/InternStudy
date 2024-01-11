using System;
using System.Collections;
using System.Linq;


namespace Dijkstra
{

    static class Constants
    {
        public const int INF = 1000000;
    }

    class Graph
    {
        private int size; //정점 개수
        private int[,] weights;  //정점 간의 간선 가중치

        public Graph() { 
            size = 0;
        }

        public Graph(int size) { 
            this.size = size;
            weights = new int[size, size];

            // 간선 가중치값 무한대로 초기화
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    weights[i, j] = Constants.INF;
        }

        public void setWeights(int i, int j, int weight)
        {
            weights[i, j] = weight;
            weights[j, i] = weight;
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

            Console.WriteLine("======================================");

        }
    }
}