using FluentValidation;
using FoodPlannerBlazor.Domain.Entities.Category.Outgoing;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategory>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name can't be empty");

            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters long");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name can be up to 100 characters long");
        }
    }
}