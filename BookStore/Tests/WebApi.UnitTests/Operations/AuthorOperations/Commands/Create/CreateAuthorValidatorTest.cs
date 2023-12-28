using WebApi.Operations.AuthorOperations.Create.Commands;

namespace WebApi.UnitTests.Operations.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("", " ")]
        [InlineData(" ", "")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErros(
            string firstName,
            string lastName
        )
        {
            // arrange
            var model = new CreateAuthorModel()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1999, 12, 12),
            };
            CreateAuthorCommand command = new CreateAuthorCommand(null, null, model);

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var results = validator.Validate(command);

            //assert
            results.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            var model = new CreateAuthorModel()
            {
                FirstName = "Deneme13",
                LastName = "Deneme14",
                DateOfBirth = DateTime.Now.Date
            };
            CreateAuthorCommand command = new CreateAuthorCommand(null, null, model);

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var results = validator.Validate(command);

            results.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
