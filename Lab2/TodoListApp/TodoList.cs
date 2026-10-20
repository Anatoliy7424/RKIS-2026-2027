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
// Методы класса (Пункт 3, дефис 2)
        public void Add(TodoItem item)
        {
            IncreaseArrayIfNeeded(); // Автоматическое расширение при переполнении
            _items[_todoCount] = item;
            _todoCount++;
        }

        public void Delete(int index)
        {
            if (index >= 0 && index < _todoCount)
            {
                // Сдвиг объектов встроенного массива влево
                for (int i = index; i < _todoCount - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _todoCount--;
                Console.WriteLine($"Задача [{index}] успешно удалена.\n");
            }
            else
            {
                Console.WriteLine("Ошибка: некорректный индекс задачи.\n");
            }
        }
