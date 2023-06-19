using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PHDP
{
    public partial class LecturaArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExecuteConsole_Click(object sender, EventArgs e)
        {
            string consoleAppPath = Server.MapPath("/Carga.exe"); // Ruta al programa de consola

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = consoleAppPath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process
            {
                StartInfo = startInfo
            };

            // Iniciar el proceso
            process.Start();

            // Leer la salida del programa de consola
            string output = process.StandardOutput.ReadToEnd();

            // Esperar a que el proceso termine
            process.WaitForExit();

            // Mostrar la salida en la página ASPX
            Response.Write(output);
        }

        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ContratosEmpleados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(fileUpload.FileName);
                    string filePath = Server.MapPath("/uploads/") + fileName;
                    fileUpload.SaveAs(filePath);

                    string fileContent = File.ReadAllText(filePath);

                    string insertQuery = "INSERT INTO dbo.Empleado (ID_empleado, Nombre, Apellido, ID_país) VALUES (@ID_empleado, @Nombre, @Apellido, @ID_país)";





                    string[] lines = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                        int ID_empleado = Convert.ToInt32(values[0]);
                        string Nombre = values[1];
                        string Apellido = values[2];
                        int ID_país = Convert.ToInt32(values[3]);

                        // Luego, ejecuta la consulta de inserción en la base de datos con estos valores

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SqlCommand command = new SqlCommand(insertQuery, connection);
                            command.Parameters.AddWithValue("@ID_empleado", ID_empleado);
                            command.Parameters.AddWithValue("@Nombre", Nombre);
                            command.Parameters.AddWithValue("@Apellido", Apellido);
                            command.Parameters.AddWithValue("@ID_país", ID_país);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }








                    // Realiza acciones adicionales con el archivo cargado, como leer su contenido
                    // o almacenar la ruta del archivo en la base de datos, según tus necesidades

                    lblMessage.Text = "Archivo subido con éxito.";
                    txtFileContent.Text = fileContent;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error al subir el archivo: " + ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "No se seleccionó ningún archivo.";
            }
        }

    }
}