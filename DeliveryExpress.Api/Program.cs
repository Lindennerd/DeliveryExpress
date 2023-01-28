using DeliveryExpress.Application;
using DeliveryExpress.Application.DeliveryRequestApplication.DependencyInjection;
using DeliveryExpress.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddDeliveryRequestModule()
    .AddDeliveryRequestRepository();

builder.Services.AddSignalR();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        _ = builder.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000");
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.AddSignalRSwaggerGen());

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<DeliveryExpressHub>("/deliveryExpressHub", options =>
{
    options.ApplicationMaxBufferSize = 1024 * 1024 * 10;
    options.TransportMaxBufferSize = 1024 * 1024 * 10;
});

app.Run();
