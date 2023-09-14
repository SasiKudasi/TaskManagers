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

