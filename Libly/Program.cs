using Libly.Core.Data;
using Microsoft.EntityFrameworkCore;
using Libly.Services;

var builder = WebApplication.CreateBuilder(args);
//adds Razor Pages services to the DI container.
builder.Services.AddRazorPages();

// Register the API Client
builder.Services.AddHttpClient<ApiClient>();

//Before this, request all services required by the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Redirect to a custom error page    
    app.UseExceptionHandler("/Error"); 
}
/*
 * UseRouting means that we won't be hardcoding every route, rather
 * the framework should figure it out dynamically based on conventions
 */
app.UseRouting();
/*
 *  MapRazorPages() tells the app to look for Razor Pages in the Pages folder 
 *  and handle requests accordingly. Other option is MVC style controllers
 */
app.UseEndpoints(endpoints => endpoints.MapRazorPages());

//Before this, select which of the services to be used in the app
app.Run();


