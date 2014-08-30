Public Class Oracle
    Inherits DBClient

    Private iConnString As String
    Public Property ConnString() As String
        Get
            Return iConnString
        End Get
        Set(ByVal value As String)
            iConnString = value
        End Set
    End Property
    Public Sub New()

    End Sub

    Public Sub New(ByVal pConnString As String)
        Me.ConnString = pConnString

    End Sub


    Public Overrides Function Delete(ByVal Query As String) As Integer

    End Function

    Public Overrides Sub EnableEnterKey()

    End Sub

    Public Overloads Overrides Function getMaxValue(ByVal Table As String, ByVal Field As String) As String

    End Function

    Public Overloads Overrides Function getMaxValue(ByVal Table As String, ByVal Field As String, ByVal Where As String) As String

    End Function

    Public Overrides Function getTopValue(ByVal Table As String, ByVal Field As String) As String

    End Function

    Public Overrides Function InsertS(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer

    End Function

    Public Overrides Function Insert(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer

    End Function


    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As System.Windows.Forms.ComboBox) As Integer

    End Function

    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As System.Windows.Forms.ComboBox, ByVal Where As String) As Integer

    End Function

    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As System.Windows.Forms.ComboBox) As Integer

    End Function

    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As System.Windows.Forms.ComboBox, ByVal Where As String) As Integer

    End Function

    Public Overrides Function LoadGridWin32(ByVal Query As String, ByVal Grid As System.Windows.Forms.DataGridView) As Integer

    End Function

    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As System.Windows.Forms.ListBox) As Integer

    End Function

    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As System.Windows.Forms.ListBox, ByVal Where As String) As Integer

    End Function

    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As System.Windows.Forms.ListBox) As Integer

    End Function

    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As System.Windows.Forms.ListBox, ByVal Where As String) As Integer

    End Function

    Public Overrides Function ResetCounter(ByVal Table As String) As Integer

    End Function

    Public Overrides Sub Run(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)

    End Sub

    Public Overrides Function RunCommand(ByVal Query As String) As Integer

    End Function

    Public Overrides Sub RunProcedure(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)

    End Sub

    Public Overrides Function SelectDate(ByVal Query As String) As Date

    End Function

    Public Overrides Function SelectDouble(ByVal Query As String) As Double

    End Function

    Public Overrides Function SelectInt(ByVal Query As String) As Integer

    End Function

    Public Overrides Function SelectLong(ByVal Query As String) As Long

    End Function

    Public Overrides Function SelectRows(ByVal Query As String) As System.Data.DataTable

    End Function

    Public Overrides Function SelectSingle(ByVal Query As String) As Single

    End Function

    Public Overrides Function SelectString(ByVal Query As String) As String

    End Function

    Public Overloads Overrides Function Update(ByVal Query As String) As Integer

    End Function

    Public Overloads Overrides Sub Update(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Where As String, ByVal Count As String)

    End Sub

    Public Overloads Overrides Sub writeXML()

    End Sub

    Public Overloads Overrides Sub writeXML(ByVal Path As String, ByVal Query As String)

    End Sub
    Public Overloads Overrides Function ConvertDate(ByVal sDate As Date) As String
        Return ""
    End Function


End Class
