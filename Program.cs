
using AutoMapper;
using Kotabko.DataAccess;
using Kotabko.Repository.Classes;
using Kotabko.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
//             AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options => {options.Password.RequireUppercase = false;})
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Registering Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddScoped<IBookRepository,BookRepository>();


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();


///shopping card service
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(s => ShoppingCardRepository.GetshoppingCard(s));
builder.Services.AddSession();

//Register Auto Mapper
builder.Services.AddAutoMapper(typeof(Program));


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
app.UseSession();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
