using CRUDMVC.Models;
using System.Data.SqlClient; //Nos permite usar los objetos y clases de SQL
using System.Data;

namespace CRUDMVC.Datos
{
    public class ContactoDatos
    {
        //Para obtener todos los contactos registrados
        public List<ContactoModel> Listar()
        {

            var oLista = new List<ContactoModel>(); //Se hace referencia a la lista en el objeto oLista

            var cn = new Conexion(); //Instacia de la clase de conexion

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) //Establecer la cedena de conexion
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el resultado del procedimiento
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) //Lee uno a uno
                    {
                        oLista.Add(new ContactoModel() //Llama a cada una de las propiedades que vamos a utilizar
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        }); 
                    }
                }
            }
            return oLista;
        }

        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel(); //Se hace referencia a la lista en el objeto oLista

            var cn = new Conexion(); //Instacia de la clase de conexion

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) //Establecer la cedena de conexion
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el resultado del procedimiento
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) //Lee uno a uno
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion(); //Instacia de la clase de conexion

                using (var conexion = new SqlConnection(cn.getCadenaSQL())) //Establecer la cedena de conexion
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); //Ejecuta el procedimiento almacenado
                }
                respuesta = true; //Si no tuvo error es verdadero
            }
            catch (Exception ex)
            {
                string error = ex.Message; //Guarda el mensaje de error
                respuesta=false; //Si tuvo error es falso
            }
            return respuesta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion(); //Instacia de la clase de conexion

                using (var conexion = new SqlConnection(cn.getCadenaSQL())) //Establecer la cedena de conexion
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); //Ejecuta el procedimiento almacenado
                }
                respuesta = true; //Si no tuvo error es verdadero
            }
            catch (Exception ex)
            {
                string error = ex.Message; //Guarda el mensaje de error
                respuesta = false; //Si tuvo error es falso
            }
            return respuesta;
        }

        public bool Eliminar(int idContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion(); //Instacia de la clase de conexion

                using (var conexion = new SqlConnection(cn.getCadenaSQL())) //Establecer la cedena de conexion
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", idContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery(); //Ejecuta el procedimiento almacenado
                }
                respuesta = true; //Si no tuvo error es verdadero
            }
            catch (Exception ex)
            {
                string error = ex.Message; //Guarda el mensaje de error
                respuesta = false; //Si tuvo error es falso
            }
            return respuesta;
        }

    }
}
