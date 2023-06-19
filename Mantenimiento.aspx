<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mantenimiento.aspx.cs" Inherits="PHDP.Mantenimiento" %>

<!DOCTYPE html>
<html>
<head>
    <title>Mantenimiento</title>
</head>
<body>
    <form id="formMantenimiento" runat="server">
        <div>
            <label>Año:</label>
            <asp:TextBox ID="txtAnio" runat="server"></asp:TextBox>
            <br />
            <label>Empresa:</label>
            <asp:DropDownList ID="ddlEmpresa" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
        </div>
        <br />
        <asp:GridView ID="gridResultados" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID_contrato" HeaderText="ID Contrato" />
                <asp:BoundField DataField="Fecha_inicio" HeaderText="Fecha Inicio" />
                <asp:BoundField DataField="Fecha_terminacion" HeaderText="Fecha Terminación" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" CommandArgument='<%# Eval("ID_contrato") %>' />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("ID_contrato") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p><a href="../Default.aspx">Volver a la página principal</a></p>
    </form>
</body>
</html>
