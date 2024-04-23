namespace Training.Application.Requests.Warehouse;

using Training.Application.Attributes;

[Validator<CreateWarehouseValidator>]
public class CreateWarehouseRequest : IRequest
{
    public required string Name { get; set; }

    public required string State { get; set; }

    public required string City { get; set; }

    public required int Capacity { get; set; }

    public required int Max { get; set; }
}
