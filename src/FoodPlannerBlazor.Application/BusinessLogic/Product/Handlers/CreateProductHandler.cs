using FoodPlannerBlazor.Application.BusinessLogic.Product.Commands;
using FoodPlannerBlazor.Domain.Entities.Product.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Product.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ApiResponse<Domain.Entities.Product.Product>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public CreateProductHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Product.Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("products");
            var outgoingObject = new CreateProduct(request.Name, request.CategoryId);

            return await httpClient.PostWithDeserializationAsync<Domain.Entities.Product.Product>(outgoingObject);
        }
    }
}