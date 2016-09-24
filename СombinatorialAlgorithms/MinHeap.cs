using System;
using System.Collections.Generic;

namespace СombinatorialAlgorithms
{
    internal class MinHeap<T> where T : IComparable<T>
    {
        private readonly List<T> _array = new List<T>();

        public int Count => _array.Count;

        public void Add(T element)
        {
            _array.Add(element);
            var c = _array.Count - 1;
            while (c > 0 && _array[c].CompareTo(_array[c/2]) == -1)
            {
                var tmp = _array[c];
                _array[c] = _array[c/2];
                _array[c/2] = tmp;
                c = c/2;
            }
        }

        public T RemoveMin()
        {
            var ret = _array[0];
            _array[0] = _array[_array.Count - 1];
            _array.RemoveAt(_array.Count - 1);

            var c = 0;
            while (c < _array.Count)
            {
                var min = c;
                if (2*c + 1 < _array.Count && _array[2*c + 1].CompareTo(_array[min]) == -1)
                    min = 2*c + 1;
                if (2*c + 2 < _array.Count && _array[2*c + 2].CompareTo(_array[min]) == -1)
                    min = 2*c + 2;

                if (min == c)
                    break;
                var tmp = _array[c];
                _array[c] = _array[min];
                _array[min] = tmp;
                c = min;
            }

            return ret;
        }

        public T Peek()
        {
            return _array[0];
        }
    }
}