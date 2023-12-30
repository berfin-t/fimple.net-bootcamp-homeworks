using FluentValidation;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;

namespace WebApi.Application.DirectorOperations.Validator
{
    public class UpdateDirectorValidator : AbstractValidator<CreateDirector>
    {
        public UpdateDirectorValidator()
        {
            RuleFor(d => d.Model.Name).NotEmpty();
            RuleFor(d => d.Model.LastName).NotEmpty();
            RuleFor(d => d.Model.FilmsDirected).NotEmpty();
        }
    }
}
