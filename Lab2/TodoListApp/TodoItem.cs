using System;

namespace TodoListApp
{
    // Пункт 2: Класс, описывающий одну задачу
    public class TodoItem
    {
        // Свойства задачи (Пункт 2, дефис 1)
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public DateTime LastUpdate { get; set; }

        // Конструктор (Пункт 2, дефис 2)
        public TodoItem(string text)
        {
            Text = text;
            IsDone = false;
            LastUpdate = DateTime.Now;
        }
