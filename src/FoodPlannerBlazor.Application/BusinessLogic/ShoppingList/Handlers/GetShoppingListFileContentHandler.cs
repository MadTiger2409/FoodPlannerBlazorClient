using FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries;
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
    public class GetShoppingListFileContentHandler : IRequestHandler<GetShoppingListFileContentQuery, ApiResponse<byte[]>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetShoppingListFileContentHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<byte[]>> Handle(GetShoppingListFileContentQuery request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("shoppingList");

            var queryParams = new Dictionary<string, string>
            {
                ["from"] = request.GetShoppingListModel.From.Date.ToString("yyyy-MM-dd"),
                ["to"] = request.GetShoppingListModel.To.Date.ToString("yyyy-MM-dd"),
                ["peopleCount"] = request.GetShoppingListModel.PeopleCount.ToString(CultureInfo.InvariantCulture)
            };
            var partialQuery = QueryHelpers.AddQueryString("pdf", queryParams);

            // Change it to do correct deserialization
            // Maybe add new extension method to get file with deserialization?
            return await httpClient.GetWithDeserializationAsync<byte[]>(partialQuery);
        }
    }
}
