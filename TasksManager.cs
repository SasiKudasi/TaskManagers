
namespace TaskManager
{
    public class TasksManager
    {
        private static int _key;

        private static Task _task = new Task();
     
        private static Dictionary<int, Task> _taskDictionary = new Dictionary<int, Task>();

                       
        internal static void AddTask()
        {
            _key = AddKey();
            AddTaskName();            
            GetTaskStatus();
            TaskReady();

            _taskDictionary.Add(_key, new Task( _task.TaskName, _task.Priority, _task.Status));
                        
            if(_taskDictionary.ContainsKey(_key))
            {                
                Console.WriteLine($"TaskName: {_task.TaskName}, Priority: {_task.Priority}, Status: {_task.Status}");                                
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
            _task.TaskName = Console.ReadLine();
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
              return  _task.Priority = "Низкий";
            }
            if (ChousePrioruty(key) == Priority.HIGHT)
            {
              return  _task.Priority = "Высокий";
            }
            if (ChousePrioruty(key) == Priority.MEDIUM)
            {
              return  _task.Priority = "Средний";
            }
            return _task.Priority;
        }

        public static string TaskReady ()
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
            if(CheckStatus(key) == Status.ISNT_DONE)
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

        public static void SortPriority (string text)
        {
            var hidePriority = _taskDictionary.Values.Where(task => task.Priority == text);

            foreach (var task in hidePriority)
            {
                Console.WriteLine($"TaskName: {task.TaskName}, Priority: {task.Priority}, Status: {task.Status}");
            }
        }


        public static void SortStatus(string text)
        {
            var hidePriority = _taskDictionary.Values.Where(task => task.Status == text);

            foreach (var task in hidePriority)
            {
                Console.WriteLine($"TaskName: {task.TaskName}, Priority: {task.Priority}, Status: {task.Status}");
            }
        }

        public static void SpecificTasks()
        {
            Console.WriteLine("Какие дела вы хотите получить?");
            Console.WriteLine("1. Вывести все данные");
            Console.WriteLine("2. Вывести все данные с высоким приоритетом");
            Console.WriteLine("3. Вывести все данные со средним приоритетом");
            Console.WriteLine("4. Вывести все данные с низким приоритетом");
            Console.WriteLine("5. Вывести все незавершенные дела");
            Console.WriteLine("6. Вывести все завершенные дела");


            int key = int.Parse(Console.ReadLine());

            if (key == 1)            
                BrowseAllTask();            
            if (key == 2)            
                SortPriority("Высокий");
            
            if (key == 3)            
                SortPriority("Средний");
            
            if (key == 4)
                SortPriority("Низкий");
            if (key == 5)
                SortStatus("Не выполнено");
            if (key == 6)
                SortStatus("Выполнено");         
        }
        internal static void BrowseAllTask()
        {
            

            foreach (var kvp in _taskDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key},name {kvp.Value.TaskName}, priority {kvp.Value.Priority}, status {kvp.Value.Status}");
            }
        }

        internal static void DeliteAllTasks()
        {
            _taskDictionary.Clear();
        }

        internal static void DeliteTask()
        {
            Console.WriteLine("Выберите задачу, которую хотите удалить:");
            BrowseAllTask();
            int key  = int.Parse(Console.ReadLine());
            _taskDictionary.Remove(key);
            BrowseAllTask();
        }

        internal static void EditTask()
        {
            Console.WriteLine("Выберите задачу");

            BrowseAllTask();

            _key = AddKey();
                        
            Console.WriteLine("Что вы хотите изменить?");
            Console.WriteLine("1. Задача");
            Console.WriteLine("2. Приоритет");
            Console.WriteLine("3. Статус");
            
            var key1 = int.Parse(Console.ReadLine());
            if(key1 == 1)
            {
                Console.WriteLine("Введите задачу");
                _taskDictionary[_key].TaskName = Console.ReadLine();
            }
            if (key1 == 2)
            {
                Console.WriteLine("Укажите приоритет");
                _taskDictionary[_key].Priority =  GetTaskStatus();
            }
            if(key1 == 3)
            {
                Console.WriteLine("Укажите готовность");
                _taskDictionary[_key].Status = TaskReady();
            }
            BrowseAllTask();
        }
    }
}
