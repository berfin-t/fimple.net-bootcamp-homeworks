using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.Operations.BookOperations.Create.Commands;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Create
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        readonly BookStoreDbContext _context;
        readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_AppException_ShouldBeReturn()
        {
            var book = new Book()
            {
                Title = "Deneme21",
                PageCount = 500,
                PublishDate = new DateTime(1999, 12, 12),
                GenreId = 1,
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookModel model = new CreateBookModel() { Title = book.Title };

            CreateBookCommand command = new CreateBookCommand(_context, _mapper, model);

            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<AppException>()
                .And.Message.Should()
                .Be("Book already added");
        }
    }
}
