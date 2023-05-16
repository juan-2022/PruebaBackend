using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;

namespace LBA_Negocio.Contratos
{
    public interface IComandosPrueba
    {
        Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel);
        Task<string> ConteoVehiculos(InformacionDto informacionDto);
        Task<string> RecaudoVehiculos(InformacionDto informacionDto);
    }
}
