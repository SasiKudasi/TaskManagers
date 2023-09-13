﻿using System;
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
        
        public static void GetTaskStatus()
        {
            Console.WriteLine("Выберите приоритет задачи:");
            Console.WriteLine("1. Высокий");
            Console.WriteLine("2. Средний");
            Console.WriteLine("3. Низкий");

            var key = Console.ReadKey();

            if (ChousePrioruty(key) == Priority.LOW)
            {
                task.Priority = "Низкий";
            }
            if (ChousePrioruty(key) == Priority.HIGHT)
            {
                task.Priority = "Высокий";
            }
            if (ChousePrioruty(key) == Priority.MEDIUM)
            {
                task.Priority = "Средний";
            }
        }

        public static  string TaskReady ()
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
            Console.WriteLine("");

            foreach (var kvp in taskDictionary)
            {
                int key = kvp.Key;

                string[] taskData = taskDictionary[key];
                Console.WriteLine($"Key: {key}, TaskName: {taskData[0]}, Priority: {taskData[1]}, Status: {taskData[2]}");
            }

        }

        internal static void DeliteAllTasks()
        {
            throw new NotImplementedException();
        }

        internal static void DeliteTask()
        {
            throw new NotImplementedException();
        }

        internal static void EditTask()
        {
            Console.WriteLine("Выберите задачу");

            BrowseAllTask();

            int key = int.Parse(Console.ReadLine());

            _taskData = taskDictionary[key];
            Console.WriteLine($"TaskName: {_taskData[0]}, Priority: {_taskData[1]}, Status: {_taskData[2]}");

            Console.WriteLine("");
        }
    }
}