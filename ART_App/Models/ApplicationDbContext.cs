using Microsoft.EntityFrameworkCore;


namespace ART_App.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AccountsBRModel> AccountsBR { get; set; }
        public DbSet<ProjectsBRModel> ProjectsBR { get; set; }
        public DbSet<MasterBRModel> MasterBR { get; set; }
    }
}
