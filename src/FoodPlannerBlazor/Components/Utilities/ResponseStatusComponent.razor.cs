using FoodPlannerBlazor.Infrastructure.Common;
using Microsoft.AspNetCore.Components;

namespace FoodPlannerBlazor.Components.Utilities
{
    public partial class ResponseStatusComponent<T> : ComponentBase
    {
        private ApiResponse<T> _response;
        private string _successMessage;
        private bool _showDetailsInformation = false;
        private string detailsCssClass;

        [Parameter]
        public ApiResponse<T> Response
        {
            get => _response;
            set
            {
                _response = value;
                detailsCssClass = Response.Success ? "details-success" : "details-fail";
            }
        }

        [Parameter]
        public string SuccessMessage
        {
            get => _successMessage;
            set => _successMessage = value;
        }

        [Parameter]
        public bool ShowDetailsInformation
        {
            get => _showDetailsInformation;
            set
            {
                if (_showDetailsInformation == value)
                    return;

                _showDetailsInformation = value;
                ShowDetailsInformationChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<bool> ShowDetailsInformationChanged { get; set; }

        private void Hide()
        {
            detailsCssClass = string.Empty;
            ShowDetailsInformation = false;
        }
    }
}
