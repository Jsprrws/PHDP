using System;
using System.Data;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data.SqlClient;

namespace PHDP
{
    public partial class ExportarEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExportarPDF_Click(object sender, EventArgs e)
        {
            DataTable dataTable = ObtenerDatosTablaEmpleados();

            foreach (DataRow row in dataTable.Rows)
            {
                // Crear un nuevo documento PDF para cada empleado
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                XGraphics graphics = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 12, XFontStyle.Bold);

                float yPosition = 50;

                // Agregar texto adicional antes de imprimir las columnas
                graphics.DrawString("Contrato de Confidencialidad", font, XBrushes.Black, new XRect(50, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 20;

                string textoAdicional = "Este contrato de confidencialidad (Contrato) se establece entre [Nombre de la Parte Reveladora]";

                graphics.DrawString(textoAdicional, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;

                string textoAdicional2 = "en adelante (La Parte Reveladora), y Amazon.com, Inc. y sus afiliadas, en adelante (Amazon). Confidencialidad y Propósito";

                graphics.DrawString(textoAdicional2, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;

                string textoAdicional3 = "La Parte Reveladora se compromete a revelar cierta información confidencial a Amazon en relación con la colaboración entre ambas partes.";

                graphics.DrawString(textoAdicional3, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;


                string textoAdicional4 = "La información confidencial puede incluir, entre otros, secretos comerciales, datos técnicos, estrategias de mercado,";
                string textoAdicional5 = "información financiera y cualquier otra información que sea designada como confidencial. 2. Obligaciones de Confidencialidad\r\nAmazon se compromete ";
                string textoAdicional6 = "mantener la información confidencial recibida de la Parte Reveladora en estricta confidencialidad y a utilizarla únicamente para los fines establecidos ";
                string textoAdicional7 = "en este Contrato. Amazon se asegurará de que su personal y cualquier tercero involucrado en la colaboración también estén sujetos ";
                string textoAdicional8 = "a obligaciones de confidencialidad y se comprometan a cumplir con los términos de este Contrato. 3. Uso Limitado\r\nLa información confidencial ";
                string textoAdicional9 = "proporcionada por la Parte Reveladora solo podrá ser utilizada por Amazon para los fines específicos relacionados con la colaboración ";
                string textoAdicional10 = "entre las partes. Amazon no revelará ni divulgará la información confidencial a terceros sin el previo consentimiento por escrito de la Parte Reveladora, ";
                string textoAdicional11 = "a menos que sea requerido por ley o por una orden judicial. 4. Medidas de Seguridad\r\nAmazon implementará medidas razonables  ";
                string textoAdicional12 = "para proteger la información confidencial de accesos no autorizados, divulgaciones o pérdidas. Estas medidas de seguridad incluirán, ";
                string textoAdicional13 = "pero no se limitarán a, la protección de sistemas, la limitación de acceso a la información confidencial solo a empleados autorizados ";
                string textoAdicional14 = "y la firma de acuerdos  ";
                string textoAdicional15 = "de confidencialidad con dichos empleados. 5. Duración\r\nEste Contrato de Confidencialidad comenzará en la fecha de su firma y continuará ";
                string textoAdicional16 = "vigente durante el período de colaboración entre las partes y durante [especificar el período de tiempo] años a partir de la finalización de dich";
                string textoAdicional17 = "colaboración. 6. Devolución de la Información\r\nA solicitud de la Parte Reveladora, Amazon deberá devolver o destruir toda la información confidencial ";
                string textoAdicional18 = "y cualquier copia de la misma una vez finalizada la colaboración o terminado este Contrato, a menos que la Parte Reveladora acuerde  ";
                string textoAdicional19 = "lo contrario por escrito. 7. No Licencia\r\nEste Contrato no otorga a ninguna de las partes una licencia o derecho sobre la información confidencial  ";
                string textoAdicional20 = "de la otra parte, excepto en la medida en que sea necesario para los fines establecidos en este Contrato. 8. Ley Aplicable y ";
                string textoAdicional21 = "Jurisdicción\r\nEste Contrato se regirá e interpretará de acuerdo con las leyes del [país o estado correspondiente]. Cualquier disputa que surja de este  ";
                string textoAdicional22 = "Contrato estará sujeta a la jurisdicción exclusiva de los tribunales del [país o estado correspondiente]. Ambas partes, en ";
                string textoAdicional23 = "representación de sus respectivas entidades, han firmado este Contrato de Confidencialidad en la fecha indicada a continuación. [Nombre de la Parte Reveladora]Amazon.com, Inc.\r\nFirma";
                graphics.DrawString(textoAdicional4, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional5, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional6, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional7, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional8, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional9, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional10, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional11, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional12, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional13, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional14, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional15, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional16, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional17, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional18, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional19, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional20, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional21, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional22, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;
                graphics.DrawString(textoAdicional23, font, XBrushes.Black, new XRect(5, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                yPosition += 10;









                foreach (DataColumn column in dataTable.Columns)
                {
                    graphics.DrawString(column.ColumnName, font, XBrushes.Black, new XRect(50, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    yPosition += 20;
                }

                yPosition += 20;
                foreach (var item in row.ItemArray)
                {
                    graphics.DrawString(item.ToString(), font, XBrushes.Black, new XRect(50, yPosition, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    yPosition += 20;
                }

                // Obtener el nombre del empleado para el nombre del archivo PDF
                string nombreEmpleado = row["Nombre"].ToString(); // Reemplaza "Nombre" con el nombre de la columna que contiene el nombre del empleado

                string filePath = Server.MapPath("~/ArchivosPDF/" + nombreEmpleado + ".pdf");
                document.Save(filePath);
            }

            Response.Write("Exportación exitosa de los documentos PDF.");

            // Response.ContentType = "application/pdf";
            // Response.AppendHeader("Content-Disposition", "attachment; filename=Empleados.pdf");
            // Response.TransmitFile(filePath);
            // Response.End();
        }

        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ContratosEmpleados;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ObtenerDatosTablaEmpleados()
        {
            
            string query = "SELECT * FROM DBO.Empleado"; // Reemplaza por tu consulta SQL para obtener los empleados

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
    }
}