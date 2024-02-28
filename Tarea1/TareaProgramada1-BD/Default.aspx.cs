using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TareaProgramada1_BD
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }


        }
        public void CargarDatos()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPMostrarListaEmpleados";
                cmd.Connection = conn;
                conn.Open();
                gvdEmpleados.DataSource = cmd.ExecuteReader();
                gvdEmpleados.DataBind();

            }
        }

        public void GuardaEmpleado()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPInsertEmpleado";
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value=txtNombre.Text.Trim();
                cmd.Parameters.Add("@Salario", SqlDbType.Money).Value = Convert.ToDecimal(txtSalario.Text.Trim());
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlDatoEmpleado.Visible = false;
            pnlAltaEmpleado.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pnlAltaEmpleado.Visible = false;
            pnlDatoEmpleado.Visible = true;
            GuardaEmpleado();
            CargarDatos();
        }
    }
}