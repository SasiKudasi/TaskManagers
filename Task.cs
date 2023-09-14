
using System.ComponentModel.DataAnnotations;

namespace TaskManager
{
    public  class Task
    {
        [Key]
        public int Id { get; set; } 
        public string TaskName {  get; set; }        
        public string Priority { get; set; }
        public string Status { get; set; }


        public Task[] Tasks { get; set; }
        public Task() { }

        public Task(string taskName, string priority, string status)
        {
            TaskName = taskName;
            Priority = priority;
            Status = status;
        }

        

       

       
    }

}

