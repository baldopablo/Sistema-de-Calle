Imports System.Windows.Forms

Public Class VentanaPrincipaldelSistema

    Private Sub NuevoUsuarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoUsuarioToolStripMenuItem.Click
        LimpiarFormNuevoUsuario()
        CargarFormNuevoUsuario()
        NUEVOUSUARIO.MdiParent = Me
        NUEVOUSUARIO.Show()
    End Sub

    Private Sub ListaDeUsuariosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListaDeUsuariosToolStripMenuItem.Click
        LISTAUSUARIOS.MdiParent = Me
        LISTAUSUARIOS.Show()
    End Sub

    Private Sub NuevoAtletaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoAtletaToolStripMenuItem.Click
        LimpiarControlesAtleta()
        CargarControlesAtleta()
        NUEVOATLETA.TipoDeFormulario = TipoFormulario.Alta
        NUEVOATLETA.MdiParent = Me
        NUEVOATLETA.Show()
    End Sub

    Private Sub ListaDeAtletasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListaDeAtletasToolStripMenuItem.Click
        LISTA_DE_ATLETAS.MdiParent = Me
        LISTA_DE_ATLETAS.TipoDeFormulario = TipoFormulario.Listado
        LISTA_DE_ATLETAS.Show()
    End Sub

    Private Sub ListaDeCompetenciasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListaDeCompetenciasToolStripMenuItem.Click
        LISTACOMPETENCIAS.MdiParent = Me
        LISTACOMPETENCIAS.Show()
    End Sub

    Private Sub NuevoJuezToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoJuezToolStripMenuItem.Click
        LimpiarFormNuevoJuez()
        NUEVOJUEZ.Text = "Registro de Jueces"
        NUEVOJUEZ.txtNacionalidad.Text = "Argentina"
        NUEVOJUEZ.cboProv.Text = "--Seleccionar--"
        NUEVOJUEZ.cbotipo.Text = "--Seleccionar--"
        NUEVOJUEZ.btnActualizarJuez.Enabled = False
        NUEVOJUEZ.btnCancelar.Enabled = True
        NUEVOJUEZ.btnRegistrar.Enabled = True
        NUEVOJUEZ.MdiParent = Me
        NUEVOJUEZ.Show()
    End Sub
    Sub LimpiarFormNuevoJuez()
        NUEVOJUEZ.txtnombrejuez.Text = Nothing
        NUEVOJUEZ.txtapejuez.Text = Nothing
        NUEVOJUEZ.txtdnijuez.Text = Nothing
        NUEVOJUEZ.txtNacionalidad.Text = Nothing
        NUEVOJUEZ.cboProv.SelectedIndex = -1
        NUEVOJUEZ.txtdirejuez.Text = Nothing
        NUEVOJUEZ.txtfijojuez.Text = Nothing
        NUEVOJUEZ.txtcelujuez.Text = Nothing
        NUEVOJUEZ.txtmailjuez.Text = Nothing
        NUEVOJUEZ.cbotipo.SelectedIndex = -1
    End Sub

    Private Sub ListaDeJuecesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListaDeJuecesToolStripMenuItem.Click
        LISTAJUECES.MdiParent = Me
        LISTAJUECES.Show()
    End Sub

    Private Sub NuevoClubFederaciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoClubFederaciónToolStripMenuItem.Click
        LimpiarFormNuevoClub()
        NUEVOCLUBFEDERACION.btnRegistrar.Enabled = True
        NUEVOCLUBFEDERACION.btnActualizar.Enabled = False
        NUEVOCLUBFEDERACION.btncancelar.Enabled = True
        NUEVOCLUBFEDERACION.MdiParent = Me
        NUEVOCLUBFEDERACION.Show()
    End Sub

    Private Sub ListaDeClubesFederacionesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListaDeClubesFederacionesToolStripMenuItem.Click
        LISTADOCLUBFEDERACION.MdiParent = Me
        LISTADOCLUBFEDERACION.Show()
    End Sub

    Private Sub NuevaCompetenciaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaCompetenciaToolStripMenuItem.Click
        NUEVACOMPETENCIA.MdiParent = Me
        NUEVACOMPETENCIA.Show()
    End Sub


    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "Está seguro que desea salir"
        style = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
        title = "Salir"
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub CalleToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles CalleToolStripMenuItem.Click
        Informe_Final_Calle.ShowDialog()
    End Sub

    Private Sub CrossCountryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CrossCountryToolStripMenuItem.Click
        Informe_Final_Cross_Country.ShowDialog()
    End Sub

    Private Sub LanzamientoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LanzamientoToolStripMenuItem.Click
        Informe_Final_Lanzamiento.ShowDialog()
    End Sub

    Private Sub MaratónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MaratónToolStripMenuItem.Click
        Informe_Final_Maratón.ShowDialog()
    End Sub

    Private Sub MarchaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MarchaToolStripMenuItem.Click
        Informe_Final_Marcha.ShowDialog()
    End Sub

    Private Sub MedioFondoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MedioFondoToolStripMenuItem.Click
        Informe_Final_Medio_Fondo.ShowDialog()
    End Sub

    Private Sub ObstáculosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ObstáculosToolStripMenuItem.Click
        Informe_Final_Obstáculos.ShowDialog()
    End Sub

    Private Sub VelocidadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VelocidadToolStripMenuItem.Click
        Informe_Final_Velocidad.ShowDialog()
    End Sub

    Private Sub LargoYTripleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LargoYTripleToolStripMenuItem.Click
        Informe_Final_Salto.ShowDialog()
    End Sub

    Private Sub FondoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FondoToolStripMenuItem.Click
        Informe_Final_Fondo.ShowDialog()
    End Sub
    Sub LimpiarControlesAtleta()
        NUEVOATLETA.txtNombreAtleta.Text = Nothing
        NUEVOATLETA.txtApellidoAtleta.Text = Nothing
        NUEVOATLETA.txtDniAtleta.Text = Nothing
        NUEVOATLETA.dtpFechaNacimiento.Text = Nothing
        NUEVOATLETA.txtNacionalidad.Text = Nothing
        NUEVOATLETA.cboProvAtleta.SelectedIndex = -1
        NUEVOATLETA.cboLocAtleta.SelectedIndex = -1
        NUEVOATLETA.cboSexo.SelectedIndex = -1
        NUEVOATLETA.txtDomicilioAtleta.Text = Nothing
        NUEVOATLETA.txtBarrioAtleta.Text = Nothing
        NUEVOATLETA.txtFijoAtleta.Text = Nothing
        NUEVOATLETA.txtCelularAtleta.Text = Nothing
        NUEVOATLETA.txtEmailAtleta.Text = Nothing
        NUEVOATLETA.txtContactoEmergencia.Text = Nothing
        NUEVOATLETA.TxtNumeroAtleta.Text = "0"
        NUEVOATLETA.txtFederado.Text = Nothing
    End Sub

    Sub CargarControlesAtleta()
        NUEVOATLETA.Text = "Registro de Atletas"
        NUEVOATLETA.txtNacionalidad.Text = "Argentina"
        NUEVOATLETA.txtFederado.Text = "No"
        NUEVOATLETA.TxtNumeroAtleta.Text = "0"
        NUEVOATLETA.btnValidarExistencia.Enabled = True
        NUEVOATLETA.btnRegistrarAtleta.Enabled = True
        NUEVOATLETA.btnLimpiar.Enabled = True
        NUEVOATLETA.btnConfirmarAsistencia.Enabled = False
        NUEVOATLETA.btnCancelar.Enabled = True
        NUEVOATLETA.btnActualizarAtleta.Enabled = False
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

    Sub CargarFormNuevoUsuario()
        NUEVOUSUARIO.Text = "Registro de Usuarios"
        NUEVOUSUARIO.GroupBox2.Enabled = True
        NUEVOUSUARIO.GroupBox1.Enabled = True
        NUEVOUSUARIO.txtcodigo.Enabled = True
        NUEVOUSUARIO.txtNombre.Enabled = True
        NUEVOUSUARIO.txtApellido.Enabled = True
        NUEVOUSUARIO.cboprovincia.Text = "--Seleccionar--"
        NUEVOUSUARIO.txtDireccion.Enabled = True
        NUEVOUSUARIO.txtBarrio.Enabled = True
        NUEVOUSUARIO.txtTelefonoFijo.Enabled = True
        NUEVOUSUARIO.txtTelefonoCelular.Enabled = True
        NUEVOUSUARIO.txtEmail.Enabled = True
        NUEVOUSUARIO.txtNombreUsuario.Enabled = True
        NUEVOUSUARIO.txtContraseña.Enabled = True
        NUEVOUSUARIO.cboPerfilUsuario.Text = "--Seleccionar--"
        NUEVOUSUARIO.cboPerfilUsuario.Enabled = True
        NUEVOUSUARIO.btnRegistrarUsuario.Enabled = True
        NUEVOUSUARIO.btnRegistrarUsuario.Visible = True
        NUEVOUSUARIO.btnActualizarUsuario.Enabled = False
        NUEVOUSUARIO.btncancelar.Enabled = True
    End Sub

    Sub LimpiarFormNuevoClub()
        NUEVOCLUBFEDERACION.txtnombreclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtdireccionclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtfijoclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtceluclub.Text = Nothing
        NUEVOCLUBFEDERACION.txtmailclub.Text = Nothing
    End Sub

    Private Sub EstadísticasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EstadísticasToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("C:\Users\valeria\Desktop\Estadistica.appref-ms")
        Catch ex As Exception
            MsgBox("error")
        End Try

    End Sub
End Class
