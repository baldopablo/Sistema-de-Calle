Imports System.Data.SqlClient
Imports CAPA_ENTIDAD
Imports System.Collections.Generic

Public Class DAOAtletas_x_Competencia
    Dim objcon As New conexion
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim ds As New DataSet

    Public Sub Nuevo_Atleta_x_Competencia(ByRef ObjAxC As CEAtletas_x_Competencia) ' insertar
        cn = objcon.Conectar
        Try
            cn.Open() 'se ubica siempre antes de ejecutar el comando
            da = New SqlDataAdapter("Nuevo_Atleta_x_Competencia", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand.Parameters
                .Add("@Id_Atleta_X_Competencia", SqlDbType.Int).Value = ObjAxC.Id_atleta_x_competencia
                .Add("@Id_Atleta", SqlDbType.Int).Value = ObjAxC.id_atleta
                .Add("@Id_Competencia", SqlDbType.Int).Value = ObjAxC.id_competencia
                .Add("@Id_Resultados_X_Atleta", SqlDbType.Int).Value = ObjAxC.id_resultado_atleta
                .Add("@Id_Resultados_X_Competencia", SqlDbType.Int).Value = ObjAxC.id_resultado_competencia
            End With
            da.SelectCommand.ExecuteNonQuery()  'inserta los valores
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.CommandText = "select @@IDENTITY"
            Dim ds As DataSet = New DataSet
            da.Fill(ds)
            ObjAxC.id_competencia = ds.Tables(0)(0)(0)
        Catch ex As Exception
            MsgBox("No se pudo crear el nuevo registro", MsgBoxStyle.Critical)
        Finally
            da.Dispose()
            cn.Dispose()
        End Try
    End Sub

    Public Function Nuevo_Codigo_Atleta_x_Competencia() As String
        cn = objcon.Conectar
        cn.Open()
        da = New SqlDataAdapter("Nuevo_Codigo_Atleta_x_Competencia", cn)
        Return da.SelectCommand.ExecuteScalar()
    End Function
    'FUNCION QUE LLENA EL DATAGRID FINAL DE CROSS COUNTRY
    Public Function Planilla_Final_Cross_Country() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Final_Cross_Country", cn)
        da.Fill(ds, "Planilla_Final_Cross_Country")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Lanzamiento() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Lanzamiento", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Lanzamiento")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Salto() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Salto", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Salto")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Obstaculos() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Obstaculos", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Obstaculos")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Velocidad_Serie_Unica() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Velocidad_Serie_Unica", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Velocidad_Serie_Unica")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Cross_Country() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Cross_Country", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Cross_Country")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Fondo() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Fondo", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Fondo")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Medio_Fondo() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Medio_Fondo", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Medio_Fondo")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Marcha() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Marcha", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Marcha")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    'FUNCION QUE LLENA EL DATAGRID FINAL DE CALLE
    Public Function Planilla_Resultado_Final_Calle() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Calle", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Calle")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Planilla_Resultado_Final_Maraton() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Planilla_Resultado_Final_Maraton", cn)
        da.Fill(ds, "Planilla_Resultado_Final_Maraton")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Calle() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Calle", cn)
        da.Fill(ds, "Ultimo Registro Atleta por Competencia Calle")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Velocidad() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Velocidad", cn)
        da.Fill(ds, "Ultimo_Registro_Atleta_x_Competencia_Velocidad")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Obstaculos() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Obstaculos", cn)
        da.Fill(ds, "Ultimo_Registro_Atleta_x_Competencia_Obstaculos")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Cross_Country() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Cross_Country", cn)
        da.Fill(ds, "Ultimo_Registro_Atleta_x_Competencia_Cross_Country")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Maraton() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Maraton", cn)
        da.Fill(ds, "Ultimo Registro Atleta por Competencia Maraton")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Marcha() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Marcha", cn)
        da.Fill(ds, "Ultimo Registro Atleta por Competencia Marcha")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Fondo() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Fondo", cn)
        da.Fill(ds, "Ultimo_Registro_Atleta_x_Competencia_Fondo")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Medio_Fondo() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Medio_Fondo", cn)
        da.Fill(ds, "Ultimo_Registro_Atleta_x_Competencia_Medio_Fondo")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Lanzamiento() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Lanzamiento", cn)
        da.Fill(ds, "Ultimo Registro Atleta por Competencia Lanzamiento")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Ultimo_Registro_Atleta_x_Competencia_Salto() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Ultimo_Registro_Atleta_x_Competencia_Salto", cn)
        da.Fill(ds, "Ultimo Registro Atleta por Competencia Salto")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    'editar
    Public Sub Actualizar_Atleta_x_Competencia(ByVal id_atleta_x_competencia As Integer,
                             ByVal id_atleta As Integer,
                             ByVal id_competencia As Integer,
                              ByRef id_resultado_x_atleta As Integer,
                             ByVal id_resultado_x_competencia As Integer
                            )
        cn = objcon.Conectar
        cmd = New SqlCommand("Actualizar_Atleta_x_Competencia", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Id_Atleta_X_Competencia", SqlDbType.Int).Value = id_atleta_x_competencia
        cmd.Parameters.Add("@Id_Atleta", SqlDbType.Int).Value = id_atleta
        cmd.Parameters.Add("@Id_Competencia", SqlDbType.Int).Value = id_competencia
        cmd.Parameters.Add("@Id_Resultados_X_Atleta", SqlDbType.Int).Value = id_resultado_x_atleta
        cmd.Parameters.Add("@Id_Resultados_X_Competencia", SqlDbType.Int).Value = id_resultado_x_competencia
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub Actualizar_Atleta_x_Competencia(ByVal atletas_x_competencia As CEAtletas_x_Competencia)
        Actualizar_Atleta_x_Competencia(atletas_x_competencia.Id_atleta_x_competencia,
                       atletas_x_competencia.id_atleta,
                       atletas_x_competencia.id_competencia,
                       atletas_x_competencia.id_resultado_competencia,
                       atletas_x_competencia.id_resultado_atleta)
    End Sub

    Public Sub Eliminar_Atleta_x_Competencia(ByVal cod As Integer)
        Try
            cn = objcon.Conectar
            cmd = New SqlCommand("Eliminar_Atleta_x_Competencia", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Id_Atleta_X_Competencia", SqlDbType.Int).Value = cod
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error" + ex.ToString)
        End Try
    End Sub 'eliminar

    Public Function Editar_ListadoTodasCompetencias() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("Editar_ListadoTodasCompetencias", cn) ' NOMBRE DEL PROCEDIMIENTO ALMACENADO
        da.Fill(ds, "Editar_ListadoTodasCompetencias") 'ELEGIMOS UN NOMBRE O ALIAS
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    Public Function Editar_ListadoTodasCompetencias_DTO() As List(Of CEAtletas_x_Competencia)
        Dim miDS = Editar_ListadoTodasCompetencias() ' nombre del procedimiento que llena la lista de atletas de la bd
        Dim vector_Editar_ListadoTodasCompetencias = New List(Of CEAtletas_x_Competencia)()
        For Each row In miDS.Tables(0).Rows
            Dim axc As CEAtletas_x_Competencia = New CEAtletas_x_Competencia()

            'axc.Id_atleta_x_competencia = row("Id_Atleta_X_Competencia")

            axc.Nombre_competencia = row("Nombre")
            axc.lugar_competencia = ("Lugar")
            axc.id_provincia = row("Id_Provincia")
            'axc.nombre_provincia = row("Nombre_Provincia")
            axc.id_localidad = row("Id_Localidad")
            'axc.nombre_localidad = row("Nombre_Localidad")
            axc.distancia = row("Distancia")
            axc.fecha_inicio = row("Fecha")
            axc.hora_inicio = row("Hora")
            axc.id_disciplina = row("Id_Disciplina")
            axc.id_prueba = row("Id_Prueba")
            axc.otra = row("Otra")
            axc.juez1 = row("Id_Juez")
            'axc.Apellido_Juez1 = row("Apellido_Juez")
            axc.juez2 = row("Id_Juez")
            'axc.Apellido_Juez2 = row("Apellido_Juez")
            axc.juez3 = row("Id_Juez")
            ' axc.Apellido_Juez3 = row("Apellido_Juez")
            axc.id_usuario = row("Id_Usuario")
            axc.Estado_Competencia = row("Estado_Competencia")
            axc.id_competencia = row("Id_Competencia")
            'axc.id_atleta = row("Id_Atleta")
            'axc.Nombre_atleta = row("Nombre_Atleta")
            'axc.Apellido_atleta = row("Apellido_Atleta")

            ' ver como ponemos la edad del atleta
            'axc.edad = row("Edad")

            'axc.id_sexo = row("Id_Sexo")
            'axc.otra_institucion = row("Otra_Institución")
            'axc.dorsal = row("Dorsal")
            'axc.id_resultado_competencia = row("Id_Resultados_X_Competencia")
            vector_Editar_ListadoTodasCompetencias.Add(axc)
        Next
        Return vector_Editar_ListadoTodasCompetencias
    End Function

    'CREACION DE LAS FUNCIONES QUE SUPUESTAMENTE LLENA EL DATAGRID DE LAS PLANILLAS SEGUN ID COMPETENCIA

    Public Function ListadoTodasCompetencias() As DataSet
        Dim ds As New DataSet
        cn = objcon.Conectar
        da = New SqlDataAdapter("ListadoTodasCompetencias", cn)
        da.Fill(ds, "Todas las Competencias")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function

    'LISTADO DE COMPETENCIAS
    Public Function ListadoDeCompetenciasDTO() As List(Of CECompetencias)
        Dim miDS = ListadoTodasCompetencias()
        Dim vectorDeCompetencia = New List(Of CECompetencias)()
        For Each row In miDS.Tables(0).Rows
            Dim com As CECompetencias = New CECompetencias()
            com.distancia = row("Distancia")
            com.fecha_inicio = row("Fecha")
            com.hora_inicio = row("Hora")
            com.id_competencia = row("Id_Competencia")
            com.id_disciplina = row("Id_Disciplina")
            com.id_localidad = row("Id_Localidad")
            com.id_provincia = row("Id_Provincia")
            com.id_prueba = row("Id_Prueba")
            com.lugar_competencia = row("Lugar")
            com.Nombre_competencia = row("Nombre")
            com.otra = row("Otra")
            com.juez1 = row("Id_Juez")
            com.juez2 = row("Id_Juez")
            com.juez3 = row("Id_Juez")
            com.id_usuario = row("Id_Usuario")
            com.Estado_Competencia = row("Estado_Competencia")

            vectorDeCompetencia.Add(com)
        Next
        Return vectorDeCompetencia
    End Function

    'Function Lista_Atletas(Id_Competencia As Integer) As DataSet
    '    Dim ds As New DataSet
    '    cn = objcon.Conectar
    '    'genero un comando con el nombre del store procedure
    '    Dim cmd = New SqlCommand("Lista_Atletas", cn)
    '    'genero el paramatero que le voy a pasar al SP
    '    Dim parametro1 = New SqlParameter("@Id_Competencia", Id_Competencia)
    '    cmd.CommandType = CommandType.StoredProcedure
    '    'Agrego los parametros
    '    cmd.Parameters.Add(parametro1)
    '    da = New SqlDataAdapter(cmd)
    '    da.Fill(ds, "Lista_Atletas")
    '    Return ds
    '    ds.Dispose()
    '    da.Dispose()
    '    cn.Dispose()
    'End Function

    'Dim objcon As New conexion
    'Dim cn As SqlConnection
    'Dim da As SqlDataAdapter
    'Dim cmd As SqlCommand

    Function Lista_Atletas(Id_Competencia As Integer) As DataSet
        ds = New DataSet
        Dim sql As String
        sql = "SELECT dbo.Atleta_X_Competencia.Id_Atleta,dbo.Atleta.Nombre_Atleta,dbo.Atleta.Fecha_Nacimiento,dbo.Club_Federación.Id_Club_Federación,CONVERT(int, DATEDIFF(d, Atleta.Fecha_Nacimiento, GETDATE())/365.25)as Edad,dbo.Atleta.Apellido_Atleta, dbo.Resultados_X_Competencia.Dorsal,dbo.Sexo.Id_Sexo, dbo.Atleta.Otra_Institución,dbo.Atleta_X_Competencia.Id_Resultados_X_Competencia FROM dbo.Atleta INNER JOIN dbo.Sexo ON dbo.Atleta.Id_Sexo = dbo.Sexo.Id_sexo  inner join dbo.Club_Federación on Club_Federación.Id_Club_Federación=Atleta.Id_Club_Federación INNER JOIN dbo.Atleta_X_Competencia ON dbo.Atleta.Id_Atleta = dbo.Atleta_X_Competencia.Id_Atleta INNER JOIN dbo.Resultados_X_Competencia ON dbo.Atleta_X_Competencia.Id_Resultados_X_Competencia = dbo.Resultados_X_Competencia.Id_Resultados_X_Competencia where atleta_x_competencia.Id_Competencia=@Id_Competencia"

        'sql = "SELECT dbo.Atleta_X_Competencia.Id_Atleta,dbo.Atleta.Nombre_Atleta,dbo.Club_Federación.Id_Club_Federación,dbo.Atleta.Fecha_Nacimiento,CONVERT(int, DATEDIFF(d, Atleta.Fecha_Nacimiento, GETDATE())/365.25)as Edad,dbo.Atleta.Apellido_Atleta, dbo.Resultados_X_Competencia.Dorsal,dbo.Sexo.Id_Sexo, dbo.Atleta.Otra_Institución,dbo.Atleta_X_Competencia.Id_Resultados_X_Competencia FROM dbo.Atleta INNER JOIN dbo.Sexo ON dbo.Atleta.Id_Sexo = dbo.Sexo.Id_sexo  inner join dbo.Club_Federación on Club_Federación.Id_Club_Federación=Atleta.Id_Club_Federación INNER JOIN dbo.Atleta_X_Competencia ON dbo.Atleta.Id_Atleta = dbo.Atleta_X_Competencia.Id_Atleta INNER JOIN dbo.Resultados_X_Competencia ON dbo.Atleta_X_Competencia.Id_Resultados_X_Competencia = dbo.Resultados_X_Competencia.Id_Resultados_X_Competencia where atleta_x_competencia.Id_Competencia=@Id_Competencia"
        cn = objcon.Conectar
        'genero un comando con el nombre del store procedure
        Dim cmd = New SqlCommand(sql, cn)
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        'genero el paramatero que le voy a pasar al SP
        Dim parametro1 = New SqlParameter("@Id_Competencia", Id_Competencia)
        'cmd.CommandType = CommandType.StoredProcedure
        'Agrego los parametros
        cmd.Parameters.Add(parametro1)
        da = New SqlDataAdapter(cmd)

        da.Fill(ds)
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function
End Class
