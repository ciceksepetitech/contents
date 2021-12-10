﻿using FluentValidation;
using User.Api.Models.Request;

namespace User.Api.Validators
{
    public class PostUserRequestValidator: AbstractValidator<PostUserRequest>
    {
        public PostUserRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.Age).LessThan(100);
            RuleFor(x => x.Age).GreaterThan(0);

        }
    }
}
