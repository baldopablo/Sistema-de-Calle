Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions

Public Class PLANILLASALTOENLARGOYTRIPLE
    Dim capanegocio As New CNCompetencias
    Dim capanegocio1 As New CNAtletas
    Dim capanegocio3 As New CNResultadoParcial
    Dim capanegocio4 As New CNAtletas_x_Competencia
    Dim capanegocio6 As New CNResultados_x_Competencia
    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario
    'Shared Property PlanillaSaltoSeleccionada As New CE

    Private Sub PLANILLASALTOENLARGOYTRIPLE_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Private Sub PrepararFormulario()
        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        btnImprimir.Enabled = False
        btnActualizar.Enabled = False
        btnGuardar.Enabled = False
        txtCodigoSalto.Enabled = False
        txtCodigoSalto.Visible = False
        btnIngresarSalto.Enabled = False
        cboCategoria.SelectedIndex = 0
        cboSexo.SelectedIndex = 0
        juezprincipal1()


        For Each row As DataGridViewRow In dgvSaltoTripleyLargo.Rows
            If row.Cells("Dorsal").Value <> 0 Then
                row.DefaultCellStyle.BackColor = Color.Red
            End If
        Next

        Select Case TipoDeFormulario
            Case TipoFormulario.Alta
                btnAgregarAtleta.Enabled = True
                btnQuitarAtleta.Enabled = True
                btnComenzar.Enabled = False
                btnGuardar.Enabled = True
        End Select
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


    Private Sub btnNulo_Click(sender As System.Object, e As System.EventArgs)

        If Me.dgvSaltoTripleyLargo.SelectedRows Is Nothing OrElse Me.dgvSaltoTripleyLargo.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar algo")
            Exit Sub
        End If
        Dim filaActual = Me.dgvSaltoTripleyLargo.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el salto conseguido..??: \n" + filaActual.Cells(2).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            Dim valor As String
            valor = "X "
            CargarSiguienteCelda(filaActual, valor)
        End If
    End Sub

    Private Sub btnRehuso_Click(sender As System.Object, e As System.EventArgs)
        If Me.dgvSaltoTripleyLargo.SelectedRows Is Nothing OrElse Me.dgvSaltoTripleyLargo.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar algo")
            Exit Sub
        End If
        Dim filaActual = Me.dgvSaltoTripleyLargo.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el salto conseguido..??: \n" + filaActual.Cells(2).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            Dim valor As String
            valor = "= "
            CargarSiguienteCelda(filaActual, valor)
        End If
    End Sub

    Dim COLUMNA_PRIMER_SALTO As Integer = 5
    Dim COLUMNA_SEGUNDA_SALTO As Integer = 6
    Dim COLUMNA_TERCERA_SALTO As Integer = 7
    Dim COLUMNA_MEJOR_SALTO As Integer = 8

    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As String)
        ' recorre las columnas 3 a 12 que corresponden a la cantidad de alturas
        For i As Integer = COLUMNA_PRIMER_SALTO To COLUMNA_TERCERA_SALTO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(filaActual.Cells(i).Value) Then 'busca la primer posición vacía
                filaActual.Cells(i).Value = valorAponer
                CalcularMejor123(filaActual)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub CalcularMejor123(ByRef filaActual As DataGridViewRow)

        If String.IsNullOrEmpty(filaActual.Cells(COLUMNA_MEJOR_SALTO).Value) Then

            Dim salto As List(Of Integer) = New List(Of Integer) ' esto es LINQ
            salto.Add(filaActual.Cells(COLUMNA_PRIMER_SALTO).Value)
            'salto.Add(filaActual.Cells(COLUMNA_SEGUNDO_LANZAMIENTO).Value)
            'salto.Add(filaActual.Cells(COLUMNA_TERCER_LANZAMIENTO).Value)

            filaActual.Cells(COLUMNA_MEJOR_SALTO).Value = salto.Max()

        End If
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PLANILLASALTOENLARGOYTRIPLE.dgvSaltoTripleyLargo.Rows.Add(atleta.dorsal,
                                                          atleta.Nombre_atleta, _
                                                          atleta.Apellido_atleta,
                                                          clubNombre,
                                                          atleta.id_atleta)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        ' valida que haya registros para poder guardarlos
        If Me.dgvSaltoTripleyLargo.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        Dim objeto As New CEAtletas_x_Competencia
        Dim objeto1 As New CEResultados_x_Competencia
        Dim objeto2 As New CEResultados_x_Competencia
        Try
            For Each rows As DataGridViewRow In Me.dgvSaltoTripleyLargo.Rows

                objeto2.id_atleta = rows.Cells(4).Value
                objeto2.id_competencia = txtCodigoSalto.Text
                objeto2.serie = txtSerie.Text
                objeto2.valor = txtValor.Text
                objeto2.descripcion = txtDescripcion.Text
                objeto2.mejor = txtMejor.Text
                objeto2.posicion = txtPosicion.Text

                capanegocio6.Nuevo_Resultado_x_Competencia(objeto2)
                rows.Cells(5).Value = Nuevo_Codigo_Resultado_x_Competencia()
                ' LO QUE SE VA A GUARDAR EN LA TABLA ATLETAS POR COMPETENCIA
                objeto.id_competencia = txtCodigoSalto.Text
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
        cboJuez1.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
    End Sub

    Sub Nuevo_Codigo_Atleta_x_Competencia()
        txtAtleta_x_Competencia.Text = capanegocio4.Nuevo_Codigo_Atleta_x_Competencia
    End Sub

    Function Nuevo_Codigo_Resultado_x_Competencia()
        Return capanegocio6.Nuevo_Codigo_Resultado_x_Competencia()
    End Function

    Private Sub btnQuitarAtleta_Click_1(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click
        If dgvSaltoTripleyLargo.Rows.Count <> 0 Then
            dgvSaltoTripleyLargo.Rows.RemoveAt(dgvSaltoTripleyLargo.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Salto.ShowDialog()
    End Sub

    Private Sub btnComenzar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click
        If Me.dgvSaltoTripleyLargo.Rows.Count = 0 Then
            MessageBox.Show("Debe ingresar atletas para poder comenzar a registrar sus Saltos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        btnIngresarSalto.Enabled = True
        btnImprimir.Enabled = True
        Me.dgvSaltoTripleyLargo.Columns("Id_Atleta").Visible = False
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub btnIngresarLanzamiento_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresarSalto.Click
        RellenarCampos()

    End Sub
    Private Sub RellenarCampos()
        PlanillaIngresodeSaltos.txtEstado.Text = "En Curso"
        PlanillaIngresodeSaltos.txtcodigocompetencia.Text = Me.txtCodigoSalto.Text
        PlanillaIngresodeSaltos.txtResultado_x_Competencia.Text = Me.txtResultado_x_Competencia.Text
        PlanillaIngresodeSaltos.txtcodigocompetencia.Text = Me.txtCodigoSalto.Text
        PlanillaIngresodeSaltos.txtNombre.Text = Me.txtNombre.Text
        PlanillaIngresodeSaltos.txtLugar.Text = Me.txtLugar.Text
        PlanillaIngresodeSaltos.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaIngresodeSaltos.txtHora.Text = Me.txtHora.Text
        PlanillaIngresodeSaltos.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaIngresodeSaltos.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaIngresodeSaltos.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaIngresodeSaltos.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaIngresodeSaltos.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaIngresodeSaltos.txtAtleta_x_Competencia.Text = Me.txtAtleta_x_Competencia.Text
        PlanillaIngresodeSaltos.cboSexo.Text = Me.cboSexo.Text
        PlanillaIngresodeSaltos.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaIngresodeSaltos.cboCategoria.Text = Me.cboCategoria.Text

        PlanillaIngresodeSaltos.ShowDialog()
    End Sub


    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        '   EN ESTA PLANILLA NO CUMPLE NINGUNA FUNCION
    End Sub

End Class