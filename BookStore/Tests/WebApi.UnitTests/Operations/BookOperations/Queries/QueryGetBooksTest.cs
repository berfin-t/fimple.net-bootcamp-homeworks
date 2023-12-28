using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.BookOperations.Queries;

namespace WebApi.UnitTests.Operations.BookOperations.Queries
{
    public class QueryGetBooksTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public QueryGetBooksTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenCalled_Books_ShouldBeReturn()
        {
            var bookList = new List<Book>
            {
                new Book()
                {
                    Title = "Deneme25",
                    PageCount = 344,
                    PublishDate = new DateTime(1999, 12, 12),
                    GenreId = 2,
                },
                new Book()
                {
                    Title = "Deneme26",
                    PageCount = 345,
                    PublishDate = new DateTime(1999, 12, 12),
                    GenreId = 1,
                }
            };
            _context.Books.AddRange(bookList);
            _context.SaveChanges();

            QueryGetBooks query = new QueryGetBooks(_context, _mapper);
            var results = FluentActions.Invoking(() => query.Handle()).Invoke();

            results.Should().NotBeNull();
            results.Count.Should().BeGreaterThanOrEqualTo(2); 
    }
}
