using CaWorkshop.Application.Common.Exceptions;
using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CaWorkshop.Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommand : IRequest
    {
        public long Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public int Priority { get; set; }

        public string Note { get; set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateTodoItemCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity =  await _applicationDbContext.TodoItems.FindAsync(request.Id);
            if(entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.ListId = request.ListId;
            entity.Title = request.Title;
            entity.Done = request.Done;
            entity.Priority = (PriorityLevel)request.Priority;
            entity.Note = request.Note;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
