using FluentValidation;
namespace ERP.Application.ManufacturingOrders.Commands.CancelMO
{
    public class CancelMOCommandValidator : AbstractValidator<CancelMOCommand>
    {
        public CancelMOCommandValidator()
        {
            RuleFor(x => x.ManufacturingOrderId)
                .NotEmpty();
        }
    }
}