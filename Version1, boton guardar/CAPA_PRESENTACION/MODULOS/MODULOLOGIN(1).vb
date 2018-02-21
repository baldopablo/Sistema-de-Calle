﻿Imports System.Data.Sql
Imports System.Data.SqlClient

Module MODULOLOGIN
    Public cn As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader

    Sub New()
        Try
            cn = New SqlConnection("Data Source=VALE\VALERIA;Initial catalog= TESIS ATLETISMO 2016; Integrated Security=True")
            cn.Open()

        Catch ex As Exception
            MessageBox.Show("error en la conexion: " + ex.ToString)
        End Try
    End Sub

    Function usuarioRegistrado(ByVal nombreUsuario As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("Select * from Usuario where nombre_usuario='" & nombreUsuario & "'", cn)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    Function contraseña(ByVal nombreUsuario As String) As String
        Dim resultado As String = ""
        Dim resultado1 As String = ""
        Try
            enunciado = New SqlCommand("Select Contraseña,Id_Perfil_Usuario from Usuario where nombre_Usuario='" & nombreUsuario & "'", cn)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("Contraseña")
                resultado1 = respuesta.Item("Id_Perfil_Usuario")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    'ESTO ES LO NUEVO
    Function perfil(ByVal nombreUsuario As String) As Integer
        Dim resultado As Integer = 1

        Try
            enunciado = New SqlCommand("Select Id_Perfil_Usuario from Usuario where nombre_Usuario='" & nombreUsuario & "'", cn)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("Id_Perfil_Usuario")

            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

End Module
