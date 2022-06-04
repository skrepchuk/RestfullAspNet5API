
using Microsoft.EntityFrameworkCore;
using RESTfullAPI.Model.Context;
using RESTfullAPI.Business;
using RESTfullAPI.Business.Implementation;
using RESTfullAPI.Repository.Implementation;
using RESTfullAPI.Repository;
using Serilog;

namespace RESTfullAPI
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        private readonly string _connectionString;
        private readonly MySqlServerVersion _serverVersion;
        private readonly string _environmentName;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            _environmentName = environment.EnvironmentName;

            _connectionString = Configuration["MySQLConnection:MySQLConnectionString"];
            _serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(_connectionString));
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning();

            
            services.AddDbContext<MySQLContext>(dbContextOptions => dbContextOptions
                .UseMySql(_connectionString, _serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                MigrationDatabase();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

        private void MigrationDatabase()
        {
            string location = _environmentName == Environments.Production || _environmentName == Environments.Staging
                ? "Database/migrations"
                : "Database";
            try
            {
                var evolveDataBaseConnection = new MySqlConnector.MySqlConnection(_connectionString);
                var evolve = new Evolve.Evolve(evolveDataBaseConnection, message => Log.Information(message))
                {
                    Locations = new[] { location },
                    IsEraseDisabled = true
                };
                evolve.Migrate();

            }
            catch (Exception error)
            {
                Log.Error("Database Migration Failed", error);
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
