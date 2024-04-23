using FluentValidation;
using FluentValidation.Validators;
using Training.Infraestructure.Data.Specifications;
using Training.Infraestructure.Interfaces;

namespace Training.Application.Validations.Products;

public class AsyncAccessoryNameNotExist<TRequest> : AsyncPropertyValidator<TRequest, string>
{
    public override string Name => "AsyncAccessoryNameNotExist";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> context, string value, CancellationToken cancellation)
    {
        var Specification = context.RootContextData[nameof(ISpecificationGroup)].As<SpecificationGroup>()!.AccesorySpecification;
        Specification.Query.ByName(value);
        var ProductBrand = await context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.AccesoryReadRepository.FirstOrDefaultAsync(Specification!, cancellation);
        return ProductBrand is not null;
    }
}
