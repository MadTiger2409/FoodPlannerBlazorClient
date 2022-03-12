using Microsoft.Extensions.DependencyInjection;

namespace FoodPlannerBlazor.Infrastructure
{
    public static class DependencyInjection
    {
        private static readonly string baseApiAddress = "https://192.168.1.108:5001";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient("categories", client =>
            {
                client.BaseAddress = new($"{baseApiAddress}/webapi/categories/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("meals", client =>
            {
                client.BaseAddress = new($"{baseApiAddress}/webapi/meals/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("plannedMeals", client =>
            {
                client.BaseAddress = new($"{baseApiAddress}/webapi/plannedMeals/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("products", client =>
            {
                client.BaseAddress = new($"{baseApiAddress}/webapi/products/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("shoppingList", client =>
            {
                client.BaseAddress = new($"{baseApiAddress}/webapi/shoppingList/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            services.AddHttpClient("units", client =>
            {
                client.BaseAddress = new($"{baseApiAddress}/webapi/units/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            return services;
        }
    }
}