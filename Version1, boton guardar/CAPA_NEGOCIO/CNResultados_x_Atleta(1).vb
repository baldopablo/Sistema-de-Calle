Imports CAPA_DATOS
Imports CAPA_ENTIDAD

Public Class CNResultados_x_Atleta
    Dim objrxa As New DAOResultados_x_Atleta

    Public Function Lista_Resultados_x_Atleta() As DataSet
        Return objrxa.Lista_Resultados_x_Atleta
    End Function

    Public Function Lista_Resultados_x_AtletaDTO() As List(Of CEResultados_x_Atleta)
        Return objrxa.Lista_Resultados_x_AtletaDTO
    End Function


    Public Function Nuevo_Codigo_Resultado_x_Atleta() As String
        Return objrxa.Nuevo_Codigo_Resultado_x_Atleta
    End Function

    Public Sub Nuevo_Resultado_x_Atleta(ByVal objresxat As CEResultados_x_Atleta)
        objrxa.Nuevo_Resultado_x_Atleta(objresxat)
    End Sub

    'Public Sub ActualizarResultado_x_Atleta(ByVal rxa As CEResultados_x_Atleta)
    '    objrxa.Actualizar_Resultado_x_Atleta(rxa.id_resultado_x_atleta,
    '                             rxa.id_competencia,
    '                             rxa.id_atleta,
    '                             rxa.id_juez1,
    '                             rxa.serie,
    '                             rxa.descripcion,
    '                             rxa.valor1,
    '                             rxa.mejor)
    'End Sub

    Public Sub Eliminar_Resultado_x_Atleta(ByVal id As Integer)
        objrxa.Eliminar_Resultado_x_Atleta(id)
    End Sub
End Class
