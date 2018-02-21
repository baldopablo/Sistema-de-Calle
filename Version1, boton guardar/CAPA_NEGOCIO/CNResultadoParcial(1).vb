Imports CAPA_DATOS
Imports CAPA_ENTIDAD

Public Class CNResultadoParcial
    Dim objres As New DAOResultadoParcial

    Public Sub NuevoResultado(ByVal objc As CeResultadoParcial)
        objres.NuevoResultado(objc)
    End Sub

    Public Function NuevoCodigoResultado() As String
        Return objres.NuevoCodigoResultado
    End Function

    Public Sub ActualizarResultado(ByVal resultado As CeResultadoParcial)
        objres.ActualizarResultado(resultado.id_resultado,
                          resultado.serie,
                          resultado.altura1,
                          resultado.altura2,
                          resultado.altura3,
                          resultado.altura4,
                          resultado.altura5,
                          resultado.lanzamiento1,
                          resultado.lanzamiento2,
                          resultado.lanzamiento3,
                          resultado.lanzamiento4,
                          resultado.lanzamiento5,
                          resultado.lanzamiento6,
                          resultado.Tiempo1,
                           resultado.Tiempo2,
                          resultado.Tiempo3,
                          resultado.mejor_lanzamiento123,
                          resultado.mejor_lanzamiento456,
                          resultado.mejor_salto,
                          resultado.mejor_tiempo_cross_country,
                          resultado.mejor_tiempo_calle,
                          resultado.mejor_tiempo_fondo,
                          resultado.mejor_tiempo_maraton,
                          resultado.mejor_tiempo_obstaculos,
                          resultado.mejor_tiempo_marcha,
                          resultado.mejor_tiempo_velocidad,
                          resultado.mejor_tiempo_medio_fondo,
                          resultado.clasificacion_calle,
                          resultado.clasificacion_salto,
                          resultado.clasificacion_lanzamiento,
                          resultado.mejor_tiempo_cross_country,
                          resultado.clasificacion_fondo,
                          resultado.clasificacion_maraton,
                          resultado.clasificacion_marcha,
                          resultado.clasificacion_medio_fondo,
                          resultado.clasificacion_obstaculos,
                          resultado.clasificacion_velocidad)
    End Sub

    Public Sub EliminarResultado(ByVal id As Integer)
        objres.EliminarResultado(id)
    End Sub

    Public Function ListaResultadosDTO() As List(Of CeResultadoParcial)
        Return objres.ListaResultadosDTO()
    End Function

    Public Function ListaResultados() As DataSet
        Return objres.ListaResultados
    End Function
End Class
