using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KIVO.Migrations
{
    /// <inheritdoc />
    public partial class incial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadesMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadesMedicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concentracion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanSuscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracionEnDias = table.Column<int>(type: "int", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSuscripciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentroMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioAtencion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCentroMedico = table.Column<int>(type: "int", nullable: false),
                    CuidadId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroMedicos_Ciudades_CuidadId",
                        column: x => x.CuidadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CentroMedicos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorariosAtencion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    HoraApertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraCierre = table.Column<TimeSpan>(type: "time", nullable: false),
                    CentroMedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosAtencion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorariosAtencion_CentroMedicos_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvitacionesDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInvitacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaAceptada = table.Column<bool>(type: "bit", nullable: false),
                    EstaExpirada = table.Column<bool>(type: "bit", nullable: false),
                    CentroMedicoId = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitacionesDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitacionesDoctors_CentroMedicos_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentroMedicoId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadMedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_CentroMedicos_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_EspecialidadesMedicas_EspecialidadMedicoId",
                        column: x => x.EspecialidadMedicoId,
                        principalTable: "EspecialidadesMedicas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CentroMedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_CentroMedicos_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentroMedicoId = table.Column<int>(type: "int", nullable: false),
                    PlanSuscripcionId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suscripciones_CentroMedicos_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suscripciones_PlanSuscripciones_PlanSuscripcionId",
                        column: x => x.PlanSuscripcionId,
                        principalTable: "PlanSuscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationCodeExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HaConfiguradoOrganizacion = table.Column<bool>(type: "bit", nullable: false),
                    SelecionoPlan = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dirección = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teléfono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoSangre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocupación = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoPerfilUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CentroMedicoId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pacientes_CentroMedicos_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pacientes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentesFamiliaresPatologicos",
                columns: table => new
                {
                    AntecedentesFamiliaresPatologicosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Hepatitis = table.Column<bool>(type: "bit", nullable: true),
                    DetallesHepatitis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifilis = table.Column<bool>(type: "bit", nullable: true),
                    DetallesSifilis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TB = table.Column<bool>(type: "bit", nullable: true),
                    DetallesTB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colera = table.Column<bool>(type: "bit", nullable: true),
                    DetallesColera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amebiasis = table.Column<bool>(type: "bit", nullable: true),
                    DetallesAmebiasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tosferina = table.Column<bool>(type: "bit", nullable: true),
                    DetallesTosferina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sarampion = table.Column<bool>(type: "bit", nullable: true),
                    DetallesSarampion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varicela = table.Column<bool>(type: "bit", nullable: true),
                    DetallesVaricela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rubéola = table.Column<bool>(type: "bit", nullable: true),
                    DetallesRubéola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parotiditis = table.Column<bool>(type: "bit", nullable: true),
                    DetallesParotiditis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meningitis = table.Column<bool>(type: "bit", nullable: true),
                    DetallesMeningitis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impetigo = table.Column<bool>(type: "bit", nullable: true),
                    DetallesImpetigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiebreTifoidea = table.Column<bool>(type: "bit", nullable: true),
                    DetallesFiebreTifoidea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Escarlatina = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEscarlatina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Malaria = table.Column<bool>(type: "bit", nullable: true),
                    DetallesMalaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Escabiosis = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEscabiosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pediculosis = table.Column<bool>(type: "bit", nullable: true),
                    DetallesPediculosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tina = table.Column<bool>(type: "bit", nullable: true),
                    DetallesTina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otros = table.Column<bool>(type: "bit", nullable: true),
                    DetallesOtros = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesFamiliaresPatologicos", x => x.AntecedentesFamiliaresPatologicosId);
                    table.ForeignKey(
                        name: "FK_AntecedentesFamiliaresPatologicos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoDeCita = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CentroMedicoId = table.Column<int>(type: "int", nullable: false),
                    RecetaId = table.Column<int>(type: "int", nullable: true),
                    SignosVitalesId = table.Column<int>(type: "int", nullable: false),
                    ExploracionTopograficaId = table.Column<int>(type: "int", nullable: true),
                    ResultadoLaboratorioId = table.Column<int>(type: "int", nullable: true),
                    NutricionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_CentroMedicos_CentroMedicoId",
                        column: x => x.CentroMedicoId,
                        principalTable: "CentroMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dietas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Desayuno = table.Column<bool>(type: "bit", nullable: true),
                    DetallesDesayuno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MananaDeColacion = table.Column<bool>(type: "bit", nullable: true),
                    DetallesMananaDeColacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Almuerzo = table.Column<bool>(type: "bit", nullable: true),
                    DetallesAlmuerzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TardeDeColacion = table.Column<bool>(type: "bit", nullable: true),
                    DetallesTardeDeColacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<bool>(type: "bit", nullable: true),
                    DetallesCena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparadoEnCasa = table.Column<bool>(type: "bit", nullable: true),
                    DetallesPreparadoEnCasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelDeApetito = table.Column<int>(type: "int", nullable: true),
                    Saciedad = table.Column<bool>(type: "bit", nullable: true),
                    DetallesSaciedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDeVasosDeAgua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferenciasAlimentarias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesAlimentarias = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadesAlimentarias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suplementos = table.Column<bool>(type: "bit", nullable: true),
                    DetallesSuplementos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DietasPasadas = table.Column<bool>(type: "bit", nullable: true),
                    DetallesDietasPasadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoIdeal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallesPesoIdeal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesActualesRelacionadasConElPeso = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadesActualesRelacionadasConElPeso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DolenciasPasadasRelacionadasConElPeso = table.Column<bool>(type: "bit", nullable: true),
                    DetallesDolenciasPasadasRelacionadasConElPeso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngestaDeLiquidos = table.Column<bool>(type: "bit", nullable: true),
                    DetallesIngestaDeLiquidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducacionNutricional = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEducacionNutricional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otros = table.Column<bool>(type: "bit", nullable: true),
                    DetallesOtros = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dietas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadesHereditarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alergias = table.Column<bool>(type: "bit", nullable: true),
                    DetallesAlergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiabetesMellitus = table.Column<bool>(type: "bit", nullable: true),
                    DetallesDiabetesMellitus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HipertensionArterial = table.Column<bool>(type: "bit", nullable: true),
                    DetallesHipertensionArterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadReumatica = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadReumatica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesRenales = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadesRenales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesOculares = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadesOculares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesCardiacas = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadesCardiacas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadHepatica = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadHepatica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesMusculares = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadesMusculares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MalformacionesCongenitas = table.Column<bool>(type: "bit", nullable: true),
                    DetallesMalformacionesCongenitas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesordenesMentales = table.Column<bool>(type: "bit", nullable: true),
                    DetallesDesordenesMentales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadesDegenerativas = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEnfermedadesDegenerativas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnomaliasCrecimientoDesarrollo = table.Column<bool>(type: "bit", nullable: true),
                    DetallesAnomaliasCrecimientoDesarrollo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErroresMetabolismo = table.Column<bool>(type: "bit", nullable: true),
                    DetallesErroresMetabolismo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otros = table.Column<bool>(type: "bit", nullable: true),
                    DetallesOtros = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadesHereditarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnfermedadesHereditarias_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasObstetricasGinecologicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimeraCitaMenstruacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaFechaMenstruacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CaracteristicasMenstruacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Embarazos = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEmbarazos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerCuelloUterino = table.Column<bool>(type: "bit", nullable: true),
                    DetallesCancerCuelloUterino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerUtero = table.Column<bool>(type: "bit", nullable: true),
                    DetallesCancerUtero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancerMama = table.Column<bool>(type: "bit", nullable: true),
                    DetallesCancerMama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActividadSexual = table.Column<bool>(type: "bit", nullable: true),
                    DetallesActividadSexual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetodosControlNatalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerapiaReemplazoHormonal = table.Column<bool>(type: "bit", nullable: true),
                    DetallesTerapiaReemplazoHormonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaPruebaPapanicolaou = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaMastografia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Otro = table.Column<bool>(type: "bit", nullable: true),
                    DetallesOtro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasObstetricasGinecologicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriasObstetricasGinecologicas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasPostnatales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RevisiónNacimiento = table.Column<bool>(type: "bit", nullable: true),
                    DetallesRevisionNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreBebe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoAlNacer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaludBebe = table.Column<bool>(type: "bit", nullable: true),
                    DetallesSaludBebe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlimentacionInfantil = table.Column<bool>(type: "bit", nullable: true),
                    TipoAlimentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEmocional = table.Column<bool>(type: "bit", nullable: true),
                    DetallesEstadoEmocional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasPostnatales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriasPostnatales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasPsiquiatricas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcienciaEnfermedad = table.Column<bool>(type: "bit", nullable: true),
                    DetallesConcienciaEnfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApoyoFamiliaresAmigos = table.Column<bool>(type: "bit", nullable: true),
                    DetallesApoyoFamiliaresAmigos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VidaFamiliar = table.Column<bool>(type: "bit", nullable: true),
                    VidaSocial = table.Column<bool>(type: "bit", nullable: true),
                    VidaLaboral = table.Column<bool>(type: "bit", nullable: true),
                    RelacionConAutoridad = table.Column<bool>(type: "bit", nullable: true),
                    ControlImpulsos = table.Column<bool>(type: "bit", nullable: true),
                    LidiaConEstres = table.Column<bool>(type: "bit", nullable: true),
                    DetallesVidaFamiliar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallesVidaSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallesVidaLaboral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallesRelacionConAutoridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallesControlImpulsos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallesLidiaConEstres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasPsiquiatricas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriasPsiquiatricas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargoPorConsultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalParcial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoPorConsultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoPorConsultas_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCIE10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    CitaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExploracionesTopograficas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    ParteDelCuerpo = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExploracionesTopograficas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExploracionesTopograficas_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasDeEncuentros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasDeEncuentros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasDeEncuentros_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nutriciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    PerdidaPeso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Agua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcentajeGrasaCorporal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MasaMuscular = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cintura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Abdomen = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutriciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nutriciones_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recetas_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recetas_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultadosLaboratorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    TipoPrueba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPrueba = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadosLaboratorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadosLaboratorios_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignosVitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatura = table.Column<double>(type: "float", nullable: true),
                    Peso = table.Column<double>(type: "float", nullable: true),
                    Temperatura = table.Column<double>(type: "float", nullable: true),
                    FrecuenciaRespiratoria = table.Column<double>(type: "float", nullable: true),
                    Sistolica = table.Column<double>(type: "float", nullable: true),
                    Diastolica = table.Column<double>(type: "float", nullable: true),
                    FrecuenciaCardiaca = table.Column<double>(type: "float", nullable: true),
                    MasaCorporal = table.Column<double>(type: "float", nullable: true),
                    PorcentajeGrasaCorporal = table.Column<double>(type: "float", nullable: true),
                    MasaMuscular = table.Column<double>(type: "float", nullable: true),
                    PerimetroCefalico = table.Column<double>(type: "float", nullable: true),
                    SaturacionOxigeno = table.Column<double>(type: "float", nullable: true),
                    PorcentajeAgua = table.Column<double>(type: "float", nullable: true),
                    PorcentajeGrasaVisceral = table.Column<double>(type: "float", nullable: true),
                    Huesos = table.Column<double>(type: "float", nullable: true),
                    Metabolismo = table.Column<double>(type: "float", nullable: true),
                    PorcentajeProteinas = table.Column<double>(type: "float", nullable: true),
                    EdadCuerpo = table.Column<double>(type: "float", nullable: true),
                    PerimetroAbdominal = table.Column<double>(type: "float", nullable: true),
                    CitaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignosVitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignosVitales_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetasMedicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<int>(type: "int", nullable: true),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frecuencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetasMedicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetasMedicamentos_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetasMedicamentos_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Departamento 1" },
                    { 2, "Departamento 2" },
                    { 3, "Departamento 3" }
                });

            migrationBuilder.InsertData(
                table: "EspecialidadesMedicas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cardiología" },
                    { 2, "Pediatría" },
                    { 3, "Dermatología" },
                    { 4, "Oftalmología" },
                    { 5, "Neurología" },
                    { 6, "Ginecología" },
                    { 7, "Psiquiatría" },
                    { 8, "Ortopedia" },
                    { 9, "Neumología" },
                    { 10, "Endocrinología" },
                    { 11, "Gastroenterología" },
                    { 12, "Oncología" },
                    { 13, "Urología" },
                    { 14, "Nefrología" },
                    { 15, "Hematología" },
                    { 16, "Infectología" },
                    { 17, "Reumatología" },
                    { 18, "Otorrinolaringología" },
                    { 19, "Toxicología" }
                });

            migrationBuilder.InsertData(
                table: "PlanSuscripciones",
                columns: new[] { "Id", "Descripcion", "DuracionEnDias", "IsFree", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Plan básico sin costo.", 0, false, "Básico", 0m },
                    { 2, "Plan estándar con acceso a consultas.", 0, false, "Estándar", 50m },
                    { 3, "Plan premium con acceso completo a servicios.", 0, false, "Premium", 100m }
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Ciudad 1" },
                    { 2, 2, "Ciudad 2" },
                    { 3, 3, "Ciudad 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentesFamiliaresPatologicos_PacienteId",
                table: "AntecedentesFamiliaresPatologicos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MedicoId",
                table: "AspNetUsers",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CargoPorConsultas_CitaId",
                table: "CargoPorConsultas",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroMedicos_CuidadId",
                table: "CentroMedicos",
                column: "CuidadId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroMedicos_DepartamentoId",
                table: "CentroMedicos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_CentroMedicoId",
                table: "Citas",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MedicoId",
                table: "Citas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteId",
                table: "Citas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_CitaId",
                table: "Diagnosticos",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_PacienteId",
                table: "Dietas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadesHereditarias_PacienteId",
                table: "EnfermedadesHereditarias",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExploracionesTopograficas_CitaId",
                table: "ExploracionesTopograficas",
                column: "CitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasObstetricasGinecologicas_PacienteId",
                table: "HistoriasObstetricasGinecologicas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasPostnatales_PacienteId",
                table: "HistoriasPostnatales",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasPsiquiatricas_PacienteId",
                table: "HistoriasPsiquiatricas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosAtencion_CentroMedicoId",
                table: "HorariosAtencion",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitacionesDoctors_CentroMedicoId",
                table: "InvitacionesDoctors",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_CentroMedicoId",
                table: "Medicos",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadMedicoId",
                table: "Medicos",
                column: "EspecialidadMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasDeEncuentros_CitaId",
                table: "NotasDeEncuentros",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutriciones_CitaId",
                table: "Nutriciones",
                column: "CitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CentroMedicoId",
                table: "Pacientes",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CiudadId",
                table: "Pacientes",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DepartamentoId",
                table: "Pacientes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UserId",
                table: "Pacientes",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CentroMedicoId",
                table: "Productos",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_CitaId",
                table: "Recetas",
                column: "CitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_MedicamentoId",
                table: "Recetas",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetasMedicamentos_MedicamentoId",
                table: "RecetasMedicamentos",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetasMedicamentos_RecetaId",
                table: "RecetasMedicamentos",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosLaboratorios_CitaId",
                table: "ResultadosLaboratorios",
                column: "CitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SignosVitales_CitaId",
                table: "SignosVitales",
                column: "CitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_CentroMedicoId",
                table: "Suscripciones",
                column: "CentroMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_PlanSuscripcionId",
                table: "Suscripciones",
                column: "PlanSuscripcionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntecedentesFamiliaresPatologicos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CargoPorConsultas");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Dietas");

            migrationBuilder.DropTable(
                name: "EnfermedadesHereditarias");

            migrationBuilder.DropTable(
                name: "ExploracionesTopograficas");

            migrationBuilder.DropTable(
                name: "HistoriasObstetricasGinecologicas");

            migrationBuilder.DropTable(
                name: "HistoriasPostnatales");

            migrationBuilder.DropTable(
                name: "HistoriasPsiquiatricas");

            migrationBuilder.DropTable(
                name: "HorariosAtencion");

            migrationBuilder.DropTable(
                name: "InvitacionesDoctors");

            migrationBuilder.DropTable(
                name: "NotasDeEncuentros");

            migrationBuilder.DropTable(
                name: "Nutriciones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "RecetasMedicamentos");

            migrationBuilder.DropTable(
                name: "ResultadosLaboratorios");

            migrationBuilder.DropTable(
                name: "SignosVitales");

            migrationBuilder.DropTable(
                name: "Suscripciones");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "PlanSuscripciones");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "CentroMedicos");

            migrationBuilder.DropTable(
                name: "EspecialidadesMedicas");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
