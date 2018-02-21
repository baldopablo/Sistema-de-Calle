Imports System.Data.SqlClient
Imports CAPA_ENTIDAD
Imports System.Collections.Generic

Public Class DAOResultadoParcial
    Dim objcon As New conexion
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand

    Public Function ListaResultados() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("ListaResultadoCalle", cn)
        da.Fill(ds, "Lista de Resultados de Calle")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function ListaResultadosDTO() As List(Of CeResultadoParcial)
        Dim miDS = ListaResultados()
        Dim vectorDeResultado = New List(Of CeResultadoParcial)()
        For Each row In miDS.Tables(0).Rows
            Dim resultado As CeResultadoParcial = New CeResultadoParcial()
            resultado.id_resultado = row("Id_Resultado_Parcial")
            resultado.serie = row("Serie")
            resultado.altura1 = row("Altura1")
            resultado.altura2 = row("Altura2")
            resultado.altura3 = row("Altura3")
            resultado.altura4 = row("Altura4")
            resultado.altura5 = row("Altura5")
            resultado.lanzamiento1 = row("lanzamiento_1")
            resultado.lanzamiento2 = row("lanzamiento_2")
            resultado.lanzamiento3 = row("lanzamiento_3")
            resultado.lanzamiento4 = row("lanzamiento_4")
            resultado.lanzamiento5 = row("lanzamiento_5")
            resultado.lanzamiento6 = row("lanzamiento_6")
            resultado.Tiempo1 = row("Tiempo1")
            resultado.Tiempo2 = row("Tiempo2")
            resultado.Tiempo3 = row("Tiempo3")
            resultado.mejor_lanzamiento123 = row("Mejor_Lanzamiento_123")
            resultado.mejor_lanzamiento456 = row("Mejor_Lanzamiento_456")
            resultado.mejor_salto = row("Mejor_Salto")
            resultado.mejor_tiempo_cross_country = row("Mejor_Tiempo_Cross_Country")
            resultado.mejor_tiempo_calle = row("Mejor_Tiempo_Calle")
            resultado.mejor_tiempo_fondo = row("Mejor_Tiempo_Fondo")
            resultado.mejor_tiempo_maraton = row("Mejor_Tiempo_Maraton")
            resultado.mejor_tiempo_obstaculos = row("Mejor_Tiempo_Obstaculos")
            resultado.mejor_tiempo_marcha = row("Mejor_Tiempo_Marcha")
            resultado.mejor_tiempo_velocidad = row("Mejor_Tiempo_Velocidad")
            resultado.mejor_tiempo_medio_fondo = row("Mejor_Tiempo_Medio_Fondo")
            resultado.clasificacion_calle = row("Clasificación_Tiempo_Calle")
            resultado.clasificacion_salto = row("Clasificación_Salto")
            resultado.clasificacion_lanzamiento = row("Clasificación_Lanzamiento")
            resultado.clasificacion_cross_country = row("Clasificación_Cross_Country")
            resultado.clasificacion_fondo = row("Clasificación_Fondo")
            resultado.clasificacion_maraton = row("Clasificación_Maraton")
            resultado.clasificacion_marcha = row("Clasificación_Marcha")
            resultado.clasificacion_medio_fondo = row("Clasificación_Medio_Fondo")
            resultado.clasificacion_obstaculos = row("Clasificación_Obstaculos")
            resultado.clasificacion_velocidad = row("Clasificación_Velocidad")

            vectorDeResultado.Add(resultado)
        Next
        Return vectorDeResultado
    End Function

    Public Sub NuevoResultado(ByRef ObjCom As CeResultadoParcial)
        cn = objcon.Conectar
        Try
            cn.Open() 'se ubica siempre antes de ejecutar el comando
            da = New SqlDataAdapter("NUEVORESULTADO", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand.Parameters
                .Add("@Id_Resultado_Parcial", SqlDbType.Int).Value = ObjCom.id_resultado
                .Add("@Serie", SqlDbType.Int).Value = ObjCom.serie
                .Add("@Altura1", SqlDbType.Decimal).Value = ObjCom.altura1
                .Add("@Altura2", SqlDbType.Decimal).Value = ObjCom.altura2
                .Add("@Altura3", SqlDbType.Decimal).Value = ObjCom.altura3
                .Add("@Altura4", SqlDbType.Decimal).Value = ObjCom.altura4
                .Add("@Altura5", SqlDbType.Decimal).Value = ObjCom.altura5
                .Add("@lanzamiento_1", SqlDbType.Decimal).Value = ObjCom.lanzamiento1
                .Add("@lanzamiento_2", SqlDbType.Decimal).Value = ObjCom.lanzamiento2
                .Add("@lanzamiento_3", SqlDbType.Decimal).Value = ObjCom.lanzamiento3
                .Add("@lanzamiento_4", SqlDbType.Decimal).Value = ObjCom.lanzamiento4
                .Add("@lanzamiento_5", SqlDbType.Decimal).Value = ObjCom.lanzamiento5
                .Add("@lanzamiento_6", SqlDbType.Decimal).Value = ObjCom.lanzamiento6
                .Add("@Tiempo1", SqlDbType.VarChar).Value = ObjCom.Tiempo1
                .Add("@Tiempo2", SqlDbType.VarChar).Value = ObjCom.Tiempo2
                .Add("@Tiempo3", SqlDbType.VarChar).Value = ObjCom.Tiempo3
                .Add("@Mejor_Lanzamiento_123", SqlDbType.Decimal).Value = ObjCom.mejor_lanzamiento123
                .Add("@Mejor_Lanzamiento_456", SqlDbType.Decimal).Value = ObjCom.mejor_lanzamiento456
                .Add("@Mejor_Salto", SqlDbType.Decimal).Value = ObjCom.mejor_salto
                .Add("@Mejor_Tiempo_Cross_Country", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_cross_country
                .Add("@Mejor_Tiempo_Calle", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_calle
                .Add("@Mejor_Tiempo_Fondo", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_fondo
                .Add("@Mejor_Tiempo_Maraton", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_maraton
                .Add("@Mejor_Tiempo_Obstaculos", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_obstaculos
                .Add("@Mejor_Tiempo_Marcha", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_marcha
                .Add("@Mejor_Tiempo_Velocidad", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_velocidad
                .Add("@Mejor_Tiempo_Medio_Fondo", SqlDbType.VarChar).Value = ObjCom.mejor_tiempo_medio_fondo
                .Add("@Clasificación_Tiempo_Calle", SqlDbType.Int).Value = ObjCom.clasificacion_calle
                .Add("@Clasificación_Salto", SqlDbType.Int).Value = ObjCom.clasificacion_salto
                .Add("@Clasificación_Lanzamiento", SqlDbType.Int).Value = ObjCom.clasificacion_lanzamiento
                .Add("@Clasificación_Cross_Country", SqlDbType.Int).Value = ObjCom.clasificacion_cross_country
                .Add("@Clasificación_Fondo", SqlDbType.Int).Value = ObjCom.clasificacion_fondo
                .Add("@Clasificación_Maraton", SqlDbType.Int).Value = ObjCom.clasificacion_maraton
                .Add("@Clasificación_Marcha", SqlDbType.Int).Value = ObjCom.clasificacion_marcha
                .Add("@Clasificación_Medio_Fondo", SqlDbType.Int).Value = ObjCom.clasificacion_medio_fondo
                .Add("@Clasificación_Obstaculos", SqlDbType.Int).Value = ObjCom.clasificacion_obstaculos
                .Add("@Clasificación_Velocidad", SqlDbType.Int).Value = ObjCom.clasificacion_velocidad

              
            End With
            da.SelectCommand.ExecuteNonQuery()  'inserta los valores
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select @@IDENTITY"
            Dim ds As DataSet = New DataSet
            da.Fill(ds)
            ObjCom.id_resultado = ds.Tables(0)(0)(0)
        Catch ex As Exception
            Throw ex
            MsgBox("Error al registrar el nuevo resultado", MsgBoxStyle.Critical)
        Finally
            da.Dispose()
            cn.Dispose()
        End Try
    End Sub

    Public Sub ActualizarResultado(ByVal id_resultado As Integer,
                              ByVal serie As Integer,
                              ByVal altura1 As Decimal,
                              ByVal altura2 As Decimal,
                              ByVal altura3 As Decimal,
                              ByVal altura4 As Decimal,
                              ByVal altura5 As Decimal,
                              ByVal lanzamiento_1 As Decimal,
                              ByVal lanzamiento_2 As Decimal,
                              ByVal lanzamiento_3 As Decimal,
                              ByVal lanzamiento_4 As Decimal,
                              ByVal lanzamiento_5 As Decimal,
                              ByVal lanzamiento_6 As Decimal,
                              ByVal tiempo1 As String,
                              ByVal tiempo2 As String,
                              ByVal tiempo3 As String,
                              ByVal Mejor_Lanzamiento_123 As Decimal,
                              ByVal Mejor_Lanzamiento_456 As Decimal,
                              ByVal Mejor_Salto As Decimal,
                              ByVal Mejor_Tiempo_Cross_Country As String,
                              ByVal Mejor_Tiempo_Calle As String,
                              ByVal Mejor_Tiempo_Fondo As String,
                              ByVal Mejor_Tiempo_Maraton As String,
                              ByVal Mejor_Tiempo_Obstaculos As String,
                              ByVal Mejor_Tiempo_Marcha As String,
                              ByVal Mejor_Tiempo_Velocidad As String,
                              ByVal Mejor_Tiempo_Medio_Fondo As String,
                              ByVal Clasificación_Tiempo_Calle As String,
                              ByVal Clasificación_Salto As Integer,
                              ByVal Clasificación_Lanzamiento As Integer,
                              ByVal Clasificación_Cross_Country As Integer,
                              ByVal Clasificación_Fondo As Integer,
                              ByVal Clasificación_Maraton As Integer,
                              ByVal Clasificación_Marcha As Integer,
                              ByVal Clasificación_Medio_Fondo As Integer,
                              ByVal Clasificación_Obstaculos As Integer,
                              ByVal Clasificación_Velocidad As Integer)
        cn = objcon.Conectar
        cmd = New SqlCommand("ACTUALIZAR_RESULTADO", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Id_Resultado_Parcial", SqlDbType.Int).Value = id_resultado
        cmd.Parameters.Add("@Serie", SqlDbType.Int).Value = serie
        cmd.Parameters.Add("@Altura1", SqlDbType.Decimal).Value = altura1
        cmd.Parameters.Add("@Altura2", SqlDbType.Decimal).Value = altura2
        cmd.Parameters.Add("@Altura3", SqlDbType.Decimal).Value = altura3
        cmd.Parameters.Add("@Altura4", SqlDbType.Decimal).Value = altura4
        cmd.Parameters.Add("@Altura5", SqlDbType.Decimal).Value = altura5
        cmd.Parameters.Add("@lanzamiento_1", SqlDbType.Decimal).Value = lanzamiento_1
        cmd.Parameters.Add("@lanzamiento_2", SqlDbType.Decimal).Value = lanzamiento_2
        cmd.Parameters.Add("@lanzamiento_3", SqlDbType.Decimal).Value = lanzamiento_3
        cmd.Parameters.Add("@lanzamiento_4", SqlDbType.Decimal).Value = lanzamiento_4
        cmd.Parameters.Add("@lanzamiento_5", SqlDbType.Decimal).Value = lanzamiento_5
        cmd.Parameters.Add("@lanzamiento_6", SqlDbType.Decimal).Value = lanzamiento_6
        cmd.Parameters.Add("@Tiempo1", SqlDbType.VarChar).Value = tiempo1
        cmd.Parameters.Add("@Tiempo2", SqlDbType.VarChar).Value = tiempo2
        cmd.Parameters.Add("@Tiempo3", SqlDbType.VarChar).Value = tiempo3
        cmd.Parameters.Add("@Mejor_Lanzamiento_123", SqlDbType.Decimal).Value = Mejor_Lanzamiento_123
        cmd.Parameters.Add("@Mejor_Lanzamiento_456", SqlDbType.Decimal).Value = Mejor_Lanzamiento_456
        cmd.Parameters.Add("@Mejor_Salto", SqlDbType.Decimal).Value = Mejor_Salto
        cmd.Parameters.Add("@Mejor_Tiempo_Cross_Country", SqlDbType.VarChar).Value = Mejor_Tiempo_Cross_Country
        cmd.Parameters.Add("@Mejor_Tiempo_Calle", SqlDbType.VarChar).Value = Mejor_Tiempo_Calle
        cmd.Parameters.Add("@Mejor_Tiempo_Fondo", SqlDbType.VarChar).Value = Mejor_Tiempo_Fondo
        cmd.Parameters.Add("@Mejor_Tiempo_Maraton", SqlDbType.VarChar).Value = Mejor_Tiempo_Maraton
        cmd.Parameters.Add("@Mejor_Tiempo_Obstaculos", SqlDbType.VarChar).Value = Mejor_Tiempo_Obstaculos
        cmd.Parameters.Add("@Mejor_Tiempo_Marcha", SqlDbType.VarChar).Value = Mejor_Tiempo_Marcha
        cmd.Parameters.Add("@Mejor_Tiempo_Velocidad", SqlDbType.VarChar).Value = Mejor_Tiempo_Velocidad
        cmd.Parameters.Add("@Mejor_Tiempo_Medio_Fondo", SqlDbType.VarChar).Value = Mejor_Tiempo_Medio_Fondo
        cmd.Parameters.Add("@Clasificación_Tiempo_Calle", SqlDbType.Int).Value = Clasificación_Tiempo_Calle  '           
        cmd.Parameters.Add("@Clasificación_Salto", SqlDbType.Int).Value = Clasificación_Salto
        cmd.Parameters.Add("@Clasificación_Lanzamiento", SqlDbType.Int).Value = Clasificación_Lanzamiento
        cmd.Parameters.Add("@Clasificación_Cross_Country", SqlDbType.Int).Value = Clasificación_Cross_Country
        cmd.Parameters.Add("@Clasificación_Fondo", SqlDbType.Int).Value = Clasificación_Fondo
        cmd.Parameters.Add("@Clasificación_Maraton", SqlDbType.Int).Value = Clasificación_Maraton
        cmd.Parameters.Add("Clasificación_Marcha", SqlDbType.Int).Value = Clasificación_Marcha
        cmd.Parameters.Add("Clasificación_Medio_Fondo", SqlDbType.Int).Value = Clasificación_Medio_Fondo
        cmd.Parameters.Add("Clasificación_Obstaculos", SqlDbType.Int).Value = Clasificación_Obstaculos
        cmd.Parameters.Add("Clasificación_Velocidad", SqlDbType.Int).Value = Clasificación_Velocidad
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub ActualizarResultado(ByVal resultado As CeResultadoParcial)

        ActualizarResultado(resultado.id_resultado,
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

    Public Function NuevoCodigoResultado() As String
        cn = objcon.Conectar
        cn.Open()
        da = New SqlDataAdapter("ULTIMORESULTADO", cn)
        Return da.SelectCommand.ExecuteScalar()
    End Function

    Public Sub EliminarResultado(ByVal codigo As Integer)
        Try
            cn = objcon.Conectar
            Dim cmd = New SqlCommand("EliminarResultado", cn)
            cmd.CommandType = CommandType.StoredProcedure 'tipo de comando
            cmd.Parameters.Add("@Id_Resultado_Parcial", SqlDbType.Int).Value = codigo
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            'MsgBox("La Competencia ha sido eliminada correctamente")
        Catch ex As Exception
            MsgBox("Error al eliminar el resultado" + ex.ToString)
        End Try
    End Sub
End Class
