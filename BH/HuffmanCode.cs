using System;
using System.Linq;

namespace BH
{
    public class HuffmanCode
    {
        private readonly string _input;
        private readonly HuffmanNode _node;

        public HuffmanCode(string input)
        {
            _input = input;
            _node = BuildCodeTree(_input);
        }

        public string Encode()
        {
            var symbolAndCodes = _input.Distinct().ToDictionary(s => s, _node.Traverse);

            return _input.Aggregate("", (s, c) => s + symbolAndCodes[c]);
        }

        public string Decode(string input)
        {
            var rootTemp = _node;

            var res = "";
            foreach (var f1 in input)
            {
                rootTemp = f1 == '1' ? rootTemp.Right : rootTemp.Left;

                if (rootTemp.IsLeaf)
                {
                    res += rootTemp.C;
                    rootTemp = _node;
                }
            }

            return res;
        }

        private HuffmanNode BuildCodeTree(string input)
        {
            var dict = input
                .ToLookup(i => i)
                .ToDictionary(i => i.Key, f => f.Count());

            var pq = new PriorityQueue<HuffmanNode>();

            foreach (var d in dict)
            {
                pq.Enqueue(new HuffmanNode(d.Key, d.Value));
            }

            while (pq.Count() > 1)
            {
                var right = pq.Dequeue();
                var left = pq.Dequeue();

                var newNode = new HuffmanNode(right.C + left.C, right.Freq + left.Freq)
                {
                    Left = left,
                    Right = right
                };

                pq.Enqueue(newNode);
            }

            return pq.Dequeue();
        }
    }

    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public string C { get; set; }
        public int Freq { get; set; }

        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }

        public HuffmanNode(char c, int freq)
        {
            C = c.ToString();
            Freq = freq;
        }

        public HuffmanNode(string c, int freq)
        {
            C = c;
            Freq = freq;
        }

        public int CompareTo(HuffmanNode other)
        {
            if (Freq.CompareTo(other.Freq) != 0)
            {
                return Freq.CompareTo(other.Freq);
            }

            return other.C.Length.CompareTo(C.Length);
        }

        public override string ToString()
        {
            return "\r\nSymbol:" + C + " Freq:" + Freq;
        }

        public string Traverse(char c)
        {
            return TraverseInternal(this, c, "");
        }

        private string TraverseInternal(HuffmanNode node, char c, string temp)
        {
            if (node.C == c.ToString())
            {
                return temp;
            }

            if (node.Left.C.Contains(c))
            {
                return TraverseInternal(node.Left, c, temp + "0");
            }

            if (node.Right.C.Contains(c))
            {
                return TraverseInternal(node.Right, c, temp + "1");
            }

            throw new InvalidOperationException("Unknown symbol");
        }

        public bool IsLeaf { get { return Left == null && Right == null; } }
    }
}