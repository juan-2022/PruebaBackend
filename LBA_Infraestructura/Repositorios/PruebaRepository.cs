using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;
using LBA_Infraestructura.Contratos;
using LBA_Services;
using NpgsqlTypes;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace LBA_Infraestructura.Repositorios
{
    public class PruebaRepository : Repository, IPruebaRepository
    {
        private SqlCommand _comandogeneral;
        private readonly UserServices _userServices;
        public PruebaRepository(UserServices userServices)
        {
            _userServices = userServices;
            _comandogeneral = new SqlCommand();
        }
        //Obtiene Token
        public Task<string> ObtenerToken()
        {
            var resultado = _userServices.LoginUser();
            return resultado;
        }

        public async Task<string> ConteoVehiculos(InformacionDto informacionDto)
        {
            var resultado = _userServices.ConteoVehiculos(informacionDto);            
            return resultado.Result;
        }
        public async Task<string> RecaudoVehiculos(InformacionDto informacionDto)
        {
            var resultado = _userServices.RecaudoVehiculos(informacionDto);
            return resultado.Result;
        }
        public async Task<string> RegistrarLibros(ComandoRegistroViewModel comandoRegistroViewModel)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@nombre_autor", SqlDbType.VarChar).Value = comandoRegistroViewModel.nombreAutor;
            _comandogeneral.Parameters.AddWithValue("@apellidos_autor", SqlDbType.VarChar).Value = comandoRegistroViewModel.apellidosAutor;
            _comandogeneral.Parameters.AddWithValue("@nombre_editorial", SqlDbType.VarChar).Value = comandoRegistroViewModel.nombreEditorial;
            _comandogeneral.Parameters.AddWithValue("@sede_editorial", SqlDbType.VarChar).Value = comandoRegistroViewModel.sedeEditorial;
            _comandogeneral.Parameters.AddWithValue("@titulo_libro", SqlDbType.VarChar).Value = comandoRegistroViewModel.tituloLibro;
            _comandogeneral.Parameters.AddWithValue("@sinopsis_libro", SqlDbType.VarChar).Value = comandoRegistroViewModel.sinopsisLibro;
            _comandogeneral.Parameters.AddWithValue("@n_paginas_libro", SqlDbType.Int).Value = comandoRegistroViewModel.nPaginasLibro;
            var resultado = await EjecutarFuncion(_comandogeneral, "insertar_datos");
            return resultado;
        }
        public async Task<string> IniciarSesion(ConsultausuariosDto consultausuariosDto)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@user", SqlDbType.VarChar).Value = consultausuariosDto.usuario;
            _comandogeneral.Parameters.AddWithValue("@password", SqlDbType.VarChar).Value = consultausuariosDto.password;
            var resultado = await EjecutarFuncion(_comandogeneral, "inicioSesion");
            return resultado;
        }
        public async Task<string> CursosAlumno(InformacionCursoDto informacionCursoDto)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@AlumnoId",SqlDbType.VarChar).Value = informacionCursoDto.Id;
            var resultado = await EjecutarFuncion(_comandogeneral, "ObtenerMateriasPorAlumno");
            return resultado;

        }
        public async Task<string> AlumnosxNombre(InformacionEstudiante informacionEstudiante)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@NombreEstudiante", SqlDbType.VarChar).Value = informacionEstudiante.nombreEstudiante;
            var resultado = await EjecutarFuncion(_comandogeneral, "ObtenerEstudiantesPorNombre");
            return resultado;
        }
        public async Task<string> Alumnosxid(Estudiantexid estudiantexid)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = estudiantexid.id;
            var resultado = await EjecutarFuncion(_comandogeneral, "ObtenerAlumnoPorId");
            return resultado;
        }

    }
}
