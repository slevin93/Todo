using AutoMapper;
using MyTodo.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MyTodo.Todo.Application.Features.TodoItems.Queries.GetAllTodoItems;
using MyTodo.Todo.Application.Features.TodoItems.Commands.CreateTodoItems;

namespace MyTodo.Todo.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<TodoItem, GetAllTodoItemsViewModel>().ReverseMap();
            CreateMap<CreateTodoCommand, TodoItem>();
            CreateMap<GetAllTodoItemsQuery, GetAllTodoItemsParameter>();
        }
    }
}
