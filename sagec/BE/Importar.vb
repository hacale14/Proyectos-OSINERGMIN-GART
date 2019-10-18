Public Class Importar

    Private _fileupload As String
    Private _filename As String
    Private _extension As String
    Private _filepath As String
    Private _consulta As String
    Private _USUARIO As String
    Private _PASSWORD As String
    Private _BASEDEDATOS As String
    Private _SERVIDOR As String
    Private _destino As DataTable

    Public ReadOnly Property Usuario() As String
        Get
            Return "sa"
        End Get
    End Property
    Public ReadOnly Property Password() As String
        Get
            Return "innova"
        End Get
    End Property
    Public ReadOnly Property BD() As String
        Get
            Return "cobranza_desa"
        End Get
    End Property
    Public ReadOnly Property Servidor() As String
        Get
            Return "servidor"
        End Get
    End Property    

    Public Property Destino() As DataTable
        Get
            Return _destino
        End Get
        Set(ByVal value As DataTable)
            _destino = value
        End Set
    End Property


    Public Property Consulta() As String
        Get
            Return _consulta
        End Get
        Set(ByVal value As String)
            _consulta = value
        End Set
    End Property

    Public Property FileUpload() As String
        Get
            Return _fileupload
        End Get
        Set(ByVal value As String)
            _fileupload = value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return _filename
        End Get
        Set(ByVal value As String)
            _filename = value
        End Set
    End Property

    Public Property Extension() As String
        Get
            Return _extension
        End Get
        Set(ByVal value As String)
            _extension = value
        End Set
    End Property

    Public Property FilePath() As String
        Get
            Return _filepath
        End Get
        Set(ByVal value As String)
            _filepath = value
        End Set
    End Property


End Class
