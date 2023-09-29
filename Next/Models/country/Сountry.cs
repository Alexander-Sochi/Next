using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Next.Models.country
{
    public class Game
    {
        public int Id { get; set; }
        public string Gta { get; set; } // название компании

        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GameId { get; set; }      // внешний ключ
        public Game Game { get; set; }    // навигационное свойство
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Companies { get; set; }
        public DbSet<Player> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
        }
    }
}
