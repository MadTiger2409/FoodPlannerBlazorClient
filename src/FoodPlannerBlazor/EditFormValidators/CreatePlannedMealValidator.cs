using FluentValidation;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing;
using System;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class CreatePlannedMealValidator : AbstractValidator<CreatePlannedMeal>
    {
        public CreatePlannedMealValidator()
        {
            RuleFor(x => x.MealId)
                .NotNull()
                .WithMessage("The meal must be selected");

            RuleFor(x => x.MealId)
                .GreaterThan(0)
                .WithMessage("The meal must be selected");

            RuleFor(x => x.OrdinalNumber)
                .GreaterThan(0)
                .WithMessage("Ordinal number must be greater than 0");

            RuleFor(x => x.OrdinalNumber)
                .LessThanOrEqualTo(255)
                .WithMessage("Ordinal number must be less than 256");

            RuleFor(x => x.ScheduledFor.Date)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Scheduled date can't be older than today");
        }
    }
}