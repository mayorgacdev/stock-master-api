using FluentValidation;
using FluentValidation.Validators;

namespace Training.Application.Validations.Customers;

public class AsyncCustomerUniqueEmailValidator<TRequest> : AsyncPropertyValidator<TRequest, string?>
{
    public override string Name => "AsyncCustomerUniqueEmailValidator";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string? Value, CancellationToken Cancellation)
    {
        int epp = 002;
        await Task.CompletedTask;
        return await Task.FromResult(epp > 1);
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return "";
    }
}
