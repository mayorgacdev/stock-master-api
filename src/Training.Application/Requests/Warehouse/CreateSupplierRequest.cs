namespace Training.Application.Requests.Warehouse;

using Training.Application.Attributes;

[Validator<CreateSupplierValidator>]
public class CreateSupplierRequest : IRequest
{
    public required string Name { get; set; }
    public required string Address { get; set; } 
    public required string Phone { get; set; }
    public required string Email { get; set; }
}