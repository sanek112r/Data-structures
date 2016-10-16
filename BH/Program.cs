using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BH
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueExample();

            BinarySearchExample();

            DequeueExample();

            QuickSortExample();

            MergeSortExample();

            LargestCommonSubstringExample();

            Console.Read();
        }

        private static void BinarySearchExample()
        {
            var arr = new[]
            {
                1, 65, 54, 54, 51, 345, 46, 5, 67, 245, 3145, 4, 6, 5, 6, 2654, 67, 45, 7, 5476, 54, 7, 4, 75, 7, 5, 7, 547, 45, 7,
                427, 2, 4245, 7, 457, 4, 74, 51, 2, 3, 4
            };
            Array.Sort(arr);

            Console.WriteLine("Searched for 65. Index in collection:" + BinarySearcher.SearchRec(arr, 65));
            Console.WriteLine("Searched for 65. Index in collection:" + BinarySearcher.SearchNonRec(arr, 65));
        }

        private static void PriorityQueueExample()
        {
            int a1;
            int a2;
            ThreadPool.GetAvailableThreads(out a1, out a2);

            var pq = new PriorityQueue<int>();

            pq.Enqueue(10);
            // pq.Enqueue(8);
            //pq.Enqueue(9);
            //pq.Enqueue(15);
            //pq.Enqueue(3);
            //pq.Enqueue(1);
            pq.Enqueue(5);
            pq.Enqueue(5);

            pq.Enqueue(1);
            pq.Enqueue(9);

            pq.Enqueue(9);
            pq.Enqueue(5);
            pq.Enqueue(22);
            pq.Enqueue(22);

            //  pq.Enqueue(44);
            pq.Enqueue(5);
            pq.Print();
            Console.WriteLine();

            pq.Dequeue();
            pq.Print();
            Console.WriteLine();

            pq.Dequeue();
            pq.Print();
            Console.WriteLine();

            pq.Dequeue();
            pq.Print();
            Console.WriteLine();

            pq.Dequeue();
            pq.Print();
            Console.WriteLine();

            pq.Dequeue();
            pq.Print();
            Console.WriteLine();

            pq.Dequeue();
            pq.Print();
            Console.WriteLine();
        }

        private static void DequeueExample()
        {
            var deq1 = new Dequeue<int>();
            deq1.InsertLeft(1);
            deq1.InsertLeft(2);
            deq1.InsertLeft(4);

            deq1.Print();
            deq1.InsertRight(5);

            deq1.Print();

            Console.WriteLine();
        }

        private static void QuickSortExample()
        {
            var arr = new[]
            {
                1, 4, 5, 46, 56, 341, 5, 4, 6554, 6, 5467, 54, 714, 5, 4, 3, 3, 2, 2, 3, 54, 76, 78, 3, 6, 34654, 6, 46,
                426, 567, 251, 34
            };

            QuickSorter.Sort(arr);

            Console.WriteLine(String.Join(" ", arr.Select(d => d)));
        }

        private static void MergeSortExample()
        {
            var arr = new[]
            {
                1, 4, 5, 46, 56, 341, 5, 4, 6554, 6, 5467, 54, 714, 5, 4, 3, 3, 2, 2, 3, 54, 76, 78, 3, 6, 34654, 6, 46,
                426, 567, 251, 34
            };

            Console.WriteLine(String.Join(" ", MergeSorter.Sort(arr.ToList())));
        }

        private static void LargestCommonSubstringExample()
        {
            var input1 = "abcdef";
            var input2 = "acgefjk";

            var t = new int[input1.Length + 1, input2.Length + 1];

            for (int i = 1; i <= input1.Length; i++)
            {
                for (int j = 1; j <= input2.Length; j++)
                {
                    if (input1[i - 1] == input2[j - 1])
                    {
                        t[i, j] = t[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        t[i, j] = Math.Max(t[i - 1, j], t[i, j - 1]);
                    }
                }
            }

            int i1 = input1.Length;
            int j1 = input2.Length;

            var str = "";

            while (i1 > 0 && j1 > 0)
            {
                if (t[i1, j1] > t[i1 - 1, j1])
                {
                    str = input1[i1 - 1] + str;
                    i1--;
                    j1--;
                }
                else
                {
                    i1--;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Input1:" + input1);
            Console.WriteLine("Input2:" + input2);
            Console.WriteLine("Longest common subsequent string:" + str);
            Console.WriteLine("Length:" + t[input1.Length, input2.Length]);
        }
    }
}
