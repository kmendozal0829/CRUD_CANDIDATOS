using MediatR;
using System.Collections.Generic;

namespace PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList
{
    public class GetCandidatesListQuery : IRequest<List<CandidatesVm>>
    {
        public GetCandidatesListQuery() { }
    }
}
