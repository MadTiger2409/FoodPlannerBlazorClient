﻿using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Handlers
{
    public class GetPlannedMealsHandler : IRequestHandler<GetPlannedMealsQuery, ApiResponse<List<Domain.Entities.PlannedMeal.PlannedMealsWithGrouping>>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetPlannedMealsHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<List<Domain.Entities.PlannedMeal.PlannedMealsWithGrouping>>> Handle(GetPlannedMealsQuery request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("plannedMeals");

            var queryParams = new Dictionary<string, string>
            {
                ["from"] = request.From.Date.ToString("yyyy-MM-dd"),
                ["to"] = request.To.Date.ToString("yyyy-MM-dd"),
            };
            var partialQuery = QueryHelpers.AddQueryString(string.Empty, queryParams);

            return await httpClient.GetWithDeserializationAsync<List<Domain.Entities.PlannedMeal.PlannedMealsWithGrouping>>(partialQuery);
        }
    }
}