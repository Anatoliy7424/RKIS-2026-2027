using System;

namespace TodoListApp
{
    // Пункт 4: Статический класс для разбора строк ввода
    public static class CommandParser
    {
        // Метод принимает строку, список задач и профиль (Пункт 4, дефис 1)
        public static ICommand Parse(string inputString, TodoList todoList, Profile profile)
        {
            string lowerInput = inputString.ToLower();

            // Проверяем, какая команда была введена (Пункт 4, дефис 2)
            if (lowerInput == "profile")
            {
                return new ProfileCommand(profile);
            }
            if (inputString.StartsWith("add ", StringComparison.OrdinalIgnoreCase))
            {
                return new AddCommand(todoList, inputString);
            }
            // Если команда неизвестна программе, возвращаем специальную заглушку
            return new UnknownCommand(inputString);
        }
    }
     // Вспомогательный класс для обработки неизвестных команд в паттерне
    public class UnknownCommand : ICommand
    {
        private readonly string _input;
        public UnknownCommand(string input) { _input = input; }

        public void Execute() 
        {
            if (_input.ToLower() != "help" && _input.ToLower() != "exit")
            {
                Console.WriteLine("Неизвестная команда. Введите 'help'.\n");
            }
        }
    }
}