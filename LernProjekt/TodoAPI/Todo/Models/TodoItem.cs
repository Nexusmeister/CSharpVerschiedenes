using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Todo.Models
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
