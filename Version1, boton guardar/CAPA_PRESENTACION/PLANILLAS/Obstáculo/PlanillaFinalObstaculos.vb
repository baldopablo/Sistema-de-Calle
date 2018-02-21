Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanillaFinalObstaculos

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario
    Dim capanegocio2 As New CNAtletas_x_Competencia

    Private Sub PlanillaFinalObstaculos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        cargarlista()
        Label1.Visible = False
        txtCodigoObstaculos.Visible = False
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
        Label15.Visible = False
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Obstaculos.ShowDialog()
    End Sub

    Sub cargarlista()
        dgvPlanillaFinalObstaculos.DataSource = capanegocio2.Planilla_Resultado_Final_Obstaculos.Tables("Planilla_Resultado_Final_Obstaculos")
        dgvPlanillaFinalObstaculos.Columns(0).HeaderText = "Dorsal"
        dgvPlanillaFinalObstaculos.Columns(1).HeaderText = "Nombre"
        dgvPlanillaFinalObstaculos.Columns(2).HeaderText = "Apellido"
        dgvPlanillaFinalObstaculos.Columns(3).HeaderText = "Club/federación"
        dgvPlanillaFinalObstaculos.Columns(4).HeaderText = "Mejor"
        dgvPlanillaFinalObstaculos.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class