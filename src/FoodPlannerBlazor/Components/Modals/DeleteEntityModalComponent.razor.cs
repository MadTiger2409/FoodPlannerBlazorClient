using Microsoft.AspNetCore.Components;

namespace FoodPlannerBlazor.Components.Modals
{
	public partial class DeleteEntityModalComponent : ComponentBase
	{
		private bool _deleteEntity = false;

		[Parameter]
		public string EntityName { get; set; }

		[Parameter]
		public bool DeleteEntity
		{
			get => _deleteEntity;
			set
			{
				if (_deleteEntity == value)
					return;

				_deleteEntity = value;
				DeleteEntityChanged.InvokeAsync(value);
			}
		}

		[Parameter]
		public EventCallback<bool> DeleteEntityChanged { get; set; }
	}
}
