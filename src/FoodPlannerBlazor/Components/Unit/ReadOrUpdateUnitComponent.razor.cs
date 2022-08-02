using FoodPlannerBlazor.Domain.Entities.Unit.Outgoing;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Unit
{
    public partial class ReadOrUpdateUnitComponent
    {
        [Parameter]
        public int Id { get; set; }

        private UpdateUnit _updateUnitModel = new UpdateUnit { Name = "Test unit" };

        private bool _showDetailsInformation = false;

        private bool _disabled = true;

        private string _editButtonClass = "btn-warning";
        private string _editButtonValue = "Edit";

        private async Task OnValidSubmitAsync()
        {
            await Task.Delay(100);
        }

        private void ToggleEdit()
        {
            if (_disabled)
            {
                _editButtonClass = "btn-secondary";
                _editButtonValue = "Discard";
                _disabled = false;
            }
            else
            {
                _editButtonClass = "btn-warning";
                _editButtonValue = "Edit";
                _disabled = true;
            }
        }
    }
}
