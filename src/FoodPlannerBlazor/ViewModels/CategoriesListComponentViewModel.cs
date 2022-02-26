using FoodPlannerBlazor.Application.BusinessLogic.Category.Queries;
using FoodPlannerBlazor.Domain.Entities.Category;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class CategoriesListComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<List<Category>> _response = new();

        public ApiResponse<List<Category>> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public CategoriesListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetPlannedMealsFromApiAsync(string name) => Response = await _mediator.Send(new GetCategoriesQuery(name));
    }
}