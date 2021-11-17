using System;
using System.Collections.Generic;

namespace TasksWebAPI.Models
{
    public partial class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public bool? IsChecked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
