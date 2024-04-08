using ContactManager.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){ }

        public DbSet<UserEntity> Users { get; set; }
    }
}
