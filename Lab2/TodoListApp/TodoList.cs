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
                public void View(bool showIndex, bool showStatus, bool showDate, string rawInput)
        {
            if (_todoCount == 0)
            {
                Console.WriteLine("(список задач пуст)\n");
                return;
            }

            for (int i = 0; i < _todoCount; i++)
            {
                string info = _items[i].GetShortInfo();
                string row = _items[i].Text;

                // Обрезка текста до 30 символов для таблицы
                string textClean = row.Replace(Environment.NewLine, " ");
                if (textClean.Length > 30)
                {
                    textClean = textClean.Substring(0, 30) + "...";
                }

                row = textClean;

                // Форматируем вывод в зависимости от флагов
                if (showIndex) row = $"[{i}] " + row;
                if (showStatus) row += " | " + (_items[i].IsDone ? "сделано" : "не сделано");
                if (showDate) row += $" | {_items[i].LastUpdate:dd.MM.yyyy HH:mm:ss}";

                Console.WriteLine(row);
            }
            Console.WriteLine("--------------------------\n");
        }

        public TodoItem? GetItem(int index)
        {
            if (index >= 0 && index < _todoCount)
            {
                return _items[index];
            }
            return null;
        }

        // Приватный метод синхронного увеличения массива (Пункт 3, дефис 2, подточка 5)
        private void IncreaseArrayIfNeeded()
        {
            if (_todoCount < _items.Length) return;

            int newCapacity = _items.Length * CAPACITY_MULTIPLIER;
            TodoItem[] newItems = new TodoItem[newCapacity];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }
    }
}
