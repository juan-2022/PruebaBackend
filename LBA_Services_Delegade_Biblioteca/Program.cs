using LBA_Infraestructura.Contratos;
using LBA_Infraestructura.Repositorios;
using LBA_Negocio.Biblioteca;
using LBA_Negocio.Contratos;
using LBA_Negocio.Fachada;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<IFachada, Fachada>();
builder.Services.AddScoped<IPruebaRepository, PruebaRepository>();
builder.Services.AddScoped<IConsultaPrueba, ConsultaPrueba>();
builder.Services.AddScoped<IComandosPrueba, ComandosPrueba>();


builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

