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
            .ForMember(Prop => Prop.SupplierName, Opt => Opt.MapFrom(Prop => Prop.Supplier.Name))
            .ForMember(Prop => Prop.BrandName, Opt => Opt.MapFrom(Prop => Prop.ProductBrand.Name))
            .ForMember(Prop => Prop.Price, Opt => Opt.MapFrom(Prop => Prop.ProductHistoric.Price.Amount))
            .ForMember(Prop => Prop.Currency, Opt => Opt.MapFrom(Prop => Prop.ProductHistoric.Price.Currency.Symbol))
            .ForMember(Prop => Prop.WarehouseName, Opt => Opt.MapFrom(Prop => Prop.Warehouse.Name))
            .ForMember(Prop => Prop.TypeName, Opt => Opt.MapFrom(Prop => Prop.ProductType.Name))
            .ForMember(Prop => Prop.ProductPictureInfos, Opt => Opt.MapFrom(Prop => Prop.ProductPictures));
    }
}