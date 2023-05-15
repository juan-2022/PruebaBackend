using LBA_Dominios.ModelosConsultas;
using LBA_Infraestructura.Contratos;
using LBA_Negocio.Contratos;

namespace LBA_Negocio.Biblioteca
{
    public class ConsultaPrueba : IConsultaPrueba
    {
        private readonly IPruebaRepository _PruebaRepository;
        public ConsultaPrueba(IPruebaRepository bibliotecaRepository)
        {
            _PruebaRepository = bibliotecaRepository;
        }
        public async Task<string> ConsultaAutores()
        {
            string resultado = await _PruebaRepository.ConsultaAutores();
            return resultado;
        }
        public async Task<string> ConsultaEditoriales()
        {
            string resultado = await _PruebaRepository.ConsultaEditoriales();
            return resultado;
        }
        public async Task<string> ConsultaTodosLosLibros()
        {
            string resultado = await _PruebaRepository.ConsultaTodosLosLibros();
            return resultado;
        }
        public async Task<string> ConsultaLibroPorIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            string resultado = await _PruebaRepository.ConsultaLibroPorIsbn(consultaIsbnViewModel);
            return resultado;
        }
        public async Task<string> ConsultaTLAutoresDLibroPIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            string resultado = await _PruebaRepository.ConsultaTLAutoresDLibroPIsbn(consultaIsbnViewModel);
            return resultado;
        }
        public async Task<string> ConsultaEditorialLibroIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            string resultado = await _PruebaRepository.ConsultaEditorialLibroIsbn(consultaIsbnViewModel);
            return resultado;
        }


    }
}
