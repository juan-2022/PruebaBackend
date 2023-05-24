using LBA_Dominios.ModelosConsultas;
using LBA_Infraestructura.Contratos;
using LBA_Negocio.Contratos;

namespace LBA_Negocio.Biblioteca
{
    public class ConsultaPrueba : IConsultaPrueba
    {
        private readonly IPruebaRepository _PruebaRepository;
        public ConsultaPrueba(IPruebaRepository pruebaRepository)
        {
            _PruebaRepository = pruebaRepository;
        }
        public async Task<string> ObtenerToken()
        {
            string resultado = await _PruebaRepository.ObtenerToken();         
            return resultado;
        }
        public async Task<string> IniciarSesion(ConsultausuariosDto consultausuariosDto)
        {
            string resultado = await _PruebaRepository.IniciarSesion(consultausuariosDto);         
            return resultado;
        }
        
        public async Task<string> CursosAlumno(InformacionCursoDto informacionCursoDto)
        {
            string resultado = await _PruebaRepository.CursosAlumno(informacionCursoDto);         
            return resultado;
        }
        
        public async Task<string> AlumnosxNombre(InformacionEstudiante informacionEstudiante)
        {
            string resultado = await _PruebaRepository.AlumnosxNombre(informacionEstudiante);         
            return resultado;
        }
        public async Task<string> Alumnosxid(Estudiantexid estudiantexid)
        {
            string resultado = await _PruebaRepository.Alumnosxid(estudiantexid);         
            return resultado;
        }
       


    }
}
