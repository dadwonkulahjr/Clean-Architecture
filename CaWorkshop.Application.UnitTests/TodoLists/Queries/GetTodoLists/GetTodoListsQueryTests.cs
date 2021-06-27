using AutoMapper;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Infrastructure.Persistence;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Queries.GetTodoLists
{
    [Collection(nameof(QueryCollection))]
    public class GetTodoListsQueryTests
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _applicationDbContext;
        public GetTodoListsQueryTests(TestFixture testFixture)
        {
            _mapper = testFixture.Mapper;
            _applicationDbContext = testFixture.Context;
        }
        [Fact]
        public async Task ReturnsCorrectVmAndListCount()
        {
            //Arrange
            var query = new GetTodoListsQuery();
            var handler = new GetTodoListsQueryHandler(_applicationDbContext, _mapper);

            //Act
            var result = await handler.Handle(query,CancellationToken.None);

            //Assert
            result.Should().BeOfType(typeof(TodosVm));
            result.Lists.Should().HaveCount(1);
            result.Lists[0].Items.Should().HaveCount(4);
            
        }
    }
}
