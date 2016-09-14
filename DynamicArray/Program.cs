using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> arr1 = new DynamicArray<int>();
            Console.WriteLine("arr1:");
            arr1.Show();
            Console.WriteLine();

            arr1.Add(10);
            arr1.Add(2);
            Console.WriteLine("arr1.Add(10); arr1.Add(2);");
            arr1.Show();
            Console.WriteLine();

            DynamicArray<int> arr2 = new DynamicArray<int>(11);
            arr2.Add(-5);
            Console.WriteLine("arr2(11); arr2.Add(-5)");
            arr2.Show();
            Console.WriteLine();

            Stack<int> stack = new Stack<int>();
            for (int i = 1; i <= 10; i++)
                stack.Push(i);
            DynamicArray<int> arr3 = new DynamicArray<int>(stack);
            Console.WriteLine("arr3 (from stack(10))");
            arr3.Show();
            Console.WriteLine();

            arr3.Add(100);
            Console.WriteLine("arr3.Add(100)");
            arr3.Show();
            Console.WriteLine();

            arr2.AddRange(stack);
            Console.WriteLine("arr2.AddRange(stack)");
            arr2.Show();
            Console.WriteLine();

            arr1.AddRange(stack);
            Console.WriteLine("arr1.AddRange(stack)");
            arr1.Show();
            Console.WriteLine();

            arr1.Remove(10);
            Console.WriteLine("arr1.Remove(10)");
            arr1.Show();
            Console.WriteLine();

            try
            {
                arr1.Insert(3, 256);
                Console.WriteLine("arr1.Insert(3,256)");
                arr1.Show();
                Console.WriteLine();

                arr2.Insert(0, -10);
                Console.WriteLine("arr2.Insert(0,-10)");
                arr2.Show();
                Console.WriteLine();

                arr2[2] = 1000;
                Console.WriteLine("arr2[2] = 1000)");
                arr2.Show();
                Console.WriteLine();

                Console.WriteLine("arr2[1] = "+arr2[1]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
