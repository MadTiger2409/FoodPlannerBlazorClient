using System;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing
{
    public class CreatePlannedMeal
    {
        public int? MealId { get; set; }
        public int OrdinalNumber { get; set; } = 1;
        public DateTime ScheduledFor { get; set; } = DateTime.Now.Date;
    }
}