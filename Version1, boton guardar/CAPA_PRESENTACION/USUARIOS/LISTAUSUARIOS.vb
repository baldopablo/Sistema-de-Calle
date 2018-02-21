Imports System.Data
Imports System.Data.SqlClient
Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD ' aqui se encuentra la lista de usuarios

Public Class LISTAUSUARIOS
    Dim capanegocio As New CNUsuarios
    Public Property TipoDeFormulario As TipoFormulario

    Private Sub LISTAUSUARIOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Private Sub PrepararFormulario()
        cargaUsuarios()
        btnImprimir.Enabled = True
        btnModificar.Enabled = True
        btnCambiarContraseña.Enabled = True
        btnEliminar.Enabled = True
        btnCerrar.Enabled = True
        btnEliminar.Visible = True

        ' Me.dgUsuarios.Columns("nombre_usuario").Visible = False
        ' Me.dgUsuarios.Columns("contraseña").Visible = False
        'cargarlista()
        Select Case TipoDeFormulario
            Case TipoFormulario.Baja
                btnEliminar.Enabled = True
                btnCerrar.Enabled = True

            Case TipoFormulario.ModificarContraseñaUsuario
                btnCambiarContraseña.Enabled = True

            Case TipoFormulario.Modificacion
                btnImprimir.Enabled = False
                btnModificar.Enabled = True
                btnCambiarContraseña.Enabled = False
                btnEliminar.Enabled = False
                btnCerrar.Enabled = True
        End Select
    End Sub

    'procedimiento que carga los usuarios
    Sub cargaUsuarios()
        Dim listadoDeUsuarios As List(Of CEUsuarios) = capanegocio.ListadoDeUsuariosDTO 'capanegocio es el enlace 
        dgUsuarios.DataSource = listadoDeUsuarios 'datasource fuente de datos
        lbltotal.Text = listadoDeUsuarios.Count
        dgUsuarios.Columns(0).HeaderText = "Código"
        dgUsuarios.Columns(0).Visible = False
        dgUsuarios.Columns(1).HeaderText = "Nombre"
        dgUsuarios.Columns(2).HeaderText = "Apellido"
        dgUsuarios.Columns(3).HeaderText = "Provincia"
        dgUsuarios.Columns(3).Visible = False
        dgUsuarios.Columns(4).HeaderText = "Dirección"
        dgUsuarios.Columns(5).HeaderText = "Barrio"
        '  dgUsuarios.Columns("Provincia").Visible = False
        dgUsuarios.Columns(6).HeaderText = "Tel. Fijo"
        ' dgUsuarios.Columns(6).Visible = False
        dgUsuarios.Columns(7).HeaderText = "Tel. Celular"
        ' dgUsuarios.Columns(7).Visible = False
        dgUsuarios.Columns(8).HeaderText = "Correo Electrónico"
        dgUsuarios.Columns(9).HeaderText = "Nombre de Usuario"
        dgUsuarios.Columns(10).HeaderText = "Contraseña"
        dgUsuarios.Columns(11).HeaderText = "Perfil de Usuario"
        dgUsuarios.Columns(11).Visible = False
        dgUsuarios.AutoSizeColumnsMode = _
DataGridViewAutoSizeColumnsMode.AllCells
        dgUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.Font = New Font _
            (dgUsuarios.Font.Name, dgUsuarios.Font.Size, FontStyle.Bold)
        Me.dgUsuarios.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtApellido_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
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

    Private Sub txtApellido_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtApellido.TextChanged
        filtrarporapellido(txtApellido.Text, dgUsuarios)
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click

        LimpiarFormNuevoUsuario()
        NUEVOUSUARIO.Text = "MODIFICAR DATOS DEL USUARIO"
        NUEVOUSUARIO.txtcodigo.Enabled = True
        NUEVOUSUARIO.txtNombre.Enabled = True
        NUEVOUSUARIO.txtApellido.Enabled = True
        NUEVOUSUARIO.cboprovincia.Text = "--Seleccionar--"
        NUEVOUSUARIO.txtDireccion.Enabled = True
        NUEVOUSUARIO.txtBarrio.Enabled = True
        NUEVOUSUARIO.txtTelefonoFijo.Enabled = True
        NUEVOUSUARIO.txtTelefonoCelular.Enabled = True
        NUEVOUSUARIO.txtEmail.Enabled = True
        NUEVOUSUARIO.txtNombreUsuario.Enabled = False
        NUEVOUSUARIO.txtContraseña.Enabled = False
        NUEVOUSUARIO.cboPerfilUsuario.Text = "--Seleccionar--"
        NUEVOUSUARIO.btnRegistrarUsuario.Enabled = True
        NUEVOUSUARIO.btnRegistrarUsuario.Visible = True
        NUEVOUSUARIO.btnActualizarUsuario.Enabled = False
        NUEVOUSUARIO.btncancelar.Enabled = True
        NUEVOUSUARIO.GroupBox2.Enabled = False
        NUEVOUSUARIO.GroupBox1.Enabled = True
        NUEVOUSUARIO.btnActualizarUsuario.Enabled = True
        NUEVOUSUARIO.btncancelar.Enabled = True
        NUEVOUSUARIO.btnActualizarUsuario.Enabled = False

        Dim usuario As CEUsuarios = dgUsuarios.CurrentRow.DataBoundItem
        NUEVOUSUARIO.UsuarioSeleccionado = usuario
        NUEVOUSUARIO.TipoDeFormulario = TipoFormulario.Modificacion
        NUEVOUSUARIO.ShowDialog()
    End Sub

    Sub LimpiarFormNuevoUsuario()
        NUEVOUSUARIO.txtcodigo.Text = Nothing
        NUEVOUSUARIO.txtNombre.Text = Nothing
        NUEVOUSUARIO.txtApellido.Text = Nothing
        NUEVOUSUARIO.cboprovincia.SelectedIndex = -1
        NUEVOUSUARIO.txtDireccion.Text = Nothing
        NUEVOUSUARIO.txtBarrio.Text = Nothing
        NUEVOUSUARIO.txtTelefonoFijo.Text = Nothing
        NUEVOUSUARIO.txtTelefonoCelular.Text = Nothing
        NUEVOUSUARIO.txtEmail.Text = Nothing
        NUEVOUSUARIO.txtNombreUsuario.Text = Nothing
        NUEVOUSUARIO.txtContraseña.Text = Nothing
        NUEVOUSUARIO.cboPerfilUsuario.SelectedIndex = -1
    End Sub

    Private Sub btnCambiarContraseña_Click(sender As System.Object, e As System.EventArgs) Handles btnCambiarContraseña.Click
        LimpiarFormNuevoUsuario()
        NUEVOUSUARIO.Text = "CAMBIAR USUARIO Y/O CONTRASEÑA"
        NUEVOUSUARIO.txtcodigo.Enabled = False
        NUEVOUSUARIO.txtNombre.Enabled = False
        NUEVOUSUARIO.txtApellido.Enabled = False
        NUEVOUSUARIO.cboprovincia.Text = "--Seleccionar--"
        NUEVOUSUARIO.txtDireccion.Enabled = False
        NUEVOUSUARIO.txtBarrio.Enabled = False
        NUEVOUSUARIO.txtTelefonoFijo.Enabled = False
        NUEVOUSUARIO.txtTelefonoCelular.Enabled = False
        NUEVOUSUARIO.txtEmail.Enabled = False
        NUEVOUSUARIO.txtNombreUsuario.Enabled = True
        NUEVOUSUARIO.txtContraseña.Enabled = True
        NUEVOUSUARIO.cboPerfilUsuario.Text = "--Seleccionar--"
        NUEVOUSUARIO.GroupBox2.Enabled = True
        NUEVOUSUARIO.GroupBox1.Enabled = False
        NUEVOUSUARIO.btnRegistrarUsuario.Enabled = False
        NUEVOUSUARIO.btnActualizarUsuario.Enabled = True
        NUEVOUSUARIO.btncancelar.Enabled = True

        Dim usuario As CEUsuarios = dgUsuarios.CurrentRow.DataBoundItem
        NUEVOUSUARIO.UsuarioSeleccionado = usuario
        NUEVOUSUARIO.TipoDeFormulario = TipoFormulario.ModificarContraseñaUsuario

        NUEVOUSUARIO.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim r% = MessageBox.Show("Está seguro de eliminar al Usuario..?", "Mensaje",
MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If r = 6 Then
            capanegocio.eliminarusuario(Me.dgUsuarios.Rows(Me.dgUsuarios.CurrentRow.Index).Cells(0).Value)
            dgUsuarios.Columns.Clear()
            cargaUsuarios()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        ReporteListadeUsuarios.ShowDialog()
    End Sub

End Class
