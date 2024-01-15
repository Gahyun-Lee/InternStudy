﻿using System;

namespace Dijkstra
{
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
}