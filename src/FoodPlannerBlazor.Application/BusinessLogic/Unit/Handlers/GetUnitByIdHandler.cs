using FoodPlannerBlazor.Application.BusinessLogic.Unit.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Handlers
{
    public class GetUnitByIdHandler : IRequestHandler<GetUnitByIdQuery, ApiResponse<Domain.Entities.Unit.Unit>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetUnitByIdHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Unit.Unit>> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("units");

            return await httpClient.GetWithDeserializationAsync<Domain.Entities.Unit.Unit>(request.Id.ToString());
        }
    }
}