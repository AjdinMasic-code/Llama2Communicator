using CommunicationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("llama2-uncensored", httpClient =>
{
    var baseUrl = builder.Configuration.GetValue<string>("Llama2Settings:BaseUrl") ?? "";
    var port = builder.Configuration.GetValue<string>("Llama2Settings:Port") ?? "";
    var extension = builder.Configuration.GetValue<string>("Llama2Settings:Extension") ?? "";
    var fullUrl = $"{baseUrl}:{port}/{extension}/";
    httpClient.BaseAddress = new Uri(fullUrl);
});

builder.Services.AddTransient<ICommunicator, Communicator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();