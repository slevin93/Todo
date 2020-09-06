using AutoMapper;
using MediatR;
using MyTodo.Todo.Application.Interfaces.Repositories;
using MyTodo.Todo.Application.Wrappers;
using MyTodo.Todo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Todo.Application.Features.TodoItems.Commands.CreateTodoItems
{
    public class CreateTodoCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Response<long>>
    {
        private readonly ITodoItemRepositoryAsync productRepository;

        private readonly IMapper mapper;

        public CreateTodoCommandHandler(ITodoItemRepositoryAsync productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = mapper.Map<TodoItem>(request);

            await this.productRepository.AddAsync(todoItem);

            return new Response<long>(todoItem.Id);
        }
    }
}
