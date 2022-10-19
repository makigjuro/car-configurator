using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using VehicleInventory.Infrastructure.Domain;
using VehicleInventoryAPI;

namespace VehicleInventory.API;

public static class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true; 
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        builder.Services.AddControllers();
        builder.Services.AddMvc().AddControllersAsServices();
        builder.Services.AddRazorPages();
        builder.Services.AddHealthChecks();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vehicle Inventory API V1", Version = "v1" });
        });
        builder.WebHost.UseWebRoot("Pics");
        var autoServiceProviderFactory = new AutofacServiceProviderFactory();
        builder.Host.UseServiceProviderFactory(autoServiceProviderFactory)
            .ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                Startup.ConfigureServicesExtension(containerBuilder, builder.Services);
            });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseRouting(); 
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.MapHealthChecks("/health-check");
        app.UseSwagger();

        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle Inventory API V1"));

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.Urls.Add("http://*:5000");
        

        app.Run();
    }

}