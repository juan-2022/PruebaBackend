using LBA_Infraestructura.Contratos;
using LBA_Infraestructura.Repositorios;
using LBA_Negocio.Biblioteca;
using LBA_Negocio.Contratos;
using LBA_Negocio.Fachada;
using LBA_Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
            
        });
});
// Add services to the container.
builder.Services.AddScoped<IFachada, Fachada>();
builder.Services.AddScoped<IPruebaRepository, PruebaRepository>();
builder.Services.AddScoped<IConsultaPrueba, ConsultaPrueba>();
builder.Services.AddScoped<IComandosPrueba, ComandosPrueba>();

builder.Services.AddScoped<UserServices>();

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

