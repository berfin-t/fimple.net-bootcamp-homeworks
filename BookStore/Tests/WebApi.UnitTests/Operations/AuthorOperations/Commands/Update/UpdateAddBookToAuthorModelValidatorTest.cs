using WebApi.Operations.AuthorOperations.Update.Commands;
using WebApi.Operations.BookOperations.Update.Commands;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Update
{
    public class AddBookToAuthorModelValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "", 0, 0)]
        [InlineData(0, " ", 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErros(
            int itemId,
            string title,
            int genreId,
            int pageCount
        )
        {
            AddBookToAuthorModel commandBook = new AddBookToAuthorModel()
            {
                Id = itemId,
                Title = title,
                GenreId = genreId,
                PageCount = pageCount,
                PublishDate = DateTime.Now.AddYears(-20),
            };

            AddBookToAuthorModelValidator validator = new AddBookToAuthorModelValidator();
            var results = validator.Validate(commandBook);

            results.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            AddBookToAuthorModel commandBook = new AddBookToAuthorModel()
            {
                Id = 1,
                Title = "Deneme15",
                GenreId = 1,
                PageCount = 674,
                PublishDate = DateTime.Now.Date,
            };

            AddBookToAuthorModelValidator validator = new AddBookToAuthorModelValidator();
            var results = validator.Validate(commandBook);

            results.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
