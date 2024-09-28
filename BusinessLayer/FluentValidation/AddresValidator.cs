using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AddresValidator : AbstractValidator<Address>
    {
        public AddresValidator() 
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("City can not to be empty");
            RuleFor(x => x.Description1).MinimumLength(3).WithMessage("City have to be contain minumum 3 characters");

            RuleFor(x => x.Description2).NotEmpty().WithMessage("State can not to be empty");
            RuleFor(x => x.Description2).MinimumLength(3).WithMessage("State have to be contain minumum 3 characters");

            RuleFor(x => x.Description3).NotEmpty().WithMessage("Address Details can not to be empty");
            RuleFor(x => x.Description3).MinimumLength(3).WithMessage("Address Details have to be contain minumum 3 characters");
        }
    }
}
