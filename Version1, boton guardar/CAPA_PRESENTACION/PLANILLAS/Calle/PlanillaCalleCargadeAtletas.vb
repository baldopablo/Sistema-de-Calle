Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'PROCEDIMIENTO QUE CARGA EL DATAGRIDVIEW DE LOS ATLETAS SE LLAMA..
'-----------------------------LISTA_ATLETAS------------------------

'PROCEDIMIENTO QUE CARGA EL DATAGRIDVIEW DE LOS ATLETAS SE LLAMA..
'-----------------------------LISTA_ATLETAS------------------------

'PROCEDIMIENTO QUE CARGA EL DATAGRIDVIEW DE LOS ATLETAS SE LLAMA..
'-----------------------------LISTA_ATLETAS------------------------

Public Class PlanillaDeCalle

    Public Property Id_Competencia As Int32
    Dim capanegocio As New CNAtletas
    Dim capanegocio1 As New CNAtletas_x_Competencia
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
    Shared Property Atletas_x_Competencia_Calle As New CEAtletas_x_Competencia
    Public Property TipoDeFormulario As TipoFormulario

    'Public Sub New()
    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    'End Sub

    'Creo una sobrecarga del constructor para obligarlo siempre a pasar un codigo de competencia
    'POR AHORA ESTO NO LO VEMOS
    'Public Sub New(ByVal id_Competencia As Integer)
    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()
    '    If (id_Competencia <> 0) Then
    '        Me.Id_Competencia = id_Competencia
    '    End If
    '    ' llamo al método que me carga la pantalla
    '    CargarDatosFormulario()
    'End Sub

    Private Sub PLANILLACOMPETENCIACALLE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Sub CambiarColorFila()
        For i = 0 To dgvAtletasdeCalle.Rows.Count - 1
            If dgvAtletasdeCalle.Item(1, i).Value.ToString < 0 Then
                dgvAtletasdeCalle.Rows(i).Cells(1).Style.BackColor = Color.DarkRed
                dgvAtletasdeCalle.Rows(i).Cells(1).Style.ForeColor = Color.White
            End If
        Next
    End Sub

    Sub CambiarColorCelda()
        For Each row As DataGridViewRow In dgvAtletasdeCalle.Rows
            If row.Cells("Dorsal").Value <> 0 Then
                row.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    'POR AHORA ESTO NO LO VEMOS
    'Private Sub CargarDatosFormulario()
    '    Dim objcompetencia As New CNCompetencias

    '    Dim tablaCompetencia = objcompetencia.ListadoTodasCompetencias(Me.Id_Competencia)
    '    Me.txtNombre.Text = tablaCompetencia.Rows(0)("Nombre")
    '    'Me.txtLugar.Text = tablaCompetencia.Rows(1)("Lugar")
    '    'Me.cboLocalidad.Text = tablaCompetencia.Rows(2)("Localidad")
    '    'Me.cboProvincia.Text = tablaCompetencia.Rows(3)("Provincia")

    'End Sub

    'CARGA DE COMBO Y LOGICA DE BOTONES
    Private Sub PrepararFormulario()

        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        btnImprimir.Enabled = False
        btnIngresar.Enabled = False
        btnComenzar.Enabled = False
        btnCerrar.Enabled = False
        btnIngresar.Enabled = False
        cboUsuario.Visible = False
        cboProvincia.Enabled = False
        cboLocalidad.Enabled = False
        dtpfechainicio.Enabled = False
        Label13.Visible = False
        cboJuez1.Focus()
        juezprincipal1()
        juezprincipal2()
        juezprincipal3()
        Me.dgvAtletasdeCalle.Columns("Id_Atleta").Visible = False
        Me.dgvAtletasdeCalle.Columns("Id_Resultado_x_Competencia").Visible = False
        Label1.Visible = False
        txtCodigoPlanillaCalle.Visible = True
        btnActualizar.Enabled = False

        Select Case TipoDeFormulario
            Case TipoFormulario.Alta
                '  dgvAtletasdeCalle.DataSource = ""
                btnAgregarAtleta.Enabled = True
                btnQuitarAtleta.Enabled = True
                btnComenzar.Enabled = False
                btnGuardar.Enabled = True
                Nuevo_Codigo_Resultado_x_Atleta()
                Nuevo_Codigo_Atleta_x_Competencia()

            Case TipoFormulario.Modificacion
                btnAgregarAtleta.Enabled = True
                btnQuitarAtleta.Enabled = True
                btnComenzar.Enabled = False
                btnGuardar.Enabled = True
                ' prepararformularioParaLaModificacion()

            Case TipoFormulario.EditarLista

                btnAgregarAtleta.Enabled = True
                btnQuitarAtleta.Enabled = True
                btnGuardar.Enabled = False
                btnActualizar.Enabled = True
                btnCerrar.Enabled = True
                btnImprimir.Enabled = True
                ' prepararformularioParaLaModificacion()
        End Select
        '        dgvAtletasdeCalle.AutoSizeColumnsMode = _
        'DataGridViewAutoSizeColumnsMode.AllCells
        '        dgvAtletasdeCalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '        Dim cellStyle As New DataGridViewCellStyle
        '        cellStyle.Font = New Font _
        '            (dgvAtletasdeCalle.Font.Name, dgvAtletasdeCalle.Font.Size, FontStyle.Bold)
        '        Me.dgvAtletasdeCalle.ColumnHeadersDefaultCellStyle = cellStyle

    End Sub

    'Private Sub prepararformularioParaLaModificacion()
    '    ' dgvAtletasdeCalle.DataSource = Nothing
    '    Dim negocioCompetencia = New CAPA_NEGOCIO.CNCompetencias()
    '    Dim datosDeLaCompetencia = negocioCompetencia.ListaCompetenciaCalleDTO().First(Function(x) x.id_competencia = Me.Id_Competencia)
    '    cboJuez1.SelectedValue = datosDeLaCompetencia.juez1
    '    'cboJuez2.SelectedValue = datosDeLaCompetencia.juez2
    '    'cboJuez3.SelectedValue = datosDeLaCompetencia.juez3
    '    txtNombre.Text = datosDeLaCompetencia.Nombre_competencia
    '    txtLugar.Text = datosDeLaCompetencia.lugar_competencia
    '    cboProvincia.SelectedValue = datosDeLaCompetencia.id_provincia
    '    cboLocalidad.SelectedValue = datosDeLaCompetencia.id_localidad
    '    dtpfechainicio.Text = datosDeLaCompetencia.fecha_inicio
    '    txtDistanciaCompetenciaCalle.Text = datosDeLaCompetencia.distancia
    '    txtEstado.Text = datosDeLaCompetencia.Estado_Competencia


    '    'TODO: rellenar y luego cambiar los combos restantes
    '    Dim negocioAltetasPorCompetencia As New CNAtletas_x_Competencia()

    '    Dim tabla As DataTable = negocioAltetasPorCompetencia.Lista_Atletas(Me.Id_Competencia).Tables(0)
    '    Dim atleta As New CEAtletas()
    '    Dim resultado As New CEResultados_x_Competencia
    '    For Each row As DataRow In tabla.Rows

    '        atleta.dorsal = row("Dorsal")
    '        atleta.Nombre_atleta = row("Nombre_Atleta")
    '        atleta.Apellido_atleta = row("Apellido_Atleta")
    '        atleta.id_sexo = row("Id_Sexo")
    '        atleta.fecha_nacimiento = row("Fecha_Nacimiento")
    '        atleta.otra_institucion = row("Otra_Institución")
    '        atleta.id_club_federacion = row("Id_Club_Federación")
    '        atleta.id_atleta = row("Id_Atleta")
    '        resultado.id_resultado_x_competencia = row("Id_Resultados_X_Competencia")
    '        AgregarRegistroAGrilla(atleta)

    '    Next
    'End Sub

    ' BOTON COMENZAR DESACTIVA LOS BOTONES RELACIONADOS CON EL ATLETA Y ACTIVA LOS RELACIONADOS A CARGAR TIEMPOS Y GUARDAR FORMULARIOS

    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click

        If Me.dgvAtletasdeCalle.Rows.Count = 0 Then
            MessageBox.Show("Debe ingresar atletas para poder comenzar a registrar los Tiempos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        ' VALIDACION DE JUECES
        If cboJuez1.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Juez")
            cboJuez1.Focus()
            Return
        End If
        If cboJuez2.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Juez")
            cboJuez2.Focus()
            Return
        End If
        If cboJuez3.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Juez")
            cboJuez3.Focus()
            Return
        End If
        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        btnCerrar.Enabled = True
        btnImprimir.Enabled = True
        btnIngresar.Enabled = True
        btnIngresar.Enabled = True
    End Sub

    Private Sub btnFinalizarCompetencia_Click(sender As System.Object, e As System.EventArgs)
        btnAgregarAtleta.Enabled = False
        btnQuitarAtleta.Enabled = False
        btnComenzar.Enabled = False
        btnImprimir.Enabled = True
        btnCerrar.Enabled = True
        btnIngresar.Enabled = False
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim otra As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        Dim sexo As String = cNegVarios.NombreSexoPorId(atleta.id_sexo)

        PlanillaDeCalle.dgvAtletasdeCalle.Rows.Add(atleta.dorsal,
                                                     atleta.Nombre_atleta, _
                                                     atleta.Apellido_atleta, _
                                                     sexo, _
                                                     atleta.Edad, _
                                                     atleta.otra_institucion, _
                                                     atleta.id_atleta)
    End Sub

    Private Sub btnAgregarAtleta_Click_1(sender As System.Object, e As System.EventArgs) Handles btnAgregarAtleta.Click
        LISTA_DE_ATLETAS.TipoDeFormulario = TipoFormulario.AgregarAtleta
        LISTA_DE_ATLETAS.ShowDialog()
    End Sub

    Private Sub btnIngresar_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresar.Click
        RellenarCampos()
    End Sub

    Private Sub RellenarCampos()
        IngresodeTiemposdeCalle.txtEstado.Text = "En Curso"
        IngresodeTiemposdeCalle.txtCodigoPlanillaCalle.Text = Me.txtCodigoPlanillaCalle.Text
        IngresodeTiemposdeCalle.txtResultado_x_Atleta.Text = Me.txtResultado_x_Atleta.Text
        IngresodeTiemposdeCalle.txtResultado_x_Competencia.Text = Me.txtResultado_x_Competencia.Text
        IngresodeTiemposdeCalle.txtCodigoPlanillaCalle.Text = Me.txtCodigoPlanillaCalle.Text
        IngresodeTiemposdeCalle.txtNombre.Text = Me.txtNombre.Text
        IngresodeTiemposdeCalle.txtLugar.Text = Me.txtLugar.Text
        IngresodeTiemposdeCalle.txtDistanciaCompetenciaCalle.Text = Me.txtDistanciaCompetenciaCalle.Text
        IngresodeTiemposdeCalle.dtpfechainicio.Text = Me.dtpfechainicio.Text
        IngresodeTiemposdeCalle.txtHora.Text = Me.txtHora.Text
        IngresodeTiemposdeCalle.cboProvincia.Text = Me.cboProvincia.Text
        IngresodeTiemposdeCalle.cboLocalidad.Text = Me.cboLocalidad.Text
        IngresodeTiemposdeCalle.cboJuez1.Text = Me.cboJuez1.Text
        IngresodeTiemposdeCalle.cboJuez2.Text = Me.cboJuez2.Text
        IngresodeTiemposdeCalle.cboJuez3.Text = Me.cboJuez3.Text
        IngresodeTiemposdeCalle.cboUsuario.Text = Me.cboUsuario.Text
        IngresodeTiemposdeCalle.txtAtleta_x_Competencia.Text = Me.txtAtleta_x_Competencia.Text
        IngresodeTiemposdeCalle.ShowDialog()
    End Sub

    Private Sub btnQuitarAtleta_Click_1(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click

        If dgvAtletasdeCalle.Rows.Count <> 0 Then
            dgvAtletasdeCalle.Rows.RemoveAt(dgvAtletasdeCalle.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        ' valida que haya registros para poder guardarlos
        If Me.dgvAtletasdeCalle.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
        Dim objeto As New CEAtletas_x_Competencia
        Dim objeto1 As New CEResultados_x_Atleta
        Dim objeto2 As New CEResultados_x_Competencia
        Try
            For Each rows As DataGridViewRow In Me.dgvAtletasdeCalle.Rows
                ' LO QUE SE VA A GUARDAR EN LA TABLA RESULTADO POR COMPETENCIA
                objeto2.id_atleta = rows.Cells(6).Value
                objeto2.id_competencia = txtCodigoPlanillaCalle.Text
                objeto2.serie = txtSerie.Text
                objeto2.valor = txtValor.Text
                objeto2.descripcion = txtDescripcion.Text
                objeto2.mejor = txtMejor.Text
                objeto2.posicion = txtPosicion.Text
                objeto2.dorsal = rows.Cells(0).Value
                objeto2.id_juez = cboJuez1.SelectedValue

                capanegocio6.Nuevo_Resultado_x_Competencia(objeto2)
                rows.Cells(7).Value = Nuevo_Codigo_Resultado_x_Competencia()

                ' LO QUE SE VA A GUARDAR EN LA TABLA ATLETAS POR COMPETENCIA
                objeto.id_competencia = txtCodigoPlanillaCalle.Text
                objeto.id_atleta = rows.Cells(6).Value
                'objeto.id_resultado_atleta = txtResultado_x_Atleta.Text
                objeto.id_resultado_atleta = 1
                objeto.id_resultado_competencia = rows.Cells(7).Value

                ' LO QUE SE VA A GUARDAR EN LA TABLA RESULTADO POR ATLETA nooooooo iiriaaaaaaa
                objeto1.id_resultado_x_atleta = txtResultado_x_Atleta.Text
                objeto1.id_competencia = txtCodigoPlanillaCalle.Text
                objeto1.id_atleta = rows.Cells(6).Value

                objeto1.serie = txtSerie.Text
                objeto1.descripcion = txtDescripcion.Text
                objeto1.valor1 = txtValor.Text
                objeto1.mejor = txtMejor.Text

                capanegocio4.Nuevo_Atleta_x_Competencia(objeto)
            Next
            MessageBox.Show("Se guardado correctamente la lista de atletas", "Guardando Lista de Atletas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Nuevo_Codigo_Resultado_x_Atleta()
            Nuevo_Codigo_Resultado_x_Competencia()
            Nuevo_Codigo_Atleta_x_Competencia()
        Catch ex As Exception
            MsgBox("No se pudo guardar la lista de atletas", MsgBoxStyle.Critical)
        End Try
        btnGuardar.Enabled = False
        btnComenzar.Enabled = True
        btnImprimir.Enabled = True
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

    Sub Nuevo_Codigo_Resultado_x_Atleta()
        txtResultado_x_Atleta.Text = capanegocio5.Nuevo_Codigo_Resultado_x_Atleta
    End Sub

    Function Nuevo_Codigo_Resultado_x_Competencia()
        Return capanegocio6.Nuevo_Codigo_Resultado_x_Competencia()
    End Function

    Sub Nuevo_Codigo_Atleta_x_Competencia()
        txtAtleta_x_Competencia.Text = capanegocio4.Nuevo_Codigo_Atleta_x_Competencia
    End Sub

    Private Sub RellenarCampos_Atletas_x_Competencia_Calle()
        txtCodigoPlanillaCalle.Text = Atletas_x_Competencia_Calle.id_competencia
        txtNombre.Text = Atletas_x_Competencia_Calle.Nombre_competencia
        txtLugar.Text = Atletas_x_Competencia_Calle.lugar_competencia
        txtDistanciaCompetenciaCalle.Text = Atletas_x_Competencia_Calle.distancia
        dtpfechainicio.Text = Atletas_x_Competencia_Calle.fecha_inicio
        txtHora.Text = Atletas_x_Competencia_Calle.hora_inicio
        cboProvincia.Text = Atletas_x_Competencia_Calle.nombre_provincia
        cboLocalidad.Text = Atletas_x_Competencia_Calle.nombre_localidad
        txtEstado.Text = Atletas_x_Competencia_Calle.Estado_Competencia
        cboJuez1.Text = Atletas_x_Competencia_Calle.Apellido_Juez1
        cboJuez2.Text = Atletas_x_Competencia_Calle.Apellido_Juez2
        cboJuez3.Text = Atletas_x_Competencia_Calle.Apellido_Juez3
        cboUsuario.SelectedValue = Atletas_x_Competencia_Calle.id_usuario
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Calle.ShowDialog()

        'If dgvAtletasdeCalle.Rows.Count <> 0 Then
        '    'Dim Dt As New DataTable
        '    'Dt = Me.dgvAtletasdeCalle.DataSource
        '    Dim Dt As DataTable = CType(Me.dgvAtletasdeCalle.DataSource, DataTable)
        '    Dim Cr As New Cr_Calle
        '    Cr.SetDataSource(Dt)

        '    Dim R As New frm_Cr_Calle
        '    R.CrystalReportViewer1.ReportSource = Cr
        '    R.ShowDialog()

        'End If

        'Dim MyDataSet As New DataSet 'Conjunto de datos
        'Dim Dt As New DataTable 'EL dataTable del conjunto de datos
        'Dim mi_rptSocios As New Cr_Calle 'Documento cristal reports
        ''Dim miReporte As New Form7 'Formulario visor
        'If dgvAtletasdeCalle.Rows.Count <> 0 Then
        '    Dim filas As Integer = Me.dgvAtletasdeCalle.Rows.Count
        '    Dim i As Integer = 0
        '    For i = 0 To filas - 1
        '        'Paso los datos al dataset el "DataGridViewTextBoxColumn" se encuentra dentro de
        '        ' la propiedad Columns(coleccion)>Diseño>Name
        '        Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Dorsal").Value)
        '        Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Nombre").Value)
        '        'Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Apellido").Value)
        '        'Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Sexo").Value)
        '        'Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Edad").Value)
        '        'Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Institución").Value)
        '        'Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Id_Atleta").Value)
        '        'Dt.Rows.Add(Me.dgvAtletasdeCalle.Rows(i).Cells("Id_Resultado_x_Competencia").Value)

        '    Next (i)
        'End If
        '"Cliente" es la tabla en el dataset
        'MyDataSet.Tables("DataTable1").Merge(Dt)
        'mi_rptSocios.SetDataSource(MyDataSet)
        'frm_Cr_Calle.CrystalReportViewer1.ReportSource = mi_rptSocios
        'frm_Cr_Calle.Show()
    End Sub


    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

End Class
