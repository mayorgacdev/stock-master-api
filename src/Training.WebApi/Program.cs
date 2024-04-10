using Training.Application.Proxies;
using Training.WebApi.Extensions;

var Builder = WebApplication.CreateBuilder(args);

Builder.Services.AddControllers().AddJsonOptions(static Options => Options.JsonSerializerOptions.PropertyNamingPolicy = JsonDefaultNamingPolicy.DefaultNamingPolicy); ;
Builder.Services.AddTrainingSwaggerGen();
Builder.Services.AddServicesFromAttribute();
Builder.Services.AddInfraestructure(Builder.Configuration);
Builder.Services.AddOutputCache(Options =>
{
    Options.AddBasePolicy(Builder => Builder.Expire(TimeSpan.FromSeconds(30)));
});
var app = Builder.Build();

app.UseTrainingSwaggerUI();
app.UseTrainingMiddlewares();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
