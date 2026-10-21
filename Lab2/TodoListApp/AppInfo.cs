using System;
using System.Collections.Generic;

namespace TodoListApp
{
    // Пункт 1: Статический класс глобального состояния приложения
    public static class AppInfo
    {
        public static TodoList Todos { get; set; } = new TodoList();
        public static Profile CurrentProfile { get; set; } = new Profile("Анатолий", "Васильев", 2004);
        public static Stack<ICommand> UndoStack { get; } = new Stack<ICommand>();
        public static Stack<ICommand> RedoStack { get; } = new Stack<ICommand>();

    }
}
