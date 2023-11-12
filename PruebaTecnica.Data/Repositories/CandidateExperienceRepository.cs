using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Domain;
using PruebaTecnica.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class CandidateExperienceRepository : RepositoryBase<CandidateExperience>, ICandidateExperienceRepository
    {
        public CandidateExperienceRepository(CandidateDbContext candidateDbContext) : base(candidateDbContext)
        {
        }
    }
}
