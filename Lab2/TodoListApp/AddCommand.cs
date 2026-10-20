using System;

namespace TodoListApp
{
    // Пункт 3: Класс конкретной команды для добавления задачи
    public class AddCommand : ICommand
    {
       // Оформляем свойства и зависимости по требованиям методички (Пункт 3)
        private readonly TodoList _todoList;
        private readonly string _input;

        public AddCommand(TodoList todoList, string input)
        {
            _todoList = todoList;
            _input = input;
        }

        public void Execute()
        {
            bool isMultiline = _input.Contains("--multiline") || _input.Contains(" -m");
            string taskText = "";

            if (isMultiline)
            {
                Console.WriteLine("Введите строки задачи (для окончания введите !end):");
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while (true)
                {
                    Console.Write("> ");
                    string? line = Console.ReadLine();
                    if (line == "!end") break;
                    if (line != null) sb.AppendLine(line);
                }
                taskText = sb.ToString().TrimEnd();
            }
            else
            {
                string[] parts = _input.Split(new[] { ' ' }, 2);
                if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts))
                {
                    Console.WriteLine("Ошибка: введите текст задачи после 'add'.\n");
                    return;
                }
                taskText = parts[1];
            }
