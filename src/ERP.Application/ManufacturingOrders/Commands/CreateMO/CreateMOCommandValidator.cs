using FluentValidation;

namespace ERP.Application.ManufacturingOrders.Commands.CreateMO
{
    public class CreateMOCommandValidator : AbstractValidator<CreateMOCommand>
    {
        public CreateMOCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.RoutingId)
                .NotEmpty();

            RuleFor(x => x.QuantityToProduce)
                .GreaterThan(0);

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate);

            RuleFor(x => x.WorkOrders)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.WorkOrders)
                .SetValidator(new WorkOrderValidator());
        }
    }

    public class WorkOrderValidator : AbstractValidator<WorkOrderCommand>
    {
        public WorkOrderValidator()
        {
            RuleFor(x => x.ManufacturingOrderId)
                .NotEmpty();

            RuleFor(x => x.WorkCenterId)
                .NotEmpty();

            RuleFor(x => x.RoutingStepId)
                .NotEmpty();
        }
    }
}