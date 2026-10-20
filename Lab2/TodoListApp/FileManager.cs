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
    }
}