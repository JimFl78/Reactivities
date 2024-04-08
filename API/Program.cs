using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//required for secure application 
//app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();


//create the database - using (scope) destroyed after completing code
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    //can be done from command line
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (System.Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during database migration");
    throw;
}

app.Run();
