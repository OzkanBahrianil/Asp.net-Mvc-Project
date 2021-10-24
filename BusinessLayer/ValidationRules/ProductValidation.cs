using EntityLayer.concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Please enter ImageUrl");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter Name");
        }
    }
}
