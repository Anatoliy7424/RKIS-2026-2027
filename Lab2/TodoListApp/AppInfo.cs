using System;
using System.Collections.Generic;

namespace TodoListApp
{
    // Пункт 1: Статический класс глобального состояния приложения
    public static class AppInfo
    {
        public static TodoList Todos { get; set; } = new TodoList();
        public static Profile CurrentProfile { get; set; } = new Profile("Анатолий", "Васильев", 2004);
    }
}