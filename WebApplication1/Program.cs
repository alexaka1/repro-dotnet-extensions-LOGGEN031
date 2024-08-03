var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.Run();

partial class Foo(ILogger<Foo> logger)
{
    private readonly ILogger<Foo> _logger = logger;

    // errors with LOGGEN031
    [LoggerMessage(LogLevel.Trace, "Some message {@SomeProperty}")]
    private partial void LogSomeMessage(int someProperty);

    // works fine
    [LoggerMessage(LogLevel.Trace, "Some message {SomeProperty}")]
    private partial void LogSomeMessageWithoutAt(int someProperty);
}
