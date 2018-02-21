Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanillaDeVelocidad

    Public Property Id_Competencia As Int32
    Dim capanegocio As New CNCompetencias
    Dim capanegocio1 As New CNAtletas
    Dim capanegocio3 As New CNResultadoParcial
    Dim capanegocio4 As New CNAtletas_x_Competencia
    Dim capanegocio5 As New CNResultados_x_Atleta
    Dim capanegocio6 As New CNResultados_x_Competencia

    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario


    Private Sub btnAgregarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarAtleta.Click
        'VALIDA QUE SE SELECCIONE SEXO Y CATEGORIA
        If cboSexo.Text = "--Seleccionar--" And cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Sexo y una Categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboSexo.Focus()
            Return
        End If

        'VALIDA QUE SE SELECCIONE SEXO
        If cboSexo.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Sexo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboSexo.Focus()
            Return
        End If

        'VALIDA QUE SE SELECCIONE CATEGORIA
        If cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar una Categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboCategoria.Focus()
            Return
        End If

        LISTA_DE_ATLETAS.TipoDeFormulario = TipoFormulario.DatosAdicionalesDelAtleta
        LISTA_DE_ATLETAS.ShowDialog()

        cboCategoria.Enabled = False
        cboSexo.Enabled = False

        Dim cantidad As DataGridView = CType(dgvPlanillaVelocidad, DataGridView)
        If cantidad.Rows.Count >= 24 Then
            MessageBox.Show("Ha sido agregado el último atleta, no se permiten mas ingresos")
            btnAgregarAtleta.Enabled = False
            Return
        End If
    End Sub

    Private Sub btnQuitarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click
        If dgvPlanillaVelocidad.Rows.Count <> 0 Then
            dgvPlanillaVelocidad.Rows.RemoveAt(dgvPlanillaVelocidad.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)

        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PlanillaDeVelocidad.dgvPlanillaVelocidad.Rows.Add(0,
                                                          atleta.id_atleta,
                                                            atleta.dorsal,
                                                          atleta.Apellido_atleta,
                                                          atleta.Nombre_atleta, _
                                                          clubNombre)
    End Sub

    Private Sub PrepararFormulario()
        btnAgregarAtleta.Enabled = True '
        btnQuitarAtleta.Enabled = True '
        btnImprimir.Enabled = False '
        btnComenzar.Enabled = False '
        btnCerrar.Enabled = True '
        btnIngresarTiempos.Enabled = False
        btnGuardar.Enabled = True
        Label1.Visible = False
        txtCodigoVelocidad.Visible = False
        btnActualizar.Enabled = False '
        Label15.Visible = False
        cboUsuario.Visible = False
        Me.dgvPlanillaVelocidad.Columns("Id_Atleta").Visible = True
        cboCategoria.SelectedIndex = 0
        cboSexo.SelectedIndex = 0
        juezprincipal1()
        juezprincipal2()
        juezprincipal3()
        Nuevo_Codigo_Resultado_x_Atleta()
        Nuevo_Codigo_Resultado_x_Competencia()
        Nuevo_Codigo_Atleta_x_Competencia()
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboPrueba.Enabled = False
       
        Me.dgvPlanillaVelocidad.Columns("Seleccionar").ReadOnly = False
    End Sub
    Sub juezprincipal1()
        'TODO: Hacer lo mismo en todos los combos que lleven seleccionar
        Dim miVista As DataView = capanegocio.JuezPrincipal1.Tables("Apellido de Jueces").DefaultView
        miVista.Sort = "Nombre_Juez"
        Dim sortedDT As DataTable = miVista.ToTable()
        cboJuez1.DataSource = sortedDT
        cboJuez1.DisplayMember = "Apellido_Juez"
        cboJuez1.ValueMember = "Id_Juez"
        '--Seleccionar--
        'dejo seleccionado el "seleccionar" por defecto
        cboJuez1.SelectedIndex = 0
    End Sub

    Sub juezprincipal2()
        Dim miVista As DataView = capanegocio.JuezPrincipal2.Tables("Apellido de Jueces").DefaultView
        miVista.Sort = "Nombre_Juez"
        Dim sortedDT As DataTable = miVista.ToTable()
        cboJuez2.DataSource = sortedDT
        cboJuez2.DisplayMember = "Apellido_Juez"
        cboJuez2.ValueMember = "Id_Juez"
        '--Seleccionar--
        'dejo seleccionado el "seleccionar" por defecto
        cboJuez2.SelectedIndex = 0
    End Sub

    Sub juezprincipal3()
        Dim miVista As DataView = capanegocio.JuezPrincipal3.Tables("Apellido de Jueces").DefaultView
        miVista.Sort = "Nombre_Juez"
        Dim sortedDT As DataTable = miVista.ToTable()
        cboJuez3.DataSource = sortedDT
        cboJuez3.DisplayMember = "Apellido_Juez"
        cboJuez3.ValueMember = "Id_Juez"
        '--Seleccionar--
        'dejo seleccionado el "seleccionar" por defecto
        cboJuez3.SelectedIndex = 0
    End Sub

    Private Sub PlanillaDeVelocidad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click

        If Me.dgvPlanillaVelocidad.Rows.Count = 0 Then
            MessageBox.Show("Ingrese a los atletas que participarán de la competencia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If cboJuez1.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Juez")
            cboJuez1.Focus()
            Return
        End If
        If cboJuez2.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Juez")
            cboJuez2.Focus()
            Return
        End If
        If cboJuez3.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Juez")
            cboJuez3.Focus()
            Return
        End If
        If cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Categoría")
            cboCategoria.Focus()
            Return
        End If
        If cboSexo.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione un Sexo")
            cboSexo.Focus()
            Return
        End If

        btnCerrar.Enabled = True
        btnImprimir.Enabled = True
        btnActualizar.Enabled = False
        btnIngresarTiempos.Enabled = True
        'Dim dgv As DataGridView = CType(dgvPlanillaVelocidad, DataGridView)
        'If dgv.Rows.Count >= 1 And dgv.Rows.Count <= 2 Then
        'ElseIf dgv.Rows.Count >= 3 And dgv.Rows.Count <= 4 Then
        'ElseIf dgv.Rows.Count >= 5 And dgv.Rows.Count <= 6 Then
        'End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        If Me.dgvPlanillaVelocidad.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        Dim objeto As New CEAtletas_x_Competencia
        Dim objeto1 As New CEResultados_x_Atleta
        Dim objeto2 As New CEResultados_x_Competencia

        Try
            For Each rows As DataGridViewRow In Me.dgvPlanillaVelocidad.Rows

                'LO QUE SE VA A GUARDAR EN LA TABLA RESULTADO POR COMPETENCIA
                objeto2.id_atleta = rows.Cells(1).Value
                objeto2.id_resultado_x_competencia = rows.Cells(6).Value
                objeto2.id_competencia = txtCodigoVelocidad.Text
                objeto2.serie = txtSerie.Text
                objeto2.valor = txtValor.Text
                objeto2.descripcion = txtDescripcion.Text
                objeto2.mejor = txtMejor.Text
                objeto2.posicion = txtPosicion.Text

                capanegocio6.Nuevo_Resultado_x_Competencia(objeto2)

                ' genera un nuevo codigo de resultado por competencia
                rows.Cells(6).Value = Nuevo_Codigo_Resultado_x_Competencia()

                ' LO QUE SE VA A GUARDAR EN LA TABLA ATLETAS POR COMPETENCIA
                objeto.id_competencia = txtCodigoVelocidad.Text
                objeto.id_atleta = rows.Cells(1).Value
                objeto.id_resultado_atleta = 1
                objeto.id_resultado_competencia = rows.Cells(6).Value
                objeto.Id_atleta_x_competencia = txtAtleta_x_Competencia.Text

                capanegocio4.Nuevo_Atleta_x_Competencia(objeto)

            Next
            MsgBox("Se guardado correctamente la lista de atletas")
            Nuevo_Codigo_Resultado_x_Atleta()
            Nuevo_Codigo_Resultado_x_Competencia()
            Nuevo_Codigo_Atleta_x_Competencia()
        Catch ex As Exception
            MsgBox("No se pudo guardar la lista de atletas", MsgBoxStyle.Critical)
        End Try
        btnComenzar.Enabled = True
        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        btnImprimir.Enabled = True
        btnGuardar.Enabled = False
        btnCerrar.Enabled = True
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False

    End Sub

    Function Nuevo_Codigo_Resultado_x_Competencia()
        Return capanegocio6.Nuevo_Codigo_Resultado_x_Competencia()
    End Function

    Sub Nuevo_Codigo_Resultado_x_Atleta()
        txtResultado_x_Atleta.Text = capanegocio5.Nuevo_Codigo_Resultado_x_Atleta
    End Sub

    Sub Nuevo_Codigo_Atleta_x_Competencia()
        txtAtleta_x_Competencia.Text = capanegocio4.Nuevo_Codigo_Atleta_x_Competencia
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Velocidad.ShowDialog()
    End Sub

    Private Sub btnIngresarTiempos_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresarTiempos.Click
        RellenarCampos()
        PlanilladeSerieUnicaVelocidad.Close()
    End Sub

    Sub RellenarCampos()
        txtEstado.Text = "En Curso"
        PlanilladeSerieUnicaVelocidad.txtCodigoVelocidad.Text = Me.txtCodigoVelocidad.Text
        PlanilladeSerieUnicaVelocidad.txtNombre.Text = Me.txtNombre.Text
        PlanilladeSerieUnicaVelocidad.txtLugar.Text = Me.txtLugar.Text
        PlanilladeSerieUnicaVelocidad.cboProvincia.Text = Me.cboProvincia.Text
        PlanilladeSerieUnicaVelocidad.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanilladeSerieUnicaVelocidad.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanilladeSerieUnicaVelocidad.txtHora.Text = Me.txtHora.Text
        PlanilladeSerieUnicaVelocidad.txtEstado.Text = Me.txtEstado.Text
        PlanilladeSerieUnicaVelocidad.cboJuez1.Text = Me.cboJuez1.Text
        PlanilladeSerieUnicaVelocidad.cboJuez2.Text = Me.cboJuez2.Text
        PlanilladeSerieUnicaVelocidad.cboJuez3.Text = Me.cboJuez3.Text
        PlanilladeSerieUnicaVelocidad.cboUsuario.Text = Me.cboUsuario.Text
        PlanilladeSerieUnicaVelocidad.cboPrueba.Text = Me.cboPrueba.Text
        PlanilladeSerieUnicaVelocidad.cboSexo.Text = Me.cboSexo.Text
        PlanilladeSerieUnicaVelocidad.cboCategoria.Text = Me.cboCategoria.Text
        PlanilladeSerieUnicaVelocidad.Show()
    End Sub
End Class

