using AutoMapper;
using Moq;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Application.Features.Candidates.Queries.GetCandidatesList;
using PruebaTecnica.Application.Mappings;
using PruebaTecnica.Application.UnitTests.Mocks;
using PruebaTecnica.Infrastructure.Repositories;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PruebaTecnica.Application.UnitTests.Features.Candidate.Queries
{
    public class GetCandidateQueryHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<CandidateRepository> candidateRepository;

        public GetCandidateQueryHandlerTests()
        {
            candidateRepository = MockCandidateRepository.GetCandidateRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCandidateListTest()
        {
            var handler = new GetCandidatesListQueryHandler(candidateRepository.Object, mapper);

            var result = await handler.Handle(new GetCandidatesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CandidatesVm>>();
        }
    }
}
