using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.BookOperations.Update.Commands;

namespace WebApi.UnitTests.Operations.BookOperations.Update
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIsNotFound_AppException_ShouldBeReturn()
        {
            var itemId = 0;

            UpdateBookCommand command = new UpdateBookCommand(_context, _mapper, itemId, null);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Book not found");
        }
    }
}
