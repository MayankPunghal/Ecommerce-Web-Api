using System.Text;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string requestBody = await ReadRequestBody(context.Request);

        // Log the entire request as a string
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        Console.WriteLine($"Request Body: {requestBody}");

        await _next(context);
    }

    private async Task<string> ReadRequestBody(HttpRequest request)
    {
        request.EnableBuffering(); // Enable rewinding the request body

        using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
        {
            string requestBody = await reader.ReadToEndAsync();
            request.Body.Position = 0; // Rewind the request body
            return requestBody;
        }
    }
}
