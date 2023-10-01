using FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Handlers
{
    public class DeleteUnitHandler : IRequestHandler<DeleteUnitCommand, ApiResponse<string>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public DeleteUnitHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<string>> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("units");

            return await httpClient.DeleteWithDeserializationAsync(request.Id);
        }
    }
}
