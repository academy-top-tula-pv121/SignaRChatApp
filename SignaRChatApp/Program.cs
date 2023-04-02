using SignaRChatApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(hubOptions =>
{
    hubOptions.EnableDetailedErrors = true;
    hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat", mapOtions =>
{
    mapOtions.ApplicationMaxBufferSize = 128;
    mapOtions.TransportMaxBufferSize = 128;
});

app.Run();
