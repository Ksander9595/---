using System;

namespace draft
{
    class Person
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int value = r.Next(1, 3);
            Console.WriteLine(value);
            
        }
    }
}
