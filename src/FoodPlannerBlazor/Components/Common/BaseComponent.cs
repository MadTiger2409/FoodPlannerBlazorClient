using FoodPlannerBlazor.ViewModels.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Common
{
    public class BaseComponent<TViewModel> : ComponentBase, IDisposable where TViewModel : BaseViewModel
    {
        [Inject]
        public TViewModel ViewModel { get; set; }

        private bool disposed;

        protected override async Task OnInitializedAsync()
        {
            ViewModel.PropertyChanged += OnPropertyChangedHandler;
            await base.OnInitializedAsync();
        }

        private async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    ViewModel.PropertyChanged -= OnPropertyChangedHandler;
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseComponent() => Dispose(false);
    }
}