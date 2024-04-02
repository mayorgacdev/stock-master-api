using Training.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTrainingSwaggerGen();
builder.Services.AddServicesFromAttribute();
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

app.UseTrainingSwaggerUI();
app.UseTrainingMiddlewares();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
