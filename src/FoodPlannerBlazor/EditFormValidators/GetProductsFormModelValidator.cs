using FluentValidation;
using FoodPlannerBlazor.EditFormModels;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class GetProductsFormModelValidator : AbstractValidator<GetProductsFormModel>
    {
        public GetProductsFormModelValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100);
        }
    }
}