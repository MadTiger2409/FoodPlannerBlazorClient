using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components
{
    public partial class NewCategoryComponent : ComponentBase
    {
        [Inject]
        public NewCategoryComponentViewModel ViewModel { get; set; }

        private CreateCategoryFormModel formModel = new();

        private bool showDetailsInformation = false;

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddCategoryAsync(formModel);
            showDetailsInformation = true;
        }

        public void Dispose() => ViewModel.PropertyChanged -= OnPropertyChangedHandler;

        protected override async Task OnInitializedAsync()
        {
            ViewModel.PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            };
            await base.OnInitializedAsync();
        }

        private async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}