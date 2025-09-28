using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
long Lcm(long a, long b) => a / Gcd(a, b) * b;

app.MapGet("/andrei_ziber22_gmail_com", (HttpRequest req) =>
{
    if (!long.TryParse(req.Query["x"], out var x) ||
        !long.TryParse(req.Query["y"], out var y) ||
        x <= 0 || y <= 0)
    {
        return Results.Text("NaN");
    }
    return Results.Text(Lcm(x, y).ToString());
});

app.Run();
