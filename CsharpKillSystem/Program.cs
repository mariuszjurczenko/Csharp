using System;
using System.Collections.Generic;

namespace CsharpKillSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
                new Person() { Id = i, Name = i.ToString(), Email = i.ToString() };

                if (i % 100000 == 0)
                {
                    Console.WriteLine(GetTotalCollections());
                }
            }
        }

        static int GetTotalCollections()
        {
            return GC.CollectionCount(0) +
                   GC.CollectionCount(1) +
                   GC.CollectionCount(2);
        }

        static List<Person> people = new List<Person>();
    }
}
