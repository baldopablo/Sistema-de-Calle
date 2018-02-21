Imports CAPA_DATOS
Imports CAPA_ENTIDAD

Public Class CNAtletas_x_Competencia
    Dim objcompetencia As New DAOAtletas_x_Competencia

    Public Sub Nuevo_Atleta_x_Competencia(ByVal ObjAxC As CEAtletas_x_Competencia)
        objcompetencia.Nuevo_Atleta_x_Competencia(ObjAxC)
    End Sub

    Public Function Nuevo_Codigo_Atleta_x_Competencia() As String
        Return objcompetencia.Nuevo_Codigo_Atleta_x_Competencia()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Calle() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Calle
    End Function
    Public Function Ultimo_Registro_Atleta_x_Competencia_Velocidad() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Velocidad
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Obstaculos() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Obstaculos
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Medio_Fondo() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Medio_Fondo
    End Function

    Public Function Planilla_Resultado_Final_Velocidad_Serie_Unica() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Velocidad_Serie_Unica
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Lanzamiento() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Lanzamiento
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Salto() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Salto
    End Function

    Public Function Planilla_Resultado_Final_Calle() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Calle()
    End Function

    Public Function Planilla_Resultado_Final_Cross_Country() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Cross_Country
    End Function

    Public Function Planilla_Resultado_Final_Fondo() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Fondo
    End Function

    Public Function Planilla_Resultado_Final_Medio_Fondo() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Medio_Fondo
    End Function

    Public Function Planilla_Resultado_Final_Marcha() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Marcha
    End Function

    Public Function Planilla_Final_Cross_Country() As DataSet
        Return objcompetencia.Planilla_Final_Cross_Country()
    End Function

    Public Function Planilla_Resultado_Final_Lanzamiento() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Lanzamiento
    End Function

    Public Function Planilla_Resultado_Final_Salto() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Salto
    End Function
    Public Function Planilla_Resultado_Final_Maraton() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Maraton
    End Function


    Function Planilla_Resultado_Final_Obstaculos() As DataSet
        Return objcompetencia.Planilla_Resultado_Final_Obstaculos
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Cross_Country() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Cross_Country
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Maraton() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Maraton
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Marcha() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Marcha
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Fondo() As DataSet
        Return objcompetencia.Ultimo_Registro_Atleta_x_Competencia_Fondo
    End Function

    Public Sub Eliminar_Atleta_x_Competencia(ByVal id As Integer)
        objcompetencia.Eliminar_Atleta_x_Competencia(id)
    End Sub

    Public Function Editar_ListadoTodasCompetencias() As DataSet
        Return objcompetencia.Editar_ListadoTodasCompetencias
    End Function

    Public Function Editar_ListadoTodasCompetencias_DTO() As List(Of CEAtletas_x_Competencia)
        Return objcompetencia.Editar_ListadoTodasCompetencias_DTO()
    End Function
    'Public Function ListadoTodasCompetencias() As DataSet
    '    Return objcompetencia.ListadoTodasCompetencias
    'End Function

    'Public Function Lista_Calle_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Calle_DTO
    'End Function

    'Public Function Lista_Calle() As DataSet
    '    Return objcompetencia.Lista_Calle
    'End Function

    'Public Function Lista_Cross_Country_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Cross_Country_DTO
    'End Function

    'Public Function Lista_Cross_Country() As DataSet
    '    Return objcompetencia.Lista_Cross_Country
    'End Function

    'Public Function Lista_Fondo_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Fondo_DTO
    'End Function

    'Public Function Lista_Fondo() As DataSet
    '    Return objcompetencia.Lista_Fondo
    'End Function

    'Public Function Lista_Lanzamiento_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Lanzamiento_DTO
    'End Function

    'Public Function Lista_Lanzamiento() As DataSet
    '    Return objcompetencia.Lista_Lanzamiento
    'End Function

    'Public Function Lista_Maraton_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Maraton_DTO
    'End Function

    'Public Function Lista_Maraton() As DataSet
    '    Return objcompetencia.Lista_Maraton
    'End Function

    'Public Function Lista_Marcha_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Marcha_DTO
    'End Function

    'Public Function Lista_Marcha() As DataSet
    '    Return objcompetencia.Lista_Marcha
    'End Function

    'Public Function Lista_Medio_Fondo_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Medio_Fondo_DTO
    'End Function

    'Public Function Lista_Medio_Fondo() As DataSet
    '    Return objcompetencia.Lista_Medio_Fondo
    'End Function

    'Public Function Lista_Obstaculos_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Obstaculos_DTO
    'End Function

    'Public Function Lista_Obstaculos() As DataSet
    '    Return objcompetencia.Lista_Obstaculos
    'End Function

    'Public Function Lista_Salto_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Salto_DTO
    'End Function

    'Public Function Lista_Salto() As DataSet
    '    Return objcompetencia.Lista_Salto
    'End Function

    'Public Function Lista_Velocidad_DTO() As List(Of CEAtletas_x_Competencia)
    '    Return objcompetencia.Lista_Velocidad_DTO
    'End Function

    'Public Function Lista_Velocidad() As DataSet
    '    Return objcompetencia.Lista_Velocidad
    'End Function

    'Public Sub atletaporcomp(ByVal objc As CEAtletas_x_Competencia)
    '    objcompetencia.Nuevo_Registro_Atleta_x_Competencia(objc)
    'End Sub
    Public Sub Actualizar_Atleta_x_Competencia(ByVal objAxC As CEAtletas_x_Competencia)
        objcompetencia.Actualizar_Atleta_x_Competencia(objAxC.Id_atleta_x_competencia,
                               objAxC.id_atleta,
                               objAxC.id_competencia,
                               objAxC.id_resultado_atleta,
                               objAxC.id_resultado_competencia)
    End Sub

    'LLAMADA A LAS FUNCIONES QUE SUPUESTAMENTE LLENA EL DATAGRID DE LAS PLANILLAS SEGUN ID COMPETENCIA

    Public Function ListadoTodasCompetencias() As DataSet
        Return objcompetencia.ListadoTodasCompetencias
    End Function

    Public Function ListadoDeCompetenciasDTO() As List(Of CECompetencias)
        Return objcompetencia.ListadoDeCompetenciasDTO()
    End Function

    Public Function Lista_Atletas(Id_Competencia As Integer) As DataSet
        Return objcompetencia.Lista_Atletas(Id_Competencia)
    End Function


End Class
