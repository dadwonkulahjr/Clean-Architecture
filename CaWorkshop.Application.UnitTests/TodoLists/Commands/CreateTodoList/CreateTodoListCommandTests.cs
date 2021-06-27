using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Infrastructure.Persistence;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandTests : TestFixture
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CreateTodoListCommandTests()
        {
            _applicationDbContext = Context;
        }

        [Fact]
        public async Task ShouldPersistTodoList()
        {
            var command = new CreateTodoListCommand()
            {
                Title = "Bucket List"
            };

            var handler = new CreateTodoListCommandHandler(_applicationDbContext);
            var result = await handler.Handle(command, CancellationToken.None);

            var entity = _applicationDbContext.TodoLists.Find(result);
            entity.Should().NotBeNull();
            entity.Title.Should().Be(command.Title);
        }
    }
}
