using System;
using TaskManager;

public class Result
{
    private static Tasks _task = new Tasks();


    public static string AddTaskName(string prop)
    {
        Console.WriteLine("Введите задачу:");
        prop = Console.ReadLine();
        return prop;
    }

    public static string GetTaskStatus()
        {
            Console.WriteLine("Выберите приоритет задачи:");
            Console.WriteLine("1. Высокий");
            Console.WriteLine("2. Средний");
            Console.WriteLine("3. Низкий");

            var key = Console.ReadKey();

            if (ChousePrioruty(key) == Priority.LOW)
            {
                return _task.Priority = "Низкий";
            }
            if (ChousePrioruty(key) == Priority.HIGHT)
            {
                return _task.Priority = "Высокий";
            }
            if (ChousePrioruty(key) == Priority.MEDIUM)
            {
                return _task.Priority = "Средний";
            }
            return _task.Priority;
        }

        public static string TaskReady()
        {
            Console.WriteLine("Выполнить задачу?");
            Console.WriteLine("1. Задача выполнена");
            Console.WriteLine("2. Задача не выполнена");

            var key = Console.ReadKey();
            if (CheckStatus(key) == Status.IS_DONE)
            {
                _task.Status = "Выполнено";
                return _task.Status;
            }
            if (CheckStatus(key) == Status.ISNT_DONE)
            {
                _task.Status = "Не выполнено";
                return _task.Status;
            }
            return _task.Status;
        }

        private static Status CheckStatus(ConsoleKeyInfo key)
        {
            Status result = Status.ISNT_DONE;
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    result = Status.IS_DONE;
                    break;
                case ConsoleKey.D2:
                    result = Status.ISNT_DONE;
                    break;
            }
            return result;
        }

        public static Priority ChousePrioruty(ConsoleKeyInfo key)
        {
            Priority result = Priority.MEDIUM;
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    result = Priority.HIGHT;
                    break;
                case ConsoleKey.D2:
                    result = Priority.MEDIUM;
                    break;
                case ConsoleKey.D3:
                    result = Priority.LOW;
                    break;
            }
            return result;
        }

}

