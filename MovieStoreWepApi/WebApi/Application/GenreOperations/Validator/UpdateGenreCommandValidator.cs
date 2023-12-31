﻿using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Application.GenreOperations.Validator
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenre>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(g => g.Model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
