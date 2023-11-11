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


    }
}
