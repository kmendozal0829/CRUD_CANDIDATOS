using FluentValidation;
using System;

namespace PruebaTecnica.Application.Features.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {

        public CreateCandidateCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(50).WithMessage("El nombre no debe exceder los 50 caracteres.");


            RuleFor(p => p.Surname)
            .MaximumLength(150).WithMessage("El apellido no debe exceder los 150 caracteres.");

            RuleFor(p => p.Birthdate)
            .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .MaximumLength(250).WithMessage("El correo electrónico no debe exceder los 250 caracteres.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.");

            RuleFor(p => p.Birthdate)
            .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.");
            


        }        
    }
}
