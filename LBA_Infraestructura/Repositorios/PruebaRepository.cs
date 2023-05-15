using LBA_Dominios.ModelosComandos;
using LBA_Dominios.ModelosConsultas;
using LBA_Infraestructura.Contratos;
using NpgsqlTypes;
using System.Data;
using System.Data.SqlClient;

namespace LBA_Infraestructura.Repositorios
{
    public class PruebaRepository : Repository, IPruebaRepository
    {
        private SqlCommand _comandogeneral;
        public PruebaRepository()
        {
            _comandogeneral = new SqlCommand();
        }
        //Obtener todos los autores:
        public Task<string> ConsultaAutores()
        {
            _comandogeneral.Parameters.Clear();
            var resultado = EjecutarFuncion(_comandogeneral, "sp_getAutores");
            return resultado;
        }
        //Obtener todas las editoriales
        public Task<string> ConsultaEditoriales()
        {
            _comandogeneral.Parameters.Clear();
            var resultado = EjecutarFuncion(_comandogeneral, "sp_getEditoriales");
            return resultado;
        }
        //Obtener todos los libros
        public Task<string> ConsultaTodosLosLibros()
        {
            _comandogeneral.Parameters.Clear();
            var resultado = EjecutarFuncion(_comandogeneral, "sp_getLibros");
            return resultado;
        }
        //Obtener un libro por su ISBN
        public Task<string> ConsultaLibroPorIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@ISBN", SqlDbType.Int).Value = consultaIsbnViewModel.isbn;
            var resultado = EjecutarFuncion(_comandogeneral, "sp_getLibroByISBN");
            return resultado;
        }
        //Obtener todos los autores de un libro dado su ISBN:
        public Task<string> ConsultaTLAutoresDLibroPIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@ISBN", SqlDbType.Int).Value = consultaIsbnViewModel.isbn;
            var resultado = EjecutarFuncion(_comandogeneral, "sp_getAutoresByISBN");
            return resultado;
        }
        //Obtener la editorial de un libro dado su ISBN
        public Task<string> ConsultaEditorialLibroIsbn(ConsultaIsbnViewModel consultaIsbnViewModel)
        {
            _comandogeneral.Parameters.Clear();
            _comandogeneral.Parameters.AddWithValue("@ISBN", SqlDbType.Int).Value = consultaIsbnViewModel.isbn;
            var resultado = EjecutarFuncion(_comandogeneral, "sp_getEditorialByISBN");
            return resultado;
        }
        //que inserta valores en las tablas autores, editoriales, libros y autores_has_libros
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
            var resultado =  await EjecutarFuncion(_comandogeneral, "insertar_datos");
            return resultado;
        }

    }
}
