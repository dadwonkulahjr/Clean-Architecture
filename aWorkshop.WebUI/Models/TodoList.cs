using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aWorkshop.WebUI.Models
{
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(280)]
        public string Title { get; set; }

        public string Colour { get; set; }

        public IList<TodoItem> Items { get; set; }
        = new List<TodoItem>();
    }
}
