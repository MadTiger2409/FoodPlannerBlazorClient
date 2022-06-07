using FoodPlannerBlazor.Infrastructure.Common;
using Microsoft.AspNetCore.Components;

namespace FoodPlannerBlazor.Components.Utilities
{
    public partial class ResponseStatusComponent<T> : ComponentBase
    {
        private ApiResponse<T> _response;
        private string _successMessage;
        private bool _showDetailsInformation = false;

        [Parameter]
        public ApiResponse<T> Response
        {
            get => _response;
            set => _response = value;
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
            set => _showDetailsInformation = value;
        }
    }
}
