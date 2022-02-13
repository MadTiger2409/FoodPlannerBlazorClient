using System;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal
{
    public record PlannedMeal(int Id, byte OrdinalNumber, DateTime ScheduledFor, Meal.Meal Meal);
}