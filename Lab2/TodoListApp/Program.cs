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
