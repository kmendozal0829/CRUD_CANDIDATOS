using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Application.Exceptions;
using PruebaTecnica.Domain;
using System.Collections.Generic;
using System.Linq;
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

            var existCandidate = await candidateRepository.GetCandidateByEmailAsync(candidateEntity.Email);
            if (existCandidate != null)
            {
                throw new DuplicateException("Correo ingresado ya existe");
            }
            candidateEntity.CandidateExperiences = new List<CandidateExperience>();
            candidateEntity.CandidateExperiences = GetListExperiences(request);
            var newCandidate = await candidateRepository.AddAsync(candidateEntity);
            logger.LogInformation($"Candidate {newCandidate.CandidateId} created");
            return newCandidate.CandidateId;
        }

        private List<CandidateExperience> GetListExperiences(CreateCandidateCommand request)
        {
            var listExperiences = new List<CandidateExperience>();

            foreach (var item in request.CandidateExperiences)
            {
                var experience = new CandidateExperience()
                {
                    BeginDate = item.BeginDate,
                    Company = item.Company,
                    Description = item.Description,
                    EndDate = item.EndDate,
                    Job = item.Job,
                    Salary = item.Salary                    
                };
                listExperiences.Add(experience);
            }

            return listExperiences;
        }
    }
}
