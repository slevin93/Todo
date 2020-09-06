using Microsoft.EntityFrameworkCore;
using MyTodo.Todo.Application.Interfaces.Repositories;
using MyTodo.Todo.Domain.Entities;
using MyTodo.Todo.Infrastructure.Persistence.Contexts;
using MyTodo.Todo.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTodo.Todo.Infrastructure.Persistence.Repositories
{
    public class TodoItemRepositoryAsync : GenericRepositoryAsync<TodoItem>, ITodoItemRepositoryAsync
    {
        private readonly DbSet<TodoItem> todoItems;

        public TodoItemRepositoryAsync(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.todoItems = dbContext.Set<TodoItem>();
        }
    }
}
