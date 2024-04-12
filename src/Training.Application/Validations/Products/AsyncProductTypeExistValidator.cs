namespace Training.Application.Validations.Products;

using Ardalis.Specification;
using FluentValidation.Validators;
using FluentValidation;
using Training.Application.Constants;
using Training.Application.Resources;
using Training.Domain.Inventory;
using Training.Infraestructure.Interfaces;
using Training.Infraestructure.Data.Specifications;

public class AsyncProductTypeExistValidator<TRequest> : AsyncPropertyValidator<TRequest, string?>
{
    public override string Name => "AsyncProductTypeExistValidator";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string? Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISingleResultSpecification<Product>)].As<ISingleResultSpecification<Product>>();
        Specification?.Query.Include(Prop => Prop.ProductType).ByTypeName(Value);

        var ProductType = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.ProductReadRepository.FirstOrDefaultAsync(Specification!, Cancellation);
        return ProductType is not null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0003)!;
    }
}
