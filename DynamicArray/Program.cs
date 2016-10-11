using System;
using System.Collections.Generic;

namespace DynamicArrayTask
{
    class Program
    {
        static void ShowResult<T>(DynamicArray<T> arr, string message)
        {
            Console.WriteLine(message);
            arr.Show();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            DynamicArray<int> arr1 = new DynamicArray<int>();
            ShowResult(arr1, "arr1:");

            arr1.Add(10);
            arr1.Add(2);
            ShowResult(arr1, "arr1.Add(10); arr1.Add(2);");

            DynamicArray<int> arr2 = new DynamicArray<int>(11);
            arr2.Add(-7);
            ShowResult(arr2, "arr2(11); arr2.Add(-7)");

            Stack<int> stack = new Stack<int>();
            for (int i = 1; i <= 10; i++)
                stack.Push(i);
            DynamicArray<int> arr3 = new DynamicArray<int>(stack);
            ShowResult(arr3, "arr3 (from stack(10))");

            arr3.Add(100);
            ShowResult(arr3, "arr3.Add(100)");

            arr2.AddRange(stack);
            ShowResult(arr2, "arr2.AddRange(stack)");

            arr1.AddRange(stack);
            ShowResult(arr1, "arr1.AddRange(stack)");

            arr1.Remove(10);
            ShowResult(arr1, "arr1.Remove(10)");

            try
            {
                arr1.Insert(3, 256);
                ShowResult(arr1, "arr1.Insert(3,256)");

                arr2.Insert(0, -10);
                ShowResult(arr2, "arr2.Insert(0,-10)");

                arr2[2] = 1000;
                ShowResult(arr2, "arr2[2] = 1000");

                Console.WriteLine("arr2[1] = " + arr2[1]); Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("foreach in arr2");
            foreach (var item in arr2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(); Console.WriteLine();

            Console.WriteLine("arr2[-2] = "+arr2[-2]); Console.WriteLine();

            arr2.Capacity = 5;
            ShowResult(arr2, "arr2.Capacity = 5");

            arr2.Capacity = 9;
            ShowResult(arr2, "arr2.Capacity = 9");

            DynamicArray<int> arr4 = (DynamicArray<int>)arr2.Clone();
            ShowResult(arr4, "arr4 = arr2.Clone()");

            arr4[0] = 999; Console.WriteLine("arr4[0] = 999;\n");
            ShowResult(arr2, "arr2");
            ShowResult(arr4, "arr4");

            DynamicArray<Point> arr5 = new DynamicArray<Point>();
            arr5.AddRange(new Point[] {new Point(0,0), new Point(1, 1), new Point(2, 2), });
            ShowResult(arr5, "arr5");

            DynamicArray<Point> arr6 = (DynamicArray<Point>)arr5.Clone();
            ShowResult(arr6, "arr6 = arr5.Clone()");

            arr5[0] = new Point(5, 5);
            Console.WriteLine("arr5[0] = (5,5)");
            ShowResult(arr5, "arr5");
            ShowResult(arr6, "arr6");

            Point[] pointArray = arr6.ToArray();
            Console.WriteLine("arr6.ToArray()");
            foreach (var item in pointArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            Console.WriteLine("--------------------------------------------------------");
            CycledDynamicArray<int> arr7 = new CycledDynamicArray<int>();
            arr7.AddRange(new int[] { 1, 2, 3, 4, 5, 6 });
            arr7.Show();

            foreach (var item in arr7)
            {
                Console.WriteLine(item);
            }
        }
    }


}
