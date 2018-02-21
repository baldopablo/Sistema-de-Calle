Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PLANILLADELANZAMIENTOS

    Dim capanegocio As New CNCompetencias
    Dim capanegocio1 As New CNAtletas
    Dim capanegocio3 As New CNResultadoParcial
    Dim capanegocio4 As New CNAtletas_x_Competencia
    Dim capanegocio5 As New CNResultados_x_Atleta
    Dim capanegocio6 As New CNResultados_x_Competencia
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property ResultadoSeleccionado As New CeResultadoParcial
    Public Property TipoDeFormulario As TipoFormulario

    'CARGA LOS CAMPOS DEL DATAGRID QUE SIRVE PARA AGREGAR ATLETAS A LA COMPETENCIA
    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PLANILLADELANZAMIENTOS.dgvLanzamiento.Rows.Add(atleta.dorsal,
                                                          atleta.Nombre_atleta, _
                                                          atleta.Apellido_atleta,
                                                          clubNombre,
                                                          atleta.id_atleta)
    End Sub

    Private Sub PLANILLADELANZAMIENTOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    ' LOGICA DE BOTONES Y LLENADO DE COMBOBOX
    Private Sub PrepararFormulario()
        btnAgregarAtleta.Enabled = True
        btnQuitarAtleta.Enabled = True
        btnImprimir.Enabled = False
        btnComenzar.Enabled = False
        btnGuardar.Enabled = True

        Label1.Visible = False
        txtCodigoLanzamiento.Visible = False
        btnActualizar.Enabled = False
        btnIngresarLanzamiento.Enabled = False
        cboLocalidad.Enabled = False
        cboProvincia.Enabled = False
        cboPrueba.Enabled = False
        cboSexo.SelectedIndex = 0
        cboUsuario.Visible = False
        dtpfechainicio.Enabled = False
        Me.dgvLanzamiento.Columns("Id_Atleta").Visible = True

        cboCategoria.SelectedIndex = 0
        Label13.Visible = False
        txtCodigoLanzamiento.Visible = False
        juezprincipal1()
        NuevoCodigoResultado()
    End Sub
   
    Const COLUMNA_PRIMER_LANZAMIENTO As Integer = 5
    Const COLUMNA_SEGUNDO_LANZAMIENTO As Integer = 6
    Const COLUMNA_TERCER_LANZAMIENTO As Integer = 7
    Const COLUMNA_MEJOR_LANZAMIENTO As Integer = 8
    Const COLUMNA_ORDEN As Integer = 9

    ' VALIDA EL CONTENIDO DE LAS CELDAS VACIAS DE LA FILA SELECCIONADA Y AGREGA EL VALOR DEL TEXTBOX
    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As Object)

        ' recorre las columnas 4 a 6 que corresponden a los primeros tres lanzamientos
        For i As Integer = COLUMNA_PRIMER_LANZAMIENTO To COLUMNA_TERCER_LANZAMIENTO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(filaActual.Cells(i).Value) Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_TERCER_LANZAMIENTO Then
                    CalcularMejor123(filaActual)
                End If
                Exit Sub
            End If
        Next
    End Sub
    ' CALCULA EL MEJOR DE LOS TRES PRIMEROS LANZAMIENTOS 

    Private Sub CalcularMejor123(ByRef filaActual As DataGridViewRow)
        If String.IsNullOrEmpty(filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO).Value) Then
            Dim lanzamientos As List(Of Double) = New List(Of Double) ' esto es LINQ
            lanzamientos.Add(filaActual.Cells(COLUMNA_PRIMER_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_SEGUNDO_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_TERCER_LANZAMIENTO).Value)
            filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO).Value = lanzamientos.Max()
        End If
    End Sub

    ' BOTON NULO
    Private Sub btnNulo_Click(sender As System.Object, e As System.EventArgs)
        If Me.dgvLanzamiento.SelectedRows Is Nothing OrElse Me.dgvLanzamiento.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar una opción")
            Exit Sub
        End If
        Dim filaActual = Me.dgvLanzamiento.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el lanzamiento de:" + filaActual.Cells(3).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            CargarSiguienteCelda(filaActual, 0)
        End If
    End Sub

    ' BOTON REHUSO
    Private Sub btnRehuso_Click(sender As System.Object, e As System.EventArgs)
        If Me.dgvLanzamiento.SelectedRows Is Nothing OrElse Me.dgvLanzamiento.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar algo")
            Exit Sub
        End If
        Dim filaActual = Me.dgvLanzamiento.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el lanzamiento de:" + filaActual.Cells(3).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            CargarSiguienteCelda(filaActual, 0)
        End If
    End Sub

    Private Sub btnAgregarAtleta_Click_1(sender As System.Object, e As System.EventArgs) Handles btnAgregarAtleta.Click
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

   
    Private Sub btnQuitarAtleta_Click_1(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click
        'QUITA ATLETA DE LA COMPETENCIA
        If dgvLanzamiento.Rows.Count <> 0 Then
            dgvLanzamiento.Rows.RemoveAt(dgvLanzamiento.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        ' valida que haya registros para poder guardarlos
        If Me.dgvLanzamiento.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        Dim objeto As New CEAtletas_x_Competencia
        Dim objeto1 As New CEResultados_x_Competencia
        Dim objeto2 As New CEResultados_x_Competencia
        Try
            For Each rows As DataGridViewRow In Me.dgvLanzamiento.Rows

                objeto2.id_atleta = rows.Cells(4).Value
                objeto2.id_competencia = txtCodigoLanzamiento.Text
                objeto2.serie = txtSerie.Text
                objeto2.valor = txtValor.Text
                objeto2.descripcion = txtDescripcion.Text
                objeto2.mejor = txtMejor.Text
                objeto2.posicion = txtPosicion.Text

                capanegocio6.Nuevo_Resultado_x_Competencia(objeto2)
                rows.Cells(5).Value = Nuevo_Codigo_Resultado_x_Competencia()
                ' LO QUE SE VA A GUARDAR EN LA TABLA ATLETAS POR COMPETENCIA
                objeto.id_competencia = txtCodigoLanzamiento.Text
                objeto.id_atleta = rows.Cells(4).Value
                'objeto.id_resultado_atleta = txtResultado_x_Atleta.Text
                objeto.id_resultado_atleta = 1
                objeto.id_resultado_competencia = rows.Cells(5).Value


                capanegocio4.Nuevo_Atleta_x_Competencia(objeto)
            Next
            ' MsgBox("Se guardado correctamente la lista de atletas")
            MessageBox.Show("Se guardado correctamente la lista de atletas", "Guardando Lista de Atletas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Nuevo_Codigo_Resultado_x_Atleta()
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
        cboCategoria.Enabled = False
        cboSexo.Enabled = False
        cboJuez1.Enabled = False

    End Sub

    Sub Nuevo_Codigo_Atleta_x_Competencia()
        txtAtleta_x_Competencia.Text = capanegocio4.Nuevo_Codigo_Atleta_x_Competencia
    End Sub

    Function Nuevo_Codigo_Resultado_x_Competencia()
        Return capanegocio6.Nuevo_Codigo_Resultado_x_Competencia()
    End Function

    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click
        If Me.dgvLanzamiento.Rows.Count = 0 Then
            MessageBox.Show("Debe ingresar atletas para poder comenzar a registrar sus Lanzamientos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        If cboSexo.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione un Sexo")
            cboSexo.Focus()
            Return
        End If
        If cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Categoría")
            cboCategoria.Focus()
            Return
        End If
        If cboJuez1.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione un Juez")
            cboJuez1.Focus()
            Return
        End If
        btnIngresarLanzamiento.Enabled = True
        Me.dgvLanzamiento.Columns("Id_Atleta").Visible = False
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
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

    Sub NuevoCodigoResultado()
        TextBox2.Text = capanegocio3.NuevoCodigoResultado
    End Sub

    Private Sub RellenarCampos()
        PlanillaIngresodeLanzamientos.txtEstado.Text = "En Curso"
        PlanillaIngresodeLanzamientos.txtcodigocompetencia.Text = Me.txtCodigoLanzamiento.Text
        PlanillaIngresodeLanzamientos.txtResultado_x_Competencia.Text = Me.txtResultado_x_Competencia.Text
        PlanillaIngresodeLanzamientos.txtCodigoLanzamiento.Text = Me.txtCodigoLanzamiento.Text
        PlanillaIngresodeLanzamientos.txtNombre.Text = Me.txtNombre.Text
        PlanillaIngresodeLanzamientos.txtLugar.Text = Me.txtLugar.Text
        PlanillaIngresodeLanzamientos.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaIngresodeLanzamientos.txtHora.Text = Me.txtHora.Text
        PlanillaIngresodeLanzamientos.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaIngresodeLanzamientos.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaIngresodeLanzamientos.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaIngresodeLanzamientos.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaIngresodeLanzamientos.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaIngresodeLanzamientos.txtAtleta_x_Competencia.Text = Me.txtAtleta_x_Competencia.Text
        PlanillaIngresodeLanzamientos.cboSexo.Text = Me.cboSexo.Text
        PlanillaIngresodeLanzamientos.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaIngresodeLanzamientos.cboCategoria.Text = Me.cboCategoria.Text
        PlanillaIngresodeLanzamientos.ShowDialog()
    End Sub

    Private Sub btnIngresarLanzamiento_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresarLanzamiento.Click
        RellenarCampos()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Lanzamiento.ShowDialog()

    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        '   EN ESTA PLANILLA NO CUMPLE NINGUNA FUNCION
    End Sub
End Class
