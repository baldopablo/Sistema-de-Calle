Public Class Form1
    Dim datos As New BaseDataContext

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dg_lista_usuario.Columns.Clear()
        cargar()

    End Sub

    Sub cargar()
        Dg_lista_usuario.AutoGenerateColumns = False
        Dim lista = (From c In datos.Usuario Select c.Id_Usuario, c.Nombre_Usu).ToList

        Dg_lista_usuario.Columns.Add("Id_Usuario", "Id_Usuario")
        Dg_lista_usuario.Columns.Add("Nombre_Usu", "nombre")
        

        Dg_lista_usuario.Columns(0).DataPropertyName = "Id_Usuario"
        Dg_lista_usuario.Columns(1).DataPropertyName = "Nombre_usu"

        Dg_lista_usuario.DataSource = lista
    End Sub
End Class