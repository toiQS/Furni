using Furni.Data;
using Furni.Services.auth;
using Furni.Services.blog;
using Furni.Services.cart;
using Furni.Services.item;
using Furni.Services.member;
using Furni.Services.product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

// add service model
builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
builder.Services.AddControllers();
builder.Services.AddScoped<IBlogServices, BlogServices>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<IItemServices, ItemServices>();
builder.Services.AddScoped<IMemberServices, MemberServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
//builder.Services.AddScoped<IAuthServices, AuthServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cart}/{action=Index}/{id?}");

app.Run();
