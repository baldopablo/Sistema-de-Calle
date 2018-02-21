Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions

Public Class NUEVOATLETA

    Dim capanegocio As New CNAtletas
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    Shared Property TipoDeFormulario2 As TipoFormulario

    Shared Property RefGrid As DataGridView

    ' procedimiento que llena los campos (textbox....)
    Private Sub RellenarCampos()
        txtIdAtleta.Text = AtletaSeleccionado.id_atleta
        txtNombreAtleta.Text = AtletaSeleccionado.Nombre_atleta
        txtApellidoAtleta.Text = AtletaSeleccionado.Apellido_atleta
        dtpFechaNacimiento.Text = AtletaSeleccionado.fecha_nacimiento
        txtDniAtleta.Text = AtletaSeleccionado.dni_atleta
        cboSexo.SelectedValue = AtletaSeleccionado.id_sexo
        txtNacionalidad.Text = AtletaSeleccionado.nacionalidad
        cboProvAtleta.SelectedValue = AtletaSeleccionado.id_provincia
        cboLocAtleta.SelectedValue = AtletaSeleccionado.id_localidad
        txtDomicilioAtleta.Text = AtletaSeleccionado.domicilio
        txtBarrioAtleta.Text = AtletaSeleccionado.barrio
        txtFijoAtleta.Text = AtletaSeleccionado.telefono_fijo
        txtCelularAtleta.Text = AtletaSeleccionado.telefono_celular
        txtEmailAtleta.Text = AtletaSeleccionado.e_mail
        txtContactoEmergencia.Text = AtletaSeleccionado.contacto_emergencia
        txtFederado.Text = AtletaSeleccionado.federado
        cboClub.SelectedValue = AtletaSeleccionado.id_club_federacion
        txtinstitucion.Text = AtletaSeleccionado.otra_institucion
        TxtNumeroAtleta.Text = AtletaSeleccionado.dorsal
        txtEstadoAtleta.Text = AtletaSeleccionado.estado_atleta
    End Sub

    Private Sub PrepararFormulario()
        'Logica de los botones
        btnRegistrarAtleta.Enabled = False
        btnActualizarAtleta.Enabled = False
        btnLimpiar.Enabled = False
        btnCancelar.Enabled = False
        btnConfirmarAsistencia.Enabled = False
        txtIdAtleta.Visible = False
        Label25.Visible = False
        txtDniAtleta.Focus()
        txtNombreAtleta.Enabled = False
        txtApellidoAtleta.Enabled = False
        dtpFechaNacimiento.Enabled = False
        txtNacionalidad.Enabled = False
        cboSexo.Enabled = False
        cboProvAtleta.Enabled = False
        cboLocAtleta.Enabled = False
        txtDomicilioAtleta.Enabled = False
        txtBarrioAtleta.Enabled = False
        txtFijoAtleta.Enabled = False
        txtCelularAtleta.Enabled = False
        txtEmailAtleta.Enabled = False
        txtContactoEmergencia.Enabled = False
        txtinstitucion.Enabled = False
        txtFederado.Enabled = False
        cboClub.Enabled = False
        txtEstadoAtleta.Enabled = False
        TxtNumeroAtleta.Enabled = False
        grbDatosparaCompetencia.Enabled = False

        Select Case TipoDeFormulario

            Case TipoFormulario.Alta '  Me.Text = "Registro de atletas"
                'logica de botones y groupbox
                btnRegistrarAtleta.Enabled = True
                btnLimpiar.Enabled = False
                btnRegistrarAtleta.Enabled = True
                btnActualizarAtleta.Enabled = False
                btnConfirmarAsistencia.Enabled = False
                btnCancelar.Enabled = True
                grbDatosparaCompetencia.Enabled = False
                'genera nuevo codigo de alteta
                nuevoCodigoatleta()
                'carga de combobox
                ListaProvinciaAtleta()
                ListaLocalidadAtleta()
                ListaClubAtleta()
                Sexo()

            Case TipoFormulario.AltaCompetencia
                'logica de botones y groupbox
                btnRegistrarAtleta.Enabled = True
                btnLimpiar.Enabled = False
                btnRegistrarAtleta.Enabled = True
                btnActualizarAtleta.Enabled = False
                btnConfirmarAsistencia.Enabled = False
                btnCancelar.Enabled = True
                btnValidarExistencia.Enabled = False
                grbDatosparaCompetencia.Enabled = False
                grbDatosPersonales.Enabled = True
                'genera nuevo codigo de alteta
                nuevoCodigoatleta()
                'carga de combobox
                ListaProvinciaAtleta()
                ListaLocalidadAtleta()
                ListaClubAtleta()
                Sexo()

                txtIdAtleta.Visible = False
                Label25.Visible = True
                txtDniAtleta.Focus()
                txtNombreAtleta.Enabled = True
                txtApellidoAtleta.Enabled = True
                dtpFechaNacimiento.Enabled = True
                txtNacionalidad.Enabled = True
                cboSexo.Enabled = True
                cboProvAtleta.Enabled = True
                cboLocAtleta.Enabled = True
                txtDomicilioAtleta.Enabled = True
                txtBarrioAtleta.Enabled = True
                txtFijoAtleta.Enabled = True
                txtCelularAtleta.Enabled = True
                txtEmailAtleta.Enabled = True
                txtContactoEmergencia.Enabled = True
                txtinstitucion.Enabled = False
                txtFederado.Enabled = False
                cboClub.Enabled = False
                txtEstadoAtleta.Enabled = False
                TxtNumeroAtleta.Enabled = False
                grbDatosparaCompetencia.Enabled = False




            Case TipoFormulario.Baja
                'no hace nada

            Case TipoFormulario.DatosAdicionalesDelAtleta
                Me.Text = "DATOS ADICIONALES DEL ATLETA"
                'logica de botones y groupbox
                btnConfirmarAsistencia.Enabled = True
                btnCancelar.Enabled = True
                btnRegistrarAtleta.Enabled = False
                btnLimpiar.Enabled = False
                btnActualizarAtleta.Enabled = False
                grbDatosparaCompetencia.Enabled = True
                grbDatosPersonales.Enabled = False
                'nuevo codigo de alteta
                nuevoCodigoatleta()
                'carga de combobox
                ListaProvinciaAtleta()
                ListaLocalidadAtleta()
                ListaClubAtleta()
                Sexo()
                cboClub.SelectedValue = AtletaSeleccionado.id_club_federacion
                txtinstitucion.Enabled = True
                txtFederado.Enabled = True
                cboClub.Enabled = True
                txtEstadoAtleta.Enabled = True
                TxtNumeroAtleta.Enabled = True
                'Cargo los campos con los datos del atleta
                RellenarCampos()
                LISTA_DE_ATLETAS.Close()

            Case TipoFormulario.Consulta
                Me.Text = "VER DATOS DEL ATLETA"

                btnActualizarAtleta.Enabled = True
                btnLimpiar.Enabled = True
                btnValidarExistencia.Enabled = False
                btnCancelar.Enabled = True
                'combos
                Sexo()
                ListaProvinciaAtleta()
                ListaLocalidadAtleta()
                ListaClubAtleta()
                cboClub.SelectedValue = AtletaSeleccionado.id_club_federacion
                'genera codigo
                nuevoCodigoatleta()
                'activacion de campos
                txtDniAtleta.Enabled = False
                grbDatosparaCompetencia.Enabled = False
                btnRegistrarAtleta.Enabled = False
                btnActualizarAtleta.Enabled = False
                btnLimpiar.Enabled = False

                btnConfirmarAsistencia.Enabled = False
                txtIdAtleta.Visible = False
                Label25.Visible = False
                'Cargo los campos con los datos del atleta
                RellenarCampos()

            Case TipoFormulario.Modificacion

                Me.Text = "ACTUALIZAR LOS DATOS DEL ATLETA"
                capanegocio.ActualizarAtleta(AtletaSeleccionado)
                nuevoCodigoatleta()
                ListaProvinciaAtleta()
                ListaLocalidadAtleta()
                ListaClubAtleta()
                cboClub.SelectedValue = AtletaSeleccionado.id_club_federacion
                Sexo()
                grbDatosparaCompetencia.Enabled = False

                ' botones
                btnActualizarAtleta.Enabled = True
                btnLimpiar.Enabled = False
                btnCancelar.Enabled = True
                btnValidarExistencia.Enabled = False
                'combos
                ListaProvinciaAtleta()
                ListaLocalidadAtleta()
                ListaClubAtleta()
                'rellena los campos
                RellenarCampos()  'Cargo los campos con los datos del atleta
                'activa los campos
                txtDniAtleta.Enabled = True
                txtNombreAtleta.Enabled = True
                txtApellidoAtleta.Enabled = True
                dtpFechaNacimiento.Enabled = True
                txtNacionalidad.Enabled = True
                cboSexo.Enabled = True
                cboProvAtleta.Enabled = True
                cboLocAtleta.Enabled = True
                txtDomicilioAtleta.Enabled = True
                txtBarrioAtleta.Enabled = True
                txtFijoAtleta.Enabled = True
                txtCelularAtleta.Enabled = True
                txtEmailAtleta.Enabled = True
                txtContactoEmergencia.Enabled = True
                txtinstitucion.Enabled = True
                txtFederado.Enabled = True
                cboClub.Enabled = True
                txtEstadoAtleta.Enabled = True
                TxtNumeroAtleta.Enabled = True
                Exit Sub
        End Select
    End Sub

    Private Sub NUEVOATLETA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' llamamos al procedimiento que carga el formulario
        PrepararFormulario()

    End Sub

    Sub nuevoCodigoatleta()
        txtIdAtleta.Text = capanegocio.nuevocodigoatleta
    End Sub

    Sub ListaProvinciaAtleta()
        cboProvAtleta.DisplayMember = "Nombre_Provincia"
        cboProvAtleta.ValueMember = "Id_Provincia"
        cboProvAtleta.DataSource = capanegocio.ListaProvinciaAtleta.Tables("provincias de atletas")
        cboProvAtleta.SelectedIndex = 22
    End Sub

    Sub ListaLocalidadAtleta()
        'limpiamos el combo
        cboLocAtleta.DataSource = Nothing
        If (Me.cboProvAtleta.SelectedValue Is Nothing) Then 'si no hay ninguna provincia seleccionada salgo
            Return
        End If
        With cboLocAtleta
            .DisplayMember = "Nombre_Localidad"
            .ValueMember = "Id_Localidad"
            'lleno el combo con el listado de localidades filtrado por provincia
            .DataSource = capanegocio.ListaLocalidadAtleta(Me.cboProvAtleta.SelectedValue).Tables(0)
        End With
    End Sub

    Sub ListaClubAtleta()
        cboClub.DataSource = capanegocio.ListaClubAtleta.Tables("Clubes de Atletas")
        cboClub.DisplayMember = "Nombre_Club"
        cboClub.ValueMember = "Id_Club_Federación"
        'cboClub.SelectedIndex = 6
    End Sub

    Sub Sexo()
        cboSexo.DisplayMember = "Sexo"
        cboSexo.ValueMember = "Id_Sexo"
        cboSexo.DataSource = capanegocio.Sexoatleta.Tables("Sexo")
        cboSexo.SelectedIndex = 2
    End Sub

    Function getidatleta()
        Return txtIdAtleta.Text
    End Function

    Function getnombreatleta() As String
        Return txtNombreAtleta.Text
    End Function

    Function getapellidoatleta() As String
        Return txtApellidoAtleta.Text
    End Function

    Function getFechaNacimientoAtleta()
        Return CDate(dtpFechaNacimiento.Text)
    End Function

    Function getDniatleta() As String
        Return txtDniAtleta.Text
    End Function

    Function getNacionalidad() As String
        Return txtNacionalidad.Text
    End Function

    Function getidProvinciaAtleta()
        Return cboProvAtleta.SelectedValue
    End Function

    Function getidLocalidadAtleta()
        Return cboLocAtleta.SelectedValue
    End Function

    Function getDomicilioAtleta() As String
        Return txtDomicilioAtleta.Text
    End Function

    Function getbarrioAtleta() As String
        Return txtBarrioAtleta.Text
    End Function

    Function gettelefono_fijo() As String
        Return txtFijoAtleta.Text
    End Function

    Function gettelefono_celular() As String
        Return txtCelularAtleta.Text
    End Function

    Function gete_mail() As String
        Return txtEmailAtleta.Text
    End Function

    Function getContactoEmergencia() As String
        Return txtContactoEmergencia.Text
    End Function

    Function getFederado() As String
        Return txtFederado.Text
    End Function

    Function getIdClubAtleta() As Integer
        Return cboClub.SelectedValue
    End Function

    Function getOtraInstitucion() As String
        Return txtinstitucion.Text
    End Function

    Function getDorsal()
        Return CInt(TxtNumeroAtleta.Text)
    End Function

    Function getEstadoAtleta()
        Return txtEstadoAtleta.Text
    End Function

    Function getsexo()
        Return cboSexo.SelectedValue
    End Function

    Private Sub txtNacionalidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNacionalidad.KeyPress
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

    Private Sub txtNacionalidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNacionalidad.TextChanged
        If Not txtNacionalidad.Text = "Argentina" Then
            cboProvAtleta.Text = "Otra"
            cboProvAtleta.Enabled = False
            cboLocAtleta.Enabled = False
        Else
            txtNacionalidad.Text = "Argentina"
            cboProvAtleta.Text = "--Seleccionar--"
            cboProvAtleta.Enabled = True
            cboLocAtleta.Enabled = True
        End If
    End Sub

    Private Sub cboProvAtleta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProvAtleta.SelectedIndexChanged
        ListaLocalidadAtleta()
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        LimpiarControlesAtleta()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txtDniAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDniAtleta.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreAtleta.KeyPress
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

    Private Sub txtApellidoAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidoAtleta.KeyPress
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

    Private Sub txtBarrioAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarrioAtleta.KeyPress
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

    Private Sub txtFijoAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFijoAtleta.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCelularAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelularAtleta.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtFederado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFederado.KeyPress
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

    Private Sub txtEstadoAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEstadoAtleta.KeyPress
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

    Private Sub TxtNumeroAtleta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumeroAtleta.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtContactoEmergencia_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactoEmergencia.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Function validar_Mail(ByVal sMail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(sMail, _
                             "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function

    Private Sub txtEmailAtleta_Leave(sender As Object, e As System.EventArgs) Handles txtEmailAtleta.Leave
        If validar_Mail(LCase(txtEmailAtleta.Text)) = False Then
            MessageBox.Show("Dirección de correo electrónico no es valido, el correo debe tener el formato: nombre@dominio.com, " & _
            " por favor seleccione un correo válido", "Validación de correo electronico", MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation)
            txtEmailAtleta.Focus()
            txtEmailAtleta.SelectAll()
        End If
    End Sub

    Private Sub txtNombreAtleta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombreAtleta.TextChanged
        Dim i As Integer
        txtNombreAtleta.Text = StrConv(txtNombreAtleta.Text, VbStrConv.ProperCase)
        i = Len(txtNombreAtleta.Text)
        txtNombreAtleta.SelectionStart = i
    End Sub

    Private Sub txtApellidoAtleta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtApellidoAtleta.TextChanged
        Dim i As Integer
        txtApellidoAtleta.Text = StrConv(txtApellidoAtleta.Text, VbStrConv.ProperCase)
        i = Len(txtApellidoAtleta.Text)
        txtApellidoAtleta.SelectionStart = i
    End Sub

    Private Sub txtDomicilioAtleta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDomicilioAtleta.TextChanged
        Dim i As Integer
        txtDomicilioAtleta.Text = StrConv(txtDomicilioAtleta.Text, VbStrConv.ProperCase)
        i = Len(txtDomicilioAtleta.Text)
        txtDomicilioAtleta.SelectionStart = i
    End Sub

    Private Sub txtBarrioAtleta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBarrioAtleta.TextChanged
        Dim i As Integer
        txtBarrioAtleta.Text = StrConv(txtBarrioAtleta.Text, VbStrConv.ProperCase)
        i = Len(txtBarrioAtleta.Text)
        txtBarrioAtleta.SelectionStart = i
    End Sub

    Private Sub txtFederado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFederado.TextChanged
        Dim i As Integer
        txtFederado.Text = StrConv(txtFederado.Text, VbStrConv.ProperCase)
        i = Len(txtFederado.Text)
        txtFederado.SelectionStart = i
    End Sub

    Private Sub txtEstadoAtleta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEstadoAtleta.TextChanged
        Dim i As Integer
        txtEstadoAtleta.Text = StrConv(txtEstadoAtleta.Text, VbStrConv.ProperCase)
        i = Len(txtEstadoAtleta.Text)
        txtEstadoAtleta.SelectionStart = i
    End Sub

    Private Sub txtinstitucion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtinstitucion.TextChanged
        Dim i As Integer
        txtinstitucion.Text = StrConv(txtinstitucion.Text, VbStrConv.ProperCase)
        i = Len(txtinstitucion.Text)
        txtinstitucion.SelectionStart = i
    End Sub

    Private Sub btnValidarExistencia_Click(sender As System.Object, e As System.EventArgs) Handles btnValidarExistencia.Click
        If txtDniAtleta.Text = "" Then
            MessageBox.Show("Debe ingresar un Número de Documento. Ejemplo: 00000000")
            txtDniAtleta.Clear()
            txtDniAtleta.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtDniAtleta.Text) Then
            MessageBox.Show("Debe ingresar un Número de Documento válido. Ejemplo: 00000000")
            txtDniAtleta.Clear()
            txtDniAtleta.Focus()
            Exit Sub
        End If

        If DniRegistrado(txtDniAtleta.Text) = False Then
            MessageBox.Show("El atleta NO está registrado", "Validando existencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNombreAtleta.Enabled = True
            txtApellidoAtleta.Enabled = True
            dtpFechaNacimiento.Enabled = True
            txtNacionalidad.Enabled = True
            cboSexo.Enabled = True
            cboProvAtleta.Enabled = True
            cboLocAtleta.Enabled = True
            txtDomicilioAtleta.Enabled = True
            txtBarrioAtleta.Enabled = True
            txtFijoAtleta.Enabled = True
            txtCelularAtleta.Enabled = True
            txtEmailAtleta.Enabled = True
            txtContactoEmergencia.Enabled = True
            txtinstitucion.Enabled = True
            txtFederado.Enabled = True
            cboClub.Enabled = True
            txtEstadoAtleta.Enabled = True
            TxtNumeroAtleta.Enabled = True
            btnValidarExistencia.Enabled = False
            Exit Sub
        Else
            MessageBox.Show("El atleta ya se encuentra registrado", "Validando existencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            LISTA_DE_ATLETAS.ShowDialog()
            Me.btnValidarExistencia.Enabled = False
            Me.btnRegistrarAtleta.Enabled = False
            Me.btnLimpiar.Enabled = False
            Me.btnConfirmarAsistencia.Enabled = False
            Me.btnCancelar.Enabled = True
            Me.btnActualizarAtleta.Enabled = False
            Me.Show()
        End If
    End Sub

    Private Sub btnActualizarAtleta_Click_1(sender As System.Object, e As System.EventArgs) Handles btnActualizarAtleta.Click
        Try
            AtletaSeleccionado.id_atleta = txtIdAtleta.Text
            AtletaSeleccionado.Nombre_atleta = txtNombreAtleta.Text
            AtletaSeleccionado.Apellido_atleta = txtApellidoAtleta.Text
            AtletaSeleccionado.fecha_nacimiento = dtpFechaNacimiento.Text
            AtletaSeleccionado.id_sexo = cboSexo.SelectedValue
            AtletaSeleccionado.dni_atleta = txtDniAtleta.Text
            AtletaSeleccionado.nacionalidad = txtNacionalidad.Text
            AtletaSeleccionado.id_provincia = cboProvAtleta.SelectedValue
            AtletaSeleccionado.id_localidad = cboLocAtleta.SelectedValue
            AtletaSeleccionado.domicilio = txtDomicilioAtleta.Text
            AtletaSeleccionado.barrio = txtBarrioAtleta.Text
            AtletaSeleccionado.telefono_fijo = txtFijoAtleta.Text
            AtletaSeleccionado.telefono_celular = txtCelularAtleta.Text
            AtletaSeleccionado.e_mail = txtEmailAtleta.Text
            AtletaSeleccionado.contacto_emergencia = txtContactoEmergencia.Text
            AtletaSeleccionado.federado = txtFederado.Text
            AtletaSeleccionado.id_club_federacion = cboClub.SelectedValue
            AtletaSeleccionado.otra_institucion = txtinstitucion.Text
            AtletaSeleccionado.dorsal = TxtNumeroAtleta.Text
            AtletaSeleccionado.estado_atleta = txtEstadoAtleta.Text

            ' al limpiar los controles y al querer guardar los cambios realizados,
            ' el sistema muestra que hay campos vacios que son necesarios
            ' una vez llenado con campos si permite la actualizacion del atleta
            If txtNombreAtleta.Text = "" Then
                MessageBox.Show("Complete el campo con el Nombre del atleta")
                txtNombreAtleta.Focus()
                Return
            End If
            If txtApellidoAtleta.Text = Nothing Then
                MessageBox.Show("Complete el campo con el apellido del atleta")
                txtApellidoAtleta.Focus()
                Return
            End If
            If Me.dtpFechaNacimiento.Value.Date = DateTime.Now.Date Then
                MessageBox.Show("debe ingresar una fecha de nacimiento válida, ésta no puede ser el día de hoy.")
                dtpFechaNacimiento.Focus()
                Return
            End If
            If txtDomicilioAtleta.Text = Nothing Then
                MessageBox.Show("Complete el campo con el domicilio del atleta")
                txtDomicilioAtleta.Focus()
                Return
            End If
            If txtCelularAtleta.Text = Nothing Then
                MessageBox.Show("Complete el campo con el Telefono Celular del atleta")
                txtCelularAtleta.Focus()
                Return
            End If
            If txtEmailAtleta.Text = Nothing Then
                MessageBox.Show("Complete el campo con el e-mail del atleta")
                txtEmailAtleta.Focus()
                Return
            End If
            capanegocio.ActualizarAtleta(AtletaSeleccionado)
            MsgBox(" Los datos del Atleta han sido actualizados correctamente")
            ' LimpiarControlesAtleta()
            Me.Hide()
            LISTA_DE_ATLETAS.ShowDialog()

        Catch ex As Exception
            MsgBox("Error al actualizar los datos del Atleta")
        End Try
    End Sub

    Private Sub btnRegistrarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnRegistrarAtleta.Click
        'LimpiarControlesAtleta()
        Dim objeto As New CEAtletas ' llena los valores y los envia a la clase usuarios por medio del objeto
        If txtDniAtleta.Text = "" Then
            MessageBox.Show("El DNI del atleta no puede estar vacío")
            txtDniAtleta.Focus()
            Return
        End If
        If txtNombreAtleta.Text = "" Then
            MessageBox.Show("Complete el campo con el nombre del atleta")
            txtNombreAtleta.Focus()
            Return
        End If
        If txtApellidoAtleta.Text = Nothing Then
            MessageBox.Show("Complete el campo con el apellido del atleta")
            txtApellidoAtleta.Focus()
            Return
        End If
        If Me.dtpFechaNacimiento.Value.Date = DateTime.Now.Date Then
            MessageBox.Show("debe ingresar una fecha de nacimiento válida, ésta no puede ser el día de hoy.")
            dtpFechaNacimiento.Focus()
            Return
        End If
        If cboSexo.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar el Sexo del Atleta")
            cboSexo.Focus()
            Return
        End If
        If cboProvAtleta.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar una Provincia")
            cboProvAtleta.Focus()
            Return
        End If
        If txtDomicilioAtleta.Text = Nothing Then
            MessageBox.Show("Complete el campo con el domicilio del atleta")
            txtDomicilioAtleta.Focus()
            Return
        End If
        If txtCelularAtleta.Text = Nothing Then
            MessageBox.Show("Complete el campo con el Telefono Celular del atleta")
            txtCelularAtleta.Focus()
            Return
        End If
        If txtEmailAtleta.Text = Nothing Then
            MessageBox.Show("Complete el campo con el e-mail del atleta")
            txtEmailAtleta.Focus()
            Return
        End If
        objeto.Nombre_atleta = getnombreatleta()
        objeto.Apellido_atleta = getapellidoatleta()
        objeto.dni_atleta = getDniatleta()
        objeto.fecha_nacimiento = getFechaNacimientoAtleta()
        objeto.id_sexo = getsexo()
        objeto.nacionalidad = getNacionalidad()
        objeto.id_provincia = getidProvinciaAtleta()
        objeto.id_localidad = getidLocalidadAtleta()
        objeto.domicilio = getDomicilioAtleta()
        objeto.barrio = getbarrioAtleta()
        objeto.telefono_fijo = gettelefono_fijo()
        objeto.telefono_celular = gettelefono_celular()
        objeto.e_mail = gete_mail()
        objeto.contacto_emergencia = getContactoEmergencia()
        objeto.federado = getFederado()
        objeto.id_club_federacion = getIdClubAtleta()
        objeto.otra_institucion = getOtraInstitucion()
        objeto.dorsal = getDorsal()
        objeto.estado_atleta = getEstadoAtleta()
        Try
            capanegocio.nuevoatleta(objeto) 'el objeto salta a la capa de negocio (ojbu), va al daousuarios a objusu y llena el formulario
            btnLimpiar.PerformClick() ' ejecuta el boton limpiar
            txtIdAtleta.Clear() 'borra campo codigo
            nuevoCodigoatleta() ' llama a procedimiento q carga el nuevo codigo
            'Dim opc As DialogResult = MsgBox("Desea agregar a un nuevo Atleta..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")
            'If opc = Windows.Forms.DialogResult.Yes Then
            '    nuevoCodigoatleta()
            '    LimpiarControlesAtleta()
            '    CargarControlesAtleta()
            'Else
            '    Me.Close()
            '    Exit Sub
            'End If
        Catch ex As Exception
            MsgBox(" Error al registrar al Atleta")
        End Try
    End Sub

    Sub LimpiarControlesAtleta()
        Me.txtNombreAtleta.Text = Nothing
        Me.txtApellidoAtleta.Text = Nothing
        Me.txtDniAtleta.Text = Nothing
        Me.dtpFechaNacimiento.Text = Nothing
        Me.txtNacionalidad.Text = Nothing
        Me.cboProvAtleta.SelectedIndex = -1
        Me.cboLocAtleta.SelectedIndex = -1
        Me.cboSexo.SelectedIndex = -1
        Me.txtDomicilioAtleta.Text = Nothing
        Me.txtBarrioAtleta.Text = Nothing
        Me.txtFijoAtleta.Text = Nothing
        Me.txtCelularAtleta.Text = Nothing
        Me.txtEmailAtleta.Text = Nothing
        Me.txtContactoEmergencia.Text = Nothing
        Me.TxtNumeroAtleta.Text = "0"
        Me.txtFederado.Text = Nothing
    End Sub

    Sub CargarControlesAtleta()
        Me.Text = "Registro de Atletas"
        Me.txtNacionalidad.Text = "Argentina"
        Me.txtFederado.Text = "No"
        Me.TxtNumeroAtleta.Text = "0"
        Me.btnValidarExistencia.Enabled = True
        Me.btnRegistrarAtleta.Enabled = True
        Me.btnLimpiar.Enabled = True
        Me.btnConfirmarAsistencia.Enabled = False
        Me.btnCancelar.Enabled = True
        Me.btnActualizarAtleta.Enabled = False
    End Sub

    Private Sub btnCancelar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmarAsistencia_Click_1(sender As System.Object, e As System.EventArgs) Handles btnConfirmarAsistencia.Click

        'cuando confirmo asistencia genere un registro nuevo en la tabla atleta por competencia
        If TxtNumeroAtleta.Text <> "0" Then
            Try
                AtletaSeleccionado.id_club_federacion = cboClub.SelectedValue
                AtletaSeleccionado.otra_institucion = txtinstitucion.Text
                AtletaSeleccionado.dorsal = TxtNumeroAtleta.Text ' dorsal=0
                AtletaSeleccionado.estado_atleta = txtEstadoAtleta.Text

                capanegocio.ActualizarAtleta(AtletaSeleccionado)
                LISTA_DE_ATLETAS.Close()

                'Agrego el atleta al formulario de acuerdo al tipo de competencia

                PlanillaDeCalle.AgregarRegistroAGrilla(AtletaSeleccionado)
                PLANILLADELANZAMIENTOS.AgregarRegistroAGrilla(AtletaSeleccionado)
                '  PlanillaSaltoenAltoyGarrocha.AgregarRegistroAGrilla(AtletaSeleccionado)
                PlanillaDeVelocidad.AgregarRegistroAGrilla(AtletaSeleccionado)
                PlanilladeMedioFondo.AgregarRegistroAGrilla(AtletaSeleccionado)
                PlanilladeFondoCargadeAtletas.AgregarRegistroAGrilla(AtletaSeleccionado)
                PlanilladeObstáculos.AgregarRegistroAGrilla(AtletaSeleccionado)
                PlanillaCrossCountry.AgregarRegistroAGrilla(AtletaSeleccionado)
                PlanillaMaraton.AgregarRegistroAGrilla(AtletaSeleccionado)
                PlanilladeMarcha.AgregarRegistroAGrilla(AtletaSeleccionado)
                PLANILLASALTOENLARGOYTRIPLE.AgregarRegistroAGrilla(AtletaSeleccionado)

                Me.Close()
            Catch ex As Exception
                MsgBox("Error al actualizar los datos del Atleta")
                LISTA_DE_ATLETAS.Close()
                MsgBox("No se pudo agregar al Atleta a la Competencia", MsgBoxStyle.Critical)
            End Try
        Else
            MessageBox.Show("El Número o Dorsal del atleta no puede ser 0")
        End If

    End Sub
End Class

