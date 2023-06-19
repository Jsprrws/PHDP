using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PHDP
{
    public partial class RegistroPais : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ContratosEmpleados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            int nuevoID = ObtenerNuevoIDPais();

            InsertarPais(nuevoID, nombre);
            lblMensaje.Text = "El país se ha ingresado correctamente.";
            lblMensaje.Visible = true;
            Response.Redirect("~/Pais/Exito.aspx");
        }

        private void InsertarPais(int idPais, string nombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.País (ID_país, Nombre) VALUES (@ID_país, @Nombre)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_país", ObtenerNuevoIDPais());

                    SqlParameter nombreParam = new SqlParameter("@Nombre", SqlDbType.NVarChar);
                    nombreParam.Value = nombre;
                    command.Parameters.Add(nombreParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private int ObtenerNuevoIDPais()
        {
            int nuevoID = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ISNULL(MAX(ID_país), 0) + 1 FROM dbo.País";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        nuevoID = Convert.ToInt32(result);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return nuevoID;
        }
    }
}