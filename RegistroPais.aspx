<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroPais.aspx.cs" Inherits="PHDP.RegistroPais" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingresar País</title>
        <style>
        .centrado-formulario {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
}
    </style>
</head>
<body>
    <form id="form1" runat="server" class="centrado-formulario">
        <div>
            <h2>Ingresar País</h2>
            <asp:Label ID="lblMensaje" runat="server" Visible="false" />
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del país"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <p><a href="../Default.aspx">Volver a la página principal</a></p>
        </div>
    </form>
</body>
</html>

