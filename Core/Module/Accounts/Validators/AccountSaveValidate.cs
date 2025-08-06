using Core.Module.Accounts.Dtos;
using FluentValidation;

namespace Core.Module.Accounts.Validators
{
    public class AccountSaveValidate : AbstractValidator<AccountSaveDto>
    {
        public AccountSaveValidate()
        {
            RuleFor(x => x.NumberAccount)
                                     .NotEmpty()
                                     .WithMessage("Debe ingresar un numero de cuenta")
                                     .MaximumLength(12)
                                     .WithMessage("El numero de cuenta no debe exceder los 12 caracteres");
            RuleFor(x => x.AccountType)
                                    .NotEmpty()
                                    .WithMessage("Debe ingresar el tipo de cuenta")
                                    .IsInEnum()
                                    .WithMessage("El tipo de cuenta no es valido");
            RuleFor(x => x.InitialBalance)
                                    .NotEmpty()
                                    .WithMessage("Debe ingresar un saldo inicial para la cuenta")
                                    .GreaterThanOrEqualTo(0)
                                    .WithMessage("El saldo inicial debe ser mayor o igual a cero");
            RuleFor(x => x.IdentityDocument)
                                    .NotEmpty()
                                    .WithMessage("Debe ingresar el documento de identidad del cliente")
                                    .MaximumLength(12)
                                    .WithMessage("El documento de identidad no debe exceder los 12 caracteres");


        }
    }
}
