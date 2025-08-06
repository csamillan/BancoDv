using Core.Module.Transaction.Dtos;
using FluentValidation;

namespace Core.Module.Transaction.Validators
{
    public class TransactionValidators : AbstractValidator<TransactionSaveDto>
    {
        public TransactionValidators() 
        { 
            RuleFor(x => x.Date)
                            .NotEmpty()
                            .WithMessage("La fecha no debe ser especificada en una transacción de tipo depósito o retiro.");
            RuleFor(x => x.TypeMovement)
                            .NotEmpty()
                            .WithMessage("El tipo de movimiento es obligatorio.")
                            .IsInEnum()
                            .WithMessage("El tipo de movimiento no es válido.");
            RuleFor(x => x.Value)
                            .NotEmpty()
                            .WithMessage("El valor es obligatorio.")
                            .GreaterThanOrEqualTo(0)
                            .WithMessage("El saldo inicial debe ser mayor o igual a cero"); ;   
        }
    }
}
