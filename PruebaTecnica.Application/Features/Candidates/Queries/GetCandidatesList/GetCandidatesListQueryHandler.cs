using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList
{
    public class GetCandidatesListQueryHandler : IRequestHandler<GetCandidatesListQuery, List<CandidatesVm>>
    {

        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;

        public GetCandidatesListQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }

        public async Task<List<CandidatesVm>> Handle(GetCandidatesListQuery request, CancellationToken cancellationToken)
        {
            var candidates = await candidateRepository.GetAllAsync();
            return mapper.Map<List<CandidatesVm>>(candidates);
        }
    }
}
