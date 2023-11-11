using AutoMapper;
using PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate;
using PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList;
using PruebaTecnica.Domain;

namespace PruebaTecnica.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidatesVm>();
            CreateMap<CreateCandidateCommand, Candidate>();
        }
    }
}
