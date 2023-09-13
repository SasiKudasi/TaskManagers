using System;
using System.Collections.Generic;


namespace TaskManager
{
    public class TasksManager
    {
        private static int _key;

        static Task task = new Task();

        private static string[] _taskData;

        static Dictionary<int, string[]> taskDictionary = new Dictionary<int, string[]>();

                       
        internal static void AddTask()
        {
            _key = AddKey();
            AddTaskName();            
            GetTaskStatus();
            TaskReady();

            taskDictionary[_key] = new string[] { task.TaskName, task.Priority, task.Status };
                        
            if(taskDictionary.ContainsKey(_key))
            {
                 _taskData = taskDictionary[_key];
                Console.WriteLine($"TaskName: {_taskData[0]}, Priority: {_taskData[1]}, Status: {_taskData[2]}");                                
            }
        }

        private static int AddKey()
        {
            Console.WriteLine("Введите новмер задачи");
            int key = int.Parse(Console.ReadLine());
            return key;
        }

        public static void AddTaskName()
        {
            Console.WriteLine("Введите задачу:");
            task.TaskName = Console.ReadLine();
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
              return  task.Priority = "Низкий";
            }
            if (ChousePrioruty(key) == Priority.HIGHT)
            {
              return  task.Priority = "Высокий";
            }
            if (ChousePrioruty(key) == Priority.MEDIUM)
            {
              return  task.Priority = "Средний";
            }
            return task.Priority;
        }

        public static string TaskReady ()
        {
            Console.WriteLine("Выполнить задачу?");
            Console.WriteLine("1. Задача выполнена");
            Console.WriteLine("2. Задача не выполнена");

            var key = Console.ReadKey();
            if (CheckStatus(key) == Status.IS_DONE)
            {
                task.Status = "Выполнено";
                return task.Status;
            } 
            if(CheckStatus(key) == Status.ISNT_DONE)
            {
                task.Status = "Не выполнено";
                return task.Status;
            }
            return task.Status;
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


        internal static void BrowseAllTask()
        {
            foreach (var kvp in taskDictionary)
            {
                int key = kvp.Key;

                string[] taskData = taskDictionary[key];
                Console.WriteLine($"Key: {key}, TaskName: {taskData[0]}, Priority: {taskData[1]}, Status: {taskData[2]}");
            }
        }

        internal static void DeliteAllTasks()
        {
            taskDictionary.Clear();
        }

        internal static void DeliteTask()
        {
            Console.WriteLine("Выберите задачу, которую хотите удалить:");
            BrowseAllTask();
            int key  = int.Parse(Console.ReadLine());
            taskDictionary.Remove(key);
            BrowseAllTask();
        }

        internal static void EditTask()
        {
            Console.WriteLine("Выберите задачу");

            BrowseAllTask();

            int key = int.Parse(Console.ReadLine());

            _taskData = taskDictionary[key];
            
            Console.WriteLine("Что вы хотите изменить?");
            Console.WriteLine("1. Задача");
            Console.WriteLine("2. Приоритет");
            Console.WriteLine("3. Статус");
            
            var key1 = int.Parse(Console.ReadLine());
            if(key1 == 1)
            {
                Console.WriteLine("Введите задачу");
                _taskData[0] = Console.ReadLine();
            }
            if (key1 == 2)
            {
                Console.WriteLine("Укажите приоритет");
                _taskData[1] =  GetTaskStatus();
            }
            if(key1 == 3)
            {
                Console.WriteLine("Укажите готовность");
                _taskData[2] = TaskReady();
            }
            Console.WriteLine($"TaskName: {_taskData[0]}, Priority: {_taskData[1]}, Status: {_taskData[2]}");
        }
    }
}
