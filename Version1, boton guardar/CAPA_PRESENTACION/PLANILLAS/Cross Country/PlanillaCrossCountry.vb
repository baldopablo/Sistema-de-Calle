Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanillaCrossCountry

    Public Property Id_Competencia As Int32
    Dim capanegocio As New CNAtletas
    Dim capanegocio2 As New CNCompetencias
    Dim capanegocio3 As New CNResultadoParcial
    Dim capanegocio4 As New CNAtletas_x_Competencia
    Dim capanegocio5 As New CNResultados_x_Atleta
    Dim capanegocio6 As New CNResultados_x_Competencia

    Shared Property AtletaSeleccionado As New CEAtletas
    Shared Property CompetenciaSeleccionada As New CECompetencias
    Shared Property Resultado_x_Atleta As New CEResultados_x_Atleta
    Shared Property Resultado_x_Competencia As New CEResultados_x_Competencia
    Shared Property ResultadoSeleccionado As New CeResultadoParcial

    Shared Property AtletaxCompetenciaSeleccionada As New CEAtletas_x_Competencia

    Public Property TipoDeFormulario As TipoFormulario

    Private Sub btnGuardarCompetencia_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardarCompetencia.Click

        If Me.dgvAtletasdeCrossCountry.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If

        Dim objeto As New CEAtletas_x_Competencia
        Dim objeto1 As New CEResultados_x_Atleta
        Dim objeto2 As New CEResultados_x_Competencia

        Try
            For Each rows As DataGridViewRow In Me.dgvAtletasdeCrossCountry.Rows

                'LO QUE SE VA A GUARDAR EN LA TABLA RESULTADO POR COMPETENCIA
                objeto2.id_atleta = rows.Cells(4).Value
                objeto2.id_resultado_x_competencia = rows.Cells(5).Value
                objeto2.id_competencia = txtCodigoPlanillaCrossCountry.Text
                objeto2.serie = txtSerie.Text
                objeto2.valor = txtValor.Text
                objeto2.descripcion = txtDescripcion.Text
                objeto2.mejor = txtMejor.Text
                objeto2.posicion = txtPosicion.Text

                capanegocio6.Nuevo_Resultado_x_Competencia(objeto2)

                ' genera un nuevo codigo de resultado por competencia
                rows.Cells(5).Value = Nuevo_Codigo_Resultado_x_Competencia()

                ' LO QUE SE VA A GUARDAR EN LA TABLA ATLETAS POR COMPETENCIA
                objeto.id_competencia = txtCodigoPlanillaCrossCountry.Text
                objeto.id_atleta = rows.Cells(4).Value
                objeto.id_resultado_atleta = 1
                objeto.id_resultado_competencia = rows.Cells(5).Value
                objeto.Id_atleta_x_competencia = txtAtleta_x_Competencia.Text

                capanegocio4.Nuevo_Atleta_x_Competencia(objeto)

            Next
            MsgBox("Se guardado correctamente la lista de atletas")
            Nuevo_Codigo_Resultado_x_Atleta()
            Nuevo_Codigo_Resultado_x_Competencia()
            Nuevo_Codigo_Atleta_x_Competencia()
        Catch ex As Exception
            MsgBox("No se pudo guardar la lista de atletas", MsgBoxStyle.Critical)
        End Try
        btnComenzar.Enabled = True
        btnGuardarCompetencia.Enabled = False
        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        btnCerrar.Enabled = True
        cboSexo.Enabled = False
        cboCategoria.Enabled = False
        cboJuez1.Enabled = False
        cboJuez2.Enabled = False
        cboJuez3.Enabled = False
        btnImprimir.Enabled = True
    End Sub

    Sub Nuevo_Codigo_Resultado_x_Atleta()
        txtResultado_x_Atleta.Text = capanegocio5.Nuevo_Codigo_Resultado_x_Atleta
    End Sub

    Function Nuevo_Codigo_Resultado_x_Competencia()
        Return capanegocio6.Nuevo_Codigo_Resultado_x_Competencia()
    End Function

    Sub Nuevo_Codigo_Atleta_x_Competencia()
        txtAtleta_x_Competencia.Text = capanegocio4.Nuevo_Codigo_Atleta_x_Competencia
    End Sub
    Private Sub PlanillaCrossCountry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

    End Sub

    Private Sub btnAgregarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarAtleta.Click

        'VALIDA QUE SE SELECCIONE SEXO Y CATEGORIA
        If cboSexo.Text = "--Seleccionar--" And cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Sexo y una Categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboSexo.Focus()
            Return
        End If

        'VALIDA QUE SE SELECCIONE SEXO
        If cboSexo.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Sexo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboSexo.Focus()
            Return
        End If

        'VALIDA QUE SE SELECCIONE CATEGORIA
        If cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar una Categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboCategoria.Focus()
            Return
        End If

        LISTA_DE_ATLETAS.TipoDeFormulario = TipoFormulario.DatosAdicionalesDelAtleta
        LISTA_DE_ATLETAS.ShowDialog()

        'cboCategoria.Enabled = False
        'cboSexo.Enabled = False
    End Sub

   

    Private Sub btnQuitarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click
        If dgvAtletasdeCrossCountry.Rows.Count <> 0 Then
            dgvAtletasdeCrossCountry.Rows.RemoveAt(dgvAtletasdeCrossCountry.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click
        If Me.dgvAtletasdeCrossCountry.Rows.Count = 0 Then
            MessageBox.Show("Debe ingresar atletas para poder comenzar a registrar los Tiempos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        ' VALIDACION DE JUECES
        If cboJuez1.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Juez")
            cboJuez1.Focus()
            Return
        End If

        If cboJuez2.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Juez")
            cboJuez2.Focus()
            Return
        End If

        If cboJuez3.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Juez")
            cboJuez3.Focus()
            Return
        End If

        If cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione una Categoría")
            cboCategoria.Focus()
            Return
        End If

        If cboSexo.Text = "--Seleccionar--" Then
            MessageBox.Show("seleccione un Sexo")
            cboSexo.Focus()
            Return
        End If

        btnCerrar.Enabled = True
        btnImprimir.Enabled = True
        btnActualizar.Enabled = False
        btnIngresarTiempos.Enabled = True
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnIngresar_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresarTiempos.Click
        RellenarCampos()
    End Sub

    Private Sub RellenarCampos()
        IngresodeTiemposCrossCountry.txtEstado.Text = "En Curso"
        IngresodeTiemposCrossCountry.txtCodigoPlanillaCrossCountry.Text = Me.txtCodigoPlanillaCrossCountry.Text
        IngresodeTiemposCrossCountry.txtNombre.Text = Me.txtNombre.Text
        IngresodeTiemposCrossCountry.txtLugar.Text = Me.txtLugar.Text
        IngresodeTiemposCrossCountry.cboProvincia.Text = Me.cboProvincia.Text
        IngresodeTiemposCrossCountry.cboLocalidad.Text = Me.cboLocalidad.Text
        IngresodeTiemposCrossCountry.dtpfechainicio.Text = Me.dtpfechainicio.Text
        IngresodeTiemposCrossCountry.txtHora.Text = Me.txtHora.Text
        IngresodeTiemposCrossCountry.txtEstado.Text = Me.txtEstado.Text
        IngresodeTiemposCrossCountry.cboJuez1.Text = Me.cboJuez1.Text
        IngresodeTiemposCrossCountry.cboJuez2.Text = Me.cboJuez2.Text
        IngresodeTiemposCrossCountry.cboJuez3.Text = Me.cboJuez3.Text
        IngresodeTiemposCrossCountry.cboUsuario.Text = Me.cboUsuario.Text
        IngresodeTiemposCrossCountry.cboPrueba.Text = Me.cboPrueba.Text
        IngresodeTiemposCrossCountry.cboSexo.Text = Me.cboSexo.Text
        IngresodeTiemposCrossCountry.cboCategoria.Text = Me.cboCategoria.Text
        IngresodeTiemposCrossCountry.txtResultado_x_Atleta.Text = Me.txtResultado_x_Atleta.Text
        IngresodeTiemposCrossCountry.txtResultado_x_Competencia.Text = Me.txtResultado_x_Competencia.Text
        IngresodeTiemposCrossCountry.txtAtleta_x_Competencia.Text = Me.txtAtleta_x_Competencia.Text

        IngresodeTiemposCrossCountry.ShowDialog()
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PlanillaCrossCountry.dgvAtletasdeCrossCountry.Rows.Add(atleta.dorsal,
                                                          atleta.Nombre_atleta, _
                                                          atleta.Apellido_atleta, _
                                                          clubNombre, _
                                                          atleta.id_atleta)
    End Sub

    Sub PrepararFormulario()
        Label1.Visible = False
        Label13.Visible = False
        txtCodigoPlanillaCrossCountry.Visible = False
        cboUsuario.Visible = False
        btnAgregarAtleta.Enabled = True
        btnQuitarAtleta.Enabled = True
        btnCerrar.Enabled = True
        btnImprimir.Enabled = False
        btnComenzar.Enabled = False
        btnIngresarTiempos.Enabled = False
        btnActualizar.Enabled = False
        btnGuardarCompetencia.Enabled = True
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        cboPrueba.Enabled = False
        dtpfechainicio.Enabled = False
        Me.dgvAtletasdeCrossCountry.Columns("Id_Atleta").Visible = True
        'Me.dgvAtletasdeCrossCountry.Columns("Id_Resultado_Parcial").Visible = False
        cboCategoria.SelectedIndex = 0
        cboSexo.SelectedIndex = 0
        juezprincipal1()
        juezprincipal2()
        juezprincipal3()

        Nuevo_Codigo_Resultado_x_Atleta()
        ' Nuevo_Codigo_Resultado_x_Competencia()
        Nuevo_Codigo_Atleta_x_Competencia()
        'cargaatletas()
    End Sub

    Sub cargaatletas()
        Dim listadoDeAtletas As List(Of CEAtletas) = capanegocio.ListadoDeAtletasDTO()
        LISTA_DE_ATLETAS.dgvlistaatletas.DataSource = listadoDeAtletas
        LISTA_DE_ATLETAS.lbltotalatletas.Text = listadoDeAtletas.Count
    End Sub

    Sub juezprincipal1()
        'TODO: Hacer lo mismo en todos los combos que lleven seleccionar
        Dim miVista As DataView = capanegocio2.JuezPrincipal1.Tables("Apellido de Jueces").DefaultView
        miVista.Sort = "Nombre_Juez"
        Dim sortedDT As DataTable = miVista.ToTable()
        cboJuez1.DataSource = sortedDT
        cboJuez1.DisplayMember = "Apellido_Juez"
        cboJuez1.ValueMember = "Id_Juez"
        '--Seleccionar--
        'dejo seleccionado el "seleccionar" por defecto
        cboJuez1.SelectedIndex = 0
    End Sub

    Sub juezprincipal2()
        Dim miVista As DataView = capanegocio2.JuezPrincipal2.Tables("Apellido de Jueces").DefaultView
        miVista.Sort = "Nombre_Juez"
        Dim sortedDT As DataTable = miVista.ToTable()
        cboJuez2.DataSource = sortedDT
        cboJuez2.DisplayMember = "Apellido_Juez"
        cboJuez2.ValueMember = "Id_Juez"
        '--Seleccionar--
        'dejo seleccionado el "seleccionar" por defecto
        cboJuez2.SelectedIndex = 0
    End Sub

    Sub juezprincipal3()
        Dim miVista As DataView = capanegocio2.JuezPrincipal3.Tables("Apellido de Jueces").DefaultView
        miVista.Sort = "Nombre_Juez"
        Dim sortedDT As DataTable = miVista.ToTable()
        cboJuez3.DataSource = sortedDT
        cboJuez3.DisplayMember = "Apellido_Juez"
        cboJuez3.ValueMember = "Id_Juez"
        '--Seleccionar--
        'dejo seleccionado el "seleccionar" por defecto
        cboJuez3.SelectedIndex = 0
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Cross_Contry.ShowDialog()
    End Sub

    Private Sub cboSexo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSexo.SelectedIndexChanged
        Dim textoSeleccionadoSexo As String = cboSexo.Text
        Select Case textoSeleccionadoSexo
            Case "Femenino"
            Case "Masculino"
        End Select
    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
        If cboCategoria.Text = "Pre-Infantiles" Then
            cargaatletasPorEdad(0, 10)
        ElseIf cboCategoria.Text = "Infantiles" Then
            cargaatletasPorEdad(11, 12)
        ElseIf cboCategoria.Text = "Cadetes" Then
            cargaatletasPorEdad(13, 14)
        ElseIf cboCategoria.Text = "Menores" Then
            cargaatletasPorEdad(15, 17)
        ElseIf cboCategoria.Text = "Juveniles" Then
            cargaatletasPorEdad(18, 19)
        ElseIf cboCategoria.Text = "Mayores" Then
            cargaatletasPorEdad(20, 100)
        End If
       
    End Sub

    Private Sub cargaatletasPorEdad(p1 As Int32, p2 As Int32)
        Dim listadoDeAtletas As List(Of CEAtletas) = capanegocio.ListadoDeAtletasDTO().Where(Function(a) a.Edad >= p1 AndAlso a.Edad <= p2).ToList()
        LISTA_DE_ATLETAS.dgvlistaatletas.DataSource = listadoDeAtletas
        LISTA_DE_ATLETAS.lbltotalatletas.Text = listadoDeAtletas.Count
    End Sub

End Class