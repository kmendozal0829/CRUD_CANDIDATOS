using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using PruebaTecnica.Domain;
using PruebaTecnica.Infrastructure.Persistence;
using PruebaTecnica.Infrastructure.Repositories;
using System;
using System.Linq;

namespace PruebaTecnica.Application.UnitTests.Mocks
{
    public static class MockCandidateRepository
    {
        public static Mock<CandidateRepository> GetCandidateRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var candidates = fixture.CreateMany<Candidate>().ToList();

            candidates.Add(fixture.Build<Candidate>()
                .With(c => c.Email, "kmendoza0829@gmail.com")
                .Create());

            var options = new DbContextOptionsBuilder<CandidateDbContext>()
                .UseInMemoryDatabase(databaseName: $"PruebaTecnica-{Guid.NewGuid()}")
                .Options;

            var candidateDbContextFake = new CandidateDbContext(options);
            candidateDbContextFake.Database.EnsureDeleted();
            candidateDbContextFake.Candidates.AddRange(candidates);
            candidateDbContextFake.SaveChanges();


            var mockRepository = new Mock<CandidateRepository>(candidateDbContextFake);
            return mockRepository;
        }

        public static void AddCandidateRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var candidates = fixture.CreateMany<Candidate>().ToList();

            candidates.Add(fixture.Build<Candidate>()
                .With(c => c.Email, "kmendoza0829@gmail.com")
                .Without(c => c.CandidateExperiences)
                .Create());

            var options = new DbContextOptionsBuilder<CandidateDbContext>()
                .UseInMemoryDatabase(databaseName: $"PruebaTecnica-{Guid.NewGuid()}")
                .Options;

            var candidateDbContextFake = new CandidateDbContext(options);
            candidateDbContextFake.Database.EnsureDeleted();
            candidateDbContextFake.Candidates.AddRange(candidates);
            candidateDbContextFake.SaveChanges();


            var mockRepository = new Mock<CandidateRepository>(candidateDbContextFake);
        }


    }
}
