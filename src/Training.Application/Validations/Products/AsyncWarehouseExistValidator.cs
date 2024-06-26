﻿namespace Training.Application.Validations.Products;

using Ardalis.Specification;
using FluentValidation.Validators;
using FluentValidation;
using Training.Application.Constants;
using Training.Application.Resources;
using Training.Domain.Inventory;
using Training.Infraestructure.Interfaces;
using Training.Infraestructure.Data.Specifications;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class AsyncWarehouseExistValidator<TRequest> : AsyncPropertyValidator<TRequest, string>
{
    public override string Name => "AsyncWarehouseExistValidator";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISpecificationGroup)].As<SpecificationGroup>();
        var SingleWarehouseSpec = Specification!.WarehouseSpecification;
        SingleWarehouseSpec.Query.ById(Value);
        
        var Warehouse = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.WarehouseReadRepository.
            FirstOrDefaultAsync(SingleWarehouseSpec, Cancellation);
        return Warehouse is not null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0005)!;
    }
}