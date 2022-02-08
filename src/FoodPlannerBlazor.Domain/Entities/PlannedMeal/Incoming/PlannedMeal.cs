using System;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal.Incoming
{
    public record PlannedMeal(int Id, byte OrdinalNumber, DateTime ScheduledFor, Meal.Incoming.Meal Meal);
}