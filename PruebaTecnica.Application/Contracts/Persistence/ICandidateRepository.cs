using PruebaTecnica.Domain;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Contracts.Persistence
{
    public interface ICandidateRepository : IAsyncRepository<Candidate>
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);
        Task<Candidate> GetCandidateByIdAsync(int id);
    }
}
