using FoodPlannerBlazor.Application.BusinessLogic.Meal.Commands;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.Meal.Handlers
{
    public class CreateMealHandler : IRequestHandler<CreateMealCommand, ApiResponse<Domain.Entities.Meal.Meal>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public CreateMealHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.Meal.Meal>> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("meals");

            return await httpClient.PostWithDeserializationAsync<Domain.Entities.Meal.Meal>(request.CreateMealModel);
        }
    }
}
