using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Domain;
using PruebaTecnica.Infrastructure.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(CandidateDbContext context) : base(context)
        {
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await context.Candidates.AsNoTracking().Where(a => a.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await context.Candidates
                .Include(x => x.CandidateExperiences)
                .Where(a => a.CandidateId == id)
                .AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
