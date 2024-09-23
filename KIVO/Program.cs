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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<KivoDbContext>(option=>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPasienteRepository,PasienteRepository>();
builder.Services.AddScoped<ICentroMedicoRepository,CentroMedicoRepositoy>();
builder.Services.AddScoped<IMedicoRepository,MedicoRepository>();
builder.Services.AddScoped<IEspesialidadRepository,EspecialidadRepository>();
builder.Services.AddScoped<ISuscripcionRepository, SuscripcionRepository>();
builder.Services.AddScoped<IPlanSuscripcionRepository,PlanSuscripcionRepository>();
builder.Services.AddScoped<IUnityOfWork,UnityOfWork>();
builder.Services.AddScoped<AccountServices>();
builder.Services.AddIdentity<KIVO.Models.User, IdentityRole>().AddEntityFrameworkStores<KivoDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId =builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});
builder.Services.AddScoped<OrganizacionConfiguradaFilter>();
builder.Services.AddScoped<VerificarEstadoUsuarioAttribute>();


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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//    app.UseMiddleware<PhoneNumberVerificationMiddleware>("/Account/VerificarNumero", new[] {
//         "/Account/ResendVerificationCode", // Ruta para enviar el código de verificación
//         "/Account/VerificarNumeroPost"
//     });


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
