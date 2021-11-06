Imports System
Imports System.IO
Imports System.Collections
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class nxml
    Function numtra(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = ""
        For Each sLine In arrText
            If InStr(sLine, "NumEmpleado=") > 0 Then
                cad = Mid(sLine, InStr(sLine, "NumEmpleado=") + 13, 5)
                cad = cad.Replace(Chr(34), "")
                cad = cad.Replace(" ", "")
                cad = cad.Replace("N", "")
                cad = cad.Replace("u", "")
                cad = cad.Replace("m", "")
            End If
        Next
        numtra = Trim(cad)
    End Function
    Function serie(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = ""
        For Each sLine In arrText
            If InStr(sLine, "serie=") > 0 Then
                cad = Mid(sLine, InStr(sLine, "serie=") + 12, 1)
                'SE LE CAMBIA A 11 CON NOMINA DEL 2014
            End If
        Next
        If cad.ToString = "C" Then
            serie = 4
        Else
            If cad.ToString = "L" Then
                serie = 14
            Else
                serie = 3
            End If

        End If
    End Function
    Function nominab(archivo As String)
        Dim tipo
        nominab = token(archivo, "<cfdi:Comprobante", "/>", "serie=")
        If Len(nominab) = 7 Then
            tipo = Right(nominab, 2)
        Else
            If Len(nominab) = 5 Then
                tipo = ""
            Else
                tipo = Right(nominab, 1)
            End If
        End If
        Select Case tipo
            Case "P"
                nominab = 2
            Case "D"
                nominab = 4
            Case "V"
                nominab = 3
            Case "A"
                nominab = 7
            Case "B"
                nominab = 15
            Case "CV"
                nominab = 3
            Case Else
                nominab = 1
        End Select
    End Function
    Function semana(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = ""
        For Each sLine In arrText
            If InStr(sLine, "serie=") > 0 Then
                cad = Mid(sLine, InStr(sLine, "serie=") + 7, 5)
                'se le cambia a 4 cuando es nomina 2014
            End If
        Next
        semana = cad
    End Function

    Function fecha(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = ""
        For Each sLine In arrText
            If InStr(sLine, "FechaTimbrado=") > 0 Then
                cad = Mid(sLine, InStr(sLine, "FechaTimbrado=") + 15, 10)
                'cad = cad.Replace(Chr(34), "")
                'cad = cad.Replace(" ", "")
            End If
        Next
        fecha = Trim(cad)
    End Function
    Function importe(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim per, ded As Double
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = ""
        For Each sLine In arrText
            If InStr(sLine, "<nomina:Percepciones") > 0 Then
                cad = Mid(sLine, InStr(sLine, "TotalExento=") + Len("TotalExento="), 10)
                cad = cad.Replace(Chr(34), "")
                cad = cad.Replace("T", "")
                cad = cad.Replace("o", "")
                cad = cad.Replace("t", "")
                cad = cad.Replace("a", "")
                cad = cad.Replace("l", "")
                cad = cad.Replace("g", "")
                per = Convert.ToDouble(Val(cad))
                cad = Mid(sLine, InStr(sLine, "TotalGravado=") + Len("TotalGravado="), 10)
                cad = cad.Replace(Chr(34), "")
                cad = cad.Replace(">", "")
                per = per + Convert.ToDouble(cad)
            End If
            If InStr(sLine, "<nomina:Deducciones") > 0 Then
                cad = "TotalExento="
                cad = Mid(sLine, InStr(sLine, cad) + Len(cad), 10)
                cad = cad.Replace(Chr(34), "")
                cad = cad.Replace("T", "")
                cad = cad.Replace("o", "")
                cad = cad.Replace("t", "")
                cad = cad.Replace("a", "")
                cad = cad.Replace("l", "")
                cad = cad.Replace("G", "")
                ded = Convert.ToDouble(cad)
                cad = "TotalGravado="
                cad = Mid(sLine, InStr(sLine, cad) + Len(cad), 10)
                cad = cad.Replace(Chr(34), "")
                cad = cad.Replace(">", "")
                ded = ded + Convert.ToDouble(cad)
            End If
        Next
        importe = per - ded
    End Function
    Function clave(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String = ""
        Dim texto = "(CLAVE: "
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = ""
        For Each sLine In arrText
            If InStr(sLine, texto) > 0 Then
                cad = Mid(sLine, InStr(sLine, texto) + Len(texto), 7)
            End If
        Next
        clave = cad
    End Function
    Function sem(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As Integer = 0
        Dim texto = "ENEB"
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = 0
        For Each sLine In arrText
            If InStr(sLine, texto) > 0 Then
                cad = 1
            Else
                cad = 0
            End If
        Next
        sem = cad
    End Function
    Function prueba(archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As Integer = 0
        Dim texto = "ENEB"
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = 0
        For Each sLine In arrText
            'If InStr(sLine, texto) > 0 Then
            'cad = 1
            'Else
            'cad = 0
            'End If
            MsgBox(sLine)
        Next
        prueba = cad
    End Function
    Function folio(archivo As String)
        folio = token(archivo, "<cfdi:Comprobante", "/>", "folio=")
    End Function
    Function uuid(archivo As String)
        uuid = token(archivo, "<tfd:TimbreFiscalDigital", "/>", "UUID=")
    End Function
    Function token(archivo As String, tini As String, tfin As String, texto As String)
        Dim file As String
        Dim posi, posf
        Dim cad1
        file = My.Computer.FileSystem.ReadAllText("c:\temp\" + archivo)
        posi = InStr(1, file, tini)
        posf = InStr(posi, file, tfin)
        cad1 = Mid(file, posi, posf - posi + Len(tfin))
        tini = texto + Chr(34)
        posi = InStr(1, cad1, tini)
        posf = InStr(posi + Len(tini), cad1, Chr(34))
        posf = posf - posi - Len(tini)
        token = Mid(cad1, posi + Len(tini), posf)
    End Function

End Class
