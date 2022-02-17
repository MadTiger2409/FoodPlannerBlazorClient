using FoodPlannerBlazor.Application.BusinessLogic.Category.Queries;
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

            var response = await sender.Send(new GetCategoriesQuery());

            Console.ReadLine();
        }
    }
}