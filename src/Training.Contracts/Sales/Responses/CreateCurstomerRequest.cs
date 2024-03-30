namespace Training.Contracts.Sales.Responses;

public class CreateCurstomerRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

public static class CreateCurstomerRequestExtensions
{
    public static Customer ToCustomer(this CreateCurstomerRequest request)
    {
        return Customer.Create(request.FirstName, request.LastName, request.Email, request.Phone);
    }
}