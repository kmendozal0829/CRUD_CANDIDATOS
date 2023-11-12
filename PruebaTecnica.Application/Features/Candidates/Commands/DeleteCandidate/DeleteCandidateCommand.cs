using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Application.Features.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCandidateCommand(int id)
        {
            Id = id;
        }
    }
}
