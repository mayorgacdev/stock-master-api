namespace Training.Application.Mapping;

using Azure.Core;
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
        CreateMap<ProductBrand, ProductBrandInfo>().ReverseMap();
        CreateMap<ProductPrice, ProductPriceInfo>()
            .ForMember(Prop => Prop.Price, Opt => Opt.MapFrom(Prop => Prop.Price.Amount)).ReverseMap();

        CreateMap<ProductPicture, PictureInfo>().ReverseMap();

        CreateMap<Warehouse, WarehouseInfo>().ReverseMap();
        CreateMap<ProductType, ProductTypeInfo>().ReverseMap();
        CreateMap<Accesory, AccesoryInfo>().ForMember(Prop => Prop.PurchasePrice, Opt => Opt.MapFrom(Prop 
             => Prop.PurchasePrice.Amount))
            .ForMember(Prop => Prop.Price, Opt => Opt.MapFrom(Prop => Prop.Price.Amount));

        CreateMap<Product, ProductInfo>()
            .ForMember(Prop => Prop.SupplierInfo, Opt => Opt.MapFrom(Prop => Prop.Supplier))
            .ForMember(Prop => Prop.BrandInfo, Opt => Opt.MapFrom(Prop => Prop.ProductBrand))
            .ForMember(Prop => Prop.WarehouseInfo, Opt => Opt.MapFrom(Prop => Prop.Warehouse))
            .ForMember(Prop => Prop.ProductTypeInfo, Opt => Opt.MapFrom(Prop => Prop.ProductType))
            .ForMember(Prop => Prop.PriceInfo, Opt => Opt.MapFrom(Prop => Prop.ProductPrices))
            .ForMember(Prop => Prop.Pictures, Opt => Opt.MapFrom(Prop => Prop.ProductPictures));
    }
}

public static class BasicMappingExtensions
{

    public static ProductPicture AsProductPicture(this CreateProductPictureRequest request)
        => ProductPicture.Create(request.PictureUrl);

    public static IEnumerable<AccesoryDetailInfo> AsAccesoryDetailInfo(this IEnumerable<AccesoryDetail> request)
        => request.Select(req => AccesoryDetailInfo.Create(
            request.SingleOrDefault()!.ProductId,
            request.Select(e => e.AccesoryId)));

    public static Accesory AsAccesory(this CreateAccesoryRequest request)
        => Accesory.Create(
            new Domain.Common.Money(request.Price,
                new Domain.Common.Currency(request.Currency)),
            new Domain.Common.Money(request.PurchaseAmount,
                new Domain.Common.Currency(request.Currency)),
            request.Stock,
            request.Name,
            request.Description,
            request.Notes,
            request.IsActive);

    public static Part AsPart(this CreatePartRequest Request)
        => Part.Create(
            new Domain.Common.Money(Request.Price,
                new Domain.Common.Currency(Request.Currency)),
            new Domain.Common.Money(Request.PurchaseAmount, 
                new Domain.Common.Currency(Request.Currency)), 
            Request.Name, 
            Request.Description, 
            Request.IsActive);
}