using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Application.GenreOperations.Validator
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenre>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(g => g.Model.Name).NotEmpty().MinimumLength(2);

        }
    }
}
