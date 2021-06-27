using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Infrastructure.Persistence;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidatorTests : TestFixture
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CreateTodoListCommandValidatorTests()
        {
            _applicationDbContext = Context;
        }

        [Fact]
        public void IsValid_ShouldBeTrue_WhenListTitleIsUnique()
        {
            var command = new CreateTodoListCommand()
            {
                Title = "Bucket List"
            };

            var validator = new CreateTodoListCommandValidator(_applicationDbContext);

            var result = validator.Validate(command);
            result.IsValid.Should().Be(true);
        }
        [Fact]
        public void IsValid_ShouldBeFalse_WhenListTitleIsNotUnique()
        {
            var command = new CreateTodoListCommand()
            {
                Title = "Todo List"
            };
            var validator = new CreateTodoListCommandValidator(_applicationDbContext);
            var result = validator.Validate(command);

            result.IsValid.Should().Be(false);
        }
    }
}
