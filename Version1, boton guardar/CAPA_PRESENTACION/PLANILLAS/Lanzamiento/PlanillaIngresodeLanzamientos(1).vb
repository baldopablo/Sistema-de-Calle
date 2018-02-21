Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanillaIngresodeLanzamientos

    Dim capanegocio As New CNCompetencias
    Dim capanegocio3 As New CNResultadoParcial
    Dim capanegocio4 As New CNAtletas_x_Competencia
    Dim capanegocio6 As New CNResultados_x_Competencia

    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property ResultadoFinalSeleccionado As New CEResultados_x_Competencia
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property ResultadoSeleccionado As New CeResultadoParcial
    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub PlanillaRondaClasificatoriaLanzamiento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Private Sub PrepararFormulario()
        cargarlista()
        btnCerrar.Enabled = True
        btnInformeFinal.Enabled = False

    End Sub

    Const COLUMNA_PRIMER_LANZAMIENTO As Integer = 5
    Const COLUMNA_SEGUNDO_LANZAMIENTO As Integer = 6
    Const COLUMNA_TERCER_LANZAMIENTO As Integer = 7
    Const COLUMNA_MEJOR_LANZAMIENTO As Integer = 8
    Const COLUMNA_CUARTO_LANZAMIENTO As Integer = 9
    Const COLUMNA_QUINTO_LANZAMIENTO As Integer = 10
    Const COLUMNA_SEXTO_LANZAMIENTO As Integer = 11
    Const COLUMNA_MEJOR_LANZAMIENTO_TOTAL As Integer = 12
    Const COLUMNA_MEJOR_POSICION_FINAL As Integer = 13

    Private Sub btnVálido_Click(sender As System.Object, e As System.EventArgs) Handles btnVálido.Click
        'valida que el textbox no este vacio
        If Me.dgvIngresodeLanzamiento.SelectedRows Is Nothing OrElse Me.dgvIngresodeLanzamiento.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar una opción")
            Exit Sub
        End If
        'valida que no se ingresen otros caracteres ue no sean numericos
        If Not IsNumeric(txtDistancia.Text) Then
            MessageBox.Show("Debe ingresar una distancia válida")
            Exit Sub
        End If
        Dim filaActual = Me.dgvIngresodeLanzamiento.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el lanzamiento de:" + filaActual.Cells(3).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim distancia As Decimal = 0
            If Not Decimal.TryParse(txtDistancia.Text, distancia) Then
                MessageBox.Show("Ingrese una distancia correcta")
                Exit Sub
            End If
            Dim result = String.Format("{0:N2} mts", distancia)
            CargarSiguienteCelda(filaActual, txtDistancia.Text)
            txtDistancia.Clear()
        End If
    End Sub

    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As Object)
        ' recorre las columnas 4 a 6 que corresponden a los primeros tres lanzamientos
        For i As Integer = COLUMNA_PRIMER_LANZAMIENTO To COLUMNA_TERCER_LANZAMIENTO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00,00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_TERCER_LANZAMIENTO Then
                    CalcularMejor123(filaActual)
                End If
                Exit Sub
            End If
        Next
        ' recorre las columnas 10 a 12 que corresponden a los primeros tres lanzamientos
        For i As Integer = COLUMNA_CUARTO_LANZAMIENTO To COLUMNA_SEXTO_LANZAMIENTO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00,00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_SEXTO_LANZAMIENTO Then
                    'AQUI SE DEBE CALCULAR EL MEJOR DE TODOS LOS LANZAMIENTOS
                    CalcularMejorTOTAL(filaActual)
                End If
                Exit Sub
            End If
        Next
    End Sub

    Private Sub CalcularMejor123(ByRef filaActual As DataGridViewRow)
        If String.IsNullOrEmpty(CStr(filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO).Value).Trim()) OrElse CStr(filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO).Value).Trim() = "00,00" Then
            Dim lanzamientos As List(Of Double) = New List(Of Double) ' esto es LINQ
            lanzamientos.Add(filaActual.Cells(COLUMNA_PRIMER_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_SEGUNDO_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_TERCER_LANZAMIENTO).Value)
            filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO).Value = lanzamientos.Max()
        End If
    End Sub

    Private Sub Ordenar()
        'ORDENA EL DATAGRID Y PONE LAS POSICIONES
        dgvIngresodeLanzamiento.Sort(dgvIngresodeLanzamiento.Columns(8), System.ComponentModel.ListSortDirection.Descending)
        Dim cont As Integer
        cont = 0
        For Each rows As DataGridViewRow In Me.dgvIngresodeLanzamiento.Rows
            cont = cont + 1
            rows.Cells(9).Value = cont
        Next
    End Sub

    Private Sub btnNulo_Click(sender As System.Object, e As System.EventArgs) Handles btnNulo.Click
        If Me.dgvIngresodeLanzamiento.SelectedRows Is Nothing OrElse Me.dgvIngresodeLanzamiento.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar una opción")
            Exit Sub
        End If
        Dim filaActual = Me.dgvIngresodeLanzamiento.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el lanzamiento de:" + filaActual.Cells(3).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            CargarSiguienteCelda(filaActual, 0)
        End If
    End Sub

    Private Sub btnRehuso_Click(sender As System.Object, e As System.EventArgs) Handles btnRehuso.Click
        If Me.dgvIngresodeLanzamiento.SelectedRows Is Nothing OrElse Me.dgvIngresodeLanzamiento.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar algo")
            Exit Sub
        End If
        Dim filaActual = Me.dgvIngresodeLanzamiento.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el lanzamiento de:" + filaActual.Cells(3).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            CargarSiguienteCelda(filaActual, 0)
        End If
    End Sub

    Sub cargarlista()
        dgvIngresodeLanzamiento.DataSource = capanegocio4.Ultimo_Registro_Atleta_x_Competencia_Lanzamiento.Tables("Ultimo Registro Atleta por Competencia Lanzamiento")
        dgvIngresodeLanzamiento.Columns(0).HeaderText = "Código"
        dgvIngresodeLanzamiento.Columns(0).Visible = False
        dgvIngresodeLanzamiento.Columns(1).HeaderText = "Dorsal"
        dgvIngresodeLanzamiento.Columns(2).HeaderText = "Nombre"
        dgvIngresodeLanzamiento.Columns(3).HeaderText = "Apellido"
        dgvIngresodeLanzamiento.Columns(4).HeaderText = "Club/Federación"
        dgvIngresodeLanzamiento.Columns(5).HeaderText = "1° Lanz."
        dgvIngresodeLanzamiento.Columns(6).HeaderText = "2° Lanz."
        dgvIngresodeLanzamiento.Columns(7).HeaderText = "3° Lanz."
        dgvIngresodeLanzamiento.Columns(8).HeaderText = "Mejor Primera Fase"
        dgvIngresodeLanzamiento.Columns(9).HeaderText = "4° Lanz."
        dgvIngresodeLanzamiento.Columns(10).HeaderText = "5° Lanz."
        dgvIngresodeLanzamiento.Columns(11).HeaderText = "6° Lanz."
        dgvIngresodeLanzamiento.Columns(12).HeaderText = "Mejor Final"
        dgvIngresodeLanzamiento.Columns(13).HeaderText = "Posición"
        dgvIngresodeLanzamiento.Columns(14).HeaderText = "Serie"
        dgvIngresodeLanzamiento.Columns(15).Visible = False
        dgvIngresodeLanzamiento.Columns(16).HeaderText = "Descripción"
        dgvIngresodeLanzamiento.Columns(17).Visible = False
        dgvIngresodeLanzamiento.Columns(18).HeaderText = "Código Resultado"
        dgvIngresodeLanzamiento.Columns(19).Visible = False
    End Sub

    Private Sub OrdenarTotal()
        'ORDENA EL DATAGRID Y PONE LAS POSICIONES
        dgvIngresodeLanzamiento.Sort(dgvIngresodeLanzamiento.Columns(12), System.ComponentModel.ListSortDirection.Descending)
        Dim cont As Integer
        cont = 0
        For Each rows As DataGridViewRow In Me.dgvIngresodeLanzamiento.Rows
            cont = cont + 1
            rows.Cells(13).Value = cont
        Next
    End Sub

    Private Sub txtDistancia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDistancia.TextChanged
        'If txtDistancia.Text = " " Then
        '    btnNulo.Enabled = False
        '    btnRehuso.Enabled = False
        'Else
        '    btnNulo.Enabled = True
        '    btnRehuso.Enabled = True
        'End If
    End Sub

    ' VALIDACION DE CELDAS VACIAS PARA LA SEGUNDA RONDA DE LANZAMIENTOS EN LOS CUALES SIGUEN PARTICIPANDO LOS 8 PRIMEROS ATLETAS SEGUN SU LANZAMIENTO
    Private Sub CargarSiguienteCelda456(ByRef filaActual As DataGridViewRow, valorAponer As Object)
        ' recorre las columnas 4 a 6 que corresponden a los primeros tres lanzamientos
        For i As Integer = COLUMNA_CUARTO_LANZAMIENTO To COLUMNA_SEXTO_LANZAMIENTO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00,00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_SEXTO_LANZAMIENTO Then
                    CalcularMejor456(filaActual)
                    '  MessageBox.Show("El Mejor Lanzamiento logrado de: " & Environment.NewLine & CStr(filaActual.Cells(3).Value) & filaActual.Cells(8).Value)
                End If
                Exit Sub
            End If
        Next
    End Sub

    Private Sub CalcularMejor456(ByRef filaActual As DataGridViewRow)
        If String.IsNullOrEmpty(CStr(filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO_TOTAL).Value).Trim()) OrElse CStr(filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO_TOTAL).Value).Trim() = "00,00" Then
            Dim lanzamientos As List(Of Double) = New List(Of Double) ' esto es LINQ
            lanzamientos.Add(filaActual.Cells(COLUMNA_CUARTO_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_QUINTO_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_SEXTO_LANZAMIENTO).Value)
            filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO_TOTAL).Value = lanzamientos.Max()
        End If
    End Sub

    Private Sub CalcularMejorTOTAL(ByRef filaActual As DataGridViewRow)
        If String.IsNullOrEmpty(CStr(filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO_TOTAL).Value).Trim()) OrElse CStr(filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO_TOTAL).Value).Trim() = "00,00" Then
            Dim lanzamientos As List(Of Double) = New List(Of Double) ' esto es LINQ
            lanzamientos.Add(filaActual.Cells(COLUMNA_PRIMER_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_SEGUNDO_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_TERCER_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_CUARTO_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_QUINTO_LANZAMIENTO).Value)
            lanzamientos.Add(filaActual.Cells(COLUMNA_SEXTO_LANZAMIENTO).Value)
            filaActual.Cells(COLUMNA_MEJOR_LANZAMIENTO_TOTAL).Value = lanzamientos.Max()
            OrdenarTotal()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If dgvIngresodeLanzamiento.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To dgvIngresodeLanzamiento.Rows.Count - 1
                    ResultadoFinalSeleccionado.id_resultado_x_competencia = dgvIngresodeLanzamiento.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value
                    ResultadoFinalSeleccionado.id_competencia = txtcodigocompetencia.Text
                    ResultadoFinalSeleccionado.id_atleta = dgvIngresodeLanzamiento.Rows(i).Cells.Item("Id_Atleta").Value
                    ResultadoFinalSeleccionado.mejor = dgvIngresodeLanzamiento.Rows(i).Cells.Item("Mejor Lanzamiento").Value
                    ResultadoFinalSeleccionado.posicion = dgvIngresodeLanzamiento.Rows(i).Cells.Item("Posicion").Value
                    ResultadoFinalSeleccionado.valor = PlanillaDeCalle.txtValor.Text
                    ResultadoFinalSeleccionado.serie = txtSerie.Text
                    ResultadoFinalSeleccionado.descripcion = txtDescripcion.Text
                    ResultadoFinalSeleccionado.id_juez = PLANILLADELANZAMIENTOS.cboJuez1.SelectedValue
                    ResultadoFinalSeleccionado.dorsal = dgvIngresodeLanzamiento.Rows(i).Cells.Item("Dorsal").Value

                    AtletaxCompetenciaSeleccionada.id_competencia = txtcodigocompetencia.Text
                    AtletaxCompetenciaSeleccionada.id_resultado_competencia = dgvIngresodeLanzamiento.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value
                    AtletaxCompetenciaSeleccionada.id_atleta = dgvIngresodeLanzamiento.Rows(i).Cells.Item("Id_Atleta").Value

                    capanegocio6.Actualizar_Resultado_x_Competencia(ResultadoFinalSeleccionado)
                    capanegocio4.Actualizar_Atleta_x_Competencia(AtletaxCompetenciaSeleccionada)
                Next
                MessageBox.Show("Los registros se han actualizado correctamente", "Actualizando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox("Error al actualizar los datos de la Planilla")
            End Try
        End If
        btnInformeFinal.Enabled = True
    End Sub

    Private Sub btnInformeFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnInformeFinal.Click
        RellenarCampos()

    End Sub
    Sub RellenarCampos()
        PlanillaFinalLanzamiento.txtEstado.Text = "Finalizada"
        PlanillaFinalLanzamiento.txtCodigoLanzamiento.Text = Me.txtCodigoLanzamiento.Text
        PlanillaFinalLanzamiento.txtResultado_x_Competencia.Text = Me.txtResultado_x_Competencia.Text
        'PlanillaFinalLanzamiento.txtCodigoLanzamiento.Text = Me.txtCodigoLanzamiento.Text
        PlanillaFinalLanzamiento.txtNombre.Text = Me.txtNombre.Text
        PlanillaFinalLanzamiento.txtLugar.Text = Me.txtLugar.Text
        PlanillaFinalLanzamiento.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaFinalLanzamiento.txtHora.Text = Me.txtHora.Text
        PlanillaFinalLanzamiento.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaFinalLanzamiento.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaFinalLanzamiento.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaFinalLanzamiento.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaFinalLanzamiento.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaFinalLanzamiento.txtAtleta_x_Competencia.Text = Me.txtAtleta_x_Competencia.Text
        PlanillaFinalLanzamiento.cboSexo.Text = Me.cboSexo.Text
        PlanillaFinalLanzamiento.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaFinalLanzamiento.cboCategoria.Text = Me.cboCategoria.Text
        Me.Close()
        PlanillaFinalLanzamiento.ShowDialog()
    End Sub


    Private Sub dgvIngresodeLanzamiento_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvIngresodeLanzamiento.CellFormatting
        e.CellStyle.SelectionBackColor = Color.Azure
        e.CellStyle.SelectionForeColor = Color.Black
        Try
            If Me.dgvIngresodeLanzamiento.Columns(e.ColumnIndex).Name = "Tiempo Juez 1" Then

                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow

                    End If
                End If
            End If
            If Me.dgvIngresodeLanzamiento.Columns(e.ColumnIndex).Name = "Tiempo Juez 2" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvIngresodeLanzamiento.Columns(e.ColumnIndex).Name = "Tiempo Juez 3" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvIngresodeLanzamiento.Columns(e.ColumnIndex).Name = "Mejor" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00") Then
                        e.CellStyle.BackColor = Color.Red
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class