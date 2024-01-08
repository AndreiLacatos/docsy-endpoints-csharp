using Docsy.Endpoints.Extensions;
using Docsy.Endpoints.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddSliceServices(builder.Configuration);

var app = builder.Build();

app.MapGrpcService<GrpcCollectionService>();
app.MapGrpcService<GrpcEndpointService>();

app.Run();
