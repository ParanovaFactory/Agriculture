using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Title can not to be empty");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Title have to be contain minumum 3 characters");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail can not to be empty");
            RuleFor(x => x.Mail).MinimumLength(3).WithMessage("Mail have to be contain minumum 3 characters");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Message can not to be empty");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("Message have to be contain minumum 3 characters");

            RuleFor(x => x.Date).NotEmpty().WithMessage("Date can not to be empty");
        }
    }
}
