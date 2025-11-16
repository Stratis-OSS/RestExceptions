namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/400"/>
/// </summary>
public class BadRequestRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Malformed request syntax.";

    public override string Title => "Bad Request";
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
