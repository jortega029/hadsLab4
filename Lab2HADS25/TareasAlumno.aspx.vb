Imports AccesoDatos.AccesoDatosSQL
Imports System.Data.SqlClient
Imports System.Drawing
Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usuario = Session("Usuario")
        Label1.Text = "Bienvenido/a " & usuario
        asignaturas.AutoPostBack = True
        If Not Page.IsPostBack Then
            Dim dr As SqlDataReader
            dr = obtenerAsignaturas(usuario)
            While dr.Read
                asignaturas.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
            Dim da = obtenerTareas(usuario, asignaturas.SelectedValue)
            Dim ds As New DataSet
            da.Fill(ds, "TareasGenericas")
            Dim dt = ds.Tables("tareasGenericas")

            tablaFinal.DataSource = dt
            tablaFinal.DataBind()
            Session("ds") = ds
            Session("tabla") = dt
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Clear()
        Response.Redirect("Inicio.aspx")
    End Sub

    Protected Sub asignaturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles asignaturas.SelectedIndexChanged
        Dim da = obtenerTareas(Session("Usuario"), asignaturas.SelectedValue)
        Dim ds As New DataSet
        da.Fill(ds, "TareasGenericas")
        Dim dt = ds.Tables("tareasGenericas")
        Session("tabla") = dt

        tablaFinal.DataSource = dt
        tablaFinal.DataBind()
    End Sub

    Protected Sub tablaFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tablaFinal.SelectedIndexChanged
        Dim tabla = Session("tabla")
        Dim codigo = tabla.Rows(tablaFinal.SelectedIndex).Item("Codigo")
        Dim horas = tabla.Rows(tablaFinal.SelectedIndex).Item("HEstimadas")
        Dim usuario = Session("usuario")
        Response.Redirect("InstanciarTarea.aspx?tarea=" & codigo & "&usuario=" & usuario & "&horas=" & horas)
    End Sub

    Protected Sub SortRecords(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim sortExpression As String = e.SortExpression
        Dim direction As String = String.Empty

        If SortDirection = SortDirection.Ascending Then

            SortDirection = SortDirection.Descending

            direction = " DESC"

        Else

            SortDirection = SortDirection.Ascending

            direction = " ASC"

        End If

        Dim table As DataTable = Session("tabla")

        table.DefaultView.Sort = sortExpression & direction

        tablaFinal.DataSource = table

        tablaFinal.DataBind()

    End Sub



    Public Property SortDirection() As SortDirection

        Get

            If ViewState("SortDirection") Is Nothing Then

                ViewState("SortDirection") = SortDirection.Ascending

            End If

            Return DirectCast(ViewState("SortDirection"), SortDirection)

        End Get

        Set(ByVal value As SortDirection)

            ViewState("SortDirection") = value

        End Set

    End Property
End Class