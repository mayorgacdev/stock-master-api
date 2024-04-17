namespace Training.Application.Mapping;

using Training.Application.Requests;
using Training.Application.Requests.Products;
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

        CreateMap<Supplier, SupplierInfo>().ReverseMap();
        CreateMap<ProductBrand, BrandInfo>().ReverseMap();
        CreateMap<Warehouse, WarehouseInfo>().ReverseMap();
        CreateMap<ProductType, ProductTypeInfo>().ReverseMap();

        CreateMap<Product, ProductInfo>()
            .ForMember(Prop => Prop.SupplierInfo, Opt => Opt.MapFrom(Prop => Prop.Supplier))
            .ForMember(Prop => Prop.BrandInfo, Opt => Opt.MapFrom(Prop => Prop.ProductBrand))
            .ForMember(Prop => Prop.WarehouseInfo, Opt => Opt.MapFrom(Prop => Prop.Warehouse))
            .ForMember(Prop => Prop.ProductTypeInfo, Opt => Opt.MapFrom(Prop => Prop.ProductType));
    }
}

public static class BasicMappingExtensions
{

    public static ProductPicture AsProductPicture(this CreateProductPictureRequest request)
        => ProductPicture.Create(request.PictureUrl);
}