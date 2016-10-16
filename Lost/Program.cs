using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = GetN();
            Queue<Person> persons = new Queue<Person>();
            FillQueue(persons, n);           
            Console.WriteLine($"Last person: {GetLastPerson(persons)}");
        }

        private static int GetN()
        {
            int n = 0;

            bool tryInput = true;
            while (tryInput)
            {
                Console.Write("Input N: ");
                tryInput = !int.TryParse(Console.ReadLine(), out n);
            }
            return n;
        }

        private static void FillQueue(Queue<Person> queue, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(new Person(i));
            }
        }


        private static Person GetLastPerson(Queue<Person> persons)
        {
            while (persons.Count > 1)
            {
                persons.Enqueue(persons.Dequeue());
                persons.Dequeue();
            }
            return persons.Dequeue();
        }
    }
}
