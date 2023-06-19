using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace PHDP
{
    public partial class Mantenimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpresas();
            }
        }

        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ContratosEmpleados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        private void CargarContratos(int anio, int idEmpresa)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT c.ID_contrato, c.Fecha_inicio, c.Fecha_terminación " +
                               "FROM dbo.Contrato c " +
                               "JOIN dbo.Empleado e ON c.ID_empleado = e.ID_empleado " +
                               "JOIN dbo.Empresa emp ON e.ID_país = emp.ID_país " +
                               "WHERE YEAR(c.Fecha_inicio) = @Anio AND emp.ID_empresa = @IdEmpresa";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Anio", anio);
                command.Parameters.AddWithValue("@IdEmpresa", idEmpresa);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);

                try
                {
                    gridResultados.DataSource = dataTable;
                    gridResultados.DataBind();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción o mostrar información de depuración
                    string errorMessage = ex.Message;
                    // Puedes mostrar el mensaje de error en una etiqueta o en la consola
                    // lblErrorMessage.Text = errorMessage;
                    // Console.WriteLine(errorMessage);
                }
                
            }
        }

        private void CargarEmpresas()
        {
            // Conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta para obtener las empresas
                string query = "SELECT ID_empresa, Nombre FROM dbo.Empresa";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                // Obtener los datos y enlazarlos al DropDownList
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    ddlEmpresa.DataSource = dataTable;
                    ddlEmpresa.DataTextField = "Nombre";
                    ddlEmpresa.DataValueField = "ID_empresa";
                    ddlEmpresa.DataBind();
                }
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            int anio = int.Parse(txtAnio.Text);
            int idEmpresa = int.Parse(ddlEmpresa.SelectedValue);

            // Consulta para obtener los registros filtrados por año y empresa
            string query = "SELECT  a.ID_contrato, a.Fecha_inicio, a.Fecha_terminación FROM dbo.Contrato a, dbo.Empresa b , dbo.País c,dbo.Empleado d " +
                           "WHERE d.ID_país = c.ID_país and a.ID_empleado = d.ID_empleado " +
                           "and a.ID_contrato = b.ID_empresa and year(a.Fecha_inicio) = @Anio AND ID_empresa = @Id_Empresa";

            // Conexión a la base de datos
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Anio", anio);
                command.Parameters.AddWithValue("@Id_Empresa", idEmpresa);
                connection.Open();

                // Obtener los datos y enlazarlos al GridView
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    try
                    {
                        gridResultados.DataSource = dataTable;
                        gridResultados.DataBind();
                    }
                    catch (Exception ex)
                    {

                        // Manejar la excepción o mostrar información de depuración
                        string errorMessage = ex.Message;
                        // Puedes mostrar el mensaje de error en una etiqueta o en la consola
                        // lblErrorMessage.Text = errorMessage;
                        // Console.WriteLine(errorMessage);
                    }

                }
                CargarContratos(anio, idEmpresa);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("El evento btnEditar_Click se ha ejecutado correctamente.");

            // Obtener el ID del contrato seleccionado
            Button btnEditar = (Button)sender;
            int idContrato = int.Parse(btnEditar.CommandArgument);
            //string idContrato = btnEditar.CommandArgument;
            // Redireccionar a la página de edición pasando el ID del contrato como parámetro
            Response.Redirect("~/EditarContrato.aspx?ID=" + idContrato);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del contrato seleccionado
            Button btnEliminar = (Button)sender;
            int idContrato = int.Parse(btnEliminar.CommandArgument);

            // Lógica para eliminar el contrato con el ID proporcionado
            EliminarContrato(idContrato);

            // Volver a cargar los resultados
            btnFiltrar_Click(sender, e);
        }

        private void EliminarContrato(int idContrato)
        {
            // Conexión a la base de datos
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta para eliminar el contrato
                string query = "DELETE FROM dbo.Contrato WHERE ID_contrato = @Id_Contrato";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Contrato", idContrato);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

    }
}