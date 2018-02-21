Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Planilla2SeriesMedioFondo

    Public Property TipoDeFormulario As TipoFormulario
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property ResultadoSeleccionado As New CeResultadoParcial
    Dim capanegocio1 As New CNResultadoParcial

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        btnIraSerieFinal.Enabled = True
        'Try
        ResultadoSeleccionado.Tiempo1 = dgvSerie1.CurrentRow.Cells.Item("TiempoJuez1").Value
        ResultadoSeleccionado.Tiempo2 = dgvSerie1.CurrentRow.Cells.Item("TiempoJuez2").Value
        ResultadoSeleccionado.Tiempo3 = dgvSerie1.CurrentRow.Cells.Item("TiempoJuez3").Value
        ResultadoSeleccionado.mejor_tiempo_medio_fondo = dgvSerie1.CurrentRow.Cells.Item("TiempoAsignado").Value
        ResultadoSeleccionado.clasificacion_medio_fondo = dgvSerie1.CurrentRow.Cells.Item("Clasificación").Value
        ResultadoSeleccionado.serie = txtSerie1.Text
        capanegocio1.ActualizarResultado(ResultadoSeleccionado)
        MsgBox("Se actualizaron correctamente los datos de la serie 1")
        ' Catch ex As Exception
        MsgBox("Error al actualizar los datos de la Planilla")
        ' End Try

        'Try
        ResultadoSeleccionado.Tiempo1 = dgvSerie2.CurrentRow.Cells.Item("TiempoJuez1").Value
        ResultadoSeleccionado.Tiempo2 = dgvSerie2.CurrentRow.Cells.Item("TiempoJuez2").Value
        ResultadoSeleccionado.Tiempo3 = dgvSerie2.CurrentRow.Cells.Item("TiempoJuez3").Value
        ResultadoSeleccionado.mejor_tiempo_medio_fondo = dgvSerie2.CurrentRow.Cells.Item("TiempoAsignado").Value
        ResultadoSeleccionado.clasificacion_medio_fondo = dgvSerie2.CurrentRow.Cells.Item("Clasificación").Value
        ResultadoSeleccionado.serie = txtSerie2.Text

        capanegocio1.ActualizarResultado(ResultadoSeleccionado)

        MsgBox("Se actualizaron correctamente los datos de la serie 2")
        ' Catch ex As Exception
        MsgBox("Error al actualizar los datos de la Planilla")
        ' End Try
    End Sub

    Private Sub btnAgregarSerie1_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarSerie1.Click
        'Se define una lista temporal de registro seleccionados
        Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
        'Se recorre cada registro del grid de origen
        For Each row As DataGridViewRow In Me.dgvSerie1.Rows
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
            Me.dgvSerie2.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value)
            Me.dgvSerie1.Rows.Remove(row)
        Next

        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In Me.dgvSerie1.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            Me.dgvSerie2.Rows.Add(New Object() {row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value})
        Next
    End Sub

    Private Sub btnQuitarSerie1_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitarSerie1.Click
        'Se define una lista temporal de registro seleccionados
        Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
        'Se recorre cada registro del grid de origen
        For Each row As DataGridViewRow In Me.dgvSerie2.Rows
            'Se recupera el campo que representa el checkbox,
            'se valida que esté seleccionado y agregándolo a la lista temporal
            Dim cellSelecion As DataGridViewCheckBoxCell = _
            TryCast(row.Cells("DataGridViewCheckBoxColumn1"), DataGridViewCheckBoxCell)

            If Convert.ToBoolean(cellSelecion.Value) Then
                FilasSeleccionadas.Add(row)
            End If
        Next
        'Se agrega el ítem seleccionado al grid de destino
        'eliminando la fila del grid original
        For Each row As DataGridViewRow In FilasSeleccionadas
            Me.dgvSerie1.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value)
            Me.dgvSerie2.Rows.Remove(row)
        Next

        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In Me.dgvSerie2.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            Me.dgvSerie1.Rows.Add(New Object() {row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value})
        Next
    End Sub

    Private Sub btnAgregarSerieFinal1_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarSerieFinal1.Click
        'Se define una lista temporal de registro seleccionados
        Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
        'Se recorre cada registro del grid de origen
        For Each row As DataGridViewRow In dgvSerie1.Rows
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
            PlanillaSerieFinalMedioFondo.dgvSerie1.Rows.Add(row.Cells(1).Value, row.Cells(2).Value)
            dgvSerie1.Rows.Remove(row)
        Next

        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvSerie1.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            PlanillaSerieFinalMedioFondo.dgvSerie1.Rows.Add(New Object() {row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value})
        Next
    End Sub

    Private Sub btnAgregarTiempo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTiempo.Click
        If dtpTiempo.Value.ToString("HH:mm:ss") = "00:00:00" Then
            MessageBox.Show("Debe ingresar un tiempo para poder continuar")
            dtpTiempo.Select()
            dtpTiempo.Focus()
            Exit Sub
        End If
        Dim filaActual = Me.dgvSerie1.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el tiempo de: " + Environment.NewLine + filaActual.Cells(2).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim valor As String = dtpTiempo.Value.ToString("HH:mm:ss")
            CargarSiguienteCelda1(filaActual, valor)
            'limpiar el time picker
            dtpTiempo.Value = Date.FromOADate(0)
        End If
        btnActualizar.Enabled = True
        btnAgregarSerieFinal1.Enabled = True
    End Sub

    Const COLUMNA_PRIMER_TIEMPO As Integer = 4
    Const COLUMNA_SEGUNDO_TIEMPO As Integer = 5
    Const COLUMNA_TERCER_TIEMPO As Integer = 6
    Const COLUMNA_MEJOR_TIEMPO As Integer = 7

    ' RECORRE LAS CELDAS, VALIDA QUE LA POSICION Q ESTE VACIA E INGRESA EL VALOR
    Private Sub CargarSiguienteCelda1(ByRef filaActual As DataGridViewRow, valorAponer As String)
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

    'Private Sub CalcularMejorTiempoSerie1(ByRef filaActual As DataGridViewRow)
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

    Private Function ConvertirADate(valor As String)
        Dim nuevoTiempo As DateTime = DateTime.ParseExact("01/01/2001 " + valor.Trim(), "dd/MM/yyyy HH:mm:ss", Nothing)
        Return nuevoTiempo
    End Function

    Private Sub btnAgregarSerieFinal2_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarSerieFinal2.Click
        'Se define una lista temporal de registro seleccionados
        Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
        'Se recorre cada registro del grid de origen
        For Each row As DataGridViewRow In dgvSerie2.Rows
            'Se recupera el campo que representa el checkbox,
            'se valida que esté seleccionado y agregándolo a la lista temporal
            Dim cellSelecion As DataGridViewCheckBoxCell = _
            TryCast(row.Cells("DataGridViewCheckBoxColumn1"), DataGridViewCheckBoxCell)

            If Convert.ToBoolean(cellSelecion.Value) Then
                FilasSeleccionadas.Add(row)
            End If
        Next
        'Se agrega el ítem seleccionado al grid de destino
        'eliminando la fila del grid original
        For Each row As DataGridViewRow In FilasSeleccionadas
            PlanillaSerieFinalMedioFondo.dgvSerie1.Rows.Add(row.Cells(1).Value, row.Cells(2).Value)
            dgvSerie2.Rows.Remove(row)
        Next

        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvSerie2.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("DataGridViewCheckBoxColumn1"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            PlanillaSerieFinalMedioFondo.dgvSerie1.Rows.Add(New Object() {row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value})
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If dtpTiempo1.Value.ToString("HH:mm:ss") = "00:00:00" Then
            MessageBox.Show("Debe ingresar un tiempo para poder continuar")
            dtpTiempo1.Select()
            dtpTiempo1.Focus()
            Exit Sub
        End If

        Dim filaActual2 = Me.dgvSerie2.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el tiempo de: " + Environment.NewLine + filaActual2.Cells(2).Value,
                           "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim valor1 As String = dtpTiempo1.Value.ToString("HH:mm:ss")
            CargarSiguienteCelda2(filaActual2, valor1)
            'limpiar el time picker
            dtpTiempo1.Value = Date.FromOADate(0)
        End If
        btnActualizar.Enabled = True
        btnAgregarSerieFinal2.Enabled = True
    End Sub

    ' RECORRE LAS CELDAS, VALIDA QUE LA POSICION Q ESTE VACIA E INGRESA EL VALOR
    Private Sub CargarSiguienteCelda2(ByRef filaActual As DataGridViewRow, valorAponer As String)
        ' recorre las columnas 4 a 6 que corresponden a los primeros tres tiempos 
        For i As Integer = COLUMNA_PRIMER_TIEMPO To COLUMNA_TERCER_TIEMPO
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(CStr(filaActual.Cells(i).Value).Trim()) OrElse CStr(filaActual.Cells(i).Value).Trim() = "00:00:00" Then 'busca la primer posición vacía d las celdas 4,5,6
                filaActual.Cells(i).Value = valorAponer
                If i = COLUMNA_TERCER_TIEMPO Then
                    'CALCULA EL TIEMPO MEDIO Y LO ASIGNA A LA COLUMNA MEJOR TIEMPO
                    Dim fila = dgvSerie2.CurrentRow
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

    'Private Sub CalcularMejorTiempoSerie2(ByRef filaActual2 As DataGridViewRow)
    '    If String.IsNullOrEmpty(filaActual2.Cells(COLUMNA_MEJOR_TIEMPO).Value) Then
    '        Dim Tiempos As List(Of Date) = New List(Of Date) ' esto es LINQ
    '        Tiempos.Add(ConvertirADate(filaActual2.Cells(COLUMNA_PRIMER_TIEMPO).Value))
    '        Tiempos.Add(ConvertirADate(filaActual2.Cells(COLUMNA_SEGUNDO_TIEMPO).Value))
    '        Tiempos.Add(ConvertirADate(filaActual2.Cells(COLUMNA_TERCER_TIEMPO).Value))
    '        filaActual2.Cells(COLUMNA_MEJOR_TIEMPO).Value = Tiempos.OrderByDescending(Function(t) t.Hour). _
    '            ThenByDescending(Function(t) t.Minute). _
    '            ThenByDescending(Function(t) t.Second).First().ToString("hh:mm:ss")
    '    End If

    'End Sub

    Private Sub btnIraSerieFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnIraSerieFinal.Click

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
        PlanillaSerieFinalMedioFondo.cboPrueba.Text = Me.cboPrueba.Text
        PlanillaSerieFinalMedioFondo.cboSexo.Text = Me.cboSexo.Text
        PlanillaSerieFinalMedioFondo.Show()
    End Sub


    Private Sub Planilla2SeriesMedioFondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

    End Sub

    Sub PrepararFormulario()
        dtpTiempo.Value = Date.FromOADate(0)
        cboLocalidad.Enabled = False
        cboProvincia.Enabled = False
        cboPrueba.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        dtpfechainicio.Enabled = False
        Label1.Visible = False
        Label22.Visible = False
        txtCodigoMedioFondo.Visible = False
        cboUsuario.Visible = False
        btnAgregarSerieFinal1.Enabled = False
        btnAgregarSerieFinal2.Enabled = False
        btnActualizar.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class