using CaWorkshop.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using CaWorkshop.Application.Common.Exceptions;
using CaWorkshop.Domain.Entities;

namespace CaWorkshop.Application.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }

    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public UpdateTodoListCommandHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public async Task<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.TodoLists.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            entity.Title = request.Title;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
