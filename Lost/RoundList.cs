using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost
{
    public class RoundList : IEnumerable<Person>
    {
        IEnumerator<Person> en;

        public IEnumerator<Person> GetEnumerator()
        {
            return en;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
