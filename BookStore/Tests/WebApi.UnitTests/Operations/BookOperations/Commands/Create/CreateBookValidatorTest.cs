using WebApi.Operations.BookOperations.Create.Commands;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Create
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Deneme1", 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErros(
            string title,
            int pageCount,
            int genreId
        )
        {
            // arrange
            var model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-4),
                GenreId = genreId
            };
            CreateBookCommand command = new CreateBookCommand(null, null, model);

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            var model = new CreateBookModel()
            {
                Title = "Deneme2",
                PageCount = 564,
                PublishDate = DateTime.Now.Date,
                GenreId = 2
            };
            CreateBookCommand command = new CreateBookCommand(null, null, model);

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var results = validator.Validate(command);

            results.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
