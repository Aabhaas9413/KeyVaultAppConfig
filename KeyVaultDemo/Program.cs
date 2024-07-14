using Azure.Identity;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(new Uri(builder.Configuration["AppConfiguration:Endpoint"]), new DefaultAzureCredential())
           .Select(builder.Configuration["AppConfiguration:Key"])
           .ConfigureKeyVault(kv =>
           {
               kv.SetCredential(new DefaultAzureCredential());
           });
   // Register refresh for a specific key
   options.ConfigureRefresh(refreshOptions =>
   {
       refreshOptions.Register("TestApp:Settings:UseSampleKey")
                     .SetCacheExpiration(TimeSpan.FromMinutes(1));
   });
});
builder.Services.AddAzureAppConfiguration();
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
