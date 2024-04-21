using aspLearning.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Context;

public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{
    //entities
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .Property(x => x.Name)
            .HasColumnName("s_name")
            .HasColumnType("nvarchar")
            .HasColumnOrder(2)
            .IsRequired()
            .HasMaxLength(150)
            .HasDefaultValue("Ali Chavoshi");

        modelBuilder.Entity<Course>()
            .Property(x => x.CreatedRow)
            .HasDefaultValueSql("GetDate()");

        modelBuilder.Entity<Course>()
            // .HasIndex(x=>x.Name)
            .HasAlternateKey(x => new {x.Id , x.AuthorId});


        modelBuilder.Entity<Course>()
            .Property(x => x.RowVersion)
            .IsRowVersion();

        modelBuilder.Entity<Course>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }
}