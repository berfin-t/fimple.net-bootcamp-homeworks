using WebApi.Operations.AuthorOperations.Update.Commands;

namespace WebApi.UnitTests.Operations.AuthorOperations.Commands.Update
{
    public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
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
            UpdateAuthorModel model = new UpdateAuthorModel()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1999, 12, 12)
            };

            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null, itemId, model);

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var results = validator.Validate(command);

            results.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            var itemId = 0;
            UpdateAuthorModel model = new UpdateAuthorModel()
            {
                FirstName = "Deneme16",
                LastName = "Deneme17",
                DateOfBirth = DateTime.Now
            };

            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null, itemId, model);

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var results = validator.Validate(command);

            results.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
