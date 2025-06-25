using System.Runtime.CompilerServices;
using System.Xml.Linq;

using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> _list = new List<string>() { "Apple", "Banana", "Cherry" };

            public void TaskLoop()
            {
                Console.WriteLine("Введите '–exit' для выхода.");

                while (true)
                {
                    Console.WriteLine("Список: ");
                    _list.ForEach(Console.WriteLine);

                    Console.Write("Введите строку для добавления (или –exit): ");
                    string input = Console.ReadLine();
                    if (input == "–exit") return;

                    _list.Add(input);
                    Console.WriteLine("Добавлено. Список обновлен:");
                    _list.ForEach(Console.WriteLine);

                    Console.Write("Введите строку для вставки в середину (или –exit): ");
                    input = Console.ReadLine();
                    if (input == "–exit") return;

                    int middleIndex = _list.Count / 2;
                    _list.Insert(middleIndex, input);
                    Console.WriteLine("Добавлено в середину. Список обновлен:");
                    _list.ForEach(Console.WriteLine);
                }
            }
        }

        private class DictionaryTask
        {
            private readonly Dictionary<string, int> _students = new Dictionary<string, int>();

            public void TaskLoop()
            {
                Console.WriteLine("Введите '–exit' для выхода.");

                while (true)
                {
                    Console.Write("Введите имя студента (или –exit): ");
                    string name = Console.ReadLine();
                    if (name == "–exit") return;

                    Console.Write("Введите оценку от 2 до 5: ");
                    if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 2 || grade > 5)
                    {
                        Console.WriteLine("Некорректная оценка!");
                        continue;
                    }

                    _students[name] = grade;
                    Console.WriteLine("Добавлено.");

                    Console.Write("Введите имя студента для получения оценки (или –exit): ");
                    string query = Console.ReadLine();
                    if (query == "–exit") return;

                    if (_students.TryGetValue(query, out int result))
                    {
                        Console.WriteLine($"Оценка студента {query}: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Студент не найден.");
                    }
                }
            }
        }

        private class DoubleLinkedListTask
        {
            private class Node
            {
                public string Data;
                public Node Prev;
                public Node Next;

                public Node(string data)
                {
                    Data = data;
                }
            }

            private Node head;
            private Node tail;

            public void TaskLoop()
            {
                Console.WriteLine("Введите от 3 до 6 элементов (ввод по одному, '–exit' для выхода):");

                int count = 0;
                while (count < 6)
                {
                    Console.Write($"Элемент {count + 1}: ");
                    string input = Console.ReadLine();
                    if (input == "–exit") return;

                    AddToEnd(input);
                    count++;

                    if (count >= 3)
                    {
                        Console.Write("Хотите завершить ввод? (да/нет): ");
                        if (Console.ReadLine()?.Trim().ToLower() == "да")
                            break;
                    }
                }

                Console.WriteLine("Прямой порядок:");
                PrintForward();

                Console.WriteLine("Обратный порядок:");
                PrintBackward();
            }

            private void AddToEnd(string data)
            {
                Node node = new Node(data);
                if (head == null)
                {
                    head = tail = node;
                }
                else
                {
                    tail.Next = node;
                    node.Prev = tail;
                    tail = node;
                }
            }

            private void PrintForward()
            {
                Node current = head;
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }

            private void PrintBackward()
            {
                Node current = tail;
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Prev;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания (1, 2 или 3):");
            if (!int.TryParse(Console.ReadLine(), out int task))
            {
                Console.WriteLine("Ошибка ввода.");
                return;
            }

            switch (task)
            {
                case 1:
                    CheckTaskFirst();
                    break;
                case 2:
                    CheckTaskSecond();
                    break;
                case 3:
                    CheckTaskThird();
                    break;
                default:
                    Console.WriteLine("Нет такого задания.");
                    break;
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var dictTask = new DictionaryTask();
            dictTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var linkedListTask = new DoubleLinkedListTask();
            linkedListTask.TaskLoop();
        }
    }
}
