﻿namespace Training.Application.Validations.Warehouse;

using Ardalis.Specification;
using FluentValidation.Validators;
using FluentValidation;
using System.Threading.Tasks;
using Training.Application.Constants;
using Training.Application.Resources;
using Training.Domain.Inventory;
using Training.Infraestructure.Interfaces;
using Training.Infraestructure.Data.Specifications;

public class AsyncSupplierNotExist<TRequest> : AsyncPropertyValidator<TRequest, string>
{
    public override string Name => "AsyncSupplierNotExist";

    public override async Task<bool> IsValidAsync(ValidationContext<TRequest> Context, string Value, CancellationToken Cancellation)
    {
        var Specification = Context.RootContextData[nameof(ISingleResultSpecification<Supplier>)].As<ISingleResultSpecification<Supplier>>();
        Specification?.Query.ByName(Value);

        var Warehouse = await Context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.SupplierRepository.FirstOrDefaultAsync(Specification!, Cancellation);
        return Warehouse is null;
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0010)!;
    }

}