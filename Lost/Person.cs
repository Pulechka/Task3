namespace Lost
{
    public class Person
    {
        public int Number { get; set; }

        public Person(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return "Person #" + Number;
        }
    }
}
