using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ERP.Application.ProductVariants.Commands.CreateProductVariant
{
    public class CreateProductVariantValidator : AbstractValidator<CreateProductVariantCommand>
    {
        public CreateProductVariantValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();

            RuleFor(x => x.SKU).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Name).NotEmpty().MaximumLength(255);

            RuleFor(x => x.Images).NotNull();
            RuleForEach(x => x.Images).NotEmpty();

            RuleFor(x => x.PriceReference).NotNull().GreaterThanOrEqualTo(0);

            RuleFor(x => x.CostPrice).NotNull().GreaterThanOrEqualTo(0);

            RuleFor(x => x.Weight).NotNull().GreaterThan(0);

            RuleFor(x => x.Length).NotNull().GreaterThan(0);

            RuleFor(x => x.Width).NotNull().GreaterThan(0);

            RuleFor(x => x.Height).NotNull().GreaterThan(0);

            RuleFor(x => x.Volume).NotNull().GreaterThan(0);
        }
    }
}