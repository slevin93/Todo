using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodo.Todo.Web.Models
{
    public class ApiPagesResponse<T> : ApiResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
