namespace Training.Application.Constants;

/// <summary>
///     Prefijos usados para los códigos de error.
/// </summary>
public static class ErrorCodePrefix
{
    #region Services

    /// <summary>
    ///     Prefijo usado para los Servicios.
    /// </summary>
    private const string SERV = nameof(SERV);


    /// <summary>
    ///     Prefijo para la clase: <see cref="CustomerService" />
    /// </summary>
    public const string CustomerServicePrefix = $"{SERV}C";

    /// <summary>
    ///     Prefijo para la clase: <see cref="ProductService" />
    /// </summary>
    public const string WarehouseServicePrefix = $"{SERV}W";


    #endregion
}