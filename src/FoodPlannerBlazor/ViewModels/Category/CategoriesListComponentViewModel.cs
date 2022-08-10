using FoodPlannerBlazor.Application.BusinessLogic.Category.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.Category
{
    public class CategoriesListComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<List<Domain.Entities.Category.Category>> _response = new();

        public ApiResponse<List<Domain.Entities.Category.Category>> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public CategoriesListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetCategoriesFromApiAsync(string name) => Response = await _mediator.Send(new GetCategoriesQuery(name));
    }
}