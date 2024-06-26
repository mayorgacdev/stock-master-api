﻿namespace Training.Application.Validations.Products;

using Ardalis.Specification;
using FluentValidation.Validators;
using FluentValidation;
using Training.Application.Constants;
using Training.Application.Resources;
using Training.Domain.Inventory;
using Training.Infraestructure.Interfaces;
using Training.Infraestructure.Data.Specifications;

public class AsyncSupplierExistValidator<TRequest> : AsyncPropertyValidator<TRequest, string>
{
    public override string Name => "AsyncSupplierExistValidator";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISpecificationGroup)].As<SpecificationGroup>();
        var SingleSupplierSpecification = Specification!.SupplierSpecification;
        SingleSupplierSpecification.Query.ById(Value);

        var Supplier = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!
            .SupplierReadRepository.FirstOrDefaultAsync(SingleSupplierSpecification!, Cancellation);

        return Supplier is not null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0004)!;
    }
}