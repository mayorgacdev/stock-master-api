namespace Training.Application.Validations.Warehouse;

using Ardalis.Specification;
using FluentValidation.Validators;
using FluentValidation;
using Training.Application.Constants;
using Training.Application.Resources;
using Training.Domain.Inventory;
using Training.Infraestructure.Interfaces;
using Training.Infraestructure.Data.Specifications;

internal class AsyncTypeNotExist<TRequest> : AsyncPropertyValidator<TRequest, string>
{
    public override string Name => "AsyncTypeNotExist";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISingleResultSpecification<ProductType>)].As<ISingleResultSpecification<ProductType>>();
        Specification?.Query.ByName(Value);

        var Warehouse = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.ProductTypeRepository.FirstOrDefaultAsync(Specification!, Cancellation);
        return Warehouse is null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0009)!;
    }

}