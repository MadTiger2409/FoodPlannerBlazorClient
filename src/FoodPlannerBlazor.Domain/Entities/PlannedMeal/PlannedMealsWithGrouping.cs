using System;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal
{
    public class PlannedMealsWithGrouping
    {
        public DateTime ScheduledFor { get; set; }
        public List<PlannedMealForGrouping> PlannedMeals { get; set; }
    }
}