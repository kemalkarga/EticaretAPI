using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Product
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Boş Geçilemez");
        }
    }
}
