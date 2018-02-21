Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class PlanillaFinalLanzamiento

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario
    Dim capanegocio As New CNAtletas
    Dim capanegocio2 As New CNAtletas_x_Competencia

    Private Sub PlanillaFinalLanzamiento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        cargarlista()
    End Sub

    Sub cargarlista()
        dgvFinalLanzamiento.DataSource = capanegocio2.Planilla_Resultado_Final_Lanzamiento.Tables("Planilla_Resultado_Final_Lanzamiento")
        dgvFinalLanzamiento.Columns(0).HeaderText = "Dorsal"
        dgvFinalLanzamiento.Columns(1).HeaderText = "Nombre"
        dgvFinalLanzamiento.Columns(2).HeaderText = "Apellido"
        dgvFinalLanzamiento.Columns(3).HeaderText = "Club/federación"
        dgvFinalLanzamiento.Columns(4).HeaderText = "Descripción"
        dgvFinalLanzamiento.Columns(4).Visible = False
        dgvFinalLanzamiento.Columns(4).HeaderText = "Mejor"
        dgvFinalLanzamiento.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Lanzamiento.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class