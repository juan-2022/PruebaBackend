using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;
using LBA_Negocio.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace LBA_Services_Delegade_Biblioteca.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class PruebaController : Controller
    {
        private readonly IFachada _fachada;
        delegate string delegadaObtenerToken();
        delegate string delegadaConteoVehiculos(InformacionDto informacionDto);
        delegate string delegadaRecaudoVehiculos(InformacionDto informacionDto);
        delegate string delegadaRegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel);

        public PruebaController(IFachada fachada)
        {
            _fachada= fachada;
        }
        [HttpGet("ConsultaToken")]
        public async Task<string> ObtenerToken()
        {
            delegadaObtenerToken delegada = delegate ()
            {
                return _fachada.ObtenerToken().Result;
            };
            return delegada();
        }

        [HttpPost("ConteoVehiculos")]
        public async Task<string> ConteoVehiculos(InformacionDto informacionDto)
        {
            delegadaConteoVehiculos delegada = delegate (InformacionDto _informacionDto)
            {
                return _fachada.ConteoVehiculos(_informacionDto).Result;
            };
            return delegada(informacionDto);
        }
        [HttpPost("RecaudoVehiculos")]
        public async Task<string> RecaudoVehiculos(InformacionDto informacionDto)
        {
            delegadaRecaudoVehiculos delegada = delegate (InformacionDto _informacionDto)
            {
                return _fachada.RecaudoVehiculos(_informacionDto).Result;
            };
            return delegada(informacionDto);
        }

    }
}
