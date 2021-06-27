using AutoMapper;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.Common.Mapping
{
    public class MappingTests : IClassFixture<MappingFixture>
    {
        private readonly IMapper _mappper;
        public MappingTests(MappingFixture fixture)
        {
            _mappper = fixture.Mapper;
        }
        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _mappper
                .ConfigurationProvider
                .AssertConfigurationIsValid();
                
        }

        [Theory]
        [InlineData(typeof(TodoList), typeof(TodoListDto))]
        [InlineData(typeof(TodoItem), typeof(TodoItemDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);
            _mappper.Map(instance, source, destination);
        }
    }
}
