using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person name and surname can not to be empty");
            RuleFor(x => x.PersonName).MinimumLength(7).WithMessage("Person name and surname have to be contain minumum 7 characters");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Person title can not to be empty");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Person title have to be contain minumum 3 characters");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image Url title can not to be empty");
            RuleFor(x => x.FacebookUrl).NotEmpty().WithMessage("Facebook Url title can not to be empty");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Instagram Url title can not to be empty");
            RuleFor(x => x.WebsiteUrl).NotEmpty().WithMessage("Website Url title can not to be empty");
            RuleFor(x => x.TwitterkUrl).NotEmpty().WithMessage("Twitter Url title can not to be empty");
        }
    }
}
