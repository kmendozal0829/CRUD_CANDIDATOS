using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;
        private readonly ILogger<CreateCandidateCommandHandler> logger;

        public CreateCandidateCommandHandler(ICandidateRepository candidateRepository, IMapper mapper, ILogger<CreateCandidateCommandHandler> logger)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateEntity = mapper.Map<Candidate>(request);
            var newCandidate = await candidateRepository.AddAsync(candidateEntity);
            logger.LogInformation($"Candidate {newCandidate.CandidateId} created");
            return newCandidate.CandidateId;
        }
    }
}
