using MyTodo.Todo.Web.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodo.Todo.Web.Services
{
    public interface ITodoItemsService
    {
        Task<ApiPagesResponse<IEnumerable<TodoItems>>> GetTodoItemsAsync();

        Task DeleteTodoItemsAsync(int id);

        Task AddTodoItemAsync(TodoItems todoItems);

        Task UpdateTodoItemsAsync(TodoItems todoItems);
    }
}