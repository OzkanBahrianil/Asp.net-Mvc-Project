using EntityLayer.concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class AdressValidation:AbstractValidator<Address>
    {
        public AdressValidation()
        {
            RuleFor(x => x.AddressLine).NotEmpty().WithMessage("the address cannot be empty");
            RuleFor(x => x.City).NotEmpty().WithMessage("the city cannot be empty");
            RuleFor(x => x.CityCode).NotEmpty().WithMessage("the city code cannot be empty");
            RuleFor(x => x.Country).NotEmpty().WithMessage("the country cannot be empty");
        }
    }
}
