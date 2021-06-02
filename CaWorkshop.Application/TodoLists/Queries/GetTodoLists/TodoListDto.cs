using AutoMapper;
using CaWorkshop.Application.Common.Mapping;
using CaWorkshop.Domain.Entities;
using System.Collections.Generic;


namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<TodoItemDto> Items { get; set; }
        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<TodoList, TodoListDto>();
        //}

        //public static Expression<Func<TodoList, TodoListDto>> Projection
        //{
        //    get
        //    {
        //        return list => new TodoListDto()
        //        {
        //            Id = list.Id,
        //            Title = list.Title,
        //            Items = list.Items.AsQueryable()
        //                        .Select(TodoItemDto.Projection)
        //                        .ToList()
        //        };

        //    }
        //}
    }
}
