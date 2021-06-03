using AutoMapper;
using CaWorkshop.Application.Common.Mapping;
using CaWorkshop.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public long Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public int Priority { get; set; }

        public string Note { get; set; }

        //public void Mapping(Profile profile)
        //{
        //   profile.CreateMap<TodoItem, TodoItemDto>()
        //           .ForMember(d => d.Priority,
        //           opt => opt.MapFrom(s => (int)s.Priority));
        //}

        //public static Expression<Func<TodoItem, TodoItemDto>> Projection

        //{
        //    get
        //    {
        //        return item => new TodoItemDto
        //        {
        //            Id = item.Id,
        //            ListId = item.ListId,
        //            Title = item.Title,
        //            Done = item.Done,
        //            Priority = (int)item.Priority,
        //            Note = item.Note
        //        };
        //    }
        //}
    }
}
