using FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Handlers
{
    public class UpdateUnitHandler : IRequestHandler<UpdateUnitCommand, ApiResponse<Domain.Entities.Unit.Unit>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public UpdateUnitHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Unit.Unit>> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("units");

            return await httpClient.PutWithDeserializationAsync<Domain.Entities.Unit.Unit>(request.Unit, request.Id.ToString());
        }
    }
}