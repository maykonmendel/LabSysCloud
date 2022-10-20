using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LabSysCloud.Domain.Entities;

namespace LabSysCloud.Service.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator()
        {
            RuleFor(paciente => paciente.Nome)
                .NotEmpty().WithMessage("O nome do paciente é obrigatório.")
                .When(paciente => String.IsNullOrEmpty(paciente.Nome));

            RuleFor(paciente => paciente.CPF)
                .NotEmpty().WithMessage("O CPF do paciente é obrigatório.")
                .When(paciente => String.IsNullOrEmpty(paciente.CPF));

            RuleFor(paciente => paciente.RG)
                .NotEmpty().WithMessage("O RG do paciente é obrigatório.")
                .When(paciente => String.IsNullOrEmpty(paciente.RG));

            RuleFor(paciente => paciente.CNS)
                .NotEmpty().WithMessage("O Cartão Nacional de Saúde do paciente é obrigatório.")
                .When(paciente => String.IsNullOrEmpty(paciente.CNS));
        }             
    }
}