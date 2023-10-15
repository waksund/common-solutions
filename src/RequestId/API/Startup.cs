using API.Middlewares;
using API.Services;
using API.Common;

namespace API;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<SessionData>();
        services.AddTransient<RequestIdService>();
        services.AddTransient<ExternalApiService>();
        services.AddTransient<HttpSendHelper>();

        services.AddHttpClient<HttpSendHelper>();
        
        services.AddControllers();
        services.AddMvc();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<RequestIdMiddleware>();
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}