using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Otp> Otps => Set<Otp>();

        // ✅ ADD THIS
        public DbSet<TradeApplication> TradeApplications => Set<TradeApplication>();
    }
}
