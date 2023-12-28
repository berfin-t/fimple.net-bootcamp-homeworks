using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.GenreOperations.Delete.Commands;

namespace WebApi.UnitTests.Operations.GenreOperations.Commands.Delete
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGenreNotFoundInDatabase_AppException_ShouldBeReturn()
        {
            var genreId = 0;

            DeleteGenreCommand command = new DeleteGenreCommand(_context, genreId);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Genre not found");
        }
    }
}
