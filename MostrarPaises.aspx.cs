using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using static TuProyecto.Controllers.PaisController;
using System.Reflection;

namespace PHDP
{
    public partial class MostrarPaises : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ContratosEmpleados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Pais> paises = new List<Pais>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                    

                {
                    connection.Open();
                    string query = "SELECT * FROM dbo.País"; // Reemplaza "NombreTabla" con el nombre de tu tabla en SQL Server
                    SqlCommand command = new SqlCommand(query, connection);
                    
                    SqlDataReader reader = command.ExecuteReader();

                    // Recorre los registros y muestra los datos
                    while (reader.Read())
                    {
                        
                        int columna1 = (int)reader["ID_país"]; // Reemplaza "Columna1" con el nombre de tu columna en SQL Server
                        string columna2 = reader["Nombre"].ToString(); // Reemplaza "Columna2" con el nombre de tu columna en SQL Server



                        Pais pais = new Pais()
                        {
                            ID_país =  columna1,
                            Nombre = columna2

                        };


                        paises.Add(pais);

                    }

                    reader.Close();
                }
                Model = paises;
            }
        }
        public List<Pais> Model { get; set; }
        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}