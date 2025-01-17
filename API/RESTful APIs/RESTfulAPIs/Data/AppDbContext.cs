using Microsoft.EntityFrameworkCore;
using RESTfulAPIs.Model;

namespace RESTfulAPIs.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Book>Books { get; set; }
}