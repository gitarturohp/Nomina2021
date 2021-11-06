Imports System.IO
Imports Spire.Xls
Public Class nomina
    Public a As New Clase
    Private Sub bot_act_114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim wban = 0
        MsgBox("Usuario No Autorizado")
    End Sub
    Private Sub bot_poliza_cont_Click(sender As System.Object, e As System.EventArgs) Handles bot_poliza_cont.Click
        Dim b As New Clase
        Dim file As System.IO.FileStream
        Dim carpeta = ""
        Dim nombre = ""
        Dim fic As String
        Dim partida = 1
        Dim fecha = ""
        Dim concepto = ""
        Dim cadena = ""
        fbd_carpeta.ShowDialog()
        Dim folio = 0
        carpeta = fbd_carpeta.SelectedPath
        a.qr("select convert(char(10),getdate(),103) fecha", 1)
        a.rs.Read()
        fecha = InputBox("FECHA DE POLIZA:", , "DD/MM/AAAA")
        cadena = InputBox("Ciclo e inicio y terminacion de semana")
        b.qr("select c2_num,c2_documento,c2_serie,sum(case when c2_tipo='C' then c2_importe else 0 end) cargo," +
            " sum(case when c2_tipo='A' then c2_importe else 0 end) abono from acon202" +
            " group by c2_num,c2_documento,c2_serie order by 1,2,3", 1)
        While b.rs.Read
            concepto = InputBox("Concepto de poliza (serie:" + b.rs!c2_serie.ToString + ", Num: " + b.rs!c2_num.ToString + ")", , "")
            concepto = concepto + " " + cadena
            a.qr("select c2_ano,c2_folio from acon201 where c2_ano=2016 and c2_documento=" + b.rs!c2_documento.ToString + " and c2_serie=" + b.rs!c2_serie.ToString, 1)
            a.rs.Read()
            folio = a.rs!c2_folio + 1
            nombre = "Poliza_" + a.rs!c2_ano.ToString + "_" + b.rs!c2_documento.ToString + "_" + b.rs!c2_serie.ToString + "_" + folio.ToString + ".csv"
            fic = carpeta + "\" + nombre
            file = System.IO.File.Create(fic)
            file.Close()
            Dim sw As New System.IO.StreamWriter(fic)
            a.qr("select sum(case when c2_tipo='C' then c2_importe else 0 end) cargo," +
                " sum(case when c2_tipo='C' then c2_importe else 0 end) abono from acon202" +
                " where c2_documento=" + b.rs!c2_documento.ToString + " and c2_num=" + b.rs!c2_num.ToString + " and c2_serie=" + b.rs!c2_serie.ToString, 1)
            a.rs.Read()
            If a.rs!cargo = a.rs!abono Then
                sw.WriteLine("P," + b.rs!c2_documento.ToString + ",10," + b.rs!c2_serie.ToString + "," + folio.ToString + ",," + fecha + "," + a.rs!cargo.ToString + "," + a.rs!abono.ToString + ",1," + fecha + "," + concepto + ",")
                a.qr("select c2_serie serie,c2_centro,replace(c2_cta,'-','') cta,c2_tipo tip,c2_importe imp,replace(rtrim(c2_concepto),',',' ') des from acon202" +
                     " where c2_documento=" + b.rs!c2_documento.ToString + " and c2_serie=" + b.rs!c2_serie.ToString + " and c2_num=" + b.rs!c2_num.ToString, 1)
                While a.rs.Read
                    sw.WriteLine("D," + b.rs!c2_documento.ToString + ",10," + b.rs!c2_serie.ToString + "," + folio.ToString + "," + partida.ToString + ",," + a.rs!c2_centro.ToString + "," + a.rs!cta.ToString + "," + a.rs!tip.ToString + "," + a.rs!imp.ToString + ",0," + a.rs!des)
                    partida = partida + 1
                End While
                sw.Close()
                a.qr("update acon201 set c2_folio=" + folio.ToString + ",c2_fecha=getdate() where c2_ano=2016 and c2_documento=" + b.rs!c2_documento.ToString + " and c2_serie=" + b.rs!c2_serie.ToString, 1)
            Else
                MsgBox("Poliza Descuadrada")
                Exit Sub
            End If
        End While
        MsgBox("Proceso Terminado")
    End Sub
    Private Sub bot_pensiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Usuario No Autorizado")
    End Sub
    Private Sub nomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not Directory.Exists("C:\temp") Then
            Directory.CreateDirectory("c:\temp")
        End If
    End Sub
    Private Sub bot_pol_txt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim file As System.IO.FileStream
        Dim carpeta = ""
        Dim nombre = ""
        Dim fic As String
        Dim partida = 1
        Dim folio = ""
        Dim concepto = ""
        fbd_carpeta.RootFolder = Environment.SpecialFolder.MyComputer
        fbd_carpeta.ShowDialog()
        carpeta = fbd_carpeta.SelectedPath
        'nombre = "Poliza_" + Mid(Date.Today.ToString, 1, 10) + "_" + Mid(TimeOfDay.ToString, 12, 2) + Mid(TimeOfDay.ToString, 15, 2) + ".csv"
        While True
            folio = InputBox("Folio Contable")
            If Val(folio) > 0 And Val(folio) < 9999 Then
                folio = RTrim(LTrim(folio))
                Exit While
            End If
        End While

        concepto = InputBox("Concepto de poliza", "Concepto", "NOMINA DE SEM DEL AL ")
        nombre = "Poliza_220116.txt"
        fic = carpeta + "\" + nombre
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select sum(case when c2_tipo='C' then c2_importe else 0 end) cargo,sum(case when c2_tipo='C' then c2_importe else 0 end) abono from acon202 ", 1)
        a.rs.Read()
        sw.WriteLine("P" + a.ceros("42", 3) + "10002" + a.ceros(folio, 7) + "00022/01/2016" + a.ceros(a.rs!cargo.ToString, 18) + a.ceros(a.rs!abono.ToString, 18) + a.ceros("1", 16) + "22/01/2016" +
                     a.espacios(concepto, 120) + a.espacios("", 80))
        a.qr("select replace(c2_cta,'-','') cta,c2_tipo tip,c2_importe imp,replace(rtrim(c2_concepto),',',' ') des from acon202 order by 1", 1)
        While a.rs.Read
            sw.WriteLine("D" + a.ceros("42", 3) + "10002" + a.ceros(folio, 7) + a.ceros(partida.ToString, 3) + "   000" + a.espacios(a.rs!cta.ToString, 29) +
                         a.rs!tip.ToString + a.ceros(a.rs!imp.ToString, 18) + a.ceros(a.rs!imp.ToString, 18) + a.espacios(a.rs!des, 80) + "000000000000000000000")
            partida = partida + 1
        End While
        sw.Close()
        MsgBox("Realizado")
    End Sub
    Private Sub bot_ahorro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim b As New Clase
        Dim sem = ""
        Dim tponom = "1"
        Dim query = ""
        Dim ciclo = ""
        While True
            sem = InputBox("Semana a Cargar:")
            a.qr("select count(*) num from anom201 where h1_semana=" + sem, 1)
            a.rs.Read()
            If a.rs!num > 0 Then
                Exit While
            End If
        End While
        a.qr("select h1_ciclo from anom201 where h1_semana=" + sem, 1)
        a.rs.Read()
        If a.rs!h1_ciclo = 1 Then
            ciclo = "z"
        Else
            ciclo = "r"
        End If
        While True
            tponom = InputBox("Tipo de Nomina: (1) Obrero  (2)  Confianza", , "1")
            If Val(tponom) > 0 And Val(tponom) < 3 Then
                Exit While
            End If
        End While
        a.qr("select count(*) num from anom502 where k2_semana=" + sem + " and k2_tipo='H' and k2_tponom=" + tponom, 1)
        a.rs.Read()
        If a.rs!num > 0 Then
            MsgBox("Semana ya cargada para timbrado")
        Else
            a.qr("select sum(j1_importe) imp,count(*) cant" +
                " from anom401, anom105, anom201 " +
                " where j1_semana = " + sem +
                " and j1_cpto=(case when j1_tponom=1 then 498 else 557 end)" +
                " and h1_semana=j1_semana" +
                " and j1_tpo_emision<8" +
                " and j1_tponom=" + tponom +
                " and j1_importe!=0" +
                " and j1_numtra=g5_numtra" +
                " and g5_tponom=j1_tponom", 1)
            a.rs.Read()
            If MsgBox("Importe: " + a.rs!imp.ToString + "  Cantidad: " + a.rs!cant.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                a.qr("insert into anom502" +
                    " select 8,j1_numtra,j1_tponom,g5_dptoz,g5_catz,316,h1_fecha_ini,h1_fecha_fin,j1_importe,1,'S',h1_fecha_ini+3,'H',j1_semana,g5_ingreso from anom401,anom105,anom201" +
                    " where j1_semana = " + sem +
                    " and j1_cpto=(case when j1_tponom=1 then 498 else 557 end)" +
                    " and h1_semana=j1_semana" +
                    " and j1_tponom=" + tponom +
                    " and j1_tpo_emision<8" +
                    " and j1_importe!=0" +
                    " and j1_numtra=g5_numtra" +
                    " and g5_tponom=j1_tponom", 2)
                a.qr("insert into anom502" +
                    " select 8,j1_numtra,j1_tponom,g5_dptoz,g5_catz,604,h1_fecha_ini,h1_fecha_fin,j1_importe,1,'S',h1_fecha_ini+3,'H',j1_semana,g5_ingreso from anom401,anom105,anom201" +
                    " where j1_semana = " + sem +
                    " and j1_cpto=(case when j1_tponom=1 then 498 else 557 end)" +
                    " and h1_semana=j1_semana" +
                    " and j1_tponom=" + tponom +
                    " and j1_importe!=0" +
                    " and j1_numtra=g5_numtra" +
                    " and g5_tponom=j1_tponom", 2)
                If tponom = "1" Then
                    a.qr("insert into anom502" +
                        " select 8,j1_numtra,j1_tponom,g5_dptoz,g5_catz,315,h1_fecha_ini,h1_fecha_fin,j1_importe,1,'S',h1_fecha_ini+3,'H',j1_semana,g5_ingreso from anom401,anom105,anom201" +
                        " where j1_semana = " + sem +
                        " and j1_cpto=(case when j1_tponom=1 then 498 else 557 end)" +
                        " and h1_semana=j1_semana" +
                        " and j1_tponom=" + tponom +
                        " and j1_importe!=0" +
                        " and j1_numtra=g5_numtra" +
                        " and g5_tponom=j1_tponom", 2)
                    a.qr("insert into anom502" +
                        " select 8,j1_numtra,j1_tponom,g5_dptoz,g5_catz,557,h1_fecha_ini,h1_fecha_fin,j1_importe,1,'S',h1_fecha_ini+3,'H',j1_semana,g5_ingreso from anom401,anom105,anom201" +
                        " where j1_semana = " + sem +
                        " and j1_cpto=(case when j1_tponom=1 then 498 else 557 end)" +
                        " and h1_semana=j1_semana" +
                        " and j1_tponom=" + tponom +
                        " and j1_importe!=0" +
                        " and j1_numtra=g5_numtra" +
                        " and g5_tponom=j1_tponom", 2)
                End If
                MsgBox("Carga Realizada")
            End If
        End If
    End Sub

    Private Sub bot_lectura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bot_cargar_Click(sender As System.Object, e As System.EventArgs) Handles bot_cargar.Click
        a.qr("select c2_num,c2_documento,c2_serie,sum(case when c2_tipo='C' then c2_importe else 0 end) cargo," +
            " sum(case when c2_tipo='A' then c2_importe else 0 end) abono from acon202" +
            " group by c2_num,c2_documento,c2_serie order by 1,2", 1)
        dgv_polizas.Rows.Clear()
        Dim cont = 0
        While a.rs.Read
            dgv_polizas.Rows.Add(a.rs!c2_num, a.rs!c2_documento, a.rs.Item(2), a.rs!cargo, a.rs!abono)
            cont = cont + 1
        End While
        While cont >= 0
            If dgv_polizas.Rows(cont).Cells(3).Value() <> dgv_polizas.Rows(cont).Cells(4).Value() Then
                dgv_polizas.Rows(cont).DefaultCellStyle.BackColor = Color.Red
            Else
                dgv_polizas.Rows(cont).DefaultCellStyle.BackColor = Color.White
            End If
            cont = cont - 1
        End While
    End Sub

    Private Sub bot_carga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_carga.Click
        Dim miwb As New Workbook
        Dim mish As Worksheet
        Dim cont = 2
        If MsgBox("Eliminar Carga Anterior?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("delete from acon202", 2)
        End If
        If cd.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        miwb.LoadFromFile(cd.FileName)
        mish = miwb.Worksheets(0)
        lbl_cargando.Visible = True
        While True
            If Val(mish.Range(cont, 1).Value) = 0 Then
                lbl_cargando.Text = "CORRECTO"
                MsgBox("Carga Realizada")
                lbl_cargando.Visible = False
                Exit While
            End If
            a.qr("insert into acon202 values('" + mish.Range(cont, 1).Value.ToString + "','" +
                                                  mish.Range(cont, 2).Value.ToString + "'," +
                                                  mish.Range(cont, 3).Value.ToString + ",'" +
                                                  mish.Range(cont, 4).Value.ToString + "'," +
                                                  mish.Range(cont, 5).Value.ToString + "," +
                                                  mish.Range(cont, 6).Value.ToString + "," +
                                                  mish.Range(cont, 7).Value.ToString + "," +
                                                  mish.Range(cont, 8).Value.ToString + ")", 2)
            cont = cont + 1
        End While
        a.qr("delete from acon202 where c2_importe=0", 2)
        miwb = Nothing
        mish = Nothing
    End Sub

    Private Sub bot_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_borrar.Click
        Dim y As Integer
        y = dgv_polizas.CurrentCellAddress.Y
        If Val(y) < 0 Then
            MsgBox("Seleccionar una poliza")
            Exit Sub
        End If
        If Val(dgv_polizas.Rows(y).Cells(0).Value) = 0 Then
            MsgBox("No existe poliza a borrar")
            Exit Sub
        End If
        If MsgBox("Borrar poliza " + dgv_polizas.Rows(y).Cells(0).Value.ToString + "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("delete from acon202 where c2_num in (" + dgv_polizas.Rows(y).Cells(0).Value.ToString + ")", 2)
            bot_cargar.PerformClick()
        End If
    End Sub

    Private Sub nomina_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CargarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarToolStripMenuItem.Click
        bot_carga.PerformClick()
    End Sub

    Private Sub RevisarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisarToolStripMenuItem.Click
        bot_cargar.PerformClick()
    End Sub

    Private Sub CreacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreacionToolStripMenuItem.Click
        bot_poliza_cont.PerformClick()
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarToolStripMenuItem.Click
        bot_borrar.PerformClick()
    End Sub

    Private Sub LectorXMLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LectorXMLToolStripMenuItem.Click
        If Not Directory.Exists("C:\temp\xml") Then
            Directory.CreateDirectory("C:\temp\xml")
        End If
        Dim di As New IO.DirectoryInfo("c:\temp\xml")
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.xml")
        Dim dra As IO.FileInfo

        '//////// CREACION DE ARCHIVO

        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\xml.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        Dim num = 0
        For Each dra In diar1
            sw.WriteLine(num.ToString + Chr(9) + a.xml(dra.ToString))
            num = num + 1
        Next
        sw.Close()
        MsgBox("Proceso terminado con " + num.ToString + " registros")
    End Sub

    Private Sub ImportarPolizasDeNominaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarPolizasDeNominaToolStripMenuItem.Click
        Dim wsem = 202001
        Dim premio = 0
        Dim wpoliza = 0.00
        a.qr("select sum(case when j1_cpto<400 then j1_importe else j1_importe*-1 end) imp from anom401" +
            " where j1_semana=(select i4_ano_sem from anom304)" +
            " and j1_tpo_emision<8" +
            " and j1_tponom=1" +
            " and j1_nomina=1" +
            " and j1_cpto<>498", 1)
        a.rs.Read()
        wpoliza = a.rs!imp
        a.qr("select sum(j1_importe) imp from pagos where j1_tponom=1 and j1_nomina=1", 1)
        a.rs.Read()
        wpoliza = wpoliza - a.rs!imp
        If wpoliza <> 0 Then
            MsgBox("Poliza incorrecta, llamar a nomina")
            Exit Sub
        End If
        a.qr("select top 1 j1_semana from anom401b where j1_nomina=2", 1)
        If a.rs.HasRows Then
            premio = 1
        End If
        a.qr("select top 1 j1_semana from anom401b", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            wsem = a.rs.Item(0)
            a.qr("truncate table acon202", 2)
            a.qr("poliza_nomina " + wsem.ToString + ",1,1", 2)
            a.qr("poliza_nomina " + wsem.ToString + ",2,1", 2)
            If premio = 1 Then
                a.qr("poliza_nomina " + wsem.ToString + ",1,2", 2)
                a.qr("poliza_nomina " + wsem.ToString + ",1,5", 2)
            End If
            a.qr("poliza_nomina " + wsem.ToString + ",1,3", 2)
            a.qr("poliza_nomina " + wsem.ToString + ",2,3", 2)
            a.qr("poliza_nomina " + wsem.ToString + ",1,4", 2)
            a.qr("poliza_nomina " + wsem.ToString + ",2,4", 2)
            a.qr("exec pro_isr_sub_causados " + wsem.ToString, 2)
            MsgBox("Proceso realizado")
        End If

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        cd.ShowDialog()
        Dim wb As New Workbook
        Dim hj As Worksheet
        wb.LoadFromFile(cd.FileName)
        hj = wb.Worksheets(0)
        MsgBox(hj.Range(7, 3).Value.ToString)
        MsgBox(hj.Range("C7").Value.ToString)
    End Sub
End Class