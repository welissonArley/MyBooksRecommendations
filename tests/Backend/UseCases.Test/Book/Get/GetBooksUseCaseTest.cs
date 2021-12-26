using FluentAssertions;
using MyBooksRecommendations.Application.UseCases.Book.Get;
using System.Collections.Generic;
using Useful.ToTests.Builders.Entities;
using Useful.ToTests.Builders.Mapper;
using Useful.ToTests.Builders.Repositories;
using Xunit;

namespace UseCases.Test.Book.Get
{
    public class GetBooksUseCaseTest
    {
        [Fact]
        public void Validade_Sucess()
        {
            var booksList = new List<MyBooksRecommendations.Domain.Entity.Book>
            {
                EntityBookBuilder.Instance().Build(),
                EntityBookBuilder.Instance().Build(),
                EntityBookBuilder.Instance().Build(),
                EntityBookBuilder.Instance().Build()
            };

            var mapper = MapperBuilder.Build();
            var repository = BookReadOnlyRepositoryBuilder.Instance().GetAllBooks(booksList).Build();

            var useCase = new GetBookUseCase(mapper, repository);

            var response = useCase.Execute();

            response.Should().HaveCount(booksList.Count);
        }
    }
}
