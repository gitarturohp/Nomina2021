Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.Mail
Public Class Principal
    Public a As New Clase
    Public b As New Clase
    Public c As New xml_liquida
    Public d As New nxml
    Public ruta As String
    Dim wtiponom As Integer
    Private Sub Form1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar.ToString = Chr(27) Then
            If MsgBox("Salir del programa?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Application.Exit()
            End If
        End If
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        a.qr("select g1_timbrado from anom101", 1)
        a.rs.Read()
        ruta = a.rs!g1_timbrado.ToString
        If Not Directory.Exists(ruta) Then
            Directory.CreateDirectory(ruta)
        End If
        Dim ResolucionDestino As Size
        ResolucionDestino = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        Me.Height = ResolucionDestino.Height
    End Sub

    Private Sub bot_carga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)
        Dim wfecha
        wfecha = InputBox("FECHA DE CIERRE")
        MsgBox(wfecha)
    End Sub
    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim b As New nxml
        Dim di As New IO.DirectoryInfo("c:\temp")
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.pdf")
        Dim dra As IO.FileInfo
        Dim query As String = ""
        Dim num = 1
        Dim wvar
        If MsgBox("PROCESAR CARGA DE XML DE NOTA DE CREDITO", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each dra In diar1
                wvar = b.clave(dra.ToString)
                'query = "insert into uuid_nc values(" + wvar.ToString + ",'" + b.uuid(dra.ToString).ToString + "','31/12/2014')"
                MsgBox(query)
                'a.qr(query, 2)
                'My.Computer.FileSystem.MoveFile("c:\temp\" + dra.ToString, "c:\temp\xml\" + dra.ToString)
            Next
            MsgBox("CARGA REALIZADA")
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    End Sub
    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_dispersion.Click
        If a.acceso(acceso.usuario, "cargas") <> 0 Then
            cargas.Show()
        Else
            MsgBox("Usuario No Autorizado", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bot_nomina_Click(sender As System.Object, e As System.EventArgs) Handles bot_nomina.Click
        If a.acceso(acceso.usuario, "nomina") <> 0 Then
            nomina.Show()
        Else
            MsgBox("Usuario No Autorizado", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bot_asistencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_asistencia.Click
        If a.acceso(acceso.usuario, "asistencia") <> 0 Then
            Asistencia.Show()
        Else
            MsgBox("Usuario No Autorizado", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub bot_lee_timbrado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub bot_procesos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_procesos.Click
        If a.acceso(acceso.usuario, "procesos") <> 0 Then
            procesos.Show()
        Else
            MsgBox("Usuario No Autorizado", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub VersionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VersionToolStripMenuItem.Click
        MsgBox("Industrial Azucarera San Cristobal" + Chr(13) + Chr(13) + "Autor: Tecnologias de la Informacion" + Chr(13) + Chr(13) + "Version " + version + "  MMXXI")
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Principal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
    Private Sub bot_porfuera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_porfuera.Click
        If a.acceso(acceso.usuario, "porfuera") <> 0 Then
            PorFuera.Show()
        Else
            MsgBox("Usuario No Autorizado", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub OrdinariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdinariaToolStripMenuItem.Click
        bot_procesos.PerformClick()
    End Sub

    Private Sub ExtraordinariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraordinariaToolStripMenuItem.Click
        bot_porfuera.PerformClick()
    End Sub

    Private Sub DispersionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DispersionToolStripMenuItem.Click
        bot_dispersion.PerformClick()
    End Sub

    Private Sub PolizasContablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolizasContablesToolStripMenuItem.Click
        bot_nomina.PerformClick()
    End Sub

    Private Sub bot_maestros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_maestros.Click
        If a.acceso(acceso.usuario, "maestros") <> 0 Then
            maestros.Show()
        Else
            MsgBox("Usuario No Autorizado", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub CatalogosMaestrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatalogosMaestrosToolStripMenuItem.Click
        bot_maestros.PerformClick()
    End Sub
End Class
