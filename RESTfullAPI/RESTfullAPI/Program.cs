using RESTfullAPI;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app,app.Environment);

app.Run();
