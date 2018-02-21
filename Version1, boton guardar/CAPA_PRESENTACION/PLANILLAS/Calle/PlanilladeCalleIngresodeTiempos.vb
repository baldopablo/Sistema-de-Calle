Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Web.UI.WebControls

Public Class IngresodeTiemposdeCalle

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property ResultadoSeleccionado As New CEResultados_x_Atleta
    Shared Property ResultadoFinalSeleccionado As New CEResultados_x_Competencia

    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia

    Dim capanegocio1 As New CNResultadoParcial
    Dim capanegocio2 As New CNAtletas_x_Competencia
    Dim capanegocio3 As New CNResultados_x_Atleta
    Dim capanegocio4 As New CNResultados_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click

        'btnInformeFinal.Enabled = True
        If dgvTiempos.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To dgvTiempos.Rows.Count - 1

                    ResultadoFinalSeleccionado.id_resultado_x_competencia = dgvTiempos.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value
                    ResultadoFinalSeleccionado.id_competencia = txtCodigoPlanillaCalle.Text
                    ResultadoFinalSeleccionado.id_atleta = dgvTiempos.Rows(i).Cells.Item("Id_Atleta").Value
                    ResultadoFinalSeleccionado.mejor = dgvTiempos.Rows(i).Cells.Item("Mejor").Value
                    ResultadoFinalSeleccionado.posicion = dgvTiempos.Rows(i).Cells.Item("Posicion").Value
                    ResultadoFinalSeleccionado.serie = dgvTiempos.Rows(i).Cells.Item("Serie").Value
                    ResultadoFinalSeleccionado.valor = PlanillaDeCalle.txtValor.Text
                    ResultadoFinalSeleccionado.descripcion = dgvTiempos.Rows(i).Cells.Item("Descripcion").Value
                    ResultadoFinalSeleccionado.id_juez = PlanillaDeCalle.cboJuez1.SelectedValue
                    ResultadoFinalSeleccionado.dorsal = dgvTiempos.Rows(i).Cells.Item("Dorsal").Value

                    CompetenciaSeleccionada.juez1 = cboJuez1.SelectedValue
                    CompetenciaSeleccionada.juez2 = cboJuez2.SelectedValue
                    CompetenciaSeleccionada.juez3 = cboJuez3.SelectedValue

                    AtletaxCompetenciaSeleccionada.id_atleta = dgvTiempos.Rows(i).Cells.Item("Id_Atleta").Value
                    AtletaxCompetenciaSeleccionada.id_competencia = txtCodigoPlanillaCalle.Text
                    AtletaxCompetenciaSeleccionada.id_resultado_competencia = dgvTiempos.Rows(i).Cells.Item("Id_Resultados_X_Competencia").Value

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

    Private Sub IngresodeTiempos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    ' CREACION DE CONSTANTES 
    Const COLUMNA_PRIMER_TIEMPO As Integer = 5
    Const COLUMNA_SEGUNDO_TIEMPO As Integer = 6
    Const COLUMNA_TERCER_TIEMPO As Integer = 7
    Const COLUMNA_MEJOR_TIEMPO As Integer = 8

    ' BOTON AGREGAR TIEMPO
    Private Sub btnAgregarTiempo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTiempo.Click
        'VALIDA HS VACIA (00:00:00)
        If dtpTiempo.Value.ToString("HH:mm:ss") = "00:00:00" Then
            MessageBox.Show("Debe ingresar un tiempo para poder continuar")
            dtpTiempo.Select()
            dtpTiempo.Focus()
            Exit Sub
        End If
        'CONFIRMA INGRESO DE TIEMPO DEL ATLETA CON APELLIDO.....
        Dim filaActual = Me.dgvTiempos.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el tiempo de: " & Environment.NewLine & CStr(filaActual.Cells(3).Value),
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
                    Dim fila = dgvTiempos.CurrentRow
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

    ' CALCULO DEL MEJOR TIEMPO
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
        If dgvTiempos.Rows.Count <> 0 Then
        
        End If
        'limpiar el time picker
        dtpTiempo.Value = Date.FromOADate(0)
        'txtCodigoPlanillaCalle.Visible = False
        'Label3.Visible = False
        Label13.Visible = False
        cboUsuario.Visible = False
        btnActualizar.Enabled = True
        btnInformeFinal.Enabled = False
        Label3.Visible = False
        txtCodigoPlanillaCalle.Visible = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        dtpfechainicio.Enabled = False
        'Me.dgvTiempos.Columns("Id_Atleta").Visible = False
        cargarlista()
    End Sub

    Private Sub btnInformeFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnInformeFinal.Click

        txtEstado.Text = "Finalizada"
        PlanillaFinalCalle.txtCodigoPlanillaCalle.Text = Me.txtCodigoPlanillaCalle.Text
        PlanillaFinalCalle.txtNombre.Text = Me.txtNombre.Text
        PlanillaFinalCalle.txtLugar.Text = Me.txtLugar.Text
        PlanillaFinalCalle.cboProvincia.Text = Me.cboProvincia.Text
        PlanillaFinalCalle.cboLocalidad.Text = Me.cboLocalidad.Text
        PlanillaFinalCalle.dtpfechainicio.Text = Me.dtpfechainicio.Text
        PlanillaFinalCalle.txtHora.Text = Me.txtHora.Text
        PlanillaFinalCalle.txtDistanciaCompetenciaCalle.Text = Me.txtDistanciaCompetenciaCalle.Text
        PlanillaFinalCalle.txtEstado.Text = Me.txtEstado.Text
        PlanillaFinalCalle.cboJuez1.Text = Me.cboJuez1.Text
        PlanillaFinalCalle.cboJuez2.Text = Me.cboJuez2.Text
        PlanillaFinalCalle.cboJuez3.Text = Me.cboJuez3.Text
        PlanillaFinalCalle.cboUsuario.Text = Me.cboUsuario.Text
        PlanillaFinalCalle.Show()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Sub cargarlista()
        dgvTiempos.DataSource = capanegocio2.Ultimo_Registro_Atleta_x_Competencia_Calle.Tables("Ultimo Registro Atleta por Competencia Calle")
        dgvTiempos.Columns(0).HeaderText = "Código"
        dgvTiempos.Columns(0).Visible = False
        dgvTiempos.Columns(1).HeaderText = "Dorsal"
        dgvTiempos.Columns(2).HeaderText = "Nombre"
        dgvTiempos.Columns(3).HeaderText = "Apellido"
        dgvTiempos.Columns(4).HeaderText = "Edad"
        dgvTiempos.Columns(5).HeaderText = "1° Tiempo"
        dgvTiempos.Columns(6).HeaderText = "2° Tiempo"
        dgvTiempos.Columns(7).HeaderText = "3° Tiempo"
        dgvTiempos.Columns(8).HeaderText = "Mejor Tiempo"
        dgvTiempos.Columns(9).HeaderText = "Posición"
        dgvTiempos.Columns(10).HeaderText = "Serie"
        dgvTiempos.Columns(10).Visible = False
        dgvTiempos.Columns(11).HeaderText = "Descripción"
        dgvTiempos.Columns(11).Visible = False
        dgvTiempos.Columns(12).HeaderText = "Código Resultado"
        dgvTiempos.Columns(12).Visible = False

    End Sub

    Private Sub Ordenar()
        'ORDENA EL DATAGRID Y PONE AS POSICIONES
        dgvTiempos.Sort(dgvTiempos.Columns(8), System.ComponentModel.ListSortDirection.Ascending)
        Dim cont As Integer
        cont = 0
        For Each rows As DataGridViewRow In Me.dgvTiempos.Rows
            cont = cont + 1
            rows.Cells(9).Value = cont
        Next
    End Sub

    Private Sub dgvTiempos_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvTiempos.CellFormatting
        'e.CellStyle.SelectionBackColor = Color.Azure
        'e.CellStyle.SelectionForeColor = Color.Black
        'If dgvTiempos.Rows.Count <> 0 Then
        '    dgvTiempos.Columns("Tiempo Juez 1").DefaultCellStyle.SelectionBackColor = Color.Transparent
        '    dgvTiempos.Columns("Tiempo Juez 1").DefaultCellStyle.SelectionForeColor = dgvTiempos.DefaultCellStyle.ForeColor
        '    dgvTiempos.Columns("Tiempo Juez 2").DefaultCellStyle.SelectionBackColor = Color.Transparent
        '    dgvTiempos.Columns("Tiempo Juez 2").DefaultCellStyle.SelectionForeColor = dgvTiempos.DefaultCellStyle.ForeColor
        '    dgvTiempos.Columns("Tiempo Juez 3").DefaultCellStyle.SelectionBackColor = Color.Transparent
        '    dgvTiempos.Columns("Tiempo Juez 3").DefaultCellStyle.SelectionForeColor = dgvTiempos.DefaultCellStyle.ForeColor
        'End If
        Try
            For Each Row As DataGridViewRow In dgvTiempos.Rows
                If Me.dgvTiempos.Columns(e.ColumnIndex).Name = "Tiempo Juez 1" Then
                    dgvTiempos.Columns("Tiempo Juez 1").DefaultCellStyle.SelectionBackColor = Color.Transparent
                    dgvTiempos.Columns("Tiempo Juez 1").DefaultCellStyle.SelectionForeColor = dgvTiempos.DefaultCellStyle.ForeColor
                    dgvTiempos.Columns("Tiempo Juez 1").DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10)

                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, String)
                        If (valor >= "00:00:00") Then
                            e.CellStyle.BackColor = Color.GreenYellow

                        End If
                    End If
                End If
                If Me.dgvTiempos.Columns(e.ColumnIndex).Name = "Tiempo Juez 2" Then
                    dgvTiempos.Columns("Tiempo Juez 2").DefaultCellStyle.SelectionBackColor = Color.Transparent
                    dgvTiempos.Columns("Tiempo Juez 2").DefaultCellStyle.SelectionForeColor = dgvTiempos.DefaultCellStyle.ForeColor
                    dgvTiempos.Columns("Tiempo Juez 2").DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10)
                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, String)
                        If (valor >= "00:00:00") Then
                            e.CellStyle.BackColor = Color.GreenYellow
                        End If
                    End If
                End If
                If Me.dgvTiempos.Columns(e.ColumnIndex).Name = "Tiempo Juez 3" Then
                    dgvTiempos.Columns("Tiempo Juez 3").DefaultCellStyle.SelectionBackColor = Color.Transparent
                    dgvTiempos.Columns("Tiempo Juez 3").DefaultCellStyle.SelectionForeColor = dgvTiempos.DefaultCellStyle.ForeColor
                    dgvTiempos.Columns("Tiempo Juez 3").DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10)
                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, String)
                        If (valor >= "00:00:00") Then
                            e.CellStyle.BackColor = Color.GreenYellow
                        End If
                    End If
                End If
                If Me.dgvTiempos.Columns(e.ColumnIndex).Name = "Mejor" Then
                    dgvTiempos.Columns("Mejor").DefaultCellStyle.SelectionBackColor = Color.Transparent
                    dgvTiempos.Columns("Mejor").DefaultCellStyle.SelectionForeColor = dgvTiempos.DefaultCellStyle.ForeColor
                    dgvTiempos.Columns("Mejor").DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10)
                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, String)
                        If (valor >= "00:00:00") Then
                            e.CellStyle.BackColor = Color.Red
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class


