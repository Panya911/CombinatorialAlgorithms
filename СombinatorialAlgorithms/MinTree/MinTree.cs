using System;
using System.Collections.Generic;
using System.Linq;
using СombinatorialAlgorithms.GraphModel;

namespace СombinatorialAlgorithms.MinTree
{
    public static class MinTree
    {
        public static Graph BuildDijkstraMinTree(Graph graph, Dictionary<Edge, int> weights)
        {
            var result = new Graph();
            foreach (var node in graph.Nodes)
            {
                result.AddNode(node.Number);
            }

            var nodes = new HashSet<Node>(graph.Nodes);
            var currentNode = nodes.First();
            var previous = new Dictionary<Node, Node>();
            var grayNodes = new HashSet<Node>();

            foreach (var edge in currentNode.Edges)
            {
                var other = edge.Other(currentNode);
                grayNodes.Add(other);
                previous[other] = currentNode;
            }
            nodes.Remove(currentNode);

            while (nodes.Count > 0)
            {
                var min = GetMinElement(grayNodes, x => weights[new Edge(x, previous[x])]);
                result.AddEdge(previous[min].Number, min.Number);
                nodes.Remove(min);
                grayNodes.Remove(min);
                foreach (var edge in min.Edges)
                {
                    var other = edge.Other(min);
                    if (nodes.Contains(other) &&
                        (!previous.ContainsKey(other) ||
                         weights[new Edge(min, other)] < weights[new Edge(other, previous[other])]))
                    {
                        grayNodes.Add(other);
                        previous[other] = min;
                    }
                }
            }
            return result;
        }

        public static Graph BuildKruskalMinTree(Graph graph, Dictionary<Edge, double> weights)
        {
            var result = new Graph();
            foreach (var node in graph.Nodes)
            {
                result.AddNode(node.Number);
            }
            var edges = graph.Edges;
            foreach (var edge in edges.OrderBy(x => weights[x]))
            {
                result.AddEdge(edge.First.Number, edge.Second.Number);
                if (HasCycle(result))
                    result.RemoveEdge(edge.First.Number,edge.Second.Number);
            }
            return result;
        }

        private static bool HasCycle(Graph graph)
        {
            var notVisited = new HashSet<Node>(graph.Nodes);
            var visited = new HashSet<Node>();
            var queue = new Queue<Path>();

            while (notVisited.Count > 0)
            {
                var startNode = notVisited.First();
                queue.Enqueue(new Path(startNode, null));
                visited.Add(startNode);
                notVisited.Remove(startNode);
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    foreach (var edge in node.Node.Edges.Where(x => !x.Other(node.Node).Equals(node.Previous)))
                    {
                        if (visited.Contains(edge.Other(node.Node)))
                        {
                            return true;
                        }
                        visited.Add(edge.Other(node.Node));
                        notVisited.Remove(edge.Other(node.Node));
                        queue.Enqueue(new Path(edge.Other(node.Node), node.Node));
                    }
                }
            }
            return false;
        }

        private static T GetMinElement<T, TKey>(IEnumerable<T> elements, Func<T, TKey> keySelector)
            where TKey : IComparable
        {
            var minElement = elements.First();
            var minKey = keySelector(minElement);

            foreach (var element in elements)
            {
                if (keySelector(element).CompareTo(minKey) >= 0) continue;
                minElement = element;
                minKey = keySelector(element);
            }
            return minElement;
        }

        private class Path
        {
            public Path(Node node, Node previous)
            {
                Node = node;
                Previous = previous;
            }

            public Node Node { get; }
            public Node Previous { get; }
        }
    }
}