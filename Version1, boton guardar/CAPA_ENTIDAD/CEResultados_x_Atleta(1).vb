Public Class CEResultados_x_Atleta


    Private _id_resultado_x_atleta As Integer

    Public Property id_resultado_x_atleta() As Integer
        Get
            Return _id_resultado_x_atleta
        End Get
        Set(ByVal value As Integer)
            _id_resultado_x_atleta = value
        End Set
    End Property

    Private _id_competencia As Integer
    Public Property id_competencia() As Integer
        Get
            Return _id_competencia
        End Get
        Set(ByVal value As Integer)
            _id_competencia = value
        End Set
    End Property

    Private _id_atleta As Integer
    Public Property id_atleta() As Integer
        Get
            Return _id_atleta
        End Get
        Set(ByVal value As Integer)
            _id_atleta = value
        End Set
    End Property

    Private _id_juez1 As Integer
    Public Property id_juez1() As Integer
        Get
            Return _id_juez1
        End Get
        Set(ByVal value As Integer)
            _id_juez1 = value
        End Set
    End Property

    Private _id_juez2 As Integer
    Public Property id_juez2() As Integer
        Get
            Return _id_juez2
        End Get
        Set(ByVal value As Integer)
            _id_juez2 = value
        End Set
    End Property

    Private _id_juez3 As Integer
    Public Property id_juez3() As Integer
        Get
            Return _id_juez3
        End Get
        Set(ByVal value As Integer)
            _id_juez3 = value
        End Set
    End Property

    Private _serie As String
    Public Property serie() As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            _serie = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _valor1 As String
    Public Property valor1() As String
        Get
            Return _valor1
        End Get
        Set(ByVal value As String)
            _valor1 = value
        End Set
    End Property

    Private _valor2 As String
    Public Property valor2() As String
        Get
            Return _valor2
        End Get
        Set(ByVal value As String)
            _valor2 = value
        End Set
    End Property

    Private _valor3 As String
    Public Property valor3() As String
        Get
            Return _valor3
        End Get
        Set(ByVal value As String)
            _valor3 = value
        End Set
    End Property

    Private _mejor As String
    Public Property mejor() As String
        Get
            Return _mejor
        End Get
        Set(ByVal value As String)
            _mejor = value
        End Set
    End Property
End Class
