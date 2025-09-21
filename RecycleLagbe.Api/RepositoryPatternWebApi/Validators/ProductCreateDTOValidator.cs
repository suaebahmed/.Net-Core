using FluentValidation;
using RepositoryPatternWebApi.DTOs;
using RepositoryPatternWebApi.Repositories;
using RepositoryPatternWebApi.Repositories.Implementations;

namespace RepositoryPatternWebApi.Validators;

public class ProductCreateDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductCreateDTOValidator(ICategoryRepository categoryRepository)
    {

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .Length(3, 50).WithMessage("Product name must be between 3 and 50 characters.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.")
            .PrecisionScale(8, 2, true).WithMessage("Price must have at most 8 digits in total and 2 decimals.");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Hey, Come on! Category ID is required.")
            .MustAsync(async (id, ct) =>
            {
                return await categoryRepository.ExistsAsync(id);
            })
            .WithMessage("Invalid CategoryId From Fluent Validation");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
            .When(p => !string.IsNullOrEmpty(p.Description));

    }
}
