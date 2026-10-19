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
                private static bool[] _statuses = new bool[INITIAL_CAPACITY];
        private static DateTime[] _dates = new DateTime[INITIAL_CAPACITY];


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
        private static void EnsureCapacity()
        {
            if (_todoCount < _todos.Length) return;
            int newCapacity = _todos.Length * CAPACITY_MULTIPLIER;
            
            string[] newTodos = new string[newCapacity];
            bool[] newStatuses = new bool[newCapacity];
            DateTime[] newDates = new DateTime[newCapacity];

            for (int i = 0; i < _todos.Length; i++)
            {
                newTodos[i] = _todos[i];
                newStatuses[i] = _statuses[i];
                newDates[i] = _dates[i];
            }

            _todos = newTodos;
            _statuses = newStatuses;
            _dates = newDates;
        }
    }
}