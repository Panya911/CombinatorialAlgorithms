using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using СombinatorialAlgorithms.GraphModel;
using СombinatorialAlgorithms.MinTree;

namespace Tests
{
    [TestFixture]
    internal class MinTreeAlgorithm_Should
    {
        [Test]
        public void calculate_dijkstra_min_tree_on_pasha_graph()
        {
            var graph = new Graph();
            var nodes = new[]
            {
                new Node(1),
                new Node(2),
                new Node(3),
                new Node(4),
                new Node(5)
            };
            graph.AddNode(nodes[0].Number);
            graph.AddNode(nodes[1].Number);
            graph.AddNode(nodes[2].Number);
            graph.AddNode(nodes[3].Number);
            graph.AddNode(nodes[4].Number);

            graph.AddEdge(nodes[0].Number, nodes[1].Number);
            graph.AddEdge(nodes[0].Number, nodes[2].Number);
            graph.AddEdge(nodes[0].Number, nodes[3].Number);
            graph.AddEdge(nodes[0].Number, nodes[4].Number);

            graph.AddEdge(nodes[1].Number, nodes[2].Number);
            graph.AddEdge(nodes[1].Number, nodes[3].Number);
            graph.AddEdge(nodes[1].Number, nodes[4].Number);

            graph.AddEdge(nodes[2].Number, nodes[3].Number);
            graph.AddEdge(nodes[2].Number, nodes[4].Number);

            graph.AddEdge(nodes[3].Number, nodes[4].Number);

            var weights = new Dictionary<Edge, int>
            {
                {new Edge(nodes[0], nodes[1]), 8},
                {new Edge(nodes[0], nodes[2]), 6},
                {new Edge(nodes[0], nodes[3]), 5},
                {new Edge(nodes[0], nodes[4]), 10},
                {new Edge(nodes[1], nodes[2]), 12},
                {new Edge(nodes[1], nodes[3]), 3},
                {new Edge(nodes[1], nodes[4]), 4},
                {new Edge(nodes[2], nodes[3]), 11},
                {new Edge(nodes[2], nodes[4]), 16},
                {new Edge(nodes[3], nodes[4]), 7}
            };

            var result = MinTree.BuildDijkstraMinTree(graph, weights);

            result.Edges.Count().Should().Be(4);
            result.Edges.Should().BeEquivalentTo(
                new Edge(nodes[0], nodes[2]),
                new Edge(nodes[0], nodes[3]),
                new Edge(nodes[3], nodes[1]),
                new Edge(nodes[1], nodes[4]));
        }

        [Test]
        public void calculate_kruskal_min_tree_on_pasha_graph()
        {
            var graph = new Graph();
            var nodes = new[]
            {
                new Node(1),
                new Node(2),
                new Node(3),
                new Node(4),
                new Node(5)
            };
            graph.AddNode(nodes[0].Number);
            graph.AddNode(nodes[1].Number);
            graph.AddNode(nodes[2].Number);
            graph.AddNode(nodes[3].Number);
            graph.AddNode(nodes[4].Number);

            graph.AddEdge(nodes[0].Number, nodes[1].Number);
            graph.AddEdge(nodes[0].Number, nodes[2].Number);
            graph.AddEdge(nodes[0].Number, nodes[3].Number);
            graph.AddEdge(nodes[0].Number, nodes[4].Number);

            graph.AddEdge(nodes[1].Number, nodes[2].Number);
            graph.AddEdge(nodes[1].Number, nodes[3].Number);
            graph.AddEdge(nodes[1].Number, nodes[4].Number);

            graph.AddEdge(nodes[2].Number, nodes[3].Number);
            graph.AddEdge(nodes[2].Number, nodes[4].Number);

            graph.AddEdge(nodes[3].Number, nodes[4].Number);

            var weights = new Dictionary<Edge, double>
            {
                {new Edge(nodes[0], nodes[1]), 8},
                {new Edge(nodes[0], nodes[2]), 6},
                {new Edge(nodes[0], nodes[3]), 5},
                {new Edge(nodes[0], nodes[4]), 10},
                {new Edge(nodes[1], nodes[2]), 12},
                {new Edge(nodes[1], nodes[3]), 3},
                {new Edge(nodes[1], nodes[4]), 4},
                {new Edge(nodes[2], nodes[3]), 11},
                {new Edge(nodes[2], nodes[4]), 16},
                {new Edge(nodes[3], nodes[4]), 7}
            };

            var result = MinTree.BuildKruskalMinTree(graph, weights);

            result.Edges.Count().Should().Be(4);
            result.Edges.Should().BeEquivalentTo(
                new Edge(nodes[0], nodes[2]),
                new Edge(nodes[0], nodes[3]),
                new Edge(nodes[3], nodes[1]),
                new Edge(nodes[1], nodes[4]));
        }

        [Test]
        public void calculate_dijkstra_min_tree_on_very_difficult_graph()
        {
            var graph = new Graph();
            var nodes = new[]
            {
                new Node(0),
                new Node(1),
                new Node(2),
                new Node(3),
                new Node(4),
                new Node(5),
                new Node(6),
                new Node(7),
                new Node(8),
                new Node(9)
            };
            graph.AddNode(nodes[0].Number);
            graph.AddNode(nodes[1].Number);
            graph.AddNode(nodes[2].Number);
            graph.AddNode(nodes[3].Number);
            graph.AddNode(nodes[4].Number);
            graph.AddNode(nodes[5].Number);
            graph.AddNode(nodes[6].Number);
            graph.AddNode(nodes[7].Number);
            graph.AddNode(nodes[8].Number);
            graph.AddNode(nodes[9].Number);


            graph.AddEdge(nodes[0].Number, nodes[1].Number);
            graph.AddEdge(nodes[0].Number, nodes[3].Number);
            graph.AddEdge(nodes[0].Number, nodes[4].Number);


            graph.AddEdge(nodes[1].Number, nodes[2].Number);
            graph.AddEdge(nodes[1].Number, nodes[3].Number);
            graph.AddEdge(nodes[1].Number, nodes[6].Number);

            graph.AddEdge(nodes[2].Number, nodes[3].Number);
            graph.AddEdge(nodes[2].Number, nodes[6].Number);
            graph.AddEdge(nodes[2].Number, nodes[5].Number);

            graph.AddEdge(nodes[3].Number, nodes[4].Number);
            graph.AddEdge(nodes[3].Number, nodes[5].Number);

            graph.AddEdge(nodes[4].Number, nodes[5].Number);
            graph.AddEdge(nodes[4].Number, nodes[9].Number);

            graph.AddEdge(nodes[5].Number, nodes[6].Number);
            graph.AddEdge(nodes[5].Number, nodes[8].Number);
            graph.AddEdge(nodes[5].Number, nodes[9].Number);

            graph.AddEdge(nodes[6].Number, nodes[7].Number);
            graph.AddEdge(nodes[6].Number, nodes[8].Number);

            graph.AddEdge(nodes[7].Number, nodes[8].Number);
            graph.AddEdge(nodes[7].Number, nodes[9].Number);

            graph.AddEdge(nodes[8].Number, nodes[9].Number);


            var weights = new Dictionary<Edge, int>
            {
                {new Edge(nodes[0], nodes[1]), 6},
                {new Edge(nodes[0], nodes[3]), 3},
                {new Edge(nodes[0], nodes[4]), 9},

                {new Edge(nodes[1], nodes[2]), 2},
                {new Edge(nodes[1], nodes[3]), 4},
                {new Edge(nodes[1], nodes[6]), 9},

                {new Edge(nodes[2], nodes[3]), 2},
                {new Edge(nodes[2], nodes[6]), 9},
                {new Edge(nodes[2], nodes[5]), 8},

                {new Edge(nodes[3], nodes[4]), 9},
                {new Edge(nodes[3], nodes[5]), 9},

                {new Edge(nodes[4], nodes[5]), 8},
                {new Edge(nodes[4], nodes[9]), 18},

                {new Edge(nodes[5], nodes[6]), 7},
                {new Edge(nodes[5], nodes[8]), 9},
                {new Edge(nodes[5], nodes[9]), 10},

                {new Edge(nodes[6], nodes[7]), 4},
                {new Edge(nodes[6], nodes[8]), 5},

                {new Edge(nodes[7], nodes[8]), 1},
                {new Edge(nodes[7], nodes[9]), 4},

                {new Edge(nodes[8], nodes[9]), 3}
            };

            var result = MinTree.BuildDijkstraMinTree(graph, weights);

            result.Edges.Count().Should().Be(9);
            result.Edges.Should().BeEquivalentTo(
                new Edge(nodes[0], nodes[3]),
                new Edge(nodes[2], nodes[3]),
                new Edge(nodes[1], nodes[2]),
                new Edge(nodes[2], nodes[5]),
                new Edge(nodes[4], nodes[5]),
                new Edge(nodes[5], nodes[6]),
                new Edge(nodes[6], nodes[7]),
                new Edge(nodes[7], nodes[8]),
                new Edge(nodes[8], nodes[9]));
        }

        [Test]
        public void calculate_kruskal_min_tree_on_very_difficult_graph()
        {
            var graph = new Graph();
            var nodes = new[]
            {
                new Node(0),
                new Node(1),
                new Node(2),
                new Node(3),
                new Node(4),
                new Node(5),
                new Node(6),
                new Node(7),
                new Node(8),
                new Node(9)
            };
            graph.AddNode(nodes[0].Number);
            graph.AddNode(nodes[1].Number);
            graph.AddNode(nodes[2].Number);
            graph.AddNode(nodes[3].Number);
            graph.AddNode(nodes[4].Number);
            graph.AddNode(nodes[5].Number);
            graph.AddNode(nodes[6].Number);
            graph.AddNode(nodes[7].Number);
            graph.AddNode(nodes[8].Number);
            graph.AddNode(nodes[9].Number);


            graph.AddEdge(nodes[0].Number, nodes[1].Number);
            graph.AddEdge(nodes[0].Number, nodes[3].Number);
            graph.AddEdge(nodes[0].Number, nodes[4].Number);


            graph.AddEdge(nodes[1].Number, nodes[2].Number);
            graph.AddEdge(nodes[1].Number, nodes[3].Number);
            graph.AddEdge(nodes[1].Number, nodes[6].Number);

            graph.AddEdge(nodes[2].Number, nodes[3].Number);
            graph.AddEdge(nodes[2].Number, nodes[6].Number);
            graph.AddEdge(nodes[2].Number, nodes[5].Number);

            graph.AddEdge(nodes[3].Number, nodes[4].Number);
            graph.AddEdge(nodes[3].Number, nodes[5].Number);

            graph.AddEdge(nodes[4].Number, nodes[5].Number);
            graph.AddEdge(nodes[4].Number, nodes[9].Number);

            graph.AddEdge(nodes[5].Number, nodes[6].Number);
            graph.AddEdge(nodes[5].Number, nodes[8].Number);
            graph.AddEdge(nodes[5].Number, nodes[9].Number);

            graph.AddEdge(nodes[6].Number, nodes[7].Number);
            graph.AddEdge(nodes[6].Number, nodes[8].Number);

            graph.AddEdge(nodes[7].Number, nodes[8].Number);
            graph.AddEdge(nodes[7].Number, nodes[9].Number);

            graph.AddEdge(nodes[8].Number, nodes[9].Number);


            var weights = new Dictionary<Edge, double>
            {
                {new Edge(nodes[0], nodes[1]), 6},
                {new Edge(nodes[0], nodes[3]), 3},
                {new Edge(nodes[0], nodes[4]), 9},

                {new Edge(nodes[1], nodes[2]), 2},
                {new Edge(nodes[1], nodes[3]), 4},
                {new Edge(nodes[1], nodes[6]), 9},

                {new Edge(nodes[2], nodes[3]), 2},
                {new Edge(nodes[2], nodes[6]), 9},
                {new Edge(nodes[2], nodes[5]), 8},

                {new Edge(nodes[3], nodes[4]), 9},
                {new Edge(nodes[3], nodes[5]), 9},

                {new Edge(nodes[4], nodes[5]), 8},
                {new Edge(nodes[4], nodes[9]), 18},

                {new Edge(nodes[5], nodes[6]), 7},
                {new Edge(nodes[5], nodes[8]), 9},
                {new Edge(nodes[5], nodes[9]), 10},

                {new Edge(nodes[6], nodes[7]), 4},
                {new Edge(nodes[6], nodes[8]), 5},

                {new Edge(nodes[7], nodes[8]), 1},
                {new Edge(nodes[7], nodes[9]), 4},

                {new Edge(nodes[8], nodes[9]), 3}
            };

            var result = MinTree.BuildKruskalMinTree(graph, weights);

            result.Edges.Count().Should().Be(9);
            result.Edges.Should().BeEquivalentTo(
                new Edge(nodes[0], nodes[3]),
                new Edge(nodes[2], nodes[3]),
                new Edge(nodes[1], nodes[2]),
                new Edge(nodes[2], nodes[5]),
                new Edge(nodes[4], nodes[5]),
                new Edge(nodes[5], nodes[6]),
                new Edge(nodes[6], nodes[7]),
                new Edge(nodes[7], nodes[8]),
                new Edge(nodes[8], nodes[9]));
        }

    }
}