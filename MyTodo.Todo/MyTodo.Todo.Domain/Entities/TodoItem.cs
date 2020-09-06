using System;
using System.Collections.Generic;
using System.Text;

namespace MyTodo.Todo.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
