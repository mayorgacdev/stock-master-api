using Training.Application.Requests;
using Training.Application.Sales.Requests.Customers;
using Training.Domain.Sales;

namespace Training.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerInfo>().ReverseMap();
        CreateMap<Customer, CreateCurstomerRequest>().ReverseMap();
    }
}