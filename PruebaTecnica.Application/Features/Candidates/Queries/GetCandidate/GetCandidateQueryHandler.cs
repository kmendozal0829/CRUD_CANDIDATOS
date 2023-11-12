using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Candidates.Queries.GetCandidate
{
    public class GetCandidateQueryHandler : IRequestHandler<GetCandidateQuery, CandidateWithExperiencesVm>
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;

        public GetCandidateQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }

        public async Task<CandidateWithExperiencesVm> Handle(GetCandidateQuery request, CancellationToken cancellationToken)
        {
            var includes = new List<Expression<Func<Candidate, object>>>
            {
                x => x.CandidateExperiences
            };

            var candidate = await candidateRepository.GetCandidateByIdAsync(request.Id);

            return mapper.Map<CandidateWithExperiencesVm>(candidate);
        }
    }
}
