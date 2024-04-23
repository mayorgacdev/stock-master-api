namespace Training.Common;

public record class ErrorResponse(string HttpMethod, string ServerHost, string EndpointPath, string? QueryString, object? RequestBody);
