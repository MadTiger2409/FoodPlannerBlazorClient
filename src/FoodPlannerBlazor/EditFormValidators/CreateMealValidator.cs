using FluentValidation;
using FoodPlannerBlazor.Domain.Entities.Meal.Outgoing;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class CreateMealValidator : AbstractValidator<CreateMeal>
    {
        public CreateMealValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name can't be empty");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Name must be at least 3 characters long");

            RuleFor(x => x.Name)
                .MaximumLength(300)
                .WithMessage("Name can be up to 300 characters long");

            RuleFor(x => x.Ingredients)
                .SetValidator(new CreateIngredientsValidator());
        }
    }
}
