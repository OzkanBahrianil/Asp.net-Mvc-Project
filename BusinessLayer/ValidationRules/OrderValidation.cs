using EntityLayer.concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public class OrderValidation:AbstractValidator<Order>
    {

        public OrderValidation()
        {

            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Please enter number of jobs");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Please enter Offered Modey");
          
        }
    }
}
