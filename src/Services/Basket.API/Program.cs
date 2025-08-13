using Basket.API.GrpcServices;
using Basket.API.Repository;
using Discounts.Grpc.Protos;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options => 
{ 
    options.Configuration = builder.Configuration.GetConnectionString("BasketDB");
});
builder.Services.AddGrpcClient<DiscountsProtoService.DiscountsProtoServiceClient>(options=> options.Address =new Uri(builder.Configuration.GetValue<string>("GrpcSettings:DiscountGrpcUrl")));
builder.Services.AddScoped<DiscountGrpcService>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
