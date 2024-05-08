using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog title can't be empty");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog content can't be empty");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog image can't be empty");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog title can't exceed 150 characters");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog title can't be less than 5 characters");
        }
    }
}
