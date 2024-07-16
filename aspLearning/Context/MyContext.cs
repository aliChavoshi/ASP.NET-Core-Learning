using System.Runtime.CompilerServices;
using aspLearning.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Context;

public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{
    //entities
    public DbSet<Course> Courses => Set<Course>(); //CRUD
    public DbSet<Author> Author => Set<Author>();
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //one to many => author
        // modelBuilder.Entity<Author>()
        //     .HasMany() //course
        //     .WithOne(x => x.Author)
        //     .HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);

        // one to many => course
         modelBuilder.Entity<Course>()
             .HasOne(x => x.Author)
             .WithMany()
             .HasForeignKey(x => x.AuthorId);


        modelBuilder.Entity<Student>()
            .HasOne(x => x.StudentAddress)
            .WithOne(x => x.Student)
            .HasForeignKey<StudentAddress>(x => x.StudentId)
            .HasPrincipalKey<Student>(x => x.Id);


        //many to many
        modelBuilder.Entity<BookCategory>()
            .HasKey(x => new { x.BookId, x.CategoryId });

        modelBuilder.Entity<BookCategory>()
            .HasOne(x => x.Book)
            .WithMany(x => x.BookCategories)
            .HasForeignKey(x => x.BookId);

        modelBuilder.Entity<BookCategory>()
            .HasOne(x => x.Category)
            .WithMany(x => x.BookCategories)
            .HasForeignKey(x => x.CategoryId);


        base.OnModelCreating(modelBuilder);
    }
}