using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Unit.Outgoing;
using FoodPlannerBlazor.ViewModels.Unit;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Unit
{
    public partial class ReadOrUpdateUnitComponent : BaseComponent<ReadOrUpdateUnitComponentViewModel>
    {
        [Parameter]
        public int Id { get; set; }

        private UpdateUnit _updateUnitModel = new();

        private bool showDetailsInformation = false;

        private bool _disabled = true;

        private string _editButtonClass = "btn-warning";
        private string _editButtonValue = "Edit";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await ViewModel.GetUnitFromApiAsync(Id);

            _updateUnitModel.Name = ViewModel.GetUnitResponse.Value.Name;
        }

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.UpdateUnitAsync(Id, _updateUnitModel);

            if (ViewModel.UpdateUnitResponse.Success == true && ViewModel.UpdateUnitResponse.Error == null)
                ToggleEdit();

            showDetailsInformation = true;
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

                _updateUnitModel.Name = ViewModel.GetUnitResponse.Value.Name;
            }
        }
    }
}
