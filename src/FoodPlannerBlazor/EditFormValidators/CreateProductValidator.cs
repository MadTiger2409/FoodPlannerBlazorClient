﻿using FluentValidation;
using FoodPlannerBlazor.Domain.Entities.Product.Outgoing;

namespace FoodPlannerBlazor.EditFormValidators
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull()
                .WithMessage("Category must be selected");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("Category must be selected");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name can't be empty");

            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters long");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name can be up to 100 characters long");
        }
    }
}