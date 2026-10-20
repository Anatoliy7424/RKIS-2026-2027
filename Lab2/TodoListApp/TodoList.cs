using System;

namespace TodoListApp
{
    // Пункт 3: Класс-хранилище для управления списком задач
    public class TodoList
    {
        private const int INITIAL_CAPACITY = 2;
        private const int CAPACITY_MULTIPLIER = 2;

        // Приватное поле: внутренний массив объектов TodoItem (Пункт 3, дефис 1)
        private TodoItem[] _items;
        private int _todoCount;

        public TodoList()
        {
            _items = new TodoItem[INITIAL_CAPACITY];
            _todoCount = 0;
        }
