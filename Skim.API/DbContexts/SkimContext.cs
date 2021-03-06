using Microsoft.EntityFrameworkCore;
using Skim.API.Entities;

namespace Skim.API.DbContexts
{
    public class SkimContext : DbContext
    {
        public SkimContext(DbContextOptions<SkimContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Slug must have UNIQUE constraint
            builder.Entity<ShortLink>(entity => 
            {
                entity.HasIndex(e => e.Slug).IsUnique();
            });
        }

        public DbSet<ShortLink> ShortLinks { get; set; }
    }
}