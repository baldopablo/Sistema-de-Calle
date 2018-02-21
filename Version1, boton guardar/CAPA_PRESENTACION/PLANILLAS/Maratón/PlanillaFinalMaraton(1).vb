Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class PlanillaFinalMaraton

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario

    Dim capanegocio2 As New CNAtletas_x_Competencia

    Private Sub PlanillaFinalMaraton_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

    End Sub

    Sub PrepararFormulario()
        cargarlista()
        Label3.Visible = False
        Label13.Visible = False
        txtCodigoPlanillaMaraton.Visible = False
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
        'Me.dgvAtletasdeMaraton.Columns("Id_Atleta").Visible = False
        'Me.dgvAtletasdeMaraton.Columns("Id_Resultado_Parcial").Visible = False
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim localidadNombre As String = cNegVarios.NombreLocalidadPorId(atleta.id_localidad)
        Dim sexoNombre As String = cNegVarios.NombreSexoPorId(atleta.id_sexo)
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PlanillaFinalMaraton.dgvAtletasdeMaraton.Rows.Add(atleta.dorsal,
                                                          atleta.Nombre_atleta, _
                                                          atleta.Apellido_atleta,
                                                          clubNombre)
    End Sub

    Sub cargarlista()
        dgvAtletasdeMaraton.DataSource = capanegocio2.Planilla_Resultado_Final_Maraton.Tables("Planilla_Resultado_Final_Maraton")
        dgvAtletasdeMaraton.Columns(0).HeaderText = "Dorsal"
        dgvAtletasdeMaraton.Columns(1).HeaderText = "Nombre"
        dgvAtletasdeMaraton.Columns(2).HeaderText = "Apellido"
        dgvAtletasdeMaraton.Columns(3).HeaderText = "Club/federación"
        dgvAtletasdeMaraton.Columns(4).HeaderText = "Mejor"
        dgvAtletasdeMaraton.Columns(5).HeaderText = "Posición"
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Final_Maraton.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class