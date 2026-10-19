using System;

namespace TodoListApp
{
    class Program
    {
        // Константы для размера массива (Пункт 2, дефис 3)
        private const int INITIAL_CAPACITY = 2;
        private const int CAPACITY_MULTIPLIER = 2;

        // Понятные имена в едином стиле (Пункт 2, дефис 1)
        private static string[] _todos = new string[INITIAL_CAPACITY];
        private static int _todoCount = 0;

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Приложение TodoList ---");
            Console.WriteLine("Введите 'help' для просмотра команд.\n");

            while (true)
            {
                Console.Write("Введите команду: ");
                string? input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input)) continue;

                string lowerInput = input.ToLower();

                if (lowerInput == "help")
                {
                    ShowHelp();
                }
                else if (lowerInput == "exit")
                {
                    Console.WriteLine("До свидания!");
                    break;
                }
                else
                {
                    Console.WriteLine("Неизвестная команда. Введите 'help'.\n");
                }
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("\nДоступные команды: help, exit\n");
        }
    }
}