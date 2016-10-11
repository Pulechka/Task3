using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArrayTask
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        protected T[] data;
        protected int count;

        public int Capacity
        {
            get { return data.Length; }
            set
            {
                if (value <=0)
                    throw new ArgumentOutOfRangeException("capacity", "Capacity should be positive");
                if (value > data.Length) //copy all values
                {
                    T[] temp = new T[count];
                    data.CopyTo(temp, 0);
                    data = new T[value];
                    temp.CopyTo(data, 0);
                }
                else // cut values
                {
                    T[] temp = new T[value];
                    for (int i = 0; i < value; i++)
                    {
                        temp[i] = data[i];
                    }
                    data = new T[value];
                    temp.CopyTo(data, 0);
                    count = data.Length;
                }
            }
        }


        public int Count
        {
            get { return count; }
        }


        public DynamicArray()
        {
            data = new T[8];
            count = 0;
        }


        public DynamicArray(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException("capacity", "Capacity should be positive");
            data = new T[capacity];
            count = 0;
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

            this.count = data.Length;
        }


        public void Add(T newItem)
        {
            if (count == Capacity) //raise capacity
            {
                T[] temp = data;
                data = new T[Capacity * 2];
                temp.CopyTo(data, 0);
            }

            data[count] = newItem;
            count++;
        }

        public void AddRange(IEnumerable<T> col)
        {
            IEnumerator<T> enumerator = col.GetEnumerator();

            int count = 0;
            while (enumerator.MoveNext())
                count++;

            if (Capacity < this.count + count) //raise capacity
            {
                int newCapacity = Capacity * 2;
                while (newCapacity < this.count + count)
                    newCapacity *= 2;

                T[] temp = data;
                data = new T[newCapacity];
                temp.CopyTo(data, 0);
            }

            enumerator.Reset();
            enumerator.MoveNext();
            for (int i = this.count; i < count+ this.count; i++)
            {
                data[i] = enumerator.Current;
                enumerator.MoveNext();
            }

            this.count += count;
        }


        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(item))
                {
                    for (int j = i; j < count; j++)
                    {
                        data[j] = data[j + 1];

                    }
                    data[count] = default(T);
                    count--;
                    return true;
                }
            }
            return false;
        }


        public bool Insert(int index, T item)
        {
            if (index > count || index < 0)
                throw new ArgumentOutOfRangeException("index");

            if (count == Capacity) //raise capacity
            {
                T[] temp = data;
                data = new T[Capacity * 2];
                temp.CopyTo(data, 0);
            }

            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = item;
            count++;

            return true;

            //когда возвращать false ?????????????????????????????????????????????????????????????????????
        }


        public void Show()
        {
            Console.WriteLine($"Count = {Count}");
            Console.WriteLine($"Capacity = {Capacity}");
            for (int i = 0; i < data.Length; i++)
            {
                if (i < Count)
                    Console.Write($"{data[i]} ");
                else
                    Console.Write("x ");
            }
            Console.WriteLine();
        }


        public T this[int index]
        {
            get
            {
                if (index >= count)
                    throw new ArgumentOutOfRangeException("index");
                else if (index < 0)
                    return data[count + index];
                else
                    return data[index];
            }
            set
            {
                if (index >= count)
                    throw new ArgumentOutOfRangeException("index");
                else if (index < 0)
                    data[count + index] = value;
                else
                    data[index] = value;
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            DynamicArray<T> copy = new DynamicArray<T>();
            copy.data = new T[Capacity];
            data.CopyTo(copy.data,0);
            copy.count = count;
            return copy;
        }

        public T[] ToArray()
        {
            T[] resultArray = new T[count];
            for (int i = 0; i < count; i++)
            {
                resultArray[i] = data[i];
            }
            return resultArray;
        }
    }


    public class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        protected int position = -1;
        protected T[] data;
        protected int count;

        public DynamicArrayEnumerator(DynamicArray<T> dataArray)
        {
            data = dataArray.ToArray();
            count = dataArray.Count;
        }

        public T Current
        {
            get
            {
                try { return data[position]; }
                catch(IndexOutOfRangeException) { throw new InvalidOperationException(); }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose() { }

        public virtual bool MoveNext()
        {
            position++;
            return (position < count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}