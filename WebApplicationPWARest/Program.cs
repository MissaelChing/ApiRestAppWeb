using Microsoft.EntityFrameworkCore;
using WebApplicationPWARest.Context;

var builder = WebApplication.CreateBuilder(args);
string Cords = "";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConexionSQL>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Missael")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cords, policy =>
    {
        policy.SetIsOriginAllowed(oring => new Uri(oring).Host == "localhost")
         .AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(Cords);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
