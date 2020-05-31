using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\TestData\dijkstraData.txt";
            if(args.Length != 0)
                filePath = args[0];
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"using File path: {filePath}");
            var nodes = File.ReadAllLines(filePath).Select(line =>
            {
                var lineItems = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var nodeId = Convert.ToInt32(lineItems[0]);
                var adjacentEdges = new List<AdjacentEdge>();
                for (int i = 1; i < lineItems.Length; i++)
                {
                    var adjacentEdgeIdAndWeight = lineItems[i].Split(',').Select(item=>Convert.ToInt32(item)).ToArray();
                    adjacentEdges.Add(new AdjacentEdge(adjacentEdgeIdAndWeight[0], adjacentEdgeIdAndWeight[1]));
                }
                return new Node(nodeId, adjacentEdges);
            }).ToArray();
            stopWatch.Stop();
            var initTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("read and init time={0}", initTime);
            stopWatch.Restart();
            var alg = new DijkstraMinPathImpl(nodes);
            var result = alg.CalculateMinPaths(1);
            stopWatch.Stop();
            Console.WriteLine("running time = {0}, result={1}", stopWatch.ElapsedMilliseconds, string.Join(
                ",",
                result[6],
                result[36],
                result[58],
                result[81],
                result[98],
                result[114],
                result[132],
                result[164],
                result[187],
                result[196]));
            Console.WriteLine("press any key");
            Console.ReadLine();
        }
    }
}
