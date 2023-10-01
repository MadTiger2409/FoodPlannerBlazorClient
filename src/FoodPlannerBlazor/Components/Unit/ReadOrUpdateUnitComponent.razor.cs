using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Components.Modals;
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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private UpdateUnit _updateUnitModel = new();
        private DeleteEntityModalComponent<Domain.Entities.Unit.Unit> deleteModal;

        private bool showDetailsInformation = false;

        private bool _disabled = true;

        private string _editButtonClass = "btn-warning";
        private string _editButtonValue = "Edit";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await ViewModel.GetUnitFromApiAsync(Id);

            if (ViewModel.GetUnitResponse.Success)
                _updateUnitModel.Name = ViewModel.GetUnitResponse.Value.Name;
        }

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.UpdateUnitAsync(Id, _updateUnitModel);

            if (ViewModel.UpdateUnitResponse.Success == true && ViewModel.UpdateUnitResponse.Error == null)
                ToggleEdit();

            showDetailsInformation = true;
        }

        private async Task OnDeleteAsync()
        {
            await ViewModel.DeleteUnitAsync(Id);

            if (ViewModel.DeleteUnitResponse.Success == true)
            {
                NavigationManager.NavigateTo("/units");
            }
            else
            {
                ViewModel.UpdateUnitResponse.Error = ViewModel.DeleteUnitResponse.Error;
                ViewModel.UpdateUnitResponse.Success = false;

                showDetailsInformation = true;
            }
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

                _updateUnitModel = new UpdateUnit { Name = ViewModel.GetUnitResponse.Value.Name };
            }
        }
    }
}
