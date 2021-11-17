using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksWebAPI.Models;

namespace TasksWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class ToDoTaskController : ControllerBase
    {
        
        [HttpGet("Get")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<ToDoTask> Get()
        {
            using (var context = new ToDoDbContext())
            {
                var res= context.ToDoTask.ToList();
                return res;
            }
        }

        [HttpPost("Post")]
        [EnableCors("AllowOrigin")]
        public void Post([FromForm] ToDoTask toDoTask)
        {
            var newTask = new ToDoTask();
            newTask.Description = toDoTask.Description;
            newTask.Name = toDoTask.Name;
            newTask.UserId = 1;
            newTask.IsChecked = toDoTask.IsChecked.Equals("True")?true:false;
            newTask.CreatedOn = DateTime.Now;
            newTask.ModifiedOn = DateTime.Now;

            using (var context = new ToDoDbContext())
            {
                context.ToDoTask.Add(newTask);
                context.SaveChanges();
            }
        }
    }
}
