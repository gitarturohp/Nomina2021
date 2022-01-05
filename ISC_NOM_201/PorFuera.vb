Imports System.IO
Imports System.Threading
Imports Spire.Xls
Public Class PorFuera
    Dim a As New Clase
    Dim b As New Clase
    Private trd_timbrado As Thread
    Private Sub cmb_numtra_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Dim LenText As Long, ret As Long
        'Si los caracteres presionados están entre el 0 y la Z  
        'MsgBox(e.KeyCode)
        If e.KeyCode >= 48 And e.KeyCode <= 105 Then
            'ret = SendMessage(cmb_numtra.hwnd, &H14C&, -1, ByVal Combo1.Text)  

            'If ret >= 0 Then
            'LenText = Len(cmb_numtra.Text)
            'cmb_numtra.ListIndex = ret
            'cmb_numtra.Text = Combo1.List(ret)
            'cmb_numtra.SelStart = LenText
            'cmb_numtra.SelLength = Len(Combo1.Text) - LenText
            'End If
        End If
    End Sub

    Private Sub cmb_numtra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_reporte.Click
        Dim archivo As System.IO.FileStream
        Dim fic As String
        Dim cont = 0
        Dim sem = 0
        txt_neto_pagar.Text = "0.00"
        archivo = System.IO.File.Create("c:\temp\reporte.txt")
        archivo.Close()
        fic = "c:\temp\reporte.doc"
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("                   REPORTE DE ENVIO A CFDI")
        sw.WriteLine("------------------------------------------------------------------")
        sw.WriteLine("  TPONOM   NUMTRA   NOMBRE                            IMPORTE")
        sw.WriteLine("------------------------------------------------------------------")
        sw.Close()
        dgr_conceptos.Rows.Clear()
        a.qr("select top 1 k2_semana from anom502 where k2_estado=1", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            sem = a.rs!k2_semana
        End If
        If sem > 0 Then
            a.qr("update anom304 set i4_ano_sem=" + sem.ToString, 2)
            a.qr("update anom304 set  i4_inisem=(select h1_fecha_ini from anom201 where h1_semana=i4_ano_sem)," + _
                " i4_finsem=(select h1_fecha_fin from anom201 where h1_semana=i4_ano_sem)," + _
                " i4_numfes=(select count(*) from anom202,anom201 where h2_festivo='S' and h2_fecha between h1_fecha_ini and h1_fecha_fin and h1_semana=i4_ano_sem)," + _
                " i4_ciclo=(select case when h1_ciclo=1 then 'Z' else 'R' end from anom201 where h1_semana=i4_ano_sem)," + _
                " i4_numsem=(select right(convert(char(6),i4_ano_sem),2))", 2)
        End If
        a.qr("select k2_tponom,k2_tipo,k2_cpto,count(*) cont,sum(k2_importe) importe from anom502,anom104" + _
            " where k2_estado=1 and k2_cpto=g4_cpto group by k2_tponom,k2_tipo,k2_cpto", 1)
        While a.rs.Read
            dgr_conceptos.Rows.Add(a.rs!k2_tponom.ToString, a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4))
            cont = cont + 1
        End While
        cont = cont - 1
        While cont >= 0
            If dgr_conceptos.Rows(cont).Cells(2).Value < 400 Then
                txt_neto_pagar.Text = txt_neto_pagar.Text + dgr_conceptos.Rows(cont).Cells(4).Value
            Else
                txt_neto_pagar.Text = txt_neto_pagar.Text - dgr_conceptos.Rows(cont).Cells(4).Value
            End If
            cont = cont - 1
        End While
        txt_neto_pagar.Text = FormatCurrency(txt_neto_pagar.Text)
    End Sub

    Private Sub bot_carga_xml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_carga_xml.Click
        Dim ar As StreamReader
        Dim sem = ""
        Dim fecpago = ""
        Dim cont = 2
        Dim lin() As String
        While True
            sem = InputBox("Semana")
            If Val(sem) = 0 Then
                Exit sub
            End If
            a.qr("select * from anom201 where h1_semana=" + sem.ToString, 1)
            a.rs.Read()
            If a.rs.HasRows Then
                sem = a.rs!h1_semana.ToString
                a.qr("select j2_cerrado from anom402 where j2_semana=" + sem, 1)
                a.rs.Read()
                If a.rs!j2_cerrado = "S" Then
                    MsgBox("Semana cerrada para timbrado")
                    Exit Sub
                Else
                    Exit While
                End If
            End If
        End While
        While True
            fecpago = InputBox("fecha de pago :", "Fecha de Pago", "DD/MM/AAAA")
            If IsDate(fecpago.ToString) Then
                Exit While
            End If
            If Val(fecpago) = 0 Then
                Exit Sub
            End If
        End While
        If cd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ar = New StreamReader(cd.FileName)
            While True
                lin = Split(ar.ReadLine, Chr(9))
                If Len(lin(0)) = 0 Then
                    Exit While
                End If
                Select Case lin(8)
                    Case 1
                        a.qr("select * from anom105 where g5_tponom=" + lin(8).ToString + " and g5_numtra=" + lin(0).ToString, 1)
                    Case 2
                        a.qr("select * from anom105 where g5_tponom=" + lin(8).ToString + " and g5_numtra=" + lin(0).ToString, 1)
                    Case 3
                        a.qr("select * from vacre102 where v_relab=14 and v_clave=" + lin(0).ToString, 1)
                    Case 4
                        a.qr("select * from vacre102 where v_relab=15 and v_clave=" + lin(0).ToString, 1)
                    Case Else
                        a.qr("select i8_clave from aing108 where i8_relab=11 and i8_clabe='" + lin(0).ToString + "'", 1)
                End Select
                If Not a.rs.HasRows Then
                    MsgBox("Error numero de trabajador no existe: fila " + cont.ToString)
                    Exit Sub
                End If
                a.qr("select * from anom103 where g3_cc=" + lin(1).ToString, 1)
                If Not a.rs.HasRows Then
                    MsgBox("Departamento no existe: fila " + cont.ToString)
                    Exit Sub
                End If
                a.qr("select * from anom102 where g2_catego=" + lin(2).ToString, 1)
                If Not a.rs.HasRows Then
                    MsgBox("Categoria no existe: fila " + cont.ToString)
                    Exit Sub
                End If
                a.qr("select * from anom104 where g4_cpto=" + lin(3).ToString, 1)
                If Not a.rs.HasRows Then
                    MsgBox("Concepto no existe: fila " + cont.ToString)
                    Exit Sub
                End If
                If Not IsDate(lin(4)) Then
                    MsgBox("Fecha inicial erronea: fila " + cont.ToString)
                    Exit Sub
                End If
                If DateTime.Compare(lin(4), fecpago) > 0 Then
                    MsgBox("Fecha pago anterior a fecha inicial: fila " + cont.ToString)
                    Exit Sub
                End If
                If Not IsDate(lin(5)) Then
                    MsgBox("Fecha final erronea: fila " + cont.ToString)
                    Exit Sub
                End If
                If DateTime.Compare(lin(4), lin(5)) > 0 Then
                    MsgBox("Fecha final es anterior a fecha inicial: fila " + cont.ToString)
                    Exit Sub
                End If
                If Not IsDate(lin(7)) Then
                    MsgBox("Fecha ingreso erronea: fila " + cont.ToString)
                    Exit Sub
                End If
                a.qr("select * from catalogos where familia=3 and letra='" + lin(9).ToString + "'", 1)
                If Not a.rs.HasRows Then
                    MsgBox("tipo de pago erroneo: fila " + cont.ToString)
                    Exit Sub
                End If
                cont += 1
            End While
        End If
        lbl_cargando.Visible = True
        ar.Close()
        ar = Nothing
        ar = New StreamReader(cd.FileName)
        While True
            lin = Split(ar.ReadLine, Chr(9))
            If Val(lin(0)) = 0 Then
                lbl_cargando.Text = "CORRECTO"
                MsgBox("Carga Realizada")
                lbl_cargando.Text = "CARGANDO . . ."
                lbl_cargando.Visible = False
                Exit While
            End If
            Try
                If Len(lin(0)) > 5 Then
                    a.qr("select i8_clave from aing108 where i8_relab=11 and i8_clabe='" + lin(0).ToString + "'", 1)
                    a.rs.Read()
                    a.qr("insert into anom502 values(8," + a.rs!i8_clave.ToString + "," + lin(8).ToString + "," + lin(1).ToString + _
                         "," + lin(2).ToString + "," + lin(3).ToString + ",'" + Mid(lin(4).ToString, 1, 10) + "','" + _
                         Mid(lin(5).ToString, 1, 10) + "'," + lin(6).ToString + ",1,'N','" + fecpago + "','" + lin(9).ToString + "'," + sem.ToString + ",'" + _
                         Mid(lin(7).ToString, 1, 10) + "')", 2)
                Else
                    a.qr("insert into anom502 values(8," + lin(0).ToString + "," + lin(8).ToString + "," + lin(1).ToString + _
                         "," + lin(2).ToString + "," + lin(3).ToString + ",'" + Mid(lin(4).ToString, 1, 10) + "','" + _
                         Mid(lin(5).ToString, 1, 10) + "'," + lin(6).ToString + ",1,'N','" + fecpago + "','" + lin(9).ToString + "'," + sem.ToString + ",'" + _
                         Mid(lin(7).ToString, 1, 10) + "')", 2)
                End If
            Catch ex As Exception
                MsgBox("Error en el archivo, revisar el origen, no debe existir celdas sin valor")
                Exit While
            End Try
        End While
        lbl_cargando.Visible = False
        a.qr("update anom402 set j2_cerrado='S' where j2_semana<=(select max(j2_semana)-2 from anom402) and j2_cerrado='N'", 2)
    End Sub
    Private Sub bot_car_xml_jub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cargas.Show()
    End Sub
    Private Sub bot_cfdi_junto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_cfdi_junto.Click
        trd_timbrado = Nothing
        trd_timbrado = New Thread(AddressOf timbrado3)
        trd_timbrado.IsBackground = True
        prb_estado.Value = 50
        trd_timbrado.Start()
    End Sub

    Private Sub bot_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_limpiar.Click
        Dim ban = 0
        Dim b As New Clase
        Dim semana = ""
        Dim fecha = ""
        If MsgBox("Actualizar estado procesado?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("update anom502 set k2_estado=2 where k2_estado=1", 2)
            If MsgBox("Cargar txt?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                While True
                    semana = InputBox("Semana: ")
                    fecha = InputBox("Fecha de pago: ")
                    a.qr("select count(*) num from anom201 where h1_semana=" + semana, 1)
                    a.rs.Read()
                    If a.rs!num > 0 Then
                        Exit While
                    End If
                End While
                a.qr("delete from anom502a", 2)
                arc_carga_txt.Filter = "Archivos de Textillo (*.txt)|*.txt"
                arc_carga_txt.ShowDialog()
                a.qr("BULK INSERT anom502a from 'd:\servidor\" + RTrim(Mid(arc_carga_txt.FileName.ToString, 4, 30)) + "' with(ROWTERMINATOR='\n',FIELDTERMINATOR ='\t')", 2)
                a.qr("select * from anom502a", 1)
                While a.rs.Read
                    b.qr("insert into anom502 values (8," + a.rs!k2_numtra.ToString + "," + a.rs!k2_tponom.ToString + "," + a.rs!k2_depto.ToString + "," + a.rs!k2_catego.ToString + "," + _
                           a.rs!k2_cpto.ToString + ",'" + Mid(a.rs!k2_fec_ini.ToString, 1, 10) + "','" + Mid(a.rs!k2_fec_fin.ToString, 1, 10) + "'," + a.rs!k2_importe.ToString + ",1,'N','" + _
                           fecha + "','" + a.rs!k2_tipo.ToString + "'," + semana + ",'" + Mid(a.rs!k2_fec_ini_lab.ToString, 1, 10) + "')", 2)
                End While
                ban = 1
            End If
            If ban = 0 Then
                MsgBox("Limpieza Realizada")
            Else
                a.qr("select count(*) num from anom502 where k2_estado=1", 1)
                a.rs.Read()
                MsgBox("Limpieza y Carga Realizada, " + a.rs!num.ToString + " filas insertadas")
            End If
        End If
        dgr_conceptos.Rows.Clear()
    End Sub
    Private Sub bot_procesados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_procesados.Click
        Dim cont = 0
        Dim sem = 0
        While True
            sem = InputBox("Semana")
            a.qr("select * from anom201 where h1_semana=" + sem.ToString, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        txt_neto_pagar.Text = "0.00"
        dgr_conceptos.Rows.Clear()
        a.qr("select k2_tponom,k2_tipo,0,count(distinct k2_numtra) cont,sum(case when k2_cpto<400 then k2_importe else k2_importe*-1 end) importe " +
            " from anom502, anom104" +
            " where k2_estado = 2" +
            " and k2_semana=" + sem.ToString +
            " and k2_cpto=g4_cpto " +
            " group by k2_tponom,k2_tipo " +
            " order by 1,2", 1)
        While a.rs.Read
            dgr_conceptos.Rows.Add(a.rs!k2_tponom.ToString, a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4))
            cont = cont + 1
        End While
        cont = cont - 1
        While cont >= 0
            If dgr_conceptos.Rows(cont).Cells(2).Value < 400 Then
                txt_neto_pagar.Text = txt_neto_pagar.Text + dgr_conceptos.Rows(cont).Cells(4).Value
            Else
                txt_neto_pagar.Text = txt_neto_pagar.Text - dgr_conceptos.Rows(cont).Cells(4).Value
            End If
            cont = cont - 1
        End While
        '========= CREACION DE REPORTE ==========='
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\r_anom502a.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("REPORTE DE TIMBRADO POR SEMANA " + sem.ToString)
        sw.WriteLine("================================================================================")
        sw.WriteLine("TIPO  TPONOM   NUMTRA         NOMBRE                           IMPORTE")
        sw.WriteLine("================================================================================")
        a.qr("exec r_anom502a " + sem.ToString, 1)
        While a.rs.Read
            sw.WriteLine(" " + a.rs.Item(0).ToString + "      " + a.rs.Item(1).ToString + "      " + a.rs.Item(2).ToString.PadLeft(5, " ") + "    " + a.rs.Item(3).ToString.PadRight(40, " ") + " " + a.rs.Item(4).ToString.PadLeft(15, " "))
        End While
        sw.Close()
    End Sub

    Private Sub PorFuera_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar.ToString = Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub PorFuera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If Environment.UserName = "aherrerap" Then
            bot_borrar.Enabled = True
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Timbrado2017ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timbrado2017ToolStripMenuItem.Click
        MsgBox("Timbrado deshabilitado, hablar a sistemas. 8104")
        Exit Sub
        trd_timbrado = Nothing
        trd_timbrado = New Thread(AddressOf timbrado)
        trd_timbrado.IsBackground = True
        prb_estado.Value = 50
        trd_timbrado.Start()
    End Sub
    Private Sub timbrado()
        Dim file As System.IO.FileStream
        Dim wchar As Integer = Asc("|")
        Dim fic As String
        Dim folio = 1
        Dim det As New Clase
        Dim ban = 0
        Dim tot = 0
        Dim w_tponom = 1
        Dim w_nomina = 1
        Dim w_numtra = 1
        Dim w_per = 1
        Dim w_ded = 1
        Dim w_otp = 1
        Dim w_query = ""
        Dim fecpag
        Dim wserie
        Dim wtipo = ""
        Dim wjubtot = 0.0
        Dim wjubpar = 0.0
        Dim wfinper = 0.0
        Dim wfinacu = 0.0
        Dim w_tiempo = Mid(TimeOfDay.ToString, 12, 8)
        Dim datos(10) As String
        While True
            w_tponom = InputBox("TIPO DE NOMINA: " + Chr(13) + "1.- SINDICALIZADO" + Chr(13) + "2.- CONFIANZA" + Chr(13) + "3.- JUBILADOS" + Chr(13) + "4.- BECARIOS")
            If Val(w_tponom) = 0 Then
                trd_timbrado.Abort()
                Exit Sub
            End If
            If Val(w_tponom) > 0 And Val(w_tponom) < 5 Then
                Exit While
            End If
        End While
        a.qr("select distinct k2_tipo from anom502 where k2_estado=1 and k2_tponom=" + w_tponom.ToString, 1)
        While a.rs.Read
            w_query = w_query + UCase(a.rs!k2_tipo) + ","
        End While
        While True
            wtipo = UCase(InputBox("Selecciona Tipo " + w_query))
            If InStr(w_query, wtipo) > 0 Then
                Exit While
            End If
            If Len(wtipo) = 0 Then
                Exit Sub
            End If
        End While
        Select Case wtipo
            Case "A"
                wserie = "PRESTACION"
            Case "F"
                wserie = "FINIQUITO"
            Case "D"
                wserie = "DESPENSA"
            Case "J"
                wserie = "JUBILADOSQUINCENAL"
            Case "G"
                wserie = "JUBILADOSMENSUAL"
            Case "E"
                wserie = "BECARIOS"
            Case "I"
                wserie = "PAGOUNICO"
            Case "V"
                wserie = "VIATICOS"
            Case "K"
                wserie = "DEFUNCION"
            Case "P"
                wserie = "PRIMA"
            Case "S"
                wserie = "SEGUROVIDA"
            Case "C"
                wserie = "CONVENIO"
            Case "T"
                wserie = "UTILIDADES"
            Case "M"
                wserie = "EMOLUMENTOS"
            Case Else
                wserie = "NOMINA"
        End Select
        '==== temp1
        a.qr("timbrado 1," + w_tponom.ToString + ",2,'" + wtipo + "'", 2)
        '===== temp2
        a.qr("catdepto 1," + w_tponom.ToString + ",2,'" + wtipo + "'", 2)
        '===== temp3
        a.qr("cargadetalle 1," + w_tponom.ToString + ",2,'" + wtipo + "'", 2)
        '===== CARGA DATOS GENERALES
        a.qr("select g1_reg_patron regimss,i4_ciclo ciclo,i4_ano_sem semana,j2_serie serie,g1_nombre,g1_rfc,replace(convert(char(20),h1_fecha_fin+4,111),'/','-') pago," + _
             " replace(convert(char(20),h1_fecha_ini,111),'/','-') ini,replace(convert(char(20),h1_fecha_fin,111),'/','-') fin,g1_cp" + _
             " from anom304,anom402,anom101,anom201 " + _
             " where i4_ano_sem=j2_semana" + _
             " and j2_semana=h1_semana", 1)
        a.rs.Read()
        datos(0) = a.rs!regimss
        datos(1) = a.rs!ciclo
        datos(2) = a.rs!semana.ToString
        datos(3) = wserie
        datos(4) = a.rs!g1_nombre
        datos(5) = a.rs!g1_rfc
        datos(6) = fecpag
        datos(7) = a.rs!fin
        datos(8) = a.rs!ini
        datos(9) = a.rs!g1_cp.ToString
        Select Case w_tponom
            Case 1
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_OBRERO_" + wtipo.ToString + ".txt"
            Case 2
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_EMPLEADO_" + wtipo.ToString + ".txt"
            Case 3
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_JUBILADO_" + wtipo.ToString + ".txt"
            Case 4
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_BECARIO_" + wtipo.ToString + ".txt"
        End Select
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select count(*) num from temp1 where t1_tponom=" + w_tponom.ToString, 1)
        a.rs.Read()
        MsgBox("Registros a procesar: " + a.rs!num.ToString)
        tot = a.rs!num
        '===== LISTADO GENERAL DE TIMBRADO
        w_numtra = 1
        w_per = 1
        w_ded = 1
        w_otp = 1
        Select Case Val(w_tponom)
            Case 1
                w_query = "select * from listanom502,temp1,temp2"
            Case 2
                w_query = "select * from listanom502,temp1,temp2"
            Case 3
                w_query = "select * from listajubila,temp1,temp2"
            Case 4
                w_query = "select * from listabecarios,temp1,temp2"
        End Select
        w_query = w_query +
            " where j1_nomina = 1" + _
            " and j1_tponom=t1_tponom" + _
            " and j1_numtra=t1_numtra" + _
            " and j1_tponom=t2_tponom" + _
            " and j1_numtra=t2_numtra" + _
            " and t1_neto>0" + _
            " and k2_tipo='" + wtipo.ToString + "'" + _
            " order by 1,2,3"
        a.qr(w_query, 1)
        While a.rs.Read
            ban += 1
            If ban > tot Then
                ban = tot
            End If
            prb_estado.Value = ban / tot * 100
            If w_numtra <> a.rs!j1_numtra Then
                sw.WriteLine("CFD" + Chr(wchar) + "698")
                sw.WriteLine("Version" + Chr(wchar) + "3.2")
                If w_tponom = 2 Then
                    sw.WriteLine("Serie" + Chr(wchar) + datos(3) + "C")
                Else
                    sw.WriteLine("Serie" + Chr(wchar) + datos(3))
                End If
                sw.WriteLine("Folio" + Chr(wchar) + folio.ToString)
                sw.WriteLine("EfectoCFD" + Chr(wchar) + "egreso")
                folio = folio + 1
                sw.WriteLine("Pago" + Chr(wchar) + "Pago en una sola exhibición")
                sw.WriteLine("MetPago" + Chr(wchar) + "NA")
                sw.WriteLine("LugarExp" + Chr(wchar) + datos(9))
                sw.WriteLine("Notas" + Chr(wchar) + "Información adicional")
                sw.WriteLine("Info" + Chr(wchar) + "Nomina")
                sw.WriteLine("ERFC" + Chr(wchar) + RTrim(datos(5)))
                sw.WriteLine("ENombre" + Chr(wchar) + RTrim(datos(4)))
                If a.rfc(a.rs!v_rfc_rep) Then
                    sw.WriteLine("RRFC" + Chr(wchar) + a.rs!v_rfc_rep)
                Else
                    MsgBox("RFC incorrecto, numero de trabajador " + a.rs!j1_numtra.ToString)
                End If
                sw.WriteLine("RNombre" + Chr(wchar) + Replace(a.rs!v_nombrerep, "Ñ", "N"))
                sw.WriteLine("NumLin" + Chr(wchar) + "1")
                sw.WriteLine("Cant|1")
                sw.WriteLine("UM|ACT")
                sw.WriteLine("Desc" + Chr(wchar) + "Pago de nómina")
                If a.rs!t1_subsidio = 0 Then
                    sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!viaticos).ToString)
                    sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto + a.rs!israfavor).ToString)
                    sw.WriteLine("TotImpR" + Chr(wchar) + (a.rs!t1_ispt + a.rs!adeudo).ToString)
                    sw.WriteLine("TotCargDesc" + Chr(wchar) + (a.rs!t1_descto - a.rs!adeudo).ToString)
                    sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor).ToString)
                    sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                    sw.WriteLine("MonImpR" + Chr(wchar) + (a.rs!t1_ispt + a.rs!adeudo).ToString)
                    sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor).ToString)
                Else
                    If a.rs!t1_subsidio > a.rs!t1_ispt Then
                        sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                        sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_ispt).ToString)
                        sw.WriteLine("TotImpR" + Chr(wchar) + "0")
                        sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                        sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                        sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                        sw.WriteLine("MonImpR" + Chr(wchar) + "0")
                        sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                    Else
                        sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                        sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                        sw.WriteLine("TotImpR" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio).ToString)
                        sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                        sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                        sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                        sw.WriteLine("MonImpR" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio).ToString)
                        sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                    End If
                End If
                sw.WriteLine("Campo0" + Chr(wchar) + "REGIMEN")
                sw.WriteLine("Campo1" + Chr(wchar) + "601")
                sw.WriteLine("TipoJornada" + Chr(wchar) + "03")
                If wtipo <> "G" And wtipo <> "J" Then
                    sw.WriteLine("RiesgoPuesto" + Chr(wchar) + "4")
                    sw.WriteLine("RegistroPatronal" + Chr(wchar) + RTrim(datos(0)))
                    Select Case wtipo
                        Case "D"
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                        Case "F"
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                        Case "I"
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                        Case Else
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!sdi.ToString)
                    End Select
                    sw.WriteLine("NumSeguridadSocial" + Chr(wchar) + a.rs!v_imss_rep.ToString)
                    If w_tponom = 1 Or w_tponom = 2 Then
                        sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                    Else
                        sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + a.rs!sdi.ToString)
                    End If
                Else
                    sw.WriteLine("RiesgoPuesto" + Chr(wchar) + "0")
                    sw.WriteLine("RegistroPatronal" + Chr(wchar) + "0")
                    sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + "0")
                    sw.WriteLine("NumSeguridadSocial" + Chr(wchar) + "0")
                    sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + "0")
                End If
                Select Case a.rs!dias
                    Case Is < 7
                        sw.WriteLine("NumDiasPagados" + Chr(wchar) + "7.000")
                    Case Is < 16
                        sw.WriteLine("NumDiasPagados" + Chr(wchar) + "15.000")
                    Case Is < 32
                        sw.WriteLine("NumDiasPagados" + Chr(wchar) + "30.000")
                    Case Else
                        sw.WriteLine("NumDiasPagados" + Chr(wchar) + "1.000")
                End Select
                sw.WriteLine("NumEmpleado" + Chr(wchar) + a.rs!j1_numtra.ToString)
                Select Case wtipo
                    Case "G"
                        sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "05")
                    Case "J"
                        sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "04")
                    Case Else
                        sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "99")
                End Select
                Select Case Val(w_tponom)
                    Case 1
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=3 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                    Case 2
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=4 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                    Case 3
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=14 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                    Case 4
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=15 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                End Select
                If b.rs.HasRows Then
                    b.rs.Read()
                    If Len(b.rs!clabe) < 18 Then
                        sw.WriteLine("Banco" + Chr(wchar) + b.rs!banco.ToString)
                    End If
                    sw.WriteLine("CuentaBancaria" + Chr(wchar) + b.rs!clabe.ToString)
                End If

                If w_tponom = 1 Then
                    sw.WriteLine("Sindicalizado|Si")
                Else
                    sw.WriteLine("Sindicalizado|No")
                End If
                If w_tponom = 3 Or a.rs!t1_jubila > 0 Then
                    sw.WriteLine("TipoContrato" + Chr(wchar) + "10")
                Else
                    If Not IsDBNull(a.rs!g5_plaza) Then
                        If a.rs!g5_plaza = 1 Or a.rs!g5_plaza = 2 Then
                            sw.WriteLine("TipoContrato" + Chr(wchar) + "01")
                        Else
                            sw.WriteLine("TipoContrato" + Chr(wchar) + "03")
                        End If
                    Else
                        sw.WriteLine("TipoContrato" + Chr(wchar) + "03")
                    End If
                End If
                If Not a.curp(a.rs!v_curp_rep) Then
                    MsgBox("CURP Errores, numero de trabajador " + a.rs!j1_numtra.ToString)
                Else
                    sw.WriteLine("CURP" + Chr(wchar) + a.rs!v_curp_rep.ToString)
                End If
                'sw.WriteLine("CURP" + Chr(wchar) + a.rs!v_curp_rep.ToString)
                If w_tponom = 1 Or w_tponom = 2 Then
                    If datos(1) = "Z" Then
                        sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catz)
                    Else
                        sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catr)
                    End If
                Else
                    If w_tponom = 3 Then
                        sw.WriteLine("Puesto" + Chr(wchar) + "Jubilado")
                    Else
                        sw.WriteLine("Puesto" + Chr(wchar) + "Becario")
                    End If
                End If
                If wtipo = "J" Or wtipo = "I" Or wtipo = "G" Or wtipo = "K" Then
                    sw.WriteLine("TipoRegimen" + Chr(wchar) + "99")
                Else
                    sw.WriteLine("TipoRegimen" + Chr(wchar) + "02")
                End If
                sw.WriteLine("FechaInicialPago" + Chr(wchar) + a.rs!k2_fec_ini.ToString)
                sw.WriteLine("FechaFinalPago" + Chr(wchar) + a.rs!k2_fec_fin.ToString)
                If IsDBNull(a.rs!anti) Then
                    sw.WriteLine("Antiguedad" + Chr(wchar) + "P1W")
                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!k2_fec_ini.ToString)
                Else
                    If a.rs!g5_plaza = 1 Then
                        sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad)
                        sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso)
                    Else
                        If wtipo = "F" Then
                            sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad.ToString)
                            sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso.ToString)
                        Else
                            If wtipo = "D" Then
                                sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad.ToString)
                                sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso.ToString)
                            Else
                                If wtipo = "G" Or wtipo = "J" Then
                                    sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad.ToString)
                                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!k2_fec_ini)
                                Else
                                    sw.WriteLine("Antiguedad" + Chr(wchar) + "P1W")
                                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!k2_fec_ini.ToString)
                                End If
                            End If
                        End If
                    End If
                End If
                If datos(1) = "Z" Then
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptoz)
                Else
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptor)
                End If
                datos(6) = DateAdd(DateInterval.Day, 0, DateTime.Parse(a.rs!k2_fecha)).ToString
                datos(6) = Mid(datos(6), 7, 4) + "-" + Mid(datos(6), 4, 2) + "-" + Mid(datos(6), 1, 2)
                sw.WriteLine("FechaPago" + Chr(wchar) + datos(6).ToString)
                If wtipo = "G" Or wtipo = "J" Then
                    sw.WriteLine("TipoNomina" + Chr(wchar) + "O")
                Else
                    sw.WriteLine("TipoNomina" + Chr(wchar) + "E")
                End If
                sw.WriteLine("ClaveEntFed|VER")
                sw.WriteLine("")
                '===== detalle de nomina
                w_per = 1
                w_ded = 1
                w_otp = 1
                w_numtra = a.rs!j1_numtra
                Dim anos = 0
                Dim wsem = 0
                Dim ultsuel = 0.0
                '====== Calculo de años de servicio y ultimo sueldo mensual para finiquito
                If wtipo = "F" Or wtipo = "I" Then
                    b.qr("select max(k2_semana) sem from anom502 where k2_tipo in ('F','I') and k2_numtra=" + _
                         a.rs!t2_numtra.ToString + " and k2_tponom=" + a.rs!t2_tponom.ToString + " and k2_estado=1", 1)
                    b.rs.Read()
                    wsem = b.rs!sem
                    b.qr("select datediff(day,g5_ingreso,(select h1_fecha_fin from anom201 where h1_semana=" + b.rs!sem.ToString + ")) serv from anom105 where g5_numtra=" + _
                         a.rs!t2_numtra.ToString + " and g5_tponom=" + a.rs!t2_tponom.ToString, 1)
                    b.rs.Read()
                    Try
                        anos = Math.Round(b.rs!serv / 365, 0)
                    Catch ex As Exception
                        MsgBox(a.rs!t2_numtra)
                    End Try
                    b.qr("select max(j1_semana) sem from anom401 where j1_semana<" + wsem.ToString + " and j1_cpto=3 and j1_tpo_emision<8 and j1_tponom=" + _
                         a.rs!t2_tponom.ToString + " and j1_numtra=" + a.rs!t2_numtra.ToString, 1)
                    If b.rs.HasRows Then
                        b.rs.Read()
                        If Not IsDBNull(b.rs!sem) Then
                            b.qr("select (sum(j1_importe)/count(*))*30.4 importe from anom401 where j1_semana between " + (b.rs!sem - 3).ToString + " and " + b.rs!sem.ToString + " and j1_cpto=3 and j1_tpo_emision<8 and j1_tponom=" + _
                                 a.rs!t2_tponom.ToString + " and j1_numtra=" + a.rs!t2_numtra.ToString, 1)
                            b.rs.Read()
                            ultsuel = b.rs!importe
                        End If
                    End If
                End If
                '===== Detalle de percepciones, deducciones, pagos por separacion, otros pagos
                b.qr("select t3_tponom,t3_numtra,t3_cpto,t3_percep,t3_deduc,t3_seres,sum(t3_importe) t3_importe,t3_exento,t3_concepto " + _
                    " from temp3 where t3_tponom=" + a.rs!t2_tponom.ToString + " and t3_numtra=" + a.rs!t2_numtra.ToString + _
                    " group by t3_tponom,t3_numtra,t3_cpto,t3_percep,t3_deduc,t3_seres,t3_exento,t3_concepto" + _
                    " order by t3_concepto,t3_cpto", 1)
                While b.rs.Read
                    If b.rs!t3_cpto = 300 Or b.rs!t3_cpto = 152 Then
                        wjubpar = b.rs!t3_importe
                    End If
                    If b.rs!t3_cpto = 217 Or b.rs!t3_cpto = 131 Then
                        wjubtot = b.rs!t3_importe
                    End If
                    Select Case b.rs!t3_concepto
                        Case 1
                            wfinper += b.rs!t3_importe
                            If b.rs!t3_exento = 0 Then
                                wfinacu += b.rs!t3_importe
                            End If
                            If w_per = 1 Then
                                sw.WriteLine("Percepcion" + Chr(wchar) + w_per.ToString)
                                If a.rs!t1_sueldos > 0 Then
                                    sw.WriteLine("TotalSueldos" + Chr(wchar) + a.rs!t1_sueldos.ToString)
                                End If
                                If a.rs!t1_separa > 0 Then
                                    sw.WriteLine("TotalSeparacionIndemnizacion" + Chr(wchar) + a.rs!t1_separa.ToString)
                                End If
                                If a.rs!t1_jubila > 0 Then
                                    sw.WriteLine("TotalJubilacionPensionRetiro" + Chr(wchar) + a.rs!t1_jubila.ToString)
                                End If
                                sw.WriteLine("TotalExento" + Chr(wchar) + a.rs!t1_exento.ToString)
                                sw.WriteLine("TotalGravado" + Chr(wchar) + a.rs!t1_gravado.ToString)
                                sw.WriteLine("TipoPercepcion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                sw.WriteLine("Clave" + Chr(wchar) + a.ceros(b.rs!t3_cpto.ToString))
                                sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_percep.ToString)
                            Else
                                sw.WriteLine("Percepcion" + Chr(wchar) + w_per.ToString)
                                sw.WriteLine("TipoPercepcion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                sw.WriteLine("Clave" + Chr(wchar) + a.ceros(b.rs!t3_cpto.ToString))
                                sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_percep.ToString)
                            End If
                            If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                            Else
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                            End If
                            w_per = w_per + 1
                        Case 2
                            If wtipo = "G" Or wtipo = "J" Or wtipo = "F" Or wtipo = "I" Or wtipo = "K" Then
                                sw.WriteLine("JubilacionPensionRetiro|1")
                                If wjubtot > 0 Then
                                    sw.WriteLine("TotalUnaExhibicion|" + wjubtot.ToString)
                                    wjubtot = 0
                                End If
                                If wjubpar > 0 Then
                                    sw.WriteLine("TotalParcialidad|" + wjubpar.ToString)
                                    If a.rs!dias < 16 Then
                                        sw.WriteLine("MontoDiario|" + String.Format(Math.Round(wjubpar / 15, 2), "#,##0.00"))
                                    Else
                                        sw.WriteLine("MontoDiario|" + String.Format(Math.Round(wjubpar / 30, 2), "#,##0.00"))
                                    End If
                                    wjubpar = 0
                                End If
                                sw.WriteLine("IngresoAcumulable|0")
                                sw.WriteLine("IngresoNoAcumulable|0")
                            End If
                        Case 3
                            sw.WriteLine("SeparacionIndemnizacion|1")
                            sw.WriteLine("TotalPagado|" + wfinper.ToString)
                            sw.WriteLine("NumAnosServicio|" + anos.ToString)
                            sw.WriteLine("UltimoSueldoMensOrd|" + ultsuel.ToString)
                            sw.WriteLine("IngresoAcumulable|" + wfinacu.ToString)
                            sw.WriteLine("IngresoNoAcumulable|0")
                            wfinper = 0
                            wfinacu = 0
                        Case 4
                            If a.rs!t1_subsidio > a.rs!t1_ispt And b.rs!t3_cpto <> 403 Then
                                If w_ded = 1 Then
                                    sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                    sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_ispt + a.rs!t1_descto).ToString)
                                    sw.WriteLine("TotalGravado" + Chr(wchar) + "0.00")
                                    sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                Else
                                    sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                    sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                End If
                                If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                    sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                    sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                                Else
                                    sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                                End If
                                w_ded = w_ded + 1
                            Else
                                If a.rs!t1_subsidio < a.rs!t1_ispt Then
                                    If w_ded = 1 Then
                                        sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                        sw.WriteLine("TotalExento" + Chr(wchar) + ((a.rs!t1_ispt - a.rs!t1_subsidio) + a.rs!t1_descto).ToString)
                                        sw.WriteLine("TotalGravado" + Chr(wchar) + "0.00")
                                        sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    Else
                                        sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                        sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    End If
                                    If b.rs!t3_cpto = 403 Then
                                        sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                        sw.WriteLine("ImporteExento" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio).ToString)
                                    Else
                                        sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                        sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    End If
                                    w_ded = w_ded + 1
                                End If
                                If a.rs!t1_subsidio = a.rs!t1_ispt Then
                                    If w_ded = 1 Then
                                        sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                        sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_ispt + a.rs!t1_descto).ToString)
                                        sw.WriteLine("TotalGravado" + Chr(wchar) + "0.00")
                                        sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    Else
                                        sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                        sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    End If
                                    If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                        sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                        sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    Else
                                        sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                        sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                                    End If
                                    w_ded = w_ded + 1
                                End If
                            End If
                        Case 5
                            'CREDITO AL SALARIO 411, VIATICOS 218 y 440 DEVOLUCION ISR
                            If a.rs!t1_subsidio > a.rs!t1_ispt Then
                                sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                If b.rs!t3_cpto = 411 Then
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + (b.rs!t3_importe * -1 - a.rs!t1_ispt).ToString)
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "002")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    If a.rs!t1_ispt > (b.rs!t3_importe * -1) Then
                                        'sw.WriteLine("ImporteSubsidio" + Chr(wchar) + "0.00")
                                    Else
                                        sw.WriteLine("ImporteSubsidio" + Chr(wchar) + (b.rs!t3_importe * -1 - a.rs!t1_ispt).ToString)
                                    End If
                                    sw.WriteLine("SubsidioCausado" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                End If
                                w_otp = w_otp + 1
                            Else
                                sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                If b.rs!t3_cpto = 218 Then
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "003")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    sw.WriteLine("ImporteSubsidio" + Chr(wchar) + b.rs!t3_importe.ToString)
                                End If
                                If b.rs!t3_cpto = 103 Then
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "999")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    sw.WriteLine("ImporteSubsidio" + Chr(wchar) + b.rs!t3_importe.ToString)
                                End If
                                If b.rs!t3_cpto = 440 Then
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "999")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    sw.WriteLine("ImporteSubsidio" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                    sw.WriteLine("SaldoAFavor" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                    sw.WriteLine("Año" + Chr(wchar) + "2016")
                                    sw.WriteLine("RemanenteSalFav" + Chr(wchar) + "0")
                                End If
                            End If
                    End Select
                    sw.WriteLine("")
                End While
            End If
            '===================== INICIA PROCESO DE PERCEPCIONES Y DEDUCCIONES
        End While
        sw.Close()
        file = Nothing
        sw = Nothing
        MsgBox("Inicio: " + w_tiempo + ", proceso Terminado: " + Mid(TimeOfDay.ToString, 12, 8))
        prb_estado.Value = 0
    End Sub
    '===================== TIMBRADO ACTUAL 23/03/2019

    Private Sub timbrado3()
        Dim file As System.IO.FileStream
        Dim wchar As Integer = Asc("|")
        Dim fic As String
        Dim folio = 1
        Dim det As New Clase
        Dim ban = 0
        Dim tot = 0
        Dim w_tponom = 1
        Dim w_nomina = 1
        Dim w_numtra = 1
        Dim w_per = 1
        Dim w_ded = 1
        Dim w_otp = 1
        Dim w_query = ""
        Dim fecpag = "01/01/1900"
        Dim wserie
        Dim inipag = ""
        Dim finpag = ""
        Dim wtipo = ""
        Dim wjubtot = 0.0
        Dim wjubpar = 0.0
        Dim wfinper = 0.0
        Dim wfinacu = 0.0
        Dim w_tiempo = Mid(TimeOfDay.ToString, 12, 8)
        Dim datos(10) As String
        While True
            w_tponom = InputBox("TIPO DE NOMINA: " + Chr(13) + "1.- SINDICALIZADO" + Chr(13) + "2.- CONFIANZA" + Chr(13) + "3.- JUBILADOS" + Chr(13) + "4.- BECARIOS")
            If Val(w_tponom) = 0 Then
                trd_timbrado.Abort()
                Exit Sub
            End If
            If Val(w_tponom) > 0 And Val(w_tponom) < 5 Then
                Exit While
            End If
        End While
        a.qr("select distinct k2_tipo from anom502 where k2_estado=1 and k2_tponom=" + w_tponom.ToString, 1)
        While a.rs.Read
            w_query = w_query + UCase(a.rs!k2_tipo) + ","
        End While
        While True
            wtipo = UCase(InputBox("Selecciona Tipo " + w_query))
            If InStr(w_query, wtipo) > 0 Then
                Exit While
            End If
            If Len(wtipo) = 0 Then
                Exit Sub
            End If
        End While
        Select Case wtipo
            Case "A"
                wserie = "PRESTACION"
            Case "F"
                wserie = "FINIQUITO"
            Case "D"
                wserie = "DESPENSA"
            Case "J"
                wserie = "JUBILADOSQUINCENAL"
            Case "G"
                wserie = "JUBILADOSMENSUAL"
            Case "E"
                wserie = "BECARIOS"
            Case "I"
                wserie = "PAGOUNICO"
            Case "V"
                wserie = "VIATICOS"
            Case "K"
                wserie = "DEFUNCION"
            Case "P"
                wserie = "PRIMA"
            Case "S"
                wserie = "SEGUROVIDA"
            Case "C"
                wserie = "CONVENIO"
            Case "N"
                wserie = "VACACIONES"
            Case "T"
                wserie = "UTILIDADES"
            Case "M"
                wserie = "EMOLUMENTOS"
                While True
                    fecpag = InputBox("Fecha de pago")
                    If IsDate(fecpag) Then
                        Exit While
                    End If
                End While
            Case Else
                wserie = "NOMINA"
        End Select
        a.qr("SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY('" + fecpag + "')-1),'" + fecpag + "'),111) inicio," +
             "CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,'" + fecpag + "'))),DATEADD(mm,1,'" + fecpag + "')),111) fin", 1)
        a.rs.Read()
        inipag = Replace(a.rs!inicio, "/", "-")
        finpag = Replace(a.rs!fin, "/", "-")
        '==== temp1
        a.qr("timbrado 1," + w_tponom.ToString + ",2,'" + wtipo + "'", 2)
        '===== temp2
        a.qr("catdepto 1," + w_tponom.ToString + ",2,'" + wtipo + "'", 2)
        '===== temp3
        a.qr("cargadetalle 1," + w_tponom.ToString + ",2,'" + wtipo + "'", 2)
        '===== CARGA DATOS GENERALES
        a.qr("select g1_reg_patron regimss,i4_ciclo ciclo,i4_ano_sem semana,j2_serie serie,g1_nombre,g1_rfc,replace(convert(char(20),h1_fecha_fin+4,111),'/','-') pago," + _
             " replace(convert(char(20),h1_fecha_ini,111),'/','-') ini,replace(convert(char(20),h1_fecha_fin,111),'/','-') fin,g1_cp" + _
             " from anom304,anom402,anom101,anom201 " + _
             " where i4_ano_sem=j2_semana" + _
             " and j2_semana=h1_semana", 1)
        If Not a.rs.HasRows Then
            MsgBox("No existe nada que timbrar")
            Exit Sub
        End If
        a.rs.Read()
        datos(0) = a.rs!regimss
        datos(1) = a.rs!ciclo
        datos(2) = a.rs!semana.ToString
        datos(3) = wserie
        datos(4) = a.rs!g1_nombre
        datos(5) = a.rs!g1_rfc
        datos(6) = fecpag
        datos(7) = a.rs!fin
        datos(8) = a.rs!ini
        datos(9) = a.rs!g1_cp.ToString
        Select Case w_tponom
            Case 1
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_OBRERO_" + wtipo.ToString + ".txt"
            Case 2
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_EMPLEADO_" + wtipo.ToString + ".txt"
            Case 3
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_JUBILADO_" + wtipo.ToString + ".txt"
            Case 4
                fic = "c:\temp\" + wserie + "_" + datos(2).ToString + "_BECARIO_" + wtipo.ToString + ".txt"
        End Select
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select count(*) num from temp1 where t1_tponom=" + w_tponom.ToString, 1)
        a.rs.Read()
        MsgBox("Registros a procesar: " + a.rs!num.ToString)
        tot = a.rs!num
        '===== LISTADO GENERAL DE TIMBRADO
        w_numtra = 1
        w_per = 1
        w_ded = 1
        w_otp = 1
        Select Case Val(w_tponom)
            Case 1
                w_query = "select * from listanom502,temp1,temp2"
            Case 2
                w_query = "select * from listanom502,temp1,temp2"
            Case 3
                w_query = "select * from listajubila,temp1,temp2"
            Case 4
                w_query = "select * from listabecarios,temp1,temp2"
        End Select
        w_query = w_query +
            " where j1_nomina = 1" + _
            " and j1_tponom=t1_tponom" + _
            " and j1_numtra=t1_numtra" + _
            " and j1_tponom=t2_tponom" + _
            " and j1_numtra=t2_numtra" + _
            " and t1_neto>0" + _
            " and k2_tipo='" + wtipo.ToString + "'" + _
            " order by 1,2,3"
        a.qr(w_query, 1)
        While a.rs.Read
            ban += 1
            If ban > tot Then
                ban = tot
            End If
            prb_estado.Value = ban / tot * 100
            If w_numtra <> a.rs!j1_numtra Then
                sw.WriteLine("CFD" + Chr(wchar) + "698")
                sw.WriteLine("Version" + Chr(wchar) + "3.3")
                If w_tponom = 2 Then
                    sw.WriteLine("Serie" + Chr(wchar) + datos(3) + "C")
                Else
                    sw.WriteLine("Serie" + Chr(wchar) + datos(3))
                End If
                sw.WriteLine("Folio" + Chr(wchar) + folio.ToString)
                sw.WriteLine("EfectoCFD" + Chr(wchar) + "N")
                folio = folio + 1
                sw.WriteLine("Pago" + Chr(wchar) + "99")
                sw.WriteLine("MetPago" + Chr(wchar) + "PUE")
                sw.WriteLine("LugarExp" + Chr(wchar) + datos(9))
                If wtipo = "I" Or wtipo = "P" Then
                Else
                    sw.WriteLine("ERFC" + Chr(wchar) + RTrim(datos(5)))
                    sw.WriteLine("ENombre" + Chr(wchar) + RTrim(datos(4)))
                End If
                If a.rfc(a.rs!v_rfc_rep) Then
                    sw.WriteLine("RRFC" + Chr(wchar) + a.rs!v_rfc_rep)
                Else
                    MsgBox("RFC incorrecto, numero de trabajador " + a.rs!j1_numtra.ToString)
                End If
                sw.WriteLine("RNombre" + Chr(wchar) + Replace(a.rs!v_nombrerep, "Ñ", "N"))
                sw.WriteLine("Cant|1")
                sw.WriteLine("UM|ACT")
                sw.WriteLine("Desc" + Chr(wchar) + "Pago de nómina")
                Dim wimpuesto As Decimal = 0.0
                wimpuesto = a.rs!t1_ispt - a.rs!t1_subsidio
                If a.rs!t1_subsidio = 0 Then
                    sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!viaticos).ToString)
                    sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto + a.rs!israfavor).ToString)
                    sw.WriteLine("TotImpR" + Chr(wchar) + (a.rs!t1_ispt + a.rs!adeudo).ToString)
                    sw.WriteLine("TotCargDesc" + Chr(wchar) + (a.rs!t1_descto - a.rs!adeudo).ToString)
                    sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor).ToString)
                    sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                    sw.WriteLine("MonImpR" + Chr(wchar) + (a.rs!t1_ispt + a.rs!adeudo).ToString)
                    sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor).ToString)
                Else
                    If a.rs!t1_subsidio > a.rs!t1_ispt Then
                        sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                        sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_ispt + a.rs!israfavor).ToString)
                        sw.WriteLine("TotImpR" + Chr(wchar) + "0")
                        sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                        sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor).ToString)
                        sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                        sw.WriteLine("MonImpR" + Chr(wchar) + "0")
                        sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor).ToString)
                    Else
                        If a.rs!t1_subsidio = a.rs!t1_ispt Then
                            sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("TotImpR" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                            sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                            sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                            sw.WriteLine("MonImpR" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                        Else
                            sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("TotImpR" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                            sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                            sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                            sw.WriteLine("MonImpR" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio).ToString)
                            sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                        End If
                    End If
                End If
                sw.WriteLine("Regimen" + Chr(wchar) + "601")
                If wtipo <> "I" And wtipo <> "P" Then
                    If wtipo = "M" Then
                        sw.WriteLine("TipoJornada" + Chr(wchar) + "")
                    Else
                        sw.WriteLine("TipoJornada" + Chr(wchar) + "03")
                    End If
                End If
                If wtipo <> "G" And wtipo <> "J" Then
                    If wtipo <> "I" And wtipo <> "P" Then
                        If wtipo = "M" Then
                            sw.WriteLine("RiesgoPuesto" + Chr(wchar) + "0")
                        Else
                            sw.WriteLine("RiesgoPuesto" + Chr(wchar) + "4")
                        End If
                    End If
                    sw.WriteLine("RegistroPatronal" + Chr(wchar) + RTrim(datos(0)))
                    Select Case wtipo
                        Case "D"
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                        Case "F"
                            If a.rs!j1_tponom = 4 Then
                                sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + "0")
                            Else
                                sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                            End If
                        Case "I"
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                        Case "E"
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + "0")
                        Case Else
                            sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!sdi.ToString)
                    End Select
                    sw.WriteLine("FactorIntegracion" + Chr(wchar) + "0")
                    If wtipo <> "P" And wtipo <> "I" Then
                        If wtipo = "M" Then
                            sw.WriteLine("NumSeguridadSocial" + Chr(wchar) + "")
                        Else
                            sw.WriteLine("NumSeguridadSocial" + Chr(wchar) + a.rs!v_imss_rep.ToString)
                        End If

                    End If
                    If w_tponom = 1 Or w_tponom = 2 Then
                        sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                    Else
                        sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + a.rs!sdi.ToString)
                    End If
                Else
                    sw.WriteLine("RiesgoPuesto" + Chr(wchar) + "99")
                    sw.WriteLine("RegistroPatronal" + Chr(wchar) + "0")
                    sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + "0")
                    sw.WriteLine("FactorIntegracion" + Chr(wchar) + "0")
                    sw.WriteLine("NumSeguridadSocial" + Chr(wchar) + "0")
                    sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + "0")
                End If
                Select Case a.rs!dias
                    Case Is < 7
                        If wtipo = "M" Then
                            sw.WriteLine("NumDiasPagados" + Chr(wchar) + "1.000")
                        Else
                            sw.WriteLine("NumDiasPagados" + Chr(wchar) + "7.000")
                        End If
                    Case Is < 16
                        sw.WriteLine("NumDiasPagados" + Chr(wchar) + "15.000")
                    Case Is < 32
                        sw.WriteLine("NumDiasPagados" + Chr(wchar) + "30.000")
                    Case Else
                        sw.WriteLine("NumDiasPagados" + Chr(wchar) + "1.000")
                End Select
                sw.WriteLine("NumEmpleado" + Chr(wchar) + a.rs!j1_numtra.ToString)
                Select Case wtipo
                    Case "G"
                        sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "05")
                    Case "J"
                        sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "04")
                    Case Else
                        sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "99")
                End Select
                Select Case Val(w_tponom)
                    Case 1
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=3 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                    Case 2
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=4 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                    Case 3
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=14 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                    Case 4
                        b.qr("select case when len(i8_clabe)=18 then substring(i8_clabe,1,3) else '021' end banco,i8_clabe clabe from aing108 where i8_relab=15 and i8_clave=" + a.rs!j1_numtra.ToString, 1)
                End Select
                If b.rs.HasRows Then
                    b.rs.Read()
                    If Len(b.rs!clabe) < 18 Then
                        sw.WriteLine("Banco" + Chr(wchar) + b.rs!banco.ToString)
                    End If
                    sw.WriteLine("CuentaBancaria" + Chr(wchar) + b.rs!clabe.ToString)
                End If
                If w_tponom = 1 Then
                    sw.WriteLine("Sindicalizado|Si")
                Else
                    sw.WriteLine("Sindicalizado|No")
                End If
                If w_tponom = 3 Or a.rs!t1_jubila > 0 Then
                    If wtipo = "I" Or wtipo = "P" Then
                        sw.WriteLine("TipoContrato" + Chr(wchar) + "99")
                    Else
                        If w_tponom < 3 Or w_tponom = 4 Then
                            sw.WriteLine("TipoContrato" + Chr(wchar) + "01")
                        Else
                            sw.WriteLine("TipoContrato" + Chr(wchar) + "10")
                        End If
                    End If
                Else
                    If Not IsDBNull(a.rs!g5_plaza) Then
                        If wtipo = "P" Or wtipo = "I" Or wtipo = "C" Or wtipo = "F" Then
                            sw.WriteLine("TipoContrato" + Chr(wchar) + "99")
                        Else
                            If a.rs!g5_plaza = 1 Or a.rs!g5_plaza = 2 Then
                                If wtipo = "M" Then
                                    sw.WriteLine("TipoContrato" + Chr(wchar) + "09")
                                Else
                                    sw.WriteLine("TipoContrato" + Chr(wchar) + "01")
                                End If

                            Else
                                sw.WriteLine("TipoContrato" + Chr(wchar) + "03")
                            End If
                        End If
                    Else
                        If w_tponom = 4 Then
                            sw.WriteLine("TipoContrato" + Chr(wchar) + "01")
                        Else
                            sw.WriteLine("TipoContrato" + Chr(wchar) + "99")
                        End If
                    End If
                End If
                If Not a.curp(a.rs!v_curp_rep) Then
                    MsgBox("CURP Errores, numero de trabajador " + a.rs!j1_numtra.ToString)
                Else
                    sw.WriteLine("CURP" + Chr(wchar) + a.rs!v_curp_rep.ToString)
                End If
                If w_tponom = 1 Or w_tponom = 2 Then
                    If datos(1) = "Z" Then
                        sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catz)
                    Else
                        sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catr)
                    End If
                Else
                    If w_tponom = 3 Then
                        sw.WriteLine("Puesto" + Chr(wchar) + "Jubilado")
                    Else
                        sw.WriteLine("Puesto" + Chr(wchar) + "Becario")
                    End If
                End If
                Select Case wtipo
                    Case "J"
                        sw.WriteLine("TipoRegimen" + Chr(wchar) + "12")
                    Case "G"
                        sw.WriteLine("TipoRegimen" + Chr(wchar) + "12")
                    Case "P"
                        sw.WriteLine("TipoRegimen" + Chr(wchar) + "13")
                    Case "F"
                        If w_tponom = 4 Then
                            sw.WriteLine("TipoRegimen" + Chr(wchar) + "02")
                        Else
                            sw.WriteLine("TipoRegimen" + Chr(wchar) + "13")
                        End If

                    Case "K"
                        If w_tponom = 3 Then
                            sw.WriteLine("TipoRegimen" + Chr(wchar) + "12")
                        Else
                            sw.WriteLine("TipoRegimen" + Chr(wchar) + "02")
                        End If
                    Case "C"
                        sw.WriteLine("TipoRegimen" + Chr(wchar) + "99")
                    Case "I"
                        If w_tponom = 3 Then
                            sw.WriteLine("TipoRegimen" + Chr(wchar) + "12")
                        Else
                            sw.WriteLine("TipoRegimen" + Chr(wchar) + "99")
                        End If
                    Case "M"
                        sw.WriteLine("TipoRegimen" + Chr(wchar) + "07")
                    Case Else
                        sw.WriteLine("TipoRegimen" + Chr(wchar) + "02")
                End Select
                If wtipo = "M" Then
                    sw.WriteLine("FechaInicialPago" + Chr(wchar) + inipag)
                    sw.WriteLine("FechaFinalPago" + Chr(wchar) + finpag)
                Else
                    sw.WriteLine("FechaInicialPago" + Chr(wchar) + a.rs!k2_fec_ini.ToString)
                    sw.WriteLine("FechaFinalPago" + Chr(wchar) + a.rs!k2_fec_fin.ToString)
                End If
                If IsDBNull(a.rs!anti) Then
                    sw.WriteLine("Antiguedad" + Chr(wchar) + "P1W")
                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!k2_fec_ini.ToString)
                Else
                    If a.rs!g5_plaza = 1 Then
                        If wtipo = "M" Then
                            sw.WriteLine("Antiguedad" + Chr(wchar) + "")
                            sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + inipag)
                        Else
                            sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad)
                            sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso)
                        End If
                    Else
                        If wtipo = "F" Then
                            sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad.ToString)
                            sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso.ToString)
                        Else
                            If wtipo = "D" Then
                                sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad.ToString)
                                sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso.ToString)
                            Else
                                If wtipo = "G" Or wtipo = "J" Then
                                    sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!antiguedad.ToString)
                                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!k2_fec_ini)
                                Else
                                    sw.WriteLine("Antiguedad" + Chr(wchar) + "P1W")
                                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!k2_fec_ini.ToString)
                                End If
                            End If
                        End If
                    End If
                End If
                If datos(1) = "Z" Then
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptoz)
                Else
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptor)
                End If
                datos(6) = DateAdd(DateInterval.Day, 0, DateTime.Parse(a.rs!k2_fecha)).ToString
                datos(6) = Mid(datos(6), 7, 4) + "-" + Mid(datos(6), 4, 2) + "-" + Mid(datos(6), 1, 2)
                If wtipo = "M" Then
                    sw.WriteLine("FechaPago" + Chr(wchar) + Mid(fecpag, 7, 4) + "-" + Mid(fecpag, 4, 2) + "-" + Mid(fecpag, 1, 2))
                Else
                    sw.WriteLine("FechaPago" + Chr(wchar) + datos(6).ToString)
                End If
                If wtipo = "G" Or wtipo = "J" Then
                    sw.WriteLine("TipoNomina" + Chr(wchar) + "O")
                Else
                    sw.WriteLine("TipoNomina" + Chr(wchar) + "E")
                End If
                sw.WriteLine("ClaveEntFed|VER")
                sw.WriteLine("")
                '===== detalle de nomina
                w_per = 1
                w_ded = 1
                w_otp = 1
                w_numtra = a.rs!j1_numtra
                Dim anos = 0
                Dim wsem = 0
                Dim ultsuel = 0.0
                Dim incapacidad = 0.0
                '====== Calculo de años de servicio y ultimo sueldo mensual para finiquito
                If wtipo = "F" Or wtipo = "I" Then
                    b.qr("select max(k2_semana) sem from anom502 where k2_tipo in ('F','I') and k2_numtra=" + _
                         a.rs!t2_numtra.ToString + " and k2_tponom=" + a.rs!t2_tponom.ToString + " and k2_estado=1", 1)
                    b.rs.Read()
                    wsem = b.rs!sem
                    b.qr("select datediff(day,g5_ingreso,(select h1_fecha_fin from anom201 where h1_semana=" + b.rs!sem.ToString + ")) serv from anom105 where g5_numtra=" + _
                         a.rs!t2_numtra.ToString + " and g5_tponom=" + a.rs!t2_tponom.ToString, 1)
                    b.rs.Read()
                    Try
                        If a.rs!t2_tponom = 4 Then
                            anos = 1
                        Else
                            anos = Math.Round(b.rs!serv / 365, 0)
                        End If

                    Catch ex As Exception
                        MsgBox("Error años servicio, numtra: " + a.rs!t2_numtra.ToString)
                    End Try
                    b.qr("select max(j1_semana) sem from anom401 where j1_semana<" + wsem.ToString + " and j1_cpto=3 and j1_tpo_emision<8 and j1_tponom=" + _
                         a.rs!t2_tponom.ToString + " and j1_numtra=" + a.rs!t2_numtra.ToString, 1)
                    If b.rs.HasRows Then
                        b.rs.Read()
                        If Not IsDBNull(b.rs!sem) Then
                            b.qr("select (sum(j1_importe)/count(*))*30.4 importe from anom401 where j1_semana between " + (b.rs!sem - 3).ToString + " and " + b.rs!sem.ToString + " and j1_cpto=3 and j1_tpo_emision<8 and j1_tponom=" + _
                                 a.rs!t2_tponom.ToString + " and j1_numtra=" + a.rs!t2_numtra.ToString, 1)
                            b.rs.Read()
                            ultsuel = b.rs!importe
                        End If
                    End If
                End If
                '===== Detalle de percepciones, deducciones, pagos por separacion, otros pagos
                b.qr(" select t3_tponom,t3_numtra,t3_cpto,t3_percep,t3_deduc,t3_seres,g14_saldo,sum(t3_importe) t3_importe,t3_exento,t3_concepto " + _
                     " from temp3 left join anom114 on (t3_tponom=g14_tponom and g14_numtra=t3_numtra and g14_cpto=440) " + _
                     " where t3_tponom=" + a.rs!t2_tponom.ToString + " and t3_numtra=" + a.rs!t2_numtra.ToString + _
                     " group by t3_tponom,t3_numtra,t3_cpto,t3_percep,t3_deduc,t3_seres,g14_saldo,t3_exento,t3_concepto" + _
                     " order by t3_concepto,t3_cpto", 1)
                While b.rs.Read
                    If b.rs!t3_cpto = 300 Or b.rs!t3_cpto = 152 Then
                        wjubpar = b.rs!t3_importe
                    End If
                    If b.rs!t3_cpto = 217 Or b.rs!t3_cpto = 131 Or b.rs!t3_cpto = 119 Then
                        wjubtot = b.rs!t3_importe
                    End If
                    If b.rs!T3_CPTO = 106 Then
                        incapacidad = b.rs!t3_importe
                    End If
                    Select Case b.rs!t3_concepto
                        Case 1
                            wfinper += b.rs!t3_importe
                            If b.rs!t3_exento = 0 Then
                                wfinacu += b.rs!t3_importe
                            End If
                            If w_per = 1 Then
                                sw.WriteLine("Percepcion" + Chr(wchar) + w_per.ToString)
                                If a.rs!t1_sueldos > 0 Then
                                    sw.WriteLine("TotalSueldos" + Chr(wchar) + a.rs!t1_sueldos.ToString)
                                End If
                                If a.rs!t1_separa > 0 Then
                                    sw.WriteLine("TotalSeparacionIndemnizacion" + Chr(wchar) + a.rs!t1_separa.ToString)
                                End If
                                If a.rs!t1_jubila > 0 Then
                                    sw.WriteLine("TotalJubilacionPensionRetiro" + Chr(wchar) + a.rs!t1_jubila.ToString)
                                End If
                                sw.WriteLine("TotalExento" + Chr(wchar) + a.rs!t1_exento.ToString)
                                sw.WriteLine("TotalGravado" + Chr(wchar) + a.rs!t1_gravado.ToString)
                                sw.WriteLine("TipoPercepcion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                sw.WriteLine("Clave" + Chr(wchar) + a.ceros(b.rs!t3_cpto.ToString))
                                sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_percep.ToString)
                            Else
                                sw.WriteLine("Percepcion" + Chr(wchar) + w_per.ToString)
                                sw.WriteLine("TipoPercepcion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                sw.WriteLine("Clave" + Chr(wchar) + a.ceros(b.rs!t3_cpto.ToString))
                                sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_percep.ToString)
                            End If
                            If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                            Else
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                            End If
                            w_per = w_per + 1
                        Case 2
                            If wtipo = "G" Or wtipo = "J" Or wtipo = "F" Or wtipo = "I" Or wtipo = "K" Then
                                sw.WriteLine("JubilacionPensionRetiro|1")
                                If wjubtot > 0 Then
                                    sw.WriteLine("TotalUnaExhibicion|" + wjubtot.ToString)
                                    wjubtot = 0
                                End If
                                If wjubpar > 0 Then
                                    sw.WriteLine("TotalParcialidad|" + wjubpar.ToString)
                                    If a.rs!dias < 16 Then
                                        sw.WriteLine("MontoDiario|" + String.Format(Math.Round(wjubpar / 15, 2), "#,##0.00"))
                                    Else
                                        sw.WriteLine("MontoDiario|" + String.Format(Math.Round(wjubpar / 30, 2), "#,##0.00"))
                                    End If
                                    wjubpar = 0
                                End If
                                sw.WriteLine("IngresoAcumulable|0")
                                sw.WriteLine("IngresoNoAcumulable|0")
                            End If
                        Case 3
                            sw.WriteLine("SeparacionIndemnizacion|1")
                            sw.WriteLine("TotalPagado|" + wfinper.ToString)
                            sw.WriteLine("NumAnosServicio|" + anos.ToString)
                            sw.WriteLine("UltimoSueldoMensOrd|" + ultsuel.ToString)
                            sw.WriteLine("IngresoAcumulable|" + wfinacu.ToString)
                            sw.WriteLine("IngresoNoAcumulable|0")
                            wfinper = 0
                            wfinacu = 0
                        Case 4
                            If b.rs!t3_cpto = 403 Then
                                Select Case (a.rs!t1_ispt - a.rs!t1_subsidio)
                                    Case Is < 0
                                    Case Is = 0
                                    Case Is > 0
                                        If w_ded = 1 Then
                                            sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                            sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_ispt + a.rs!t1_descto - a.rs!t1_subsidio - a.rs!israfavor).ToString)
                                            sw.WriteLine("TotalGravado" + Chr(wchar) + "0.00")
                                            sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                            sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                            sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                        Else
                                            sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                            sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                            sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                            sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                        End If
                                        If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                            sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                            sw.WriteLine("ImporteExento" + Chr(wchar) + (b.rs!t3_importe - a.rs!t1_subsidio).ToString)
                                        Else
                                            sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                            sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                                        End If
                                        w_ded = w_ded + 1
                                End Select
                            Else
                                If w_ded = 1 Then
                                    sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                    If a.rs!t1_ispt < a.rs!t1_subsidio Then
                                        sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_descto).ToString)
                                    Else
                                        sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_ispt - a.rs!t1_subsidio + a.rs!t1_descto - a.rs!israfavor).ToString)
                                    End If
                                    sw.WriteLine("TotalGravado" + Chr(wchar) + "0.00")
                                    sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                Else
                                    sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                    sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                End If
                                If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                    sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                    sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                                Else
                                    sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                                End If
                                w_ded = w_ded + 1
                            End If
                        Case 5
                            'CREDITO AL SALARIO 411, VIATICOS 218 y 440 DEVOLUCION ISR
                            If a.rs!t1_subsidio > a.rs!t1_ispt Then
                                sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                If b.rs!t3_cpto = 411 Then
                                    If w_otp = 1 Then
                                        sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + (a.rs!t1_subsidio - a.rs!t1_ispt + a.rs!israfavor).ToString)
                                    End If
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "002")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    If a.rs!t1_ispt > (b.rs!t3_importe * -1) Then
                                        'sw.WriteLine("ImporteSubsidio" + Chr(wchar) + "0.00")
                                    Else
                                        'sw.WriteLine("ImporteSubsidio" + Chr(wchar) + (b.rs!t3_importe * -1 - a.rs!t1_ispt).ToString)
                                        sw.WriteLine("ImporteOtroPago" + Chr(wchar) + (b.rs!t3_importe * -1 - a.rs!t1_ispt).ToString)
                                    End If
                                    sw.WriteLine("SubsidioCausado" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                End If
                                If b.rs!t3_cpto = 440 Then
                                    If w_otp = 1 Then
                                        sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + (b.rs!t3_importe * -1 - a.rs!t1_ispt).ToString)
                                    End If
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "004")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    If a.rs!t1_ispt > (b.rs!t3_importe * -1) Then
                                        'sw.WriteLine("ImporteSubsidio" + Chr(wchar) + "0.00")
                                    Else
                                        'sw.WriteLine("ImporteSubsidio" + Chr(wchar) + (b.rs!t3_importe * -1 - a.rs!t1_ispt).ToString)
                                        'sw.WriteLine("ImporteOtroPago" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                    End If
                                    sw.WriteLine("ImporteOtroPago" + Chr(wchar) + Math.Round(b.rs!g14_saldo, 2).ToString)
                                    sw.WriteLine("SaldoAFavor" + Chr(wchar) + Math.Round(b.rs!g14_saldo, 2).ToString)
                                    sw.WriteLine("Anio" + Chr(wchar) + "2020")
                                    sw.WriteLine("RemanenteSalFav|" + Math.Round(b.rs!g14_saldo + b.rs!t3_importe, 2).ToString)
                                End If
                                w_otp = w_otp + 1
                            Else
                                If a.rs!t1_subsidio > 0 Then
                                    sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + "0.00")
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "002")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    sw.WriteLine("ImporteOtroPago" + Chr(wchar) + "0.00")
                                    sw.WriteLine("SubsidioCausado" + Chr(wchar) + a.rs!t1_subsidio.ToString)
                                End If
                                If b.rs!t3_cpto = 218 Then
                                    sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "003")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    sw.WriteLine("ImporteOtroPago" + Chr(wchar) + b.rs!t3_importe.ToString)
                                End If
                                If b.rs!t3_cpto = 103 Then
                                    sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + b.rs!t3_importe.ToString)
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "999")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    sw.WriteLine("ImporteOtroPago" + Chr(wchar) + b.rs!t3_importe.ToString)
                                End If
                                If b.rs!t3_cpto = 440 Then
                                    sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                    sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                    sw.WriteLine("TipoOtroPago" + Chr(wchar) + "004")
                                    sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                    sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                    sw.WriteLine("ImporteOtroPago" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                    sw.WriteLine("SaldoAFavor" + Chr(wchar) + (b.rs!g14_saldo).ToString)
                                    sw.WriteLine("Anio" + Chr(wchar) + "2020")
                                    If (b.rs!g14_saldo - (b.rs!t3_importe * -1)) > 0 Then
                                        sw.WriteLine("RemanenteSalFav" + Chr(wchar) + ((b.rs!g14_saldo - (b.rs!t3_importe * -1)).ToString))
                                    Else
                                        sw.WriteLine("RemanenteSalFav" + Chr(wchar) + "0.00")
                                    End If
                                End If
                            End If
                    End Select
                    sw.WriteLine("")
                End While
                If incapacidad > 0 Then
                    sw.WriteLine("Incapacidad|1")
                    sw.WriteLine("DiasIncapacidad|3")
                    sw.WriteLine("TipoIncapacidad|2")
                    sw.WriteLine("ImporteMonetario|" + Format(incapacidad, "#####0.00"))
                    sw.WriteLine("")
                    incapacidad = 0
                End If
            End If
            '===================== INICIA PROCESO DE PERCEPCIONES Y DEDUCCIONES
        End While
        sw.Close()
        file = Nothing
        sw = Nothing
        MsgBox("Inicio: " + w_tiempo + ", proceso Terminado: " + Mid(TimeOfDay.ToString, 12, 8))
        prb_estado.Value = 0
    End Sub
    Private Sub CerrarSemanaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSemanaToolStripMenuItem.Click
        Dim sem = ""
        While True
            sem = InputBox("Semana")
            a.qr("select * from anom201 where h1_semana=" + sem.ToString, 1)
            If a.rs.HasRows Then
                a.qr("select j2_cerrado from anom402 where j2_semana=" + sem.ToString, 1)
                a.rs.Read()
                If a.rs!j2_cerrado = "S" Then
                    MsgBox("Semana ya cerrada")
                    Exit While
                Else
                    a.qr("update anom402 set j2_cerrado='S' where j2_semana=" + sem.ToString, 2)
                    MsgBox("Semana " + sem.ToString + " cerrada para timbrado")
                    Exit While
                End If
            End If
        End While
    End Sub

    Private Sub RevisarTimbradoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub ReactivarSemanaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReactivarSemanaToolStripMenuItem.Click
        Dim sem = ""
        Dim tipos = ""
        Dim valid = ""
        If InputBox("Codigo de reproceso") <> "146352" Then
            MsgBox("Acceso no permitido")
            Exit Sub
        End If
        a.qr("update anom502 set k2_estado=2 where k2_estado=1", 2)
        While True
            sem = InputBox("Semana")
            tipos = ""
            If Val(sem) = 0 Then
                Exit Sub
            End If
            a.qr("select * from anom201 where h1_semana=" + sem.ToString, 1)
            If a.rs.HasRows Then
                a.qr("select distinct k2_tipo from anom502 where k2_semana=" + sem + " and k2_tponom<5", 1)
                If a.rs.HasRows Then
                    While a.rs.Read
                        valid = valid + a.rs!k2_tipo + ","
                    End While
                    While True
                        tipos = InputBox("selecciona tipo (" + valid + ")")
                        tipos = UCase(tipos)
                        If Len(tipos) = 1 Then
                            If InStr(1, valid, tipos, 1) Then
                                Exit While
                            End If
                        End If
                    End While
                End If
                a.qr("update anom502 set k2_estado=1 where k2_tponom<5 and k2_tipo='" + tipos + "' and k2_semana=" + sem.ToString, 2)
                a.qr("update anom304 set i4_ano_sem=" + sem.ToString +
                ",i4_inisem=(select h1_fecha_ini from anom201 where h1_semana=" + sem.ToString +
                "),i4_finsem=(select h1_fecha_fin from anom201 where h1_semana=" + sem.ToString + ")", 2)
                a.qr("update parametros set valor='C:\temp\' where tipo=1 and clave='ruta'", 2)
                a.qr("update anom402 set j2_cerrado='N' where j2_semana=" + sem.ToString, 2)
                Exit While
            End If
        End While
        bot_reporte.PerformClick()
        MsgBox("Proceso terminado")
    End Sub

    Private Sub Timbrado201733ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timbrado201733ToolStripMenuItem.Click
        trd_timbrado = Nothing
        trd_timbrado = New Thread(AddressOf timbrado3)
        trd_timbrado.IsBackground = True
        prb_estado.Value = 50
        trd_timbrado.Start()
    End Sub

    Private Sub RevisionTimbradoDetalleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RevisionTimbradoDetalleToolStripMenuItem.Click
        ofd_leer_timbrado.ShowDialog()
        Dim ar As New StreamReader(ofd_leer_timbrado.FileName)
        Dim ln As String = ""
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\detalle.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        Dim cantidad = 0
        Dim numtra = 0
        Dim nombre = ""
        Dim importe = 0.0
        Dim total = 0.0
        Dim total2 = 0.0
        Dim total3 = 0.0
        Dim accion = 1
        Dim cad = ""
        Dim sub1 As Double = 0
        Dim wtponom = 1
        While True
            wtponom = InputBox("Tipo de nomina (1,2,3)")
            If Val(wtponom) > 0 And Val(wtponom) < 4 Then
                Exit While
            End If
        End While
        If Val(wtponom) < 3 Then
            a.qr("select max(j1_semana) sem from anom401b", 1)
            a.rs.Read()
            a.qr("select j1_numtra,sum(case when j1_cpto=403 then j1_importe else 0 end) ispt,sum(case when j1_cpto=411 then j1_importe else 0 end) subsidio from anom401" + _
                " where j1_semana = " + a.rs!sem.ToString + _
                " and j1_tponom=" + wtponom.ToString + _
                " and j1_cpto in (403,411)" + _
                " and j1_tpo_emision<8" + _
                " group by j1_numtra" + _
                " having ((sum(case when j1_cpto=403 then j1_importe else 0 end)+sum(case when j1_cpto=411 then j1_importe else 0 end))>0) and (sum(case when j1_cpto=411 then j1_importe else 0 end))!=0", 1)
            While a.rs.Read
                'sub1 += 1
            End While
        End If
        Do
            ln = ar.ReadLine
            cad = "RNombre|"
            If Mid(ln, 1, Len(cad)) = cad Then
                nombre = Mid(ln, Len(cad) + 1, 50)
            End If
            cad = "NumEmpleado|"
            If Mid(ln, 1, Len(cad)) = cad Then
                If numtra <> Val(Mid(ln, Len(cad) + 1, 5)) And numtra <> 0 Then
                    sw.WriteLine(numtra.ToString + Chr(9) + nombre.ToString + Chr(9) + Math.Round(importe, 2).ToString + Chr(9) + Math.Round(total3, 2).ToString)
                    total = total + Math.Round(importe, 2)
                    importe = 0.0
                    total3 = 0.0
                End If
                numtra = Val(Mid(ln, Len(cad) + 1, 5))
                cantidad = cantidad + 1
            End If
            cad = "Percepcion|"
            If Mid(ln, 1, Len(cad)) = cad Then
                accion = 1
            End If
            cad = "Deduccion|"
            If Mid(ln, 1, Len(cad)) = cad Then
                accion = 2
            End If
            cad = "TotalExento|"
            If Mid(ln, 1, Len(cad)) = cad Then
                If accion = 1 Then
                    total2 += Val(Mid(ln, Len(cad) + 1, 15))
                    total3 += Val(Mid(ln, Len(cad) + 1, 15))
                Else
                    total2 -= Val(Mid(ln, Len(cad) + 1, 15))
                    total3 -= Val(Mid(ln, Len(cad) + 1, 15))
                End If
            End If
            cad = "TotalGravado|"
            If Mid(ln, 1, Len(cad)) = cad Then
                If accion = 1 Then
                    total2 += Val(Mid(ln, Len(cad) + 1, 15))
                    total3 += Val(Mid(ln, Len(cad) + 1, 15))
                Else
                    total2 -= Val(Mid(ln, Len(cad) + 1, 15))
                    total3 -= Val(Mid(ln, Len(cad) + 1, 15))
                End If
            End If
            cad = "ImporteGravado|"
            If Mid(ln, 1, Len(cad)) = cad Then
                If accion = 1 Then
                    importe = importe + Val(Mid(ln, Len(cad) + 1, 15))
                Else
                    importe = importe - Val(Mid(ln, Len(cad) + 1, 15))
                End If
            End If
            cad = "ImporteExento|"
            If Mid(ln, 1, Len(cad)) = cad Then
                If accion = 1 Then
                    importe = importe + Val(Mid(ln, Len(cad) + 1, 15))
                Else
                    importe = importe - Val(Mid(ln, Len(cad) + 1, 15))
                End If
            End If
            cad = "ImporteSubsidio|"
            If Mid(ln, 1, Len(cad)) = cad Then
                importe = importe + Val(Mid(ln, Len(cad) + 1, 15))
                total2 += Val(Mid(ln, Len(cad) + 1, 15))
                total3 += Val(Mid(ln, Len(cad) + 1, 15))
            End If
            cad = "ImporteOtroPago|"
            If Mid(ln, 1, Len(cad)) = cad Then
                importe = importe + Val(Mid(ln, Len(cad) + 1, 15))
                total2 += Val(Mid(ln, Len(cad) + 1, 15))
                total3 += Val(Mid(ln, Len(cad) + 1, 15))
            End If
        Loop Until ln Is Nothing
        sw.WriteLine(numtra.ToString + Chr(9) + nombre.ToString + Chr(9) + Math.Round(importe, 2).ToString + Chr(9) + Math.Round(total3, 2).ToString)
        total = total + Math.Round(importe, 2)
        sw.Close()
        sub1 = sub1 / 100
        MsgBox(cantidad.ToString + Chr(13) + FormatCurrency(total - sub1).ToString + "   -   " + FormatCurrency(total2 - sub1))
    End Sub

    Private Sub RevisionTimbradoEncabezadoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RevisionTimbradoEncabezadoToolStripMenuItem.Click
        ofd_leer_timbrado.ShowDialog()
        Dim ar As StreamReader
        Try
            ar = New StreamReader(ofd_leer_timbrado.FileName)
        Catch ex As Exception
            Exit Sub
        End Try
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\encabe.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        Dim lin As String
        Dim numtra = 0
        Dim nombre = ""
        Dim cad
        Dim importe As Double = 0
        Dim imp As Double = 0
        Dim pagar As Double = 0
        Dim pag As Double = 0
        Dim subtotal As Double = 0
        Dim subt As Double = 0
        Dim sub1 As Double = 0
        Dim wtponom = 1
        While True
            wtponom = InputBox("Tipo de nomina (1,2,3)")
            If Val(wtponom) > 0 And Val(wtponom) < 4 Then
                Exit While
            End If
        End While
        If Val(wtponom) < 3 Then
            a.qr("select max(j1_semana) sem from anom401b", 1)
            a.rs.Read()
            a.qr("select j1_numtra,sum(case when j1_cpto=403 then j1_importe else 0 end) ispt,sum(case when j1_cpto=411 then j1_importe else 0 end) subsidio from anom401" + _
                " where j1_semana = " + a.rs!sem.ToString + _
                " and j1_tponom=" + wtponom.ToString + _
                " and j1_cpto in (403,411)" + _
                " and j1_tpo_emision<8" + _
                " group by j1_numtra" + _
                " having ((sum(case when j1_cpto=403 then j1_importe else 0 end)+sum(case when j1_cpto=411 then j1_importe else 0 end))>0) and (sum(case when j1_cpto=411 then j1_importe else 0 end))!=0", 1)
            While a.rs.Read
                'sub1 += 1
            End While
            'sub1 = sub1 / 100
        End If
        Do
            lin = ar.ReadLine
            If Not lin Is Nothing Then
                cad = "PrecMX|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    subtotal += Val(Mid(lin, Len(cad) + 1, 15))
                    subt += Val(Mid(lin, Len(cad) + 1, 15))
                End If
                cad = "TotNeto|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    importe += Val(Mid(lin, Len(cad) + 1, 15))
                    imp += Val(Mid(lin, Len(cad) + 1, 15))
                End If
                cad = "TotImpR|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    importe -= Val(Mid(lin, Len(cad) + 1, 15))
                    imp -= Val(Mid(lin, Len(cad) + 1, 15))
                    subtotal -= Val(Mid(lin, Len(cad) + 1, 15))
                    subt -= Val(Mid(lin, Len(cad) + 1, 15))
                End If
                cad = "TotCargDesc|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    importe -= Val(Mid(lin, Len(cad) + 1, 15))
                    imp -= Val(Mid(lin, Len(cad) + 1, 15))
                    subtotal -= Val(Mid(lin, Len(cad) + 1, 15))
                    subt -= Val(Mid(lin, Len(cad) + 1, 15))
                End If
                cad = "Importe|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    pagar += Val(Mid(lin, Len(cad) + 1, 15))
                    pag += Val(Mid(lin, Len(cad) + 1, 15))
                End If
                cad = "NumEmpleado|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    numtra = Val(Mid(lin, Len(cad) + 1, 5))
                End If
                cad = "TotalOtrosPagos|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    subtotal += Val(Mid(lin, Len(cad) + 1, 15))
                    subt += Val(Mid(lin, Len(cad) + 1, 15))
                End If
                cad = "CFD|"
                If Mid(lin, 1, Len(cad)) = cad Then
                    sw.WriteLine(numtra.ToString + Chr(9) + imp.ToString + Chr(9) + pag.ToString + Chr(9) + subt.ToString)
                    imp = 0
                    pag = 0
                    subt = 0
                End If
            End If
        Loop Until lin Is Nothing
        sw.WriteLine(numtra.ToString + Chr(9) + imp.ToString + Chr(9) + pag.ToString + Chr(9) + subt.ToString)
        sw.Close()
        MsgBox(Format(importe, "##,###,##0.00") + "    -     " + Format(pagar, "##,###,##0.00") + "    -    " + Format(subtotal, "##,###,##0.00"))
    End Sub

    Private Sub CargarPensionesDispersionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarPensionesDispersionToolStripMenuItem.Click
        Dim wsemana = ""
        Dim ini = ""
        Dim fin = ""
        Dim pago = ""
        Dim valor = 0
        Dim lin() As String
        Dim tipo = 0
        Dim ar As StreamReader
        a.qr("select i4_ano_sem,convert(char(10),getdate(),103) fecha from anom304", 1)
        a.rs.Read()
        wsemana = a.rs!i4_ano_sem.ToString
        a.qr("select convert(char(10),h1_fecha_ini,103) ini,convert(char(10),h1_fecha_fin,103) fin,convert(char(10),dateadd(day,4,h1_fecha_fin),103) pago from anom201 where h1_semana=" + wsemana, 1)
        a.rs.Read()
        ini = a.rs!ini
        fin = a.rs!fin
        pago = a.rs!pago
        If ofd_leer_timbrado.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ar = New StreamReader(ofd_leer_timbrado.FileName)
            Dim cont = 1
            While True
                lin = Split(ar.ReadLine, Chr(9))
                If Len(lin(0)) = 0 Then
                    Exit While
                End If
                Try
                    For x = 0 To 2
                        valor = Val(lin(x))
                    Next
                Catch ex As Exception
                    MsgBox("Error fila " + cont.ToString)
                End Try
                cont += 1
            End While
            ar = New StreamReader(ofd_leer_timbrado.FileName)
            While True
                lin = Split(ar.ReadLine, Chr(9))
                If Len(lin(0)) = 0 Then
                    Exit While
                End If
                a.qr("insert into anom502 values(8," + lin(0).ToString + "," + lin(2).ToString + ",13000,3,0,'" + ini + "','" + fin + "'," + lin(1).ToString + ",2,'S','" + pago + "','P'," + wsemana + ",'" + ini + "')", 2)
            End While
            MsgBox("Pensiones cargadas")
            ar.Close()
        End If
    End Sub

    Private Sub ResumenPorPersonaYConceptoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenPorPersonaYConceptoToolStripMenuItem.Click
        Dim wb As New Workbook
        Dim hoja As Worksheet = wb.Worksheets(0)
        Dim cols = 0
        Dim fil = 0
        Dim sem = 0
        Dim netopag = 0.00
        Dim fic = ""
        a.qr("select i4_ano_sem from anom304", 1)
        a.rs.Read()
        sem = a.rs!i4_ano_sem
        Dim wtipo = ""
        Dim wtponom = ""
        While True
            wtipo = UCase(InputBox("Tipo de nomina (E,J,G,K,F,A,P)"))
            If Len(wtipo) = 1 Then
                Exit While
            End If
        End While
        If wtipo = "P" Then
            While True
                wtponom = UCase(InputBox("Numero de nomina pensionada (5 a 15)"))
                If Val(wtponom) > 4 And Val(wtponom) < 16 Then
                    Exit While
                End If
            End While
        End If
        fic = "C:\temp\rep_anom502_" + wtipo + "_" + sem.ToString + ".xlsx"
        Dim query = ""
        If wtipo = "P" Then
            a.qr("select count(distinct k2_cpto) cols from anom502" +
                 " where k2_semana=(select i4_ano_sem from anom304)" +
                 " and k2_tipo='" + wtipo + "'" +
                 " and k2_tponom=" + wtponom, 1)
        Else
            a.qr("select count(distinct k2_cpto) cols from anom502" +
                 " where k2_semana=(select i4_ano_sem from anom304)" +
                 " And k2_tipo='" + wtipo + "'", 1)
        End If

        a.rs.Read()
        cols = a.rs!cols - 1
        Dim encabe(cols) As String
        Dim cptos(cols) As Int16
        If wtipo = "P" Then
            a.qr("select distinct k2_cpto,substring(g4_nombre,1,15) cpto from anom502,anom104 " +
                " where k2_cpto=g4_cpto " +
                " and k2_semana=(select i4_ano_sem from anom304)" +
                " and k2_tipo='" + wtipo + "'" +
                " and k2_tponom=" + wtponom +
                " order by 1", 1)
        Else
            a.qr("select distinct k2_cpto,substring(g4_nombre,1,15) cpto from anom502,anom104 " +
                " where k2_cpto=g4_cpto " +
                " and k2_semana=(select i4_ano_sem from anom304)" +
                " and k2_tipo='" + wtipo + "'" +
                " order by 1", 1)
        End If
        While a.rs.Read
            encabe(fil) = a.rs!cpto
            cptos(fil) = a.rs!k2_cpto
            fil = fil + 1
        End While
        fil = 1
        If wtipo = "P" Then
            query += "select k2_tponom,k2_numtra,v_nombrerep nombre,sum(case when k2_cpto=" + cptos(0).ToString + " then k2_importe else 0 end) '" + encabe(0) + "'"
        Else
            query += "select k2_tponom,k2_numtra,nombre,sum(case when k2_cpto=" + cptos(0).ToString + " then k2_importe else 0 end) '" + encabe(0) + "'"
        End If
        For fil = 1 To cols
            query += ",sum(case when k2_cpto=" + cptos(fil).ToString + " then k2_importe else 0 end) '" + encabe(fil) + "'"
        Next
        If wtipo = "P" Then
            query += " from anom502,vacre102" +
                    " where k2_numtra=v_clave" +
                    " and v_relab=11" +
                    " and k2_semana=(select i4_ano_sem from anom304)" +
                    " and k2_tipo='" + wtipo + "'" +
                    " and k2_tponom=" + wtponom +
                    " group by k2_tponom,k2_numtra,v_nombrerep" +
                    " order by 1,2"
        Else
            query += " from anom502,nombres" +
                    " where k2_numtra=numtra" +
                    " and k2_tponom=tponom" +
                    " and k2_semana=(select i4_ano_sem from anom304)" +
                    " and k2_tipo='" + wtipo + "'" +
                    " group by k2_tponom,k2_numtra,nombre" +
                    " order by 1,2"
        End If

        a.qr(query, 1)
        hoja.Range(1, 1).Text = "TPONOM"
        hoja.Range(1, 2).Text = "NUMTRA"
        hoja.Range(1, 3).Text = "NOMBRE"
        hoja.Range(1, 4).Text = encabe(0)
        For fil = 1 To cols
            hoja.Range(1, fil + 4).Text = encabe(fil)
        Next
        fil = 2
        Dim cp = 1
        While a.rs.Read
            Try
                hoja.Range(fil, 1).NumberValue = a.rs.Item(0).ToString
                hoja.Range(fil, 2).NumberValue = a.rs.Item(1).ToString
                hoja.Range(fil, 3).Text = a.rs.Item(2).ToString
                hoja.Range(fil, 4).NumberValue = a.rs.Item(3).ToString
                hoja.Range(fil, 4).NumberFormat = "#,##0.00"
                netopag += a.rs.Item(3)
                For x = 1 To cols
                    hoja.Range(fil, x + 4).NumberValue = a.rs.Item(x + 3).ToString
                    hoja.Range(fil, x + 4).NumberFormat = "#,##0.00"
                    If cptos(cp) < 400 Then
                        netopag += a.rs.Item(x + 3)
                    Else
                        netopag -= a.rs.Item(x + 3)
                    End If
                    cp += 1
                Next
                hoja.Range(fil, cols + 5).NumberValue = netopag
                hoja.Range(fil, cols + 5).NumberFormat = "#,##0.00"
                fil += 1
                cp = 1
                netopag = 0
            Catch ex As Exception
                MsgBox("ERROR EN FILA " + fil.ToString)
            End Try
        End While
        fil -= 1
        hoja.Range(a.letra(cols + 5) + "1").Text = "NETO A PAGAR"
        hoja.Range("A1:" + a.letra(cols + 5) + fil.ToString).BorderInside(LineStyleType.Thin, Color.Black)
        hoja.Range("A1:" + a.letra(cols + 5) + fil.ToString).BorderAround(LineStyleType.Thin, Color.Black)
        hoja.Range("A1:" + a.letra(cols + 5) + "1").Style.Color = Color.DarkSeaGreen
        hoja.Range("A1:" + a.letra(cols + 5) + "1").Style.Font.IsBold = True
        hoja.Range("A1:" + a.letra(cols + 5) + "1").Style.HorizontalAlignment = HorizontalAlignment.Center
        hoja.Range("A1:" + a.letra(cols + 5) + fil.ToString).Style.Font.FontName = "Calibri"
        hoja.Range("A1:" + a.letra(cols + 5) + fil.ToString).Style.Font.Size = 11
        hoja.AllocatedRange.AutoFitColumns()
        hoja.Range(a.letra(cols + 5) + (fil + 2).ToString).Formula = "=SUM(" + a.letra(cols + 5) + "2:" + a.letra(cols + 5) + fil.ToString + ")"
        hoja.Range(a.letra(cols + 5) + (fil + 2).ToString).NumberFormat = "#,##0.00"
        Try
            wb.SaveToFile(fic, ExcelVersion.Version2010)
        Catch ex As Exception
            MsgBox("Archivo abierto, cerrar archivo.")
        End Try

        wb = Nothing
        hoja = Nothing
        MsgBox("Archivo creado: " + fic)
    End Sub

    Private Sub AcumuladoPorTrabajadorConceptoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcumuladoPorTrabajadorConceptoToolStripMenuItem.Click
        Dim ini = 0
        Dim fin = 0
        While True
            ini = Val(InputBox("Semana inicial"))
            If ini = 0 Then
                Exit Sub
            End If
            a.qr("select * from anom201 where h1_semana=" + ini.ToString, 1)
            If a.rs.HasRows Then
                Exit While
            Else
                MsgBox("Semana incorrecta")
            End If
        End While
        While True
            fin = Val(InputBox("Semana final"))
            If fin = 0 Then
                Exit Sub
            End If
            If (fin - ini) > 77 Then
                MsgBox("Rango demasiado amplio, reduce la semana, demasiados registros pueden causar perdida de informacion.")
            Else
                a.qr("select * from anom201 where h1_semana=" + fin.ToString, 1)
                If a.rs.HasRows Then
                    Exit While
                Else
                    MsgBox("Semana incorrecta")
                End If
            End If
        End While
        Dim archivo = "c:\temp\rep_acumulado_"
        Dim hoja As Worksheet
        Dim libro As Workbook
        Dim fila As Integer
        fila = 5
        archivo = archivo + Mid(ini.ToString, 5, 2) + "_" + Mid(fin.ToString, 5, 2) + ".xlsx"
        Try
            If File.Exists(archivo) Then
                My.Computer.FileSystem.DeleteFile(archivo)
            End If
        Catch ex As Exception
            MsgBox("Archivo se encuentra abierto: " + archivo)
            Exit Sub
        End Try
        libro = New Workbook
        hoja = libro.Worksheets(0)
        ' Encabezado y nombre del reporte
        hoja.Range("A1").Text = "INDUSTRIAL AZUCARERA SAN CRISTOBAL S.A. DE C.V."
        hoja.Range("A2").Text = "ACUMULADO PAGOS EXTRAORDINARIOS " + ini.ToString + " A " + fin.ToString
        hoja.Range("A1").Style.Font.Size = 16
        hoja.Range("A2").Style.Font.Size = 12
        hoja.Range("A1:A2").Style.Font.FontName = "Calibri"
        hoja.Range("A1:A2").Style.HorizontalAlignment = HorizontalAlignment.Center
        hoja.Range("A1:A2").Style.Font.IsBold = True
        hoja.Range("A1:G1").Merge()
        hoja.Range("A2:G2").Merge()
        ' Titulos de columnas
        With hoja.Range("A4:G4")
            .Style.Color = Color.DarkSeaGreen
            .Style.Font.IsBold = True
            .Style.HorizontalAlignment = HorizontalAlignment.Center
        End With
        hoja.Range("A4").Text = "SEMANA"
        hoja.Range("B4").Text = "NUMTRA"
        hoja.Range("C4").Text = "NOMBRE"
        hoja.Range("D4").Text = "TIPO"
        hoja.Range("E4").Text = "CPTO"
        hoja.Range("F4").Text = "DESCRIP"
        hoja.Range("G4").Text = "IMPORTE"
        ' Filas
        a.qr("select k2_semana,k2_numtra,nombre,k2_tipo,g4_cpto,g4_nombre,case when k2_cpto<400 then k2_importe else k2_importe*-1 end " +
            " from anom502,nombres,anom104" +
            " where k2_semana between " + ini.ToString + " and " + fin.ToString +
            " and k2_tponom<5" +
            " and k2_cpto=g4_cpto" +
            " and tponom=k2_tponom" +
            " and k2_numtra=numtra" +
            " order by k2_semana,k2_tipo,k2_numtra,k2_cpto", 1)
        If Not a.rs.HasRows Then
            MsgBox("Consulta incorrecta")
            Exit Sub
        End If
        While a.rs.Read
            Try
                hoja.Range(fila, 1).NumberValue = a.rs.Item(0)
                hoja.Range(fila, 2).NumberValue = a.rs.Item(1)
                hoja.Range(fila, 3).Text = a.rs.Item(2)
                hoja.Range(fila, 4).Text = a.rs.Item(3)
                hoja.Range(fila, 5).NumberValue = a.rs.Item(4)
                hoja.Range(fila, 6).Text = a.rs.Item(5)
                hoja.Range(fila, 7).NumberValue = a.rs.Item(6)
                fila += 1
            Catch ex As Exception
                MsgBox(a.rs.Item(0))
                MsgBox(a.rs.Item(1))
                MsgBox(a.rs.Item(2))
                MsgBox(a.rs.Item(3))
                MsgBox(a.rs.Item(4))
                MsgBox(a.rs.Item(5))
                MsgBox(a.rs.Item(6))
                Exit Sub
            End Try
        End While
        fila -= 1
        hoja.Range("A4:G" + fila.ToString).BorderAround(LineStyleType.Medium, Color.Black)
        hoja.Range("A4:G" + fila.ToString).BorderInside(LineStyleType.Thin, Color.Black)
        fila += 2
        hoja.Range(fila, 7).Formula = "=+SUM(G6:G" + (fila - 2).ToString + ")"
        hoja.Range("G5:G" + fila.ToString).NumberFormat = "#,##0.00"
        hoja.AllocatedRange.AutoFitColumns()
        libro.SaveToFile(archivo, ExcelVersion.Version2010)
        hoja = Nothing
        libro = Nothing
        MsgBox("Reporte realizado: " + archivo)
    End Sub

    Private Sub bot_elim_buscar_Click(sender As Object, e As EventArgs) Handles bot_elim_buscar.Click
        Dim cant = 1
        Dim semana = txt_eli_semana.Text
        Dim importe = 0.00
        Dim query = "select k2_tponom,k2_numtra,k2_tipo,k2_cpto,K2_SEMANA,k2_importe from anom502"
        dgv_eliminar.Rows.Clear()
        txt_eli_importe.Text = 0.00
        If Not Val(txt_eli_semana.Text) > 0 Then
            MsgBox("Campo semana necesario")
            Exit Sub
        End If
        a.qr("select * from anom201 where h1_semana=" + semana.ToString, 1)
        If Not a.rs.HasRows Then
            MsgBox("Semana incorrecta, campo necesario")
            Exit Sub
        Else
            query += " where k2_semana=" + semana.ToString
        End If
        If Val(txt_eli_numtra.Text) > 0 Then
            query += " and k2_numtra=" + txt_eli_numtra.Text.ToString
        End If
        If cmb_eli_tponom.SelectedIndex > -1 Then
            query += " and k2_tponom=" + Mid(cmb_eli_tponom.Text, 1, 1)
        End If
        If Len(txt_eli_letra.Text) Then
            query += " and k2_tipo='" + txt_eli_letra.Text + "'"
        End If
        query += " order by k2_semana,k2_numtra,k2_cpto"
        a.qr(query, 1)
        If a.rs.HasRows Then
            While a.rs.Read
                dgv_eliminar.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4), a.rs.Item(5))
                cant += 1
                If cant = 100 Then
                    MsgBox("Demasiados registros, reducir consulta")
                    Exit While
                End If
            End While
            cant = 0
            While cant < dgv_eliminar.Rows.Count
                If dgv_eliminar.Rows(cant).Cells(3).Value > 400 Then
                    importe = importe - dgv_eliminar.Rows(cant).Cells(5).Value
                Else
                    importe = importe + dgv_eliminar.Rows(cant).Cells(5).Value
                End If
                cant = cant + 1
            End While
            txt_eli_importe.Text = importe
        Else
            MsgBox("Sin registros")
        End If

    End Sub

    Private Sub bot_elim_borrar_Click(sender As Object, e As EventArgs) Handles bot_elim_borrar.Click
        Dim query = "select * from anom502 "
        Dim qdelete = "delete from anom502"
        Dim semana = txt_eli_semana.Text
        If InputBox("Clave de acceso") = "864209" Then
            If Not Val(txt_eli_semana.Text) > 0 Then
                MsgBox("Campo semana necesario")
                Exit Sub
            End If
            a.qr("select * from anom201 where h1_semana=" + semana.ToString, 1)
            If Not a.rs.HasRows Then
                MsgBox("Semana incorrecta, campo necesario")
                Exit Sub
            Else
                query += " where k2_semana=" + semana.ToString
                qdelete += " where k2_semana=" + semana.ToString
            End If
            If Val(txt_eli_numtra.Text) > 0 Then
                query += " and k2_numtra=" + txt_eli_numtra.Text.ToString
                qdelete += " and k2_numtra=" + txt_eli_numtra.Text.ToString

            End If
            If cmb_eli_tponom.SelectedIndex > -1 Then
                query += " and k2_tponom=" + Mid(cmb_eli_tponom.Text, 1, 1)
                qdelete += " and k2_tponom=" + Mid(cmb_eli_tponom.Text, 1, 1)
            End If
            If Len(txt_eli_letra.Text) Then
                query += " and k2_tipo='" + txt_eli_letra.Text + "'"
                qdelete += " and k2_tipo='" + txt_eli_letra.Text + "'"

            End If
            a.qr(query, 1)
            If a.rs.HasRows Then
                MsgBox(qdelete + " " + Chr(13) + txt_eli_importe.Text.ToString)
            End If
        End If
    End Sub

    Private Sub bot_elim_ajuste_Click(sender As Object, e As EventArgs) Handles bot_elim_ajuste.Click
        Dim query = "select * from anom502 "
        Dim qajuste = "insert into ajustesconcil select k2_semana,k2_tponom,k2_numtra,k2_cpto,k2_importe*-1 from anom502"
        Dim semana = txt_eli_semana.Text
        If InputBox("Clave de acceso") = "864209" Then
            If Not Val(txt_eli_semana.Text) > 0 Then
                MsgBox("Campo semana necesario")
                Exit Sub
            End If
            a.qr("select * from anom201 where h1_semana=" + semana.ToString, 1)
            If Not a.rs.HasRows Then
                MsgBox("Semana incorrecta, campo necesario")
                Exit Sub
            Else
                query += " where k2_semana=" + semana.ToString
                qajuste += " where k2_semana=" + semana.ToString
            End If
            If Val(txt_eli_numtra.Text) > 0 Then
                query += " and k2_numtra=" + txt_eli_numtra.Text.ToString
                qajuste += " and k2_numtra=" + txt_eli_numtra.Text.ToString

            End If
            If cmb_eli_tponom.SelectedIndex > -1 Then
                query += " and k2_tponom=" + Mid(cmb_eli_tponom.Text, 1, 1)
                qajuste += " and k2_tponom=" + Mid(cmb_eli_tponom.Text, 1, 1)
            End If
            If Len(txt_eli_letra.Text) Then
                query += " and k2_tipo='" + txt_eli_letra.Text + "'"
                qajuste += " and k2_tipo='" + txt_eli_letra.Text + "'"

            End If
            a.qr(query, 1)
            If a.rs.HasRows Then
                MsgBox(qajuste + " " + Chr(13) + txt_eli_importe.Text.ToString)
            End If
        End If
    End Sub
End Class