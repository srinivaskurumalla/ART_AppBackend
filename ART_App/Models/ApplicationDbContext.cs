using Microsoft.EntityFrameworkCore;


namespace ART_App.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AccountsBRModel> AccountsBR { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<AccountsBRModel>()
                .Property(x => x.AccountId)
                .HasComputedColumnSql("CONCAT('ACC',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))");

            modelBuilder.Entity<ProjectsBRModel>()
               .Property(x => x.ProjectId)
               .HasComputedColumnSql("CONCAT('PR',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))");
            modelBuilder.Entity<MasterBRModel>()
             .Property(x => x.CandidateId)
             .HasComputedColumnSql("CONCAT('CA',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))");

            modelBuilder.Entity<SignUpModel>()
            .Property(x => x.EmpId)
            .HasComputedColumnSql("CONCAT('ICS',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))");

          
        }
        public DbSet<ProjectsBRModel> ProjectsBR { get; set; }

        public DbSet<MasterBRModel> MasterBR { get; set; }
        public DbSet<SignUpModel> SignUpModel { get; set; }

    }
}
