Imports System.IO
Public Class Asistencia
    Public a As New Clase
    Public semana As String
    Private Sub bot_carga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ar As StreamReader
        If cd.ShowDialog() = MsgBoxResult.Ok Then
            Try
                ar = New StreamReader(cd.FileName)
            Catch ex As Exception
                Exit Sub
            End Try
            Dim lin() As String
            Dim fecha As String = ""
            Dim wdia = 0
            Dim arr As New ArrayList
            While ar.Peek() > 0
                lin = Split(ar.ReadLine, Chr(9))
                If Not lin Is Nothing Then
                    If lin(4) = 0 Then
                        fecha = lin(2)
                        fecha = Mid(fecha, 9, 2) + "/" + Mid(fecha, 6, 2) + "/" + Mid(fecha, 1, 4) + Mid(fecha, 11, 9)
                        a.qr("select h2_dia from anom202 where h2_fecha='" + Mid(fecha.ToString, 1, 10) + "'", 1)
                        a.rs.Read()
                        wdia = a.rs!h2_dia
                        a.qr("select * from anom204 where convert(char(10),h4_fecha,103)='" + Mid(fecha, 1, 10) + "' and h4_numtra=" + lin(1).ToString, 1)
                        If Not a.rs.HasRows Then
                            a.qr("insert into anom204 values(" + lin(0).ToString + "," + lin(1).ToString + ",'" + fecha + "'," + wdia.ToString + "," + lin(4).ToString + ")", 2)
                        End If
                    End If
                End If
            End While
            MsgBox("Carga realizada")
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub CapturaDeAsistenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturaDeAsistenciaToolStripMenuItem.Click
        If MsgBox("Se enviara asistencia a nomina semana " + semana + ", los datos que se tengan capturados se eliminaran", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("asistencia " + semana, 2)
            MsgBox("Proceso realizado")
        End If
    End Sub
    Private Sub SalariosIMSSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalariosIMSSToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\SDI_empleados.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select g5_tponom,g5_numtra,g5_sasegi from anom105 where g5_tponom=1", 1)
        While a.rs.Read
            sw.WriteLine(a.rs!g5_tponom.ToString + Chr(9) + a.rs!g5_numtra.ToString + Chr(9) + a.rs!g5_sasegi.ToString)
        End While
        sw.Close()
        fic = "c:\temp\SDI_empleado.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        sw = New System.IO.StreamWriter(fic)
        a.qr("select g5_tponom,g5_numtra,g5_sasegi from anom105 where g5_tponom=2", 1)
        While a.rs.Read
            sw.WriteLine(a.rs!g5_tponom.ToString + Chr(9) + a.rs!g5_numtra.ToString + Chr(9) + a.rs!g5_sasegi.ToString)
        End While
        sw.Close()
        MsgBox("Proceso terminado")
    End Sub

    Private Sub Asistencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        a.qr("select i4_ano_sem from anom304", 1)
        a.rs.Read()
        semana = a.rs!i4_ano_sem
        While True
            semana = InputBox("Semana",, semana)
            a.qr("select * from anom201 where h1_semana=" + semana, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                Exit While
            End If
        End While
        lbl_semana.Text = a.rs!h1_semana
    End Sub
    Private Sub ReporteDeAsistenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeAsistenciaToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String
        Dim sw As System.IO.StreamWriter
        a.qr("select * from anom201 where h1_semana=" + semana, 1)
        If Not a.rs.HasRows Then
            MsgBox("Semana no existe")
            Exit Sub
        End If
        fic = "c:\temp\Asistencia_" + semana + ".csv"
        file = System.IO.File.Create(fic)
        file.Close()
        sw = New System.IO.StreamWriter(fic)
        sw.WriteLine("NUMTRA,NOMBRE,DEPTO,LUN,MAR,MIE,JUE,VIE,SAB,DOM,HOR_LUN,HOR_MAR,HOR_MIE,HOR_JUE,HOR_VIE,HOR_SAB,HOR_DOM")
        a.qr("reporte_asistencia_confianza " + semana, 1)
        While a.rs.Read
            sw.WriteLine(a.rs.Item(0).ToString + "," +
                         a.rs.Item(1).ToString + "," +
                         a.rs.Item(2).ToString + "," +
                         a.rs.Item(3).ToString + "," +
                         a.rs.Item(4).ToString + "," +
                         a.rs.Item(5).ToString + "," +
                         a.rs.Item(6).ToString + "," +
                         a.rs.Item(7).ToString + "," +
                         a.rs.Item(8).ToString + "," +
                         a.rs.Item(9).ToString + "," +
                         a.rs.Item(10).ToString + "," +
                         a.rs.Item(11).ToString + "," +
                         a.rs.Item(12).ToString + "," +
                         a.rs.Item(13).ToString + "," +
                         a.rs.Item(14).ToString + "," +
                         a.rs.Item(15).ToString + "," +
                         a.rs.Item(16).ToString)
        End While
        sw.Close()
        Process.Start(fic)
    End Sub
    Private Sub bot_tab1_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_tab1_mostrar.Click
        dgv_reloj.Rows.Clear()
        a.qr("select tipo,descrip,max(case when familia=15 then 'X' else '' end ) FIJOS," +
                    " max(case when familia=16 then 'X' else '' end ) RELOJ," +
                    " max(case when familia=17 then 'X' else '' end ) DOMINGO," +
                    " max(case when familia=22 then 'X' else '' end ) DOMREP from catalogos" +
                    " where familia in (15,16,17,22)" +
                    " group by tipo,descrip" +
                    " order by 1", 1)
        While a.rs.Read
            dgv_reloj.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4), a.rs.Item(5))
        End While
    End Sub

    Private Sub txt_numtra_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numtra.Leave
        chk_fijo.Checked = False
        chk_reloj.Checked = False
        chk_domfes.Checked = False
        chk_domrep.Checked = False
        a.qr("select tipo,descrip,max(case when familia=15 then 'X' else '' end) fij,max(case when familia=16 then 'X' else '' end) rel,max(case when familia=17 then 'X' else '' end) dom,max(case when familia=22 then 'X' else '' end) dorep from catalogos" +
                " where familia in (15,16,17,22)" +
                " and tipo=" + txt_numtra.Text +
                " group by tipo,descrip", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            txt_nom_numtra.Text = a.rs!descrip
            If a.rs!fij = "X" Then
                chk_fijo.Checked = True
            End If
            If a.rs!rel = "X" Then
                chk_reloj.Checked = True
            End If
            If a.rs!dom = "X" Then
                chk_domfes.Checked = True
            End If
            If a.rs!dorep = "X" Then
                chk_domrep.Checked = True
            End If
        Else
            a.qr("select nombre from nombres where tponom=2 and numtra=" + txt_numtra.Text, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                txt_nom_numtra.Text = a.rs!nombre
            Else
                MsgBox("Numero de trabajador no existe")
                Exit Sub
            End If
        End If
        a.qr("select descrip from catalogos where familia=21 and tipo=" + txt_numtra.Text, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            txt_correo.Text = a.rs!descrip
        End If
    End Sub

    Private Sub tab_captura_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab_captura.Leave
        chk_fijo.Checked = False
        chk_reloj.Checked = False
        chk_domfes.Checked = False
        chk_domrep.Checked = False
        txt_nom_numtra.Text = ""
        txt_numtra.Text = ""
        txt_correo.Text = ""
    End Sub

    Private Sub bot_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_guardar.Click
        Dim query = "insert into catalogos values ("
        If chk_fijo.Checked = True And chk_reloj.Checked = True Then
            MsgBox("No puede tener asistencia fija y por reloj")
            Exit Sub
        End If
        If chk_fijo.Checked = True Then
            a.qr("select * from catalogos where familia in (15) and tipo=" + txt_numtra.Text, 1)
            If Not a.rs.HasRows Then
                query = query + "15," + txt_numtra.Text + ",'" + txt_nom_numtra.Text + "','A')"
                a.qr(query, 2)
            End If
        Else
            a.qr("delete from catalogos where familia=15 and tipo='" + txt_numtra.Text + "'", 2)
        End If
        If chk_reloj.Checked = True Then
            a.qr("select * from catalogos where familia in (16) and tipo=" + txt_numtra.Text, 1)
            If Not a.rs.HasRows Then
                query = query + "16," + txt_numtra.Text + ",'" + txt_nom_numtra.Text + "','A')"
                a.qr(query, 2)
            End If
        Else
            a.qr("delete from catalogos where familia=16 and tipo='" + txt_numtra.Text + "'", 2)
        End If
        If chk_domrep.Checked = True Then
            a.qr("select * from catalogos where familia in (22) and tipo=" + txt_numtra.Text, 1)
            If Not a.rs.HasRows Then
                query = query + "22," + txt_numtra.Text + ",'" + txt_nom_numtra.Text + "','F')"
                a.qr(query, 2)
            End If
        Else
            a.qr("delete from catalogos where familia=22 and tipo='" + txt_numtra.Text + "'", 2)
        End If
        If chk_domfes.Checked = True Then
            a.qr("select * from catalogos where familia in (17) and tipo=" + txt_numtra.Text, 1)
            If Not a.rs.HasRows Then
                query = query + "17," + txt_numtra.Text + ",'" + txt_nom_numtra.Text + "','A')"
                a.qr(query, 2)
            End If
        Else
            a.qr("delete from catalogos where familia=17 and tipo='" + txt_numtra.Text + "'", 2)
        End If
        If Len(txt_correo.Text) > 0 Then
            a.qr("select descrip from catalogos where familia=21 and tipo=" + txt_numtra.Text, 1)
            If a.rs.HasRows Then
                a.qr("update catalogos set descrip='" + txt_correo.Text + "' where familia=21 and tipo='" + txt_numtra.Text + "'", 2)
            Else
                a.qr("insert into catalogos values (21,'" + txt_numtra.Text + "','" + txt_correo.Text + "','A')", 2)
            End If
        End If
        MsgBox("Proceso realizado")
        chk_fijo.Checked = False
        chk_reloj.Checked = False
        chk_domfes.Checked = False
        chk_domrep.Checked = False
        txt_nom_numtra.Text = ""
        txt_numtra.Text = ""
        txt_correo.Text = ""
    End Sub

    Private Sub txt_numtra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numtra.KeyPress
        If e.KeyChar = Chr(13) Then
            bot_guardar.Focus()
        End If
    End Sub

    Private Sub tab_reloj_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab_reloj.Leave
        dgv_reloj.Rows.Clear()
    End Sub

    Private Sub CargaAsistenciaDeRelojToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargaAsistenciaDeRelojToolStripMenuItem.Click
        Dim ar As StreamReader
        If cd.ShowDialog() = MsgBoxResult.Ok Then
            Try
                ar = New StreamReader(cd.FileName)
            Catch ex As Exception
                Exit Sub
            End Try
            Dim lin() As String
            Dim fecha As String = ""
            Dim wdia = 0
            Dim arr As New ArrayList
            While ar.Peek() > 0
                lin = Split(ar.ReadLine, Chr(9))
                If Not lin Is Nothing Then
                    If lin(4) = 0 Then
                        fecha = lin(2)
                        fecha = Mid(fecha, 9, 2) + "/" + Mid(fecha, 6, 2) + "/" + Mid(fecha, 1, 4) + Mid(fecha, 11, 9)
                        a.qr("select h2_dia from anom202 where h2_fecha='" + Mid(fecha.ToString, 1, 10) + "'", 1)
                        a.rs.Read()
                        wdia = a.rs!h2_dia
                        a.qr("select * from anom204 where convert(char(10),h4_fecha,103)='" + Mid(fecha, 1, 10) + "' and h4_numtra=" + lin(1).ToString, 1)
                        If Not a.rs.HasRows Then
                            a.qr("insert into anom204 values(" + lin(0).ToString + "," + lin(1).ToString + ",'" + fecha + "'," + wdia.ToString + "," + lin(4).ToString + ")", 2)
                        End If
                    End If
                End If
            End While
            MsgBox("Carga realizada")
        End If
    End Sub

    Private Sub CargarIncapacidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarIncapacidadesToolStripMenuItem.Click
        Dim objReader As StreamReader
        Dim sLine As String = ""
        Dim linea(23)
        Dim cont = 0
        Dim archivo = ""
        If cd.ShowDialog = DialogResult.OK Then
            archivo = cd.FileName
            objReader = New StreamReader(archivo)
            Do
                sLine = objReader.ReadLine()
                If cont > 0 And Len(sLine) > 0 Then
                    linea = Split(sLine, ",")
                    a.qr("select * from incapacidades where numtra=" + linea(2) + " and fecha='" + linea(4) + "' and dias=" + linea(5), 1)
                    If a.rs.HasRows Then
                        a.qr("update incapacidades set rama='" + linea(9) + "' " + "where numtra=" + linea(2) + " and fecha='" + linea(4) + "' and dias=" + linea(5), 2)
                    Else
                        a.qr("insert into incapacidades values (" + linea(2).ToString + ",'" +
                             linea(4).ToString + "'," +
                             linea(5).ToString + ",'" +
                             linea(9).ToString + "'," +
                             linea(11).ToString + ")", 2)
                    End If
                End If
                cont += 1
            Loop Until sLine Is Nothing
            objReader.Close()
        End If
        MsgBox("termino")
    End Sub

    Private Sub bot_mostrar_Click(sender As Object, e As EventArgs) Handles bot_mostrar.Click
        Dim query = ""
        Dim varios = 0
        query = "select a.numtra,nombre,convert(char(10),fecha,103),dias,rama,catego from incapacidades a,nombres b" +
                " where tponom=(case when a.numtra<20000 then 1 else 2 end)" +
                " And a.numtra = b.numtra"
        If Len(cmb_inc_rama.Text) > 0 Then
            query += " and rama='" + cmb_inc_rama.Text + "'"
        End If
        If Len(cmb_inc_estado.Text) > 0 Then
            If Mid(cmb_inc_estado.Text, 1, 1) = "V" Then
                query += " and dateadd(day,dias,fecha)>=getdate()"
            End If
        End If
        If IsDate(txt_inc_fecha.Text) Then
            query += " and fecha='" + txt_inc_fecha.Text + "'"
        End If
        If Val(txt_inc_numtra.Text) > 0 Then
            query += " and a.numtra=" + txt_inc_numtra.Text.ToString
        End If
        query += " order by 1 asc,fecha desc"
        a.qr(query, 1)
        dgv_incapacidades.Rows.Clear()
        While a.rs.Read
            varios += 1
            dgv_incapacidades.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4), a.rs.Item(5))
            If varios = 200 Then
                MsgBox("Consulta con mas de 200 registros, aplicar filtros.")
                Exit While
            End If
        End While
    End Sub

    Private Sub bot_inc_eliminar_Click(sender As Object, e As EventArgs) Handles bot_inc_eliminar.Click
        Dim numtra = 0
        Dim fecha = ""
        Dim dias = 0
        If dgv_incapacidades.Rows.Count = 0 Then
            MsgBox("Seleccionar registro")
        Else
            numtra = dgv_incapacidades.Rows(dgv_incapacidades.CurrentCellAddress.Y).Cells(0).Value
            fecha = dgv_incapacidades.Rows(dgv_incapacidades.CurrentCellAddress.Y).Cells(2).Value
            dias = dgv_incapacidades.Rows(dgv_incapacidades.CurrentCellAddress.Y).Cells(3).Value
            a.qr("select * from incapacidades " +
                   " where numtra=" + numtra.ToString +
                   " and fecha='" + fecha + "'" +
                   " and dias=" + dias.ToString, 1)
            If a.rs.HasRows Then
                a.qr("delete from incapacidades" +
                   " where numtra=" + numtra.ToString +
                   " and fecha='" + fecha + "'" +
                   " and dias=" + dias.ToString, 2)
                bot_mostrar.PerformClick()
                MsgBox("Registro borrado")
            End If
        End If
    End Sub

    Private Sub bot_inc_guardar_Click(sender As Object, e As EventArgs) Handles bot_inc_guardar.Click
        Dim numtra = 0
        Dim fecha = ""
        Dim dias = 0
        Dim rama = ""
        Dim catego = 0
        numtra = Val(txt_inc_numtra.Text)
        If numtra = 0 Then
            MsgBox("Falta numero de trabajador")
            Exit Sub
        End If
        rama = cmb_inc_rama.Text
        If Len(rama) = 0 Then
            MsgBox("Falta rama")
            Exit Sub
        End If
        dias = Val(txt_inc_dias.Text)
        If dias = 0 Then
            MsgBox("Faltan dias de incapacidad")
            Exit Sub
        End If
        fecha = txt_inc_fecha.Text
        If Not IsDate(fecha) Then
            MsgBox("Fecha incorrecta")
            Exit Sub
        End If
        catego = Val(txt_inc_catego.Text)
        If catego = 0 Then
            MsgBox("Falta categoria")
            Exit Sub
        Else
            a.qr("select * from anom102 where g2_catego=" + catego.ToString, 1)
            If Not a.rs.HasRows Then
                MsgBox("Categoria no existe")
                Exit Sub
            End If
        End If
        a.qr("select * from incapacidades " +
                   " where numtra=" + numtra.ToString +
                   " and fecha='" + fecha + "'" +
                   " and dias=" + dias.ToString, 1)
        If a.rs.HasRows Then
            MsgBox("Registro existente")
            Exit Sub
        End If
        a.qr("insert into incapacidades values (" + numtra.ToString + ",'" + fecha + "'," + dias.ToString + ",'" + rama + "'," + catego.ToString + ")", 2)
        MsgBox("Registro insertado")
        borrar()
        txt_inc_numtra.Text = numtra
        txt_inc_fecha.Text = fecha
        bot_mostrar.PerformClick()
    End Sub
    Sub borrar()
        txt_inc_numtra.Text = ""
        txt_inc_dias.Text = ""
        txt_inc_fecha.Text = ""
        txt_inc_catego.Text = ""
        cmb_inc_estado.SelectedIndex = -1
        cmb_inc_rama.SelectedIndex = -1
    End Sub
End Class