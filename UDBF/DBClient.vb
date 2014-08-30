Imports System.Windows.Forms

Public MustInherit Class DBClient
    Public MustOverride Function InsertS(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer
    Public MustOverride Function Insert(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer

    Public MustOverride Function RunCommand(ByVal Query As String) As Integer
    Public MustOverride Function getMaxValue(ByVal Table As String, ByVal Field As String, ByVal Where As String) As String
    Public MustOverride Function LoadGridWin32(ByVal Query As String, ByVal Grid As DataGridView) As Integer
    Public MustOverride Function ResetCounter(ByVal Table As String) As Integer
    Public MustOverride Function SelectRows(ByVal Query As String) As DataTable
    Public MustOverride Function SelectString(ByVal Query As String) As String
    Public MustOverride Function SelectLong(ByVal Query As String) As Int64
    Public MustOverride Function SelectInt(ByVal Query As String) As Integer
    Public MustOverride Function SelectSingle(ByVal Query As String) As Single
    Public MustOverride Function SelectDouble(ByVal Query As String) As Double
    Public MustOverride Function SelectDate(ByVal Query As String) As Date

    Public MustOverride Sub writeXML()
    Public MustOverride Function Update(ByVal Query As String) As Integer
    Public MustOverride Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As ComboBox, ByVal Where As String) As Integer
    Public MustOverride Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As ComboBox) As Integer
    Public MustOverride Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As ComboBox, ByVal Where As String) As Integer
    Public MustOverride Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As ComboBox) As Integer

    Public MustOverride Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As ListBox, ByVal Where As String) As Integer
    Public MustOverride Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As ListBox) As Integer
    Public MustOverride Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As ListBox, ByVal Where As String) As Integer
    Public MustOverride Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As ListBox) As Integer

    Public MustOverride Sub EnableEnterKey()

    Public MustOverride Sub Update(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Where As String, ByVal Count As String)


    Public MustOverride Function Delete(ByVal Query As String) As Integer
    Public MustOverride Sub writeXML(ByVal Path As String, ByVal Query As String)

    Public MustOverride Function getMaxValue(ByVal Table As String, ByVal Field As String) As String

    Public MustOverride Function getTopValue(ByVal Table As String, ByVal Field As String) As String

    Public MustOverride Sub Run(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)

    Public MustOverride Sub RunProcedure(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)
    Public MustOverride Function ConvertDate(ByVal sDate As Date) As String


End Class
