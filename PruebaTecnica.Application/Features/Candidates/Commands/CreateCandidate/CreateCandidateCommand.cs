using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommand : IRequest<int>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

        public IEnumerable<ExperienceViewModel> CandidateExperiences { get; set; }
    }
    public class ExperienceViewModel
    {
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
