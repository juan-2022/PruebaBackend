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
        public Task<string> ObtenerToken()
        {
            return _consultaPrueba.ObtenerToken();
        }
        public Task<string> ConteoVehiculos(InformacionDto informacionDto)
        {
            return _comandosPrueba.ConteoVehiculos(informacionDto);
        }
        public Task<string> RecaudoVehiculos(InformacionDto informacionDto)
        {
            return _comandosPrueba.RecaudoVehiculos(informacionDto);
        }
        public Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel)
        {
            return _comandosPrueba.RegistrarLibros(comandoRegistroViewModel);
        }
    }
}
