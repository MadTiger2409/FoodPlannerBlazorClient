using System;

namespace FoodPlannerBlazor.EditFormModels
{
    public class CreatePlannedMealFormModel
    {
        public int? MealId { get; set; }
        public int OrdinalNumber { get; set; } = 1;
        public DateTime ScheduledFor { get; set; } = DateTime.Now.Date;
    }
}