namespace Training.Contracts;

public record CustomerInfo(Guid Id, string Name, string Email, string Phone);

public static class CustomerInfoExtensions
{
    public static CustomerInfo ToCustomerInfo(this Customer customer)
    {
        return new CustomerInfo(customer.Id, customer.FirtsName, customer.Email, customer.Phone);
    }
}

// Path: src/Training.Contracts/Sales/Responses/CustomerInfo.cs

