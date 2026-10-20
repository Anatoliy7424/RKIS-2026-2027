using System;
using System.IO;

namespace TodoListApp
{
    // Пункт 2: Статический класс для работы с файловой системой
    public static class FileManager
    {
        // Проверяет и создает папку при необходимости (Пункт 2, дефис 1)
        public static void EnsureDataDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
    // Сохранение профиля в текстовый файл (Пункт 2, дефис 2)
        public static void SaveProfile(Profile profile, string filePath)
        {
            string content = $"{profile.FirstName};{profile.LastName};{profile.BirthYear}";
            File.WriteAllText(filePath, content);
        }

        // Загрузка профиля из файла (Пункт 2, дефис 3)
        public static Profile LoadProfile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new Profile("Анатолий", "Васильев", 2004);
            }

            string[] parts = File.ReadAllText(filePath).Split(';');
            if (parts.Length == 3 && int.TryParse(parts[2], out int year))
            {
                return new Profile(parts[0], parts[1], year);
            }
            return new Profile("Анатолий", "Васильев", 2004);
        }
    }
}