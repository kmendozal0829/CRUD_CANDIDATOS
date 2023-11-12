using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate;
using PruebaTecnica.Application.Mappings;
using PruebaTecnica.Application.UnitTests.Mocks;
using PruebaTecnica.Infrastructure.Repositories;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PruebaTecnica.Application.UnitTests.Features.Candidate.Commands.CreateCandidate
{
    public class CreateCandidateCommandHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<CandidateRepository> candidateRepository;
        private readonly Mock<ILogger<CreateCandidateCommandHandler>> logger;

        public CreateCandidateCommandHandlerTests()
        {
            candidateRepository = MockCandidateRepository.GetCandidateRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            mapper = mapperConfig.CreateMapper();
            logger = new Mock<ILogger<CreateCandidateCommandHandler>>();

            MockCandidateRepository.AddCandidateRepository();
        }

        [Fact]
        public async Task CreateCandidateCommand_InputCandidate_ReturnsNumber()
        {
            var candidateInput = new CreateCandidateCommand
            {
                Name = "Kevin",
                Birthdate = DateTime.Now,
                Email = "kmendoza0829@gmail.com",
                Surname = "Mendoza"                
            };

            var handler = new CreateCandidateCommandHandler(candidateRepository.Object, mapper, logger.Object);
            var result = await handler.Handle(candidateInput, CancellationToken.None);
            result.ShouldBeOfType<int>();
        }
    }
}
