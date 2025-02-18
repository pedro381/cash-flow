using Microsoft.EntityFrameworkCore;

namespace Consolidation.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para a entidade Consolidation
        public DbSet<Domain.Entities.Consolidation> Consolidations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais para a entidade Consolidation, se necessário.
            modelBuilder.Entity<Domain.Entities.Consolidation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date)
                      .IsRequired();
                entity.Property(e => e.TotalCredits)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalDebits)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.Property(e => e.Balance)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.Property(e => e.Type)
                      .IsRequired();
            });
        }
    }
}
