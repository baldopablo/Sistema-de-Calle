Imports System.Data
Imports System.Data.SqlClient
Imports CAPA_ENTIDAD
Imports CAPA_NEGOCIO

Public Class LISTADOCLUBFEDERACION
    Dim capanegocio As New CNClubFederación
    Public Property TipoDeFormulario As TipoFormulario

    ''' SE EJECUTA AL CARGARSE EL FORMULARIO
    ''' PONER AQUI TODA LA LOGICA DE "RELLENO" DE CAMPOS
    ''' BOTONERÍA, ETC
    Private Sub PrepararFormulario()
        cargaclubes()

        'logica de botones
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnCerrar.Enabled = True

        Select Case TipoDeFormulario
            Case TipoFormulario.Modificacion
                btnModificar.Enabled = False
        End Select
    End Sub

    Private Sub NUEVOCLUBFEDERACION_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub cargaclubes()
        Dim ListadoDeClubes As List(Of CEClubFederacion) = capanegocio.ListadoDeClubesDTO()
        dgvclubes.DataSource = ListadoDeClubes
        lbltotalclub.Text = ListadoDeClubes.Count
        dgvclubes.Columns(0).HeaderText = "Código"
        dgvclubes.Columns(0).Visible = False
        dgvclubes.Columns(1).HeaderText = "Nombre"
        dgvclubes.Columns(2).HeaderText = "Dirección"
        dgvclubes.Columns(3).HeaderText = "Tel. Fijo"
        dgvclubes.Columns(4).HeaderText = "Tel. Celular"
        dgvclubes.Columns(5).HeaderText = "Correo Electrónico"
        dgvclubes.AutoSizeColumnsMode = _
      DataGridViewAutoSizeColumnsMode.AllCells
        dgvclubes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim cellStyle As New DataGridViewCellStyle
    cellStyle.Font = New Font _
        (dgvclubes.Font.Name, dgvclubes.Font.Size, FontStyle.Bold)
        Me.dgvclubes.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    Private Sub txtnombreclub_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombreclub.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtnombreclub_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnombreclub.TextChanged
        filtrarnombreclub(txtnombreclub.Text, dgvclubes)
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        LimpiarFormNuevoClub()

        NUEVOCLUBFEDERACION.txtnombreclub.Text = True
        NUEVOCLUBFEDERACION.txtdireccionclub.Text = True
        NUEVOCLUBFEDERACION.txtfijoclub.Text = True
        NUEVOCLUBFEDERACION.txtceluclub.Text = True
        NUEVOCLUBFEDERACION.txtmailclub.Text = True

        Dim club As CEClubFederacion = dgvclubes.CurrentRow.DataBoundItem
        NUEVOCLUBFEDERACION.ClubSeleccionado = club
        NUEVOCLUBFEDERACION.TipoDeFormulario = TipoFormulario.Modificacion
        NUEVOCLUBFEDERACION.ShowDialog()
    End Sub

    Sub LimpiarFormNuevoClub()
        NUEVOCLUBFEDERACION.txtnombreclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtdireccionclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtfijoclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtceluclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtmailclub.Text = Nothing
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim r% = MessageBox.Show("Está seguro de eliminar al Club/Federación..?", "Mensaje",
    MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If r = 6 Then
            capanegocio.eliminarclub(Me.dgvclubes.Rows(Me.dgvclubes.CurrentRow.Index).Cells(0).Value)
            dgvclubes.Columns.Clear()
            cargaclubes()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        ReporteListadeClubes.ShowDialog()
    End Sub
End Class