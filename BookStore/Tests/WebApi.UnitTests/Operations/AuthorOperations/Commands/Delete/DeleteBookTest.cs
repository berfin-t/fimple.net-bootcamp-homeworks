using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Delete.Commands;

namespace WebApi.UnitTests.Operations.AuthorOperations.Commands.Delete
{
    public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;

        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAuthorNotFoundInDatabase_AppException_ShouldBeReturn()
        {
            var bookId = 0;

            DeleteAuthorCommand command = new DeleteAuthorCommand(_context, bookId);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Author not found");
        }
    }
}
