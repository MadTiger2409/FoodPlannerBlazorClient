using FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries;
using FoodPlannerBlazor.Domain.Entities.ShoppingList;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Handlers
{
    public class GetShoppingListHandler : IRequestHandler<GetShoppingListQuery, ApiResponse<List<ShoppingListItem>>>
    {
        public async Task<ApiResponse<List<ShoppingListItem>>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            return new ApiResponse<List<ShoppingListItem>>();
        }
    }
}
