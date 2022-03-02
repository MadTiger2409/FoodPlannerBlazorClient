using FluentValidation;
using FoodPlannerBlazor.EditFormModels;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class CreateCategoryFormModelValidator : AbstractValidator<CreateCategoryFormModel>
    {
        public CreateCategoryFormModelValidator()
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