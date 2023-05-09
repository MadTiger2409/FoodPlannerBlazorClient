using FoodPlannerBlazor.Domain.Entities.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Modals
{
    public partial class DeleteEntityModalComponent<T> : ComponentBase where T : NamedEntity
    {
        [Parameter]
        public T Entity { get; set; }

        [Parameter]
        public EventCallback<int?> OnDeleteEntity { get; set; }

        private string modalDisplay = "none;";
        private string modalClass = "";

        public void Open()
        {
            modalDisplay = "block;";
            modalClass = "fade show";
        }

        private async Task DeleteEntity(MouseEventArgs e, int? entityId)
        {
            await OnDeleteEntity.InvokeAsync(entityId);
            Close();
        }

        private void Close()
        {
            modalDisplay = "none";
            modalClass = "";
        }
    }
}
