using Microsoft.EntityFrameworkCore;
using Xeyyam.Models;

namespace Xeyyam.DAL;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
    {
        
    }

    public DbSet<Category> Categories { get; set; } = null!;
}


