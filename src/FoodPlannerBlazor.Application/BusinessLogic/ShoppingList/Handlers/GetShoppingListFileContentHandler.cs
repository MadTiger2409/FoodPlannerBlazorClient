using FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Handlers
{
    public class GetShoppingListFileContentHandler : IRequestHandler<GetShoppingListFileContentQuery, ApiResponse<byte[]>>
    {
        public async Task<ApiResponse<byte[]>> Handle(GetShoppingListFileContentQuery request, CancellationToken cancellationToken)
        {
            return new ApiResponse<byte[]>();
        }
    }
}
