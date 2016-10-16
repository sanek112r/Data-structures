using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BH
{
    class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> _data = new List<T>();

        public void Enqueue(T value)
        {
            _data.Add(value);
            var parentIndex = GetParentIndex(_data.Count - 1);
            var elementIndex = _data.Count - 1;

            while (_data[parentIndex].CompareTo(value) > 0 && parentIndex >= 0)
            {
                Swap(parentIndex, elementIndex);
                elementIndex = parentIndex;
                parentIndex = GetParentIndex(elementIndex);
            }
        }

        public T Dequeue()
        {
            var res = _data.First();

            Swap(0, _data.Count - 1);
            _data.RemoveAt(_data.Count - 1);
            int parent = 0;

            while (true)
            {
                var leftChild = parent * 2 + 1;
                if (leftChild >= _data.Count)
                {
                    break;
                }

                var rightChild = leftChild + 1;
                var minChild = rightChild < _data.Count && _data[leftChild].CompareTo(_data[rightChild]) > 0 ? rightChild : leftChild;

                if (_data[parent].CompareTo(_data[minChild]) > 0)
                {
                    Swap(parent, minChild);
                    parent = minChild;
                }
                else
                {
                    break;
                }
            }

            //Console.WriteLine("Dequeed:" + res);

            return res;
        }

        public void Print()
        {
            foreach (var d in _data)
            {
                Console.Write(d + " ");
            }
        }

        private int GetParentIndex(int ind)
        {
            return (ind - 1) / 2;
        }

        private void Swap(int pos1, int pos2)
        {
            var temp = _data[pos1];
            _data[pos1] = _data[pos2];
            _data[pos2] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}