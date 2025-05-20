using Microsoft.EntityFrameworkCore;

namespace Eksamen2025Gruppe5.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<PollenRegistrering> PollenRegistreringer { get; set; }
        public DbSet<PollenResponse> PollenResponses { get; set; }
        public DbSet<DateInfo> DateInfos { get; set; }
        public DbSet<IndexInfo> IndexInfos { get; set; }
        public DbSet<ColorInfo> ColorInfos { get; set; }
    }
}
