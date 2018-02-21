﻿Imports System.Data.SqlClient
Imports CAPA_ENTIDAD

Public Class DAOClubFederacion

    Dim objcon As New conexion
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand

    'funcion que permite mostrar una lista de CLUBES
    Public Function listadoclubes() As DataSet
        Dim ds As New DataSet
        cn = objcon.conectar
        da = New SqlDataAdapter("LISTADOCLUBES", cn)
        da.Fill(ds, "CLUBES")
        Return ds
        ds.Dispose()
        da.Dispose()
        cn.Dispose()
    End Function


    Public Function ListadoDeClubesDTO() As List(Of CEClubFederacion)
        Dim miDS = listadoclubes()
        Dim vectorDeClubes = New List(Of CEClubFederacion)()
        For Each row In miDS.Tables(0).Rows
            Dim club As CEClubFederacion = New CEClubFederacion()
            club.direccion = row("Dirección")
            club.e_mail = row("E_mail")
            club.id_club_federacion = row("Código")
            'club.id_provincia = row("Provincia")
            club.Nombre_club = row("Nombre")
            club.telefono_celular = row("Celular")
            club.telefono_fijo = row("Fijo")
            vectorDeClubes.Add(club)
        Next
        Return vectorDeClubes
    End Function

    'funcion que permita autogenerar el codigo del club 
    Public Function nuevoCodigoclub() As String
        cn = objcon.Conectar
        cn.Open()
        da = New SqlDataAdapter("ULTIMOCLUB", cn)
        Return da.SelectCommand.ExecuteScalar()
    End Function

    'procedimiento que insertar un nuevo club
    Public Sub nuevoclub(ByVal objc As CEClubFederacion)
        cn = objcon.Conectar
        Try
            cn.Open()
            da = New SqlDataAdapter("NUEVOCLUB", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand.Parameters
                .Add("@id_club_federacion", SqlDbType.Int).Value = objc.id_club_federacion
                .Add("@nombre_club", SqlDbType.VarChar).Value = objc.Nombre_club
                '.Add("@id_provincia", SqlDbType.Int).Value = objc.id_provincia
                .Add("@direccion", SqlDbType.VarChar).Value = objc.direccion
                .Add("@telefono_fijo", SqlDbType.VarChar).Value = objc.telefono_fijo
                .Add("@telefono_celular", SqlDbType.VarChar).Value = objc.telefono_celular
                .Add("@e_mail", SqlDbType.VarChar).Value = objc.e_mail
            End With
            da.SelectCommand.ExecuteNonQuery()
            'MsgBox("Club/Federación registrado correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Error al registrar al Club/Federación", MsgBoxStyle.Critical, "Error")
        Finally
            da.Dispose()
            cn.Dispose()
        End Try
    End Sub


    ' MessageBox.Show("La Competencia ha sido registrada correctamente", "Creando Competencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '' Me.Close()
    '    Catch ex As Exception
    '        MsgBox("Error al registrar la Competencia", MsgBoxStyle.Critical, "Error")
    '        Exit Sub



    Public Sub actualizarClub(ByVal id_club As Integer,
                              ByVal nombre As String,
                              ByVal direccion As String,
                              ByVal telefono_fijo As String,
                              ByVal telefono_celular As String,
                              ByVal e_mail As String)
        cn = objcon.Conectar
        cmd = New SqlCommand("ACTUALIZARCLUB", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Id_Club_Federación", SqlDbType.Int).Value = id_club
        cmd.Parameters.Add("@Nombre_Club", SqlDbType.VarChar).Value = nombre
        cmd.Parameters.Add("@Dirección", SqlDbType.VarChar).Value = direccion
        cmd.Parameters.Add("@Teléfono_Fijo", SqlDbType.VarChar).Value = telefono_fijo
        cmd.Parameters.Add("@Teléfono_Celular", SqlDbType.VarChar).Value = telefono_celular
        cmd.Parameters.Add("@E_mail", SqlDbType.VarChar).Value = e_mail
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Sub ActualizarClub(ByVal club As CEClubFederacion)
        actualizarClub(club.id_club_federacion,
                       club.Nombre_club,
                       club.direccion,
                       club.telefono_fijo,
                       club.telefono_celular,
                       club.e_mail)
    End Sub

    Public Sub eliminarclub(ByVal cod As Integer)
        Try
            cn = objcon.Conectar
            cmd = New SqlCommand("ELIMINARCLUB", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@id_club_federacion", SqlDbType.Int).Value = cod
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error al eliminar al Club" + ex.ToString)
        End Try
    End Sub
End Class



