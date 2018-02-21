

Imports System.Data
Imports System.Data.SqlClient
Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Linq

Public Class LISTA_DE_ATLETAS
    Dim capanegocio As New CNAtletas

    Public Property TipoDeFormulario As TipoFormulario
     
    ''' SE EJECUTA AL CARGARSE EL FORMULARIO
    ''' PONER AQUI TODA LA LOGICA DE "RELLENO" DE CAMPOS
    ''' BOTONERÍA, ETC
    ''' 
    Sub CargaMasculinoMayores()
        Dim ListadoMasculinoMayores As List(Of CEAtletas) = capanegocio.FILTRO_MASCULINO_MAYORES_DTO
        Me.dgvlistaatletas.DataSource = ListadoMasculinoMayores
        Me.lbltotalatletas.Text = ListadoMasculinoMayores.Count
    End Sub

    Sub CargaMasculinoJuveniles()
        Dim ListadoMasculinoJuveniles As List(Of CEAtletas) = capanegocio.FILTRO_MASCULINO_JUVENILES_DTO
        Me.dgvlistaatletas.DataSource = ListadoMasculinoJuveniles
        Me.lbltotalatletas.Text = ListadoMasculinoJuveniles.Count
    End Sub

    Sub CargaMasculinoMenores()
        Dim ListadoMasculinoMenores As List(Of CEAtletas) = capanegocio.FILTRO_MASCULINO_MENORES_DTO
        Me.dgvlistaatletas.DataSource = ListadoMasculinoMenores
        Me.lbltotalatletas.Text = ListadoMasculinoMenores.Count
    End Sub

    Sub CargaMasculinoCadete()
        Dim ListadoMasculinoCadete As List(Of CEAtletas) = capanegocio.FILTRO_MASCULINO_CADETES_DTO
        Me.dgvlistaatletas.DataSource = ListadoMasculinoCadete
        Me.lbltotalatletas.Text = ListadoMasculinoCadete.Count
    End Sub

    Sub CargaMasculinoInfantil()
        Dim ListadoMasculinoInfantil As List(Of CEAtletas) = capanegocio.FILTRO_MASCULINO_INFANTILES_DTO
        Me.dgvlistaatletas.DataSource = ListadoMasculinoInfantil
        Me.lbltotalatletas.Text = ListadoMasculinoInfantil.Count
    End Sub

    Sub CargaMasculinoPreinfantil()
        Dim ListadoMasculinoPreinfantil As List(Of CEAtletas) = capanegocio.FILTRO_MASCULINO_PRE_INFANTILES_DTO
        Me.dgvlistaatletas.DataSource = ListadoMasculinoPreinfantil
        Me.lbltotalatletas.Text = ListadoMasculinoPreinfantil.Count
    End Sub

    Sub CargaFemeninoMayores()
        Dim ListadoFemeninoMayores As List(Of CEAtletas) = capanegocio.FILTRO_FEMENINO_MAYORES_DTO
        Me.dgvlistaatletas.DataSource = ListadoFemeninoMayores
        Me.lbltotalatletas.Text = ListadoFemeninoMayores.Count
    End Sub

    ' filtro femenino juveniles
    Sub CargaFemeninoJuveniles()
        Dim ListadoFemeninoJuveniles As List(Of CEAtletas) = capanegocio.FILTRO_FEMENINO_JUVENILES_DTO
        Me.dgvlistaatletas.DataSource = ListadoFemeninoJuveniles
        Me.lbltotalatletas.Text = ListadoFemeninoJuveniles.Count
    End Sub

    ' filtro femenino menores
    Sub CargaFemeninoMenores()
        Dim ListadoFemeninoMenores As List(Of CEAtletas) = capanegocio.FILTRO_FEMENINO_MENORES_DTO
        Me.dgvlistaatletas.DataSource = ListadoFemeninoMenores
        Me.lbltotalatletas.Text = ListadoFemeninoMenores.Count
    End Sub

    ' filtro femenino cadetes
    Sub CargaFemeninoCadetes()
        Dim ListadoFemeninoCadetes As List(Of CEAtletas) = capanegocio.FILTRO_FEMENINO_CADETES_DTO
        Me.dgvlistaatletas.DataSource = ListadoFemeninoCadetes
        Me.lbltotalatletas.Text = ListadoFemeninoCadetes.Count
    End Sub

    ' filtro femenino infantiles
    Sub CargaFemeninoinfantiles()
        Dim ListadoFemeninoInfantiles As List(Of CEAtletas) = capanegocio.FILTRO_FEMENINO_INFANTILES_DTO
        Me.dgvlistaatletas.DataSource = ListadoFemeninoInfantiles
        Me.lbltotalatletas.Text = ListadoFemeninoInfantiles.Count
    End Sub

    ' filtro femenino infantiles
    Sub CargaFemeninoPreInfantiles()
        Dim ListadoFemeninoPreInfantiles As List(Of CEAtletas) = capanegocio.FILTRO_FEMENINO_PRE_INFANTILES_DTO
        Me.dgvlistaatletas.DataSource = ListadoFemeninoPreInfantiles
        Me.lbltotalatletas.Text = ListadoFemeninoPreInfantiles.Count
    End Sub

    Private Sub PrepararFormulario()
        'Logica de los botones
        btnModificar.Enabled = False
        btnAgregarACompetencia.Enabled = False
        btnEliminar.Enabled = False
        btnCerrar.Enabled = True
        btnImprimir.Enabled = False
        GroupBox1.Enabled = True
        btnAgregarNuevo.Enabled = False
        'FILTRO FEMENINO DE PLANILLA CROSS COUNTRY
        If PlanillaCrossCountry.cboCategoria.Text = "Mayores" And PlanillaCrossCountry.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Menores" And PlanillaCrossCountry.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Cadetes" And PlanillaCrossCountry.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Juveniles" And PlanillaCrossCountry.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Infantiles" And PlanillaCrossCountry.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Pre-Infantiles" And PlanillaCrossCountry.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES

            'FILTRO MASCULINO DE PLANILLA CROSS COUNTRY
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Menores" And PlanillaCrossCountry.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Mayores" And PlanillaCrossCountry.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Cadetes" And PlanillaCrossCountry.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Juveniles" And PlanillaCrossCountry.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Infantiles" And PlanillaCrossCountry.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PlanillaCrossCountry.cboCategoria.Text = "Pre-Infantiles" And PlanillaCrossCountry.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES


            'FILTRO FEMENINO DE PLANILLA MARCHA
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Mayores" And PlanilladeMarcha.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Menores" And PlanilladeMarcha.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Cadetes" And PlanilladeMarcha.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Juveniles" And PlanilladeMarcha.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Infantiles" And PlanilladeMarcha.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Pre-Infantiles" And PlanilladeMarcha.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES

            'FILTRO MASCULINO DE PLANILLA MARCHA
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Menores" And PlanilladeMarcha.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Mayores" And PlanilladeMarcha.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Cadetes" And PlanilladeMarcha.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Juveniles" And PlanilladeMarcha.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Infantiles" And PlanilladeMarcha.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PlanilladeMarcha.cboCategoria.Text = "Pre-Infantiles" And PlanilladeMarcha.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES


            'FILTRO FEMENINO DE PLANILLA MARATON
        ElseIf PlanillaMaraton.cboCategoria.Text = "Mayores" And PlanillaMaraton.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PlanillaMaraton.cboCategoria.Text = "Menores" And PlanillaMaraton.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Cadetes" And PlanillaMaraton.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Juveniles" And PlanillaMaraton.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Infantiles" And PlanillaMaraton.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Pre-Infantiles" And PlanillaMaraton.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES

            'FILTRO MASCULINO DE PLANILLA MARATON
        ElseIf PlanillaMaraton.cboCategoria.Text = "Menores" And PlanillaMaraton.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Mayores" And PlanillaMaraton.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Cadetes" And PlanillaMaraton.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Juveniles" And PlanillaMaraton.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Infantiles" And PlanillaMaraton.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PlanillaMaraton.cboCategoria.Text = "Pre-Infantiles" And PlanillaMaraton.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES


            'FILTRO FEMENINO DE PLANILLA FONDO
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Mayores" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Menores" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Cadetes" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Juveniles" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Infantiles" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Pre-Infantiles" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES

            'FILTRO MASCULINO DE PLANILLA FONDO
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Menores" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Mayores" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Cadetes" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Juveniles" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Infantiles" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PlanilladeFondoCargadeAtletas.cboCategoria.Text = "Pre-Infantiles" And PlanilladeFondoCargadeAtletas.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES


            'FILTRO FEMENINO DE PLANILLA LANZAMIENTOS
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Mayores" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Menores" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Cadetes" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Juveniles" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Infantiles" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Pre-Infantiles" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES

            'FILTRO MASCULINO DE PLANILLA LANZAMIENTOS
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Menores" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Mayores" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Cadetes" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Juveniles" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Infantiles" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PLANILLADELANZAMIENTOS.cboCategoria.Text = "Pre-Infantiles" And PLANILLADELANZAMIENTOS.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES


            'FILTRO FEMENINO DE PLANILLA MEDIO FONDO
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Mayores" And PlanilladeMedioFondo.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Menores" And PlanilladeMedioFondo.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Cadetes" And PlanilladeMedioFondo.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Juveniles" And PlanilladeMedioFondo.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Infantiles" And PlanilladeMedioFondo.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Pre-Infantiles" And PlanilladeMedioFondo.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES

            'FILTRO MASCULINO DE PLANILLA MEDIO FONDO
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Menores" And PlanilladeMedioFondo.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Mayores" And PlanilladeMedioFondo.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Cadetes" And PlanilladeMedioFondo.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Juveniles" And PlanilladeMedioFondo.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Infantiles" And PlanilladeMedioFondo.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PlanilladeMedioFondo.cboCategoria.Text = "Pre-Infantiles" And PlanilladeMedioFondo.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES


            'FILTRO FEMENINO DE PLANILLA OBSTACULOS
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Mayores" And PlanilladeObstáculos.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Menores" And PlanilladeObstáculos.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Cadetes" And PlanilladeObstáculos.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Juveniles" And PlanilladeObstáculos.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Infantiles" And PlanilladeObstáculos.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Pre-Infantiles" And PlanilladeObstáculos.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES

            'FILTRO MASCULINO DE PLANILLA OBSTACULOS
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Menores" And PlanilladeObstáculos.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Mayores" And PlanilladeObstáculos.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Cadetes" And PlanilladeObstáculos.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Juveniles" And PlanilladeObstáculos.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Infantiles" And PlanilladeObstáculos.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PlanilladeObstáculos.cboCategoria.Text = "Pre-Infantiles" And PlanilladeObstáculos.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES



            'FILTRO FEMENINO DE PLANILLA SALTO LARGO Y TRIPLE
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Mayores" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Menores" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Cadetes" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Juveniles" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Infantiles" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Pre-Infantiles" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES


            'FILTRO MASCULINO DE PLANILLA SALTO LARGO Y TRIPLE
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Menores" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Mayores" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Cadetes" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Juveniles" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Infantiles" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PLANILLASALTOENLARGOYTRIPLE.cboCategoria.Text = "Pre-Infantiles" And PLANILLASALTOENLARGOYTRIPLE.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES


            'FILTRO FEMENINO DE PLANILLA SALTO VELOCIDAD
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Mayores" And PlanillaDeVelocidad.cboSexo.Text = "Masculino" Then
            CargaMasculinoMayores()
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Menores" And PlanillaDeVelocidad.cboSexo.Text = "Masculino" Then
            CargaMasculinoMenores() ' CARGA MASCULINOS MENORES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Cadetes" And PlanillaDeVelocidad.cboSexo.Text = "Masculino" Then
            CargaMasculinoCadete() ' CARGA MASCULINOS CADETES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Juveniles" And PlanillaDeVelocidad.cboSexo.Text = "Masculino" Then
            CargaMasculinoJuveniles() ' CARGA MASCULINOS JUVENILES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Infantiles" And PlanillaDeVelocidad.cboSexo.Text = "Masculino" Then
            CargaMasculinoInfantil() ' CARGA MASCULINOS INFANTILES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Pre-Infantiles" And PlanillaDeVelocidad.cboSexo.Text = "Masculino" Then
            CargaMasculinoPreinfantil() ' CARGA MASCULINOS PRE-INFANTILES


            'FILTRO MASCULINO DE PLANILLA VELOCIDAD
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Menores" And PlanillaDeVelocidad.cboSexo.Text = "Femenino" Then
            CargaFemeninoMenores() ' CARGA FEMENINOS MENORES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Mayores" And PlanillaDeVelocidad.cboSexo.Text = "Femenino" Then
            CargaFemeninoMayores() ' CARGA FEMENINOS MAYORES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Cadetes" And PlanillaDeVelocidad.cboSexo.Text = "Femenino" Then
            CargaFemeninoCadetes() ' CARGA FEMENINOS CADETES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Juveniles" And PlanillaDeVelocidad.cboSexo.Text = "Femenino" Then
            CargaFemeninoJuveniles() ' CARGA FEMENINOS JUVENILES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Infantiles" And PlanillaDeVelocidad.cboSexo.Text = "Femenino" Then
            CargaFemeninoinfantiles() ' CARGA FEMENINOS INFANTILES
        ElseIf PlanillaDeVelocidad.cboCategoria.Text = "Pre-Infantiles" And PlanillaDeVelocidad.cboSexo.Text = "Femenino" Then
            CargaFemeninoPreInfantiles() ' CARGA FEMENINOS PRE-INFANTILES
        Else
            cargaatletas()
        End If

        Select Case TipoDeFormulario

            Case TipoFormulario.Alta
               btnEliminar.Enabled = True
                btnImprimir.Enabled = True
                btnModificar.Enabled = True
                btnCerrar.Enabled = True

            Case TipoFormulario.Baja
                btnEliminar.Enabled = True

            Case TipoFormulario.Consulta
                'AGREGAR A LA COMPETENCIA
                btnImprimir.Enabled = False
                btnAgregarACompetencia.Enabled = True

            Case TipoFormulario.Modificacion
                btnModificar.Enabled = True

            Case TipoFormulario.AgregarAtleta
                btnAgregarACompetencia.Enabled = True
                btnCerrar.Enabled = True
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                btnImprimir.Enabled = False
                btnEliminar.Visible = False
                btnVer.Enabled = False

            Case TipoFormulario.DatosAdicionalesDelAtleta
                btnAgregarACompetencia.Enabled = True
                btnCerrar.Enabled = True
                btnVer.Enabled = False
            Case TipoFormulario.Listado
                btnModificar.Enabled = True

            Case TipoFormulario.Ver
                btnModificar.Enabled = False
                btnAgregarACompetencia.Enabled = False
                btnEliminar.Enabled = False
                btnCerrar.Enabled = True
                btnImprimir.Enabled = False
                GroupBox1.Enabled = True
        End Select
    End Sub

    Private Sub LISTA_DE_ATLETAS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

    End Sub

    Sub cargaatletas()
        Dim listadoDeAtletas As List(Of CEAtletas) = capanegocio.ListadoDeAtletasDTO()

        dgvlistaatletas.DataSource = listadoDeAtletas
        lbltotalatletas.Text = listadoDeAtletas.Count
        ' Me.dgvlistaatletas.CurrentRow.Selected = False
        dgvlistaatletas.Columns(0).HeaderText = "Código"
        dgvlistaatletas.Columns(0).Visible = False
        dgvlistaatletas.Columns(1).HeaderText = "Nombre"
        dgvlistaatletas.Columns(2).HeaderText = "Apellido"
        dgvlistaatletas.Columns(3).HeaderText = "Dni"
        dgvlistaatletas.Columns(4).HeaderText = "Fecha de Nacimiento"
        dgvlistaatletas.Columns(5).HeaderText = "Nacionalidad"
        '  dgvjueces.Columns("Provincia").Visible = False
        dgvlistaatletas.Columns(6).HeaderText = "Provincia"
        dgvlistaatletas.Columns(6).Visible = False
        dgvlistaatletas.Columns(7).HeaderText = "Localidad"
        dgvlistaatletas.Columns(7).Visible = False
        dgvlistaatletas.Columns(8).HeaderText = "Dirección"
        dgvlistaatletas.Columns(9).HeaderText = "Barrio"
        dgvlistaatletas.Columns(10).HeaderText = "Tel. Fijo"
        dgvlistaatletas.Columns(11).HeaderText = "Tel. Celular"
        dgvlistaatletas.Columns(12).HeaderText = "Correo Electrónico"
        dgvlistaatletas.Columns(13).HeaderText = "Contacto de Emergencia"
        dgvlistaatletas.Columns(14).HeaderText = "Federado"
        dgvlistaatletas.Columns(15).HeaderText = "Club/Federación"
        dgvlistaatletas.Columns(15).Visible = False
        dgvlistaatletas.Columns(16).HeaderText = "Representa a"
        dgvlistaatletas.Columns(17).HeaderText = "Dorsal"
        dgvlistaatletas.Columns(17).Visible = False
        dgvlistaatletas.Columns(18).HeaderText = "Estado del Atleta"
        dgvlistaatletas.Columns(18).Visible = False
        dgvlistaatletas.Columns(19).HeaderText = "Sexo"
        dgvlistaatletas.Columns(19).Visible = False
        dgvlistaatletas.Columns(20).HeaderText = "Edad"
        dgvlistaatletas.ClearSelection()
        dgvlistaatletas.AutoSizeColumnsMode = _
    DataGridViewAutoSizeColumnsMode.AllCells
        dgvlistaatletas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim cellStyle As New DataGridViewCellStyle
        cellStyle.Font = New Font _
            (dgvlistaatletas.Font.Name, dgvlistaatletas.Font.Size, FontStyle.Bold)
        Me.dgvlistaatletas.ColumnHeadersDefaultCellStyle = cellStyle


    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        ' filtrarpordni(TextBox1.Text, dgvlistaatletas)
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim r% = MessageBox.Show("Está seguro de eliminar al atleta de la base de datos..?", "Mensaje",
         MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If r = 6 Then
            capanegocio.eliminarAtleta(Me.dgvlistaatletas.Rows(Me.dgvlistaatletas.CurrentRow.Index).Cells(0).Value)
            dgvlistaatletas.Columns.Clear()
            cargaatletas()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Dim atleta As CEAtletas = dgvlistaatletas.CurrentRow.DataBoundItem
        NUEVOATLETA.AtletaSeleccionado = atleta
        NUEVOATLETA.TipoDeFormulario = TipoFormulario.Modificacion
        NUEVOATLETA.ShowDialog()

    End Sub

    Private Sub btnAgregarACompetencia_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarACompetencia.Click
        'ESTO ES MUY IMPORTANTE PORQUE LE ESTOY PASANDO EL DTO DEL ATLETA SELECCIONADO, ESTO NO PUEDE ESTAR EN NULO PORQUE EXLOTA TODO
        'Y NOS VMOS A MORIR EN EL INFIERNO
        'si dgvlistaatletas.currentrow.column(id_atleta) = atletaxcompetencia.dgv.column(id_atleta).any then
        'msgbox 'el atleta ya existe'
        'si no
        Dim atleta As CEAtletas = dgvlistaatletas.CurrentRow.DataBoundItem
        NUEVOATLETA.AtletaSeleccionado = atleta
        NUEVOATLETA.TipoDeFormulario = TipoFormulario.DatosAdicionalesDelAtleta

        NUEVOATLETA.ShowDialog()
    End Sub

    Private Sub btnAgregarNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarNuevo.Click
        LimpiarControlesAtleta()
        CargarControlesAtleta()
        NUEVOATLETA.TipoDeFormulario = TipoFormulario.AltaCompetencia
        NUEVOATLETA.ShowDialog()
        ' Me.Refresh()
        Me.Close()
    End Sub


    'profe
    'Private Sub cboCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '    '        - de 9 a 10 preinfantiles
    '    '- de 11 a 12 infantiles
    '    '- de 13 a 14 cadetes
    '    '- de 15 a 17 menores
    '    '- de 18 a 19 juveniles
    '    '- de 20 a 22 mayores
    '    Dim textoSeleccionado As String = cboCategoria.Text

    '    Select Case textoSeleccionado
    '        Case "Todas"
    '            cargaatletas()
    '        Case "Pre-infantiles"
    '            cargaatletasPorEdad(0, 10)
    '        Case "Infantiles"
    '            cargaatletasPorEdad(11, 12)
    '        Case "Cadetes"
    '            cargaatletasPorEdad(13, 14)
    '        Case "Menores"
    '            cargaatletasPorEdad(15, 17)
    '        Case "Juveniles"
    '            cargaatletasPorEdad(18, 19)
    '        Case "Mayores"
    '            cargaatletasPorEdad(20, 100)
    '    End Select
    'End Sub

    Private Sub cargaatletasPorEdad(p1 As Int32, p2 As Int32)
        Dim listadoDeAtletas As List(Of CEAtletas) = capanegocio.ListadoDeAtletasDTO().Where(Function(a) a.Edad >= p1 AndAlso a.Edad <= p2).ToList()
        dgvlistaatletas.DataSource = listadoDeAtletas
        lbltotalatletas.Text = listadoDeAtletas.Count
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        ReporteListadeAtletas.ShowDialog()
    End Sub

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        VerControlesAtleta()
        Dim atleta As CEAtletas = dgvlistaatletas.CurrentRow.DataBoundItem
        NUEVOATLETA.AtletaSeleccionado = atleta
        NUEVOATLETA.TipoDeFormulario = TipoFormulario.Consulta
        NUEVOATLETA.Show()
    End Sub

    Sub VerControlesAtleta()
        NUEVOATLETA.Text = "VER DATOS DEL ATLETA"
        NUEVOATLETA.btnValidarExistencia.Enabled = False
        NUEVOATLETA.btnRegistrarAtleta.Enabled = False
        NUEVOATLETA.btnLimpiar.Enabled = False
        NUEVOATLETA.btnConfirmarAsistencia.Enabled = False
        NUEVOATLETA.btnCancelar.Enabled = True
        NUEVOATLETA.btnActualizarAtleta.Enabled = False
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

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
   
        Dim Fila = Buscar(dgvlistaatletas, "Código", TextBox1.Text)

        If Fila Is Nothing Then
            MessageBox.Show("No se ha encontrado al Atleta")
            btnAgregarNuevo.Enabled = True
            btnAgregarACompetencia.Enabled = False

            Return
        End If

        dgvlistaatletas.ClearSelection()
        dgvlistaatletas.CurrentCell = Fila.Cells(3)
        dgvlistaatletas.Focus()
        Fila.Selected = True

    End Sub

    Private Function Buscar(Grid As DataGridView, Col As String, SearchText As String) As DataGridViewRow

        Return Grid.Rows.Cast(Of DataGridViewRow)().
         FirstOrDefault(Function(r) Convert.ToString(r.Cells(3).Value).Equals(SearchText))

    End Function

End Class


