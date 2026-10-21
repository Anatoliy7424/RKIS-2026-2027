using System;

namespace TodoListApp
{
    // Пункт 4: Класс для хранения данных профиля автора проекта
    public class Profile
    {
        // Свойства (Пункт 4, дефис 1)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        // Пункт 2: Новые поля для многопользовательского режима
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Конструктор инициализирует базовые данные
        public Profile(string firstName, string lastName, int birthYear)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        // Метод GetInfo возвращает отформатированную строку (Пункт 4, дефис 2)
        public string GetInfo()
        {
            // Автоматический расчет возраста на основе текущего 2026 года
            int age = 2026 - BirthYear;
            return $"{FirstName} {LastName}, возраст {age}";
        }
    }
}
