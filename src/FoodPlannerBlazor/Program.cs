using FluentValidation;
using FoodPlannerBlazor.Application;
using FoodPlannerBlazor.Infrastructure;
using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodPlannerBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddInfrastructure();
            builder.Services.AddApplication();

            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            builder.Services.AddTransient<PlannedMealsListComponentViewModel>();
            builder.Services.AddTransient<NewPlannedMealComponentViewModel>();
            builder.Services.AddTransient<CategoriesListComponentViewModel>();
            builder.Services.AddTransient<NewCategoryComponentViewModel>();

            await builder.Build().RunAsync();
        }
    }
}