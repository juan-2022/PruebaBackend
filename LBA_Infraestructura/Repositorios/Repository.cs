using Newtonsoft.Json;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace LBA_Infraestructura.Repositorios
{
    public class Repository
    {
        private StrCadenaConexion connectionString = new StrCadenaConexion();
        private SqlConnection connection = new SqlConnection();
        private SqlTransaction transaction = null;

        private SqlConnection Conexion()
        {
            try
            {
                connection = new SqlConnection(connectionString.Cadena);
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EndConec()
        {
            connection.Close();
        }

        public async Task<string> EjecutarFuncion(SqlCommand command, string nombreProcedimiento)
        {
            string resultado = string.Empty;
            DataTable tablaProcedimiento = new DataTable();
            command.Connection = Conexion();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = nombreProcedimiento;

            try
            {
                tablaProcedimiento.Load(command.ExecuteReader());
                if (tablaProcedimiento.Rows.Count > 0)
                {
                    var datos = tablaProcedimiento.Rows[0].Table;
                    resultado = JsonConvert.SerializeObject(datos, Formatting.Indented);
                }
                else
                {
                    listaRespues lista = new() { resultadodb = "vacio" };
                    List<listaRespues> listaList = new List<listaRespues>();
                    listaList.Add(lista);
                    resultado = JsonConvert.SerializeObject(listaList);
                }
                EndConec();

                return resultado;

            }
            catch (Exception e)
            {
                throw;
            }

        }

    }

    public class listaRespues
    {
        public string resultadodb { get; set; }
    }

}
