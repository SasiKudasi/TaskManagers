
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
           _task.Priority = Result.GetTaskStatus();
           _task.Status =  Result.TaskReady();            

            _taskDictionary.Add(_task.Id, new Tasks( _task.TaskName, _task.Priority, _task.Status));

            _appDbContext.Add(_taskDictionary[_task.Id]);

            if (_taskDictionary.ContainsKey(_task.Id))
            {                
                Console.WriteLine($"TaskId: {_task.Id} TaskName: {_task.TaskName}, Priority: {_task.Priority}, Status: {_task.Status}");                                
            }
            _appDbContext.SaveChanges();
        }

        public static void AddTaskName()
        {
            Console.WriteLine("Введите задачу:");
            _task.TaskName = Console.ReadLine();
            if(_task.TaskName == null || _task.TaskName == "")
            {
                Console.WriteLine("Строка не может быть пустая, введите значение:\n");
                AddTaskName();
            }
        }

        private static int AddKey()
        {
            Console.WriteLine("Введите новмер задачи");
            try
            {
                int key = int.Parse(Console.ReadLine());

                return key;
            }
            catch (Exception ex)
            {
               Console.WriteLine("Неправильный формат, попробуйте еще раз\n");   
               return AddKey();
            }
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
                AddTaskName();               
            }
            if (key1 == 2)
            {
                Console.WriteLine("Укажите приоритет");
                taskUpdate.Priority =  Result.GetTaskStatus();
            }
            if(key1 == 3)
            {
                Console.WriteLine("Укажите готовность");
                taskUpdate.Status = Result.TaskReady();
            }
            _appDbContext.SaveChanges();
            BrowseAllTask();
        }
    }
}
