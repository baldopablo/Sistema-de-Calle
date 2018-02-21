Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanillaFinalMedio_Fondo

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario
    Dim capanegocio2 As New CNAtletas_x_Competencia

    Private Sub PlanillaFinalMedio_Fondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        cargarlista()
        Label1.Visible = False
        Label18.Visible = False
        txtCodigoMedioFondo.Visible = False
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
        '    Me.dgvPlanillaFinalMedioFondo.Columns("Id_Atleta").Visible = False
        '    Me.dgvPlanillaFinalMedioFondo.Columns("Id_Resultado_Parcial").Visible = False
        'End Sub
    End Sub
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Medio_Fondo.ShowDialog()
    End Sub

    Sub cargarlista()
        dgvPlanillaFinalMedioFondo.DataSource = capanegocio2.Planilla_Resultado_Final_Medio_Fondo.Tables("Planilla_Resultado_Final_Medio_Fondo")
        dgvPlanillaFinalMedioFondo.Columns(0).HeaderText = "Dorsal"
        dgvPlanillaFinalMedioFondo.Columns(1).HeaderText = "Nombre"
        dgvPlanillaFinalMedioFondo.Columns(2).HeaderText = "Apellido"
        dgvPlanillaFinalMedioFondo.Columns(3).HeaderText = "Club/federación"
        dgvPlanillaFinalMedioFondo.Columns(4).HeaderText = "Mejor"
        dgvPlanillaFinalMedioFondo.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class