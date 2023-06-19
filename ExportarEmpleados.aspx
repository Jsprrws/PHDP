<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarEmpleados.aspx.cs" Inherits="PHDP.ExportarEmpleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exportar Empleados a PDF</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Exportar Empleados a PDF</h2>
            <asp:Button ID="btnExportarPDF" runat="server" Text="Exportar a PDF" OnClick="btnExportarPDF_Click" />
        </div>
    </form>
</body>
     <p><a href="../Default.aspx">Volver a la página principal</a></p>
</html>
