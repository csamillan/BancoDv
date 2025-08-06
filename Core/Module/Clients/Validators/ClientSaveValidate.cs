using Core.Module.Clients.Dtos;
using FluentValidation;

namespace Core.Module.Clients.Validators
{
    public class ClientSaveValidate : AbstractValidator<ClientSaveDto>
    {
        public ClientSaveValidate() 
        {
            RuleFor(x => x.Name)
                            .NotEmpty()
                            .WithMessage("Debe Ingresar un nombre")
                            .MaximumLength(100)
                            .WithMessage("Solo puede ingresar maximo 100 caracteres");

            RuleFor(x => x.Address)
                            .NotEmpty()
                            .WithMessage("Debe Ingresar una direccion")
                            .MaximumLength(100)
                            .WithMessage("Solo puede ingresar maximo 150 caracteres");

            RuleFor(x => x.Phone)
                            .NotEmpty()
                            .WithMessage("Debe Ingresar un numero de telefono")
                            .MinimumLength(9)
                            .WithMessage("Debe ingresar minimo 9 digitos")
                            .MaximumLength(15)
                            .WithMessage("Solo puede ingresar maximo 15 digitos");

            RuleFor(x => x.IdentityDocument)
                            .NotEmpty()
                            .WithMessage("Debe Ingresar su documento de identidad")
                            .MaximumLength(15)
                            .WithMessage("Solo puede ingresar maximo 12 digitos");

            RuleFor(x => x.Age)
                            .NotEmpty()
                            .WithMessage("Debe Ingresar su edad")
                            .GreaterThan(18)
                            .WithMessage("Debes ser mayor de edad")
                            .LessThan(120)
                            .WithMessage("No debe ser mayor a 120 años");

            RuleFor(x => x.Gender)
                            .NotEmpty()
                            .WithMessage("Debe ingresar un genero")
                            .IsInEnum()
                            .WithMessage("El genero no es valido");

            RuleFor(x => x.Password)
                            .NotEmpty()
                            .WithMessage("Debe ingresar una contraseña")
                            .MaximumLength(25)
                            .WithMessage("Solo puede ingresar maximo 25 caracteres");
        }
    }
}
