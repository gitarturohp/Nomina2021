Imports System
Imports System.Text
Imports System.Collections
Imports System.DirectoryServices
Public Class acceso
    Public usuario As String
    Private Sub bot_entra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_entra.Click
        Dim a As New Clase
        Dim dominio = "gpozucarmex.corp"
        Dim forma As String = ""
        Try
            If IsAuthenticated(dominio, txt_clave.Text, txt_pass.Text) Then
                a.qr("select * from nomina_acceso where n1_cuenta='" + txt_clave.Text + "'", 1)
                If Not a.rs.HasRows Then
                    MsgBox("Usuario no tiene permisos de entrada al sistema")
                Else
                    a.qr("select valor from parametros where tipo=1 and clave='mantto'", 1)
                    a.rs.Read()
                    If Val(a.rs!valor) = 1 Then
                        MsgBox("Sistema en mantenimiento, espere unos minutos...", MsgBoxStyle.Critical)
                        If txt_clave.Text <> "aherrerap" Then
                            Application.Exit()
                        End If
                    End If
                    a.qr("select * from nomina_acceso where n1_cuenta='" + txt_clave.Text + "'", 1)
                    a.rs.Read()
                    forma = (Mid(a.rs!n1_accesos, 2, InStr(a.rs!n1_accesos, "]") - 2))
                    usuario = txt_clave.Text
                    username = usuario
                    version = Mid(lbl_version.Text, 6, 4)
                    txt_clave.Text = ""
                    txt_pass.Text = ""
                    Select Case forma
                        Case "principal"
                            Principal.Show()
                            Me.Hide()
                        Case "nomina"
                            nomina.Show()
                            Me.Hide()
                        Case "porfuera"
                            PorFuera.Show()
                            Me.Hide()
                        Case "procesos"
                            procesos.Show()
                            Me.Hide()
                        Case "asistencia"
                            Asistencia.Show()
                            Me.Hide()
                        Case Else
                            MsgBox("Usuario no tiene permisos de entrada al sistema")
                    End Select
                End If
            Else
                MsgBox("El usuario o contraseña no son validos", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Function IsAuthenticated(ByVal domain As String, ByVal username As String, ByVal pwd As String) As Boolean
        Dim path As String = "LDAP://gpozucarmex.corp/DC=gpozucarmex,DC=corp"
        Dim domainAndUsername As String = domain & "\" & username
        Dim entry As DirectoryEntry = New DirectoryEntry(path, domainAndUsername, pwd)
        Try
            Dim obj As Object = entry.NativeObject
            Dim search As DirectorySearcher = New DirectorySearcher(entry)
            search.Filter = "(SAMAccountName=" & username & ")"
            search.PropertiesToLoad.Add("cn")
            Dim result As SearchResult = search.FindOne()
            If (result Is Nothing) Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Sub bot_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_salir.Click
        Me.Close()
    End Sub

    Private Sub txt_clave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_clave.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_pass.Focus()
        End If
    End Sub

    Private Sub txt_pass_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pass.KeyPress
        If e.KeyChar = Chr(13) Then
            bot_entra.PerformClick()
        End If
    End Sub

    Private Sub acceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Keyboard.CapsLock Then
            MsgBox("CAPS LOCK esta activado, puede afectar tu usuario o contraseña", MsgBoxStyle.Information)
        End If
    End Sub
End Class