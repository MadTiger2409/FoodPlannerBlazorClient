using FoodPlannerBlazor.Application.BusinessLogic.Category.Commands;
using FoodPlannerBlazor.Domain.Entities.Category.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.Category
{
    public class NewCategoryComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Domain.Entities.Category.Category> _response = new();

        public ApiResponse<Domain.Entities.Category.Category> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public NewCategoryComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task AddCategoryAsync(CreateCategory createCategoryModel) => Response = await _mediator.Send(new CreateCategoryCommand(createCategoryModel));
    }
}