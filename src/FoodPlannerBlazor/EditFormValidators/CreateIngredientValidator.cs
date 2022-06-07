using FluentValidation;
using FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class CreateIngredientValidator : AbstractValidator<CreateIngredient>
    {
        public CreateIngredientValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .WithMessage("The product must be selected");

            RuleFor(x => x.UnitId)
                .NotNull()
                .WithMessage("The unit must be selected");

            RuleFor(x => x.Amount)
                .GreaterThan(0.0f)
                .WithMessage("Amount must be greater than 0");
        }
    }
}
