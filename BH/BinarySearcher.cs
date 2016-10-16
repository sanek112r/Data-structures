using System;

namespace BH
{
    public static class BinarySearcher
    {
        public static int SearchNonRec<T>(T[] sortedArray, T target) where T:IComparable<T>
        {
            if (sortedArray == null || sortedArray.Length == 0)
            {
                return -1;
            }

            int low = 0;
            int high = sortedArray.Length;

            while (low <= high)
            {
                var pos = (low + high) / 2;

                if (target.CompareTo(sortedArray[pos]) == 0)
                {
                    return pos;
                }

                if (target.CompareTo(sortedArray[pos]) == 1)
                {
                    low = pos;
                }
                else
                {
                    high = pos;
                }
            }

            return -1;
        }

        public static int SearchRec<T>(T[] a, T target) where T : IComparable<T>
        {
            return BinarySearch(a, 0, a.Length - 1, target);
        }

        private static int BinarySearch<T>(T[] a, int start, int end, T target) where T : IComparable<T>
        {
            int middle = (start + end) / 2;

            if (end < start)
            {
                return -1;
            }

            if (target.CompareTo(a[middle]) == 0)
            {
                return middle;
            }

            if (target.CompareTo(a[middle]) == -1)
            {
                return BinarySearch(a, start, middle - 1, target);
            }

            return BinarySearch(a, middle + 1, end, target);
        }
    }
}