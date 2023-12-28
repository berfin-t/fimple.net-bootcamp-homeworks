using WebApi.Operations.BookOperations.Update.Commands;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Update
{
    public class AddAuthorToBookModelValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "", "")]
        [InlineData(0, "", " ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErros(
            int itemId,
            string firstName,
            string lastName
        )
        {
            AddAuthorToBookModel commandAuthor = new AddAuthorToBookModel()
            {
                Id = itemId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Now.AddYears(-20),
            };

            AddAuthorToBookModelValidator validator = new AddAuthorToBookModelValidator();
            var results = validator.Validate(commandAuthor);

            results.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            AddAuthorToBookModel commandAuthor = new AddAuthorToBookModel()
            {
                Id = 1,
                FirstName = "Deneme4",
                LastName = "Deneme5",
                DateOfBirth = DateTime.Now,
            };

            AddAuthorToBookModelValidator validator = new AddAuthorToBookModelValidator();
            var results = validator.Validate(commandAuthor);

            results.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
