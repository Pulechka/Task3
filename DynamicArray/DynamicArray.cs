using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayTask
{
    public class DynamicArray<T>
    {
        private T[] data;
        private int length;

        public int Capacity
        {
            get { return data.Length; }
        }


        public int Length
        {
            get { return length; }
        }


        public DynamicArray()
        {
            data = new T[8];
            length = 0;
        }


        public DynamicArray(int capacity)
        {
            data = new T[capacity];
            length = 0;
        }


        public DynamicArray(IEnumerable<T> col)
        {
            IEnumerator<T> enumerator = col.GetEnumerator();

            int count = 0;
            while (enumerator.MoveNext())
                count++;
            
            data = new T[count];

            enumerator.Reset();
            enumerator.MoveNext();
            for (int i = 0; i < count; i++)
            {
                data[i] = enumerator.Current;
                enumerator.MoveNext();
            }

            length = data.Length;
        }


        public void Add(T newItem)
        {
            if (length == Capacity) //raise capacity
            {
                T[] temp = data;
                data = new T[Capacity * 2];
                temp.CopyTo(data, 0);
            }

            data[length] = newItem;
            length++;
        }

        public void AddRange(IEnumerable<T> col)
        {
            IEnumerator<T> enumerator = col.GetEnumerator();

            int count = 0;
            while (enumerator.MoveNext())
                count++;

            if (Capacity < length + count) //raise capacity
            {
                int newCapacity = Capacity * 2;
                while (newCapacity < length + count)
                    newCapacity *= 2;

                T[] temp = data;
                data = new T[newCapacity];
                temp.CopyTo(data, 0);
            }

            enumerator.Reset();
            enumerator.MoveNext();
            for (int i = length; i < count+length; i++)
            {
                data[i] = enumerator.Current;
                enumerator.MoveNext();
            }

            length += count;
        }


        public bool Remove(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (data[i].Equals(item))
                {
                    for (int j = i; j < length; j++)
                    {
                        data[j] = data[j + 1];

                    }
                    data[length] = default(T);
                    length--;
                    return true;
                }
            }
            return false;
        }


        public bool Insert(T item, int index)
        {
            if (index <= length || index < 0)
                throw new ArgumentOutOfRangeException("index");


            return false;
        }

        public void Show()
        {
            Console.WriteLine($"Length = {length}");
            Console.WriteLine($"Capacity = {Capacity}");
            foreach (var item in data)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
