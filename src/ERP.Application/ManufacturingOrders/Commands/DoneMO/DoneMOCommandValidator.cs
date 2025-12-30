using FluentValidation;
namespace ERP.Application.ManufacturingOrders.Commands.DoneMO
{
    public class DoneMOCommandValidator : AbstractValidator<DoneMOCommand>
    {
        public DoneMOCommandValidator()
        {
            RuleFor(x => x.ManufacturingOrderId)
                .NotEmpty();
        }
    }
}