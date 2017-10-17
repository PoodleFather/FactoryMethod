using Microsoft.EntityFrameworkCore;

namespace FactoryMehtodLib.Model
{
    public class Entities : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=HyunWoo;User Id=sa;Password=ad!@#0;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<BoardAdmin> BoardAdmin { get; set; }
        public DbSet<Joiner> Joiner { get; set; }
    }
}
