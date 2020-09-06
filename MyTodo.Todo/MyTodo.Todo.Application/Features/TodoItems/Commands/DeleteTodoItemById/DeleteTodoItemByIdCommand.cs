using MediatR;
using MyTodo.Todo.Application.Exceptions;
using MyTodo.Todo.Application.Interfaces.Repositories;
using MyTodo.Todo.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Todo.Application.Features.TodoItems.Commands.DeleteTodoItemById
{
    public class DeleteTodoItemByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteItemByIdCommandHandler : IRequestHandler<DeleteTodoItemByIdCommand, Response<int>>
    {
        private readonly ITodoItemRepositoryAsync todoItemRepository;

        public DeleteItemByIdCommandHandler(ITodoItemRepositoryAsync todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public async Task<Response<int>> Handle(DeleteTodoItemByIdCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await this.todoItemRepository.GetByIdAsync(request.Id);

            if (todoItem is null)
                throw new ApiException("Todo Item Not Found.");

            await this.todoItemRepository.DeleteAsync(todoItem);

            return new Response<int>(todoItem.Id);
        }
    }
}
