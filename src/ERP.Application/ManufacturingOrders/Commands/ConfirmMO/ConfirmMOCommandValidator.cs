using FluentValidation;
namespace ERP.Application.ManufacturingOrders.Commands.ConfirmMO
{
    public class ConfirmMOCommandValidator : AbstractValidator<ConfirmMOCommand>
    {
        public ConfirmMOCommandValidator()
        {
            RuleFor(x => x.ManufacturingOrderId)
                .NotEmpty();
        }
    }
}