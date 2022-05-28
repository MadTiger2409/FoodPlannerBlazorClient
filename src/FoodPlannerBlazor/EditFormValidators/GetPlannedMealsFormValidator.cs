using FluentValidation;
using FoodPlannerBlazor.EditFormModels;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class GetPlannedMealsFormValidator : AbstractValidator<GetPlannedMealsFormModel>
    {
        public GetPlannedMealsFormValidator()
        {
            RuleFor(x => x)
                .Must(x => (x.To.Date - x.From.Date).TotalDays >= 0)
                .WithMessage("End date can't be lower than start date");

            RuleFor(x => x)
                .Must(x => (x.To.Date - x.From.Date).TotalDays <= 31)
                .WithMessage("Date range can't be bigger than 31 days");
        }
    }
}