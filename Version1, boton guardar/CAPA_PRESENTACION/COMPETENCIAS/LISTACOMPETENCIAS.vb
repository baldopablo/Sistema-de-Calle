Imports System.Data
Imports System.Data.SqlClient
Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD

Public Class LISTACOMPETENCIAS
    Dim capanegocio As New CNCompetencias
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub LISTACOMPETENCIACALLE_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub
    '   TODAS LAS COMPETENCIAS
    Sub ListadoTodasCompetencias()
        Dim ListadoTodasCompetencias As List(Of CECompetencias) = capanegocio.ListadoDeCompetenciasDTO()
        dgvCompetencias.DataSource = ListadoTodasCompetencias
        lbltotalcompetencias.Text = ListadoTodasCompetencias.Count
        Me.dgvCompetencias.Columns(0).Visible = False
        Me.dgvCompetencias.Columns(1).HeaderText = "Nombre"
        Me.dgvCompetencias.Columns(2).HeaderText = "Lugar"
        Me.dgvCompetencias.Columns(3).HeaderText = "Distancia"
        Me.dgvCompetencias.Columns(3).Visible = False
        Me.dgvCompetencias.Columns(4).HeaderText = "Fecha"
        Me.dgvCompetencias.Columns(5).HeaderText = "Hora"
        Me.dgvCompetencias.Columns(6).HeaderText = "Provincia"
        Me.dgvCompetencias.Columns(7).HeaderText = "Id_Provincia"
        Me.dgvCompetencias.Columns(7).Visible = False
        Me.dgvCompetencias.Columns(8).HeaderText = "Localidad"
        Me.dgvCompetencias.Columns(9).HeaderText = "Id_Localidad"
        Me.dgvCompetencias.Columns(9).Visible = False
        Me.dgvCompetencias.Columns(10).HeaderText = "Otra"
        Me.dgvCompetencias.Columns(10).Visible = False
        Me.dgvCompetencias.Columns(11).HeaderText = "Id_Disciplina"
        Me.dgvCompetencias.Columns(11).Visible = False
        Me.dgvCompetencias.Columns(12).HeaderText = "Disciplina"
        Me.dgvCompetencias.Columns(12).Visible = False
        Me.dgvCompetencias.Columns(13).HeaderText = "Id_Prueba"
        Me.dgvCompetencias.Columns(13).Visible = False
        Me.dgvCompetencias.Columns(14).HeaderText = "Prueba"
        Me.dgvCompetencias.Columns(14).Visible = False
        Me.dgvCompetencias.Columns(15).HeaderText = "Juez1"
        Me.dgvCompetencias.Columns(15).Visible = False
        Me.dgvCompetencias.Columns(16).HeaderText = "Juez2"
        Me.dgvCompetencias.Columns(16).Visible = False
        Me.dgvCompetencias.Columns(17).HeaderText = "Juez3"
        Me.dgvCompetencias.Columns(17).Visible = False
        Me.dgvCompetencias.Columns(18).HeaderText = "Id_Usuario"
        Me.dgvCompetencias.Columns(18).Visible = False
        Me.dgvCompetencias.Columns(19).HeaderText = "Estado de Competencia"
        Me.dgvCompetencias.Columns(19).Visible = False
        dgvCompetencias.AutoSizeColumnsMode = _
    DataGridViewAutoSizeColumnsMode.AllCells
        dgvCompetencias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.Font = New Font _
            (dgvCompetencias.Font.Name, dgvCompetencias.Font.Size, FontStyle.Bold)
        Me.dgvCompetencias.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub
    ' COMPETENCIAS DE CALLE
    Private Sub ListaCompetenciaCalle()
        Dim ListadoCompetenciaCalle As List(Of CECompetencias) = capanegocio.ListaCompetenciaCalleDTO()
        dgvCompetencias.DataSource = ListadoCompetenciaCalle
        lbltotalcompetencias.Text = ListadoCompetenciaCalle.Count
        Me.dgvCompetencias.Columns(0).Visible = False
        Me.dgvCompetencias.Columns(1).HeaderText = "Nombre"
        Me.dgvCompetencias.Columns(2).HeaderText = "Lugar"
        Me.dgvCompetencias.Columns(3).HeaderText = "Distancia"
        Me.dgvCompetencias.Columns(4).HeaderText = "Fecha"
        Me.dgvCompetencias.Columns(5).HeaderText = "Hora"
        Me.dgvCompetencias.Columns(6).HeaderText = "Provincia"
        Me.dgvCompetencias.Columns(7).HeaderText = "Id_Provincia"
        Me.dgvCompetencias.Columns(7).Visible = False
        Me.dgvCompetencias.Columns(8).HeaderText = "Localidad"
        Me.dgvCompetencias.Columns(9).HeaderText = "Id_Localidad"
        Me.dgvCompetencias.Columns(9).Visible = False
        Me.dgvCompetencias.Columns(10).HeaderText = "Otra"
        Me.dgvCompetencias.Columns(10).Visible = False
        Me.dgvCompetencias.Columns(11).HeaderText = "Id_Disciplina"
        Me.dgvCompetencias.Columns(11).Visible = False
        Me.dgvCompetencias.Columns(12).HeaderText = "Disciplina"
        Me.dgvCompetencias.Columns(12).Visible = False
        Me.dgvCompetencias.Columns(13).HeaderText = "Id_Prueba"
        Me.dgvCompetencias.Columns(13).Visible = False
        Me.dgvCompetencias.Columns(14).HeaderText = "Prueba"
        Me.dgvCompetencias.Columns(14).Visible = False
        Me.dgvCompetencias.Columns(15).HeaderText = "Juez1"
        Me.dgvCompetencias.Columns(15).Visible = False
        Me.dgvCompetencias.Columns(16).HeaderText = "Juez2"
        Me.dgvCompetencias.Columns(16).Visible = False
        Me.dgvCompetencias.Columns(17).HeaderText = "Juez3"
        Me.dgvCompetencias.Columns(17).Visible = False
        Me.dgvCompetencias.Columns(18).HeaderText = "Id_Usuario"
        Me.dgvCompetencias.Columns(18).Visible = False
        Me.dgvCompetencias.Columns(19).HeaderText = "Estado de Competencia"
        Me.dgvCompetencias.Columns(19).Visible = False
        dgvCompetencias.AutoSizeColumnsMode = _
DataGridViewAutoSizeColumnsMode.AllCells
        dgvCompetencias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.Font = New Font _
            (dgvCompetencias.Font.Name, dgvCompetencias.Font.Size, FontStyle.Bold)
        Me.dgvCompetencias.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub
    'COMPETENCIAS DE PISTA Y CAMPO
    Private Sub ListaCompetenciaPista()
        Dim ListadoCompetenciaPista As List(Of CECompetencias) = capanegocio.ListadoCompetenciaPistaDTO()
        dgvCompetencias.DataSource = ListadoCompetenciaPista
        lbltotalcompetencias.Text = ListadoCompetenciaPista.Count
        Me.dgvCompetencias.Columns(0).Visible = False
        Me.dgvCompetencias.Columns(1).HeaderText = "Nombre"
        Me.dgvCompetencias.Columns(2).HeaderText = "Lugar"
        Me.dgvCompetencias.Columns(3).HeaderText = "Distancia"
        Me.dgvCompetencias.Columns(3).Visible = False
        Me.dgvCompetencias.Columns(4).HeaderText = "Fecha"
        Me.dgvCompetencias.Columns(5).HeaderText = "Hora"
        Me.dgvCompetencias.Columns(6).HeaderText = "Provincia"
        Me.dgvCompetencias.Columns(7).HeaderText = "Id_Provincia"
        Me.dgvCompetencias.Columns(7).Visible = False
        Me.dgvCompetencias.Columns(8).HeaderText = "Localidad"
        Me.dgvCompetencias.Columns(9).HeaderText = "Id_Localidad"
        Me.dgvCompetencias.Columns(9).Visible = False
        Me.dgvCompetencias.Columns(10).HeaderText = "Otra"
        Me.dgvCompetencias.Columns(10).Visible = False
        Me.dgvCompetencias.Columns(11).HeaderText = "Id_Disciplina"
        Me.dgvCompetencias.Columns(11).Visible = False
        Me.dgvCompetencias.Columns(12).HeaderText = "Disciplina"
        Me.dgvCompetencias.Columns(12).Visible = True
        Me.dgvCompetencias.Columns(13).HeaderText = "Id_Prueba"
        Me.dgvCompetencias.Columns(13).Visible = False
        Me.dgvCompetencias.Columns(14).HeaderText = "Prueba"
        Me.dgvCompetencias.Columns(14).Visible = True
        Me.dgvCompetencias.Columns(15).HeaderText = "Juez1"
        Me.dgvCompetencias.Columns(15).Visible = False
        Me.dgvCompetencias.Columns(16).HeaderText = "Juez2"
        Me.dgvCompetencias.Columns(16).Visible = False
        Me.dgvCompetencias.Columns(17).HeaderText = "Juez3"
        Me.dgvCompetencias.Columns(17).Visible = False
        Me.dgvCompetencias.Columns(18).HeaderText = "Id_Usuario"
        Me.dgvCompetencias.Columns(18).Visible = False
        Me.dgvCompetencias.Columns(19).HeaderText = "Estado de Competencia"
        Me.dgvCompetencias.Columns(19).Visible = False
        dgvCompetencias.AutoSizeColumnsMode = _
DataGridViewAutoSizeColumnsMode.AllCells
        dgvCompetencias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.Font = New Font _
            (dgvCompetencias.Font.Name, dgvCompetencias.Font.Size, FontStyle.Bold)
        Me.dgvCompetencias.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    Private Sub txtNombreCompetenciaCalle_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtTodas.CheckedChanged
        ListadoTodasCompetencias()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditarListaCompetencia.Click

        Dim Competencia As CECompetencias = dgvCompetencias.CurrentRow.DataBoundItem
        NUEVACOMPETENCIA.CompetenciaSeleccionada = Competencia
        NUEVACOMPETENCIA.TipoDeFormulario = TipoFormulario.Modificacion
        NUEVACOMPETENCIA.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    'Private Sub dgvCompetencias_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvCompetencias.DoubleClick
    '    Dim codigo = dgvCompetencias.SelectedRows(0).Cells("id_competencia").Value
    '    Dim result = MessageBox.Show("Desea cargar la competencia: " + dgvCompetencias.SelectedRows(0).Cells("Nombre_competencia").Value,
    ' "Confirmar acción", MessageBoxButtons.YesNo)
    '    If result = DialogResult.No Then
    '        Return
    '    End If
    '    Dim f = New PLANILLACOMPETENCIACALLE(codigo)
    '    f.Show()
    'End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim r% = MessageBox.Show("Está seguro de eliminar la Competencia..?", "Mensaje",
MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If r = 6 Then
            capanegocio.eliminarCompetencia(Me.dgvCompetencias.Rows(Me.dgvCompetencias.CurrentRow.Index).Cells(0).Value)
            dgvCompetencias.Columns.Clear()
            ListaCompetenciaCalle()
        End If
    End Sub

    Private Sub PrepararFormulario()
        'If Me.dgvCompetencias.Rows.Count = 0 Then
        '    MessageBox.Show("Ingrese datos en el grid.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        If rbtTodas.Checked = True And rbtDisciplina.Checked = False And rbtDistancia.Checked = False Then
            ListadoTodasCompetencias()
            rbtTodas.Checked = True

        End If

        If rbtDistancia.Checked = True And rbtTodas.Checked = False And rbtDisciplina.Checked = False Then
            ListaCompetenciaCalle()
            rbtDistancia.Checked = True
        End If

        If rbtDisciplina.Checked = True And rbtTodas.Checked = False And rbtDistancia.Checked = False Then
            ListaCompetenciaPista()
            rbtDisciplina.Checked = True
        End If

        'Logica de los botones
        'btnNuevaCompetencia.Enabled = False
        btnEditarListaCompetencia.Enabled = False
        btnEliminar.Enabled = False
        btnCerrar.Enabled = False
        btnImprimir.Enabled = False

        Select Case TipoDeFormulario

            Case TipoFormulario.Alta
                ' btnNuevaCompetencia.Enabled = False
                btnCerrar.Enabled = True
                btnEliminar.Enabled = True
                btnEditarListaCompetencia.Enabled = True

                'EL BOTON ELIMINAR ESTA OCULTO Y DEBE!!!!!! QUEDAR OCULTO
                btnEliminar.Visible = False

            Case TipoFormulario.Baja
                btnEliminar.Enabled = True

            Case TipoFormulario.Consulta
                btnCerrar.Enabled = True

                'AGREGAR A LA COMPETENCIA
                btnImprimir.Enabled = True
                ' btnAgregarACompetencia.Enabled = True
            Case TipoFormulario.Modificacion
        End Select

    End Sub

    Private Sub rbtDistancia_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDistancia.CheckedChanged
        ListaCompetenciaCalle()
    End Sub

    Private Sub rbtDisciplina_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDisciplina.CheckedChanged
        ListaCompetenciaPista()
    End Sub

End Class


