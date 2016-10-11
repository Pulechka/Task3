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
            int N = 0;

            bool tryInput = true;
            while (tryInput)
            {
                Console.Write("Input N: ");
                tryInput = !int.TryParse(Console.ReadLine(), out N);
            }

            Queue<Person> persons = new Queue<Person>();
            for (int i = 1; i <=N; i++)
            {
                persons.Enqueue(new Person(i));
            }

            while (persons.Count >1)
            {
                persons.Enqueue(persons.Dequeue());
                persons.Dequeue();
            }
            
            Console.WriteLine($"Last person: {persons.Dequeue()}");

        }

    }
}
