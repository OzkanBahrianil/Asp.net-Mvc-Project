using EntityLayer.concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public class CustomerValidation: AbstractValidator<Customer>
    {
        public CustomerValidation()
        {

            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter your e - mail address correctly.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter your Name");
        }
    }
}
