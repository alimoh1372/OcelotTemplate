using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var environmentEnvironmentName = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"ocelot{environmentEnvironmentName}.json", false, true);

builder.Services.AddOcelot(builder.Configuration);



var app = builder.Build();



app.Run();
