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
        delegate string delegadaConsultaAutores();
        delegate string delegadaConsultaEditoriales();
        delegate string delegadaConsultaTodosLosLibros();
        delegate string delegadaConsultaLibroPorIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        delegate string delegadaConsultaTLAutoresDLibroPIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        delegate string delegadaConsultaEditorialLibroIsbn(ConsultaIsbnViewModel consultaIsbnViewModel);
        delegate string delegadaRegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel);

        public PruebaController(IFachada fachada)
        {
            _fachada= fachada;
        }
        
        [HttpGet("ConsultaAutores")]
        public async Task<string> ConsultaAutores()
        {
            delegadaConsultaAutores delegada = delegate ()
            {
                return _fachada.ConsultaAutores().Result;
            };
            return delegada();
        }
        [HttpGet("ConsultaEditoriales")]
        public async Task<string> ConsultaEditoriales()
        {
            delegadaConsultaEditoriales delegada = delegate ()
            {
                return _fachada.ConsultaEditoriales().Result;
            };
            return delegada();
        }
        [HttpGet("ConsultaTodosLosLibros")]
        public async Task<string> ConsultaTodosLosLibros()
        {
            delegadaConsultaTodosLosLibros delegada = delegate ()
            {
                return _fachada.ConsultaTodosLosLibros().Result;
            };
            return delegada();
        }
        [HttpPost("ConsultaLibroPorIsbn")]
        public async Task<string> ConsultaLibroPorIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            delegadaConsultaLibroPorIsbn delegada = delegate (ConsultaIsbnViewModel _consultaIsbnViewModel)
            {
                return _fachada.ConsultaLibroPorIsbn(_consultaIsbnViewModel).Result;
            };
            return delegada(consultaIsbnViewModel);
        }
        [HttpPost("ConsultaTLAutoresDLibroPIsbn")]
        public async Task<string> ConsultaTLAutoresDLibroPIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            delegadaConsultaTLAutoresDLibroPIsbn delegada =  delegate (ConsultaIsbnViewModel _consultaIsbnViewModel)
            {
                return  _fachada.ConsultaTLAutoresDLibroPIsbn(_consultaIsbnViewModel).Result;
            };
            return delegada(consultaIsbnViewModel);
        }
        [HttpPost("ConsultaEditorialLibroIsbn")]
        public async Task<string> ConsultaEditorialLibroIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            delegadaConsultaEditorialLibroIsbn delegada = delegate (ConsultaIsbnViewModel _consultaIsbnViewModel)
            {
                return _fachada.ConsultaEditorialLibroIsbn(_consultaIsbnViewModel).Result;
            };
            return delegada(consultaIsbnViewModel);
        }
        [HttpPost("RegistrarLibros")]
        public async Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel)
        {
            delegadaRegistrarLibros delegada = delegate (ComandoRegistroViewModel _comandoRegistroViewModel)
            {
                return _fachada.RegistrarLibros(_comandoRegistroViewModel).Result;
            };
            return delegada(comandoRegistroViewModel);
        }

    }
}
