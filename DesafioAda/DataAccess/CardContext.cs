using DesafioAda.Domain;
using Microsoft.EntityFrameworkCore;

namespace DesafioAda.DataAccess
{
    public class CardContext : DbContext
    {

        public CardContext(DbContextOptions<CardContext> options) 
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
