using FluentValidation;
using MediatR;
using SampleLibrary.Behaviours;
using SampleLibrary.Car.Data;
using SampleLibrary.Car.Queries;
using SampleLibrary.Car.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IDataAccess, SampleDataAccess>();
builder.Services.AddMediatR(typeof(GetCarListQuery).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehaviour<,>));
builder.Services.AddValidatorsFromAssembly(typeof(InsertCarCommandValidator).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.DisplayRequestDuration(); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
