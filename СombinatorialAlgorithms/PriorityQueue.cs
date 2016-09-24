using System;

namespace СombinatorialAlgorithms
{
    internal class PriorityQueue<T>
    {
        private readonly MinHeap<Node> _minHeap = new MinHeap<Node>();

        public int Count => _minHeap.Count;

        public void Add(int priority, T element)
        {
            _minHeap.Add(new Node {Priority = priority, Element = element});
        }

        public T RemoveMin()
        {
            return _minHeap.RemoveMin().Element;
        }

        public T Peek()
        {
            return _minHeap.Peek().Element;
        }

        private class Node : IComparable<Node>
        {
            public T Element;
            public int Priority;

            public int CompareTo(Node other)
            {
                return Priority.CompareTo(other.Priority);
            }
        }
    }
}