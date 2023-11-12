using MediatR;

namespace PruebaTecnica.Application.Features.Candidates.Queries.GetCandidate
{
    public class GetCandidateQuery : IRequest<CandidateWithExperiencesVm>
    {
        public int Id { get; set; }

        public GetCandidateQuery(int id)
        {
            Id = id;
        }
    }
}
