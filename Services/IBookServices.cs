using CRUD_OP.Responses;
using CRUD_OP.ViewModels;

namespace CRUD_OP.Services
{
    public interface IBookServices
    {
        Task<BooksResponseManager> RetrieveBooks();
        Task<BookResponseManager> RetriveBook(int id);
        Task<BookResponseManager> CreateBook(BookVM model);
        Task<BookResponseManager> UpdateBook(int id, BookVM model);
        Task<BookResponseManager> DeleteBook(int id);
    }
}
