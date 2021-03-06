﻿Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization

Public Class PlanillaSerieUnicaMedioFondo
    Public Property TipoDeFormulario As TipoFormulario
    Shared Property ResultadoFinalSeleccionado As New CEResultados_x_Competencia
    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property ResultadoSeleccionado As New CeResultadoParcial
    Dim capanegocio2 As New CNAtletas_x_Competencia
    Dim capanegocio4 As New CNResultados_x_Competencia
    Dim capanegocio1 As New CNResultadoParcial

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        btnInformeFinal.Enabled = True
        If dgvSerie1.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To dgvSerie1.Rows.Count - 1
                    ResultadoFinalSeleccionado.id_resultado_x_competencia = dgvSerie1.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value
                    ResultadoFinalSeleccionado.id_competencia = txtCodigoMedioFondo.Text
                    ResultadoFinalSeleccionado.id_atleta = dgvSerie1.Rows(i).Cells.Item("Id_Atleta").Value
                    ResultadoFinalSeleccionado.mejor = dgvSerie1.Rows(i).Cells.Item("Mejor").Value
                    ResultadoFinalSeleccionado.posicion = dgvSerie1.Rows(i).Cells.Item("Posicion").Value
                    ResultadoFinalSeleccionado.serie = dgvSerie1.Rows(i).Cells.Item("Serie").Value
                    ResultadoFinalSeleccionado.valor = PlanillaDeCalle.txtValor.Text
                    ResultadoFinalSeleccionado.descripcion = dgvSerie1.Rows(i).Cells.Item("Descripción").Value
                    ResultadoFinalSeleccionado.id_juez = PlanilladeMedioFondo.cboJuez1.SelectedValue
                    ResultadoFinalSeleccionado.dorsal = dgvSerie1.Rows(i).Cells.Item("Dorsal").Value

                    AtletaxCompetenciaSeleccionada.id_atleta = dgvSerie1.Rows(i).Cells.Item("Id_Atleta").Value
                    AtletaxCompetenciaSeleccionada.id_competencia = txtCodigoMedioFondo.Text
                    AtletaxCompetenciaSeleccionada.id_resultado_competencia = dgvSerie1.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value

                    capanegocio4.Actualizar_Resultado_x_Competencia(ResultadoFinalSeleccionado)
                    capanegocio2.Actualizar_Atleta_x_Competencia(AtletaxCompetenciaSeleccionada)

                Next
                MessageBox.Show("Los registros se han actualizado correctamente", "Actualizando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MsgBox("Error al actualizar los datos de la Planilla")
            End Try
        End If
        btnInformeFinal.Enabled = True
        btnActualizar.Enabled = False
    End Sub

    Private Sub PlanillaSerieUnicaMedioFondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        btnInformeFinal.Enabled = False
        btnActualizar.Enabled = False
        ' Me.dgvSerie1.Columns("Id_Atleta").Visible = True
        'Me.dgvSerie1.Columns("Id_Resultado_Parcial").Visible = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        dtpfechainicio.Enabled = False
        cboPrueba.Enabled = False
        Label22.Visible = False
        cboUsuario.Visible = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cargarlista()
    End Sub

    Sub cargarlista()
        dgvSerie1.DataSource = capanegocio2.Ultimo_Registro_Atleta_x_Competencia_Medio_Fondo.Tables("Ultimo_Registro_Atleta_x_Competencia_Medio_Fondo")
        dgvSerie1.Columns(0).HeaderText = "Código"
        dgvSerie1.Columns(0).Visible = False
        dgvSerie1.Columns(1).HeaderText = "Dorsal"
        dgvSerie1.Columns(2).HeaderText = "Nombre"
        dgvSerie1.Columns(3).HeaderText = "Apellido"
        dgvSerie1.Columns(4).HeaderText = "Club/Federación"
        dgvSerie1.Columns(5).HeaderText = "1° Tiempo"
        dgvSerie1.Columns(6).HeaderText = "2° Tiempo"
        dgvSerie1.Columns(7).HeaderText = "3° Tiempo"
        dgvSerie1.Columns(8).HeaderText = "Mejor Tiempo"
        dgvSerie1.Columns(9).HeaderText = "Posición"
        dgvSerie1.Columns(10).HeaderText = "Serie"
        dgvSerie1.Columns(10).Visible = False
        dgvSerie1.Columns(11).HeaderText = "Descripción"
        dgvSerie1.Columns(11).Visible = False
        dgvSerie1.Columns(12).HeaderText = "Código Resultado"
        dgvSerie1.Columns(12).Visible = False
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
        Dim filaActual = Me.dgvSerie1.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el tiempo de: " + Environment.NewLine + filaActual.Cells(2).Value,
                           "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim valor As String = dtpTiempo.Value.ToString("HH:mm:ss")
            CargarSiguienteCelda(filaActual, valor)
            'limpiar el time picker
            dtpTiempo.Value = Date.FromOADate(0)
        End If
        Ordenar()
        btnActualizar.Enabled = True
    End Sub

    Const COLUMNA_PRIMER_TIEMPO As Integer = 5
    Const COLUMNA_SEGUNDO_TIEMPO As Integer = 6
    Const COLUMNA_TERCER_TIEMPO As Integer = 7
    Const COLUMNA_MEJOR_TIEMPO As Integer = 8

    ' RECORRE LAS CELDAS, VALIDA QUE LA POSICION Q ESTE VACIA E INGRESA EL VALOR
    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As String)
        ' recorre las columnas 4 a 6 que corresponden a los primeros tres tiempos 
        For i As Integer = COLUMNA_PRIMER_TIEMPO To COLUMNA_TERCER_TIEMPO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00:00:00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_TERCER_TIEMPO Then
                    'CALCULA EL TIEMPO MEDIO Y LO ASIGNA A LA COLUMNA MEJOR TIEMPO
                    Dim fila = dgvSerie1.CurrentRow
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

    '' CALCULO DEL MEJOR TIEMPO
    'Private Sub CalcularMejorTiempo(ByRef filaActual As DataGridViewRow)
    '    If String.IsNullOrEmpty(filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value) Then
    '        Dim Tiempos As List(Of Date) = New List(Of Date) ' esto es LINQ
    '        Tiempos.Add(ConvertirADate(filaActual.Cells(COLUMNA_PRIMER_TIEMPO).Value))
    '        Tiempos.Add(ConvertirADate(filaActual.Cells(COLUMNA_SEGUNDO_TIEMPO).Value))
    '        Tiempos.Add(ConvertirADate(filaActual.Cells(COLUMNA_TERCER_TIEMPO).Value))
    '        filaActual.Cells(COLUMNA_MEJOR_TIEMPO).Value = Tiempos.OrderByDescending(Function(t) t.Hour). _
    '            ThenByDescending(Function(t) t.Minute). _
    '            ThenByDescending(Function(t) t.Second).First().ToString("hh:mm:ss")
    '    End If
    'End Sub

    Private Sub btnInformeFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnInformeFinal.Click

        PlanillaFinalMedio_Fondo.txtEstado.Text = "Finalizada"
        PlanillaFinalMedio_Fondo.txtCodigoMedioFondo.Text = Me.txtCodigoMedioFondo.Text
        PlanillaFinalMedio_Fondo.txtNombre.Text = Me.txtNombre.Text
        PlanillaFinalMedio_Fondo.txtLugar.Text = Me.txtLugar.Text
        PlanillaFinalMedio_Fondo.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaFinalMedio_Fondo.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaFinalMedio_Fondo.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaFinalMedio_Fondo.txtHora.Text = Me.txtHora.Text
        PlanillaFinalMedio_Fondo.txtEstado.Text = Me.txtEstado.Text
        PlanillaFinalMedio_Fondo.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaFinalMedio_Fondo.cboJuez2.Text = Me.cboJuez2.Text
        PlanillaFinalMedio_Fondo.cboJuez3.Text = Me.cboJuez3.Text
        PlanillaFinalMedio_Fondo.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaFinalMedio_Fondo.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaFinalMedio_Fondo.cboSexo.Text = Me.cboSexo.Text
        PlanillaFinalMedio_Fondo.cboCategoria.Text = Me.cboCategoria.Text
        PlanillaFinalMedio_Fondo.Show()
        Me.Close()
    End Sub

    Private Sub Ordenar()
        'ORDENA EL DATAGRID POR COLUMNA MEJOR TIEMPO 
        dgvSerie1.Sort(dgvSerie1.Columns(8), System.ComponentModel.ListSortDirection.Ascending)

        Dim cont As Integer
        cont = 0
        'PONE LAS POSICIONES
        For Each rows As DataGridViewRow In Me.dgvSerie1.Rows
            cont = cont + 1
            rows.Cells(9).Value = cont
        Next
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub dgvSerie1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvSerie1.CellFormatting
        e.CellStyle.SelectionBackColor = Color.Azure
        e.CellStyle.SelectionForeColor = Color.Black
        Try
            If Me.dgvSerie1.Columns(e.ColumnIndex).Name = "Tiempo Juez 1" Then

                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow

                    End If
                End If
            End If
            If Me.dgvSerie1.Columns(e.ColumnIndex).Name = "Tiempo Juez 2" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvSerie1.Columns(e.ColumnIndex).Name = "Tiempo Juez 3" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor >= "00:00:00") Then
                        e.CellStyle.BackColor = Color.GreenYellow
                    End If
                End If
            End If
            If Me.dgvSerie1.Columns(e.ColumnIndex).Name = "Mejor" Then
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