using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain;
using PruebaTecnica.Domain.Common;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace PruebaTecnica.Infrastructure.Persistence
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options): base(options)
        {
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.ModifyDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.InsertDate = DateTime.Now;
                        entry.Entity.ModifyDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasMany(m => m.CandidateExperiences)
                .WithOne(m => m.Candidate)
                .HasForeignKey(m => m.CandidateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Candidate>()
                .HasAlternateKey(m => m.Email);
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidatesExperiences { get; set; }
    }
}
