using AutoMapper;
using PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate;
using PruebaTecnica.Application.Features.Candidates.Commands.EditCandidate;
using PruebaTecnica.Application.Features.Candidates.Queries.GetCandidate;
using PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList;
using PruebaTecnica.Domain;

namespace PruebaTecnica.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidatesVm>();
            CreateMap<Candidate, CandidateWithExperiencesVm>();
            CreateMap<CreateCandidateCommand, Candidate>().ForMember(dest => dest.CandidateExperiences, opt => opt.Ignore()); 
            CreateMap<EditCandidateCommand, Candidate>().ForMember(dest => dest.CandidateExperiences, opt => opt.Ignore()); 
        }
    }
}
