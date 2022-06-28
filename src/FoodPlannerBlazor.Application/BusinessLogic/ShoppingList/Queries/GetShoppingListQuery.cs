using FoodPlannerBlazor.Domain.Entities.ShoppingList;
using FoodPlannerBlazor.Domain.Entities.ShoppingList.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries
{
    public record GetShoppingListQuery(GetShoppingList GetShoppingListModel) : IRequest<ApiResponse<List<ShoppingListItem>>>;
}
