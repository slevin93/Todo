using AutoMapper;
using MediatR;
using MyTodo.Todo.Application.Interfaces.Repositories;
using MyTodo.Todo.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Todo.Application.Features.TodoItems.Queries.GetAllTodoItems
{
    public class GetAllTodoItemsQuery : IRequest<PagedResponse<IEnumerable<GetAllTodoItemsViewModel>>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }

    public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, PagedResponse<IEnumerable<GetAllTodoItemsViewModel>>>
    {
        private readonly ITodoItemRepositoryAsync todoItemRepository;
        private readonly IMapper mapper;

        public GetAllTodoItemsQueryHandler(ITodoItemRepositoryAsync todoItemRepository, IMapper mapper)
        {
            this.todoItemRepository = todoItemRepository;

            this.mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllTodoItemsViewModel>>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = mapper.Map<GetAllTodoItemsParameter>(request);

            var todoItem = await this.todoItemRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);

            var todoItemViewModel = mapper.Map<IEnumerable<GetAllTodoItemsViewModel>>(todoItem);

            return new PagedResponse<IEnumerable<GetAllTodoItemsViewModel>>(todoItemViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
