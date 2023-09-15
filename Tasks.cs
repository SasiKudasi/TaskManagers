
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManager
{
        public  class Tasks
        {
      
        public int Id { get; set; }
        public string TaskName {  get; set; }        
        public string Priority { get; set; }
        public string Status { get; set; }
                      
        public Tasks() { }

        public Tasks(string taskName, string priority, string status)
        {
            TaskName = taskName;
            Priority = priority;
            Status = status;
        }

        

       

       
    }

}

