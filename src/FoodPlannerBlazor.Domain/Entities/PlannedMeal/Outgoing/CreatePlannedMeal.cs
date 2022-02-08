using System;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing
{
    public record CreatePlannedMeal(byte OrdinalNumber, DateTime ScheduledFor, int MealId);
}