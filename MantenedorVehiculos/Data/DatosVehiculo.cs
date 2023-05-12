using MantenedorVehiculos.Models;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.OleDb;

namespace MantenedorVehiculos.Data
{
    public class DatosVehiculo
    {
        public List<ModeloVehiculos> ListarDatos()
        {
            var oLista = new List<ModeloVehiculos>();
            var cn = new Conexion();
            string query = "select * from Vehiculo";

            //using (var conexion = new SqlConnection(cn.getCadenaConexion()))
            using (var conexion = new OleDbConnection(cn.getCadenaConexion()))
            {
                conexion.Open();
                OleDbCommand cmd = new OleDbCommand(query, conexion);
                //cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ModeloVehiculos()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Marca = dr["Marca"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            Color = dr["Color"].ToString(),
                            Patente = dr["Patente"].ToString(),
                            Anio = Convert.ToInt32((dr["Anio"])),
                            Cilindrada = Convert.ToInt32((dr["Cilindrada"]))
                        });

                    }
                }
            }
            return oLista;
        }

        public ModeloVehiculos ObtenerId(int IdVehiculo)
        {
            var oVehiculo = new ModeloVehiculos();
            var cn = new Conexion();
            string query = "select Id, Marca, Modelo, Color, Patente, Anio, Cilindrada from Vehiculo where Id = @idVehiculo";

            //using (var conexion = new SqlConnection(cn.getCadenaConexion()))
            using (var conexion = new OleDbConnection(cn.getCadenaConexion()))
            {
                conexion.Open();
                //SqlCommand cmd = new SqlCommand(query, conexion);
                OleDbCommand cmd = new OleDbCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idVehiculo", IdVehiculo);
                //cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVehiculo.Id = Convert.ToInt32(dr["Id"]);
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Color = dr["Color"].ToString();
                        oVehiculo.Patente = dr["Patente"].ToString();
                        oVehiculo.Anio = Convert.ToInt32((dr["Anio"]));
                        oVehiculo.Cilindrada = Convert.ToInt32((dr["Cilindrada"]));
                    }
                }
            }
            return oVehiculo;
        }

        public bool Guardar(ModeloVehiculos oVehiculo)
        {
            bool guardado;
            string query = "insert into Vehiculo(Marca, Modelo, Color, Patente, Anio, Cilindrada) " +
                           "values (@marca, @modelo, @color, @patente, @anio, @cilindrada)";
            try
            {
                var cn = new Conexion();

                //using (var conexion = new SqlConnection(cn.getCadenaConexion()))
                using (var conexion = new OleDbConnection(cn.getCadenaConexion()))
                {
                    conexion.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("@modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("@color", oVehiculo.Color);
                    cmd.Parameters.AddWithValue("@patente", oVehiculo.Patente);
                    cmd.Parameters.AddWithValue("@anio", oVehiculo.Anio);
                    cmd.Parameters.AddWithValue("@cilindrada", oVehiculo.Cilindrada);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                guardado = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                guardado = false;
            }
            return guardado;
        }

        public bool Editar(ModeloVehiculos oVehiculo)
        {
            bool editado;
            string query = "Update Vehiculo set Marca = @marca, Modelo = @modelo, Color = @color, Patente = @patente, Anio = @anio, Cilindrada = @cilindrada "+
                            "where Id = @idVehiculo";

            try
            {
                var cn = new Conexion();

                //using (var conexion = new SqlConnection(cn.getCadenaConexion()))
                using (var conexion = new OleDbConnection(cn.getCadenaConexion()))
                {
                    conexion.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@marca", oVehiculo.Marca);
                    cmd.Parameters.AddWithValue("@modelo", oVehiculo.Modelo);
                    cmd.Parameters.AddWithValue("@color", oVehiculo.Color);
                    cmd.Parameters.AddWithValue("@patente", oVehiculo.Patente);
                    cmd.Parameters.AddWithValue("@anio", oVehiculo.Anio);
                    cmd.Parameters.AddWithValue("@cilindrada", oVehiculo.Cilindrada);
                    cmd.Parameters.AddWithValue("@idVehiculo", oVehiculo.Id);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                editado = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                editado = false;
            }
            return editado;
        }

        public bool Eliminar(int idVehiculo)
        {
            bool eliminado;
            string query = "delete from Vehiculo where Id = @idVehiculo";
            try
            {
                var cn = new Conexion();
                //using (var conexion = new SqlConnection(cn.getCadenaConexion()))
                using (var conexion = new OleDbConnection(cn.getCadenaConexion()))
                {
                    conexion.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                eliminado = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                eliminado = false;
            }
            return eliminado;
        }
    }
}
