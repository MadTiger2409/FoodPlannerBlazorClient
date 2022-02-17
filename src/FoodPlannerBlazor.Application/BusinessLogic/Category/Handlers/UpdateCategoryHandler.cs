using FoodPlannerBlazor.Application.BusinessLogic.Category.Commands;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ApiResponse<Domain.Entities.Category.Category>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public UpdateCategoryHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Category.Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("categories");

            return await httpClient.PutWithDeserializationAsync<Domain.Entities.Category.Category>(request.Category, request.Id.ToString());
        }
    }
}