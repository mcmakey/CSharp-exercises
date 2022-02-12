using Microsoft.EntityFrameworkCore;

namespace CardService.Models
{
    public class CardServiceContext : DbContext
    {

        public CardServiceContext(DbContextOptions<CardServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Card> Cards { get; set; } = null!;
    }
}
