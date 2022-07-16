using CRUD_OP.Models;

namespace CRUD_OP.Responses
{
    public class BooksResponseManager
    {
        public IEnumerable<Book> Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
