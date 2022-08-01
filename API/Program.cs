using API.GraphQL;
using API.Interfaces;
using API.Providers;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);
var defaultPolicy = "DefaultPolicy";

// Add services to the container.
builder.Services.AddSingleton<ITaskBookProviderDB, TaskBookProviderDB>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: defaultPolicy,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQL(b => b
                .AddHttpMiddleware<ISchema>()
                .AddSystemTextJson()
                .AddErrorInfoProvider()
                .AddSchema<TaskBookSchema>()
                .AddGraphTypes(typeof(TaskBookSchema).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(defaultPolicy);

app.UseAuthorization();

app.UseGraphQL<ISchema>();
app.UseGraphQLAltair("/");

app.MapControllers();

app.Run();
