using FoodPlannerBlazor.Enums;
using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.JSInterop;
using FoodPlannerBlazor.ViewModels.ShoppingList;

namespace FoodPlannerBlazor.Components.ShoppingList
{
    public partial class ShoppingListComponent : BaseComponent<ShoppingListComponentViewModel>, IDisposable
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public DateTime From { get; set; } = DateTime.Now.Date;

        [Parameter]
        public DateTime To { get; set; } = DateTime.Now.Date;

        [Parameter]
        public float PeopleCount { get; set; } = 1f;

        private GetShoppingListFormModel formModel = new();
        private bool disposed;

        protected override void OnInitialized()
        {
            ViewModel.PropertyChanged += ListFileContentChangedAsync;
        }

        private async void ListFileContentChangedAsync(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.ShoppingListFileContentResponse)
                && ViewModel.ShoppingListFileContentResponse.Success
                && ViewModel.ShoppingListFileContentResponse.Value != null
                && ViewModel.ShoppingListFileContentResponse.Value.Content.Length > 0)
            {
                await JSRuntime.InvokeVoidAsync("downloadFromByteArray",
                    new
                    {
                        ByteArray = ViewModel.ShoppingListFileContentResponse.Value.Content,
                        FileName = ViewModel.ShoppingListFileContentResponse.Value.NameWithExtension,
                        ContentType = "application/pdf"
                    });
            }
        }

        private async Task OnValidSubmitAsync()
        {
            From = formModel.From;
            To = formModel.To;
            PeopleCount = formModel.PeopleCount;

            await ViewModel.GetShoppingListFromApiAsync(formModel);
        }

        protected override async Task OnParametersSetAsync()
        {
            var queryString = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;
            var parsedQuery = QueryHelpers.ParseQuery(queryString);

            if (parsedQuery.TryGetValue("from", out var from))
            {
                From = Convert.ToDateTime(from);
            }

            if (parsedQuery.TryGetValue("to", out var to))
            {
                To = Convert.ToDateTime(to);
            }

            if (parsedQuery.TryGetValue("peopleCount", out var peopleCount))
            {
                PeopleCount = (float)Convert.ToDouble(peopleCount, CultureInfo.InvariantCulture);
            }

            formModel.From = From;
            formModel.To = To;
            formModel.PeopleCount = PeopleCount;
            formModel.Type = ShoppingListTypeEnum.In_App_List;

            await ViewModel.GetShoppingListFromApiAsync(formModel);
        }

        protected virtual new void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    ViewModel.PropertyChanged -= ListFileContentChangedAsync;

                base.Dispose(disposing);
            }

            disposed = true;
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ShoppingListComponent() => Dispose(false);
    }
}
