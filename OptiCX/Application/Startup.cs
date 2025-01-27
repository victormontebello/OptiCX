using Infraestructure.Rds;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class Startup
{
    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        var sqlConnectionString = Configuration.GetConnectionString("PostgresSqlConnectionString")?
            .Replace("{{DBHOST}}", Environment.GetEnvironmentVariable("AWS_RDS_ENDPOINT"));
        
        services.AddDbContext<RdsDbContext>(options => options.UseNpgsql(sqlConnectionString));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
        Migrate(app);
    }

    private void Migrate(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<RdsDbContext>();
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            
            if (!pendingMigrations.Any())
                return;
            
            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error migrating database: {ex.Message}");
            }
        }
    }
}