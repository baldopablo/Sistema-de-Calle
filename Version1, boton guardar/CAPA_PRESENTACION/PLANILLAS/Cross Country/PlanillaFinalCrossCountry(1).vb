Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class PlanillaFinalCrossCountry

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Dim capanegocio2 As New CNAtletas_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub PlanillaFinalCrossCountry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        Label3.Visible = False
        Label13.Visible = False
        txtCodigoPlanillaFinalCrossCountry.Visible = False
        cboUsuario.Visible = False
        cboSexo.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboPrueba.Enabled = False
        dtpfechainicio.Enabled = False
        cboCategoria.Enabled = False
        cargarlista()
        'Me.dgvAtletasdeCrossCountry.Columns("Id_Atleta").Visible = False
        'Me.dgvAtletasdeCrossCountry.Columns("Id_Resultado_Parcial").Visible = False
    End Sub

    Sub cargarlista()
        dgvAtletasdeCrossCountry.DataSource = capanegocio2.Planilla_Resultado_Final_Cross_Country.Tables("Planilla_Resultado_Final_Cross_Country")
        dgvAtletasdeCrossCountry.Columns(0).HeaderText = "Dorsal"
        dgvAtletasdeCrossCountry.Columns(1).HeaderText = "Nombre"
        dgvAtletasdeCrossCountry.Columns(2).HeaderText = "Apellido"
        dgvAtletasdeCrossCountry.Columns(3).HeaderText = "Club/federación"
        dgvAtletasdeCrossCountry.Columns(4).HeaderText = "Mejor"
        dgvAtletasdeCrossCountry.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Cross_Country.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class