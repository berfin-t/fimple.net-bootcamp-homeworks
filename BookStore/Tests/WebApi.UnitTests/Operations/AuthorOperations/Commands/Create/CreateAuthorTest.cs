using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Create.Commands;

namespace WebApi.UnitTests.Operations.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorIsGiven_AppException_ShouldBeReturn()
        {
            var author = new Author()
            {
                FirstName = "Deneme8",
                LastName = "Deneme9",
                DateOfBirth = new DateTime(1999, 12, 12),
            };
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorModel model = new CreateAuthorModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper, model);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Author already added");
        }
    }
}
