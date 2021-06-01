using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public interface IGetTodoListsQuery
    {
        Task<List<TodoList>> Handle();
    }

    public class GetTodoListsQuery : IRequest<List<TodoList>>
    {
       
    }

    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, List<TodoList>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetTodoListsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<List<TodoList>> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.TodoLists.Select(l => new TodoList()
            {
                Id = l.Id,
                Title = l.Title,
                Items = l.Items.Select(i => new TodoItem
                {
                    Id = i.Id,
                    ListId = i.ListId,
                    Title = i.Title,
                    Done = i.Done,
                    Priority = i.Priority,
                    Note = i.Note
                }).ToList()
            }).ToListAsync(cancellationToken);
        }

    }
}

