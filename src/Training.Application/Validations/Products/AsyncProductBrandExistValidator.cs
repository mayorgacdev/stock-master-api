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
        var Specification = Context.RootContextData[nameof(ISpecificationGroup)].As<SpecificationGroup>();
        var SingleProductBrandSpecification = Specification!.BrandSpecification;
        SingleProductBrandSpecification.Query.ById(Value);

        var ProductBrand = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.ProductBrandReadRepository.FirstOrDefaultAsync(SingleProductBrandSpecification!, Cancellation);
        return ProductBrand is not null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0002)!;
    }
}
