using Shouldly;

namespace RestExceptions.IntegrationTests.Services;

public class RestExceptionsTests(ApiFactory factory) : ApiTests(factory), IClassFixture<ApiFactory>
{
    [Theory]
    [InlineData(0, "Internal Server Error")]
    [InlineData(400, "Bad Request")]
    [InlineData(401, "Unauthorized")]
    [InlineData(402, "Payment Required")]
    [InlineData(403, "Forbidden")]
    [InlineData(404, "Not Found")]
    [InlineData(405, "Method Not Allowed")]
    [InlineData(406, "Not Acceptable")]
    [InlineData(407, "Proxy Authentication Required")]
    [InlineData(408, "Request Timeout")]
    [InlineData(409, "Conflict")]
    [InlineData(410, "Gone")]
    [InlineData(411, "Length Required")]
    [InlineData(412, "Precondition Failed")]
    [InlineData(413, "Content Too Large")]
    [InlineData(414, "URI Too Long")]
    [InlineData(415, "Unsupported Media Type")]
    [InlineData(416, "Range Not Satisfiable")]
    [InlineData(417, "Expectation Failed")]
    [InlineData(421, "Misdirected Request")]
    [InlineData(422, "Unprocessable Content")]
    [InlineData(423, "Locked")]
    [InlineData(424, "Failed Dependency")]
    [InlineData(426, "Upgrade Required")]
    [InlineData(428, "Precondition Required")]
    [InlineData(429, "Too Many Requests")]
    [InlineData(431, "Request Header Fields Too Large")]
    [InlineData(451, "Unavailable For Legal Reasons")]
    [InlineData(500, "Internal Server Error")]
    [InlineData(501, "Not Implemented")]
    [InlineData(502, "Bad Gateway")]
    [InlineData(503, "Service Unavailable")]
    [InlineData(504, "Gateway Timeout")]
    [InlineData(505, "HTTP Version Not Supported")]
    [InlineData(506, "Variant Also Negotiates")]
    [InlineData(507, "Insufficient Storage")]
    [InlineData(508, "Loop Detected")]
    [InlineData(510, "Not Extended")]
    [InlineData(511, "Network Authentication Required")]
    public async Task Status_Code_To_Http_Error_Title(int statusCode, string expected)
    {
        // Act
        var problemDetails = await GetProblemDetailsAsync("error", statusCode);
        var result = problemDetails?.Title ?? string.Empty;

        // Assert
        result.ShouldBe(expected);
    }
}
