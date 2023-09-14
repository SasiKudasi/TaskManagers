
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;

namespace TaskManager
{
    internal class Program
    {
        public static Task task = new Task();

        static void Main(string[] args)
        {          
            while (true)
            {

                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Просмотр задач");
                Console.WriteLine("3. Просмотр определенных задач");
                Console.WriteLine("4. Удалить задачу");
                Console.WriteLine("5. Удалить все задачи");
                Console.WriteLine("6. Изменить задачу");

                var key = Console.ReadKey();
                Interaction(key);
                Console.ReadLine();
            }
        }

        public static void Interaction(ConsoleKeyInfo key)
        {

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    TasksManager.AddTask();
                    break;
                case ConsoleKey.D2:
                    TasksManager.BrowseAllTask();
                    break;
                case ConsoleKey.D3:
                    TasksManager.SpecificTasks();
                    break;
                case ConsoleKey.D4:
                    TasksManager.DeliteTask();
                    break;
                case ConsoleKey.D5:
                    TasksManager.DeliteAllTasks();
                    break;
                case ConsoleKey.D6:
                    TasksManager.EditTask();
                    break;
            }

        }

    }
}
