using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;
using LBA_Negocio.Contratos;

namespace LBA_Negocio.Fachada
{
    public class Fachada : IFachada
    {
        private readonly IConsultaPrueba _consultaPrueba;
        private readonly IComandosPrueba _comandosPrueba;

        public Fachada(IConsultaPrueba consultaPrueba, IComandosPrueba comandosPrueba)
        {
            _consultaPrueba = consultaPrueba;
            _comandosPrueba = comandosPrueba;
        }
        public Task<string> ConsultaAutores()
        {
            return _consultaPrueba.ConsultaAutores();
        }
        public Task<string> ConsultaEditoriales()
        {
            return _consultaPrueba.ConsultaEditoriales();
        }
        public Task<string> ConsultaTodosLosLibros()
        {
            return _consultaPrueba.ConsultaTodosLosLibros();
        }
        public Task<string> ConsultaLibroPorIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            return _consultaPrueba.ConsultaLibroPorIsbn(consultaIsbnViewModel);
        }
        public Task<string> ConsultaTLAutoresDLibroPIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            return _consultaPrueba.ConsultaTLAutoresDLibroPIsbn(consultaIsbnViewModel);
        }
        public Task<string> ConsultaEditorialLibroIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            return _consultaPrueba.ConsultaEditorialLibroIsbn(consultaIsbnViewModel);
        }
        public Task<string> RegistrarLibros(ComandoRegistroViewModel prospectivaViewModel)
        {
            return _comandosPrueba.RegistrarLibros(prospectivaViewModel);
        }

    }
}
