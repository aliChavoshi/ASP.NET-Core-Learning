using aspLearning.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Context;

public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{
    //entities
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API
        modelBuilder.Entity<User>()
            .ToTable("tbl_User", "catalog");

        base.OnModelCreating(modelBuilder);
    }
}