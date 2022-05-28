using FoodPlannerBlazor.Domain.Entities.Meal;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;

namespace FoodPlannerBlazor.ViewModels
{
    public class NewMealComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Meal> _response = new();

        public ApiResponse<Meal> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public NewMealComponentViewModel(ISender mediator) => _mediator = mediator;

        //public async Task AddMealAsync(CreateMealFormModel formModel) => Response = await _mediator.Send(new CreateMealCommand(formModel.Name, formModel.Ingredients));
    }
}