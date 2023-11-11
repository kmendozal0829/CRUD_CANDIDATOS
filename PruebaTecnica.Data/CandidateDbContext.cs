using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain;

namespace PruebaTecnica.Data
{
    public class CandidateDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress; Initial Catalog=Candidates;Integrated Security=True");
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidatesExperiences { get; set; }
    }
}
