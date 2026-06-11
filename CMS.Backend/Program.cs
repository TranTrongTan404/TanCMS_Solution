using Microsoft.EntityFrameworkCore;
using CMS.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// =========================
// Đăng ký DbContext
// =========================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// =========================
// Đăng ký MVC + API
// =========================
builder.Services.AddControllersWithViews();

// =========================
// Swagger
// =========================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// =========================
// CẤU HÌNH CORS CHO REACTJS
// =========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// =========================
// Cookie Authentication
// =========================
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// =========================
// Authorization
// =========================
builder.Services.AddAuthorization();

var app = builder.Build();

// =========================
// Swagger
// =========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "TanCMS Web API v1");

        c.RoutePrefix = "swagger";
    });
}

// =========================
// Configure HTTP Pipeline
// =========================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// =========================
// Kích hoạt CORS
// Phải nằm sau UseRouting()
// và trước Authentication/Authorization
// =========================
app.UseCors("AllowReactApp");

// =========================
// Authentication
// =========================
app.UseAuthentication();

// =========================
// Authorization
// =========================
app.UseAuthorization();

// =========================
// Map API Controllers
// =========================
app.MapControllers();

// =========================
// Map MVC Controllers
// =========================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();