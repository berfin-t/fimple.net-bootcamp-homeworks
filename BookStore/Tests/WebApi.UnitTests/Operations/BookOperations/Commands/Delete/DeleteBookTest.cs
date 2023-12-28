using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.BookOperations.Delete.Commands;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Delete
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenBookNotFoundInDatabase_AppException_ShouldBeReturn()
        {
            var bookId = 0;

            DeleteBookCommand command = new DeleteBookCommand(_context, bookId);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Book not found");
        }
    }
}
