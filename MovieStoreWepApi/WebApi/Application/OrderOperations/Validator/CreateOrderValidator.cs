using FluentValidation;
using WebApi.Application.OrderOperations.Commands.CreateOrder;

namespace WebApi.Application.OrderOperations.Validator
{
    public class CreateOrderValidator : AbstractValidator<CreateOrder>
    {
        public CreateOrderValidator()
        {
            RuleFor(o => o.Model.MovieId).NotEmpty();
            RuleFor(o => o.Model.CustomerId).NotEmpty();
           
        }
    }
}
