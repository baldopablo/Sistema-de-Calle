Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Globalization

Public Class IngresodeTiemposCrossCountry
    Dim capanegocio1 As New CNResultadoParcial
    Dim capanegocio2 As New CNAtletas_x_Competencia
    Dim capanegocio3 As New CNResultados_x_Atleta
    Dim capanegocio4 As New CNResultados_x_Competencia
    Dim capanegocio5 As New CNCompetencias
    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property ResultadoSeleccionado As New CeResultadoParcial
    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia
    Shared Property ResultadoFinalSeleccionado As New CEResultados_x_Competencia

    Public Property TipoDeFormulario As TipoFormulario

    Private Sub btnGuardarCompetencia_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        ' dgvTiemposCrossCountry.Rows.Clear()
        btnInformeFinal.Enabled = True
        If dgvTiemposCrossCountry.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To dgvTiemposCrossCountry.Rows.Count - 1
                    ResultadoFinalSeleccionado.id_resultado_x_competencia = dgvTiemposCrossCountry.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value
                    ResultadoFinalSeleccionado.id_competencia = txtCodigoPlanillaCrossCountry.Text
                    ResultadoFinalSeleccionado.id_atleta = dgvTiemposCrossCountry.Rows(i).Cells.Item("Id_Atleta").Value
                    ResultadoFinalSeleccionado.mejor = dgvTiemposCrossCountry.Rows(i).Cells.Item("Mejor").Value
                    ResultadoFinalSeleccionado.posicion = dgvTiemposCrossCountry.Rows(i).Cells.Item("Posicion").Value
                    ResultadoFinalSeleccionado.serie = dgvTiemposCrossCountry.Rows(i).Cells.Item("Serie").Value
                    ResultadoFinalSeleccionado.valor = PlanillaDeCalle.txtValor.Text
                    ResultadoFinalSeleccionado.descripcion = dgvTiemposCrossCountry.Rows(i).Cells.Item("Descripción").Value
                    ResultadoFinalSeleccionado.id_juez = PlanillaCrossCountry.cboJuez1.SelectedValue
                    ResultadoFinalSeleccionado.dorsal = dgvTiemposCrossCountry.Rows(i).Cells.Item("Dorsal").Value

                    AtletaxCompetenciaSeleccionada.id_atleta = dgvTiemposCrossCountry.Rows(i).Cells.Item("Id_Atleta").Value
                    AtletaxCompetenciaSeleccionada.id_competencia = txtCodigoPlanillaCrossCountry.Text
                    AtletaxCompetenciaSeleccionada.id_resultado_competencia = dgvTiemposCrossCountry.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value

                    capanegocio4.Actualizar_Resultado_x_Competencia(ResultadoFinalSeleccionado)
                    capanegocio2.Actualizar_Atleta_x_Competencia(AtletaxCompetenciaSeleccionada)
                Next
                MessageBox.Show("Los registros se han actualizado correctamente", "Actualizando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MsgBox("Error al actualizar los datos de la Planilla")
            End Try
        End If
    End Sub

    Private Sub IngresodeTiemposCrossCountry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        dtpTiempo.Value = Date.FromOADate(0)
        cargarlista()
        btnInformeFinal.Enabled = False
        Label3.Visible = False
        txtCodigoPlanillaCrossCountry.Visible = False
        Label13.Visible = False
        cboUsuario.Visible = False
        'Me.dgvTiemposCrossCountry.Columns("Id_Atleta").Visible = True
        'Me.dgvTiemposCrossCountry.Columns("Id_Resultado_Parcial").Visible = False
        btnActualizar.Enabled = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboPrueba.Enabled = False
        cboCategoria.Enabled = False
        cboSexo.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        dtpfechainicio.Enabled = False
    End Sub

    Private Sub btnAgregarTiempo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTiempo.Click

        If dtpTiempo.Value.ToString("HH:mm:ss") = "00:00:00" Then
            MsgBox("Debe ingresar un tiempo para poder continuar")
            dtpTiempo.Select()
            dtpTiempo.Focus()
            Exit Sub
        End If
        Dim filaActual = Me.dgvTiemposCrossCountry.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el tiempo de : " + Environment.NewLine + filaActual.Cells(3).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim valor As String = dtpTiempo.Value.ToString("HH:mm:ss")
            CargarSiguienteCelda(filaActual, valor)
            'limpiar el time picker
            dtpTiempo.Value = Date.FromOADate(0)
        End If
        Ordenar()
        btnActualizar.Enabled = True
    End Sub

    Dim COLUMNA_PRIMER_TIEMPO As Integer = 5
    Dim COLUMNA_SEGUNDO_TIEMPO As Integer = 6
    Dim COLUMNA_TERCER_TIEMPO As Integer = 7
    Dim COLUMNA_MEJOR_TIEMPO As Integer = 8

    'Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As String)
    '    For i As Integer = COLUMNA_PRIMER_TIEMPO To COLUMNA_TERCER_TIEMPO
    '        If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00:00:00" Then
    '            filaActual.Cells(i).Value = valorAponer
    '            If i = COLUMNA_TERCER_TIEMPO Then
    '                CalcularMejorTiempo(filaActual)
    '            End If
    '            Exit Sub
    '        End If
    '    Next
    'End Sub

    Private Function ConvertirADate(valor As String)
        Dim nuevoTiempo As DateTime = DateTime.ParseExact("01/01/2001 " + valor.Trim(), "dd/MM/yyyy HH:mm:ss", Nothing)
        Return nuevoTiempo
    End Function

    'Private Sub CalcularMejorTiempo(ByRef filaActual As DataGridViewRow)
    '    If String.IsNullOrEmpty(CStr(filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value).Trim()) OrElse CStr(filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value).Trim() = "00:00:00" Then
    '        Dim tiempocross As List(Of Date) = New List(Of Date) ' esto es LINQ
    '        tiempocross.Add(ConvertirADate(filaActual.Cells(COLUMNA_PRIMER_TIEMPO).Value))
    '        tiempocross.Add(ConvertirADate(filaActual.Cells(COLUMNA_SEGUNDO_TIEMPO).Value))
    '        tiempocross.Add(ConvertirADate(filaActual.Cells(COLUMNA_TERCER_TIEMPO).Value))
    '        filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value = tiempocross.OrderByDescending(Function(t) t.Hour). _
    '            ThenByDescending(Function(t) t.Minute). _
    '            ThenByDescending(Function(t) t.Second).First().ToString("hh:mm:ss")
    '    End If
    'End Sub

    ' RECORRE LAS CELDAS, VALIDA QUE LA POSICION Q ESTE VACIA E INGRESA EL VALOR
    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As String)
        ' recorre las columnas 4 a 6 que corresponden a los primeros tres tiempos 
        For i As Integer = COLUMNA_PRIMER_TIEMPO To COLUMNA_TERCER_TIEMPO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00:00:00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_TERCER_TIEMPO Then
                    'CALCULA EL TIEMPO MEDIO Y LO ASIGNA A LA COLUMNA MEJOR TIEMPO
                    Dim fila = dgvTiemposCrossCountry.CurrentRow
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

    Private Sub btnInformeFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnInformeFinal.Click
        txtEstado.Text = "Finalizada"
        PlanillaFinalCrossCountry.txtCodigoPlanillaFinalCrossCountry.Text = Me.txtCodigoPlanillaCrossCountry.Text
        PlanillaFinalCrossCountry.txtNombre.Text = Me.txtNombre.Text
        PlanillaFinalCrossCountry.txtLugar.Text = Me.txtLugar.Text
        PlanillaFinalCrossCountry.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaFinalCrossCountry.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaFinalCrossCountry.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaFinalCrossCountry.txtHora.Text = Me.txtHora.Text
        PlanillaFinalCrossCountry.txtEstado.Text = Me.txtEstado.Text
        PlanillaFinalCrossCountry.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaFinalCrossCountry.cboJuez2.Text = Me.cboJuez2.Text
        PlanillaFinalCrossCountry.cboJuez3.Text = Me.cboJuez3.Text
        PlanillaFinalCrossCountry.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaFinalCrossCountry.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaFinalCrossCountry.cboSexo.Text = Me.cboSexo.Text
        PlanillaFinalCrossCountry.cboCategoria.Text = Me.cboCategoria.Text
        PlanillaFinalCrossCountry.Show()
    End Sub

    Sub cargarlista()
        dgvTiemposCrossCountry.DataSource = capanegocio2.Ultimo_Registro_Atleta_x_Competencia_Cross_Country.Tables("Ultimo_Registro_Atleta_x_Competencia_Cross_Country")
        dgvTiemposCrossCountry.Columns(0).HeaderText = "Código"
        dgvTiemposCrossCountry.Columns(0).Visible = False
        dgvTiemposCrossCountry.Columns(1).HeaderText = "Dorsal"
        dgvTiemposCrossCountry.Columns(2).HeaderText = "Nombre"
        dgvTiemposCrossCountry.Columns(3).HeaderText = "Apellido"
        dgvTiemposCrossCountry.Columns(4).HeaderText = "Edad"
        dgvTiemposCrossCountry.Columns(5).HeaderText = "1° Tiempo"
        dgvTiemposCrossCountry.Columns(6).HeaderText = "2° Tiempo"
        dgvTiemposCrossCountry.Columns(7).HeaderText = "3° Tiempo"
        dgvTiemposCrossCountry.Columns(8).HeaderText = "Mejor Tiempo"
        dgvTiemposCrossCountry.Columns(9).HeaderText = "Posición"
        dgvTiemposCrossCountry.Columns(10).HeaderText = "Serie"
        dgvTiemposCrossCountry.Columns(10).Visible = False
        dgvTiemposCrossCountry.Columns(11).HeaderText = "Descripción"
        dgvTiemposCrossCountry.Columns(11).Visible = False
        dgvTiemposCrossCountry.Columns(12).HeaderText = "Código Resultado"
        dgvTiemposCrossCountry.Columns(12).Visible = False
    End Sub

    Private Sub Ordenar()
        'ORDENA EL DATAGRID Y PONE AS POSICIONES
        dgvTiemposCrossCountry.Sort(dgvTiemposCrossCountry.Columns(8), System.ComponentModel.ListSortDirection.Ascending)

        Dim cont As Integer
        cont = 0

        For Each rows As DataGridViewRow In Me.dgvTiemposCrossCountry.Rows
            cont = cont + 1
            rows.Cells(9).Value = cont
        Next
    End Sub

    Private Sub dgvTiemposCrossCountry_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvTiemposCrossCountry.CellFormatting
        e.CellStyle.SelectionBackColor = Color.Azure
        e.CellStyle.SelectionForeColor = Color.Black
        Try
            If Me.dgvTiemposCrossCountry.Columns(e.ColumnIndex).Name = "Tiempo Juez 1" Then

                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow

                    End If
                End If
            End If
            If Me.dgvTiemposCrossCountry.Columns(e.ColumnIndex).Name = "Tiempo Juez 2" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvTiemposCrossCountry.Columns(e.ColumnIndex).Name = "Tiempo Juez 3" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvTiemposCrossCountry.Columns(e.ColumnIndex).Name = "Mejor" Then
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