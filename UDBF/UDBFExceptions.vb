Public Enum ErrorType
    Insert
    Update
    Delete
    Run
    Query
End Enum
Public Class UDBFException
    Inherits Exception
    Private iErrorType As ErrorType
    Public Property udbfErrorType As ErrorType
        Get
            Return iErrorType
        End Get
        Set(ByVal value As ErrorType)
            iErrorType = value
        End Set
    End Property
    Private iErrorCode As Integer
    Public Property ErrorCode As Integer
        Get
            Return iErrorCode

        End Get
        Set(ByVal value As Integer)
            iErrorCode = value
        End Set
    End Property
    Private iErrorMessage As String
    Public Property ErrorMesssage As String
        Get
            Return iErrorMessage

        End Get
        Set(ByVal value As String)
            iErrorMessage = value
        End Set
    End Property
    Public Sub New(ByVal pError As String)
        Me.ErrorMesssage = ErrorCode


    End Sub
End Class
