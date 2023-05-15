using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;

namespace LBA_Infraestructura.Contratos
{
    public interface IPruebaRepository
    {
        Task<string> ConsultaAutores();
        Task<string> ConsultaEditoriales();
        Task<string> ConsultaTodosLosLibros();
        Task<string> ConsultaLibroPorIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        Task<string> ConsultaTLAutoresDLibroPIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        Task<string> ConsultaEditorialLibroIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel);

    }
}
