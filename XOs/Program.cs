using Microsoft.AspNetCore.Mvc;
using XOs;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSignalR(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(600);
    options.KeepAliveInterval = TimeSpan.FromSeconds(60);
    options.MaximumParallelInvocationsPerClient = 2;
    options.EnableDetailedErrors = true;
    options.HandshakeTimeout = TimeSpan.FromSeconds(60);
});



var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();



app.MapHub<ChatHub>("/chatHub");    

app.MapGet("/", async (context) => context.Response.Redirect("/index.html"));

app.MapGet("/api/endgame", () => Data.ResetAll());



app.MapGet("/api/getfield", () =>
{
    var response = new
    {
        field = Data.field,
    };

    return Results.Json(response);
});

app.MapPost("/api/setplayer", ([FromQuery] string player) =>
{
    bool isSuccess = false;
    if(!(Data.players.Count == 2 || Data.players.FirstOrDefault() == player))
    {
        Data.players.Add(player);
        isSuccess = true;
    }

    var response = new
    {
        success = isSuccess,
        id = Data.players.IndexOf(player),
    };

    return Results.Json(response);
});

app.Run();
