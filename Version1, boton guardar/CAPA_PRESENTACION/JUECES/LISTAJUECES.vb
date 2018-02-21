Imports System.Data
Imports System.Data.SqlClient
Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD


Public Class LISTAJUECES
    Dim capanegocio As New CNJueces

    Private Sub LISTAJUECES_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargajuez()
        Me.dgvjueces.Columns(1).Visible = False
    End Sub

    Private Sub cargajuez()
        Dim ListadoDeJueces As List(Of CEJueces) = capanegocio.ListadoDeJuecesDTO()
        dgvjueces.DataSource = ListadoDeJueces
        lblTotal.Text = ListadoDeJueces.Count
        dgvjueces.Columns(1).HeaderText = "Código"
        dgvjueces.Columns("id_juez").Visible = False
        dgvjueces.Columns(2).HeaderText = "Nombre y Apellido"
        dgvjueces.Columns(3).HeaderText = "Dni"
        dgvjueces.Columns(4).HeaderText = "Nacionalidad"
        dgvjueces.Columns(5).HeaderText = "Dirección"
        dgvjueces.Columns(6).HeaderText = "Id_Provincia"
        dgvjueces.Columns(6).Visible = False
        dgvjueces.Columns(7).HeaderText = "Provincia"
        dgvjueces.Columns(8).HeaderText = "Tel. Fijo"
        dgvjueces.Columns(9).HeaderText = "Tel. Celular"
        dgvjueces.Columns(10).HeaderText = "Correo Electrónico"
        dgvjueces.Columns(11).HeaderText = "Tipo de Juez"
        dgvjueces.Columns(11).Visible = False
        dgvjueces.AutoSizeColumnsMode = _
DataGridViewAutoSizeColumnsMode.AllCells
        dgvjueces.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.Font = New Font _
            (dgvjueces.Font.Name, dgvjueces.Font.Size, FontStyle.Bold)
        Me.dgvjueces.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        filtrarapellidojuez(TextBox1.Text, dgvjueces)
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Dim juez As CEJueces = dgvjueces.CurrentRow.DataBoundItem
        NUEVOJUEZ.JuezSeleccionado = juez
        NUEVOJUEZ.TipoDeFormulario = TipoFormulario.Modificacion
        NUEVOJUEZ.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim r% = MessageBox.Show("Está seguro de eliminar al Juez..?", "Mensaje",
MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If r = 6 Then
            capanegocio.eliminarjuez(Me.dgvjueces.Rows(Me.dgvjueces.CurrentRow.Index).Cells(0).Value)
            dgvjueces.Columns.Clear()
            cargajuez()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        ReporteListadeJueces.ShowDialog()
    End Sub
End Class
