Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanillaMaraton

    Public Property Id_Competencia As Int32
    Dim capanegocio As New CNCompetencias
    Dim capanegocio1 As New CNAtletas
    Dim capanegocio3 As New CNResultadoParcial
    Dim capanegocio4 As New CNAtletas_x_Competencia
    Dim capanegocio5 As New CNResultados_x_Atleta
    Dim capanegocio6 As New CNResultados_x_Competencia

    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property Resultado_x_Atleta As New CEResultados_x_Atleta
    Shared Property Resultado_x_Competencia As New CEResultados_x_Competencia
    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia
    Shared Property ResultadoSeleccionado As New CeResultadoParcial
    Public Property TipoDeFormulario As TipoFormulario
    'controlar
    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Try
           
            ResultadoSeleccionado.Tiempo1 = dgvAtletasdeMaraton.CurrentRow.Cells.Item("Tiempo1").Value
            ResultadoSeleccionado.Tiempo2 = dgvAtletasdeMaraton.CurrentRow.Cells.Item("Tiempo2").Value
            ResultadoSeleccionado.Tiempo3 = dgvAtletasdeMaraton.CurrentRow.Cells.Item("Tiempo3").Value
            ResultadoSeleccionado.mejor_tiempo_maraton = dgvAtletasdeMaraton.CurrentRow.Cells.Item("Tiempo_Final_Maraton").Value
            ResultadoSeleccionado.clasificacion_maraton = dgvAtletasdeMaraton.CurrentRow.Cells.Item("Clasificación_Maraton").Value

            capanegocio3.ActualizarResultado(ResultadoSeleccionado)
            MsgBox("Los datos de la Planilla han sido actualizados correctamente")
        Catch ex As Exception
            MsgBox("Error al actualizar los datos de la Planilla")
        End Try
    End Sub

    Private Sub PlanillaMaraton_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub btnQuitarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click
        If dgvAtletasdeMaraton.Rows.Count <> 0 Then
            dgvAtletasdeMaraton.Rows.RemoveAt(dgvAtletasdeMaraton.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click
        If Me.dgvAtletasdeMaraton.Rows.Count = 0 Then
            MessageBox.Show("Debe ingresar atletas para poder comenzar a registrar los Tiempos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        ' VALIDACION DE JUECES
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
        btnIngresar.Enabled = True
        btnActualizar.Enabled = False

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

    

    Private Sub btnIngresar_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresar.Click
        txtEstado.Text = "En Curso"
        IngresodeTiemposMaraton.txtCodigoPlanillaMaraton.Text = Me.txtCodigoMaraton.Text
        IngresodeTiemposMaraton.txtNombre.Text = Me.txtNombre.Text
        IngresodeTiemposMaraton.txtLugar.Text = Me.txtLugar.Text
        IngresodeTiemposMaraton.cboProvincia.Text = Me.cboProvincia.Text
        IngresodeTiemposMaraton.cboLocalidad.Text = Me.cboLocalidad.Text
        IngresodeTiemposMaraton.dtpfechainicio.Text = Me.dtpfechainicio.Text
        IngresodeTiemposMaraton.txtHora.Text = Me.txtHora.Text
        IngresodeTiemposMaraton.txtEstado.Text = Me.txtEstado.Text
        IngresodeTiemposMaraton.cboJuez1.Text = Me.cboJuez1.Text
        IngresodeTiemposMaraton.cboJuez2.Text = Me.cboJuez2.Text
        IngresodeTiemposMaraton.cboJuez3.Text = Me.cboJuez3.Text
        IngresodeTiemposMaraton.cboUsuario.Text = Me.cboUsuario.Text
        IngresodeTiemposMaraton.cboSexo.Text = Me.cboSexo.Text
        IngresodeTiemposMaraton.cboCategoria.Text = Me.cboCategoria.Text
        IngresodeTiemposMaraton.cboPrueba.Text = Me.cboPrueba.Text
        IngresodeTiemposMaraton.Show()

    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Sub PrepararFormulario()
        Label1.Visible = False
        Label13.Visible = False
        txtCodigoMaraton.Visible = True
        cboUsuario.Visible = False
        btnIngresar.Enabled = False
        btnAgregarAtleta.Enabled = True
        btnQuitarAtleta.Enabled = True
        btnActualizar.Enabled = False
        btnComenzar.Enabled = False
        btnGuardar.Enabled = True
        btnImprimir.Enabled = False
        Me.dgvAtletasdeMaraton.Columns("Id_Atleta").Visible = True
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
        dtpfechainicio.Enabled = False

    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PlanillaMaraton.dgvAtletasdeMaraton.Rows.Add(atleta.dorsal,
                                                          atleta.Nombre_atleta, _
                                                          atleta.Apellido_atleta, _
                                                          clubNombre,
                                                          atleta.id_atleta)
    End Sub

    Private Sub btnGuardarCompetencia_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        ' valida que haya registros para poder guardarlos
        If Me.dgvAtletasdeMaraton.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If

        Dim objeto As New CEAtletas_x_Competencia
        Dim objeto1 As New CEResultados_x_Atleta
        Dim objeto2 As New CEResultados_x_Competencia

        Try
            For Each rows As DataGridViewRow In Me.dgvAtletasdeMaraton.Rows
                'LO QUE SE VA A GUARDAR EN LA TABLA RESULTADO POR COMPETENCIA
                objeto2.id_atleta = rows.Cells(4).Value
                objeto2.id_resultado_x_competencia = rows.Cells(5).Value
                objeto2.id_competencia = txtCodigoMaraton.Text
                objeto2.serie = txtSerie.Text
                objeto2.valor = txtValor.Text
                objeto2.descripcion = txtDescripcion.Text
                objeto2.mejor = txtMejor.Text
                objeto2.posicion = txtPosicion.Text
             
                capanegocio6.Nuevo_Resultado_x_Competencia(objeto2)

                ' genera un nuevo codigo de resultado por competencia
                rows.Cells(5).Value = Nuevo_Codigo_Resultado_x_Competencia()

                ' LO QUE SE VA A GUARDAR EN LA TABLA ATLETAS POR COMPETENCIA
                objeto.id_competencia = txtCodigoMaraton.Text
                objeto.id_atleta = rows.Cells(4).Value
                objeto.id_resultado_competencia = rows.Cells(5).Value
                objeto.Id_atleta_x_competencia = txtAtleta_x_Competencia.Text

                capanegocio4.Nuevo_Atleta_x_Competencia(objeto)

            Next
            ' MsgBox("Se guardado correctamente la lista de atletas")
            MessageBox.Show("Se guardado correctamente la lista de atletas", "Guardando Lista de Atletas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Nuevo_Codigo_Resultado_x_Atleta()
            Nuevo_Codigo_Resultado_x_Competencia()
            Nuevo_Codigo_Atleta_x_Competencia()
        Catch ex As Exception
            MsgBox("No se pudo guardar la lista de atletas", MsgBoxStyle.Critical)
        End Try
        btnGuardar.Enabled = False
        btnComenzar.Enabled = True
        btnImprimir.Enabled = True
        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False

    End Sub

    Sub Nuevo_Codigo_Resultado_x_Atleta()
        txtResultado_x_Atleta.Text = capanegocio5.Nuevo_Codigo_Resultado_x_Atleta
    End Sub

    Function Nuevo_Codigo_Resultado_x_Competencia()
        Return capanegocio6.Nuevo_Codigo_Resultado_x_Competencia()
    End Function

    Sub Nuevo_Codigo_Atleta_x_Competencia()
        txtAtleta_x_Competencia.Text = capanegocio4.Nuevo_Codigo_Atleta_x_Competencia
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Maraton.ShowDialog()
    End Sub
End Class