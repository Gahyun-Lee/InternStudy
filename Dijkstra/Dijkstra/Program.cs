using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Dijkstra
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@".\json\nodes2.json");

            Input? input = JsonSerializer.Deserialize<Input>(json);

            Console.WriteLine("===============Dijkstra===============");

            int size = input.Size;
            Graph graph = new Graph(size, input.Start); //그래프 생성 - 모든 값을 INF로 설정

            //그래프 가중치 값 설정
            graph.SetWeights(input.Nodes);

            Console.WriteLine("<가중치 그래프 출력>");
            graph.PrtGraph();
            Console.WriteLine();

            Console.WriteLine("<다익스트라 알고리즘 실행>");
            List<Result> result = graph.Dijkstra();

            Console.WriteLine("최단 거리 계산 결과");
            graph.PrtDist();
            Console.WriteLine();

            string resultFile = @"json\result.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string resultJson = JsonSerializer.Serialize(result, options);
            File.WriteAllText(resultFile, resultJson);
            Console.WriteLine("======================================");
        }
    }
}