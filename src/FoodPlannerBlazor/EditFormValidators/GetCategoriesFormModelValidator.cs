using FluentValidation;
using FoodPlannerBlazor.EditFormModels;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class GetCategoriesFormModelValidator : AbstractValidator<GetCategoriesFormModel>
    {
        public GetCategoriesFormModelValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100);
        }
    }
}