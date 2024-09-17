using KIVO.Models;
using KIVO.Models.Data;
using KIVO.Models.Data.Repository.IRepository;
using KIVO.Models.Data.Repository.Repository;
using KIVO.Models.Dto;
using KIVO.Services.IServerces;
using KIVO.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<KivoDbContext>(option=>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPasienteRepository,PasienteRepository>();
builder.Services.AddScoped<AccountServices>();
builder.Services.AddIdentity<KIVO.Models.User, IdentityRole>().AddEntityFrameworkStores<KivoDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId =builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

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

    app.UseBrowserLink();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
