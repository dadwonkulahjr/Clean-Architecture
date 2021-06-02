using AutoMapper;
using AutoMapper.QueryableExtensions;
using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
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

    public class TodosVm
    {
        public List<PriorityLevelDto> PriorityLevels { get; set; }
        public List<TodoListDto> Lists { get; set; }
    }

    public class PriorityLevelDto
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
    public class GetTodoListsQuery : IRequest<TodosVm>
    {

    }

    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, TodosVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTodoListsQueryHandler(IApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<TodosVm> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            return new TodosVm
            {
                PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                                       .Cast<PriorityLevel>()
                                       .Select(p => new PriorityLevelDto
                                       {
                                           Value = (int)p,
                                           Name = p.ToString()
                                       }).ToList(),
                Lists = await _dbContext.TodoLists
                                        .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                                        .ToListAsync(cancellationToken)
            };
        }

    }
}

