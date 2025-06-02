using Microsoft.EntityFrameworkCore;
using QRSurprise.Models.DAL.Entities;

namespace QRSurprise.Models.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E7MGKIP;initial catalog=SurpriseDb;integrated security=true;");
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<Proverb> Proverbs { get; set; }
        public DbSet<Sound> Sounds { get; set; }
    }
}
