Imports System.IO
Public Class lecturaxml

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub bot_leer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_leer.Click
        Dim x As New xml_liquida
        '== selecciona carpeta
        If fbd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim di As New IO.DirectoryInfo(fbd.SelectedPath)
            Dim diar1 As IO.FileInfo() = di.GetFiles("*.xml")
            Dim dra As IO.FileInfo
            '== lector de archivo
            Dim obj As StreamReader
            Dim lin As String = ""
            Dim cadena = ""
            Dim cont = 0
            dgv_xmls.Rows.Clear()
            For Each dra In diar1
                obj = New StreamReader(fbd.SelectedPath + "\" + dra.ToString)
                lin = obj.ReadToEnd
                dgv_xmls.Rows.Add(token(lin, "<cfdi:Emisor", "rfc="), token(lin, "<cfdi:Emisor", "nombre="), token(lin, "<tfd:TimbreFiscalDigital", "UUID="), token(lin, "<cfdi:Comprobante", " total="))
                cont += 1
            Next
            lbl_registros.Text = "Registros leidos: " + cont.ToString
            MsgBox("Proceso " + cont.ToString + " registros")
        End If
    End Sub
    Function token(ByVal cadena As String, ByVal cini As String, ByVal cbus As String)
        Dim posi = 0, posf = 0
        posi = InStr(1, cadena, cini)
        posf = InStr(1, Mid(cadena, posi, Len(cadena) - posi), ">")
        posf = posf + posi
        cadena = Mid(cadena, posi, posf - posi)
        posi = InStr(1, cadena, cbus) + Len(cbus) + 1
        If posi < 10 Then
            If cbus = "nombre=" Then
                cbus = "Nombre="
            End If
            If cbus = "rfc=" Then
                cbus = "Rfc="
            End If
            If cbus = " total=" Then
                cbus = " Total="
            End If
            posi = InStr(1, cadena, cbus) + Len(cbus) + 1
        End If
        posf = InStr(1, Mid(cadena, posi, Len(cadena) - posi), Chr(34))
        posf = posf + posi - 1
        token = Mid(cadena, posi, posf - posi)
    End Function
End Class