using AutoMapper;
using CloudinaryDotNet;
using KIVO.AutoMapper;
using KIVO.DataMaster;
using KIVO.Filter;
using KIVO.Miiddleware;
using KIVO.Models;
using KIVO.Models.Data;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Data.Repository.Repository;
using KIVO.Models.Dto;
using KIVO.Models.UnityOfWork;
using KIVO.Services.IServerces;
using KIVO.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneNumbers;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<KivoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPasienteRepository, PasienteRepository>();
builder.Services.AddScoped<ICentroMedicoRepository, CentroMedicoRepositoy>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IEspesialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<ISuscripcionRepository, SuscripcionRepository>();
builder.Services.AddScoped<IPlanSuscripcionRepository, PlanSuscripcionRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<ICuidadRepository, CuidadRepositor>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<AccountServices>();
builder.Services.AddScoped<VerificarEstadoUsuarioAttribute>();
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Unit of Work
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

// Identity
builder.Services.AddIdentity<KIVO.Models.User, IdentityRole>()
    .AddEntityFrameworkStores<KivoDbContext>()
    .AddDefaultTokenProviders();

// Google Authentication
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});


 var cloudinaryUrl = Environment.GetEnvironmentVariable("CLOUDINARY_URL");
if (!string.IsNullOrEmpty(cloudinaryUrl))
{
    var cloudinary = new Cloudinary(cloudinaryUrl);
    cloudinary.Api.Secure = true; // Asegúrate de que las URLs generadas sean seguras
    builder.Services.AddSingleton(cloudinary);
}
else
{
    // Manejo de error si la variable no está configurada
    throw new Exception("CLOUDINARY_URL no está configurado en las variables de entorno.");
}

// Stripe
StripeConfiguration.ApiKey = "sk_test_51Q2etcB7yCB8tXwRVKwEurGDq8w2mSLu5ghwj53BrUrcerFIwLKy5yhUycy8VOs431F1gv1ziPXMDI35mmMl2YSX00wi2HoO4W";

// Carga la configuración SMTP desde appsettings.json
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.Configure<WhatsAppApiConfig>(builder.Configuration.GetSection("WhatsAppApi"));

// Registra el servicio EmailSender
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IMessageSender, WhatsAppMessageSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicialización de roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Crear roles al iniciar la aplicación
        await CreateRoles.CreateRolesData(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error creando los roles.");
    }
}

app.Run();
