using CaWorkshop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CaWorkshop.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.TodoItems.Any())
            {
                return;
            }
            var newListItem = new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem
                    {
                       Title = "Make a todo list"
                    },
                     new TodoItem
                    {
                       Title = "Check off the first item"
                    },
                     new TodoItem
                    {
                       Title = "Realise you've already it all"
                    },
                    new TodoItem
                    {
                       Title = "Reward yourself with a something new"
                    }

                }
            };
            applicationDbContext.TodoLists.Add(newListItem);
            applicationDbContext.SaveChanges();

        }
    }
}
