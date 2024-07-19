using Microsoft.EntityFrameworkCore;
using MyApi.Properties.Model;

namespace MyApi.Properties.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Student?> Students { get; set; }
}