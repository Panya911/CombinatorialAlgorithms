using System;
using System.Collections.Generic;
using System.Linq;
using СombinatorialAlgorithms.GraphModel;

namespace СombinatorialAlgorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var incidentArray = ReadIncidentArray();
            var input = ReadGraphFromIncidentArray(incidentArray);
            var result = MinTree.MinTree.BuildKruskalMinTree(input.Item1, input.Item2);

            foreach (var incidentList in BuildIncidentLists(result))
            {
                Console.WriteLine(string.Join(" ", incidentList));
            }
            Console.WriteLine(CalculateWeight(result, input.Item2));
        }

        private static int CalculateWeight(Graph graph, Dictionary<Edge, int> weights)
        {
            return graph.Edges.Sum(x => weights[x]);
        }

        private static int[][] BuildIncidentLists(Graph graph)
        {
            var result = new List<List<int>>();
            foreach (var node in graph.Nodes.OrderBy(x => x.Number))
            {
                var list = node.Edges.Select(edge => edge.Other(node).Number).OrderBy(x => x).ToList();
                list.Add(0);
                result.Add(list);
            }
            return result.Select(x => x.ToArray()).ToArray();
        }

        private static int[] ReadIncidentArray()
        {
            var list = new List<int>();
            var count = int.Parse(Console.ReadLine());
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                list.AddRange(values);
            }
            list.RemoveAt(count - 1);
            return list.ToArray();
        }

        private static Tuple<Graph, Dictionary<Edge, int>> ReadGraphFromIncidentArray(int[] array)
        {
            var resultGraph = new Graph();
            var weights = new Dictionary<Edge, int>();
            var nodeCount = array[0] - 2;
            for (var i = 0; i < nodeCount; i++)
            {
                resultGraph.AddNode(i + 1);
            }
            for (var i = 0; i < nodeCount; i++)
            {
                var startIndex = array[i] - 1;
                var nextNodeIndex = array[i + 1] - 1;
                for (var j = startIndex; j < nextNodeIndex; j = j + 2)
                {
                    resultGraph.AddEdge(i + 1, array[j]);
                    var edge = new Edge(new Node(i + 1), new Node(array[j]));
                    if (!weights.ContainsKey(edge))
                        weights.Add(edge, array[j + 1]);
                }
            }
            return Tuple.Create(resultGraph, weights);
        }
    }
}