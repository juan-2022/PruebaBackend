using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;
using LBA_Negocio.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

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
        delegate string delegadaIniciarSesion(ConsultausuariosDto consultausuariosDto);
        delegate string delegadaCursoAlumno(InformacionCursoDto informacionCursoDto);
        delegate string delegadaBuscarAlumno(InformacionEstudiante informacionEstudiante);
        delegate string delegadaAlumnoid(Estudiantexid estudiantexid);
        public IConfiguration _configuration;



        public PruebaController(IFachada fachada, IConfiguration configuration)
        {
            _fachada= fachada;
            _configuration= configuration;
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
        
        [HttpPost("ConsultaCurso")]
        public async Task<string> CursosAlumno(InformacionCursoDto informacionCursoDto)
        {
            delegadaCursoAlumno delegada = delegate (InformacionCursoDto _informacionCursoDto)
            {
                return _fachada.CursosAlumno(_informacionCursoDto).Result;
            };
            return delegada(informacionCursoDto);
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
        
        [HttpPost("IniciarSesion")]
        public dynamic  IniciarSesion(ConsultausuariosDto consultausuariosDto)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            delegadaIniciarSesion delegada = delegate (ConsultausuariosDto _consultausuariosDto)
            {
                return _fachada.IniciarSesion(_consultausuariosDto).Result;
            };

            if(delegada(consultausuariosDto) == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales Incorectas",
                    result = "",
                };
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("user",delegada(consultausuariosDto))

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires:DateTime.Now.AddMinutes(60),
                    signingCredentials: singIn
                );

            var value = new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return value;
        }

        [HttpPost("BuscarAlumno")]
        public async Task<string> AlumnosxNombre(InformacionEstudiante informacionEstudiante)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            
            delegadaBuscarAlumno delegada = delegate (InformacionEstudiante _informacionEstudiante)
            {
                return _fachada.AlumnosxNombre(_informacionEstudiante).Result;
            };
            return (delegada(informacionEstudiante));
       
                
        }
        
        [HttpPost("Alumnoxid")]
        public async Task<string> Alumnosxid(Estudiantexid estudiantexid)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            
            delegadaAlumnoid delegada = delegate (Estudiantexid _estudiantexid1)
            {
                return _fachada.Alumnosxid(_estudiantexid1).Result;
            };
            return (delegada(estudiantexid));
       
                
        }

    }
}
