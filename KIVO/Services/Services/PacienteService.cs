using AutoMapper;
using KIVO.Models.Data;
using KIVO.Models;
using KIVO.Services.IServerces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using KIVO.Models.Dto;

namespace KIVO.Services.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly KivoDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService cloudinaryService;

        public PacienteService(KivoDbContext context, IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _context = context;
            _mapper = mapper;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<string> AgregarPacienteAsync(PacienteDTO pacienteDTO, string userId)
        {
            // 1. Buscar el doctor que tiene el mismo ID de usuario
            var centroMedicoId = await _context.Medicos
                .Where(d => d.Id == userId) // Asegúrate de que 'Id' es la propiedad correcta en Medicos
                .Select(d => d.CentroMedicoId) // Selecciona solo el ID del Centro Médico
                .FirstOrDefaultAsync();

            if (centroMedicoId == 0)
            {
                throw new InvalidOperationException("No se encontró un Centro Médico asociado al médico.");
            }

            // 2. Mapear el DTO a la entidad Paciente
            var paciente = _mapper.Map<Paciente>(pacienteDTO);
            paciente.CentroMedicoId = centroMedicoId;
            paciente.Id = Guid.NewGuid().ToString();
            paciente.FotoPerfilUrl =await cloudinaryService.SubirImagenAsync(pacienteDTO.formFile);

            // 3. Agregar el paciente a la base de datos
            _context.Add(paciente);
            await _context.SaveChangesAsync();

            return paciente.Id!; // Retornar el ID del paciente agregado
        }

        public async Task<PacienteDTO> ObtenerPacientePorIdAsync(int id)
        {
            var paciente = await _context.Pacientes
                .FindAsync(id);

            if (paciente == null)
            {
                throw new KeyNotFoundException("Paciente no encontrado.");
            }

            return _mapper.Map<PacienteDTO>(paciente);
        }

        public async Task<PaginacionResult<PacienteDTO>> ObtenerPacientesPorCentroMedicoAsync(string userId, string? query = null, int pageNumber = 1, int pageSize = 10)
        {
            // Obtiene el ID del centro médico del médico correspondiente al userId
            var centroMedicoId = await _context.Medicos
                .Where(d => d.Id == userId)
                .Select(d => d.CentroMedicoId)
                .FirstOrDefaultAsync();

            // Consulta para filtrar los pacientes según el centro médico y la query
            var pacientesQuery = _context.Pacientes
                .Where(p => p.CentroMedicoId == centroMedicoId);

            // Filtrar por nombre o número de teléfono si se proporciona una query
            if (!string.IsNullOrWhiteSpace(query))
            {
                pacientesQuery = pacientesQuery.Where(p => p.Nombres.StartsWith(query) || p.Teléfono.StartsWith(query));
            }

            // Obtener el total de pacientes antes de la paginación
            var totalCount = await pacientesQuery.CountAsync();

            // Aplicar la paginación
            var pacientes = await pacientesQuery
                .OrderBy(p => p.Nombres) // Puedes cambiar esto por la propiedad que desees para ordenar
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<PacienteDTO>(_mapper.ConfigurationProvider) // Utiliza AutoMapper para proyectar
                .ToListAsync();

            // Crear un objeto de resultado de paginación
            return new PaginacionResult<PacienteDTO>
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Items = pacientes
            };
        }

    }

}
