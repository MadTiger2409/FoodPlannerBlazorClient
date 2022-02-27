using FoodPlannerBlazor.Application.BusinessLogic.Category.Commands;
using FoodPlannerBlazor.Domain.Entities.Category.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ApiResponse<Domain.Entities.Category.Category>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public CreateCategoryHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Category.Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("categories");
            var outgoingObject = new CreateCategory(request.Name);

            return await httpClient.PostWithDeserializationAsync<Domain.Entities.Category.Category>(outgoingObject);
        }
    }
}