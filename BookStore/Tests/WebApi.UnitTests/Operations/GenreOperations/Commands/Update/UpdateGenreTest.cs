using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.GenreOperations.Update.Commands;

namespace WebApi.UnitTests.Operations.GenreOperations.Update
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGenreIsNotFound_AppException_ShouldBeReturn()
        {
            var itemId = 0;

            UpdateGenreCommand command = new UpdateGenreCommand(_context, itemId, null);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Genre not found");
        }
    }
}
