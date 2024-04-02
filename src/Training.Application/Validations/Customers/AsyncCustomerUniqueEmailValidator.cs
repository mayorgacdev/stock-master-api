using Ardalis.Specification;
using FluentValidation;
using FluentValidation.Validators;
using Training.Application.Constants;
using Training.Application.Resources;
using Training.Domain.Sales;
using Training.Infraestructure.Data.Specifications;
using Training.Infraestructure.Interfaces;

namespace Training.Application.Validations.Customers;

public class AsyncCustomerUniqueEmailValidator<TRequest> : AsyncPropertyValidator<TRequest, string?>
{
    public override string Name => "AsyncCustomerUniqueEmailValidator";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string? Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISingleResultSpecification<Customer>)].As<ISingleResultSpecification<Customer>>();
        Specification?.Query.ByEmail(Value);

        var Customer = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.CustomerReadRepository.FirstOrDefaultAsync(Specification!, Cancellation);
        return Customer is null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    { 
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0001)!;
    }
}
