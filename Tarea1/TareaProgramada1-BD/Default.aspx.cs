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

        }
    }
}