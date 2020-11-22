using Domain.Players;
using Domain.Teams;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infra
{
    public class BrasileiraoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        // public DbSet<Team> Teams { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=pass?WORD!;Initial Catalog=Brasileirao");
        }
    }
}