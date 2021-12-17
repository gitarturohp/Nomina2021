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
        email.From = New MailAddress("notificacionsc@zucarmex.com")

        '========= cuando se estan haciendo pruebas ===============
        email.To.Add("aherrerap@zucarmex.com")
        '========= activar a true y comentar correo aherrerap

        email.To.Add("jsanchezc@zucarmex.com")
        email.To.Add("fandrei@zucarmex.com")

        email.IsBodyHtml = True
        email.Body = mensaje
        email.Subject = encabezado
        email.Priority = MailPriority.Normal
        Dim smtp As New SmtpClient
        With smtp
            .Port = 587
            .Host = "smtp.gmail.com"
            .EnableSsl = True
            '.Credentials = New Net.NetworkCredential("notificaciones@zucarmex.com", "N0tZcrMX>2O")
            .Credentials = New Net.NetworkCredential("notificacion.iasc@gmail.com", "Noti2021#")
        End With
        Try
            smtp.Send(email)
            MsgBox("Mensaje enviado.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("ERROR: " & ex.Message, MsgBoxStyle.OkOnly, "Revisar lista de destinatarios")
        End Try
        Return True
    End Function
    Function correorecibo(ByVal correo As String, ByVal archivo As String, ByVal semana As String, ByVal sem As String, ByVal concepto As String)
        Dim a As New Clase
        Dim email As New MailMessage()
        Dim archivoAdjunto As System.Net.Mail.Attachment
        email.IsBodyHtml = False
        email.From = New MailAddress("notificacionsc@zucarmex.com")
        email.To.Add(correo)
        archivoAdjunto = New System.Net.Mail.Attachment(archivo + "xml")
        email.Attachments.Add(archivoAdjunto)
        archivoAdjunto = New System.Net.Mail.Attachment(archivo + "pdf")
        email.Attachments.Add(archivoAdjunto)
        email.IsBodyHtml = True
        email.Body = semana
        email.Subject = "Recibo de " + concepto + " " + sem.ToString
        email.Priority = MailPriority.Normal
        Dim smtp As New SmtpClient
        With smtp
            .Port = 587
            .Host = "smtp.gmail.com"
            .EnableSsl = True
            '.Credentials = New Net.NetworkCredential("notificaciones@zucarmex.com", "N0tZcrMX>2O")
            .Credentials = New Net.NetworkCredential("notificacion.iasc@gmail.com", "Noti2021#")
        End With
        Try
            smtp.Send(email)
            If UCase(Mid(concepto, 1, 1)) = "N" Then
                a.qr("update bitacora_recibos set enviado=1,fecha=getdate() where tipo='N' and semana=" + sem.ToString + " and numtra=(select tipo from catalogos where familia=21 and descrip='" + correo + "')", 2)
            Else
                a.qr("update bitacora_recibos set enviado=1,fecha=getdate() where tipo<>'N' and semana=" + sem.ToString + " and numtra=(select tipo from catalogos where familia=21 and descrip='" + correo + "')", 2)
            End If
        Catch ex As Exception
            MsgBox("ERROR: " + correo + " " & ex.Message, MsgBoxStyle.OkOnly, "Revisar correo destinatario")
            a.qr("update bitacora_recibos set enviado=2 where semana=" + sem.ToString + " and numtra=(select tipo from catalogos where familia=21 and descrip='" + correo + "')", 2)
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
