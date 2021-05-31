using aWorkshop.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace aWorkshop.WebUI.Data
{
    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.TodoLists.Any())
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
