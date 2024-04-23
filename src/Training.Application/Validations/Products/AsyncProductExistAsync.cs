using FluentValidation.Validators;
using FluentValidation;
using Training.Infraestructure.Data.Specifications;
using Training.Infraestructure.Interfaces;

namespace Training.Application.Validations.Products;

public class AsyncProductExistAsync<TRequest> : AsyncPropertyValidator<TRequest, string>
{
    public override string Name => "AsyncProductExistAsync";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISpecificationGroup)].As<SpecificationGroup>()!.ProductSpecification;
        Specification.Query.ByName(Value);

        var Product = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.ProductReadRepository.FirstOrDefaultAsync(Specification!, Cancellation);
        return Product is not null;
    }
}
