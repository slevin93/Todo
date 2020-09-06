using MediatR;
using MyTodo.Todo.Application.Exceptions;
using MyTodo.Todo.Application.Interfaces.Repositories;
using MyTodo.Todo.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Todo.Application.Features.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, Response<int>>
    {
        private readonly ITodoItemRepositoryAsync todoItemRepository;

        public UpdateTodoItemCommandHandler(ITodoItemRepositoryAsync todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public async Task<Response<int>> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await todoItemRepository.GetByIdAsync(request.Id);

            if (todoItem is null)
                throw new ApiException("Todo Item Not Found.");

            todoItem.Name = request.Name;
            todoItem.IsComplete = request.IsComplete;

            await todoItemRepository.UpdateAsync(todoItem);

            return new Response<int>(todoItem.Id);
        }
    }
}
