using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.UI;

namespace TuProyecto.Controllers
{
    public class PaisController : Controller
    {
        

        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ContratosEmpleados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        private void InsertarPais(string nombre)
        {
            using (SqlConnection connection = GetSqlConnection())
            {
                string query = "INSERT INTO dbo.País (ID_país, Nombre) VALUES (@ID_país, @Nombre)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_país", ObtenerNuevoIDPais()); // Asigna un nuevo ID al país
                command.Parameters.AddWithValue("@Nombre", nombre);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private int ObtenerNuevoIDPais()
        {
            int nuevoID = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ISNULL(MAX(ID_país), 0) + 1 FROM dbo.País";
                string query2 = "SELECT ISNULL(MAX(ID_país), 0)  FROM dbo.País";

                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand command2 = new SqlCommand(query2, connection);

                try
                {
                    object result = command.ExecuteScalar();
                    object result2 = command2.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        if (result2 == result)
                        {
                            
                            nuevoID = Convert.ToInt32(result)+1;
                        }
                        else
                        {
                            nuevoID = Convert.ToInt32(result);
                        }
                       
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

            return nuevoID;
        }

        [HttpPost]
        public ActionResult GuardarPais(string nombre)
        {
            InsertarPais(nombre);


            return Redirect("/Pais/Exito.aspx");
        }
        public ActionResult Exito()
        {
            return View();
        }
        private List<Pais> MostrarPaises()
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                

                connection.Open();
                List<Pais> paises = new List<Pais>();
                string query = "SELECT * FROM dbo.País";


                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                



                    while (reader.Read())
                    {
                     
                        int id = (int)reader["ID_país"];
                        string nombre = (string)reader["Nombre"];
                        

                        Pais pais = new Pais()
                        {  
                            ID_país = id,
                            Nombre = nombre
                         
                        };

                       
                        paises.Add(pais);

                    }

                //Response.Redirect("/MostrarPaises.aspx?lista=" + Server.UrlEncode(listaComoParametro);)
                // return View("/MostrarPaises.aspx", paises);
                //return View(paises);
                return paises;

            }

                    // Propiedad para el modelo de vista
        



    }
        public List<Pais> Model { get; set; }

        public class Pais
        {
            public int ID_país { get; set; }
            public string Nombre { get; set; }

            // Constructor sin parámetros
            public Pais()
            {

            }
        }




            
     }
    
}
