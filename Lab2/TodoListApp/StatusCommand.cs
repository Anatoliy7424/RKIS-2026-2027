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
        }
    }
}