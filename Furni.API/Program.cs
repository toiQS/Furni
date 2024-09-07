using Furni.Data;
using Furni.Services.blog;
using Furni.Services.cart;
using Furni.Services.item;
using Furni.Services.member;
using Furni.Services.product;
using Microsoft.Identity.Client;

var builder = WebApplication.CreateBuilder(args);

// Connect to sql server
builder.Services.AddDbContext<ApplicationDbContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add service model
builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
builder.Services.AddControllers();
builder.Services.AddScoped<IBlogServices, BlogServices>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<IItemServices, ItemServices>();
builder.Services.AddScoped<IMemberServices, MemberServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
