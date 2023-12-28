using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Update.Commands;

namespace WebApi.UnitTests.Operations.AuthorOperations.Update
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAuthorIsNotFound_AppException_ShouldBeReturn()
        {
            var itemId = 0;

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper, itemId, null);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Author not found");
        }
    }
}
