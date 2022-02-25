using FoodPlannerBlazor.Application.BusinessLogic.Meals.Queries;
using FoodPlannerBlazor.Domain.Entities.Meal;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Meals.Handlers
{
    public class GetMealsHandler : IRequestHandler<GetMealsQuery, ApiResponse<List<Meal>>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetMealsHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<List<Meal>>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            string parameters = string.Empty;
            var httpClient = _clientFactory.CreateClient("meals");

            if (!string.IsNullOrWhiteSpace(request.Name))
                parameters = QueryHelpers.AddQueryString(string.Empty, "name", request.Name);

            return await httpClient.GetWithDeserializationAsync<List<Meal>>(parameters);
        }
    }
}