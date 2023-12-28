using System;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.BookOperations.Queries;

namespace WebApi.UnitTests.Operations.BookOperations.Queries
{
    public class QueryGetBookByIdTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public QueryGetBookByIdTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIdIsWrongGiven_AppException_ShouldBeReturn()
        {
            var itemId = -1;

            QueryGetBookById query = new QueryGetBookById(_context, _mapper, itemId);
            FluentActions
                .Invoking(() => query.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Book not found");
        }
    }
}
