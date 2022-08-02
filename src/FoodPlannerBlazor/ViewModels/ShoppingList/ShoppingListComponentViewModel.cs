using FoodPlannerBlazor.Domain.Entities.ShoppingList;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using FoodPlannerBlazor.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries;
using FoodPlannerBlazor.Domain.Entities.Common;

namespace FoodPlannerBlazor.ViewModels.ShoppingList
{
    public class ShoppingListComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;

        private ApiResponse<List<ShoppingListItem>> _shoppingListResponse = new();
        private ApiResponse<FileDataEntity> shoppingListFileContentResponse;

        public ApiResponse<List<ShoppingListItem>> ShoppingListResponse
        {
            get => _shoppingListResponse;
            set => SetValue(ref _shoppingListResponse, value);
        }

        public ApiResponse<FileDataEntity> ShoppingListFileContentResponse
        {
            get => shoppingListFileContentResponse;
            set => SetValue(ref shoppingListFileContentResponse, value);
        }

        public ShoppingListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetShoppingListFromApiAsync(GetShoppingListFormModel model)
        {
            if (model.Type == ShoppingListTypeEnum.In_App_List)
            {
                ShoppingListResponse = await _mediator.Send(new GetShoppingListQuery(model));
                return;
            }

            ShoppingListFileContentResponse = await _mediator.Send(new GetShoppingListFileContentQuery(model));
        }
    }
}
