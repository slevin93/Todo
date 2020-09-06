using MyTodo.Todo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodo.Todo.Web.Services
{
    public class TodoItemsService : BaseRestApi, ITodoItemsService
    {
        const string baseUrl = "https://localhost:9001";

        public Task<ApiPagesResponse<IEnumerable<TodoItems>>> GetTodoItemsAsync()
        {
            return GetJsonAsync<ApiPagesResponse<IEnumerable<TodoItems>>>($"{baseUrl}/api/v1/Todo");
        }

        public Task DeleteTodoItemsAsync(int id)
        {
            return DeleteAsync($"{baseUrl}/api/v1/Todo", id);
        }

        public Task AddTodoItemAsync(TodoItems todoItems)
        {
            return PostAsync($"{baseUrl}/api/v1/Todo", todoItems);
        }

        public Task UpdateTodoItemsAsync(TodoItems todoItems)
        {
            return PutAsync($"{baseUrl}/api/v1/Todo", todoItems);
        }
    }
}
