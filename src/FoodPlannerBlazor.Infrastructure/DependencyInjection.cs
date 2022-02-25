using Microsoft.Extensions.DependencyInjection;

namespace FoodPlannerBlazor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient("categories", client =>
            {
                client.BaseAddress = new("https://localhost:5001/webapi/categories/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("meals", client =>
            {
                client.BaseAddress = new("https://localhost:5001/webapi/meals/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("plannedMeals", client =>
            {
                client.BaseAddress = new("https://localhost:5001/webapi/plannedMeals/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("products", client =>
            {
                client.BaseAddress = new("https://localhost:5001/webapi/products/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("shoppingList", client =>
            {
                client.BaseAddress = new("https://localhost:5001/webapi/shoppingList/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("units", client =>
            {
                client.BaseAddress = new("https://localhost:5001/webapi/units/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            return services;
        }
    }
}