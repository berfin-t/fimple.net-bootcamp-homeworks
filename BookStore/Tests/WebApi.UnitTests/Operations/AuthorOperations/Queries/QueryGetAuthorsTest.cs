using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Queries;

namespace WebApi.UnitTests.Operations.AuthorOperations.Queries
{
    public class QueryGetAuthorsTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public QueryGetAuthorsTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenCalled_Authors_ShouldBeReturn()
        {
            var bookList = new List<Author>
            {
                new Author()
                {
                    FirstName = "Deneme17",
                    LastName = "Deneme18",
                    DateOfBirth = new DateTime(1999, 12, 12),
                },
                new Author()
                {
                    FirstName = "Deneme19",
                    LastName = "Deneme20",
                    DateOfBirth = new DateTime(1999, 12, 12),
                }
            };
            _context.Authors.AddRange(bookList);
            _context.SaveChanges();

            QueryGetAuthors query = new QueryGetAuthors(_context, _mapper);
            var results = FluentActions.Invoking(() => query.Handle()).Invoke();

            results.Should().NotBeNull();
            results.Count.Should().BeGreaterThanOrEqualTo(2); 
        }
    }
}
