Imports System.Data.SqlClient
Imports CAPA_ENTIDAD
Imports System.Collections.Generic

Public Class DAOResultados_x_Competencia
    Dim objcon As New conexion
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand

    Public Function Lista_Resultados_x_Competencia() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Lista_Resultados_x_Competencia", cn) ' NOMBRE DEL PROCEDIMIENTO ALMACENADO
        da.Fill(ds, "Resultados por Competencia") 'ELEGIMOS UN NOMBRE O ALIAS
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Lista_Resultados_x_CompetenciaDTO() As List(Of CEResultados_x_Competencia)
        Dim miDS = Lista_Resultados_x_Competencia() ' nombre del procedimiento que llena la lista de atletas de la bd
        Dim vectorDeResultados_x_Competencia = New List(Of CEResultados_x_Competencia)()
        For Each row In miDS.Tables(0).Rows
            Dim rxc As CEResultados_x_Competencia = New CEResultados_x_Competencia()
            rxc.id_resultado_x_competencia = row("Id_Resultados_X_Competencia")
            rxc.id_competencia = row("Id_Competencia")
            rxc.id_atleta = row("Id_Atleta")
            rxc.serie = row("Serie")
            rxc.descripcion = row("Descripcion")
            rxc.valor = row("Valor")
            rxc.mejor = row("Mejor")
            rxc.posicion = row("Posicion")
            vectorDeResultados_x_Competencia.Add(rxc)
        Next
        Return vectorDeResultados_x_Competencia
    End Function

    Public Function Nuevo_Codigo_Resultado_x_Competencia() As String
        cn = objcon.Conectar
        cn.Open()
        da = New SqlDataAdapter("Nuevo_Codigo_Resultado_x_Competencia", cn)
        Return da.SelectCommand.ExecuteScalar()
    End Function

    Public Sub Nuevo_Resultado_x_Competencia(ByVal rxc As CEResultados_x_Competencia)
        cn = objcon.Conectar
        Try
            cn.Open()
            da = New SqlDataAdapter("Nuevo_Resultado_x_Competencia", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand.Parameters
                .Add("@Id_Resultados_X_Competencia", SqlDbType.Int).Value = rxc.id_resultado_x_competencia
                .Add("@Id_Competencia", SqlDbType.Int).Value = rxc.id_competencia
                .Add("@Id_Atleta", SqlDbType.Int).Value = rxc.id_atleta
                .Add("@Serie", SqlDbType.VarChar).Value = rxc.serie
                .Add("@Descripcion", SqlDbType.VarChar).Value = rxc.descripcion
                .Add("@Valor", SqlDbType.VarChar).Value = rxc.valor
                .Add("Mejor", SqlDbType.VarChar).Value = rxc.mejor
                .Add("@Posicion", SqlDbType.Int).Value = rxc.posicion
                .Add("@Id_Juez", SqlDbType.Int).Value = rxc.id_juez
                .Add("@Dorsal", SqlDbType.Int).Value = rxc.dorsal
            End With
            da.SelectCommand.ExecuteNonQuery()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select @@IDENTITY"
            Dim ds As DataSet = New DataSet
            da.Fill(ds)
            rxc.id_resultado_x_competencia = ds.Tables(0)(0)(0)

        Catch ex As Exception
            MsgBox("Error al registrar el nuevo resultado de la competencia", MsgBoxStyle.Critical)
        Finally
            da.Dispose()
            cn.Dispose()
        End Try
    End Sub

    Public Sub Eliminar_Resultado_x_Competencia(ByVal cod As Integer)
        Try
            cn = objcon.Conectar
            Dim cmd = New SqlCommand("Eliminar_Resultado_x_Competencia", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Id_Resultados_X_Competencia", SqlDbType.Int).Value = cod
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("El Resultado de la competencia ha sido eliminado correctamente")
        Catch ex As Exception
            MsgBox("Error al eliminar el Resultado de la competencia" + ex.ToString)
        End Try
    End Sub


    Public Sub Actualizar_Resultado_x_Competencia(ByVal rxc As CEResultados_x_Competencia)

        Actualizar_Resultado_x_Competencia(rxc.id_resultado_x_competencia,
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

    Public Sub Actualizar_Resultado_x_Competencia(ByVal id_resultado_x_competencia As Integer,
                                ByVal id_competencia As Integer,
                                ByVal id_atleta As Integer,
                                ByVal serie As String,
                                ByVal descripcion As String,
                                ByVal valor As String,
                                ByVal mejor As String,
                                ByVal posicion As Integer,
                                ByVal id_juez As Integer,
                                ByVal dorsal As Integer)
        cn = objcon.Conectar
        cmd = New SqlCommand("Actualizar_Resultado_x_Competencia", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add("@Id_Resultados_X_Competencia", SqlDbType.Int).Value = id_resultado_x_competencia '0
        cmd.Parameters.Add("@Id_Competencia", SqlDbType.Int).Value = id_competencia '1
        cmd.Parameters.Add("@Id_Atleta", SqlDbType.Int).Value = id_atleta '2
        cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = serie '4
        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion
        cmd.Parameters.Add("@Valor", SqlDbType.VarChar).Value = valor '5
        cmd.Parameters.Add("@Mejor", SqlDbType.VarChar).Value = mejor
        cmd.Parameters.Add("@Posicion", SqlDbType.VarChar).Value = posicion
        cmd.Parameters.Add("@Id_Juez", SqlDbType.Int).Value = id_juez
        cmd.Parameters.Add("@Dorsal", SqlDbType.Int).Value = dorsal
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

End Class
