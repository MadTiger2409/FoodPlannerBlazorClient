using FoodPlannerBlazor.Application.BusinessLogic.Category.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Handlers
{
    public class GetCategoryByIdCommand : IRequestHandler<GetCategoryByIdQuery, ApiResponse<Domain.Entities.Category.Category>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetCategoryByIdCommand(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Category.Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("categories");

            return await httpClient.GetWithDeserializationAsync<Domain.Entities.Category.Category>(request.Id.ToString());
        }
    }
}