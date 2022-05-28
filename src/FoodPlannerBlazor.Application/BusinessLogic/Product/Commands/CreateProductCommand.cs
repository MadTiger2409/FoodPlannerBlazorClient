using FoodPlannerBlazor.Domain.Entities.Product.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Product.Commands
{
    public record CreateProductCommand(CreateProduct CreateProductModel) : IRequest<ApiResponse<Domain.Entities.Product.Product>>;
}