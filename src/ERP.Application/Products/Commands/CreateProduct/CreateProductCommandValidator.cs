using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(255);

            RuleFor(x=>x.Code).NotEmpty().MaximumLength(100);

            RuleFor(x=>x.Description).NotEmpty().MaximumLength(2000);

            RuleFor(x => x.Images)
            .NotEmpty();
            RuleForEach(x => x.Images)
            .NotEmpty();

            RuleFor(x=>x.CategoryIds).NotEmpty();
        }
    }
}
