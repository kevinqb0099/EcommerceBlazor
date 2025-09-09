using Ecommerce.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;


using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.Implementacion;
using Ecommerce.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Implementación de dependecia del context
 
builder.Services.AddDbContext<DbecommerceContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

//Implementado la depedencia de clases 

builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio,VentaRepositorio>();

//Implementando el AutoMapper (Utilidades)
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
