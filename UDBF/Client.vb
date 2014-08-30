Public Enum Database
    SQLServer
    MySQL
    Access
    Oracle
    SQLite
End Enum
Public Enum DebugModes
    Desktop
    Web
End Enum
Public Class Client
    Dim dClient As DBClient
    Private iConnString As String
    Public Property Connstring() As String
        Get
            Return iConnString
        End Get
        Set(ByVal value As String)
            iConnString = value
        End Set
    End Property
    Private iDBType As Database
    Public Property DBType() As Database
        Get
            Return iDBType
        End Get
        Set(ByVal value As Database)
            iDBType = value
        End Set
    End Property
    Private iDebugMode As DebugModes
    Public Property DebugMode As DebugModes
        Get
            Return iDebugMode
        End Get
        Set(ByVal value As DebugModes)
            iDebugMode = value
        End Set
    End Property
    Public Sub New(ByVal pConnString As String, ByVal pDBTYpe As Database)
        Me.Connstring = pConnString
        Me.DBType = pDBTYpe
        Me.DebugMode = DebugModes.Desktop

        If Me.DBType = Database.MySQL Then
            dClient = New MySQL(Connstring)
        ElseIf Me.DBType = Database.SQLServer Then
            dClient = New SQLServer(Connstring)
        ElseIf Me.DBType = Database.Oracle Then
            dClient = New Oracle(Connstring)
        ElseIf Me.DBType = Database.Access Then
            dClient = New Access(Connstring)
        ElseIf Me.DBType = Database.SQLite Then
            dClient = New SQLite(Connstring)
        End If
    End Sub
    Public Sub New(ByVal pConnString As String, ByVal pDBTYpe As Database, ByVal pDebugMode As DebugModes)
        Me.Connstring = pConnString
        Me.DBType = pDBTYpe
        Me.DebugMode = pDebugMode

        If Me.DBType = Database.MySQL Then
            dClient = New MySQL(Connstring)
        ElseIf Me.DBType = Database.SQLServer Then
            dClient = New SQLServer(Connstring, pDebugMode)
        ElseIf Me.DBType = Database.Oracle Then
            dClient = New Oracle(Connstring)
        ElseIf Me.DBType = Database.Access Then
            dClient = New Access(Connstring)
        End If
    End Sub

    Public Function Delete(ByVal Query As String) As Integer
        dClient.Delete(Query)
    End Function

    Public Sub EnableEnterKey()

    End Sub

    Public Function getMaxValue(ByVal Table As String, ByVal Field As String) As String
        Return dClient.getMaxValue(Table, Field)

    End Function

    Public Function getMaxValue(ByVal Table As String, ByVal Field As String, ByVal Where As String) As String
        Return dClient.getMaxValue(Table, Field, Where)
    End Function

    Public Function getTopValue(ByVal Table As String, ByVal Field As String) As String
        Return dClient.getTopValue(Table, Field)
    End Function

    Public Function InsertS(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer
        Return dClient.InsertS(Table, Fields, Values, Count)
    End Function

    Public Function Insert(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer
        Return dClient.Insert(Table, Fields, Values, Count)
    End Function

    Public Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As System.Windows.Forms.ComboBox) As Integer
        Return dClient.LoadComboBox(Table, strField, intField, Combo)
    End Function

    Public Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As System.Windows.Forms.ComboBox, ByVal Where As String) As Integer
        Return dClient.LoadComboBox(Table, strField, intField, Combo, Where)
    End Function

    Public Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As System.Windows.Forms.ComboBox) As Integer
        Return dClient.LoadComboBox(Table, Field, Combo)
    End Function

    Public Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As System.Windows.Forms.ComboBox, ByVal Where As String) As Integer
        Return dClient.LoadComboBox(Table, Field, Combo, Where)

    End Function
    Public Function LoadGridWin32(ByVal Query As String, ByVal Grid As System.Windows.Forms.DataGridView) As Integer
        Return dClient.LoadGridWin32(Query, Grid)
    End Function
    Public Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As System.Windows.Forms.ListBox) As Integer
        Return dClient.LoadListBox(Table, strField, intField, List)
    End Function
    Public Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As System.Windows.Forms.ListBox, ByVal Where As String) As Integer
        Return dClient.LoadListBox(Table, strField, intField, List, Where)
    End Function

    Public Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As System.Windows.Forms.ListBox) As Integer
        Return dClient.LoadListBox(Table, Field, List)
    End Function

    Public Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As System.Windows.Forms.ListBox, ByVal Where As String) As Integer
        Return dClient.LoadListBox(Table, Field, List, Where)
    End Function

    Public Function ResetCounter(ByVal Table As String) As Integer
        Return dClient.ResetCounter(Table)
    End Function

    Public Sub Run(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)
        dClient.Run(ProcedureName, Fields, Values, Count)
    End Sub

    Public Function RunCommand(ByVal Query As String) As Integer
        Return dClient.RunCommand(Query)
    End Function

    Public Sub RunProcedure(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)
        dClient.Run(ProcedureName, Fields, Values, Count)
    End Sub

    Public Function SelectDate(ByVal Query As String) As Date
        Return dClient.SelectDate(Query)
    End Function

    Public Function SelectDouble(ByVal Query As String) As Double
        Return dClient.SelectDouble(Query)
    End Function

    Public Function SelectInt(ByVal Query As String) As Integer
        Return dClient.SelectInt(Query)
    End Function

    Public Function SelectLong(ByVal Query As String) As Long
        Return dClient.SelectLong(Query)
    End Function

    Public Function SelectRows(ByVal Query As String) As System.Data.DataTable
        Return dClient.SelectRows(Query)
    End Function

    Public Function SelectSingle(ByVal Query As String) As Single
        Return dClient.SelectSingle(Query)
    End Function

    Public Function SelectString(ByVal Query As String) As String
        Return dClient.SelectString(Query)
    End Function

    Public Function Update(ByVal Query As String) As Integer
        Return dClient.Update(Query)
    End Function

    Public Sub Update(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Where As String, ByVal Count As String)
        dClient.Update(Table, Fields, Values, Where, Count)
    End Sub

    Public Sub writeXML(ByVal Path As String, ByVal Query As String)

    End Sub
    


End Class
