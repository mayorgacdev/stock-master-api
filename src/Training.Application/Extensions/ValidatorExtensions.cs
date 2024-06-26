﻿namespace Training.Application.Extensions;

using FluentValidation;
using Training.Application.Requests.Products;
using Training.Application.Validations.Customers;
using Training.Application.Validations.Products;
using Training.Application.Validations.Warehouse;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, string?> CustomerUniqueEmailAsync<T>(this IRuleBuilder<T, string?> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncCustomerUniqueEmailValidator<T>());

    public static IRuleBuilderOptions<T, string> ProductBrandExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncProductBrandExistValidator<T>());

    public static IRuleBuilderOptions<T, string> ProductTypeExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncProductTypeExistValidator<T>());
    public static IRuleBuilderOptions<T, string> SupplierExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncSupplierExistValidator<T>());

    public static IRuleBuilderOptions<T, string> WarehouseExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncWarehouseExistValidator<T>());

    public static IRuleBuilderOptions<T, IEnumerable<CreateProductPictureRequest>> UniqueProductUrl<T>(this IRuleBuilder<T, IEnumerable<CreateProductPictureRequest>> RuleBuilder)
        => RuleBuilder.SetValidator(new ProducPictureUniqueUrlValidator<T>());

    public static IRuleBuilderOptions<T, string> WarehouseNotExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncWarehouseNotExist<T>());

    public static IRuleBuilderOptions<T, string> SupplierNotExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncSupplierNotExist<T>());

    public static IRuleBuilderOptions<T, string> BrandNotExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncBrandNotExist<T>());

    public static IRuleBuilderOptions<T, string> ProductTypeNotExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncTypeNotExist<T>());

    public static IRuleBuilderOptions<T, string> AccessryNameNotExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncAccessoryNameNotExist<T>());

    public static IRuleBuilderOptions<T, string> ProductExistAsync<T>(this IRuleBuilder<T, string> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncProductExistAsync<T>());
    public static IRuleBuilderOptions<T, IEnumerable<CreateAccesoryRequest>> AccesoriesNotExistAsync<T>(this IRuleBuilder<T, IEnumerable<CreateAccesoryRequest>> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncAccesoriesNotExistAsync<T>());

    public static IRuleBuilderOptions<T, IEnumerable<CreatePartRequest>> PartsNotExistAsync<T>(this IRuleBuilder<T, IEnumerable<CreatePartRequest>> RuleBuilder)
        => RuleBuilder.SetAsyncValidator(new AsyncPartNotExistValidator<T>());
}