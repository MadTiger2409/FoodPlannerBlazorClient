using FoodPlannerBlazor.ViewModels.Common;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Common
{
    public class BaseComponent<TViewModel> : ComponentBase where TViewModel : BaseViewModel
    {
        [Inject]
        public TViewModel ViewModel { get; set; }

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

        public void Dispose() => ViewModel.PropertyChanged -= OnPropertyChangedHandler;
    }
}