Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanillaFinalVelocidad

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Dim capanegocio2 As New CNAtletas_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub PlanillaFinalMedioFondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        Label1.Visible = False
        Label19.Visible = False
        cboCategoria.Visible = False
        txtCodigoVelocidad.Visible = False
        dtpfechainicio.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cargarlista()
        'Me.dgvPlanillaVelocidad.Columns("Id_Atleta").Visible = False
        ' Me.dgvPlanillaVelocidad.Columns("Id_Resultado_Parcial").Visible = False
    End Sub

    Sub cargarlista()
        dgvPlanillaVelocidad.DataSource = capanegocio2.Planilla_Resultado_Final_Velocidad_Serie_Unica.Tables("Planilla_Resultado_Final_Velocidad_Serie_Unica")
        dgvPlanillaVelocidad.Columns(0).HeaderText = "Dorsal"
        dgvPlanillaVelocidad.Columns(1).HeaderText = "Nombre"
        dgvPlanillaVelocidad.Columns(2).HeaderText = "Apellido"
        dgvPlanillaVelocidad.Columns(3).HeaderText = "Club/federación"
        dgvPlanillaVelocidad.Columns(4).HeaderText = "Mejor"
        dgvPlanillaVelocidad.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Velocidad.ShowDialog()
    End Sub
End Class