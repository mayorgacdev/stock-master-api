namespace Training.Application.Validations.Products;

using Ardalis.Specification;
using FluentValidation;
using FluentValidation.Validators;
using Training.Application.Constants;
using Training.Application.Resources;
using Training.Domain.Inventory;
using Training.Infraestructure.Data.Specifications;
using Training.Infraestructure.Interfaces;

public class AsyncProductBrandExistValidator<TRequest> : AsyncPropertyValidator<TRequest, string>
{
    public override string Name => "AsyncProductBrandExistValidator";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISingleResultSpecification<Product>)].As<ISingleResultSpecification<Product>>();
        Specification?.Query.ByBrandId(Guid.Parse(Value));

        var ProductBrand = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.ProductReadRepository.FirstOrDefaultAsync(Specification!, Cancellation);
        return ProductBrand is not null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0002)!;
    }
}
