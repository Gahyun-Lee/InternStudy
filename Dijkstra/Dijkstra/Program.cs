using System;
using System.IO;
using System.Text.Json;

namespace Dijkstra
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("D:\\InternStudy\\Dijkstra\\Dijkstra\\json\\nodes.json");

            Input? input = JsonSerializer.Deserialize<Input>(json);

            Console.WriteLine("===============Dijkstra===============");

            int size = input.Size;
            Graph graph = new Graph(size, input.Start); //그래프 생성 - 모든 값을 INF로 설정

            //그래프 가중치 값 설정
            graph.setWeights(input.Nodes);

            Console.WriteLine("<가중치 그래프 출력>");
            graph.prtGraph();
            Console.WriteLine();

            Console.WriteLine("<다익스트라 알고리즘 실행>");
            graph.dijkstra();
            Console.WriteLine();

            Console.WriteLine("최단 거리 계산 결과");
            graph.prtDist();
            Console.WriteLine();

            //Json 파일에 저장
            Dist dist = new Dist(size);
            dist.dist = graph.getDist();

            string resultFile = "D:\\InternStudy\\Dijkstra\\Dijkstra\\json\\result.json";
            string result = JsonSerializer.Serialize(dist);
            File.WriteAllText(resultFile, result);
            Console.WriteLine("======================================");

        }
    }
}