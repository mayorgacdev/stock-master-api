namespace Training.Application.Resources;

/// <summary>
///   A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
public static partial class TrainingMessages
{
    /// <summary>
    ///   Returns the cached ResourceManager instance used by this class.
    /// </summary>
    static TrainingMessages() => ResourceManager = new($"{typeof(TrainingMessages).Namespace}.{typeof(TrainingMessages).Name}", typeof(TrainingMessages).Assembly);

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
    /// <param name="Key">
    ///     ErrorCode used as key value.
    /// </param>
    /// <returns>
    ///     Return looks up a localized string .
    /// </returns>
    public static string? GetMessage(string Key) => ResourceManager.GetString(Key, Culture);
}
