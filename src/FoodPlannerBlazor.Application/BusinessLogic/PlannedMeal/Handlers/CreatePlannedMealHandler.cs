using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Commands;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.Infrastructure.Extensions;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Handlers
{
    public class CreatePlannedMealHandler : IRequestHandler<CreatePlannedMealCommand, ApiResponse<Domain.Entities.PlannedMeal.PlannedMeal>>
    {
        private readonly IHttpClientFactory _clientFactory;

        public CreatePlannedMealHandler(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        public async Task<ApiResponse<Domain.Entities.PlannedMeal.PlannedMeal>> Handle(CreatePlannedMealCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _clientFactory.CreateClient("plannedMeals");
            var outgoingObject = new CreatePlannedMeal(request.OrdinalNumber, request.ScheduledFor, request.MealId);

            return await httpClient.PostWithDeserializationAsync<Domain.Entities.PlannedMeal.PlannedMeal>(outgoingObject);
        }
    }
}