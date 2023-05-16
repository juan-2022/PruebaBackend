using LBA_Dominios.ModelosConsultas;

namespace LBA_Negocio.Contratos
{
    public interface IConsultaPrueba
    {
        Task<string> ObtenerToken();
        
    }
}
