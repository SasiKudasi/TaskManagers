using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TaskManager
{
    public  class Task
    {
        public string TaskName {  get; set; }
        
        public string Priority { get; set; }
        public string Status { get; set; }
           
        public Task() { }

        public Task(Task task)
        { 
            TaskName = task.TaskName;
            Priority = task.Priority;
            Status = task.Status;

        }

       
    }

}

