using FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands;
using FoodPlannerBlazor.Domain.Entities.Unit.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Handlers
{
    public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, ApiResponse<Domain.Entities.Unit.Unit>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public CreateUnitHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Unit.Unit>> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("units");
            var outgoingObject = new CreateUnit(request.Name);

            return await httpClient.PostWithDeserializationAsync<Domain.Entities.Unit.Unit>(outgoingObject);
        }
    }
}