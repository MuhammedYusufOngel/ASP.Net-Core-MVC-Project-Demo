using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name does not exist");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category description does not exist");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Category name can only be less than 20 characters");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Category name can only be more than 2 characters");
            RuleFor(x => x.CategoryDescription).MaximumLength(150).WithMessage("Category description can only be less than 150 characters");
        }
    }
}
