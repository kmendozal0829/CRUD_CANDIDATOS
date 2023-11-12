using PruebaTecnica.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Application.Features.Candidates.Queries.GetCandidate
{
    public class CandidateWithExperiencesVm
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

        public ICollection<CandidateExperience> CandidateExperiences { get; set; }

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
