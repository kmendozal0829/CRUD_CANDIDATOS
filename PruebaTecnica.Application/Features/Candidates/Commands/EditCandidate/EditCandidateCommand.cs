using MediatR;
using System.Collections.Generic;
using System;

namespace PruebaTecnica.Application.Features.Candidates.Commands.EditCandidate
{
    public class EditCandidateCommand : IRequest<bool>
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public IEnumerable<ExperienceViewModel> CandidateExperiences { get; set; }

    }

    public class ExperienceViewModel
    {
        public int CandidateExperienceId { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
