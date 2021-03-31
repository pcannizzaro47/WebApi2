using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("user");
            modelBuilder.Entity<FileCollector>(etb => etb.HasIndex(e => new { e.CollectorId, e.FileId }).IsUnique());
        }

        public DbSet<File> Files { get; set; }

        public DbSet<Collector> Collectors { get; set; }

        public DbSet<FileCollector> FilesCollectors { get; set; }
    }
}
