using System;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
             // Фикс кодировки, чтобы русские буквы не превращались в закорючки
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Данные профиля (для команды profile)
                        string firstName = "Анатолий";
                        string lastName = "Васильев";
                        int birthYear = 2004;

                  // Пункт 2 и 5: Массив строк с небольшой начальной длиной (2 элемента)
            string[] todos = new string[2];
            int todoCount = 0;     
            Console.WriteLine("--- Приложение TodoList запущенно ---");
            Console.WriteLine("Введите 'help' для просмотра списка команд.\n");

             // Пункт 3: Бесконечный цикл для проверки команд
            while (true)
            {
                Console.Write("Введите команду: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input)) continue;

                // Пункт 4: Реализация команд
                if (input.ToLower() == "help")
                {
                    Console.WriteLine("\nДоступные команды:");
                    Console.WriteLine("  help    - вывести список всех команд");
                    Console.WriteLine("  profile - вывести данные пользователя");
                    Console.WriteLine("  add     - добавить новую задачу (Формат: add текст задачи)");
                    Console.WriteLine("  view    - вывести все задачи");
                    Console.WriteLine("  exit    - завершить работу программы\n");
                }
                else if (input.ToLower() == "profile")
                {
                    Console.WriteLine($"\nПрофиль: {firstName} {lastName}, <{birthYear}>\n");
                }
                else if (input.StartsWith("add ", StringComparison.OrdinalIgnoreCase))
                {

                     // Извлекаем текст задачи с помощью Split
                    string[] parts = input.Split(new[] { ' ' }, 2);
                    if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
                    {
                        Console.WriteLine("Ошибка: после команды 'add' нужно ввести текст задачи.\n");
                        continue;
                    }

                    string newTask = parts[1];

                     // Пункт 5: Проверка, хватит ли места в массиве
                    if (todoCount >= todos.Length)
                    {
                        Console.WriteLine($"[Система]: Места нет! Расширяю массив с {todos.Length} до {todos.Length * 2} элементов.");
                        
                        // Создаем новый массив в 2 раза длиннее текущего
                        string[] newTodos = new string[todos.Length * 2];

                         // Через цикл перезаписываем содержимое
                        for (int i = 0; i < todos.Length; i++)
                        {
                            newTodos[i] = todos[i];
                        }
                        
                        // Записываем в переменную todos новый массив
                        todos = newTodos;
                    }

                    // Добавляем задачу в массив
                    todos[todoCount] = newTask;
                    todoCount++;
                    Console.WriteLine("Задача успешно добавлена!\n");
                }
                else if (input.ToLower() == "view")
                {
                    Console.WriteLine("\n--- Список ваших задач ---");
                    int printed = 0;