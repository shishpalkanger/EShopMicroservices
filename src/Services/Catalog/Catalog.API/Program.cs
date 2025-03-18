var builder = WebApplication.CreateBuilder(args);

//Add services to container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
}
);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
   // opts.AutoCreateSchemaObjects
}).UseLightweightSessions();

var app = builder.Build();

//Configure http request pipeline
app.MapCarter();
app.Run();
