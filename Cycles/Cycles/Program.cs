using System.Diagnostics.Metrics;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Task #1: The first 10 Fibonacci numbers.");
            int a = 0;
            int b = 1;
            Console.WriteLine(a);
            Console.WriteLine(b);
            for (int i = 2; i < 10; i++)
            {
                int next = a + b;
                Console.WriteLine(next);
                a = b;
                b = next;
            }
            Console.WriteLine("Task #1: End.");
            Console.WriteLine();

            Console.WriteLine("Task #2: Even numbers from 2 to 20.");
            for (int i = 2; i <= 20; i += 2)
            {
                Console.WriteLine(i + "");
            }
            Console.WriteLine("Task #2: End.");
            Console.WriteLine();

            Console.WriteLine("Task #3: Multiplication table from 1 to 5.");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.WriteLine((i * j).ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
            Console.WriteLine("Task #3: End.");
            Console.WriteLine();

            Console.WriteLine("Task #4.");
            string password = "qwerty";
            string userInput;

            do
            {
                Console.Write("Enter password: ");
                userInput = Console.ReadLine();
            }
            while (userInput != password);
            Console.WriteLine("Correct password.");
            Console.WriteLine("Task #4: End.");
        }
    }
}