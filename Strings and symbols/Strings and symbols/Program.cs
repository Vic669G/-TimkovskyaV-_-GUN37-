using System;
using System.Text;
namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1: Concatenation of strings
            string ConcatenateStrings(string str1, string str2)
            {
                return str1 + str2;
            }
            Console.WriteLine("Задание 1:");
            Console.WriteLine(ConcatenateStrings("Hello", "World"));

            //Task 2: Greeting the user with a formatted string
            string GreetUser(string name, int age)
            {
                return $"Hello, {name}!\nYou are {age} years old.";
            }
            Console.WriteLine("\nЗадание 2:");
            Console.WriteLine(GreetUser("Vika", 20));

            //Task 3: Returning information about a row
            string GetStringInfo(string input)
            {
                return $"Length: {input.Length}\nUpper: {input.ToUpper()}\nLower: {input.ToLower()}";
            }
            Console.WriteLine("\nЗадание 3:");
            Console.WriteLine(GetStringInfo("Homework"));

            //Task 4: Get first 5 characters of string
            string GetFirstFiveChars(string input)
            {
                if (input.Length < 5)
                    return input;
                return input.Substring(0, 5);
            }
            Console.WriteLine("\nЗадание 4:");
            Console.WriteLine(GetFirstFiveChars("Example"));
            Console.WriteLine(GetFirstFiveChars("Hi"));

            //Task 5: Concatenate an array of strings into a sentence
            StringBuilder JoinStringsWithSpaces(string[] inputArray)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < inputArray.Length; i++)
                {
                    sb.Append(inputArray[i]);
                    if (i < inputArray.Length - 1)
                        sb.Append(" ");
                }
                return sb;
            }
            Console.WriteLine("\nЗадание 5:");
            string[] words = { "This", "is", "a", "test" };
            Console.WriteLine(JoinStringsWithSpaces(words).ToString());

            //Task 6: Replacing words in a string
            string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
            {
                return inputString.Replace(wordToReplace, replacementWord);
            }
            Console.WriteLine("\nЗадание 6:");
            string replaced = ReplaceWords("Hello world, brave new world!", "world", "universe");
            Console.WriteLine(replaced);
        }
    }
}