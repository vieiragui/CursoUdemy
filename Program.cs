using Blog.Context;
using Blog.Repository.Base;
using Blog.Repository.Interfaces;
using Blog.Repository;
using SixLabors.ImageSharp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDb"));
    });
builder.Services.AddMvcCore();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
