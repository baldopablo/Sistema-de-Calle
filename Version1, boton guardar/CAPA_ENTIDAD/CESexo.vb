Public Class CESexo
    Private _id_sexo As Integer

    Public Property id_sexo() As Integer
        Get
            Return _id_sexo
        End Get
        Set(ByVal value As Integer)
            _id_sexo = value
        End Set
    End Property

    Private _Nombre_Sexo As String
    Public Property Nombre_Sexo() As String
        Get
            Return _Nombre_Sexo
        End Get
        Set(ByVal value As String)
            _Nombre_Sexo = value
        End Set
    End Property
End Class
