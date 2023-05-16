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
       


    }
}
