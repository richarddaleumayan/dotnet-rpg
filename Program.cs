using dotnet_rpg.Services.CharacterService;
using dotnet_rpg.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// TODO: Use appsettings.json value for the default database connection string
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Server=DESKTOP-2VEHCL6; Database=dotnet-rpg2; Trusted_Connection=true;"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
