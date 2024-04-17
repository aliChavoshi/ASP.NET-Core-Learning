using aspLearning.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Context;

public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{
    //entities
    public DbSet<Course> Courses => Set<Course>();

    //Cache
    //re-used
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API
        modelBuilder.Entity<User>()
            .Property(x => x.UserName)
            .HasMaxLength(150);

        base.OnModelCreating(modelBuilder);
    }

    //new context => call
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(opt =>
        // {
        //
        // });
        base.OnConfiguring(optionsBuilder);
    }
}