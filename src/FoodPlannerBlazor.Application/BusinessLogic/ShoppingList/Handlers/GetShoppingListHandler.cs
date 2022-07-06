using FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries;
using FoodPlannerBlazor.Domain.Entities.ShoppingList;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Handlers
{
    public class GetShoppingListHandler : IRequestHandler<GetShoppingListQuery, ApiResponse<List<ShoppingListItem>>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetShoppingListHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<List<ShoppingListItem>>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("shoppingList");

            var queryParams = new Dictionary<string, string>
            {
                ["from"] = request.GetShoppingListModel.From.Date.ToString("yyyy-MM-dd"),
                ["to"] = request.GetShoppingListModel.To.Date.ToString("yyyy-MM-dd"),
                ["peopleCount"] = request.GetShoppingListModel.PeopleCount.ToString(CultureInfo.InvariantCulture)
            };
            var partialQuery = QueryHelpers.AddQueryString(string.Empty, queryParams);


            return await httpClient.GetWithDeserializationAsync<List<ShoppingListItem>>(partialQuery);
        }
    }
}
