using FoodPlannerBlazor.Application.BusinessLogic.Product.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Product.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, ApiResponse<List<Domain.Entities.Product.Product>>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetProductsHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<List<Domain.Entities.Product.Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            string parameters = string.Empty;
            var httpClient = _clientFactory.CreateClient("categories");

            if (!string.IsNullOrWhiteSpace(request.Name))
                parameters = QueryHelpers.AddQueryString(string.Empty, "name", request.Name);

            return await httpClient.GetWithDeserializationAsync<List<Domain.Entities.Product.Product>>(parameters);
        }
    }
}