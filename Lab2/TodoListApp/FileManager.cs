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
        // Пункт 3: Сохранение задач в CSV-формат (Пункт 2, дефис 4)
        public static void SaveTodos(TodoList todos, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                int index = 0;
                while (true)
                {
                    TodoItem? item = todos.GetItem(index);
                    if (item == null) break;

                    // Заменяем переносы строк на строку "\\n" (Пункт 3, совет)
                    string safeText = item.Text.Replace("\"", "\"\"").Replace(Environment.NewLine, "\\n").Replace("\n", "\\n");
                    sw.WriteLine($"{index};\"{safeText}\";{item.IsDone.ToString().ToLower()};{item.LastUpdate:yyyy-MM-ddTHH:mm:ss}");
                    index++;
                }
            }
        }
        // Загрузка задач из CSV-файла (Пункт 2, дефис 5)
        public static TodoList LoadTodos(string filePath)
        {
            TodoList list = new TodoList();
            if (!File.Exists(filePath)) return list;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split(';');
                if (parts.Length >= 4)
                {
                    string text = parts[1].Trim('"').Replace("\\n", Environment.NewLine);
                    bool isDone = parts[2].ToLower() == "true";
                    DateTime date = DateTime.TryParse(parts[3], out DateTime d) ? d : DateTime.Now;

                    TodoItem item = new TodoItem(text)
                    {
                        IsDone = isDone,
                        LastUpdate = date
                    };
                    list.Add(item);
                }
            }
            return list;
        }
    }
}