using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate;
using PruebaTecnica.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Candidates.Commands.EditCandidate
{
    public class EditCandidateCommandHandler : IRequestHandler<EditCandidateCommand, bool>
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly ICandidateExperienceRepository candidateExperienceRepository;
        private readonly IMapper mapper;
        private readonly ILogger<CreateCandidateCommandHandler> logger;

        public EditCandidateCommandHandler(ICandidateRepository candidateRepository, ICandidateExperienceRepository candidateExperienceRepository, IMapper mapper, ILogger<CreateCandidateCommandHandler> logger)
        {
            this.candidateRepository = candidateRepository;
            this.candidateExperienceRepository = candidateExperienceRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<bool> Handle(EditCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateEntity = mapper.Map<Candidate>(request);
            candidateEntity.CandidateExperiences = new List<CandidateExperience>();
            candidateEntity.CandidateExperiences = await UpdateListExperiences(request.CandidateExperiences, candidateEntity.CandidateId);
            await candidateRepository.UpdateAsync(candidateEntity);
            return true;
        }

        private async Task<List<CandidateExperience>> UpdateListExperiences(IEnumerable<ExperienceViewModel> experiences, int candidateId)
        {
            try
            {
                var listExperiences = new List<CandidateExperience>();

                foreach (var item in experiences)
                {
                    var experience = new CandidateExperience()
                    {
                        CandidateExperienceId = item.CandidateExperienceId,
                        BeginDate = item.BeginDate,
                        Company = item.Company,
                        Description = item.Description,
                        EndDate = item.EndDate,
                        Job = item.Job,
                        Salary = item.Salary,
                        ModifyDate = DateTime.Now,
                        CandidateId = candidateId
                    };
                    await candidateExperienceRepository.UpdateAsync(experience);
                    listExperiences.Add(experience);
                }

                return listExperiences;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
