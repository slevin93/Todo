using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodo.Todo.Web.Models
{
    public class TodoItems
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public bool IsComplete { get; set; }
    }
}
