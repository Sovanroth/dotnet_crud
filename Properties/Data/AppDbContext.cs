using Microsoft.EntityFrameworkCore;
using MyApi.Properties.Models;

namespace MyApi.Properties.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
}