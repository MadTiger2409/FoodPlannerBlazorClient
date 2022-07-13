using FoodPlannerBlazor.Application.BusinessLogic.ShoppingList.Queries;
using FoodPlannerBlazor.Domain.Entities.Common;
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
    public class GetShoppingListFileContentHandler : IRequestHandler<GetShoppingListFileContentQuery, ApiResponse<FileDataEntity>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetShoppingListFileContentHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<FileDataEntity>> Handle(GetShoppingListFileContentQuery request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("shoppingList");

            var queryParams = new Dictionary<string, string>
            {
                ["from"] = request.GetShoppingListModel.From.Date.ToString("yyyy-MM-dd"),
                ["to"] = request.GetShoppingListModel.To.Date.ToString("yyyy-MM-dd"),
                ["peopleCount"] = request.GetShoppingListModel.PeopleCount.ToString(CultureInfo.InvariantCulture)
            };
            var partialQuery = QueryHelpers.AddQueryString("pdf", queryParams);

            return await httpClient.GetFileWithDeserializationAsync(partialQuery);
        }
    }
}
