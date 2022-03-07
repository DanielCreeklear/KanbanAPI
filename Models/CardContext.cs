using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KanbanAPI.Models
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options)
            : base(options)
        {
        }

        public DbSet<CardItem> CardItems { get; set; } = null!;
    }
}
