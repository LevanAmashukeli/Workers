using System;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"data.csv";

            Repository rep = new Repository(path);

            rep.PrintDbToConsole();
            Console.WriteLine(rep.Count);
            rep.Add(new Worker("New First Name", "New Last Name", "New Position", 7777, "New Department"));
            rep.Save("newdata.csv");

            Console.ReadKey();
        }
    }
}
