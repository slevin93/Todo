using System;
using System.Collections.Generic;
using System.Text;

namespace MyTodo.Todo.WebClient.Shared
{
    [Serializable]
    public class TodoItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}