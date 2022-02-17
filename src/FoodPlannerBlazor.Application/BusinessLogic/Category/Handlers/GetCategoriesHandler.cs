using FoodPlannerBlazor.Application.BusinessLogic.Category.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, ApiResponse<List<Domain.Entities.Category.Category>>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetCategoriesHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<List<Domain.Entities.Category.Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            string parameters = string.Empty;
            var httpClient = _clientFactory.CreateClient("categories");

            if (!string.IsNullOrWhiteSpace(request.Name))
                parameters = QueryHelpers.AddQueryString(string.Empty, "name", request.Name);

            return await httpClient.GetWithDeserializationAsync<List<Domain.Entities.Category.Category>>(parameters);
        }
    }
}