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
                        
            Console.WriteLine("========================================");
            Console.WriteLine("Работу выполнил студент: [Васильев]");
            Console.WriteLine("========================================\n");

            // Шаг 8: Сбор данных
            Console.Write("Введите ваше имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите ваш год рождения: ");
            string yearInput = Console.ReadLine();

            // Расчет возраста (текущий год — 2026)
            int birthYear = Convert.ToInt32(yearInput);
            int currentYear = 2026; 
            int age = currentYear - birthYear;

            // Вывод по шаблону задания
            Console.WriteLine($"\nДобавлен пользователь {firstName} {lastName}, возраст - {age}");
        }
    }
}