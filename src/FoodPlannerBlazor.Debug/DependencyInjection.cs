using FoodPlannerBlazor.Application;
using FoodPlannerBlazor.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FoodPlannerBlazor.Debug
{
    public static class DependencyInjection
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void RegisterService()
        {
            var services = new ServiceCollection();

            services.AddInfrastructure();
            services.AddApplication();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}