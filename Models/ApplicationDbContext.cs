using Microsoft.EntityFrameworkCore;


namespace TodoApp.Models
{
public class ApplicationDbContext : DbContext
{
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options) { }


public DbSet<User> Users { get; set; } = null!;
public DbSet<TodoItem> TodoItems { get; set; } = null!;
}
}