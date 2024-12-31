using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodManagementSystem.Application.Features.Auth.Command.AdminRegister
{
    public class AdminRegisterCommandValidator:AbstractValidator<AdminRegisterCommandRequest>
    {
        public AdminRegisterCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(60).MinimumLength(8).EmailAddress().WithName("Email");
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50).MinimumLength(6).WithName("Şifre");
            RuleFor(x => x.ConfirmPassword).NotEmpty().MaximumLength(50).MinimumLength(6).Equal(x => x.Password).WithName("Şifre Tekrarı");
        }
    }
}
