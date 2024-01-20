using IntusWindowsTest.Client;
using IntusWindowsTest.Client.Services.OrderService;
using IntusWindowsTest.Client.Services.StateService;
using IntusWindowsTest.Client.Services.WindowService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("IntusWindowsTest.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("IntusWindowsTest.ServerAPI"));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IWindowService, WindowService>();

await builder.Build().RunAsync();