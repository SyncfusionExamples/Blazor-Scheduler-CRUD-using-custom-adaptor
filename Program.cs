using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using syncfusion_blazor_app.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() +"\\AppData\\AppointmentDataDB-bc.mdf;Integrated Security=True";
builder.Services.AddDbContext<AppointmentDataContext>(opts => opts.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<AppointmentDataService>();
builder.Services.AddScoped<AppointmentDataAdaptor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.Run();
