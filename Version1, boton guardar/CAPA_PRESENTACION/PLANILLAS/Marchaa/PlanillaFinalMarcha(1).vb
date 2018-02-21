Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class PlanillaFinalMarcha

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Dim capanegocio2 As New CNAtletas_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub PlanillaFinalMarcha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub
    Sub PrepararFormulario()
        cargarlista()
        Label1.Visible = False
        Label18.Visible = False
        txtCodigoMarcha.Visible = False
        cboUsuario.Visible = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboPrueba.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        dtpfechainicio.Enabled = False
        '    Me.dgvAtletasdeCalle.Columns("Id_Atleta").Visible = False
        '    Me.dgvAtletasdeCalle.Columns("Id_Resultado_Parcial").Visible = False
    End Sub

    Sub cargarlista()
        dgvAtletasdeMarcha.DataSource = capanegocio2.Planilla_Resultado_Final_Marcha.Tables("Planilla_Resultado_Final_Marcha")
        dgvAtletasdeMarcha.Columns(0).HeaderText = "Dorsal"
        dgvAtletasdeMarcha.Columns(1).HeaderText = "Nombre"
        dgvAtletasdeMarcha.Columns(2).HeaderText = "Apellido"
        dgvAtletasdeMarcha.Columns(3).HeaderText = "Club/federación"
        dgvAtletasdeMarcha.Columns(4).HeaderText = "Mejor"
        dgvAtletasdeMarcha.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Marcha.ShowDialog()
    End Sub
End Class