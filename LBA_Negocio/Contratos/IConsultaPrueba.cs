using LBA_Dominios.ModelosConsultas;

namespace LBA_Negocio.Contratos
{
    public interface IConsultaPrueba
    {
        Task<string> ObtenerToken();

        Task<string> IniciarSesion(ConsultausuariosDto consultausuariosDto);

        Task<string> CursosAlumno(InformacionCursoDto informacionCursoDto);

        Task<string> AlumnosxNombre(InformacionEstudiante informacionEstudiante);

        Task<string> Alumnosxid(Estudiantexid estudiantexid);
    }
}
