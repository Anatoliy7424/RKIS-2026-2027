using System;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Шаг 7: Информация об авторе
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
