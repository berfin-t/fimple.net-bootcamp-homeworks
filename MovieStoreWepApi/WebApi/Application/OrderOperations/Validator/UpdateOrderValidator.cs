﻿using FluentValidation;
using WebApi.Application.OrderOperations.Commands.UpdateOrder;

namespace WebApi.Application.OrderOperations.Validator
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrder>
    {
        public UpdateOrderValidator()
        {

        }
    }
}
