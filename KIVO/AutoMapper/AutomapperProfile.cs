using AutoMapper;
using KIVO.Models;
using KIVO.Models.Dto;

namespace KIVO.AutoMapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<Paciente,PacienteDTO>();
        }
    }
}
