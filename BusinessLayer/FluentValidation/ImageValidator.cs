using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not to be empty");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Title have to be contain minumum 3 characters");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not to be empty");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image Url can not to be empty");
        }
    }
}
