using Microsoft.EntityFrameworkCore;
using TeamManageApp.Models;

namespace TeamManageApp.Data
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<IssueList> IssueList { get; set; }
        public DbSet<Issue> Issue { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
