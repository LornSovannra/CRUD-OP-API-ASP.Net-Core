using CRUD_OP.Data;
using CRUD_OP.Models;
using CRUD_OP.Responses;
using CRUD_OP.Services;
using CRUD_OP.ViewModels;

namespace CRUD_OP.Providers
{
    public class BookProvider : IBookServices
    {
        private readonly ApplicationDbContext context;

        public BookProvider(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<BooksResponseManager> RetrieveBooks()
        {
            var books = context.Books.ToList();

            return new BooksResponseManager
            {
                Data = books,
                Message = "Retrived",
                IsSuccess = true,
            };
        }

        public async Task<BookResponseManager> RetriveBook(int id)
        {
            var book = context.Books.Find(id);

            if(book == null)
                return new BookResponseManager
                {
                    Message = "Book not found.",
                    IsSuccess = false,
                };

            return new BookResponseManager
            {
                Data = book,
                Message = "Retrived",
                IsSuccess = true,
            };
        }

        public async Task<BookResponseManager> CreateBook(BookVM model)
        {
            if (string.IsNullOrEmpty(model.Title))
                return new BookResponseManager
                {
                    Message = "Title is required.",
                    IsSuccess = false
                };

            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
            };

            context.Books.Add(book);
            context.SaveChanges();

            return new BookResponseManager
            {
                Message = $"Book: {model.Title} created.",
                IsSuccess = true
            };
        }

        public async Task<BookResponseManager> UpdateBook(int id, BookVM model)
        {
            var book = context.Books.Find(id);

            if (book == null)
                return new BookResponseManager
                {
                    Message = "Book not found.",
                    IsSuccess = false
                };

            book.Title = model.Title;
            book.Description = model.Description;
            context.Update(book);
            context.SaveChanges();

            return new BookResponseManager
            {
                Message = $"Book with Id: {id} updated.",
                IsSuccess = true
            };
        }

        public async Task<BookResponseManager> DeleteBook(int id)
        {
            var book = context.Books.Find(id);

            if(book == null)
                return new BookResponseManager
                {
                    Message = "Book not found.",
                    IsSuccess = false
                };

            context.Remove(book);
            context.SaveChanges();

            return new BookResponseManager
            {
                Message = $"Book with Id: {id} deleted.",
                IsSuccess = true
            };
        }
    }
}
