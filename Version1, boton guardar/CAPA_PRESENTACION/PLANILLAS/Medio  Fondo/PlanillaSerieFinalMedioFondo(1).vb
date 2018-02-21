Imports System.Globalization

Public Class PlanillaSerieFinalMedioFondo

    Private Sub PlanillaSerieFinalMedioFondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

    End Sub

    Sub PrepararFormulario()
        Label1.Visible = False
        Label18.Visible = False
        txtCodigoMedioFondo.Visible = False
        cboUsuario.Visible = False
        dtpfechainicio.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboPrueba.Enabled = False

        Me.dgvSerie1.Columns("Id_Atleta").Visible = False
        Me.dgvSerie1.Columns("Id_Resultado_Parcial").Visible = False
    End Sub

    Private Sub btnInformeFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnInformeFinal.Click
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
        PlanillaFinalMedio_Fondo.Show()

    End Sub



    Private Sub btnAgregarTiempo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTiempo.Click
        If dtpTiempo.Value.ToString("HH:mm:ss") = "00:00:00" Then
            MessageBox.Show("Debe ingresar un tiempo para poder continuar")
            dtpTiempo.Select()
            dtpTiempo.Focus()
            Exit Sub
        End If

        Dim filaActual = Me.dgvSerie1.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el tiempo de: " + Environment.NewLine + filaActual.Cells(1).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim valor As String = dtpTiempo.Value.ToString("HH:mm:ss")
            CargarSiguienteCelda(filaActual, valor)
            'limpiar el time picker
            dtpTiempo.Value = Date.FromOADate(0)
        End If
        btnActualizar.Enabled = True
        btnInformeFinal.Enabled = True
    End Sub

    Const COLUMNA_PRIMER_TIEMPO As Integer = 2
    Const COLUMNA_SEGUNDO_TIEMPO As Integer = 3
    Const COLUMNA_TERCER_TIEMPO As Integer = 4
    Const COLUMNA_MEJOR_TIEMPO As Integer = 5

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


End Class