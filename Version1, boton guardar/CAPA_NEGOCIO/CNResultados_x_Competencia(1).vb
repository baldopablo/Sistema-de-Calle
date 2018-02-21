Imports CAPA_DATOS
Imports CAPA_ENTIDAD

Public Class CNResultados_x_Competencia
    Dim objrxc As New DAOResultados_x_Competencia

    Public Function Lista_Resultados_x_Competencia() As DataSet
        Return objrxc.Lista_Resultados_x_Competencia
    End Function

    Public Function Lista_Resultados_x_CompetenciaDTO() As List(Of CEResultados_x_Competencia)
        Return objrxc.Lista_Resultados_x_CompetenciaDTO
    End Function

  

    Public Function Nuevo_Codigo_Resultado_x_Competencia() As String
        Return objrxc.Nuevo_Codigo_Resultado_x_Competencia()
    End Function

    Public Sub Nuevo_Resultado_x_Competencia(ByVal objresxcomp As CEResultados_x_Competencia)

        objrxc.Nuevo_Resultado_x_Competencia(objresxcomp)

    End Sub

    Public Sub Actualizar_Resultado_x_Competencia(ByVal rxc As CEResultados_x_Competencia)
        objrxc.Actualizar_Resultado_x_Competencia(rxc.id_resultado_x_competencia,
                                 rxc.id_competencia,
                                 rxc.id_atleta,
                                 rxc.serie,
                                 rxc.descripcion,
                                 rxc.valor,
                                 rxc.mejor,
                                 rxc.posicion,
                                 rxc.id_juez,
                                 rxc.dorsal)
    End Sub

    Public Sub Eliminar_Resultado_x_Competencia(ByVal id As Integer)
        objrxc.Eliminar_Resultado_x_Competencia(id)
    End Sub
End Class
