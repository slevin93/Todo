using System;
using System.Collections.Generic;
using System.Text;

namespace MyTodo.Todo.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
