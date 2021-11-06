Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class Clase
    Public wpas As String
    Public cn As New SqlConnection
    Dim aPath As String = Application.StartupPath
    Public rs As SqlDataReader
    Sub inex()
        desconectar()
        conectar()
    End Sub
    Sub conectar()
        wpas = My.Computer.FileSystem.ReadAllText(aPath & "\pas.ini")
        Try
            cn.ConnectionString = wpas
            cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub desconectar()
        cn.Close()
    End Sub
    Sub qr(texto As String, tipo As Integer)
        inex()
        Dim cons As New SqlCommand(texto, cn)
        If tipo = 1 Then
            Try
                rs = cons.ExecuteReader
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Try
                cons.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Sub azu(hora As String, fecha As String)
        Dim a As New Clase
        Dim libro As Excel.Workbook
        Dim hoja As Excel.Worksheet
        Dim xls = New Excel.Application
        Dim ren As Integer
        xls.Visible = False
        Dim aPat As String = Application.StartupPath
        libro = xls.Workbooks.Open(aPat & "\azucar.xls", False, False)
        a.qr("select convert(char(10),b31_salida,8) salida,placas,b31_fletero,b31_neto from abod001,acre531 " + _
            "where b31_salida between '" + fecha.ToString + " " + hora.ToString + ":00' and '" + fecha.ToString + " " + hora.ToString + _
            ":59:59' and b31_transporta=36 and ticketbascula=b31_ticket and producto=b31_transporta and nuevaorden=0 order by b31_salida", 1)
        hoja = libro.Sheets("rep1")
        Select Case Val(hora)
            Case 0 To 4
                hoja = libro.Sheets("rep2")
            Case 5 To 16
                hoja = libro.Sheets("rep1")
            Case 17 To 23
                hoja = libro.Sheets("rep2")
        End Select
        Select Case Val(hora)
            Case 0
                ren = 29
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 1
                ren = 32
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 2
                ren = 35
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 3
                ren = 38
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 4
                ren = 41
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 5
                ren = 8
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 6
                ren = 11
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 7
                ren = 14
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 8
                ren = 17
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 9
                ren = 20
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 10
                ren = 23
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 11
                ren = 26
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 12
                ren = 29
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 13
                ren = 32
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 14
                ren = 35
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 15
                ren = 38
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 16
                ren = 41
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 17
                ren = 8
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 18
                ren = 11
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 19
                ren = 14
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 20
                ren = 17
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 21
                ren = 20
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 22
                ren = 23
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
            Case 23
                ren = 26
                While a.rs.Read
                    hoja.Cells(ren, 3) = a.rs.Item(0)
                    hoja.Cells(ren, 4) = a.rs.Item(1)
                    hoja.Cells(ren, 5) = a.rs.Item(2)
                    hoja.Cells(ren, 6) = a.rs.Item(3)
                    ren = ren + 1
                End While
        End Select
        libro.Save()
        libro.Close()
        libro = Nothing
    End Sub
End Class
