Public Class CEResultados_x_Competencia

    Private _id_resultado_x_competencia As Integer

    Public Property id_resultado_x_competencia() As Integer
        Get
            Return _id_resultado_x_competencia
        End Get
        Set(ByVal value As Integer)
            _id_resultado_x_competencia = value
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

    Private _valor As String
    Public Property valor() As String
        Get
            Return _valor
        End Get
        Set(ByVal value As String)
            _valor = value
        End Set
    End Property

    Private _posicion As Integer
    Public Property posicion() As Integer
        Get
            Return _posicion
        End Get
        Set(ByVal value As Integer)
            _posicion = value
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

    Private _id_juez As Integer
    Public Property id_juez() As Integer
        Get
            Return _id_juez
        End Get
        Set(ByVal value As Integer)
            _id_juez = value
        End Set
    End Property

    Private _dorsal As Integer
    Public Property dorsal() As Integer
        Get
            Return _dorsal
        End Get
        Set(ByVal value As Integer)
            _dorsal = value
        End Set
    End Property
End Class
