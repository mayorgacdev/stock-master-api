using Training.Application.Attributes;
using Training.Application.Validations.Customers;

namespace Training.Application.Requests;

[Validator<CreateCustomerValidator>]
public class CreateCurstomerRequest : IRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

