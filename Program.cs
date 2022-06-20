var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();