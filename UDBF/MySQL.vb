Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Xml
Imports System.Windows.Forms
Imports System.IO

Public Class MySQL
    Inherits DBClient
    Private iDebugMode As Integer
    Public Property DebugMode As Integer
        Get
            Return iDebugMode
        End Get
        Set(value As Integer)
            iDebugMode = value
        End Set
    End Property
    Private iConnString As String
    Public Property ConnString() As String
        Get
            Return iConnString
        End Get
        Set(ByVal value As String)
            iConnString = value
        End Set
    End Property

    Public Sub New(ByVal pConnString As String)
        Me.ConnString = pConnString

    End Sub

    Public Overrides Function Delete(ByVal Query As String) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As New MySqlDataAdapter
        Dim com As New MySqlCommand
        conn.ConnectionString = ConnString
        Try
            conn.Open()
            com.CommandText = Query
            com.Connection = conn
            com.ExecuteNonQuery()

            Return 0
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            Return -1
        End Try
    End Function
    Public Overrides Sub EnableEnterKey()

    End Sub
    Public Overloads Overrides Function getMaxValue(ByVal Table As String, ByVal Field As String) As String
        Dim Value As String = ""
        Dim Query As String
        Query = "select max(" & Field & ") from " & Table
        Value = SelectInt(Query)
        Return Value
    End Function

    Public Overloads Overrides Function getMaxValue(ByVal Table As String, ByVal Field As String, ByVal Where As String) As String
        Dim Value As String = ""
        Dim Query As String
        Query = "select max(" & Field & ") from " & Table & " where " & Where
        Value = SelectInt(Query)
        Return Value
    End Function

    Public Overrides Function getTopValue(ByVal Table As String, ByVal Field As String) As String
        Dim Value As String = ""
        Dim Query As String
        Query = "select max(" & Field & ") from " & Table
        Value = SelectInt(Query)
        Return (Value + 1)
    End Function

    Public Overrides Function InsertS(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer
        Dim conn As New MySqlConnection
        Dim com As New MySqlCommand
        Dim i As Integer
        conn.ConnectionString = Me.ConnString
        Dim sql As String
        sql = "insert into " & Table & "("
        For i = 0 To Count - 2
            sql = sql & Fields(i) & ","
        Next
        sql = sql & Fields(i) & ") values('"

        For i = 0 To Count - 2
            sql = sql & Values(i) & "','"
        Next
        sql = sql & Values(i) & "') "
        Try
            conn.Open()
            com.Connection = conn
            com.CommandText = sql
            com.ExecuteNonQuery()
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & sql)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try

    End Function
    Public Overrides Function Insert(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer) As Integer
        Dim conn As New MySqlConnection
        Dim com As New MySqlCommand
        Dim i As Integer
        conn.ConnectionString = Me.ConnString
        Dim sql As String
        sql = "insert into " & Table & "("
        For i = 0 To Count - 2
            sql = sql & Fields(i) & ","
        Next
        sql = sql & Fields(i) & ") values('"

        For i = 0 To Count - 2
            sql = sql & Values(i) & "','"
        Next
        sql = sql & Values(i) & "') "
        Try
            conn.Open()
            com.Connection = conn
            com.CommandText = sql
            com.ExecuteNonQuery()
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & sql)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try

    End Function
    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As System.Windows.Forms.ComboBox) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Dim Query As String
        conn.ConnectionString = Me.ConnString
        Query = "select " & strField & "," & intField & " from " & Table
        com.CommandText = "select " & strField & "," & intField & " from " & Table
        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            While Reader.Read
                Combo.Items.Add(New NameValuePair(Reader.GetValue(0), Reader.GetValue(1)))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0
    End Function
    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal Combo As System.Windows.Forms.ComboBox, ByVal Where As String) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Dim Query As String
        conn.ConnectionString = Me.ConnString
        Query = "select " & strField & "," & intField & " from " & Table & Where
        com.CommandText = "select " & strField & "," & intField & " from " & Table & Where
        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            While Reader.Read
                Combo.Items.Add(New NameValuePair(Reader.GetValue(0), Reader.GetValue(1)))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0

    End Function

    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As System.Windows.Forms.ComboBox) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        conn.ConnectionString = Me.ConnString
        Dim Query As String
        Query = "select " & Field & " from " & Table
        com.CommandText = "select " & Field & " from " & Table
        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            Combo.Items.Clear()
            While Reader.Read
                Combo.Items.Add(Reader.GetValue(0))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0
    End Function
    Public Overloads Overrides Function LoadComboBox(ByVal Table As String, ByVal Field As String, ByVal Combo As System.Windows.Forms.ComboBox, ByVal Where As String) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        conn.ConnectionString = Me.ConnString
        Dim Query As String
        Query = "select " & Field & " from " & Table & Where
        com.CommandText = "select " & Field & " from " & Table & Where
        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            Combo.Items.Clear()
            While Reader.Read
                Combo.Items.Add(Reader.GetValue(0))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0
    End Function
    Public Overrides Function LoadGridWin32(ByVal Query As String, ByVal Grid As System.Windows.Forms.DataGridView) As Integer
        Dim Result As New DataTable

        Dim conn As New MySqlConnection
        Dim Reader As New MySqlDataAdapter
        Dim com As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            com.CommandText = Query
            Reader.SelectCommand = com
            Reader.SelectCommand.Connection = conn
            Reader.Fill(Result)
            Grid.DataSource = Result
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return 1

    End Function

    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As System.Windows.Forms.ListBox) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Dim Query As String
        Query = "select " & strField & "," & intField & " from " & Table

        conn.ConnectionString = Me.ConnString
        com.CommandText = Query
        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            While Reader.Read
                List.Items.Add(New NameValuePair(Reader.GetValue(0), Reader.GetValue(1)))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0
    End Function
    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal strField As String, ByVal intField As String, ByVal List As System.Windows.Forms.ListBox, ByVal Where As String) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Dim Query As String
        Query = "select " & strField & "," & intField & " from " & Table & " where " & Where
        conn.ConnectionString = Me.ConnString
        com.CommandText = Query
        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            While Reader.Read
                List.Items.Add(New NameValuePair(Reader.GetValue(0), Reader.GetValue(1)))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0

    End Function
    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As System.Windows.Forms.ListBox) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        conn.ConnectionString = Me.ConnString
        Dim Query As String
        'Query = "select " & Field & " from " & Table & " where ccode='" & cCode & "'"
        Query = "select " & Field & " from " & Table

        com.CommandText = "select " & Field & " from " & Table

        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            While Reader.Read
                List.Items.Add(Reader.GetValue(0))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0

    End Function

    Public Overloads Overrides Function LoadListBox(ByVal Table As String, ByVal Field As String, ByVal List As System.Windows.Forms.ListBox, ByVal Where As String) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        conn.ConnectionString = Me.ConnString
        Dim Query As String
        'Query = "select " & Field & " from " & Table & " where ccode='" & cCode & "'"
        Query = "select " & Field & " from " & Table & " where " & Where

        com.CommandText = "select " & Field & " from " & Table & " where " & Where

        Try
            conn.Open()
            com.Connection = conn
            Reader = com.ExecuteReader
            While Reader.Read
                List.Items.Add(Reader.GetValue(0))
            End While
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return 0

    End Function

    Public Overrides Function ResetCounter(ByVal Table As String) As Integer
        Dim Result As New DataTable
        Dim Query As String
        Query = "ALTER TABLE " & Table & " AUTO_INCREMENT = 1;"

        Dim conn As New MySqlConnection
        Dim Reader As New MySqlDataAdapter
        Dim com As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            com.ExecuteNonQuery()

        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return 1

    End Function

    Public Overrides Sub Run(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = ProcedureName
            For i As Integer = 0 To Count - 1
                cmd.Parameters.AddWithValue(Fields(i), Values(i))
            Next
            cmd.ExecuteNonQuery()


        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Public Overrides Function RunCommand(ByVal Query As String) As Integer
        Dim Result As New DataTable
        Dim conn As New MySqlConnection
        Dim Reader As New MySqlDataAdapter
        Dim com As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            com.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Close()
            conn.Dispose()
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        conn.Close()
        conn.Dispose()
        Return 1

    End Function

    Public Overrides Sub RunProcedure(ByVal ProcedureName As String, ByVal Fields() As String, ByVal Values() As String, ByVal Count As Integer)
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = ProcedureName
            For i As Integer = 0 To Count - 1
                cmd.Parameters.AddWithValue(Fields(i), Values(i))
            Next
            cmd.ExecuteNonQuery()


        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Public Overrides Function SelectDate(ByVal Query As String) As Date
        Dim Result As New DataTable
        Dim conn As New MySqlConnection(Me.ConnString)
        Dim Reader As MySqlDataAdapter
        Dim com As New MySqlCommand
        Try
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            Reader = New MySqlDataAdapter(com)
            Reader.Fill(Result)
            If IsDBNull((Result.Rows(0).Item(0))) Then
                Return "01-01-1800"
            Else
                Return CDate(Result.Rows(0).Item(0))
            End If
        Catch ex As Exception

            MsgBox(Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
    End Function

    Public Overrides Function SelectDouble(ByVal Query As String) As Double
        Dim Result As New DataTable
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Dim Ans As Double
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            Reader = com.ExecuteReader
            If Reader.Read Then
                If IsDBNull(Reader.GetValue(0)) Then
                    Return 0
                Else
                    Ans = Reader.GetValue(0)
                    conn.Close()
                    conn.Dispose()
                    Return Ans
                End If
            End If
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
    End Function

    Public Overrides Function SelectInt(ByVal Query As String) As Integer
        Dim Result As New DataTable
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Dim ResultI As Integer
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            Reader = com.ExecuteReader
            If Reader.Read Then
                If IsDBNull(Reader.GetValue(0)) Then
                    Return 0
                Else
                    ResultI = Reader.GetValue(0)
                    conn.Close()
                    conn.Dispose()
                    Return ResultI
                End If
            End If
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        conn.Dispose()

    End Function

    Public Overrides Function SelectLong(ByVal Query As String) As Long
        Dim Result As New DataTable
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Dim Ans As Long
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            Reader = com.ExecuteReader
            If Reader.Read Then
                If IsDBNull(Reader.GetValue(0)) Then
                    Return 0
                Else
                    Ans = Reader.GetInt32(0)
                    conn.Close()
                    conn.Dispose()
                    Return Ans
                End If
            End If
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
            Return 0
        Finally
            conn.Dispose()
            conn.Close()
        End Try

    End Function

    Public Overrides Function SelectRows(ByVal Query As String) As System.Data.DataTable
        Dim Result As New DataTable("RecordSet")
        Dim conn As New MySqlConnection
        Dim Reader As New MySqlDataAdapter
        Dim com As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            com.CommandText = Query
            Reader.SelectCommand = com
            Reader.SelectCommand.Connection = conn

            Reader.Fill(Result)
            Return Result
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
            Return Result
        Finally
            conn.Dispose()
            conn.Close()
        End Try
    End Function

    Public Overrides Function SelectSingle(ByVal Query As String) As Single
        Dim Result As New DataTable
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            Reader = com.ExecuteReader
            If Reader.Read Then
                If IsDBNull(Reader.GetValue(0)) Then
                    Return 0
                Else
                    Return Reader.GetValue(0)
                End If
            End If
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
            Return 0
        Finally
            conn.Dispose()
            conn.Close()
        End Try

    End Function

    Public Overrides Function SelectString(ByVal Query As String) As String
        Dim Result As New DataTable
        Dim conn As New MySqlConnection
        Dim Reader As MySqlDataReader
        Dim com As New MySqlCommand
        Try
            conn.ConnectionString = Me.ConnString
            conn.Open()
            com.Connection = conn
            com.CommandText = Query
            Reader = com.ExecuteReader
            If Reader.Read Then
                Return Reader.GetValue(0).ToString
            End If
            Return ""
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try
        Return ""

    End Function

    Public Overloads Overrides Function Update(ByVal Query As String) As Integer
        Dim conn As New MySqlConnection
        Dim Reader As New MySqlDataAdapter
        Dim com As New MySqlCommand
        conn.ConnectionString = ConnString
        Try
            conn.Open()
            com.CommandText = Query
            com.Connection = conn
            com.ExecuteNonQuery()

            Return 0
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Close()
            conn.Dispose()
            Return -1
        End Try

    End Function
    Public Overloads Overrides Sub Update(ByVal Table As String, ByVal Fields() As String, ByVal Values() As String, ByVal Where As String, ByVal Count As String)
        Dim i As Integer
        Dim Query As String
        Query = "Update " & Table & " set "
        i = 0
        While (i < Count - 1)
            Query = Query & Fields(i) & "='" & Values(i) & "',"
            i = i + 1
        End While
        Query = Query & Fields(i) & "='" & Values(i) & "' where " & Where
        If iDebugMode = 1 Then
            Log(Query)
        End If

        Dim conn As New MySqlConnection
        Dim Reader As New MySqlDataAdapter
        Dim com As New MySqlCommand
        conn.ConnectionString = Me.ConnString
        Try
            conn.Open()
            com.CommandText = Query
            'MsgBox(Query)
            com.Connection = conn
            com.ExecuteNonQuery()
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try

    End Sub


    Public Overloads Overrides Sub writeXML()

    End Sub

    Public Overloads Overrides Sub writeXML(ByVal Path As String, ByVal Query As String)
        Dim myData As New DataSet


        ' Dim myReport As New ReportDocument

        Dim conn As New MySqlConnection
        Dim com As New MySqlCommand
        com.CommandTimeout = 10000
        Dim myAdapter As New MySqlDataAdapter
        ' Dim myAdapter1 As New MySqlDataAdapter
        ' Dim dt As String

        Try


            '  dt = convertDate(dtsale.Text)
            conn.ConnectionString = Me.ConnString
            conn.Open()

            ' conn.Open()
            com.Connection = conn
            com.CommandText = Query
            myAdapter.SelectCommand = com
            myAdapter.Fill(myData)
            myData.WriteXml(Path, XmlWriteMode.WriteSchema)
        Catch ex As Exception
            Log(vbCrLf & "Error :" & ex.StackTrace & vbCrLf & "Details :" & ex.Message & vbCrLf & "Query String :" & Query)
            conn.Dispose()
            conn.Close()
        Finally
            conn.Dispose()
            conn.Close()
        End Try

    End Sub
    Public Sub Log(ByVal Message As String)
        Try
            Dim FILE_NAME As String = "log" & Today.Now.Date.Day & Today.Now.Date.Month & Today.Now.Date.Year & ".txt"
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            objWriter.WriteLine(Message)
            objWriter.Close()
        Catch ex As Exception

        End Try
    End Sub
    Public Overloads Overrides Function ConvertDate(ByVal sDate As Date) As String
        Return ""
    End Function
End Class
