using FoodPlannerBlazor.Application.BusinessLogic.Meal.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Meal.Handlers
{
    public class GetMealsHandler : IRequestHandler<GetMealsQuery, ApiResponse<List<Domain.Entities.Meal.Meal>>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetMealsHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<List<Domain.Entities.Meal.Meal>>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            string parameters = string.Empty;
            var httpClient = _clientFactory.CreateClient("meals");

            if (!string.IsNullOrWhiteSpace(request.Name))
                parameters = QueryHelpers.AddQueryString(string.Empty, "name", request.Name);

            return await httpClient.GetWithDeserializationAsync<List<Domain.Entities.Meal.Meal>>(parameters);
        }
    }
}