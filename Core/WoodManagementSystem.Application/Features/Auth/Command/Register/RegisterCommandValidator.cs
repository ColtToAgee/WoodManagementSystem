﻿using FluentValidation;

namespace WoodManagementSystem.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(50).MinimumLength(2).WithName("İsim Soyisim");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(60).MinimumLength(8).EmailAddress().WithName("Email");
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50).MinimumLength(6).WithName("Şifre");
            RuleFor(x => x.ConfirmPassword).NotEmpty().MaximumLength(50).MinimumLength(6).Equal(x => x.Password).WithName("Şifre Tekrarı");
        }
    }
}
