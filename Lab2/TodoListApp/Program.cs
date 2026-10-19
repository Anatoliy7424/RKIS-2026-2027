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

          // --- ДОБАВИЛИ ДВА МАССИВА ---
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
                // --- УСЛОВИЯ СВЯЗИ ДЛЯ ADD И VIEW ---
                                else if (input.StartsWith("add ", StringComparison.OrdinalIgnoreCase))
                {
                    ExecuteAddCommand(input);
                }
                else if (lowerInput == "view")
                {
                    ExecuteViewCommand();
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

            // Обновили справку, чтобы новые команды отображались в меню
            Console.WriteLine("\nДоступные команды:");
            Console.WriteLine("  help               - показать справку");
            Console.WriteLine("  add <текст задачи> - добавить новую задачу");
            Console.WriteLine("  view               - показать все задачи");
            Console.WriteLine("  exit               - выйти из программы\n");
            Console.WriteLine("\nДоступные команды: help, exit\n");
        }
         // --- ДОБАВИЛИ МЕТОД ---
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

                // --- В САМЫЙ НИЗ КЛАССА ДОБАВИЛИ МЕТОДЫ ЛОГИКИ ---
        private static void ExecuteAddCommand(string input)
        {
            string[] parts = input.Split(new[] { ' ' }, 2);
            if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
            {
                Console.WriteLine("Ошибка: введите текст задачи после 'add'.\n");
                return;
            }

            EnsureCapacity();

            _todos[_todoCount] = parts[1];
            _statuses[_todoCount] = false; // Запись false в statuses
            _dates[_todoCount] = DateTime.Now; // Запись текущей даты в dates
            _todoCount++;
            Console.WriteLine("Задача успешно добавлена!\n");
        }

        private static void ExecuteViewCommand()
        {
            Console.WriteLine("\n--- Список ваших задач ---");
            if (_todoCount == 0)
            {
                Console.WriteLine("(список задач пуст)");
            }
            else
            {
                for (int i = 0; i < _todoCount; i++)
                {
                    string status = _statuses[i] ? "сделано" : "не сделано";
                    Console.WriteLine($"[{i}] {_todos[i]} - <{status}> - <{_dates[i]:dd.MM.yyyy HH:mm:ss}>");
                }
            }
            Console.WriteLine("--------------------------\n");
        }
    }
}