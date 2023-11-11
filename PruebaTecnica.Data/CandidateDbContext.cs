using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain;

namespace PruebaTecnica.Data
{
    public class CandidateDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=192.168.0.16; Initial Catalog=GHDatabase;User id=sa;Password=Contraseña12345678;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasMany(m => m.CandidateExperiences)
                .WithOne(m => m.Candidate)
                .HasForeignKey(m => m.CandidateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Candidate>()
                .HasAlternateKey(m => m.Email);
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidatesExperiences { get; set; }
    }
}
