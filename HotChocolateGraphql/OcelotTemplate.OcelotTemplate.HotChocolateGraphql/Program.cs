using GraphQL.Server.Ui.Voyager;
using OcelotTemplate.OcelotTemplate.HotChocolateGraphql.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var env = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings.{env}.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.json", true, true);
builder.Services.AddDependencyInjection(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGraphQL();
});

app.UseGraphQLVoyager("/Voyager-Ui",new VoyagerOptions
{
    GraphQLEndPoint = "/graphql"
});
app.UseHttpLogging();
app.Run();
