Imports CAPA_DATOS
Imports CAPA_ENTIDAD

Public Class CNAtletas
    ' creamos el objeto de capa datos
    Dim objatleta As New DAOAtletas

    'este  metodo devuelve un vector con los objetos del tipo Atleta
    Public Function ListadoDeAtletasDTO() As List(Of CEAtletas)
        Return objatleta.ListadoDeAtletasDTO()
    End Function

    'implementamos la funcion que retorna el data set
    Public Function listadoatletas() As DataSet
        Return objatleta.listadoatletas
    End Function

    Public Function listadoatletas1() As DataSet
        Return objatleta.listadoatletas1
    End Function

    Public Function Lista_Atletas_MasculinoDTO() As List(Of CEAtletas)
        Return objatleta.Lista_Atletas_MasculinoDTO()
    End Function

    Public Function Lista_Atletas_FemeninoDTO() As List(Of CEAtletas)
        Return objatleta.Lista_Atletas_FemeninoDTO()
    End Function
    'filtro masculino infantil DTO
    Public Function FILTRO_MASCULINO_INFANTILES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_MASCULINO_INFANTILES_DTO
    End Function

    'filtro masculino pre infantil DTO
    Public Function FILTRO_MASCULINO_PRE_INFANTILES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_MASCULINO_PRE_INFANTILES_DTO()
    End Function

    'filtro masculino cadete DTO
    Public Function FILTRO_MASCULINO_CADETES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_MASCULINO_CADETES_DTO
    End Function

    'filtro masculino menores DTO
    Public Function FILTRO_MASCULINO_MENORES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_MASCULINO_MENORES_DTO
    End Function

    ' filtro masculino juveniles DTO
    Public Function FILTRO_MASCULINO_JUVENILES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_MASCULINO_JUVENILES_DTO
    End Function

    ' filtro masculino MAYORES DTO
    Public Function FILTRO_MASCULINO_MAYORES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_MASCULINO_MAYORES_DTO
    End Function

    ' filtro FEMENINO MAYORES DTO
    Public Function FILTRO_FEMENINO_MAYORES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_FEMENINO_MAYORES_DTO
    End Function

    ' filtro Femenino juveniles DTO
    Public Function FILTRO_FEMENINO_JUVENILES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_FEMENINO_JUVENILES_DTO
    End Function

    ' filtro Femenino Menores DTO
    Public Function FILTRO_FEMENINO_MENORES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_FEMENINO_MENORES_DTO
    End Function

    ' filtro Femenino Cadetes DTO
    Public Function FILTRO_FEMENINO_CADETES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_FEMENINO_CADETES_DTO
    End Function

    ' filtro Femenino Infantiles DTO
    Public Function FILTRO_FEMENINO_INFANTILES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_FEMENINO_INFANTILES_DTO
    End Function

    ' filtro Femenino  Pre Infantiles DTO
    Public Function FILTRO_FEMENINO_PRE_INFANTILES_DTO() As List(Of CEAtletas)
        Return objatleta.FILTRO_FEMENINO_PRE_INFANTILES_DTO
    End Function

    'llamamos a la funcion generar
    Public Function nuevocodigoatleta() As String
        Return objatleta.nuevoCodigoatleta
    End Function

    Public Function Sexoatleta() As DataSet
        Return objatleta.Sexoatleta
    End Function

    'lista de las provincias
    Public Function ListaProvinciaAtleta() As DataSet
        Return objatleta.ListaProvinciaAtleta
    End Function

    'lista de las localidades
    Public Function ListaLocalidadAtleta() As DataSet
        Return objatleta.ListaLocalidadAtleta
    End Function

    Public Function ListaClubAtleta() As DataSet
        Return objatleta.ListaClubAtleta
    End Function

    'lista de las localidades segun la provincia
    Public Function ListaLocalidadAtleta(Id_Provincia As Integer) As DataSet
        Return objatleta.ListaLocalidadAtleta(Id_Provincia)
    End Function

    ' llamamos al procedimiento de registro de usuario
    Public Sub nuevoatleta(ByVal obju As CEAtletas)
        objatleta.nuevoatleta(obju)
    End Sub

    Public Sub eliminarAtleta(ByVal Id As Integer)
        objatleta.eliminarAtleta(Id)
    End Sub

    Public Sub ActualizarAtleta(ByVal atleta As CEAtletas)
        objatleta.ActualizarAtleta(atleta.id_atleta,
                                 atleta.Nombre_atleta,
                                 atleta.Apellido_atleta,
                                 atleta.fecha_nacimiento,
                                 atleta.id_sexo,
                                 atleta.dni_atleta,
                                 atleta.nacionalidad,
                                 atleta.id_provincia,
                                 atleta.id_localidad,
                                 atleta.domicilio,
                                 atleta.barrio,
                                 atleta.telefono_fijo,
                                 atleta.telefono_celular,
                                 atleta.e_mail,
                                 atleta.contacto_emergencia,
                                 atleta.federado,
                                 atleta.id_club_federacion,
                                 atleta.otra_institucion,
                                 atleta.dorsal,
                                 atleta.estado_atleta)
    End Sub

    Public Function cargaMC1DTO(ByVal ID_SEXO As Integer) As List(Of CEVista_a_x_c)
        Return objatleta.Lista_fILTRO_eDAD_sEXO_DTO(ID_SEXO)
    End Function
    'Public Function cargaMC2DTO() As List(Of CEVista_a_x_c)
    '    Return objatleta.Lista_fILTRO_eDAD_sEXO_DTO()
    'End Function
    'Public Function cargaMC3DTO() As List(Of CEVista_a_x_c)
    '    Return objatleta.Lista_fILTRO_eDAD_sEXO_DTO()
    'End Function
    'Public Function cargaFC1DTO() As List(Of CEVista_a_x_c)
    '    Return objatleta.Lista_fILTRO_eDAD_sEXO_DTO()
    'End Function
    'Public Function cargaFC2DTO() As List(Of CEVista_a_x_c)
    '    Return objatleta.Lista_fILTRO_eDAD_sEXO_DTO()
    'End Function
    'Public Function cargaFC3DTO() As List(Of CEVista_a_x_c)
    '    Return objatleta.Lista_fILTRO_eDAD_sEXO_DTO()
    'End Function
End Class

