
using ConsoleApp1;

namespace TaskManager
{
    public class TasksManager
    {
       

        private static Tasks _task = new Tasks();
     
        private static Dictionary<int, Tasks> _taskDictionary = new Dictionary<int, Tasks>();

        private static AppDbContext _appDbContext = new AppDbContext();
                       
        internal static void AddTask()
        {
            _task.Id = AddKey();
            AddTaskName();            
            GetTaskStatus();
            TaskReady();            

            _taskDictionary.Add(_task.Id, new Tasks( _task.TaskName, _task.Priority, _task.Status));

            _appDbContext.Add(_taskDictionary[_task.Id]);
            if (_taskDictionary.ContainsKey(_task.Id))
            {                
                Console.WriteLine($"TaskName: {_task.TaskName}, Priority: {_task.Priority}, Status: {_task.Status}");                                
            }
            _appDbContext.SaveChanges();
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
            var priority = _appDbContext.Tasks.Where(task => task.Priority == text);

            foreach (var task in priority)
            {
                Console.WriteLine($"TaskId: {task.Id} TaskName: {task.TaskName}, Priority: {task.Priority}, Status: {task.Status}");
            }
        }


        public static void SortStatus(string text)
        {
            var status = _appDbContext.Tasks.Where(task => task.Status == text);

            foreach (var task in status)
            {
                Console.WriteLine($"TaskId: {task.Id} TaskName: {task.TaskName}, Priority: {task.Priority}, Status: {task.Status}");
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
            var allTasks = _appDbContext.Tasks.ToList();

            foreach (var task in allTasks)
            {
                Console.WriteLine($"TaskId: {task.Id} TaskName: {task.TaskName}, Priority: {task.Priority}, Status: {task.Status}");
            }                       
        }

        internal static void DeliteAllTasks()
        {
            BrowseAllTask();
            var allTasks = _appDbContext.Tasks.ToList();
            _appDbContext.Tasks.RemoveRange(allTasks);
            _appDbContext.SaveChanges();            
        }

        internal static void DeliteTask()
        {
            Console.WriteLine("Выберите задачу, которую хотите удалить:");
            BrowseAllTask();
            int key  = int.Parse(Console.ReadLine());
           var removeTask = _appDbContext.Tasks.Find(key);   
            _appDbContext.Tasks.Remove(removeTask);
            _appDbContext.SaveChanges();
            BrowseAllTask();
        }

        internal static void EditTask()
        {
            Console.WriteLine("Выберите задачу");

            BrowseAllTask();

            _task.Id = AddKey();
                        
            Console.WriteLine("Что вы хотите изменить?");
            Console.WriteLine("1. Задача");
            Console.WriteLine("2. Приоритет");
            Console.WriteLine("3. Статус");
            
            var key1 = int.Parse(Console.ReadLine());
            var taskUpdate =  _appDbContext.Tasks.Find(_task.Id);
            if (key1 == 1)
            {
                Console.WriteLine("Введите задачу");
                taskUpdate.TaskName = Console.ReadLine();                
            }
            if (key1 == 2)
            {
                Console.WriteLine("Укажите приоритет");
                taskUpdate.Priority =  GetTaskStatus();
            }
            if(key1 == 3)
            {
                Console.WriteLine("Укажите готовность");
                taskUpdate.Status = TaskReady();
            }
            _appDbContext.SaveChanges();
            BrowseAllTask();
        }
    }
}
