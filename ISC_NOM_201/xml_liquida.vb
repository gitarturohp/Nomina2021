Imports System
Imports System.IO
Imports System.Collections
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class xml_liquida
    Function prod(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim texto = "2014 ("
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
        prod = cad
    End Function
    Function cvedif(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim texto = "|CLAVE|: "
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
        cvedif = cad
    End Function

    Function fecha(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim texto = "fecha="
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
                cad = Mid(sLine, InStr(sLine, texto) + 7, 10)
            End If
        Next
        fecha = Mid(cad, 9, 2) + "-" + Mid(cad, 6, 2) + "-" + Mid(cad, 1, 4)
    End Function
    Function comple(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim texto = "<longText>COMPLE"
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
                cad = "S"
            End If
        Next
        comple = 0
        If cad = "S" Then
            comple = 1
        End If
    End Function
    Function anticipo(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad = ""
        'TEXTO A BUSCAR DENTRO DEL ARCHIVO
        Dim texto = "descripcion="
        Dim arrText As New ArrayList()
        'BANDERA NUM PARA SOLO PROCESAR EL PRIMER REGISTRO QUE ENCUENTRE
        Dim num = 0
        anticipo = 0
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        For Each sLine In arrText
            If InStr(sLine, texto) > 0 And num = 0 Then
                'EL NUMERO FIJO QUINCE ES LA CANTIDAD DE TEXTO QUE VA A EXTRAER
                cad = Mid(sLine, InStr(sLine, texto) + Len(texto) + 1, 15)
                num = 1
            End If
        Next
        '///////// ANEXO DE FUNCION
        If cad = "PRIMER ANTICIPO" Then
            anticipo = 1
        Else
            anticipo = 0
        End If
    End Function
    Function clave(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad = ""
        'TEXTO A BUSCAR DENTRO DEL ARCHIVO
        Dim texto = "|CLAVE|:"
        Dim arrText As New ArrayList()
        'BANDERA NUM PARA SOLO PROCESAR EL PRIMER REGISTRO QUE ENCUENTRE
        Dim num = 0
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        For Each sLine In arrText
            If InStr(sLine, texto) > 0 And num = 0 Then
                'EL NUMERO FIJO QUINCE ES LA CANTIDAD DE TEXTO QUE VA A EXTRAER
                cad = Mid(sLine, InStr(sLine, texto) + Len(texto) + 1, 7)
                num = 1
            End If
        Next
        clave = cad.ToString
    End Function
    Function rfc(archivo As String)
        rfc = token(archivo, "<cfdi:Emisor", "/>", "rfc=")
    End Function
    Function nombre(ByVal archivo As String)
        nombre = token(archivo, "<cfdi:Emisor", "/>", "Nombre=")
    End Function
    Function sello(archivo As String)
        sello = "||"
        sello = sello + token(archivo, "<?xml", "/>", "version=") + "|"
        sello = sello + token(archivo, "<tfd:TimbreFiscalDigital", "/>", "UUID=") + "|"
        sello = sello + token(archivo, "<tfd:TimbreFiscalDigital", "/>", "FechaTimbrado=") + "|"
        sello = sello + token(archivo, "<tfd:TimbreFiscalDigital", "/>", "selloCFD=") + "|"
        sello = sello + token(archivo, "<tfd:TimbreFiscalDigital", "/>", "noCertificadoSAT=") + "||"
    End Function
    Function token(archivo As String, tini As String, tfin As String, texto As String)
        Dim file As String
        Dim posi, posf
        Dim cad1
        file = My.Computer.FileSystem.ReadAllText("d:\magin\" + archivo)
        posi = InStr(1, file, tini)
        posf = InStr(posi, file, tfin)
        MsgBox(tfin)
        cad1 = Mid(file, posi, posf - posi + Len(tfin))
        tini = texto + Chr(34)
        posi = InStr(1, cad1, tini)
        posf = InStr(posi + Len(tini), cad1, Chr(34))
        posf = posf - posi - Len(tini)
        token = Mid(cad1, posi + Len(tini), posf)
    End Function
    Function xclave(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad = ""
        'TEXTO A BUSCAR DENTRO DEL ARCHIVO
        Dim texto = "2014 "
        Dim arrText As New ArrayList()
        'BANDERA NUM PARA SOLO PROCESAR EL PRIMER REGISTRO QUE ENCUENTRE
        Dim num = 0
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        For Each sLine In arrText
            If InStr(sLine, texto) > 0 And num = 0 Then
                'EL NUMERO FIJO QUINCE ES LA CANTIDAD DE TEXTO QUE VA A EXTRAER
                cad = Mid(sLine, InStr(sLine, texto) + Len(texto) + 1, 7)
                num = 1
            End If
        Next
        xclave = cad.ToString
    End Function
End Class
