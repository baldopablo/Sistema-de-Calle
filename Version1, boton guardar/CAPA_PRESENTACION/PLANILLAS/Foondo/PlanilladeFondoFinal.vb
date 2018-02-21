Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanilladeFondoFinal

    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Dim capanegocio2 As New CNAtletas_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub PlanillaFinalFondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        cargarlista()
        Label1.Visible = False
        Label22.Visible = False
        txtcodigofondo.Visible = False
        cboUsuario.Visible = False
        cboLocalidad.Enabled = False
        cboProvincia.Enabled = False
        cboPrueba.Enabled = False
        cboUsuario.Visible = False
        dtpfechainicio.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        ' Me.dgvPlanillaFinalFondo.Columns("Id_Atleta").Visible = False
        'Me.dgvPlanillaFinalFondo.Columns("Id_Resultado_Parcial").Visible = False
    End Sub

    Sub cargarlista()
        dgvPlanillaFinalFondo.DataSource = capanegocio2.Planilla_Resultado_Final_Fondo.Tables("Planilla_Resultado_Final_Fondo")
        dgvPlanillaFinalFondo.Columns(0).HeaderText = "Dorsal"
        dgvPlanillaFinalFondo.Columns(1).HeaderText = "Nombre"
        dgvPlanillaFinalFondo.Columns(2).HeaderText = "Apellido"
        dgvPlanillaFinalFondo.Columns(3).HeaderText = "Club/federación"
        dgvPlanillaFinalFondo.Columns(4).HeaderText = "Mejor"
        dgvPlanillaFinalFondo.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Fondo.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class