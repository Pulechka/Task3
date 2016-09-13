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
            RoundList personsRound = new RoundList();

            int count = 15;

            //for (int i = 1; i <= count; i++)
            //    personsRound.AddLast(new Person(i));

            //while(personsRound.Count > 1)
            {

            }


            foreach (var person in personsRound)
            {
                Console.WriteLine(person.Number);
            }
        }

    }
}
