Public Class CECompetencias
    'ID COMPETENCIA
    Private _id_competencia As Integer '0
    Public Property id_competencia() As Integer
        Get
            Return _id_competencia
        End Get
        Set(ByVal value As Integer)
            _id_competencia = value
        End Set
    End Property
    'NOMBRE COMPETENCIA
    Private _Nombre_competencia As String '1
    Public Property Nombre_competencia() As String
        Get
            Return _Nombre_competencia
        End Get
        Set(ByVal value As String)
            _Nombre_competencia = value
        End Set
    End Property
    'LUGAR COMPETENCIA
    Private _lugar_competencia As String '2
    Public Property lugar_competencia() As String
        Get
            Return _lugar_competencia
        End Get
        Set(ByVal value As String)
            _lugar_competencia = value
        End Set
    End Property

    'DISTANCIA
    Private _distancia As Integer '3
    Public Property distancia() As Integer
        Get
            Return _distancia
        End Get
        Set(value As Integer)
            _distancia = value
        End Set
    End Property

    'FECHA
    Private _fecha_inicio As Date '4
    Public Property fecha_inicio() As Date
        Get
            Return _fecha_inicio
        End Get
        Set(ByVal value As Date)
            _fecha_inicio = value
        End Set
    End Property

    'HORA
    Private _hora_inicio As String '5
    Public Property hora_inicio() As String
        Get
            Return _hora_inicio
        End Get
        Set(value As String)
            _hora_inicio = value
        End Set
    End Property

    'NOMBRE PROVINCIA
    Private _provincia As String
    Public Property provincia() As String
        Get
            Return _provincia
        End Get
        Set(ByVal value As String)
            _provincia = value
        End Set
    End Property

    'ID PROVINCIA
    Private _id_provincia As Integer
    Public Property id_provincia() As Integer
        Get
            Return _id_provincia
        End Get
        Set(ByVal value As Integer)
            _id_provincia = value
        End Set
    End Property

    'NOMBRE LOCALIDAD
    Private _nombre_localidad As String
    Public Property nombre_localidad() As String
        Get
            Return _nombre_localidad
        End Get
        Set(ByVal value As String)
            _nombre_localidad = value
        End Set
    End Property

    'ID LOCALIDAD
    Private _id_localidad As Integer
    Public Property id_localidad() As Integer
        Get
            Return _id_localidad
        End Get
        Set(ByVal value As Integer)
            _id_localidad = value
        End Set
    End Property

    'OTRA
    Private _otra As String
    Public Property otra() As String
        Get
            Return _otra
        End Get
        Set(ByVal value As String)
            _otra = value
        End Set
    End Property

    'ID DISCIPINA
    Private _id_disciplina As Integer
    Public Property id_disciplina() As Integer
        Get
            Return _id_disciplina
        End Get
        Set(ByVal value As Integer)
            _id_disciplina = value
        End Set
    End Property

    'NOMBRE DISCIPLINA
    Private _Nombre_Disciplina As String
    Public Property Nombre_Disciplina() As String
        Get
            Return _Nombre_Disciplina
        End Get
        Set(ByVal value As String)
            _Nombre_Disciplina = value
        End Set
    End Property

    'ID PRUEBA
    Private _id_prueba As Integer
    Public Property id_prueba() As Integer
        Get
            Return _id_prueba
        End Get
        Set(ByVal value As Integer)
            _id_prueba = value
        End Set
    End Property

    'NOMBRE PRUEBA
    Private _Nombre_prueba As String
    Public Property Nombre_prueba() As String
        Get
            Return _Nombre_prueba
        End Get
        Set(ByVal value As String)
            _Nombre_prueba = value
        End Set
    End Property

    Private _juez1 As Integer
    Public Property juez1() As Integer
        Get
            Return _juez1
        End Get
        Set(value As Integer)
            _juez1 = value
        End Set
    End Property

    Private _juez2 As Integer
    Public Property juez2() As Integer
        Get
            Return _juez2
        End Get
        Set(value As Integer)
            _juez2 = value
        End Set
    End Property

    Private _juez3 As Integer
    Public Property juez3() As Integer
        Get
            Return _juez3
        End Get
        Set(value As Integer)
            _juez3 = value
        End Set
    End Property

    Private _id_usuario As Integer
    Public Property id_usuario() As Integer
        Get
            Return _id_usuario
        End Get
        Set(value As Integer)
            _id_usuario = value
        End Set
    End Property

    Private _Estado_Competencia As String
    Public Property Estado_Competencia() As String
        Get
            Return _Estado_Competencia
        End Get
        Set(value As String)
            _Estado_Competencia = value
        End Set
    End Property
End Class


