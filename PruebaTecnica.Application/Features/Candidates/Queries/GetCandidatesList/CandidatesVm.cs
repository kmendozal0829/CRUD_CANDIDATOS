using System;

namespace PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList
{
    public class CandidatesVm
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
    }
}
