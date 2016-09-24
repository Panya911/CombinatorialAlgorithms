using System;
using System.Collections.Generic;
using System.Linq;

namespace СombinatorialAlgorithms.GraphModel
{
    public class Node
    {
        public Node(int number)
        {
            Number = number;
            Edges = new List<Edge>();
        }

        public int Number { get; }

        public List<Edge> Edges { get; }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Node;
            return other != null && Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }

    public class Edge
    {
        public Edge(Node first, Node second)
        {
            First = first;
            Second = second;
        }

        public Node First { get; }
        public Node Second { get; }

        public Node Other(Node node)
        {
            if (node.Equals(First))
                return Second;
            if (node.Equals(Second))
                return First;
            throw new Exception($"node {node} not belong {this} edge");
        }

        public override string ToString()
        {
            return $"({First}-{Second})";
        }

        public override bool Equals(object obj)
        {
            var other = obj as Edge;
            if (other == null)
            {
                return false;
            }
            return (First.Equals(other.First) && Second.Equals(other.Second)) ||
                   (First.Equals(other.Second) && Second.Equals(other.First));
        }

        public override int GetHashCode()
        {
            return First.GetHashCode() + Second.GetHashCode();
        }
    }

    public class Graph
    {
        private readonly HashSet<Edge> edges;
        private readonly HashSet<Node> nodes;

        public Graph()
        {
            edges = new HashSet<Edge>();
            nodes = new HashSet<Node>();
        }


        public IEnumerable<Node> Nodes => nodes;

        public IEnumerable<Edge> Edges => edges;

        public void AddEdge(int first, int second)
        {
            var firstNode = nodes.First(x => x.Number.Equals(first));
            var secondNode = nodes.First(x => x.Number.Equals(second));


            var edge = new Edge(firstNode, secondNode);
            edges.Add(edge);
            firstNode.Edges.Add(edge);
            secondNode.Edges.Add(edge);
        }

        public void RemoveEdge(int first, int second)
        {
            var edge = edges.First(x => (x.First.Number.Equals(first) && x.Second.Number.Equals(second)) ||
                                        (x.First.Number.Equals(second) && x.Second.Number.Equals(first)));
            edge.First.Edges.Remove(edge);
            edge.Second.Edges.Remove(edge);
            edges.Remove(edge);
        }

        public void AddNode(int nodeNumber)
        {
            var node = new Node(nodeNumber);
            nodes.Add(node);
        }
    }
}