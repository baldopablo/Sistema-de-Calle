Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD


Public Class INGRESOALSISTEMA

    Private Sub INGRESOALSISTEMA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    End Sub

    Dim capanegocio As New CNIngreso

    Private Sub btningresar_Click_1(sender As System.Object, e As System.EventArgs) Handles btningresar.Click
        Try
            If usuarioRegistrado(txtnombreusuario.Text) = True Then
                Dim contra As String = contraseña(txtnombreusuario.Text)
                If contra.Equals(txtcontraseña.Text) = True Then
                    Dim id_perfil As Integer = perfil(txtnombreusuario.Text)
                    'ACA PONES LO QU QEURES QEU SE VEA DEL ENU PRINCIPAL
                    If id_perfil = 2 Then 'ADMINISTRADOR
                        VentanaPrincipaldelSistema.UsuariosToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.AtletasToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.CompetenciaToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.JuezToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.ClubFederaciónToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.InformesGeneralesToolStripMenuItem.Enabled = True
                    ElseIf id_perfil = 3 Then ' FINAL
                        VentanaPrincipaldelSistema.UsuariosToolStripMenuItem.Visible = True
                        VentanaPrincipaldelSistema.UsuariosToolStripMenuItem.DropDownItems(0).Enabled = False
                        VentanaPrincipaldelSistema.UsuariosToolStripMenuItem.DropDownItems(1).Enabled = False
                        VentanaPrincipaldelSistema.AtletasToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.CompetenciaToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.JuezToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.ClubFederaciónToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.InformesGeneralesToolStripMenuItem.Enabled = True
                    ElseIf id_perfil = 4 Then  ' VISITANTE
                        VentanaPrincipaldelSistema.UsuariosToolStripMenuItem.Enabled = True
                        VentanaPrincipaldelSistema.UsuariosToolStripMenuItem.DropDownItems(0).Enabled = False
                        VentanaPrincipaldelSistema.UsuariosToolStripMenuItem.DropDownItems(1).Enabled = False
                        VentanaPrincipaldelSistema.AtletasToolStripMenuItem.Enabled = False
                        VentanaPrincipaldelSistema.CompetenciaToolStripMenuItem.Enabled = False
                        VentanaPrincipaldelSistema.JuezToolStripMenuItem.Enabled = False
                        VentanaPrincipaldelSistema.ClubFederaciónToolStripMenuItem.Enabled = False
                        VentanaPrincipaldelSistema.InformesGeneralesToolStripMenuItem.Enabled = True
                    Else
                        MsgBox("Perfil Erróneo", MsgBoxStyle.OkOnly, "Ingresando al Sistema")
                    End If
                    Me.Hide()
                    MsgBox("Bienvenidos!!!!!", MsgBoxStyle.OkOnly, "Ingresando al Sistema")
                    VentanaPrincipaldelSistema.ShowDialog()
                    Me.Close()
                Else
                    MsgBox("Contraseña Inválida", MsgBoxStyle.Exclamation, "Atención")
                    txtcontraseña.Text = ""
                    txtcontraseña.Focus()
                End If
            Else
                MsgBox("El Usuario: " + txtnombreusuario.Text + " no se encuentra registrado", MsgBoxStyle.Exclamation, "Atención")
                txtnombreusuario.Text = ""
                txtcontraseña.Text = ""
                txtnombreusuario.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btncancelar_Click_1(sender As System.Object, e As System.EventArgs) Handles btncancelar.Click
        If MsgBox("desea salir del programa...?", vbQuestion + vbYesNo, "salir") = vbYes Then
            Close()
        End If
    End Sub
End Class