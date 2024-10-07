using Microsoft.EntityFrameworkCore;
using RealEstateManagement.DAO.Configurations;
using RealEstateManagement.DAO.Repositories.EF;
using RealEstateManagement.Domain.ClientModule;

namespace RealEstateManagement.DAO;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Dependency injection, automatic object creation
        // Repos
        builder.Services.AddTransient<RealEstateDbContext>();
        builder.Services.AddTransient<IClientService, ClientService>();
        builder.Services.AddTransient<IClientRepository, ClientRepository>();


        builder.Services.Configure<ConnectionStrings>( 
            builder.Configuration.GetSection("ConnectionStrings")); // This initializes an object, which is passed in the RealEstateDbContexdt constructor 
        

        var app = builder.Build();

        var db = app.Services.GetService<RealEstateDbContext>();
        db.Seed();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Clients}/{action=Index}/{id?}");

        app.Run();
    }
}
