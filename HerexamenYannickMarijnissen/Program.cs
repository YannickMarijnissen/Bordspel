using HerexamenYannickMarijnissen;
using HerexamenYannickMarijnissen.Data.Repository;
using HerexamenYannickMarijnissen.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Specify the root component for the application
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register services with the dependency injection container
builder.Services.AddScoped<GameListViewModel>();
builder.Services.AddScoped<Repository>();

// Configure HttpClient for making HTTP requests
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Build and run the Blazor WebAssembly application
await builder.Build().RunAsync();
