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
                else if (lowerInput.StartsWith("view"))
                {
                    ExecuteViewCommand(input);
                }
                else if (input.StartsWith("done ", StringComparison.OrdinalIgnoreCase))
                {
                    ExecuteDoneCommand(input);
                }
                else if (input.StartsWith("delete ", StringComparison.OrdinalIgnoreCase))
                {
                    ExecuteDeleteCommand(input);
                }
                else if (input.StartsWith("update ", StringComparison.OrdinalIgnoreCase))
                {
                    ExecuteUpdateCommand(input);
                }
                else if (input.StartsWith("read ", StringComparison.OrdinalIgnoreCase))
                {
                    ExecuteReadCommand(input);
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
                // Метод view принимает строку с флагами и выводит таблицу
        private static void ExecuteViewCommand(string input)
        {
            Console.WriteLine("\n--- Список ваших задач ---");
            if (_todoCount == 0)
            {
                Console.WriteLine("(список задач пуст)\n");
                return;
            }

            // Парсинг флагов отображения (Пункт 4)
            bool showIndex = input.Contains("--index") || input.Contains(" -i") || input.Contains("--all") || input.Contains(" -a");
            bool showStatus = input.Contains("--status") || input.Contains(" -s") || input.Contains("--all") || input.Contains(" -a");
            bool showDate = input.Contains("--update-date") || input.Contains(" -d") || input.Contains("--all") || input.Contains(" -a");

            for (int i = 0; i < _todoCount; i++)
            {
                // Обрезка текста до 30 символов для таблицы (Пункт 4)
                string text = _todos[i]?.Replace(Environment.NewLine, " ") ?? "";
                if (text.Length > 30)
                {
                    text = text.Substring(0, 30) + "...";
                }

                string row = text;

                // Сборка строки по флагам
                if (showIndex) row = $"[{i}] " + row;
                if (showStatus) row += " | " + (_statuses[i] ? "сделано" : "не сделано");
                if (showDate) row += $" | {_dates[i]:dd.MM.yyyy HH:mm:ss}";

                Console.WriteLine(row);
            }
            Console.WriteLine("--------------------------\n");
        }
        private static void ShowHelp()
        {

            // Обновили справку, чтобы новые команды отображались в меню
            Console.WriteLine("\nДоступные команды:");
            Console.WriteLine("  help                     - показать эту справку");
            Console.WriteLine("  profile                  - показать профиль пользователя");
            Console.WriteLine("  add <текст> [--multiline] - добавить задачу (опционально многострочно)");
            Console.WriteLine("  view [-i] [-s] [-d] [-a]  - показать задачи таблицей с флагами фильтрации");
            Console.WriteLine("  read <индекс>            - открыть полный текст конкретной задачи");
            Console.WriteLine("  done <индекс>            - отметить задачу как выполненную");
            Console.WriteLine("  delete <индекс>          - удалить задачу");
            Console.WriteLine("  update <индекс> <текст>  - обновить текст задачи");
            Console.WriteLine("  exit                     - выйти из программы\n");
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

                // --- Добавлен многострочный режим ввода для команды add с флагами ---
                private static void ExecuteAddCommand(string input)
        {
            // Проверяем флаги многострочного ввода (Пункт 3)
            bool isMultiline = input.Contains("--multiline") || input.Contains(" -m");
            string taskText = "";

            if (isMultiline)
            {
                Console.WriteLine("Введите строки задачи (для окончания введите !end):");
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while (true)
                {
                    Console.Write("> ");
                    string? line = Console.ReadLine();
                    if (line == "!end") break;
                    if (line != null) sb.AppendLine(line);
                }
                taskText = sb.ToString().TrimEnd();
            }
            else
            {
                // Обычный однострочный режим
                string[] parts = input.Split(new[] { ' ' }, 2);
                if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
                {
                    Console.WriteLine("Ошибка: введите текст задачи после 'add'.\n");
                    return;
                }
                taskText = parts[1];
            }

            if (string.IsNullOrWhiteSpace(taskText))
            {
                Console.WriteLine("Ошибка: текст задачи не может быть пустым.\n");
                return;
            }

            EnsureCapacity();

            _todos[_todoCount] = taskText;
            _statuses[_todoCount] = false;
            _dates[_todoCount] = DateTime.Now;
            _todoCount++;
            Console.WriteLine("Задача успешно добавлена!\n");
        }
        
        // --- В КЛАСС ДОБАВИЛИ НОВЫЕ МЕТОДЫ ---
        private static void ExecuteDoneCommand(string input)
        {
            if (int.TryParse(input.Substring(5).Trim(), out int index) && index >= 0 && index < _todoCount)
            {
                _statuses[index] = true;
                _dates[index] = DateTime.Now;
                Console.WriteLine($"Задача [{index}] выполнена.\n");
            }
            else
            {
                Console.WriteLine("Ошибка: некорректный индекс задачи.\n");
            }
        }

        private static void ExecuteDeleteCommand(string input)
        {
            if (int.TryParse(input.Substring(7).Trim(), out int index) && index >= 0 && index < _todoCount)
            {
                // Сдвиг элементов влево
                for (int i = index; i < _todoCount - 1; i++)
                {
                    _todos[i] = _todos[i + 1];
                    _statuses[i] = _statuses[i + 1];
                    _dates[i] = _dates[i + 1];
                }
                _todoCount--;
                Console.WriteLine($"Задача [{index}] удалена.\n");
            }
            else
            {
                Console.WriteLine("Ошибка: некорректный индекс задачи.\n");
            }
        }

        private static void ExecuteUpdateCommand(string input)
        {
            string args = input.Substring(7).Trim();
            string[] parts = args.Split(new[] { ' ' }, 2);
            if (parts.Length == 2 && int.TryParse(parts[0], out int index) && index >= 0 && index < _todoCount)
            {
                _todos[index] = parts[1].Trim('\"');
                _dates[index] = DateTime.Now;
                Console.WriteLine($"Задача [{index}] обновлена.\n");
            }
            else
            {
                Console.WriteLine("Ошибка: используйте формат 'update <индекс> <текст>'.\n");
            }
        }
            // Пункт 5: Метод для просмотра полного текста задачи (без обрезки)
        private static void ExecuteReadCommand(string input)
        {
            if (int.TryParse(input.Substring(5).Trim(), out int index) && index >= 0 && index < _todoCount)
            {
                string status = _statuses[index] ? "выполнена" : "не выполнена";
                Console.WriteLine($"\nПолный текст задачи:\n{_todos[index]}");
                Console.WriteLine($"Статус: {status}");
                Console.WriteLine($"Дата последнего изменения: {_dates[index]:dd.MM.yyyy HH:mm:ss}\n");
            }
            else
            {
                Console.WriteLine("Ошибка: некорректный индекс задачи.\n");
            }
        }
    }
}