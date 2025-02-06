using Microsoft.EntityFrameworkCore;
using training_track_backend.Models;

namespace training_track_backend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
    }
}
