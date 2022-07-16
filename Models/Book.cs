using System.ComponentModel.DataAnnotations;

namespace CRUD_OP.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
