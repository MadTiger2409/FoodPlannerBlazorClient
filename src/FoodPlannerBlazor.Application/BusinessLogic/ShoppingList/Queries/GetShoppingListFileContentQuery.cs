using FoodPlannerBlazor.Domain.Entities.ShoppingList.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries
{
    public record GetShoppingListFileContentQuery(GetShoppingList GetShoppingListModel) : IRequest<ApiResponse<byte[]>>;
}
