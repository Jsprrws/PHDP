<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarPaises.aspx.cs" Inherits="PHDP.MostrarPaises" %>



<!DOCTYPE html>
<html>
<head>
    <title>Mostrar países</title>
        <style>
        table {
            border-collapse: collapse;
            width: 100%;
        }
        
        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <h2>Lista de países</h2>

    <table>
        <tr>
            <th>ID_país</th>
            <th>Nombre</th>
        </tr>
        <% foreach (var pais in Model) { %>
            <tr>
                <td><%: pais.ID_país %></td>
                <td><%: pais.Nombre %></td>
            </tr>
        <% } %>
    </table>
    <p><a href="../Default.aspx">Volver a la página principal</a></p>
</body>
</html>