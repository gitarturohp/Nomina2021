Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.Mail
Module Encriptar
    Private Const sSecretKey As String = "WordPass"
    Public usuario As String
    Public accesos As Integer = 0
    Public correos = ""
    Public plantilla = 0

    Sub EncryptFile(ByVal sInputFilename As String, _
               ByVal sOutputFilename As String, _
               ByVal sKey As String)

        Dim fsInput As New FileStream(sInputFilename, _
                                    FileMode.Open, FileAccess.Read)
        Dim fsEncrypted As New FileStream(sOutputFilename, _
                                    FileMode.Create, FileAccess.Write)

        Dim DES As New DESCryptoServiceProvider()

        'Establecer la clave secreta para el algoritmo DES.
        'Se necesita una clave de 64 bits y IV para este proveedor
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Establecer el vector de inicialización.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'crear cifrado DES a partir de esta instancia
        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()
        'Crear una secuencia de cifrado que transforma la secuencia
        'de archivos mediante cifrado DES
        Dim cryptostream As New CryptoStream(fsEncrypted, _
                                            desencrypt, _
                                            CryptoStreamMode.Write)

        'Leer el texto del archivo en la matriz de bytes
        Dim bytearrayinput(fsInput.Length - 1) As Byte
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)
        'Escribir el archivo cifrado con DES
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Close()
    End Sub

    Sub DecryptFile(ByVal sInputFilename As String, _
        ByVal sOutputFilename As String, _
        ByVal sKey As String)

        Dim DES As New DESCryptoServiceProvider()
        'Se requiere una clave de 64 bits y IV para este proveedor.
        'Establecer la clave secreta para el algoritmo DES.
        DES.Key() = ASCIIEncoding.ASCII.GetBytes(sKey)
        'Establecer el vector de inicialización.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'crear la secuencia de archivos para volver a leer el archivo cifrado
        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)
        'crear descriptor DES a partir de nuestra instancia de DES
        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()
        'crear conjunto de secuencias de cifrado para leer y realizar 
        'una transformación de descifrado DES en los bytes entrantes
        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)
        'imprimir el contenido de archivo descifrado
        Dim fsDecrypted As New StreamWriter(sOutputFilename)
        fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd)
        fsDecrypted.Flush()
        fsDecrypted.Close()
    End Sub
    Public Function correo(ByVal mensaje As String, ByVal encabezado As String)
        Dim a As New Clase
        Dim email As New MailMessage()
        Dim mail() As String
        email.IsBodyHtml = False
        email.From = New MailAddress("notificaciones@zucarmex.com")

        '========= cuando se estan haciendo pruebas ===============
        'email.To.Add("aherrerap@zucarmex.com")
        '========= activar a true y comentar correo aherrerap

        If True Then
            a.qr("select g1_correos from anom101", 1)
            a.rs.Read()
            mail = Split(a.rs!g1_correos, ";")
            email.To.Add(mail(0))
            If Len(correos) > 0 Then
                email.CC.Add(correos)
            End If
            email.Bcc.Add(mail(1))
            email.Bcc.Add(mail(2))
            email.Bcc.Add(mail(3))
            email.Bcc.Add(mail(4))
            email.Bcc.Add(mail(5))
            email.Bcc.Add(mail(6))
            email.Bcc.Add(mail(7))
            email.Bcc.Add(mail(8))
            email.Bcc.Add(mail(9))
            email.Bcc.Add(mail(10))
            email.Bcc.Add(mail(11))
            email.Bcc.Add(mail(12))
            email.Bcc.Add(mail(13))
        End If
        'email.Bcc.Add(mail(14))
        'email.Bcc.Add(mail(15))
        'Dim archivos() As String = Directory.GetFiles("c:\temp\", "basenc.pkg")
        'For Each archivo1 In archivos
        'Dim archivoAdjunto As New System.Net.Mail.Attachment(archivo1)
        'email.Attachments.Add(archivoAdjunto)
        'Next
        email.IsBodyHtml = True
        email.Body = mensaje
        email.Subject = encabezado
        email.Priority = MailPriority.Normal
        Dim smtp As New SmtpClient
        With smtp
            .Port = 587
            .Host = "smtp.gmail.com"
            .EnableSsl = True
            .Credentials = New Net.NetworkCredential("notificaciones@zucarmex.com", "N0tZcrMX>2O")
        End With
        Try
            smtp.Send(email)
            MsgBox("Mensaje enviado.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("ERROR: " & ex.Message, MsgBoxStyle.OkOnly, "Revisar lista de destinatarios")
        End Try
        Return True
    End Function
    Public Function correo_pagos(ByVal mensaje As String, ByVal encabezado As String, ByVal semana As Integer)
        Dim a As New Clase
        Dim email As New MailMessage()
        Dim mail() As String
        email.IsBodyHtml = False
        email.From = New MailAddress("notificaciones@zucarmex.com")
        a.qr("select g1_correos from anom101", 1)
        a.rs.Read()
        If True Then
            mail = Split(a.rs!g1_correos, ";")
            email.To.Add("ccruzr@zucarmex.com")
            email.To.Add("lmolina@zucarmex.com")
            email.To.Add("aherrerap@zucarmex.com")
            If Len(correos) > 0 Then
                'email.CC.Add(correos)
            End If
            email.CC.Add("aherrerap@zucarmex.com")
            email.Bcc.Add("dvelazco@zucarmex.com")
            email.Bcc.Add("kaguirre@zucarmex.com")
            email.Bcc.Add("clandeta@zucarmex.com")
            email.Bcc.Add("jgalvezc@zucarmex.com")
            email.Bcc.Add("acruz@zucarmex.com")
            Dim archivos() As String = Directory.GetFiles("c:\temp\", "*" + semana.ToString + "*.txt")
            For Each archivo1 In archivos
                Dim archivoAdjunto As New System.Net.Mail.Attachment(archivo1)
                email.Attachments.Add(archivoAdjunto)
            Next
        Else
            email.To.Add("aherrerap@zucarmex.com")
        End If
        email.IsBodyHtml = True
        email.Body = mensaje
        email.Subject = encabezado
        email.Priority = MailPriority.High
        Dim smtp As New SmtpClient
        smtp.Host = "smtp.gmail.com"
        smtp.Port = 587
        smtp.Credentials = New System.Net.NetworkCredential("notificaciones@zucarmex.com", "N0tZcrMX>2O")
        smtp.EnableSsl = True
        Try
            smtp.Send(email)
            MsgBox("Mensaje enviado.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("ERROR: " & ex.Message, MsgBoxStyle.OkOnly, "Revisar lista de destinatarios")
        End Try
        Return True
    End Function

    Function conteven(ByVal semana As Integer)
        Dim a As New Clase
        Dim wvalor = 0
        a.qr("select sum(case when dbo.conteo(h2_fecha)<0 then 0 else dbo.conteo(h2_fecha) end) cont from anom201,anom202" + _
            " where(h1_fecha_ini <= h2_fecha)" + _
            " and h1_fecha_fin>=h2_fecha" + _
            " and h1_semana=" + semana.ToString, 1)
        a.rs.Read()
        conteven = a.rs!cont
    End Function
    Function valsem(ByVal semana)
        Dim a As New Clase
        a.qr("select * from anom201 where h1_semana=" + semana.ToString, 1)
        If a.rs.HasRows Then
            valsem = True
        Else
            valsem = False
        End If
    End Function

End Module
