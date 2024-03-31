namespace Training.Application.Resources;


/// <summary>
///   A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
public static partial class ErrorCodeMessages
{
    /// <summary>
    ///   Returns the cached ResourceManager instance used by this class.
    /// </summary>
    static ErrorCodeMessages() => ResourceManager = new($"{typeof(ErrorCodeMessages).Namespace}.{typeof(ErrorCodeMessages).Name}", typeof(ErrorCodeMessages).Assembly);

    /// <summary>
    ///   Returns the cached ResourceManager instance used by this class.
    /// </summary>
    public static ResourceManager ResourceManager { get; }

    /// <summary>
    ///   Overrides the current thread's CurrentUICulture property for all
    ///   resource lookups using this strongly typed resource class.
    /// </summary>
    public static CultureInfo? Culture { get; set; }

    /// <summary>
    ///     Looks up a localized string.
    /// </summary>
    /// <param name="ErrorCode">
    ///     ErrorCode used as key value.
    /// </param>
    /// <returns>
    ///     Return looks up a localized string .
    /// </returns>
    public static string? GetMessageFromCode(string ErrorCode) => ResourceManager.GetString(ErrorCode, Culture);

    /// <summary>
    ///    Looks up a localized string similar to
    /// </summary>
    public static string DATAC0001 => ResourceManager.GetString(nameof(DATAC0001), Culture)!;


}