namespace Training.Application.Mapping;

using Training.Application.Requests;
using Training.Application.Sales.Requests.Customers;
using Training.Application.Sales.Requests.Products;
using Training.Domain.Inventory;
using Training.Domain.Sales;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerInfo>().ReverseMap();
        CreateMap<Customer, CreateCurstomerRequest>().ReverseMap();

        CreateMap<Product, ProductInfo>()
            .ForMember(Prop => Prop.SupplierInfo, Opt => Opt.MapFrom(Prop => Prop.Supplier.Name))
            .ForMember(Prop => Prop.BrandInfo, Opt => Opt.MapFrom(Prop => Prop.ProductBrand.Name))
            .ForMember(Prop => Prop.WarehouseInfo, Opt => Opt.MapFrom(Prop => Prop.Warehouse.Name))
            .ForMember(Prop => Prop.ProductTypeInfo, Opt => Opt.MapFrom(Prop => Prop.ProductType.Name))
            .ForMember(Prop => Prop.ProductPicturesInfo, Opt => Opt.MapFrom(Prop => Prop.ProductPictures));
    }
}