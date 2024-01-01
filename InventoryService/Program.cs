using InventoryService.AsyncDataServices;
using InventoryService.Data;
using InventoryService.EventProcessing;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.EventProcessing;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:4200",
                                              "http://localhost:4200");
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("in development");
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

}
else
{
    Console.WriteLine("Using Sql server");
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));

}
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IEventProcessor, EventProcesing>();
builder.Services.AddHostedService<MessageBusSubscriber>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app, app.Environment.IsDevelopment());

app.Run();
