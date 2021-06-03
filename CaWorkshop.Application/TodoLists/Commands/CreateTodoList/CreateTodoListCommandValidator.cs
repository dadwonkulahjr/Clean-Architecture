using CaWorkshop.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaWorkshop.Application.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateTodoListCommandValidator(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            RuleFor(v => v.Title)
                .MaximumLength(240)
                .NotEmpty()
                .MustAsync(BeUniqueTitle)
                .WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.TodoLists.AllAsync(
                l => l.Title != title, cancellationToken
                );
        }
    }
}
