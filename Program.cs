using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Просмотр задач");
            Console.WriteLine("3. Удалить задачу");
            Console.WriteLine("4. Удалить все задачи");
            Console.WriteLine("5. Изменить задачу");

            while (true)
            {
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
                    TasksManager.DeliteTask();
                    break;
                case ConsoleKey.D4:
                    TasksManager.DeliteAllTasks();
                    break;
                case ConsoleKey.D5:
                    TasksManager.EditTask();
                    break;


            }

        }

    }
}
