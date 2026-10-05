using Library_Management_Case_Study.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Common;

namespace Library_Management_Case_Study.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Borrowing> borrowings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(m => m.Email).IsUnique();


            modelBuilder.Entity<Book>()
                .HasOne(ct => ct.category)
                .WithMany(b => b.Books)
                .HasForeignKey(ct => ct.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrowing>()
                .HasOne(m => m.member)
                .WithMany(b => b.Borrowings)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.book)
                .WithMany(b => b.Borrowings)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programming", Description = "Programming and software development books" },
                new Category { Id = 2, Name = "Database", Description = "Database and data management books" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "C++ Basics", Author = "John Smith", ISBN = "1ISBN001", Price = 450, IsAvailable = true, CategoryId = 1 },
                new Book { Id = 2, Title = "SQL Fundamentals", Author = "Sarah Ali", ISBN = "ISBN002", Price = 500, IsAvailable = false, CategoryId = 2 }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed@example.com", Phone = "01012345678" },
                new Member { Id = 2, FullName = "Sara Mohamed", Email = "sara@example.com", Phone = "01198765432" }
            );

            modelBuilder.Entity<Borrowing>().HasData(
                new Borrowing { Id = 1, MemberId = 1, BookId = 2, BorrowDate = new DateTime(2026, 09, 20), ReturnDate = new DateTime(2026, 09, 25) },
                new Borrowing { Id = 2, MemberId = 2, BookId = 1, BorrowDate = new DateTime(2026, 09, 22), ReturnDate = null }
            );

        }
    }

}
