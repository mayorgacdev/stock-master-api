namespace Training.Infraestructure;

public class PagedResponse<T>
{
    public Pagination Pagination { get; }
    public IAsyncEnumerable<T> Data { get; }

    public PagedResponse(IAsyncEnumerable<T> data, Pagination pagination)
    {
        Data = data;
        Pagination = pagination;
    }
}

