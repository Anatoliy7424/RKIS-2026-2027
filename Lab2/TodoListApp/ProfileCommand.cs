using System;

namespace TodoListApp
{
    // Пункт 3: Класс конкретной команды для вывода профиля
    public class ProfileCommand : ICommand
    {
        private readonly Profile _profile;

        public ProfileCommand(Profile profile)
        {
            _profile = profile;
        }

        public void Execute()
        {
            Console.WriteLine($"\nПрофиль: {_profile.GetInfo()}\n");
        }
    }
}
