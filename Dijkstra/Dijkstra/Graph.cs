using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Graph
    {
        private int size; //정점 개수
        private int start; //출발 지점
        private int[,] weights;  //정점 간의 간선 가중치
        private Dist[] dist; //최단 거리

        public Graph() { 
            size = 0;
        }

        public Graph(int size, int start) { 
            this.size = size;
            this.start = start;
            weights = new int[size, size];
            dist = new Dist[size];

            // 간선 가중치, 최단거리 무한대로 초기화
            for (int i = 0; i < size; i++)
            {
                dist[i] = new Dist();
                dist[i].Vertex = i;
                dist[i].Distance = Constants.INF;
                for (int j = 0; j < size; j++)
                    weights[i, j] = Constants.INF;
            }
        }

        public void SetWeights(List<Node> nodes)
        {
            foreach(Node node in nodes)
            {
                weights[node.Vertex1, node.Vertex2] = node.Weight;
                weights[node.Vertex2, node.Vertex1] = node.Weight;
            }
        }

        public Dist[] GetDist()
        {
            return dist;
        }

        public void Dijkstra()
        {
            dist[start].Distance = 0;

            PriorityQueue pq = new PriorityQueue();
            pq.Enqueue(0, start);

            while(!pq.IsEmpty())
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
                        if((weight+ distNow) < dist[i].Distance)
                        {
                            dist[i].Distance = weight + distNow;
                            pq.Enqueue(dist[i].Distance, i);
                        }
                    }
                }
            }
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
            for(int i=0; i<size;i++)
                Console.Write("{0, 5}", dist[i].Distance);
        }
    }
}