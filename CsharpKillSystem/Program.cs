using System;
using System.Collections.Generic;

namespace CsharpKillSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            Test2();
        }

        static void Test2()
        {
            Console.WriteLine($"Szacowane bajty na stercie: {GC.GetTotalMemory(false)}");
            Console.WriteLine($"Ten system operacyjny ma {GC.MaxGeneration + 1}");

            Person person = new Person() { Email = "marcin@dev-hobby.pl" };
            Console.WriteLine(person.ToString());
            Console.WriteLine($"Generacja osoby to: {GC.GetGeneration(person)}");

            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"Generacja osoby to: {GC.GetGeneration(person)}");

            object[] lotOfObjects = new object[1000000];
            for (int i = 0; i < 1000000; i++)
                lotOfObjects[i] = new object();

            if (lotOfObjects[500000] != null)
                Console.WriteLine($"Generacja lotOfObjects[50000] jest: {GC.GetGeneration(lotOfObjects[50000])}");
            else
                Console.WriteLine("Już nie żyje");

            // Wydrukuj, ile razy generacja została zmieciona.
            Console.WriteLine("\nGen 0 została zmieniona {0} razy", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 została zmieniona {0} razy", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 została zmieniona {0} razy", GC.CollectionCount(2));
        }

        static void Test1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                people.Add(new Person() { Id = i, Name = i.ToString(), Email = i.ToString() });

                if (i % 100000 == 0)
                {
                    Console.WriteLine(GetTotalCollections());
                }
            }
        }

        static int GetTotalCollections()
        {
            return GC.CollectionCount(0) + GC.CollectionCount(1) + GC.CollectionCount(2);
        }

        static List<Person> people = new List<Person>();
    }
}
