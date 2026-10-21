namespace TodoListApp
{
    internal static class ProgramHelpers
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Приложение TodoList ---");
            Console.WriteLine("Введите 'help' для просмотра команд.\n");
            // --- Пункт 5: Проверка директории и загрузка данных при запуске ---
            FileManager.EnsureDataDirectory(Program._dataDir);

            // Пункт 3: Автоматическая загрузка списка всех профилей из profile.csv при старте
            AppInfo.AllProfiles = FileManager.LoadAllProfiles(Program._profilePath);
            while (true)
            {
                // Пункт 5: Запуск стартового меню входа/регистрации
                if (!Program.ShowAuthMenu())
                {
                    Console.WriteLine("Выход из приложения.");
                    return;
                }

                // Пункт 6: Формирование пути к персональному файлу задач на основе ID пользователя
                string personalTodoPath = System.IO.Path.Combine("data", $"todos_{AppInfo.CurrentProfileId}.csv");

                // Загружаем персональные задачи или создаем новые, если файла еще нет
                if (System.IO.File.Exists(personalTodoPath))
                {
                    AppInfo.Todos = FileManager.LoadTodos(personalTodoPath);
                }
                else
                {
                    AppInfo.Todos = new TodoList();
                    FileManager.SaveTodos(AppInfo.Todos, personalTodoPath);
                }
                while (AppInfo.CurrentProfileId != null)
                {
                    Console.Write("Введите команду: ");
                    string? input = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(input)) continue;

                    string lowerInput = input.ToLower();

                    if (lowerInput == "help")
                    {
                        Program.ShowHelp();
                    }
                    // --- Пункт 5: Единая точка обработки ООП-команд через паттерн Команда ---
                    else if (lowerInput == "profile" || input.StartsWith("add ", StringComparison.OrdinalIgnoreCase) || lowerInput.StartsWith("view") || input.StartsWith("status ", StringComparison.OrdinalIgnoreCase))
                    {
                        ICommand command = CommandParser.Parse(input, AppInfo.Todos, AppInfo.CurrentProfile);

                        // Если ввели команду отмены (Undo)
                        if (command is UndoCommand)
                        {
                            if (AppInfo.UndoStack.Count > 0)
                            {
                                ICommand undoCmd = AppInfo.UndoStack.Pop();
                                undoCmd.Unexecute();
                                AppInfo.RedoStack.Push(undoCmd); // Запоминаем для возможного Redo
                            }
                            else
                            {
                                Console.WriteLine("История действий пуста. Нечего отменять.\n");
                            }
                        }
                        // Если ввели команду повтора (Redo)
                        else if (command is RedoCommand)
                        {
                            if (AppInfo.RedoStack.Count > 0)
                            {
                                ICommand redoCmd = AppInfo.RedoStack.Pop();
                                redoCmd.Execute();
                                AppInfo.UndoStack.Push(redoCmd); // Возвращаем в стек отмены
                            }
                            else
                            {
                                Console.WriteLine("Нет отменённых действий для повтора.\n");
                            }
                        }
                        // Обычная команда (add, status, profile, view)
                        else
                        {
                            command.Execute();

                            // Если команда отменяемая (add или status) — сохраняем её в стек истории
                            if (command is AddCommand || command is StatusCommand)
                            {
                                AppInfo.UndoStack.Push(command);
                                AppInfo.RedoStack.Clear(); // Новое действие очищает стек повтора
                            }
                        }
                    }
                    else if (input.StartsWith("delete ", StringComparison.OrdinalIgnoreCase))
                    {
                        Program.ExecuteDeleteCommand(input);
                    }
                    else if (input.StartsWith("update ", StringComparison.OrdinalIgnoreCase))
                    {
                        Program.ExecuteUpdateCommand(input);
                    }
                    else if (input.StartsWith("read ", StringComparison.OrdinalIgnoreCase))
                    {
                        Program.ExecuteReadCommand(input);
                    }
                    else if (lowerInput == "exit")
                    {
                        Console.WriteLine("До свидания!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неизвестная команда. Введите 'help'.\n");
                    }
                }
            }
    }
}