using ETicaretAPI.Application;
using ETicaretAPI.Application.Validators.Product;
using ETicaretAPI.Infastructure.Filters;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
