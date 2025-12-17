using FluentValidation;

namespace ERP.Application.Products.Commands.CreateBOM
{
    public class CreateBOMCommandValidator : AbstractValidator<CreateBOMCommand>
    {
        public CreateBOMCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();

            RuleFor(x => x.Version)
                       .GreaterThan((byte)0);

            RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty();

            RuleForEach(x => x.Items)
                .SetValidator(new CreateBOMItemValidator());
        }

    }

    public class CreateBOMItemValidator : AbstractValidator<CreateBOMItem>
    {
        public CreateBOMItemValidator()
        {
            RuleFor(x => x.MaterialId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThan(0);

            RuleFor(x => x.UnitOfMeasureId)
                .NotEmpty();

            RuleFor(x => x.ApplyToAttributeValueIds)
                .NotNull();
        }
    }
}