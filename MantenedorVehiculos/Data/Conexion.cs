using System.Data.SqlClient;
using System.Data.OleDb;

namespace MantenedorVehiculos.Data
{
    public class Conexion
    {
        private string cadenaConexion = string.Empty;

        public Conexion() {

            /*var constructorConexion = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaConexion = constructorConexion.GetSection("ConnectionStrings:CadenaConexion").Value;*/
            cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Automotora.accdb;Persist Security Info=False;";
        }

        public string getCadenaConexion()
        {
            return cadenaConexion;
        }
    }
}
