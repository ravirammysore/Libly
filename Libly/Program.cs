var builder = WebApplication.CreateBuilder(args);
//Stuff to do before you build the app, like requesting services you need
var app = builder.Build();
//Stuff to do after you build the app, like configure routes
app.MapGet("/", () => "Welcome to Libly!");
//finally run the app
app.Run();
