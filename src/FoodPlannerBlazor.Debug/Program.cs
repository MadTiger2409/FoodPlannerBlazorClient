using FoodPlannerBlazor.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Debug
{
    public class Program
    {
        private static ShoppingListComponentViewModel ViewModel { get; set; }

        private static void ListFileContentChangedAsync(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.ShoppingListFileContentResponse)
                && ViewModel.ShoppingListFileContentResponse.Success
                && ViewModel.ShoppingListFileContentResponse.Value != null
                && ViewModel.ShoppingListFileContentResponse.Value.Content.Length > 0)
            {
                Console.WriteLine("Value changed");
            }
        }

        public static async Task Main(string[] args)
        {
            DependencyInjection.RegisterService();
            ViewModel = DependencyInjection.ServiceProvider.GetService<ShoppingListComponentViewModel>();
            ViewModel.PropertyChanged += ListFileContentChangedAsync;

            await ViewModel.GetShoppingListFromApiAsync(new EditFormModels.GetShoppingListFormModel
            {
                From = DateTime.UtcNow.Date,
                To = DateTime.UtcNow.AddDays(1).Date,
                PeopleCount = 1,
                Type = Enums.ShoppingListTypeEnum.PDF_File
            });

            Console.ReadLine();
        }
    }
}