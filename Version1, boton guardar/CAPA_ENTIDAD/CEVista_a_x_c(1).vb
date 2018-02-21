Public Class CEVista_a_x_c

    Private _id_atleta As Integer

    Public Property id_atleta() As Integer
        Get
            Return _id_atleta
        End Get
        Set(ByVal value As Integer)
            _id_atleta = value
        End Set
    End Property

    Private _Nombre_atleta As String
    Public Property Nombre_atleta() As String
        Get
            Return _Nombre_atleta
        End Get
        Set(ByVal value As String)
            _Nombre_atleta = value
        End Set
    End Property

    Private _Apellido_atleta As String
    Public Property Apellido_atleta() As String
        Get
            Return _Apellido_atleta
        End Get
        Set(ByVal value As String)
            _Apellido_atleta = value
        End Set
    End Property

   

    Private _fecha_nacimiento As Date
    Public Property fecha_nacimiento() As Date
        Get
            Return _fecha_nacimiento
        End Get
        Set(ByVal value As Date)
            _fecha_nacimiento = value
        End Set
    End Property

   

  

    Private _id_club_federacion As Integer
    Public Property id_club_federacion() As Integer
        Get
            Return _id_club_federacion
        End Get
        Set(value As Integer)
            _id_club_federacion = value
        End Set
    End Property

    Private _otra_institucion As String
    Public Property otra_institucion() As String
        Get
            Return _otra_institucion
        End Get
        Set(value As String)
            _otra_institucion = value
        End Set
    End Property

    Private _dorsal As Integer
    Public Property dorsal() As Integer
        Get
            Return _dorsal
        End Get
        Set(value As Integer)
            _dorsal = value
        End Set
    End Property

  

    Private _id_sexo As Integer

    Public Property id_sexo() As Integer
        Get
            Return _id_sexo
        End Get
        Set(ByVal value As Integer)
            _id_sexo = value
        End Set
    End Property

    Public ReadOnly Property Edad As Int32
        Get
            Return DateDiff(DateInterval.Year, fecha_nacimiento, DateTime.Now)
        End Get
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



    Private _id_competencia As Integer
    Public Property id_competencia() As Integer
        Get
            Return _id_competencia
        End Get
        Set(ByVal value As Integer)
            _id_competencia = value
        End Set
    End Property

    Private _id_resultado_x_competencia As Integer

    Public Property id_resultado_x_competencia() As Integer
        Get
            Return _id_resultado_x_competencia
        End Get
        Set(ByVal value As Integer)
            _id_resultado_x_competencia = value
        End Set
    End Property


    Private _Id_atleta_x_competencia As Integer
    Public Property Id_atleta_x_competencia() As Integer
        Get
            Return _Id_atleta_x_competencia
        End Get
        Set(value As Integer)
            _Id_atleta_x_competencia = value
        End Set
    End Property
End Class
