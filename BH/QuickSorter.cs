using System;

namespace BH
{
    public class QuickSorter
    {
        public static void Sort<T>(T[] input) where T : IComparable<T>
        {
            SortInternal(input, 0, input.Length - 1);
        }

        private static void SortInternal<T>(T[] input, int l, int r) where T : IComparable<T>
        {
            var middlePos = (l + r) / 2;
            var middle = input[middlePos];
            int i = l;
            int j = r;

            while (i <= j)
            {
                while (input[i].CompareTo(middle) < 0)
                {
                    i++;
                }

                while (input[j].CompareTo(middle) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                    i++;
                    j--;
                }
            }

            if (i < r)
            {
                SortInternal(input, i, r);
            }

            if (l < j)
            {
                SortInternal(input, l, j);
            }
        }
    }
}