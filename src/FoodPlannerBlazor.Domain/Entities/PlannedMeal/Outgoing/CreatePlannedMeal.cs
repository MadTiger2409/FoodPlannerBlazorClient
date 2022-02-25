using System;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing
{
    public record CreatePlannedMeal(int OrdinalNumber, DateTime ScheduledFor, int MealId);
}