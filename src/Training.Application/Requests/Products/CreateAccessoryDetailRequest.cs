namespace Training.Application.Requests.Products;

using Training.Application.Attributes;
using Training.Domain.Inventory;

[Validator<CreateAccessoryDetailValidator>]
public class CreateAccessoryDetailRequest : IRequest
{
    public required CreateAccesoryRequest[] CreateAccesoriesRequest { get; set; }
    public required string ProductId { get; set; }
y}

public static class CreateAccessoryDetailRequestExtensions
{
    public static IEnumerable<AccesoryDetailInfo> AsAccesoryDetailInfo(this IEnumerable<AccesoryDetail> request)
        => request.Select(req => AccesoryDetailInfo.Create(
            request.ElementAt(0).ProductId,
            request.Select(e => e.AccesoryId)));
}

public class AccesoryDetailInfo
{
    public Guid ProductId { get; set; } = Guid.Empty;
    public Guid[] AccesoryId { get; set; } = Array.Empty<Guid>();

    public static AccesoryDetailInfo Create(Guid productId, IEnumerable<Guid> accesoriesId)
        => new()
        {
            ProductId = productId,
            AccesoryId = accesoriesId,
        };
}