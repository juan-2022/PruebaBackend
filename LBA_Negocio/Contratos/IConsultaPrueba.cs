using LBA_Dominios.ModelosConsultas;

namespace LBA_Negocio.Contratos
{
    public interface IConsultaPrueba
    {
        Task<string> ConsultaAutores();
        Task<string> ConsultaEditoriales();
        Task<string> ConsultaTodosLosLibros();
        Task<string> ConsultaLibroPorIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        Task<string> ConsultaTLAutoresDLibroPIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        Task<string> ConsultaEditorialLibroIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
    }
}
