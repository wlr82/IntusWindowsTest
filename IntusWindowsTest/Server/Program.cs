using DAL.Repositories.Contracts;
using DAL.Repositories;
using DAL;
using Microsoft.EntityFrameworkCore;
using Serilog;
using IntusWindowsTest.Server.Services.OrderService;
using IntusWindowsTest.Server.Services.StateService;
using IntusWindowsTest.Server.Services.WindowsService;
using IntusWindowsTest.Server.Services.ElementTypeService;
using IntusWindowsTest.Server.Services.SubElementsService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddRazorPages();

// DB
var dbConnectionString = builder.Configuration.GetValue<string>("ConnectionStrings:MySql");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseMySQL(dbConnectionString);
});
builder.Services.AddSingleton(sp => ApplicationDbContextFactoryInitializer.Create(dbConnectionString));
builder.Services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Ent services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IWindowService, WindowService>();
builder.Services.AddScoped<IElementTypeService, ElementTypeService>();
builder.Services.AddScoped<ISubElementsService, SubElementsService>();

var app = builder.Build();
InitializeDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

static void InitializeDatabase(IHost webHost)
{
    using (var scope = webHost.Services.CreateScope())
    {
        try
        {
            scope.ServiceProvider.GetRequiredService<ApplicationDBContext>().Database.Migrate();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred seeding the DB.");
        }
    }
}