using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MyTodo.Todo.WebClient.Shared
{
    public class ApiResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string Errors { get; set; }
        public T Data { get; set; }
    }
}
