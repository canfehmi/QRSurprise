using Microsoft.EntityFrameworkCore;
using QRSurprise.Models.DAL.Entities;

namespace QRSurprise.Models.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=104.247.167.202\\MSSQLSERVER2022;initial catalog=kard3540_db;user Id=kard3540_admin;password=Kardyy0705.;TrustServerCertificate=True;");
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<Proverb> Proverbs { get; set; }
        public DbSet<Sound> Sounds { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
    }
}
