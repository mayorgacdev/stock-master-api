namespace Training.Application.Validations.Products;

using Ardalis.Specification;
using FluentValidation;
using FluentValidation.Validators;
using Training.Application.Constants;
using Training.Application.Requests.Products;
using Training.Application.Resources;
using Training.Domain.Inventory;
using Training.Infraestructure.Interfaces;

public class AsyncAccesoryNotExistAsync<T> : AsyncPropertyValidator<T, IEnumerable<CreateAccesoryRequest>>
{
    public override string Name => "AsyncAccesoryNotExistAsync";

    public override async Task<bool> IsValidAsync(ValidationContext<T> context, IEnumerable<CreateAccesoryRequest> value, CancellationToken cancellation)
    {
        var values = value.Select(request => request.Name).Distinct();
        var Specification = context.RootContextData[nameof(ISingleResultSpecification<Accesory>)].As<ISingleResultSpecification<Accesory>>();
        Specification!.Query.Where(accesory => values.Contains(accesory.Name));
        var products = await context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.AccesoryRepository.CountAsync(Specification!, cancellation);

        return products == 0;
    }
    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0011)!;
    }
}
