using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Debug
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            DependencyInjection.RegisterService();
            var sender = DependencyInjection.ServiceProvider.GetService<ISender>();

            var plannedMealCommand = new CreatePlannedMealCommand(3, DateTime.Now.Date.AddDays(4), 20);

            var response = await sender.Send(plannedMealCommand);

            Console.ReadLine();
        }
    }
}