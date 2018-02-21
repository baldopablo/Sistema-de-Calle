Imports System.Data.SqlClient
Imports CAPA_ENTIDAD
Imports System.Collections.Generic

Public Class DAOResultados_x_Atleta

    Dim objcon As New conexion
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand

    Public Function Lista_Resultados_x_Atleta() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Lista_Resultados_x_Atleta", cn) ' NOMBRE DEL PROCEDIMIENTO ALMACENADO
        da.Fill(ds, "Resultados por Atleta") 'ELEGIMOS UN NOMBRE O ALIAS
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Lista_Resultados_x_AtletaDTO() As List(Of CEResultados_x_Atleta)
        Dim miDS = Lista_Resultados_x_Atleta() ' nombre del procedimiento que llena la lista de atletas de la bd
        Dim vectorDeResultados_x_Atleta = New List(Of CEResultados_x_Atleta)()
        For Each row In miDS.Tables(0).Rows
            Dim rxa As CEResultados_x_Atleta = New CEResultados_x_Atleta()
            rxa.id_resultado_x_atleta = row("Id_Resultados_X_Atleta")
            rxa.id_competencia = row("Id_Competencia")
            rxa.id_atleta = row("Id_Atleta")
            rxa.id_juez1 = row("Id_Juez")
            rxa.serie = row("Serie")
            rxa.descripcion = row("Descripcion")
            rxa.valor1 = row("Valor")
            rxa.mejor = row("Mejor")

            vectorDeResultados_x_Atleta.Add(rxa)
        Next
        Return vectorDeResultados_x_Atleta
    End Function


    Public Function Nuevo_Codigo_Resultado_x_Atleta() As String
        cn = objcon.Conectar
        cn.Open()
        da = New SqlDataAdapter("Nuevo_Codigo_Resultado_x_Atleta", cn)
        Return da.SelectCommand.ExecuteScalar()
    End Function


    Public Sub Nuevo_Resultado_x_Atleta(ByVal rxa As CEResultados_x_Atleta)
        cn = objcon.Conectar
        Try
            cn.Open()
            da = New SqlDataAdapter("Nuevo_Resultado_x_Atleta", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand.Parameters
                .Add("@Id_Resultados_X_Atleta", SqlDbType.Int).Value = rxa.id_resultado_x_atleta
                .Add("@Id_Competencia", SqlDbType.Int).Value = rxa.id_competencia
                .Add("@Id_Atleta", SqlDbType.Int).Value = rxa.id_atleta
                .Add("@Id_Juez", SqlDbType.Int).Value = rxa.id_juez1
               
                .Add("@Serie", SqlDbType.VarChar).Value = rxa.serie
                .Add("@Descripcion", SqlDbType.VarChar).Value = rxa.descripcion
                .Add("@Valor", SqlDbType.VarChar).Value = rxa.valor1
                .Add("@Mejor", SqlDbType.VarChar).Value = rxa.mejor
            End With
            da.SelectCommand.ExecuteNonQuery()
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select @@IDENTITY"
            Dim ds As DataSet = New DataSet
            da.Fill(ds)
            rxa.id_resultado_x_atleta = ds.Tables(0)(0)(0)

        Catch ex As Exception
            MsgBox("Error al registrar el nuevo resultado del atleta", MsgBoxStyle.Critical)
        Finally
            da.Dispose()
            cn.Dispose()
        End Try
    End Sub

    'Public Sub Actualizar_Resultado_x_Atleta(ByVal rxa As CEResultados_x_Atleta)

    '    Actualizar_Resultado_x_Atleta(rxa.id_resultado_x_atleta,
    '                                 rxa.id_competencia,
    '                                 rxa.id_atleta,
    '                                 rxa.id_juez1,
    '                                 rxa.serie,
    '                                 rxa.descripcion,
    '                                 rxa.valor1,
    '                                 rxa.mejor)
    'End Sub

    'Public Sub Actualizar_Resultado_x_Atleta(ByVal id_resultado_x_atleta As Integer,
    '                            ByVal id_competencia As Integer,
    '                            ByVal id_atleta As Integer,
    '                            ByVal id_juez1 As Integer,
    '                            ByVal serie As String,
    '                            ByVal descripcion As String,
    '                            ByVal valor1 As String,
    '                            ByVal mejor As String)
    '    cn = objcon.Conectar
    '    cmd = New SqlCommand("Actualizar_Resultado_x_Atleta", cn)
    '    cmd.CommandType = CommandType.StoredProcedure

    '    cmd.Parameters.Add("@Id_Resultados_X_Atleta", SqlDbType.Int).Value = id_resultado_x_atleta '0
    '    cmd.Parameters.Add("@Id_Competencia", SqlDbType.Int).Value = id_competencia '1
    '    cmd.Parameters.Add("@Id_Atleta", SqlDbType.Int).Value = id_atleta '2
    '    cmd.Parameters.Add("@Id_Juez", SqlDbType.Int).Value = id_juez1
    '    cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = serie '4
    '    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion
    '    cmd.Parameters.Add("@Valor", SqlDbType.VarChar).Value = valor1
    '    cmd.Parameters.Add("@Mejor", SqlDbType.VarChar).Value = mejor
    '    cn.Open()
    '    cmd.ExecuteNonQuery()
    '    cn.Close()
    'End Sub

    Public Sub Eliminar_Resultado_x_Atleta(ByVal cod As Integer)
        Try
            cn = objcon.Conectar
            Dim cmd = New SqlCommand("Eliminar_Resultado_x_Atleta", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Id_Resultados_X_Atleta", SqlDbType.Int).Value = cod
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("El Resultado del Atleta ha sido eliminado correctamente")
        Catch ex As Exception
            MsgBox("Error al eliminar el Resultado del Atleta" + ex.ToString)
        End Try
    End Sub
End Class
