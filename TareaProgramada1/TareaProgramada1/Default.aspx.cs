﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;



namespace TareaProgramada1
{
    public partial class _Default : Page // Definición de la clase _Default que hereda de la clase Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Método que se ejecuta al cargar la página
            if (!IsPostBack) // Verifica si la página se carga por primera vez o es un postback
            {
                CargarListaEmpleados(); // Llama al método para cargar la lista de empleados
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }


        // //-------------------------------------------------------------------------------------------Método para cargar la lista de empleados desde la base de datos
        public void CargarListaEmpleados()
        {
            // Establece una conexión a la base de datos y ejecuta un procedimiento almacenado para obtener los datos
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(); // Crea un nuevo comando SQL
                cmd.CommandType = CommandType.StoredProcedure; // Especifica que se usará un procedimiento almacenado
                cmd.CommandText = "SPMostrarListaEmpleados"; // Especifica el nombre del procedimiento almacenado
                cmd.Connection = conn; // Establece la conexión para el comando
                conn.Open(); // Abre la conexión
                gvdEmpleados.DataSource = cmd.ExecuteReader(); // Establece el origen de datos del GridView
                gvdEmpleados.DataBind(); // Vincula los datos al GridView
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------Método para guardar un nuevo empleado en la base de datos
        public void GuardarEmpleado()
        {
            try
            {
                // -------------------- Validar que el campo Nombre no esté vacío
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('El campo Nombre es obligatorio.');", true);
                    return;
                }

                // -------------------- Validar que el campo Nombre solo contenga letras
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]+$"))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('El campo Nombre solo puede contener letras.');", true);
                    return;
                }

                // -------------------- Validar que el campo Salario no esté vacío
                if (string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('El campo Salario es obligatorio.');", true);
                    return;
                }

                //--------------------  Validar que el campo Salario contenga solo números
                decimal salario;
                if (!decimal.TryParse(txtSalario.Text, out salario))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('El campo Salario solo puede contener números.');", true);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SPInsertEmpleado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // -------------------- Parámetro para el nombre del empleado
                    cmd.Parameters.Add("@inNombre", SqlDbType.VarChar, 64).Value = txtNombre.Text.Trim();

                    // -------------------- Parámetro para el salario del empleado
                    cmd.Parameters.Add("@inSalario", SqlDbType.Money).Value = Convert.ToDecimal(txtSalario.Text.Trim());

                    // -------------------- Parámetro de salida para el código de resultado
                    SqlParameter resultCodeParam = new SqlParameter("@OutResulTCode", SqlDbType.Int);
                    resultCodeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultCodeParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    // -------------------- Verificar el código de resultado
                    int resultCode = (int)resultCodeParam.Value;
                    if (resultCode == 0)
                    {
                        // Éxito
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Empleado guardado correctamente.');", true);
                    }
                    else
                    {
                        // Error
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Error al guardar el empleado. Código de resultado: " + resultCode.ToString() + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                // -------------------- Manejar excepciones
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Error: " + ex.Message + "');", true);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------




        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            // Manejador de eventos para el botón "Nuevo"
            pnlDatoEmpleado.Visible = false; // Oculta el panel de datos del empleado
            pnlAltaEmpleado.Visible = true; // Muestra el panel de alta de empleado
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            // Manejador de eventos para el botón "Insertar"
            pnlAltaEmpleado.Visible = false; // Oculta el panel de alta de empleado
            pnlDatoEmpleado.Visible = true; // Muestra el panel de datos del empleado
            GuardarEmpleado(); // Guarda el nuevo empleado en la base de datos
            CargarListaEmpleados(); // Recarga la lista de empleados
        }
    }

}