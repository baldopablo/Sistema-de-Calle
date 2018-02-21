Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class PlanillaFinalCalle

    Public Property Id_Competencia As Int32
    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Public Property TipoDeFormulario As TipoFormulario
    Dim capanegocio As New CNAtletas
    Dim capanegocio2 As New CNAtletas_x_Competencia

    Private Sub PlanillaFinalCalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub PrepararFormulario()
        Label3.Visible = False
        txtCodigoPlanillaCalle.Visible = False
        Label13.Visible = False
        cboUsuario.Visible = False
      
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        dtpfechainicio.Enabled = False
        cargarlista()
       
    End Sub

    'Private Sub cboSexo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSexo.SelectedIndexChanged
    '    If cboSexo.Text = "Femenino" Then
    '        cargaatletasfemenino()
    '    End If
    '    If cboSexo.Text = "Masculino" Then
    '        cargaatletasmasculino()
    '    End If

    'End Sub
    'DEBERIA HACER OTRA LISTA QUE CARGUE LOS ATLETAS DE LA COMPETENCIA, (CARGA BIEN EL FILTRO)
    Sub cargaatletasfemenino()
        Dim listadoDeAtletas As List(Of CEAtletas) = capanegocio.Lista_Atletas_FemeninoDTO()
        dgvAtletasdeCalle.DataSource = listadoDeAtletas

    End Sub
    'DEBERIA HACER OTRA LISTA QUE CARGUE LOS ATLETAS DE LA COMPETENCIA, (CARGA BIEN EL FILTRO)
    Sub cargaatletasmasculino()
        Dim listadoDeAtletas As List(Of CEAtletas) = capanegocio.Lista_Atletas_MasculinoDTO()
        dgvAtletasdeCalle.DataSource = listadoDeAtletas

    End Sub

    Sub cargarlista()
        dgvAtletasdeCalle.DataSource = capanegocio2.Planilla_Resultado_Final_Calle.Tables("Planilla_Resultado_Final_Calle")

        dgvAtletasdeCalle.Columns(1).HeaderText = "Dorsal"
        dgvAtletasdeCalle.Columns(2).HeaderText = "Nombre"
        dgvAtletasdeCalle.Columns(3).HeaderText = "Apellido"
        dgvAtletasdeCalle.Columns(4).HeaderText = "Edad"
        dgvAtletasdeCalle.Columns(5).HeaderText = "Localidad"
        dgvAtletasdeCalle.Columns(6).HeaderText = "Representa a:"
        dgvAtletasdeCalle.Columns(7).HeaderText = "Descripción"
        dgvAtletasdeCalle.Columns(8).HeaderText = "Mejor"
        dgvAtletasdeCalle.Columns(9).HeaderText = "Posición"

    End Sub

    Private Sub cboRango_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    'Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
    '    Select cboSexo.Text
    '        Case "Masculino"
    '            Select Case cboRango.Text
    '                Case "categoria 1"
    '                    cargaMC1(2)
    '                Case "categoria 2"
    '                    cargaMC2()
    '                Case "categoria 3"
    '                    cargaMC3()
    '                Case "Todos"
    '                    ' poner todos
    '            End Select
    '        Case "Femenino"
    '            Select Case cboRango.Text
    '                Case "categoria 1"
    '                    cargaFC1()
    '                Case "categoria 2"
    '                    cargaFC2()
    '                Case "categoria 3"
    '                    cargaFC3()
    '                Case "Todos"
    '                    ' poner todos
    '            End Select
    '        Case "Todos"
    '            Select Case cboRango.Text
    '                Case "categoria 1"
    '                    ' poner todos
    '                Case "categoria 2"
    '                    ' poner todos
    '                Case "categoria 3"
    '                    ' poner todos
    '                Case "Todos"
    '                    ' poner todos
    '            End Select
    '        Case Else
    '            MessageBox.Show("Debe ingresar algo")
    '    End Select

    '---------------------------------------------------------------------------------------------------
    '    Select Case cboRango.Text
    '        Case "categoria 1"
    '            cargaMC1(CInt(cboSexo.SelectedIndex + 1)) 'MOSTRAR ESTOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!
    '        Case "categoria 2"
    '            cargaMC2(CInt(cboSexo.SelectedIndex + 1), txtCodigoPlanillaCalle.Text) ' IDEAAAAAAA!!!!
    '        Case "categoria 3"
    '            cargaMC3(CInt(cboSexo.SelectedIndex + 1))
    '        Case "Todos"
    '' poner todos
    '    End Select


    'End Sub
    Sub cargaMC1(ByVal ID_SEXO As Integer)
        Dim listadofiltro As List(Of CEVista_a_x_c) = capanegocio.cargaMC1DTO(ID_SEXO)
        dgvAtletasdeCalle.DataSource = listadofiltro
    End Sub
    'Sub cargaMC2()
    '    Dim listadofiltro As List(Of CEVista_a_x_c) = capanegocio.cargaMC2DTO()
    '    dgvAtletasdeCalle.DataSource = listadofiltro
    'End Sub
    'Sub cargaMC3()
    '    Dim listadofiltro As List(Of CEVista_a_x_c) = capanegocio.cargaMC3DTO()
    '    dgvAtletasdeCalle.DataSource = listadofiltro
    'End Sub
    'Sub cargaFC1()
    '    Dim listadofiltro As List(Of CEVista_a_x_c) = capanegocio.cargaFC1DTO()
    '    dgvAtletasdeCalle.DataSource = listadofiltro
    'End Sub
    'Sub cargaFC2()
    '    Dim listadofiltro As List(Of CEVista_a_x_c) = capanegocio.cargaFC2DTO()
    '    dgvAtletasdeCalle.DataSource = listadofiltro
    'End Sub
    'Sub cargaFC3()
    '    Dim listadofiltro As List(Of CEVista_a_x_c) = capanegocio.cargaFC3DTO()
    '    dgvAtletasdeCalle.DataSource = listadofiltro
    'End Sub


    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click

        If rbtSexo.Checked = True And rbtRangoEdades.Checked = False Then
            frm_Final_Calle_Sexo.ShowDialog()
            'ElseIf rbtRangoEdades.Checked = True And rbtSexo.Checked = False Then
            '    'frm_Final_Calle_Rango_Edades.ShowDialog()

        ElseIf frm_Final_Calle.ShowDialog() Then
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class

'1.- En el Explorador de Campos ->
'2.- Campos Totales Acumulados ->
'3.- Crear un Nuevo Campo -> Poner un Nombre
'4.- En la Ventana de Edicion de Campo de Total Acumulado, Seleccionar el campo de grupo y pulsar el boton >, para agregar el campo en la Caja de Texto Resumir
'5.- En Tipo Resumen Elegir de la lista: Recuento.
'6.- En Evaluar: Seleccionar -> Para Cada Registro
'7.- En Reestablecer: Seleccionar -> Al Cambiar de Grupo -> si tienes mas de un grupo selecciona el grupo de donde quieres contra
'8.- Por ultimo pulsa Aceptar y Arrastra el campo creado a la seccion de Detalles en la vita Diseño.

'Espero y les Sea de Utilidad ....