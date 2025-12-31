using System.Data;
using FluentValidation;

namespace ERP.Application.ManufacturingOrders.Commands.UpdateMO
{
    public class UpdateMOCommandValidator : AbstractValidator<UpdateMOCommand>
    {
        public UpdateMOCommandValidator()
        {
            RuleFor(x => x.ManufacturingOrderId)
                .NotEmpty();

            RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.RoutingId)
                .NotEmpty();

            RuleFor(x => x.QuantityToProduce)
                .GreaterThan(0);

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate);

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate);

            RuleFor(x => x.WorkOrders)
                           .NotNull()
                           .NotEmpty();
            RuleForEach(x => x.WorkOrders).SetValidator(new WorkOrderCommandValidator());

        }
    }
    public class WorkOrderCommandValidator : AbstractValidator<WorkOrdersCommand>
    {
        public WorkOrderCommandValidator()
        {
            RuleFor(x => x.WorkCenterId)
                .NotEmpty();

            RuleFor(x => x.RoutingStepId)
                .NotEmpty();
        }
    }


}