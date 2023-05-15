using LBA_Dominios.ModelosComandos;

namespace LBA_Negocio.Contratos
{
    public interface IComandosPrueba
    {
        Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel);
    }
}
