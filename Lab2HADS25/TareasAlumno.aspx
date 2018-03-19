<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TareasAlumno.aspx.vb" Inherits="Lab2HADS25.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alumnos gestión de tareas</title>
    
</head>
<body>
    <form id="form1" runat="server">

    <div style="background-color: #99CCFF">
        <asp:LinkButton ID="LinkButton1" runat="server">Cerrar sesión</asp:LinkButton>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <h1 style="text-align: center">ALUMNOS</h1>
        <h1 style="text-align: center">GESTIÓN DE TAREAS GENÉRICAS</h1>
    </div>

        <asp:DropDownList ID="asignaturas" runat="server">
        </asp:DropDownList>

        <asp:GridView ID="tablaFinal" runat="server">
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Instanciar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
