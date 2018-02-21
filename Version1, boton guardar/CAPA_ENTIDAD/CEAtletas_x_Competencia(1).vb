Public Class CEAtletas_x_Competencia

    Dim atleta As New CEAtletas
    Dim competencia As New CECompetencias
    Dim resultado As New CeResultadoParcial

    Private _Id_atleta_x_competencia As Integer
    Public Property Id_atleta_x_competencia() As Integer
        Get
            Return _Id_atleta_x_competencia
        End Get
        Set(value As Integer)
            _Id_atleta_x_competencia = value
        End Set
    End Property

    Private _id_competencia As Integer
    Public Property id_competencia() As Integer
        Get
            Return _id_competencia
        End Get
        Set(value As Integer)
            _id_competencia = value
        End Set
    End Property

    Private _id_atleta As Integer
    Public Property id_atleta() As Integer
        Get
            Return _id_atleta
        End Get
        Set(value As Integer)
            _id_atleta = value
        End Set
    End Property

    Private _id_resultado_atleta As Integer
    Public Property id_resultado_atleta() As Integer
        Get
            Return _id_resultado_atleta
        End Get
        Set(value As Integer)
            _id_resultado_atleta = value
        End Set
    End Property

    Private _id_resultado_competencia As Integer
    Public Property id_resultado_competencia() As Integer
        Get
            Return _id_resultado_competencia
        End Get
        Set(value As Integer)
            _id_resultado_competencia = value
        End Set
    End Property

    'COMPETENCIA

    Private _Nombre_competencia As String
    Public Property Nombre_competencia() As String
        Get
            Return _Nombre_competencia
        End Get
        Set(ByVal value As String)
            _Nombre_competencia = value
        End Set
    End Property

    Private _lugar_competencia As String
    Public Property lugar_competencia() As String
        Get
            Return _lugar_competencia
        End Get
        Set(ByVal value As String)
            _lugar_competencia = value
        End Set
    End Property

    Private _distancia As Integer
    Public Property distancia() As Integer
        Get
            Return _distancia
        End Get
        Set(value As Integer)
            _distancia = value
        End Set
    End Property

    Private _fecha_inicio As Date
    Public Property fecha_inicio() As Date
        Get
            Return _fecha_inicio
        End Get
        Set(ByVal value As Date)
            _fecha_inicio = value
        End Set
    End Property

    Private _hora_inicio As String
    Public Property hora_inicio() As String
        Get
            Return _hora_inicio
        End Get
        Set(value As String)
            _hora_inicio = value
        End Set
    End Property


    Private _id_provincia As Integer
    Public Property id_provincia() As Integer
        Get
            Return _id_provincia
        End Get
        Set(ByVal value As Integer)
            _id_provincia = value
        End Set
    End Property

    Private _nombre_provincia As String
    Public Property nombre_provincia() As String
        Get
            Return _nombre_provincia
        End Get
        Set(ByVal value As String)
            _nombre_provincia = value
        End Set
    End Property

    Private _id_localidad As Integer
    Public Property id_localidad() As Integer
        Get
            Return _id_localidad
        End Get
        Set(ByVal value As Integer)
            _id_localidad = value
        End Set
    End Property

    Private _nombre_localidad As String
    Public Property nombre_localidad() As String
        Get
            Return _nombre_localidad
        End Get
        Set(ByVal value As String)
            _nombre_localidad = value
        End Set
    End Property

    Private _otra As String
    Public Property otra() As String
        Get
            Return _otra
        End Get
        Set(ByVal value As String)
            _otra = value
        End Set
    End Property

    Private _id_disciplina As Integer
    Public Property id_disciplina() As Integer
        Get
            Return _id_disciplina
        End Get
        Set(ByVal value As Integer)
            _id_disciplina = value
        End Set
    End Property

    Private _id_prueba As Integer
    Public Property id_prueba() As Integer
        Get
            Return _id_prueba
        End Get
        Set(ByVal value As Integer)
            _id_prueba = value
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

    Private _Apellido_Juez1 As String
    Public Property Apellido_Juez1() As String
        Get
            Return _Apellido_Juez1
        End Get
        Set(ByVal value As String)
            _Apellido_Juez1 = value
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

    Private _Apellido_Juez2 As String
    Public Property Apellido_Juez2() As String
        Get
            Return _Apellido_Juez2
        End Get
        Set(ByVal value As String)
            _Apellido_Juez2 = value
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

    Private _Apellido_Juez3 As String
    Public Property Apellido_Juez3() As String
        Get
            Return _Apellido_Juez3
        End Get
        Set(ByVal value As String)
            _Apellido_Juez3 = value
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

    ' ATLETA

    'Private _Nombre_atleta As String
    'Public Property Nombre_atleta() As String
    '    Get
    '        Return _Nombre_atleta
    '    End Get
    '    Set(ByVal value As String)
    '        _Nombre_atleta = value
    '    End Set
    'End Property

    'Private _Apellido_atleta As String
    'Public Property Apellido_atleta() As String
    '    Get
    '        Return _Apellido_atleta
    '    End Get
    '    Set(ByVal value As String)
    '        _Apellido_atleta = value
    '    End Set
    'End Property

    'Private _dni_atleta As String
    'Public Property dni_atleta() As String
    '    Get
    '        Return _dni_atleta
    '    End Get
    '    Set(ByVal value As String)
    '        _dni_atleta = value
    '    End Set
    'End Property

    'Private _fecha_nacimiento As Date
    'Public Property fecha_nacimiento() As Date
    '    Get
    '        Return _fecha_nacimiento
    '    End Get
    '    Set(ByVal value As Date)
    '        _fecha_nacimiento = value
    '    End Set
    'End Property

    'Private _nacionalidad As String
    'Public Property nacionalidad() As String
    '    Get
    '        Return _nacionalidad
    '    End Get
    '    Set(ByVal value As String)
    '        _nacionalidad = value
    '    End Set
    'End Property



    'Private _domicilio As String
    'Public Property domicilio() As String
    '    Get
    '        Return _domicilio
    '    End Get
    '    Set(ByVal value As String)
    '        _domicilio = value
    '    End Set
    'End Property

    'Private _barrio As String
    'Public Property barrio() As String
    '    Get
    '        Return _barrio
    '    End Get
    '    Set(value As String)
    '        _barrio = value
    '    End Set
    'End Property

    'Private _telefono_fijo As String
    'Public Property telefono_fijo() As String
    '    Get
    '        Return _telefono_fijo
    '    End Get
    '    Set(ByVal value As String)
    '        _telefono_fijo = value
    '    End Set
    'End Property

    'Private _telefono_celular As String
    'Public Property telefono_celular() As String
    '    Get
    '        Return _telefono_celular
    '    End Get
    '    Set(ByVal value As String)
    '        _telefono_celular = value
    '    End Set
    'End Property

    'Private _e_mail As String
    'Public Property e_mail() As String
    '    Get
    '        Return _e_mail
    '    End Get
    '    Set(ByVal value As String)
    '        _e_mail = value
    '    End Set
    'End Property

    'Private _contacto_emergencia As String

    'Public Property contacto_emergencia() As String
    '    Get
    '        Return _contacto_emergencia
    '    End Get
    '    Set(ByVal value As String)
    '        _contacto_emergencia = value
    '    End Set
    'End Property

    'Private _federado As String

    'Public Property federado() As String
    '    Get
    '        Return _federado
    '    End Get
    '    Set(ByVal value As String)
    '        _federado = value
    '    End Set
    'End Property

    'Private _id_club_federacion As Integer
    'Public Property id_club_federacion() As Integer
    '    Get
    '        Return _id_club_federacion
    '    End Get
    '    Set(value As Integer)
    '        _id_club_federacion = value
    '    End Set
    'End Property

    'Private _otra_institucion As String
    'Public Property otra_institucion() As String
    '    Get
    '        Return _otra_institucion
    '    End Get
    '    Set(value As String)
    '        _otra_institucion = value
    '    End Set
    'End Property

    'Private _dorsal As Integer
    'Public Property dorsal() As Integer
    '    Get
    '        Return _dorsal
    '    End Get
    '    Set(value As Integer)
    '        _dorsal = value
    '    End Set
    'End Property

    'Private _estado_atleta As String
    'Public Property estado_atleta() As String
    '    Get
    '        Return _estado_atleta
    '    End Get
    '    Set(value As String)
    '        _estado_atleta = value
    '    End Set
    'End Property

    'Private _id_sexo As Integer

    'Public Property id_sexo() As Integer
    '    Get
    '        Return _id_sexo
    '    End Get
    '    Set(ByVal value As Integer)
    '        _id_sexo = value
    '    End Set
    'End Property

    'Public ReadOnly Property Edad As Int32
    '    Get
    '        Return DateDiff(DateInterval.Year, fecha_nacimiento, DateTime.Now)
    '    End Get
    'End Property

    'Private _fecha_nacimiento As Date
    'Public Property fecha_nacimiento() As Date
    '    Get
    '        Return _fecha_nacimiento
    '    End Get
    '    Set(ByVal value As Date)
    '        _fecha_nacimiento = value
    '    End Set
    'End Property
   

   
End Class

' definicion y propiedad de la clave foranea
'Private _ListaAtletas As List(Of CEAtletas_x_Competencia)
'Public Property ListaAtletas() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _ListaAtletas
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _ListaAtletas = value
'    End Set
'End Property

'Private _Lista_Calle As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Calle() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Calle
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Calle = value
'    End Set
'End Property

'Private _Lista_Cross_Country As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Cross_Country() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Cross_Country
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Cross_Country = value
'    End Set
'End Property

'Private _Lista_Fondo As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Fondo() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Fondo
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Fondo = value
'    End Set
'End Property

'Private _Lista_Lanzamiento As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Lanzamiento() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Lanzamiento
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Lanzamiento = value
'    End Set
'End Property

'Private _Lista_Maraton As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Maraton() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Maraton
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Maraton = value
'    End Set
'End Property

'Private _Lista_Marcha As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Marcha() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Marcha
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Marcha = value
'    End Set
'End Property

'Private _Lista_Medio_Fondo As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Medio_Fondo() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Medio_Fondo
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Medio_Fondo = value
'    End Set
'End Property

'Private _Lista_Obstaculos As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Obstaculos() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Obstaculos
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Obstaculos = value
'    End Set
'End Property

'Private _Lista_Salto As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Salto() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Salto
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Salto = value
'    End Set
'End Property

'Private _Lista_Velocidad As List(Of CEAtletas_x_Competencia)
'Public Property Lista_Velocidad() As List(Of CEAtletas_x_Competencia)
'    Get
'        Return _Lista_Velocidad
'    End Get
'    Set(value As List(Of CEAtletas_x_Competencia))
'        _Lista_Velocidad = value
'    End Set
'End Property



'End Class
