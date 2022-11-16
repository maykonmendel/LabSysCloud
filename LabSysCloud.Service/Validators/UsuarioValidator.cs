using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(usuario => usuario.NomeUsuario)
               .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
               .When(usuario => String.IsNullOrEmpty(usuario.NomeUsuario));

            RuleFor(usuario => usuario.Senha)
                .NotEmpty().WithMessage("A senha de usuário é obrigatória.")
                .When(usuario => String.IsNullOrEmpty(usuario.Senha))
                .MinimumLength(8)
                .MaximumLength(12)
                .Matches("^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$");

            RuleFor(usuario => usuario.Role)
               .NotEmpty().WithMessage("A role é obrigatório.")
               .When(usuario => String.IsNullOrEmpty(usuario.Role));
        }
    }
}