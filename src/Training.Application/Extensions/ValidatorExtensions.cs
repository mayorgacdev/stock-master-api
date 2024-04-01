using FluentValidation;
using Training.Application.Validations.Customers;

namespace Training.Application.Extensions;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, string?> CustomerUniqueEmailAsync<T>(this IRuleBuilder<T, string?> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncCustomerUniqueEmailValidator<T>());
}