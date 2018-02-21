Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class PlanillaFinalSaltoLargoyTriple

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario
    Dim capanegocio As New CNAtletas
    Dim capanegocio2 As New CNAtletas_x_Competencia

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Salto.ShowDialog()
    End Sub

    Private Sub PlanillaFinalSaltoLargoyTriple_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        cargarlista()
        txtNombre.Enabled = False
        txtLugar.Enabled = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        dtpFechaInicio.Enabled = False
        txtHora.Enabled = False
        cboPrueba.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboJuez1.Enabled = False

    End Sub

    Sub cargarlista()
        dgvFinalSalto.DataSource = capanegocio2.Planilla_Resultado_Final_Salto.Tables("Planilla_Resultado_Final_Salto")
        dgvFinalSalto.Columns(0).HeaderText = "Dorsal"
        dgvFinalSalto.Columns(1).HeaderText = "Nombre"
        dgvFinalSalto.Columns(2).HeaderText = "Apellido"
        dgvFinalSalto.Columns(3).HeaderText = "Club/federación"
        dgvFinalSalto.Columns(4).HeaderText = "Descripción"
        dgvFinalSalto.Columns(4).Visible = False
        dgvFinalSalto.Columns(4).HeaderText = "Mejor"
        dgvFinalSalto.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class