namespace Training.Application.Extensions;

using FluentValidation;
using Training.Application.Validations.Customers;
using Training.Application.Validations.Products;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, string?> CustomerUniqueEmailAsync<T>(this IRuleBuilder<T, string?> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncCustomerUniqueEmailValidator<T>());

    public static IRuleBuilderOptions<T, string?> ProductBrandExistAsync<T>(this IRuleBuilder<T, string?> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncProductBrandExistValidator<T>());

    public static IRuleBuilderOptions<T, string?> ProductTypeExistAsync<T>(this IRuleBuilder<T, string?> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncProductTypeExistValidator<T>());
    public static IRuleBuilderOptions<T, string?> SupplierExistAsync<T>(this IRuleBuilder<T, string?> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncSupplierExistValidator<T>());

    public static IRuleBuilderOptions<T, string?> WarehouseExistAsync<T>(this IRuleBuilder<T, string?> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncWarehouseExistValidator<T>());
}