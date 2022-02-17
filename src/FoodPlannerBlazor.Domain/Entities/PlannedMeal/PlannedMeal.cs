using FoodPlannerBlazor.Domain.Entities.Common;
using System;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal
{
    public class PlannedMeal : BaseEntity
    {
        public byte OrdinalNumber { get; set; }
        public DateTime ScheduledFor { get; set; }
        public Meal.Meal Meal { get; set; } = new();
    }
}