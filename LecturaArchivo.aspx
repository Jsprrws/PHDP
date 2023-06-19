<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LecturaArchivo.aspx.cs" Inherits="PHDP.LecturaArchivo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Subir archivo" OnClick="btnUpload_Click" />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtFileContent" runat="server" TextMode="MultiLine" Rows="10" Columns="50"></asp:TextBox>


             <p><a href="../Default.aspx">Volver a la página principal</a></p>
        </div>
    </form>
</body>
</html>
