using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;
public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }


    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}
