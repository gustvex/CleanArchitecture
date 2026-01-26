using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
