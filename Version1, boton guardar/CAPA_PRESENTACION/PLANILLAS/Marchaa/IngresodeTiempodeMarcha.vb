Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Globalization

Public Class IngresodeTiempodeMarcha

    Public Property Id_Competencia As Int32

    Dim capanegocio1 As New CNResultadoParcial
    Dim capanegocio4 As New CNResultados_x_Competencia

    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property ResultadoFinalSeleccionado As New CEResultados_x_Competencia
    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia

    Public Property TipoDeFormulario As TipoFormulario

    Dim capanegocio2 As New CNAtletas_x_Competencia

    Private Sub btnGuardarCompetencia_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        btnInformeFinal.Enabled = True

        If dgvTiemposMarcha.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To dgvTiemposMarcha.Rows.Count - 1
                    ResultadoFinalSeleccionado.id_resultado_x_competencia = dgvTiemposMarcha.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value
                    ResultadoFinalSeleccionado.id_competencia = txtCodigoMarcha.Text
                    ResultadoFinalSeleccionado.id_atleta = dgvTiemposMarcha.Rows(i).Cells.Item("Id_Atleta").Value
                    ResultadoFinalSeleccionado.mejor = dgvTiemposMarcha.Rows(i).Cells.Item("Mejor").Value
                    ResultadoFinalSeleccionado.posicion = dgvTiemposMarcha.Rows(i).Cells.Item("Posicion").Value
                    ResultadoFinalSeleccionado.serie = dgvTiemposMarcha.Rows(i).Cells.Item("Serie").Value
                    ResultadoFinalSeleccionado.valor = PlanillaDeCalle.txtValor.Text
                    ResultadoFinalSeleccionado.descripcion = dgvTiemposMarcha.Rows(i).Cells.Item("Descripción").Value
                    ResultadoFinalSeleccionado.id_juez = PlanilladeMarcha.cboJuez1.SelectedValue
                    ResultadoFinalSeleccionado.dorsal = dgvTiemposMarcha.Rows(i).Cells.Item("Dorsal").Value

                    AtletaxCompetenciaSeleccionada.id_atleta = dgvTiemposMarcha.Rows(i).Cells.Item("Id_Atleta").Value
                    AtletaxCompetenciaSeleccionada.id_competencia = txtCodigoMarcha.Text
                    AtletaxCompetenciaSeleccionada.id_resultado_competencia = dgvTiemposMarcha.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value

                    capanegocio4.Actualizar_Resultado_x_Competencia(ResultadoFinalSeleccionado)
                    capanegocio2.Actualizar_Atleta_x_Competencia(AtletaxCompetenciaSeleccionada)

                Next
                MessageBox.Show("Los registros se han actualizado correctamente", "Actualizando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MsgBox("Error al actualizar los datos de la Planilla")
            End Try
        End If
    End Sub

    Private Sub IngresodeTiempodeMarcha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub cargarlista()
        dgvTiemposMarcha.DataSource = capanegocio2.Ultimo_Registro_Atleta_x_Competencia_Marcha.Tables("Ultimo Registro Atleta por Competencia Marcha")
        dgvTiemposMarcha.Columns(0).HeaderText = "Código"
        dgvTiemposMarcha.Columns(0).Visible = False
        dgvTiemposMarcha.Columns(1).HeaderText = "Dorsal"
        dgvTiemposMarcha.Columns(2).HeaderText = "Nombre"
        dgvTiemposMarcha.Columns(3).HeaderText = "Apellido"
        dgvTiemposMarcha.Columns(4).HeaderText = "Edad"
        dgvTiemposMarcha.Columns(5).HeaderText = "1° Tiempo"
        dgvTiemposMarcha.Columns(6).HeaderText = "2° Tiempo"
        dgvTiemposMarcha.Columns(7).HeaderText = "3° Tiempo"
        dgvTiemposMarcha.Columns(8).HeaderText = "Mejor Tiempo"
        dgvTiemposMarcha.Columns(9).HeaderText = "Posición"
        dgvTiemposMarcha.Columns(10).HeaderText = "Serie"
        dgvTiemposMarcha.Columns(10).Visible = False
        dgvTiemposMarcha.Columns(11).HeaderText = "Descripción"
        dgvTiemposMarcha.Columns(11).Visible = False
        dgvTiemposMarcha.Columns(12).HeaderText = "Código Resultado"
        dgvTiemposMarcha.Columns(12).Visible = False
    End Sub

    ' RECORRE LAS CELDAS, VALIDA QUE LA POSICION Q ESTE VACIA E INGRESA EL VALOR
    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As String)
        ' recorre las columnas 4 a 6 que corresponden a los primeros tres tiempos 
        For i As Integer = COLUMNA_PRIMER_TIEMPO To COLUMNA_TERCER_TIEMPO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00:00:00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_TERCER_TIEMPO Then
                    'CALCULA EL TIEMPO MEDIO Y LO ASIGNA A LA COLUMNA MEJOR TIEMPO
                    Dim fila = dgvTiemposMarcha.CurrentRow
                    If fila IsNot Nothing Then
                        Dim Tiempos As New List(Of TimeSpan) From
                                               {
                                               TimeSpan.ParseExact(fila.Cells(COLUMNA_PRIMER_TIEMPO).Value.ToString, "c",
                                                                                  CultureInfo.InvariantCulture),
                                               TimeSpan.ParseExact(fila.Cells(COLUMNA_SEGUNDO_TIEMPO).Value.ToString, "c",
                                                                   CultureInfo.InvariantCulture),
                                               TimeSpan.ParseExact(fila.Cells(COLUMNA_TERCER_TIEMPO).Value.ToString, "c",
                                                                   CultureInfo.InvariantCulture)
                                               }
                        fila.Cells(COLUMNA_MEJOR_TIEMPO).Value = Tiempos.OrderBy(Function(t) t.TotalSeconds).ToList()(1)
                    End If
                End If
                Exit Sub
            End If
        Next
    End Sub

    Const COLUMNA_PRIMER_TIEMPO As Integer = 4
    Const COLUMNA_SEGUNDO_TIEMPO As Integer = 5
    Const COLUMNA_TERCER_TIEMPO As Integer = 6
    Const COLUMNA_MEJOR_TIEMPO As Integer = 7

    Private Sub btnAgregarTiempo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTiempo.Click
        'VALIDA HS VACIA (00:00:00)
        If dtpTiempo.Value.ToString("HH:mm:ss") = "00:00:00" Then
            MessageBox.Show("Debe ingresar un tiempo para poder continuar")
            dtpTiempo.Select()
            dtpTiempo.Focus()
            Exit Sub
        End If
        'CONFIRMA INGRESO DE TIEMPO DEL ATLETA CON APELLIDO.....
        Dim filaActual = Me.dgvTiemposMarcha.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el tiempo de: " + Environment.NewLine + filaActual.Cells(3).Value,
                           "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim valor As String = dtpTiempo.Value.ToString("HH:mm:ss")
            CargarSiguienteCelda(filaActual, valor)
            'limpiar el time picker
            dtpTiempo.Value = Date.FromOADate(0)
        End If
        btnActualizar.Enabled = True
        Ordenar()
    End Sub

    Private Function ConvertirADate(valor As String)
        Dim nuevoTiempo As DateTime = DateTime.ParseExact("01/01/2001 " + valor.Trim(), "dd/MM/yyyy HH:mm:ss", Nothing)
        Return nuevoTiempo
    End Function

    '' CALCULO DEL MEJOR TIEMPO
    'Private Sub CalcularMejorTiempo(ByRef filaActual As DataGridViewRow)
    '    If String.IsNullOrEmpty(CStr(filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value).Trim()) OrElse CStr(filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value).Trim() = "00:00:00" Then
    '        Dim Tiempos As List(Of Date) = New List(Of Date) ' esto es LINQ
    '        Tiempos.Add(ConvertirADate(filaActual.Cells(COLUMNA_PRIMER_TIEMPO).Value))
    '        Tiempos.Add(ConvertirADate(filaActual.Cells(COLUMNA_SEGUNDO_TIEMPO).Value))
    '        Tiempos.Add(ConvertirADate(filaActual.Cells(COLUMNA_TERCER_TIEMPO).Value))
    '        filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value = Tiempos.OrderByDescending(Function(t) t.Hour). _
    '            ThenByDescending(Function(t) t.Minute). _
    '            ThenByDescending(Function(t) t.Second).First().ToString("hh:mm:ss")
    '    End If
    'End Sub

    Sub PrepararFormulario()
        dtpTiempo.Value = Date.FromOADate(0)
        btnInformeFinal.Enabled = False
        btnActualizar.Enabled = False
        Label1.Visible = False
        txtCodigoMarcha.Visible = False
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
        cargarlista()
        ' Me.dgvTiemposMarcha.Columns("Id_Atleta").Visible = False
    End Sub

    Private Sub btnInformeFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnInformeFinal.Click
        txtEstado.Text = "Finalizada"
        PlanillaFinalMarcha.txtCodigoMarcha.Text = Me.txtCodigoMarcha.Text
        PlanillaFinalMarcha.txtNombre.Text = Me.txtNombre.Text
        PlanillaFinalMarcha.txtLugar.Text = Me.txtLugar.Text
        PlanillaFinalMarcha.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaFinalMarcha.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaFinalMarcha.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaFinalMarcha.txtHora.Text = Me.txtHora.Text
        PlanillaFinalMarcha.txtEstado.Text = Me.txtEstado.Text
        PlanillaFinalMarcha.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaFinalMarcha.cboJuez2.Text = Me.cboJuez2.Text
        PlanillaFinalMarcha.cboJuez3.Text = Me.cboJuez3.Text
        PlanillaFinalMarcha.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaFinalMarcha.cboSexo.Text = Me.cboSexo.Text
        PlanillaFinalMarcha.cboCategoria.Text = Me.cboCategoria.Text
        PlanillaFinalMarcha.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaFinalMarcha.Show()
    End Sub

    Private Sub Ordenar()
        'ORDENA EL DATAGRID Y PONE LAS POSICIONES
        dgvTiemposMarcha.Sort(dgvTiemposMarcha.Columns(7), System.ComponentModel.ListSortDirection.Ascending)

        Dim cont As Integer
        cont = 0

        For Each rows As DataGridViewRow In Me.dgvTiemposMarcha.Rows
            cont = cont + 1
            rows.Cells(8).Value = cont
        Next
    End Sub


    Private Sub dgvTiemposMarcha_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvTiemposMarcha.CellFormatting
        e.CellStyle.SelectionBackColor = Color.Azure
        e.CellStyle.SelectionForeColor = Color.Black
        Try
            If Me.dgvTiemposMarcha.Columns(e.ColumnIndex).Name = "Tiempo Juez 1" Then

                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow

                    End If
                End If
            End If
            If Me.dgvTiemposMarcha.Columns(e.ColumnIndex).Name = "Tiempo Juez 2" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvTiemposMarcha.Columns(e.ColumnIndex).Name = "Tiempo Juez 3" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvTiemposMarcha.Columns(e.ColumnIndex).Name = "Mejor" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.Red
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class