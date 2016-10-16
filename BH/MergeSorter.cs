using System.Collections.Generic;
using System.Linq;

namespace BH
{
    public class MergeSorter
    {
        public static List<int> Sort(List<int> input)
        {
            if (input.Count <= 1)
            {
                return input;
            }

            var left = new List<int>();
            var right = new List<int>();

            left.AddRange(input.Take(input.Count / 2));
            right.AddRange(input.Skip(input.Count / 2));

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        //https://en.wikipedia.org/wiki/Merge_sort - Top-down
        private static List<int> Merge(List<int> left, List<int> right)
        {
            var res = new List<int>();

            while (left.Any() && right.Any())
            {
                if (left.First() <= right.First())
                {
                    res.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    res.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            res.AddRange(left);
            res.AddRange(right);

            return res;

        }
    }
}