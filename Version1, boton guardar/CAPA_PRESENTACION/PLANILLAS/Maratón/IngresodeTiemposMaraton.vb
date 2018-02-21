Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization

Public Class IngresodeTiemposMaraton

    Public Property Id_Competencia As Int32
    Dim capanegocio1 As New CNResultadoParcial
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property ResultadoFinalSeleccionado As New CEResultados_x_Competencia
    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia

    Dim capanegocio2 As New CNAtletas_x_Competencia
    Dim capanegocio3 As New CNResultados_x_Atleta
    Dim capanegocio4 As New CNResultados_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If dgvTiemposMaraton.Rows.Count > 0 Then
            Try

                For i As Integer = 0 To dgvTiemposMaraton.Rows.Count - 1

                    ResultadoFinalSeleccionado.id_resultado_x_competencia = dgvTiemposMaraton.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value
                    ResultadoFinalSeleccionado.id_competencia = txtCodigoPlanillaMaraton.Text
                    ResultadoFinalSeleccionado.id_atleta = dgvTiemposMaraton.Rows(i).Cells.Item("Id_Atleta").Value
                    ResultadoFinalSeleccionado.mejor = dgvTiemposMaraton.Rows(i).Cells.Item("Mejor").Value
                    ResultadoFinalSeleccionado.posicion = dgvTiemposMaraton.Rows(i).Cells.Item("Posicion").Value
                    ResultadoFinalSeleccionado.serie = dgvTiemposMaraton.Rows(i).Cells.Item("Serie").Value
                    ResultadoFinalSeleccionado.valor = PlanillaDeCalle.txtValor.Text
                    ResultadoFinalSeleccionado.descripcion = dgvTiemposMaraton.Rows(i).Cells.Item("Descripcion").Value
                    ResultadoFinalSeleccionado.id_juez = PlanillaMaraton.cboJuez1.SelectedValue
                    ResultadoFinalSeleccionado.dorsal = dgvTiemposMaraton.Rows(i).Cells.Item("Dorsal").Value

                    AtletaxCompetenciaSeleccionada.id_atleta = dgvTiemposMaraton.Rows(i).Cells.Item("Id_Atleta").Value
                    AtletaxCompetenciaSeleccionada.id_competencia = txtCodigoPlanillaMaraton.Text
                    AtletaxCompetenciaSeleccionada.id_resultado_competencia = dgvTiemposMaraton.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value

                    capanegocio4.Actualizar_Resultado_x_Competencia(ResultadoFinalSeleccionado)
                    capanegocio2.Actualizar_Atleta_x_Competencia(AtletaxCompetenciaSeleccionada)
                Next

                MessageBox.Show("Los regirstros se han actualizado correctamente", "Actualizando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MsgBox("Error al actualizar los datos de la Planilla")
            End Try

        End If
        btnInformeFinal.Enabled = True
    End Sub

    Private Sub IngresodeTiemposMaraton_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

    End Sub

    Sub cargarlista()
        dgvTiemposMaraton.DataSource = capanegocio2.Ultimo_Registro_Atleta_x_Competencia_Maraton.Tables("Ultimo Registro Atleta por Competencia Maraton")
        dgvTiemposMaraton.Columns(0).HeaderText = "Código"
        dgvTiemposMaraton.Columns(0).Visible = False
        dgvTiemposMaraton.Columns(1).HeaderText = "Dorsal"
        dgvTiemposMaraton.Columns(2).HeaderText = "Nombre"
        dgvTiemposMaraton.Columns(3).HeaderText = "Apellido"
        dgvTiemposMaraton.Columns(4).HeaderText = "Edad"
        dgvTiemposMaraton.Columns(5).HeaderText = "1° Tiempo"
        dgvTiemposMaraton.Columns(6).HeaderText = "2° Tiempo"
        dgvTiemposMaraton.Columns(7).HeaderText = "3° Tiempo"
        dgvTiemposMaraton.Columns(8).HeaderText = "Mejor Tiempo"
        dgvTiemposMaraton.Columns(9).HeaderText = "Posición"
        dgvTiemposMaraton.Columns(10).HeaderText = "Serie"
        dgvTiemposMaraton.Columns(10).Visible = False
        dgvTiemposMaraton.Columns(11).HeaderText = "Descripción"
        dgvTiemposMaraton.Columns(11).Visible = False
        dgvTiemposMaraton.Columns(12).HeaderText = "Código Resultado"
        dgvTiemposMaraton.Columns(12).Visible = False
    End Sub

    Private Sub btnAgregarTiempo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTiempo.Click
        'VALIDA HS VACIA (00:00:00)
        If dtpTiempo.Value.ToString("HH:mm:ss") = "00:00:00" Then
            MessageBox.Show("Debe ingresar un tiempo para poder continuar")
            dtpTiempo.Select()
            dtpTiempo.Focus()
            Exit Sub
        End If
        'CONFIRMA INGRESO DE TIEMPO DEL ATLETA CON APELLIDO.....
        Dim filaActual = Me.dgvTiemposMaraton.SelectedRows(0)
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

    ' RECORRE LAS CELDAS, VALIDA QUE LA POSICION Q ESTE VACIA E INGRESA EL VALOR
    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As String)
        ' recorre las columnas 4 a 6 que corresponden a los primeros tres tiempos 
        For i As Integer = COLUMNA_PRIMER_TIEMPO To COLUMNA_TERCER_TIEMPO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00:00:00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_TERCER_TIEMPO Then
                    'CALCULA EL TIEMPO MEDIO Y LO ASIGNA A LA COLUMNA MEJOR TIEMPO
                    Dim fila = dgvTiemposMaraton.CurrentRow
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

    Private Function ConvertirADate(valor As String)
        Dim nuevoTiempo As DateTime = DateTime.ParseExact("01/01/2001 " + valor.Trim(), "dd/MM/yyyy HH:mm:ss", Nothing)
        Return nuevoTiempo
    End Function

    Const COLUMNA_PRIMER_TIEMPO As Integer = 5
    Const COLUMNA_SEGUNDO_TIEMPO As Integer = 6
    Const COLUMNA_TERCER_TIEMPO As Integer = 7
    Const COLUMNA_MEJOR_TIEMPO As Integer = 8

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
        Label3.Visible = False
        Label13.Visible = False
        txtCodigoPlanillaMaraton.Visible = False
        cboUsuario.Visible = False
        btnActualizar.Enabled = False
        btnInformeFinal.Enabled = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboPrueba.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        dtpfechainicio.Enabled = False
        'Me.dgvTiemposMaraton.Columns("Id_Atleta").Visible = False
        cargarlista()
    End Sub

    Private Sub btnInformeFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnInformeFinal.Click
        txtEstado.Text = "Finalizada"
        PlanillaFinalMaraton.txtCodigoPlanillaMaraton.Text = Me.txtCodigoPlanillaMaraton.Text
        PlanillaFinalMaraton.txtNombre.Text = Me.txtNombre.Text
        PlanillaFinalMaraton.txtLugar.Text = Me.txtLugar.Text
        PlanillaFinalMaraton.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaFinalMaraton.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaFinalMaraton.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaFinalMaraton.txtHora.Text = Me.txtHora.Text
        PlanillaFinalMaraton.txtEstado.Text = Me.txtEstado.Text
        PlanillaFinalMaraton.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaFinalMaraton.cboJuez2.Text = Me.cboJuez2.Text
        PlanillaFinalMaraton.cboJuez3.Text = Me.cboJuez3.Text
        PlanillaFinalMaraton.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaFinalMaraton.cboSexo.Text = Me.cboSexo.Text
        PlanillaFinalMaraton.cboCategoria.Text = Me.cboCategoria.Text
        PlanillaFinalMaraton.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaFinalMaraton.Show()
    End Sub

    Private Sub Ordenar()
        'ORDENA EL DATAGRID Y PONE LAS POSICIONES
        dgvTiemposMaraton.Sort(dgvTiemposMaraton.Columns(8), System.ComponentModel.ListSortDirection.Ascending)
        Dim cont As Integer
        cont = 0
        For Each rows As DataGridViewRow In Me.dgvTiemposMaraton.Rows
            cont = cont + 1
            rows.Cells(9).Value = cont
        Next
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dgvTiemposMaraton_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvTiemposMaraton.CellFormatting
        e.CellStyle.SelectionBackColor = Color.Azure
        e.CellStyle.SelectionForeColor = Color.Black
        Try
            If Me.dgvTiemposMaraton.Columns(e.ColumnIndex).Name = "Tiempo Juez 1" Then

                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow

                    End If
                End If
            End If
            If Me.dgvTiemposMaraton.Columns(e.ColumnIndex).Name = "Tiempo Juez 2" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvTiemposMaraton.Columns(e.ColumnIndex).Name = "Tiempo Juez 3" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvTiemposMaraton.Columns(e.ColumnIndex).Name = "Mejor" Then
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