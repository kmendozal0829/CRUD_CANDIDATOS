using MediatR;
using PruebaTecnica.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommandHandler: IRequestHandler<DeleteCandidateCommand, bool>
    {

        private readonly ICandidateRepository candidateRepository;

        public DeleteCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int id = request.Id;
                var entity = await candidateRepository.GetCandidateByIdAsync(id);
                await candidateRepository.DeleteAsync(entity);
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Se genero un error al eliminar entidad Candidate");
            }
            
        }
    }
}
