using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;

namespace LBA_Infraestructura.Contratos
{
    public interface IPruebaRepository
    {
        Task<string> ObtenerToken();
        Task<string> ConteoVehiculos(InformacionDto informacionDto);
        Task<string> RecaudoVehiculos(InformacionDto informacionDto);
        Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel);
        Task<string> IniciarSesion(ConsultausuariosDto consultausuariosDto);

        Task<string> CursosAlumno(InformacionCursoDto informacionCursoDto);

        Task<string> AlumnosxNombre(InformacionEstudiante informacionEstudiante);

        Task<string> Alumnosxid(Estudiantexid estudiantexid);

    }
}
