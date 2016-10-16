using System;
using System.Collections.Generic;
using System.Linq;

namespace BH
{
    public class Dequeue<T>
    {
        private readonly LinkedList<T> _data = new LinkedList<T>();

        public void InsertLeft(T val)
        {
            _data.AddFirst(val);
        }

        public void InsertRight(T val)
        {
            _data.AddLast(val);
        }

        public T RemoveLeft()
        {
            var res = _data.First.Value;
            _data.RemoveFirst();

            return res;
        }

        public T RemoveRight()
        {
            var res = _data.Last.Value;
            _data.RemoveLast();

            return res;
        }

        public void Print()
        {
            Console.WriteLine(String.Join(" ", _data.Select(d => d)));
        }
    }
}