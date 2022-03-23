using FluentValidation;
using FoodPlannerBlazor.EditFormModels;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class GetMealsFormModelValidator : AbstractValidator<GetMealsFormModel>
    {
        public GetMealsFormModelValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(300);
        }
    }
}