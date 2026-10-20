using System;

namespace TodoListApp
{
    // Пункт 3: Класс новой команды для изменения статуса задачи
    public class StatusCommand : ICommand
    {
        private readonly TodoList _todoList;
        private readonly string _input;

        public StatusCommand(TodoList todoList, string input)
        {
            _todoList = todoList;
            _input = input;
        }

        public void Execute()
        {
            // Сюда мы точечно добавим логику разбора строки в следующем шаге
             // Убираем имя команды "status " из строки (строка 7 символов)
            string args = _input.Substring(7).Trim();
            string[] parts = args.Split(' ');

            if (parts.Length == 2 && int.TryParse(parts[0], out int index))
            {
                // Преобразуем строковое имя в объект enum TodoStatus (Пункт 3, совет из методички)
                if (Enum.TryParse(parts[1], true, out TodoStatus newStatus))
                {
                    TodoItem? item = _todoList[index]; // Наш новый индексатор в деле!
                    if (item != null)
                    {
                        item.SetStatus(newStatus);
                        Console.WriteLine($"Статус задачи [{index}] успешно изменен на: {newStatus}\n");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: задача с таким индексом не найдена.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: указан неизвестный статус. Допустимые: NotStarted, InProgress, Completed, Postponed, Failed.\n");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: используйте формат 'status <индекс> <статус>'.\n");
            }
        }
    }
}