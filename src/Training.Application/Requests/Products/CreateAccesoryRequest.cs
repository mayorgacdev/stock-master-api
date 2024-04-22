namespace Training.Application.Requests.Products;

using Training.Application.Attributes;
using Training.Domain.Inventory;

[Validator<CreateAccesoryValidator>]
public class CreateAccesoryRequest : IRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Notes { get; set; }
    public required bool IsActive { get; set; }
    public required decimal PurchaseAmount { get; set; }
    public required decimal Price { get; set; }
    public required int Stock { get; set; }
    public required string Currency { get; set; }
}