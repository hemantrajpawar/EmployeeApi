namespace Backend.DbContext;
using Microsoft.EntityFrameworkCore;
using Backend.Model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {    
        // define primary key to userId as it shared...
        modelBuilder.Entity<Employee>()
        .HasKey(e => e.UserId);

         // User 1 -> 1 Employee
        modelBuilder.Entity<User>()
        .HasOne(u => u.Employee)
        .WithOne(e => e.User)
        .HasForeignKey<Employee>(e => e.UserId) // it shows one to one relation with foreignkey in employee table havinf user.id as a primary key of user
        .OnDelete(DeleteBehavior.Cascade);

        // employee * -> 1 department 
        modelBuilder.Entity<Employee>() 
        .HasOne(e => e.Department)
        .WithMany(d => d.Employees)
        .HasForeignKey(e => e.DepartmentId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}