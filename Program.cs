using AgendaAPI.Context;
using AgendaAPI.Models;
using AgendaAPI.Services;
using AgendaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextDB>(opt =>
{
    opt.UseSqlServer("Server=tcp:agendaserverdatabase.database.windows.net,1433;Initial Catalog=Agenda;Persist Security Info=False;User ID=p82regaa;Password=Qwerty12345.-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
});

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IContextDB, ContextDB>();

builder.Services.AddControllers(); // Agrega soporte para controladores

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Agenda",
        Description = "API desarrollada para la aplicación Agenda"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
});

//// GET todos los contactos
//app.MapGet("/api/contactos", async (Contexto context) =>
//{
//    var contactos = await context.ContactoEntity.ToListAsync();
//    return Results.Ok(contactos);
//})
//.WithDescription("Obtiene todos los contactos.");

//// GET los contactos con un nombre concreto
//app.MapGet("/api/contactos/nombre", async (Contexto context, string nombre) =>
//{
//    var contactos = await context.ContactoEntity
//                                .Where(c => c.Nombre == nombre)
//                                .ToListAsync();
//    return Results.Ok(contactos);
//})
//.WithDescription("Obtiene todos los contactos con un nombre concreto.");

//// GET todas las citas
//app.MapGet("/api/citas", async (Contexto context) =>
//{
//    var citas = await context.CitaEntity.Include(c => c.Contacto).ToListAsync();
//    return Results.Ok(citas);
//})
//.WithDescription("Obtiene todas las citas.");

//// GET las citas de una fecha concreta
//app.MapGet("/api/citas/fecha", async (Contexto context, DateTime fechaHora) =>
//{
//    var citas = await context.CitaEntity
//                            .Where(c => c.FechaHora.Date == fechaHora.Date)
//                            .ToListAsync();

//    return Results.Ok(citas);
//})
//.WithDescription("Obtiene las citas de una fecha concreta.")
//.WithMetadata(new OpenApiParameter
//{
//    Name = "fechaHora",
//    In = ParameterLocation.Query,
//    Required = true,
//    Description = "La fecha y hora de las citas."
//});

//// GET las citas de un contacto concreto
//app.MapGet("/api/citas/idContacto", async (Contexto context, int idContacto) =>
//{
//    var citas = await context.CitaEntity
//                            .Where(c => c.ContactoId == idContacto)
//                            .ToListAsync();

//    return Results.Ok(citas);
//})
//.WithDescription("Obtiene las citas de un contacto concreto.")
//.WithMetadata(new OpenApiParameter
//{
//    Name = "idContacto",
//    In = ParameterLocation.Query,
//    Required = true,
//    Description = "El ID del contacto."
//});

//// POST un nuevo contacto
//app.MapPost("/api/contacto", async (ContactoRequest request, IContactoService contactoService) =>
//{
//    var createContacto = await contactoService.CrearContacto(request);
//    return Results.Created($"/contactos/{createContacto.Id}", createContacto);
//})
//.WithDescription("Crea un nuevo contacto.")
//.WithMetadata(new OpenApiParameter
//{
//    Name = "request",
//    In = ParameterLocation.Query,
//    Required = true,
//    Description = "La información del nuevo contacto."
//});

//// POST una nueva cita
//app.MapPost("/api/cita", async (CitaRequest request, ICitaService citaService) =>
//{
//    var createCita = await citaService.CrearCita(request);
//    return Results.Created($"/citas/{createCita.Id}", createCita);
//})
//.WithDescription("Crea una nueva cita.")
//.WithMetadata(new OpenApiParameter
//{
//    Name = "request",
//    In = ParameterLocation.Query,
//    Required = true,
//    Description = "La información de la nueva cita."
//});

app.MapControllers(); // Mapea los controladores


app.Run();
