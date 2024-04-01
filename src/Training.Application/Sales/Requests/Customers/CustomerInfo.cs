namespace Training.Application.Sales.Requests.Customers;

// Convert to class
public class CustomerInfo
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

/*

public static class CustomerInfoExtensions
{
    public static CustomerInfo ToCustomerInfo(this Customer customer)
    {
        return new CustomerInfo(customer.Id, customer.FirtsName, customer.Email, customer.Phone);
    }
}*/

// Path: src/Training.Contracts/Sales/Responses/CustomerInfo.cs

