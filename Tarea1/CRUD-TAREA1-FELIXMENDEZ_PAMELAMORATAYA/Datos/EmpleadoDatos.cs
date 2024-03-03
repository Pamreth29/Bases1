using CRUD_TAREA1_FELIXMENDEZ_PAMELAMORATAYA.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD_TAREA1_FELIXMENDEZ_PAMELAMORATAYA.Datos
{
    public class EmpleadoDatos
    {

        public List<EmpleadoModel> Listar()
        {
            var objectLista = new List<EmpleadoModel>();
            var cn = new Conexion();

            using(var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        objectLista.Add(new EmpleadoModel() { 
                            id = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),
                            Salario = Convert.ToInt32(dr["Salario"])
                        });
                    }
                }
            }
            return objectLista;
        }

        public EmpleadoModel Obtener(int ID)
        {
            var objectEmpleado = new EmpleadoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Obtener", conexion);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objectEmpleado.id = Convert.ToInt32(dr["ID"]);
                        objectEmpleado.Nombre = dr["Nombre"].ToString();
                        objectEmpleado.Salario = Convert.ToInt32(dr["Salario"]);
                    }
                }
            }
            return objectEmpleado;
        }

        public bool Guardar(EmpleadoModel objectEmpleado)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Guardar", conexion);
                    cmd.Parameters.AddWithValue("@Nombre", objectEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("@Salario", objectEmpleado.Salario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();                   
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }


            return respuesta;
        }

        public bool Modificar(EmpleadoModel objectEmpleado)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Modificar", conexion);
                    cmd.Parameters.AddWithValue("@id", objectEmpleado.id);
                    cmd.Parameters.AddWithValue("@Nombre", objectEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("@Salario", objectEmpleado.Salario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }


            return respuesta;
        }

        public bool Eliminar(int ID_Empleado)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("id", ID_Empleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }


            return respuesta;
        }
    }
}
