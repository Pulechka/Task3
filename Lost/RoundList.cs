using System;
using System.Collections;
using System.Collections.Generic;

namespace Lost
{
    public class RoundList 
    {
        private List<Person> persons;
        private int position;

        RoundList()
        {
            persons = new List<Person>();
            position = -1;
        }

        //public void MoveNext()
        //{
        //    position++;
        //}

        public Person Current
        {
            get { return persons[position]; }
        }

        public void RemoveNext()
        {
            persons.RemoveAt(position++);
        }
    }
}
