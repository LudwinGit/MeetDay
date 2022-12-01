using System.Text;
using MeetDay.Aplicacion.Core.Interfaces;
using MeetDay.Aplicacion.Core.Services;
using MeetDay.Dominio.Core.Entity;
using MeetDay.Dominio.Core.Interfaces.Repositories;
using MeetDay.Infraestructura.Output.Data.Postgresql.Contexts;
using MeetDay.Infraestructura.Output.Data.Postgresql.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("PostgreSQL");

builder.Services.AddControllersWithViews().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddDbContext<MeetDayContext>(
    options => options.UseNpgsql(connectionString, b =>
    {
        b.MigrationsAssembly("MeetDay.Infraestructura.Input.Web.Angular");
    }).LogTo(Console.WriteLine, LogLevel.Information)
);


// builder.Services.AddScoped<IGestionService<Gestion,Guid>,GestionService>();
// builder.Services.AddScoped<IOtherService<Gestion>, OtherService>();
builder.Services.AddScoped<IUserRepository<User, int>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false
        // ValidateIssuer = true,
        // ValidateAudience = true,
        // ValidateLifetime = true,
        // ValidateIssuerSigningKey = true,
        // ValidIssuer = builder.Configuration["Jwt:Issuer"],
        // ValidAudience = builder.Configuration["Jwt:Audience"],
        // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
