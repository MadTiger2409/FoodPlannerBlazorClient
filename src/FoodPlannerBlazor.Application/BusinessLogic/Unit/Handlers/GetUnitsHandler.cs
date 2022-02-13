using FoodPlannerBlazor.Application.BusinessLogic.Unit.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Handlers
{
    public class GetUnitsHandler : IRequestHandler<GetUnitsQuery, ApiResponse<List<Domain.Entities.Unit.Unit>>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetUnitsHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<List<Domain.Entities.Unit.Unit>>> Handle(GetUnitsQuery request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("units");

            return await httpClient.GetWithDeserializationAsync<List<Domain.Entities.Unit.Unit>>();
        }
    }
}