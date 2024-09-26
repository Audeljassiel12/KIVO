using KIVO.Models.Dto;

namespace KIVO.Services.IServerces
{
    public interface IPacienteService
    {
        Task<string> AgregarPacienteAsync(PacienteDTO pacienteDTO, string userId);
        Task<PacienteDTO> ObtenerPacientePorIdAsync(int id);
        Task<PaginacionResult<PacienteDTO>> ObtenerPacientesPorCentroMedicoAsync(string userId, string? query = null, int pageNumber = 1, int pageSize = 10);
    }

}
