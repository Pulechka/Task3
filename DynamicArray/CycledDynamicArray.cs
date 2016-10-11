using System.Collections;
using System.Collections.Generic;

namespace DynamicArrayTask
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base() { }

        public CycledDynamicArray(int capacity) : base(capacity) { }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection) { }

        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }
    }

    public class CycledDynamicArrayEnumerator<T> : DynamicArrayEnumerator<T>
    {
        public CycledDynamicArrayEnumerator(DynamicArray<T> dataArray) : base(dataArray)
        {
        }

        public override bool MoveNext()
        {
            position++;
            if (position >= count)
            {
                Reset();
                position++;
            }
            return true;
        }
    }
}
