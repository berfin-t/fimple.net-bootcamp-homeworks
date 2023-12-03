using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public partial class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public BookStoreDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookStoreDb");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });

            .HasForeignKey(ba => ba.AId);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override void RemoveRange(params object[] entities)
        {
            base.RemoveRange(entities);
        }
    }
}
