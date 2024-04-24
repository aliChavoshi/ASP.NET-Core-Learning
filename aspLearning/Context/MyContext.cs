using aspLearning.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Context;

public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{
    //entities
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //one to many => author
        modelBuilder.Entity<Author>()
            .HasMany(x => x.Courses) //course
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId);

        //one to many => course
        // modelBuilder.Entity<Course>()
        //     .HasOne(x => x.Author)
        //     .WithMany(x => x.Courses)
        //     .HasForeignKey(x => x.AuthorId);


        base.OnModelCreating(modelBuilder);
    }
}