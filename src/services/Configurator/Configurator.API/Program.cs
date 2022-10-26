using Autofac;
using Autofac.Extensions.DependencyInjection;
using Configurator.Infrastructure.Hubs;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Configurator.API;

public static class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            ContentRootPath = Directory.GetCurrentDirectory(),
        });

        builder.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true; 
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        
        var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                policy  =>
                {
                    policy.WithOrigins("http://localhost:3000",
                                        "http://localhost:3001");
                });
        });


        builder.Services.AddControllers();
        builder.Services.AddMvc().AddControllersAsServices();
        builder.Services.AddRazorPages();
        builder.Services.AddHealthChecks();
        builder.Services.AddSignalR();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Configurator API V1", Version = "v1" });
        });
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

        app.UseStaticFiles();
        app.UseCors(MyAllowSpecificOrigins);
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Configurator API V1"));

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<ConfiguratorActionsHub>("/configurator-actions");
        });

        app.Urls.Add("http://*:5001");
        

        app.Run();
    }

}