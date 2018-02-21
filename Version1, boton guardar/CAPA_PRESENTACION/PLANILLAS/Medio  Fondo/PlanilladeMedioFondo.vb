Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanilladeMedioFondo

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

    Private Sub PlanilladeMedioFondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

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

        'cboCategoria.Enabled = False
        'cboSexo.Enabled = False

        Dim cantidad As DataGridView = CType(dgvPlanillaMedioFondo, DataGridView)
        If cboPrueba.Text = "800 metros" Or cboPrueba.Text = "1200 metros" Then
            If cantidad.Rows.Count >= 24 Then
                MessageBox.Show("Ha sido agregado el último atleta, no se permiten mas ingresos")
                btnAgregarAtleta.Enabled = False
                Return
            End If
        Else
            If cboPrueba.Text = "1500 metros" Then
                If cantidad.Rows.Count >= 48 Then
                    MessageBox.Show("Ha sido agregado el último atleta, no se permiten mas ingresos")
                    btnAgregarAtleta.Enabled = False
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub btnQuitarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click
        If dgvPlanillaMedioFondo.Rows.Count <> 0 Then
            dgvPlanillaMedioFondo.Rows.RemoveAt(dgvPlanillaMedioFondo.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PrepararFormulario()
        btnAgregarAtleta.Enabled = True
        btnQuitarAtleta.Enabled = True
        btnImprimir.Enabled = False
        btnComenzar.Enabled = False
        btnCerrar.Enabled = True
        btnIngresarTiempos.Enabled = False
        Label1.Visible = False
        txtCodigoMedioFondo.Visible = False
        btnActualizar.Enabled = False
        btnGuardar.Enabled = True
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboPrueba.Enabled = False
        Label22.Visible = False
        cboUsuario.Visible = False
        dtpfechainicio.Enabled = False
        Me.dgvPlanillaMedioFondo.Columns("Id_Atleta").Visible = True
        Me.dgvPlanillaMedioFondo.Columns("Seleccionar").ReadOnly = False
        cboCategoria.SelectedIndex = 0
        cboSexo.SelectedIndex = 0
        Me.dgvPlanillaMedioFondo.Columns(0).Visible = False
        juezprincipal1()
        juezprincipal2()
        juezprincipal3()
        Nuevo_Codigo_Resultado_x_Atleta()
        Nuevo_Codigo_Resultado_x_Competencia()
        Nuevo_Codigo_Atleta_x_Competencia()
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

    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click
       
        If Me.dgvPlanillaMedioFondo.Rows.Count = 0 Then
            MessageBox.Show("Ingrese a los atletas que participarán de la competencia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim dgv As DataGridView = CType(dgvPlanillaMedioFondo, DataGridView)
        If cboJuez1.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione un Juez")
            cboJuez1.Focus()
            Return
        End If
        If cboJuez2.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione un Juez")
            cboJuez2.Focus()
            Return
        End If
        If cboJuez3.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione un Juez")
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
        ''SERIE DE 8 ATLETAS
        ''If cboPrueba.Text = "800 metros" Or cboPrueba.Text = "1200 metros" Then
        'If dgv.Rows.Count >= 1 And dgv.Rows.Count <= 2 Then

        '    Me.dgvPlanillaMedioFondo.Columns(0).Visible = False
        '    'SERIE DE 16 ATLETAS
        'ElseIf dgv.Rows.Count >= 3 And dgv.Rows.Count <= 4 Then
        '    Me.dgvPlanillaMedioFondo.Columns(0).Visible = True

        '    'SERIE DE 24 ATLETAS
        'ElseIf dgv.Rows.Count >= 5 And dgv.Rows.Count <= 6 Then


        'End If
        '' Else
        ''SERIE DE 16 ATLETAS
        'If cboPrueba.Text = "1500 metros" Then
        '    If dgv.Rows.Count >= 1 And dgv.Rows.Count <= 16 Then

        '        'SERIE DE 32 ATLETAS
        '    ElseIf dgv.Rows.Count >= 17 And dgv.Rows.Count <= 32 Then

        '        'SERIE DE 48 ATLETAS
        '    ElseIf dgv.Rows.Count >= 33 And dgv.Rows.Count <= 48 Then

        '    End If
        'End If
        '' End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If Me.dgvPlanillaMedioFondo.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        Dim objeto As New CEAtletas_x_Competencia
        Dim objeto1 As New CEResultados_x_Atleta
        Dim objeto2 As New CEResultados_x_Competencia

        Try
            For Each rows As DataGridViewRow In Me.dgvPlanillaMedioFondo.Rows

                'LO QUE SE VA A GUARDAR EN LA TABLA RESULTADO POR COMPETENCIA
                objeto2.id_atleta = rows.Cells(1).Value
                objeto2.id_resultado_x_competencia = rows.Cells(6).Value
                objeto2.id_competencia = txtCodigoMedioFondo.Text
                objeto2.serie = txtSerie.Text
                objeto2.valor = txtValor.Text
                objeto2.descripcion = txtDescripcion.Text
                objeto2.mejor = txtMejor.Text
                objeto2.posicion = txtPosicion.Text

                capanegocio6.Nuevo_Resultado_x_Competencia(objeto2)

                ' genera un nuevo codigo de resultado por competencia
                rows.Cells(6).Value = Nuevo_Codigo_Resultado_x_Competencia()

                ' LO QUE SE VA A GUARDAR EN LA TABLA ATLETAS POR COMPETENCIA
                objeto.id_competencia = txtCodigoMedioFondo.Text
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
        cboCategoria.Enabled = False
        cboSexo.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False

    End Sub

    Sub Nuevo_Codigo_Resultado_x_Atleta()
        txtResultado_x_Atleta.Text = capanegocio5.Nuevo_Codigo_Resultado_x_Atleta
    End Sub

    Function Nuevo_Codigo_Resultado_x_Competencia()
        Return capanegocio6.Nuevo_Codigo_Resultado_x_Competencia
    End Function

    Sub Nuevo_Codigo_Atleta_x_Competencia()
        txtAtleta_x_Competencia.Text = capanegocio4.Nuevo_Codigo_Atleta_x_Competencia
    End Sub

    Private Sub btnAgregarSerie1_Click(sender As System.Object, e As System.EventArgs)
        'Se define una lista temporal de registro seleccionados
        Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
        'Se recorre cada registro del grid de origen
        For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
            'Se recupera el campo que representa el checkbox,
            'se valida que esté seleccionado y agregándolo a la lista temporal
            Dim cellSelecion As DataGridViewCheckBoxCell = _
            TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                FilasSeleccionadas.Add(row)
            End If
        Next

        'Se agrega el ítem seleccionado al grid de destino
        'eliminando la fila del grid original
        For Each row As DataGridViewRow In FilasSeleccionadas
            PlanillaSerieUnicaMedioFondo.dgvSerie1.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value)
            dgvPlanillaMedioFondo.Rows.Remove(row)
        Next
        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            PlanillaSerieUnicaMedioFondo.dgvSerie1.Rows.Add(New Object() {row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value})
        Next
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PlanilladeMedioFondo.dgvPlanillaMedioFondo.Rows.Add(0,
                                                            atleta.id_atleta,
                                                            atleta.dorsal,
                                                            atleta.Apellido_atleta,
                                                            atleta.Nombre_atleta,
                                                            clubNombre)
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Medio_Fondo.ShowDialog()
    End Sub

    Private Sub btnIngresarTiempos_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresarTiempos.Click
        RellenarFormulario()
       
    End Sub

    Sub RellenarFormulario()
       
        txtEstado.Text = "En Curso"
        PlanillaSerieUnicaMedioFondo.txtCodigoMedioFondo.Text = Me.txtCodigoMedioFondo.Text
        PlanillaSerieUnicaMedioFondo.txtNombre.Text = Me.txtNombre.Text
        PlanillaSerieUnicaMedioFondo.txtLugar.Text = Me.txtLugar.Text
        PlanillaSerieUnicaMedioFondo.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaSerieUnicaMedioFondo.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaSerieUnicaMedioFondo.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaSerieUnicaMedioFondo.txtHora.Text = Me.txtHora.Text
        PlanillaSerieUnicaMedioFondo.txtEstado.Text = Me.txtEstado.Text
        PlanillaSerieUnicaMedioFondo.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaSerieUnicaMedioFondo.cboJuez2.Text = Me.cboJuez2.Text
        PlanillaSerieUnicaMedioFondo.cboJuez3.Text = Me.cboJuez3.Text
        PlanillaSerieUnicaMedioFondo.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaSerieUnicaMedioFondo.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaSerieUnicaMedioFondo.cboSexo.Text = Me.cboSexo.Text
        PlanillaSerieUnicaMedioFondo.cboCategoria.Text = Me.cboCategoria.Text

        PlanillaSerieUnicaMedioFondo.ShowDialog()

    End Sub
End Class