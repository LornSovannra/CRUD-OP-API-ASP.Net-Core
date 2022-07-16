using CRUD_OP.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_OP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        public DbSet<Book> Books { get; set; }
    }
}
