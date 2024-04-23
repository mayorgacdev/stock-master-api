namespace Training.Application.Validations.Products;

using Ardalis.Specification;
using FluentValidation;
using FluentValidation.Validators;
using System.Threading;
using System.Threading.Tasks;
using Training.Application.Requests.Products;
using Training.Domain.Inventory;
using Training.Infraestructure.Data.Specifications;
using Training.Infraestructure.Interfaces;

public class AsyncPartNotExistValidator<T> : AsyncPropertyValidator<T, IEnumerable<CreatePartRequest>>
{
    public override string Name => "AsyncPartNotExistValidator";

    public override async Task<bool> IsValidAsync(ValidationContext<T> context, IEnumerable<CreatePartRequest> value, CancellationToken cancellation)
    {
        var values = value.Select(request => request.Name).Distinct();
        var Specification = context.RootContextData[nameof(ISpecificationGroup)].As<SpecificationGroup>()!.PartSpecification;
        Specification.Query.Where(accesory => values.Contains(accesory.Name));

        var Parts = await context.RootContextData[nameof(IUnitOfWork)].As<IUnitOfWork>()!.PartReadRepository.CountAsync(Specification, cancellation);
        return Parts == 0;
    }
}
