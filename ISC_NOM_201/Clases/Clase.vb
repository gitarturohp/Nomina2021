Imports System
Imports System.IO
Imports System.Data.Odbc
Imports System.Collections
Imports System.Data.SqlClient
Public Class Clase
    Public wpas As String
    Public cn As New SqlConnection
    Public cnu As New OdbcConnection
    Dim aPath As String = Application.StartupPath
    Public rs As SqlDataReader
    Public rsu As OdbcDataReader
    Sub inex(Optional bd As Integer = 1)
        desconectar()
        conectar(bd)
    End Sub
    Sub conectar(Optional bd As Integer = 1)
        Dim ar As New StreamReader(aPath & "\pas.ini")
        If bd = 1 Then
            wpas = ar.ReadLine
        End If
        If bd = 2 Then
            wpas = ar.ReadLine
            wpas = ar.ReadLine
        End If
        Try
            cn.ConnectionString = wpas
            cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ar.Close()
    End Sub
    Sub desconectar()
        cn.Close()
    End Sub
    Sub qr(texto As String, tipo As Integer, Optional bd As Integer = 1)
        inex(bd)
        Dim cons As New SqlCommand(texto, cn)
        cons.CommandTimeout = 0
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
    Function Num_texto(Numero As String)
        Dim Texto
        Dim Millones
        Dim Miles
        Dim Cientos
        Dim Decimales
        Dim Cadena = ""
        Dim CadMillones
        Dim CadMiles
        Dim CadCientos
        Texto = Numero
        Texto = FormatNumber(Texto, 2)
        Texto = Right(Space(14) & Texto, 14)
        Millones = Mid(Texto, 1, 3)
        Miles = Mid(Texto, 5, 3)
        Cientos = Mid(Texto, 9, 3)
        Decimales = Mid(Texto, 13, 2)
        CadMillones = ConvierteCifra(Millones, 1)
        CadMiles = ConvierteCifra(Miles, 1)
        CadCientos = ConvierteCifra(Cientos, 0)
        If Trim(CadMillones) > "" Then
            If Trim(CadMillones) = "UN" Then
                Cadena = CadMillones & " MILLON"
            Else
                Cadena = CadMillones & " MILLONES"
            End If
        End If
        If Trim(CadMiles) > "" Then
            Cadena = Cadena & " " & CadMiles & " MIL"
        End If
        If Trim(CadMiles & CadCientos) = "UN" Then
            Cadena = Cadena & " CON " & Decimales & "/100"
        Else
            If Miles & Cientos = "000000" Then
                Cadena = Cadena & " " & Trim(CadCientos) & " PESOS " & Decimales & "/100"
            Else
                Cadena = Cadena & " " & Trim(CadCientos) & " PESOS " & Decimales & "/100"
            End If
        End If
        If Numero = 1000 Then
            Num_texto = "( UN MIL PESOS 00/100 M.N )"
        Else
            Num_texto = "( " + Trim(Cadena) + " M.N.)"
        End If
    End Function

    Function ConvierteCifra(Texto As String, SW As Integer)
        Dim Centena
        Dim Decena
        Dim Unidad
        Dim txtCentena = ""
        Dim txtDecena = ""
        Dim txtUnidad = ""
        Centena = Mid(Texto, 1, 1)
        Decena = Mid(Texto, 2, 1)
        Unidad = Mid(Texto, 3, 1)
        Select Case Centena
            Case "1"
                txtCentena = "CIEN"
                If Decena & Unidad <> "00" Then
                    txtCentena = "CIENTO"
                End If
            Case "2"
                txtCentena = "DOSCIENTOS"
            Case "3"
                txtCentena = "TRESCIENTOS"
            Case "4"
                txtCentena = "CUATROCIENTOS"
            Case "5"
                txtCentena = "QUINIENTOS"
            Case "6"
                txtCentena = "SEISCIENTOS"
            Case "7"
                txtCentena = "SETECIENTOS"
            Case "8"
                txtCentena = "OCHOCIENTOS"
            Case "9"
                txtCentena = "NOVECIENTOS"
        End Select

        Select Case Decena
            Case "1"
                txtDecena = "DIEZ"
                Select Case Unidad
                    Case "1"
                        txtDecena = "ONCE"
                    Case "2"
                        txtDecena = "DOCE"
                    Case "3"
                        txtDecena = "TRECE"
                    Case "4"
                        txtDecena = "CATORCE"
                    Case "5"
                        txtDecena = "QUINCE"
                    Case "6"
                        txtDecena = "DIECISEIS"
                    Case "7"
                        txtDecena = "DIECISIETE"
                    Case "8"
                        txtDecena = "DIECIOCHO"
                    Case "9"
                        txtDecena = "DIECINUEVE"
                End Select
            Case "2"
                txtDecena = "VEINTE"
                If Unidad <> "0" Then
                    txtDecena = "VEINTI"
                End If
            Case "3"
                txtDecena = "TREINTA"
                If Unidad <> "0" Then
                    txtDecena = "TREINTA Y "
                End If
            Case "4"
                txtDecena = "CUARENTA"
                If Unidad <> "0" Then
                    txtDecena = "CUARENTA Y "
                End If
            Case "5"
                txtDecena = "CINCUENTA"
                If Unidad <> "0" Then
                    txtDecena = "CINCUENTA Y "
                End If
            Case "6"
                txtDecena = "SESENTA"
                If Unidad <> "0" Then
                    txtDecena = "SESENTA Y "
                End If
            Case "7"
                txtDecena = "SETENTA"
                If Unidad <> "0" Then
                    txtDecena = "SETENTA Y "
                End If
            Case "8"
                txtDecena = "OCHENTA"
                If Unidad <> "0" Then
                    txtDecena = "OCHENTA Y "
                End If
            Case "9"
                txtDecena = "NOVENTA"
                If Unidad <> "0" Then
                    txtDecena = "NOVENTA Y "
                End If
        End Select

        If Decena <> "1" Then
            Select Case Unidad
                Case "1"
                    If SW Then
                        txtUnidad = "UN"
                    Else
                        txtUnidad = "UNO"
                    End If
                Case "2"
                    txtUnidad = "DOS"
                Case "3"
                    txtUnidad = "TRES"
                Case "4"
                    txtUnidad = "CUATRO"
                Case "5"
                    txtUnidad = "CINCO"
                Case "6"
                    txtUnidad = "SEIS"
                Case "7"
                    txtUnidad = "SIETE"
                Case "8"
                    txtUnidad = "OCHO"
                Case "9"
                    txtUnidad = "NUEVE"
            End Select
        End If
        ConvierteCifra = txtCentena & " " & txtDecena & txtUnidad
    End Function
    Function foli(numero As Integer)
        Select Case numero
            Case numero < 10
                foli = "000" + numero.ToString
            Case numero < 100
                foli = "00" + numero.ToString
            Case numero < 1000
                foli = "0" + numero.ToString
            Case Else
                foli = numero.ToString
        End Select
    End Function

    Function ceros(numero As Integer)
        If numero < 10 Then
            ceros = "00" + numero.ToString
        Else
            If numero < 100 Then
                ceros = "0" + numero.ToString
            Else
                ceros = numero.ToString
            End If
        End If
    End Function
    Function xml(archivo As String)
        Dim objReader As New StreamReader("c:\temp\xml\" + archivo.ToString)
        Dim sLine As String = ""
        Dim wrfc As String
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        wrfc = ""
        For Each sLine In arrText
            If InStr(sLine, "<cfdi:Comprobante") > 0 Then
                wrfc = corchete(Mid(sLine, InStr(sLine, "MetodoPago=") + 12, 19))
            End If
            If InStr(sLine, "<cfdi:Comprobante") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "FormaPago=") + 11, 19))
            End If
            If InStr(sLine, "<cfdi:Comprobante") > 0 Then
                wrfc = wrfc + Chr(9) + Mid(sLine, InStr(sLine, "Fecha=") + 7, 19)
            End If
            If InStr(sLine, "<cfdi:Comprobante") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "Folio=") + 7, 25))
            End If
            If InStr(sLine, "Total=") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "Total=") + 7, 19))
            End If
            If InStr(sLine, "SubTotal=") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "SubTotal=") + 10, 19))
            End If
            If InStr(sLine, "<cfdi:Emisor") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "Nombre=") + 8, 50))
            End If
            If InStr(sLine, "<cfdi:Emisor") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "Rfc=") + 5, 13))
            End If
            If InStr(sLine, "<cfdi:Receptor") > 0 Then
                wrfc = wrfc + Chr(9) + Mid(sLine, InStr(sLine, "UsoCFDI=") + 9, 3)
            End If
            If InStr(sLine, "<tfd:TimbreFiscalDigital") > 0 Then
                wrfc = wrfc + Chr(9) + Mid(sLine, InStr(sLine, "UUID=") + 6, 36)
            End If
            If InStr(sLine, "<tfd:TimbreFiscalDigital") > 0 Then
                wrfc = wrfc + Chr(9) + Mid(sLine, InStr(sLine, "FechaTimbrado=") + 15, 19)
            End If
            If InStr(sLine, "TotalImpuestosRetenidos=") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "TotalImpuestosRetenidos=") + 25, 19))
            End If
            If InStr(sLine, "TotalImpuestosTrasladados=") > 0 Then
                wrfc = wrfc + Chr(9) + corchete(Mid(sLine, InStr(sLine, "TotalImpuestosTrasladados=") + 27, 19))
            End If
        Next
        xml = wrfc
    End Function
    Function corchete(ByVal texto As String)
        Dim x = 1
        While x < Len(texto)
            If Asc(Mid(texto, x, 1)) = 34 Then
                Exit While
            End If
            x = x + 1
        End While
        corchete = Mid(texto, 1, x - 1)
    End Function
    Function numtrab(ByVal archivo As String)
        Dim objReader As New StreamReader("c:\temp\" + archivo.ToString)
        Dim sLine As String = ""
        Dim wrfc As String
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        wrfc = ""
        For Each sLine In arrText
            If InStr(sLine, "NumEmpleado=") > 0 Then
                wrfc = Mid(sLine, InStr(sLine, "NumEmpleado=") + 13, 4)
            End If
        Next
        numtrab = wrfc
    End Function
    Function prod(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
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
            If InStr(sLine, "(CLAVE:") > 0 Then
                cad = Mid(sLine, InStr(sLine, "(CLAVE:") + 8, 7)
            End If
        Next
        prod = cad
    End Function
    Function uuid(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
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
            If InStr(sLine, "UUID=") > 0 Then
                cad = Mid(sLine, InStr(sLine, "UUID=") + 6, 36)
            End If
        Next
        uuid = cad
    End Function
    Function fecha(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
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
            If InStr(sLine, "fecha=") > 0 Then
                cad = Mid(sLine, InStr(sLine, "fecha=") + 7, 10)
            End If
        Next
        fecha = Mid(cad, 9, 2) + "-" + Mid(cad, 6, 2) + "-" + Mid(cad, 1, 4)

    End Function
    Function importe(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
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
            If InStr(sLine, " total=") > 0 Then
                cad = Mid(sLine, InStr(sLine, " total=") + 8, 12)
                cad = cad.Replace(Chr(34), "")
                cad = cad.Replace(" ", "")
                cad = cad.Replace("v", "")
                cad = cad.Replace("e", "")
                cad = cad.Replace("r", "")
                cad = cad.Replace("s", "")
                cad = cad.Replace("i", "")
                cad = cad.Replace("o", "")
                cad = cad.Replace("n", "")
            End If
        Next
        importe = cad
    End Function
    Function unitario(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
        Dim sLine As String = ""
        Dim cad As String
        Dim texto = "Unitario="
        Dim arrText As New ArrayList()
        Dim ban
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        cad = ""
        ban = 0
        For Each sLine In arrText
            If (InStr(sLine, texto) > 0 And ban <> 1) Then
                cad = Mid(sLine, InStr(sLine, texto) + Len(texto), 9)
                cad = cad.Replace(Chr(34), "")
                ban = 1
            End If
        Next
        unitario = cad
    End Function
    Function proces(archivo As String)
        Dim objReader As New StreamReader("c:\cred\" + archivo.ToString)
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
            If InStr(sLine, "Specification") > 0 Then
                'cad = Mid(sLine, InStr(sLine, "Specification") + 13, 50)
                cad = Mid(sLine, 17, 50)
            End If
        Next
        proces = Trim(cad)
    End Function
    Function ceros(archivo As String, num As Integer)
        Dim largo = Len(archivo)
        ceros = Trim(archivo)
        For x = 1 To num - largo Step 1
            ceros = "0" + ceros
        Next
    End Function
    Function espacios(archivo As String, num As Integer)
        Dim largo = Len(archivo)
        espacios = Trim(archivo)
        For x = 1 To num - largo Step 1
            espacios = espacios + " "
        Next
    End Function
    Function acceso(ByVal user As String, ByVal forma As String)
        qr("select n1_accesos from nomina_acceso where n1_cuenta='" + user + "' and n1_forma=1", 1)
        rs.Read()
        acceso = InStr(rs!n1_accesos, forma)
        If acceso = 0 Then
            acceso = InStr(rs!n1_accesos, "total")
        End If
        rs = Nothing
    End Function
    Function curp(ByVal cadena As String)
        curp = False
        cadena = UCase(cadena)
        If Len(cadena) = 18 Then
            For x = 1 To 18
                Select Case x
                    Case 1
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            curp = True
                        End If
                    Case 2
                        If Asc(Mid(cadena, x, 1)) = 65 Or Asc(Mid(cadena, x, 1)) = 69 Or Asc(Mid(cadena, x, 1)) = 73 Or Asc(Mid(cadena, x, 1)) = 79 Or Asc(Mid(cadena, x, 1)) = 85 Then
                            curp = True
                        End If
                    Case 3 To 4
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            curp = True
                        End If
                    Case 4
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            curp = True
                        End If
                    Case 5 To 10
                        If Asc(Mid(cadena, x, 1)) >= 48 And Asc(Mid(cadena, x, 1)) <= 57 Then
                            curp = True
                        End If
                    Case 11
                        If Asc(Mid(cadena, x, 1)) = 72 Or Asc(Mid(cadena, x, 1)) = 77 Then
                            curp = True
                        End If
                    Case 12 To 13
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            curp = True
                        End If
                    Case 14 To 16
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            If Asc(Mid(cadena, x, 1)) = 65 Or Asc(Mid(cadena, x, 1)) = 69 Or Asc(Mid(cadena, x, 1)) = 73 Or Asc(Mid(cadena, x, 1)) = 79 Or Asc(Mid(cadena, x, 1)) = 85 Then
                                curp = False
                            Else
                                curp = True
                            End If
                        End If
                    Case 17 To 18
                        If Asc(Mid(cadena, x, 1)) >= 48 And Asc(Mid(cadena, x, 1)) <= 57 Then
                            curp = True
                        End If
                End Select
            Next
        Else
            curp = False
        End If
    End Function
    Function rfc(ByVal cadena As String)
        rfc = False
        cadena = UCase(cadena)
        If Len(cadena) = 13 Then
            For x = 1 To 13
                Select Case x
                    Case 1
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            If Asc(Mid(cadena, x, 1)) = 65 Or Asc(Mid(cadena, x, 1)) = 69 Or Asc(Mid(cadena, x, 1)) = 73 Or Asc(Mid(cadena, x, 1)) = 79 Or Asc(Mid(cadena, x, 1)) = 85 Then
                                rfc = False
                            Else
                                rfc = True
                            End If
                        End If
                    Case 2
                        If Asc(Mid(cadena, x, 1)) = 65 Or Asc(Mid(cadena, x, 1)) = 69 Or Asc(Mid(cadena, x, 1)) = 73 Or Asc(Mid(cadena, x, 1)) = 79 Or Asc(Mid(cadena, x, 1)) = 85 Then
                            rfc = True
                        End If
                    Case 3 To 4
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            rfc = True
                        End If
                    Case 5 To 10
                        If Asc(Mid(cadena, x, 1)) >= 48 And Asc(Mid(cadena, x, 1)) <= 57 Then
                            rfc = True
                        End If
                    Case 11 To 13
                        If Asc(Mid(cadena, x, 1)) >= 48 And Asc(Mid(cadena, x, 1)) <= 57 Then
                            rfc = True
                        End If
                        If Asc(Mid(cadena, x, 1)) >= 65 And Asc(Mid(cadena, x, 1)) <= 90 Then
                            rfc = True
                        End If
                End Select
            Next
        Else
            rfc = False
        End If
    End Function
    Function letra(num As String)
        Select Case num
            Case 1
                letra = "A"
            Case 2
                letra = "B"
            Case 3
                letra = "C"
            Case 4
                letra = "D"
            Case 5
                letra = "E"
            Case 6
                letra = "F"
            Case 7
                letra = "G"
            Case 8
                letra = "H"
            Case 9
                letra = "I"
            Case 10
                letra = "J"
            Case 11
                letra = "K"
            Case 12
                letra = "L"
            Case 13
                letra = "M"
            Case 14
                letra = "N"
            Case 15
                letra = "O"
            Case 16
                letra = "P"
            Case 17
                letra = "Q"
            Case 18
                letra = "R"
            Case 19
                letra = "S"
            Case 20
                letra = "T"
            Case 21
                letra = "U"
            Case 22
                letra = "V"
            Case 23
                letra = "W"
            Case 24
                letra = "X"
            Case 25
                letra = "Y"
            Case 26
                letra = "Z"
            Case Else
                letra = "Z"
        End Select
    End Function
End Class

