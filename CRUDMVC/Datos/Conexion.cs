using System.Runtime.CompilerServices;

namespace CRUDMVC.Datos
{
    //Todas las operaciones a traves de ADO.NET
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            //Utilizamos var por que nos permite usar cualquier tipo de variable
            //Para obtener la cadena de conexion
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
