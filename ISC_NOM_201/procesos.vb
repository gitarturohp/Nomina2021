Imports System.Data.SqlClient
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports System.Net.Mail
Imports System.Threading
Imports System.Object
Imports Spire.Xls
Public Structure wfec
    Dim w_dia1, w_dia2, w_dia3, w_dia4, w_dia5, w_dia6, w_dia7 As Integer
    Dim w_fec1, w_fec2, w_fec3, w_fec4, w_fec5, w_fec6, w_fec7 As Date
    Dim w_fes1, w_fes2, w_fes3, w_fes4, w_fes5, w_fes6, w_fes7 As String
End Structure
Public Class procesos
    Private trd_timbrado As Thread
    Private trd_carga As Thread
    Private trd_nomina As Thread
    Private trd_impunix As Thread
    Private trd_salimss As Thread
    Public a As New Clase
    Public tparam As New DataTable
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub bot_car_asis_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripStatusLabel1.Text = "Activo"
    End Sub
    Private Sub ResumenPorConceptoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenPorConceptoToolStripMenuItem.Click
        Dim op As String = ""
        Dim wsemi, wsemf As String
        While True
            While True
                wsemi = InputBox("Semana Inicial: ")
                a.qr("select * from anom201 where h1_semana=" + wsemi, 1)
                If a.rs.HasRows Then
                    Exit While
                End If
                MsgBox("Semana Inicial Incorrecta", MsgBoxStyle.Exclamation)
            End While
            While True
                wsemf = InputBox("Semana Final: ")
                a.qr("select * from anom201 where h1_semana=" + wsemf, 1)
                If a.rs.HasRows Then
                    Exit While
                End If
                MsgBox("Semana Final Incorrecta", MsgBoxStyle.Exclamation)
            End While
            If wsemi > wsemf Then
                MsgBox("Semana inicial mayor que la final", MsgBoxStyle.Critical)
            Else
                Exit While
            End If
        End While
        While True
            op = InputBox("Opcion: (1) Nomina  (2)Premio  (3)finiquitos  (4)Jubilados  (5)Becarios")
            If Val(op) > 0 And Val(op) < 6 Then
                Exit While
            End If
        End While
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\rep_nom_" + op.ToString + ".txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("dimm_res1 " + wsemi + "," + wsemf + "," + op, 1)
        While a.rs.Read
            sw.WriteLine(a.rs.Item(0).ToString + Chr(9) + a.rs.Item(1).ToString + Chr(9) + a.rs.Item(2).ToString + Chr(9) + a.rs.Item(3).ToString + Chr(9) + a.rs.Item(4).ToString + Chr(9))
        End While
        sw.Close()
        MsgBox("Reporte Creado")
        Process.Start(fic)
    End Sub

    Private Sub RevisionRFCCURPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisionRFCCURPToolStripMenuItem.Click
        Dim op As String = "1"
        While True
            op = InputBox("(1) Sindicalizado   (2) Confianza")
            If Val(op) > 0 And Val(op) < 3 Then
                Exit While
            End If
        End While
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\nomina_" + op.ToString + ".txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        If op = "1" Then
            a.qr("select J1_tponom,v_fisica,j1_numtra,v_nombrerep+replicate(' ',50-len(v_nombrerep)),v_rfc_rep,v_curp_rep from obrero_rfc_curp", 1)
            sw.WriteLine("   REPORTE DE EMPLEADOS SINDICALIZADO SIN CURP O RFC")
        Else
            a.qr("select J1_tponom,v_fisica,j1_numtra,v_nombrerep+replicate(' ',50-len(v_nombrerep)),v_rfc_rep,v_curp_rep from empleado_rfc_curp", 1)
            sw.WriteLine("   REPORTE DE EMPLEADOS DE CONFIANZA SIN CURP O RFC")
        End If
        sw.WriteLine("=============================================================================")
        sw.WriteLine(" TPONOM   ID   NUMTRA     NOMBRE     RFC         CURP")
        sw.WriteLine("=============================================================================")
        While a.rs.Read
            sw.WriteLine("   " + a.rs.Item(0).ToString + Chr(9) +
                         a.rs.Item(1).ToString + Chr(9) +
                         a.rs.Item(2).ToString + Chr(9) +
                         a.rs.Item(3).ToString + Chr(9) +
                         a.rs.Item(4).ToString + Chr(9) +
                         a.rs.Item(5).ToString + Chr(9))
        End While
        sw.Close()
        sw = Nothing
        file = Nothing
        Process.Start(fic)
    End Sub

    Private Sub Timbrado2017ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim file As System.IO.FileStream
        Dim wchar As Integer = Asc("|")
        Dim fic As String
        Dim folio = 1
        Dim det As New Clase
        Dim w_tponom = 1
        Dim w_nomina = 1
        Dim w_numtra = 1
        Dim w_per = 1
        Dim w_ded = 1
        Dim w_query = ""
        Dim w_tiempo = Mid(TimeOfDay.ToString, 12, 8)
        Dim datos(10) As String
        While True
            w_tponom = Val(InputBox("Tipo de Nomina: (1) Nomina Obreros  (2) Nomina Empleado  (3) Premio Obreros"))
            If w_tponom > 0 And w_tponom < 4 Then
                Exit While
            End If
        End While
        If w_tponom = 1 Then
            w_query = " and v_relab=3 and j1_tponom=1 and j1_nomina=1"
        Else
            If w_tponom = 2 Then
                w_query = " and v_relab=4 and j1_tponom=2 and j1_nomina=1"
            Else
                w_query = " and v_relab=3 and j1_tponom=1 and j1_nomina=2"
            End If
        End If
        '==== temp1
        a.qr("timbrado " + w_nomina.ToString + "," + w_tponom.ToString + ",1,'N'", 2)
        MsgBox("termina 1")
        '===== temp2
        a.qr("catdepto " + w_nomina.ToString + "," + w_tponom.ToString + ",1,'N'", 2)
        MsgBox("termina 2")
        '===== temp3
        a.qr("cargadetalle " + w_nomina.ToString + "," + w_tponom.ToString + ",1,'N'", 2)
        MsgBox("termina 3")
        '===== CARGA DATOS GENERALES
        a.qr("select g1_reg_patron regimss,i4_ciclo ciclo,i4_ano_sem semana,j2_serie serie,g1_nombre,g1_rfc,replace(convert(char(20),h1_fecha_fin+4,111),'/','-') pago," +
             " replace(convert(char(20),h1_fecha_ini,111),'/','-') ini,replace(convert(char(20),h1_fecha_fin,111),'/','-') fin,g1_cp" +
             " from anom304,anom402,anom101,anom201 " +
             " where i4_ano_sem=j2_semana" +
             " and j2_semana=h1_semana", 1)
        a.rs.Read()
        datos(0) = a.rs!regimss
        datos(1) = a.rs!ciclo
        datos(2) = a.rs!semana.ToString
        datos(3) = a.rs!serie
        datos(4) = a.rs!g1_nombre
        datos(5) = a.rs!g1_rfc
        datos(6) = a.rs!pago
        datos(7) = a.rs!fin
        datos(8) = a.rs!ini
        datos(9) = a.rs!g1_cp.ToString
        fic = "c:\temp\" + w_tponom.ToString + "_NOM_" + datos(2) + ".txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select count(*) num from temp1", 1)
        a.rs.Read()
        MsgBox("Registros a procesar: " + a.rs!num.ToString)
        '===== LISTADO GENERAL DE TIMBRADO
        w_numtra = 1
        w_per = 1
        w_ded = 1
        a.qr("select * from listanom,temp1,temp2,temp3,sdi" +
            " where j1_nomina = " + w_nomina.ToString +
            " and j1_tponom=t1_tponom" +
            " and j1_numtra=t1_numtra" +
            " and j1_tponom=t2_tponom" +
            " and j1_numtra=t2_numtra" +
            " and j1_tponom=t3_tponom" +
            " and j1_numtra=t3_numtra" +
            " and j1_numtra=s1_numtra" +
            " and j1_tponom=s1_tponom" +
            " and s1_semana=" + datos(2).ToString +
            " order by 1,2,3,t3_cpto", 1)
        While a.rs.Read
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
                sw.WriteLine("Pago" + Chr(wchar) + "En una sola exhibición")
                sw.WriteLine("MetPago" + Chr(wchar) + "NA")
                sw.WriteLine("LugarExp" + Chr(wchar) + datos(9))
                sw.WriteLine("NoCta" + Chr(wchar) + "No Identificado")
                sw.WriteLine("Notas" + Chr(wchar) + "Información adicional")
                sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_ispt - a.rs!t1_descto).ToString)
                sw.WriteLine("Info" + Chr(wchar) + "Nomina")
                sw.WriteLine("ERFC" + Chr(wchar) + RTrim(datos(5)))
                sw.WriteLine("ENombre" + Chr(wchar) + RTrim(datos(4)))
                sw.WriteLine("RRFC" + Chr(wchar) + a.rs!v_rfc_rep)
                sw.WriteLine("RNombre" + Chr(wchar) + a.rs!v_nombrerep)
                sw.WriteLine("NumLin" + Chr(wchar) + "1")
                sw.WriteLine("Cant|1")
                sw.WriteLine("UM|ACT")
                sw.WriteLine("Desc" + Chr(wchar) + "Pago de nómina")
                sw.WriteLine("PrecMX" + Chr(wchar) + a.rs!t1_neto.ToString)
                sw.WriteLine("TotNeto" + Chr(wchar) + a.rs!t1_neto.ToString)
                sw.WriteLine("TotImpR" + Chr(wchar) + a.rs!t1_ispt.ToString)
                sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_descto - a.rs!t1_ispt).ToString)
                sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                sw.WriteLine("MonImpR" + Chr(wchar) + a.rs!t1_ispt.ToString)
                sw.WriteLine("Campo0" + Chr(wchar) + "REGIMEN")
                sw.WriteLine("Campo1" + Chr(wchar) + "601")
                sw.WriteLine("RiesgoPuesto" + Chr(wchar) + "4")
                sw.WriteLine("TipoJornada" + Chr(wchar) + "Mixta")
                sw.WriteLine("RegistroPatronal" + Chr(wchar) + RTrim(datos(0)))
                sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + a.rs!s1_importe.ToString)
                sw.WriteLine("NumSeguridadSocial" + Chr(wchar) + a.rs!v_imss_rep.ToString)
                sw.WriteLine("NumDiasPagados" + Chr(wchar) + "7")
                sw.WriteLine("NumEmpleado" + Chr(wchar) + a.rs!j1_numtra.ToString)
                sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + "0")
                sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "Semanal")
                If a.rs!g5_plaza = 1 Or a.rs!g5_plaza = 2 Then
                    sw.WriteLine("TipoContrato" + Chr(wchar) + "01")
                Else
                    sw.WriteLine("TipoContrato" + Chr(wchar) + "03")
                End If
                sw.WriteLine("CURP" + Chr(wchar) + a.rs!v_curp_rep.ToString)
                If datos(1) = "Z" Then
                    sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catz)
                Else
                    sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catr)
                End If
                sw.WriteLine("TipoRegimen" + Chr(wchar) + "02")
                sw.WriteLine("FechaFinalPago" + Chr(wchar) + datos(7).ToString)
                sw.WriteLine("FechaInicialPago" + Chr(wchar) + datos(8).ToString)
                sw.WriteLine("Antiguedad" + Chr(wchar) + "P" + a.rs!anti.ToString + "W")
                sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso)
                If datos(1) = "Z" Then
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptoz)
                Else
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptor)
                End If
                If IsDBNull(a.rs!i8_banco) Then
                    sw.WriteLine("Banco" + Chr(wchar) + "021")
                Else
                    Select Case a.rs!i8_banco
                        Case 14
                            sw.WriteLine("Banco" + Chr(wchar) + "012")
                        Case 15
                            sw.WriteLine("Banco" + Chr(wchar) + "002")
                        Case 16
                            sw.WriteLine("Banco" + Chr(wchar) + "014")
                        Case 17
                            sw.WriteLine("Banco" + Chr(wchar) + "044")
                        Case 18
                            sw.WriteLine("Banco" + Chr(wchar) + "021")
                        Case Else
                            sw.WriteLine("Banco" + Chr(wchar) + "021")
                    End Select
                End If
                sw.WriteLine("FechaPago" + Chr(wchar) + datos(6).ToString)
                sw.WriteLine("TipoNomina" + Chr(wchar) + "O")
                If w_tponom = 1 Then
                    sw.WriteLine("Sindicalizado|Sí")
                Else
                    sw.WriteLine("Sindicalizado|No")
                End If
                sw.WriteLine("ClaveEntFed|VER")
                sw.WriteLine("")
                '===== detalle de nomina
                w_per = 1
                w_ded = 1
                w_numtra = a.rs!j1_numtra
                If a.rs!t3_cpto < 400 Then
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
                        sw.WriteLine("TipoPercepcion" + Chr(wchar) + a.ceros(a.rs!t3_seres))
                        sw.WriteLine("Clave" + Chr(wchar) + a.ceros(a.rs!t3_cpto.ToString))
                        sw.WriteLine("Concepto" + Chr(wchar) + a.rs!t3_percep.ToString)
                        If a.rs!t3_exento = 1 Or a.rs!t3_cpto > 400 Then
                            sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                            sw.WriteLine("ImporteExento" + Chr(wchar) + a.rs!t3_importe.ToString)
                        Else
                            sw.WriteLine("ImporteGravado" + Chr(wchar) + a.rs!t3_importe.ToString)
                            sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                        End If
                    End If
                    w_per = w_per + 1
                End If
                sw.WriteLine("")
            Else
                If a.rs!t3_cpto < 400 Then
                    sw.WriteLine("Percepcion" + Chr(wchar) + w_per.ToString)
                    sw.WriteLine("TipoPercepcion" + Chr(wchar) + a.ceros(a.rs!t3_seres))
                    sw.WriteLine("Clave" + Chr(wchar) + a.ceros(a.rs!t3_cpto.ToString))
                    sw.WriteLine("Concepto" + Chr(wchar) + a.rs!t3_percep.ToString)
                    w_per = w_per + 1
                Else
                    If w_ded = 1 Then
                        sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                        sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_ispt + a.rs!t1_descto).ToString)
                        sw.WriteLine("TotalGravado" + Chr(wchar) + "0.00")
                        sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(a.rs!t3_seres))
                        sw.WriteLine("Clave" + Chr(wchar) + a.rs!t3_cpto.ToString)
                        sw.WriteLine("Concepto" + Chr(wchar) + a.rs!t3_deduc.ToString)
                        w_ded = w_ded + 1
                    Else
                        sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                        sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(a.rs!t3_seres))
                        sw.WriteLine("Clave" + Chr(wchar) + a.rs!t3_cpto.ToString)
                        sw.WriteLine("Concepto" + Chr(wchar) + a.rs!t3_deduc.ToString)
                        w_ded = w_ded + 1
                    End If
                End If
                If a.rs!t3_exento = 1 Or a.rs!t3_cpto > 400 Then
                    sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                    sw.WriteLine("ImporteExento" + Chr(wchar) + a.rs!t3_importe.ToString)
                Else
                    sw.WriteLine("ImporteGravado" + Chr(wchar) + a.rs!t3_importe.ToString)
                    sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                End If
                sw.WriteLine("")
            End If
            '===================== INICIA PROCESO DE PERCEPCIONES Y DEDUCCIONES
        End While
        sw.Close()
        file = Nothing
        sw = Nothing
        MsgBox("Inicio: " + w_tiempo + ", proceso Terminado: " + Mid(TimeOfDay.ToString, 12, 8))
    End Sub

    Private Sub CargarSemanaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarSemanaToolStripMenuItem.Click
        Dim b As New Clase
        Dim wsem, wser, wsemsub
        a.qr("select valor from parametros where tipo=1 and clave='semsubini'", 1)
        a.rs.Read()
        wsemsub = a.rs!valor
        wsem = Val(lbl_sem_activa.Text)
        MsgBox("Semana inicial ajuste de subsidio: " + wsemsub.ToString + Chr(13) + Chr(13) + "Semana carga: " + wsem.ToString, MsgBoxStyle.YesNo)
        a.qr("truncate table anom401b", 2)
        a.qr("insert into anom401b select j1_tpo_emision,j1_tponom,j1_numtra,j1_depto,j1_cero,j1_cpto,j1_fecha," +
            " j1_nomina,j1_semana,j1_importe,j1_hrs_dom,j1_catego,j1_turno,j1_plaza from anom401 where j1_semana=" + wsem.ToString, 2)
        a.qr("insert into anom401b select j1_tpo_emision,j1_tponom,j1_numtra,j1_depto,j1_cero,316,j1_fecha," +
            " j1_nomina,j1_semana,j1_importe,j1_hrs_dom,j1_catego,j1_turno,j1_plaza from anom401 where j1_cpto in (557,498) and j1_semana=" + wsem.ToString, 2)
        a.qr("insert into anom401b select j1_tpo_emision,j1_tponom,j1_numtra,j1_depto,j1_cero,604,j1_fecha," +
            " j1_nomina,j1_semana,j1_importe,j1_hrs_dom,j1_catego,j1_turno,j1_plaza from anom401 where j1_cpto in (557,498) and j1_semana=" + wsem.ToString, 2)
        a.qr("insert into anom401b select j1_tpo_emision,j1_tponom,j1_numtra,j1_depto,j1_cero,315,j1_fecha," +
            " j1_nomina,j1_semana,j1_importe,j1_hrs_dom,j1_catego,j1_turno,j1_plaza from anom401 where j1_cpto in (498) and j1_semana=" + wsem.ToString, 2)
        a.qr("insert into anom401b select j1_tpo_emision,j1_tponom,j1_numtra,j1_depto,j1_cero,557,j1_fecha," +
            " j1_nomina,j1_semana,j1_importe,j1_hrs_dom,j1_catego,j1_turno,j1_plaza from anom401 where j1_cpto in (498) and j1_semana=" + wsem.ToString, 2)
        a.qr("ajustesub " + wsem.ToString + "," + wsemsub.ToString, 2)
        '//////// ELIMINAR IMPUESTO Y SUBSIDIO
        If MsgBox("TIMBRADO", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("select * from anom401b where j1_tpo_emision<8 and j1_importe!=0 and j1_cpto=411", 1)
            Dim ispt = 0.0
            While a.rs.Read
                b.qr("select * from anom401b where j1_cpto=403 and j1_tpo_emision<8 and j1_tponom=" + a.rs!j1_tponom.ToString + " and j1_numtra=" + a.rs!j1_numtra.ToString + " and j1_nomina=1", 1)
                If b.rs.HasRows Then
                    b.rs.Read()
                    If IsDBNull(b.rs!j1_importe) Then
                        ispt = 0
                    Else
                        ispt = b.rs!j1_importe
                    End If
                Else
                    MsgBox("Revisar error, persona con subsidio sin impuesto: " + a.rs!j1_numtra.ToString)
                End If
                b.qr("update anom401b set j1_tpo_emision=10 where j1_cpto=403 and j1_tpo_emision<8 and j1_tponom=" + a.rs!j1_tponom.ToString + " and j1_numtra=" + a.rs!j1_numtra.ToString + " and j1_nomina=1", 2)
                If ispt > a.rs!j1_importe * -1 Then
                    b.qr("insert into anom401b values(2," + a.rs!j1_tponom.ToString + "," + a.rs!j1_numtra.ToString +
                         ",13000,0,403,getdate(),1," + a.rs!j1_semana.ToString + "," + (ispt + a.rs!j1_importe).ToString + ",1,0,1,1)", 2)
                End If
            End While
        End If
        a.qr("update anom304 set i4_ano_sem=" + wsem.ToString +
        ",i4_inisem=(select h1_fecha_ini from anom201 where h1_semana=" + wsem.ToString +
        "),i4_finsem=(select h1_fecha_fin from anom201 where h1_semana=" + wsem.ToString + ")", 2)
        a.qr("inserta_ajuste404 " + wsem.ToString, 2)
        a.qr("delete from anom401b where j1_cpto=404 and j1_catego=0 and j1_plaza=0", 2)
        a.qr("cargapago " + wsem.ToString, 2)
        a.qr("select * from pagos where j1_importe<0", 1)
        If a.rs.HasRows Then
            MsgBox("Se encontraron pagos negativos, se realizara la correcion, volver a cargar semana", MsgBoxStyle.Critical)
            a.qr("exec pagos_negativos " + wsem.ToString, 2)
        Else
            MsgBox("Carga realizada con exito", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub CargarTimbradoErroneoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarTimbradoErroneoToolStripMenuItem1.Click
        Dim b As New xml_liquida
        fbd_carpeta.ShowDialog()
        Dim wtponom = 1
        Dim di As New IO.DirectoryInfo(fbd_carpeta.SelectedPath)
        While True
            wtponom = InputBox("Tipo de Nomina: (1) Sindicalizado  (2) Confianza")
            If Val(wtponom) = 2 Or Val(wtponom) = 1 Then
                Exit While
            End If
        End While
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.pdf")
        Dim dra As IO.FileInfo
        Dim query As String
        If MsgBox("Borrar Tabla?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("truncate table sat_nomina", 2)
        End If
        For Each dra In diar1
            query = "insert into sat_nomina values(1," + Mid(dra.ToString, 23, 7) + ",getdate(),0,0," + wtponom.ToString + ",0,0,'" + Mid(dra.ToString, 31, 36) + "',0)"
            a.qr(query, 2)
        Next
        MsgBox("Carga Realizada")

    End Sub

    Private Sub TxtOtroProcesoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOtroProcesoToolStripMenuItem.Click
        '=================== timbrado 3.3 =========================
        Dim file As System.IO.FileStream
        Dim wchar As Integer = Asc("|")
        Dim b As New Clase
        Dim fic As String
        Dim folio = 1
        Dim w_tponom = 1
        Dim w_nomina = 1
        Dim w_numtra = 1
        Dim w_imppago = 0.0
        Dim w_per = 1
        Dim w_ded = 1
        Dim w_otp = 1
        Dim w_query = ""
        Dim w_tiempo = Mid(TimeOfDay.ToString, 12, 8)
        Dim datos(13) As String
        While True
            w_tponom = Val(InputBox("Tipo de Nomina: (1) Nomina Obreros  (2) Nomina Empleado  (3) Premio Obreros"))
            If w_tponom > 0 And w_tponom < 4 Then
                Exit While
            End If
        End While
        If w_tponom < 3 Then
            a.qr("select j2_saldos from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
            a.rs.Read()
            If a.rs!j2_saldos <> "S" Then
                MsgBox("Proceso de nomina no terminado,revisar ")
                Exit Sub
            End If
        Else
            a.qr("select j2_premio from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
            a.rs.Read()
            If a.rs!j2_premio <> "4" Then
                MsgBox("Proceso de premio no terminado,revisar ")
                Exit Sub
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        If w_tponom = 1 Then
            w_query = " and v_relab=3 and j1_tponom=1 and j1_nomina=1"
        Else
            If w_tponom = 2 Then
                w_query = " and v_relab=4 and j1_tponom=2 and j1_nomina=1"
            Else
                w_nomina = 2
                w_tponom = 1
            End If
        End If
        '==== temp1
        a.qr("timbrado " + w_nomina.ToString + "," + w_tponom.ToString + ",1,'N'", 2)
        '===== temp2
        a.qr("catdepto " + w_nomina.ToString + "," + w_tponom.ToString + ",1,'N'", 2)
        '===== temp3
        a.qr("cargadetalle " + w_nomina.ToString + "," + w_tponom.ToString + ",1,'N'", 2)
        '===== CARGA DATOS GENERALES
        a.qr("select g1_reg_patron regimss,i4_ciclo ciclo,i4_ano_sem semana,j2_serie serie,g1_nombre,g1_rfc,replace(convert(char(20),h1_fecha_fin+4,111),'/','-') pago," +
             " replace(convert(char(20),h1_fecha_ini,111),'/','-') ini,replace(convert(char(20),h1_fecha_fin,111),'/','-') fin,g1_cp,g1_sdiemp,g1_sdiobrr,g1_sdiobrz" +
             " from anom304,anom402,anom101,anom201 " +
             " where i4_ano_sem=j2_semana" +
             " and j2_semana=h1_semana", 1)
        a.rs.Read()
        datos(0) = a.rs!regimss
        datos(1) = a.rs!ciclo
        datos(2) = a.rs!semana.ToString
        datos(3) = a.rs!serie
        datos(4) = a.rs!g1_nombre
        datos(5) = a.rs!g1_rfc
        datos(6) = a.rs!pago
        datos(7) = a.rs!fin
        datos(8) = a.rs!ini
        datos(9) = a.rs!g1_cp.ToString
        datos(10) = a.rs!g1_sdiobrz + 1
        datos(11) = a.rs!g1_sdiobrr + 1
        datos(12) = a.rs!g1_sdiemp + 1
        If w_tponom = 1 Then
            If w_nomina = 1 Then
                fic = "c:\temp\NOMINA_OBRERO_" + datos(2) + ".txt"
            Else
                fic = "c:\temp\PREMIO_OBRERO_" + datos(2) + ".txt"
            End If

        Else
            fic = "c:\temp\NOMINA_EMPLEADO_" + datos(2) + ".txt"
        End If
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select count(*) num from temp1", 1)
        a.rs.Read()
        'MsgBox("Registros a procesar: " + a.rs!num.ToString)
        '===== LISTADO GENERAL DE TIMBRADO
        w_numtra = 1
        w_per = 1
        w_ded = 1
        w_otp = 1
        a.qr("select * from listanom,temp1,temp2 left join (aing108 left join nombancos on i8_banco=cvebanco) on i8_relab=t2_tponom+2 and t2_numtra=i8_clave" +
            " where j1_nomina = " + w_nomina.ToString +
            " and j1_tponom=t1_tponom" +
            " and j1_numtra=t1_numtra" +
            " and j1_tponom=t2_tponom" +
            " and j1_numtra=t2_numtra" +
            " order by 1,2,3", 1)
        While a.rs.Read
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
                b.qr("select * from sat_nomina where n1_tponom=" + a.rs!j1_tponom.ToString + " and n1_numtra=" + a.rs!j1_numtra.ToString + " and n1_semana=" + datos(2), 1)
                If b.rs.HasRows Then
                    b.rs.Read()
                    sw.WriteLine("TipoRelacion" + Chr(wchar) + "04")
                    sw.WriteLine("UUID" + Chr(wchar) + b.rs!n1_uuid)
                End If
                sw.WriteLine("ERFC" + Chr(wchar) + RTrim(datos(5)))
                sw.WriteLine("ENombre" + Chr(wchar) + RTrim(datos(4)))
                sw.WriteLine("RRFC" + Chr(wchar) + a.rs!v_rfc_rep)
                sw.WriteLine("RNombre" + Chr(wchar) + Replace(a.rs!v_nombrerep, "Ñ", "N"))
                sw.WriteLine("Cant|1")
                sw.WriteLine("UM|ACT")
                sw.WriteLine("Desc" + Chr(wchar) + "Pago de nómina")
                If a.rs!t1_ispt >= 0 Then
                    sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio - a.rs!azucar).ToString)
                    If a.rs!t1_ispt >= 0 And a.rs!t1_subsidio > 0 Then
                        sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio + a.rs!israfavor + 0.0 - a.rs!ajustesub).ToString)
                    Else
                        sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_subsidio + a.rs!israfavor - a.rs!ajustesub).ToString)
                    End If
                    sw.WriteLine("TotImpR" + Chr(wchar) + (a.rs!t1_ispt + a.rs!adeudo).ToString)
                    sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                    If a.rs!t1_ispt >= 0 And a.rs!t1_subsidio > 0 Then
                        w_imppago = a.rs!t1_neto - a.rs!t1_subsidio - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor - a.rs!adeudo + 0.0 + a.rs!ajustesub
                        sw.WriteLine("Importe" + Chr(wchar) + w_imppago.ToString)
                    Else
                        w_imppago = a.rs!t1_neto - a.rs!t1_subsidio - a.rs!t1_descto - a.rs!t1_ispt + a.rs!israfavor - a.rs!adeudo - a.rs!ajustesub
                        sw.WriteLine("Importe" + Chr(wchar) + w_imppago.ToString)
                    End If
                    sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                    sw.WriteLine("MonImpR" + Chr(wchar) + (a.rs!t1_ispt + +a.rs!adeudo).ToString)
                    sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(w_imppago).ToString)
                Else
                    If a.rs!t1_subsidio = 0 Then
                        sw.WriteLine("PrecMX" + Chr(wchar) + a.rs!t1_neto.ToString)
                        sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto + a.rs!israfavor + a.rs!ajustesub).ToString)
                        sw.WriteLine("TotImpR" + Chr(wchar) + (a.rs!t1_ispt + a.rs!adeudo).ToString)
                        sw.WriteLine("TotCargDesc" + Chr(wchar) + a.rs!t1_descto.ToString)
                        sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - a.rs!t1_ispt - a.rs!t1_descto + a.rs!israfavor + a.rs!ajustesub - a.rs!adeudo).ToString)
                        sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                        sw.WriteLine("MonImpR" + Chr(wchar) + (a.rs!t1_ispt + +a.rs!adeudo).ToString)
                        sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - a.rs!t1_ispt - a.rs!t1_descto + a.rs!israfavor + a.rs!ajustesub - a.rs!adeudo).ToString)
                    Else
                        If a.rs!azucar > 0 Then
                            sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) + a.rs!t1_ispt - a.rs!azucar).ToString)
                            sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) + a.rs!israfavor + a.rs!ajustesub).ToString)
                            sw.WriteLine("TotImpR" + Chr(wchar) + a.rs!adeudo.ToString)
                            sw.WriteLine("TotCargDesc" + Chr(wchar) + (a.rs!t1_descto).ToString)
                            sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) - a.rs!t1_descto + a.rs!israfavor + a.rs!ajustesub - a.rs!adeudo).ToString)
                            sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                            sw.WriteLine("MonImpR" + Chr(wchar) + a.rs!adeudo.ToString)
                            sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) - a.rs!t1_descto + a.rs!israfavor + a.rs!ajustesub - a.rs!adeudo).ToString)
                        Else
                            sw.WriteLine("PrecMX" + Chr(wchar) + (a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) + a.rs!t1_ispt + a.rs!azucar).ToString)
                            sw.WriteLine("TotNeto" + Chr(wchar) + (a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) + a.rs!israfavor + a.rs!ajustesub).ToString)
                            sw.WriteLine("TotImpR" + Chr(wchar) + a.rs!adeudo.ToString)
                            sw.WriteLine("TotCargDesc" + Chr(wchar) + (a.rs!t1_descto).ToString)
                            sw.WriteLine("Importe" + Chr(wchar) + (a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) - a.rs!t1_descto + a.rs!israfavor + a.rs!ajustesub - a.rs!adeudo).ToString)
                            sw.WriteLine("TipImpR" + Chr(wchar) + "ISR")
                            sw.WriteLine("MonImpR" + Chr(wchar) + a.rs!adeudo.ToString)
                            sw.WriteLine("ImpLetra" + Chr(wchar) + a.Num_texto(a.rs!t1_neto - (a.rs!t1_subsidio + a.rs!t1_ispt) - a.rs!t1_descto + a.rs!israfavor + a.rs!ajustesub - a.rs!adeudo).ToString)
                        End If

                    End If
                End If
                sw.WriteLine("Regimen" + Chr(wchar) + "601")
                sw.WriteLine("RiesgoPuesto" + Chr(wchar) + "4")
                sw.WriteLine("TipoJornada" + Chr(wchar) + "03")
                sw.WriteLine("RegistroPatronal" + Chr(wchar) + RTrim(datos(0)))
                If datos(1) = "Z" Then
                    If w_tponom = 1 Then
                        sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + Math.Round(a.rs!sdi * datos(10), 2).ToString)
                        sw.WriteLine("FactorIntegracion" + Chr(wchar) + datos(10).ToString)
                    Else
                        sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + Math.Round(a.rs!sdi * datos(12), 2).ToString)
                        sw.WriteLine("FactorIntegracion" + Chr(wchar) + datos(12).ToString)
                    End If
                Else
                    If w_tponom = 1 Then
                        sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + Math.Round(a.rs!sdi * datos(11), 2).ToString)
                        sw.WriteLine("FactorIntegracion" + Chr(wchar) + datos(11).ToString)
                    Else
                        sw.WriteLine("SalarioDiarioIntegrado" + Chr(wchar) + Math.Round(a.rs!sdi * datos(12), 2).ToString)
                        sw.WriteLine("FactorIntegracion" + Chr(wchar) + datos(12).ToString)
                    End If
                End If
                sw.WriteLine("NumSeguridadSocial" + Chr(wchar) + a.rs!v_imss_rep.ToString)
                If a.rs!g5_plaza = 3 Then
                    sw.WriteLine("NumDiasPagados" + Chr(wchar) + a.rs!antiguedad.ToString + ".000")
                Else
                    sw.WriteLine("NumDiasPagados" + Chr(wchar) + "7.000")
                End If
                sw.WriteLine("NumEmpleado" + Chr(wchar) + a.rs!j1_numtra.ToString)
                sw.WriteLine("SalarioBaseCotApor" + Chr(wchar) + a.rs!g5_sasegi.ToString)
                sw.WriteLine("PeriodicidadPago" + Chr(wchar) + "02")
                If IsDBNull(a.rs!i8_clabe) Or IsDBNull(a.rs!i8_banco) Then
                Else
                    If Len(a.rs!i8_clabe) < 18 Then
                        sw.WriteLine("Banco" + Chr(wchar) + a.rs!codigo)
                    End If
                    sw.WriteLine("CuentaBancaria" + Chr(wchar) + a.rs!i8_clabe)
                End If
                If w_tponom = 1 Then
                    sw.WriteLine("Sindicalizado|Si")
                Else
                    sw.WriteLine("Sindicalizado|No")
                End If
                If a.rs!g5_plaza = 1 Or a.rs!g5_plaza = 2 Then
                    sw.WriteLine("TipoContrato" + Chr(wchar) + "01")
                Else
                    sw.WriteLine("TipoContrato" + Chr(wchar) + "03")
                End If
                sw.WriteLine("CURP" + Chr(wchar) + a.rs!v_curp_rep.ToString)
                If datos(1) = "Z" Then
                    sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catz)
                Else
                    sw.WriteLine("Puesto" + Chr(wchar) + a.rs!t2_catr)
                End If
                sw.WriteLine("TipoRegimen" + Chr(wchar) + "02")
                sw.WriteLine("FechaFinalPago" + Chr(wchar) + datos(7).ToString)
                sw.WriteLine("FechaInicialPago" + Chr(wchar) + datos(8).ToString)
                If a.rs!g5_plaza = 1 Or a.rs!g5_plaza = 2 Then
                    sw.WriteLine("Antiguedad" + Chr(wchar) + a.rs!anti.ToString)
                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + a.rs!ingreso)
                Else
                    sw.WriteLine("Antiguedad" + Chr(wchar) + "P1W")
                    sw.WriteLine("FechaInicioRelLaboral" + Chr(wchar) + datos(8).ToString)
                End If
                If datos(1) = "Z" Then
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptoz)
                Else
                    sw.WriteLine("Departamento" + Chr(wchar) + a.rs!t2_deptor)
                End If
                sw.WriteLine("FechaPago" + Chr(wchar) + datos(6).ToString)
                sw.WriteLine("TipoNomina" + Chr(wchar) + "O")
                sw.WriteLine("ClaveEntFed|VER")
                sw.WriteLine("")
                '===================== INICIA PROCESO DE PERCEPCIONES Y DEDUCCIONES
                w_per = 1
                w_ded = 1
                w_otp = 1
                w_numtra = a.rs!j1_numtra
                Dim ispt = 0.0
                Dim incapacidad = 0.0
                Dim defuncion = 0.0
                Dim separacion = 0
                If True Then
                    b.qr("select * from anom401b where j1_tpo_emision=10 and j1_importe!=0 and j1_cpto=403 and j1_tponom=" + a.rs!t2_tponom.ToString + " and j1_numtra=" + a.rs!t2_numtra.ToString, 1)
                    If b.rs.HasRows Then
                        b.rs.Read()
                        ispt = b.rs!j1_importe
                    End If
                End If
                b.qr("select * from temp3 left join anom114 on (t3_tponom=g14_tponom and g14_numtra=t3_numtra and g14_cpto=440) where t3_tponom=" + a.rs!t2_tponom.ToString + " and t3_numtra=" + a.rs!t2_numtra.ToString + " order by t3_concepto,t3_cpto", 1)
                While b.rs.Read
                    If b.rs!t3_cpto = 106 Then
                        incapacidad = b.rs!t3_importe
                    End If
                    If b.rs!t3_cpto = 131 Or b.rs!t3_cpto = 119 Then
                        defuncion = b.rs!t3_importe
                    End If
                    Select Case b.rs!t3_concepto
                        Case 1
                            'PERCEPCIONES
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
                                w_per = w_per + 1
                            Else
                                sw.WriteLine("Percepcion" + Chr(wchar) + w_per.ToString)
                                sw.WriteLine("TipoPercepcion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                sw.WriteLine("Clave" + Chr(wchar) + a.ceros(b.rs!t3_cpto.ToString))
                                sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_percep.ToString)
                                w_per = w_per + 1
                            End If
                            If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                            Else
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                            End If
                            If w_per = 1 Then

                            End If
                        Case 3

                        Case 4
                            'DEDUCCIONES

                            If w_ded = 1 Then
                                sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                If a.rs!t1_ispt < 0 Then
                                    sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_descto + a.rs!adeudo).ToString)
                                Else
                                    sw.WriteLine("TotalExento" + Chr(wchar) + (a.rs!t1_ispt + a.rs!t1_descto + a.rs!adeudo).ToString)
                                End If
                                sw.WriteLine("TotalGravado" + Chr(wchar) + "0.00")
                                sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                w_ded = w_ded + 1
                            Else
                                sw.WriteLine("Deduccion" + Chr(wchar) + w_ded.ToString)
                                sw.WriteLine("TipoDeduccion" + Chr(wchar) + a.ceros(b.rs!t3_seres))
                                sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                w_ded = w_ded + 1
                            End If
                            If b.rs!t3_exento = 1 Or b.rs!t3_cpto > 400 Then
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + "0.00")
                                sw.WriteLine("ImporteExento" + Chr(wchar) + b.rs!t3_importe.ToString)
                            Else
                                sw.WriteLine("ImporteGravado" + Chr(wchar) + b.rs!t3_importe.ToString)
                                sw.WriteLine("ImporteExento" + Chr(wchar) + "0.00")
                            End If

                        Case 5
                            'CREDITO AL SALARIO 411, 440,407,408,199
                            Select Case b.rs!t3_cpto
                                Case 199
                                    If b.rs!t3_importe > 0 Then
                                        sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                        If w_otp = 1 Then
                                            If a.rs!t1_ispt < 0 And a.rs!t1_subsidio > 0 And a.rs!azucar > 0 Then
                                                sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + Math.Round(a.rs!azucar + a.rs!israfavor + (a.rs!t1_ispt * -1), 2).ToString)
                                            Else
                                                sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + Math.Round(a.rs!azucar + a.rs!israfavor, 2).ToString)
                                            End If
                                            w_otp += 1
                                        End If
                                        sw.WriteLine("TipoOtroPago" + Chr(wchar) + "999")
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                        sw.WriteLine("ImporteOtroPago" + Chr(wchar) + Math.Round(b.rs!t3_importe, 2).ToString)
                                    End If
                                Case 407
                                    If b.rs!t3_importe < 0 Then
                                        sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                        If w_otp = 1 Then
                                            sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + Math.Round((a.rs!ajustesub * -1) + a.rs!israfavor + a.rs!azucar, 2).ToString)
                                            w_otp += 1
                                        End If
                                        sw.WriteLine("TipoOtroPago" + Chr(wchar) + "007")
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                        sw.WriteLine("ImporteOtroPago" + Chr(wchar) + Math.Round(b.rs!t3_importe * -1, 2).ToString)
                                    End If
                                Case 408
                                    If b.rs!t3_importe < 0 Then
                                        sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                        If w_otp = 1 Then
                                            sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + Math.Round(b.rs!t3_importe * -1, 2).ToString)
                                            w_otp += 1
                                        End If
                                        sw.WriteLine("TipoOtroPago" + Chr(wchar) + "008")
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                        sw.WriteLine("ImporteOtroPago" + Chr(wchar) + Math.Round(b.rs!t3_importe * -1, 2).ToString)
                                    End If
                                Case 411
                                    If ((b.rs!t3_importe * -1) - (ispt)) > 0 Then
                                        sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                        If w_otp = 1 Then
                                            If (a.rs!t1_ispt + a.rs!t1_subsidio) > (b.rs!t3_importe * -1) Then
                                                sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + "0")
                                            Else
                                                sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + Math.Round((b.rs!t3_importe * -1) - (ispt) + a.rs!israfavor, 2).ToString)
                                            End If
                                        End If
                                        sw.WriteLine("TipoOtroPago" + Chr(wchar) + "002")
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                        If (a.rs!t1_ispt + a.rs!t1_subsidio - a.rs!israfavor) > (b.rs!t3_importe * -1) Then
                                            sw.WriteLine("ImporteOtroPago" + Chr(wchar) + "0")
                                        Else
                                            sw.WriteLine("ImporteOtroPago" + Chr(wchar) + Math.Round((b.rs!t3_importe * -1) - (ispt), 2).ToString)
                                        End If
                                        sw.WriteLine("SubsidioCausado" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                        w_otp += 1
                                    Else
                                        If True Then
                                            sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                            If w_otp = 1 Then
                                                sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + Math.Round(a.rs!israfavor + 0.0, 2).ToString)
                                            End If
                                            sw.WriteLine("TipoOtroPago" + Chr(wchar) + "002")
                                            sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                            sw.WriteLine("Concepto" + Chr(wchar) + "SUBSIDIO PARA EL EMPLEO EFECTIVAMENTE PAGADO AL TRABAJADOR")
                                            sw.WriteLine("ImporteOtroPago" + Chr(wchar) + "0.00")
                                            sw.WriteLine("SubsidioCausado" + Chr(wchar) + (b.rs!t3_importe * -1).ToString)
                                            w_otp = w_otp + 1
                                        End If
                                    End If
                                Case 440
                                    If (b.rs!t3_importe * -1) > 0 Then
                                        sw.WriteLine("OtroPago" + Chr(wchar) + w_otp.ToString)
                                        If w_otp = 1 Then
                                            sw.WriteLine("TotalOtrosPagos" + Chr(wchar) + Math.Round(b.rs!t3_importe * -1, 2).ToString)
                                        End If
                                        sw.WriteLine("TipoOtroPago" + Chr(wchar) + "004")
                                        sw.WriteLine("Clave" + Chr(wchar) + b.rs!t3_cpto.ToString)
                                        sw.WriteLine("Concepto" + Chr(wchar) + b.rs!t3_deduc.ToString)
                                        sw.WriteLine("ImporteOtroPago" + Chr(wchar) + Math.Round(a.rs!israfavor, 2).ToString)
                                        sw.WriteLine("SaldoAFavor" + Chr(wchar) + Math.Round(b.rs!g14_saldo - b.rs!t3_importe, 2).ToString)
                                        sw.WriteLine("Anio" + Chr(wchar) + "2020")
                                        sw.WriteLine("RemanenteSalFav|" + Math.Round(b.rs!g14_saldo, 2).ToString)
                                    End If
                            End Select
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
                If defuncion > 0 Then
                    sw.WriteLine("JubilacionPensionRetiro|1")
                    sw.WriteLine("TotalUnaExhibicion|" + Format(defuncion, "#####0.00"))
                    sw.WriteLine("IngresoAcumulable|0")
                    sw.WriteLine("IngresoNoAcumulable|0")
                    sw.WriteLine("")
                    defuncion = 0
                End If
                If separacion > 0 Then
                    'SEPARACION
                    sw.WriteLine("SeparacionIndemnizacion|1")
                    sw.WriteLine("TotalPagado|")
                    sw.WriteLine("NumAnosServicio|")
                    sw.WriteLine("UltimoSueldoMensOrd|")
                    sw.WriteLine("IngresoAcumulable|0")
                    sw.WriteLine("IngresoNoAcumulable|0")
                End If
            End If
            '===================== TERMINA PROCESO DE PERCEPCIONES Y DEDUCCIONES
        End While
        sw.Close()
        file = Nothing
        sw = Nothing
        Me.Cursor = Cursors.Default
        MsgBox("Inicio: " + w_tiempo + ", proceso Terminado, Version 3.3: " + Mid(TimeOfDay.ToString, 12, 8))
    End Sub

    Private Sub RevisionTimbradoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisionTimbradoToolStripMenuItem.Click
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
            a.qr("select j1_numtra,sum(case when j1_cpto=403 then j1_importe else 0 end) ispt,sum(case when j1_cpto=411 then j1_importe else 0 end) subsidio from anom401" +
                " where j1_semana = " + a.rs!sem.ToString +
                " and j1_tponom=" + wtponom.ToString +
                " and j1_cpto in (403,411)" +
                " and j1_tpo_emision<8" +
                " group by j1_numtra" +
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

    Private Sub ValidacionRFCSATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidacionRFCSATToolStripMenuItem.Click
        Dim tponom = 1
        Dim num = 1
        Dim rfc = ""
        While True
            tponom = InputBox("Tipo de nomina, (1) Obrero   (2) Empleado")
            If Val(tponom) > 0 And Val(tponom) < 3 Then
                Exit While
            End If
        End While
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\valida_" + tponom.ToString + ".txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr(" select  distinct substring(v_rfc_rep,1,13) rfc from anom401,vacre102" +
             " where j1_semana > 201751" +
             " and j1_tpo_emision<8" +
             " and j1_tponom=" + tponom.ToString +
             " and j1_cpto<400" +
             " and v_rfc_rep in (select rfc from rfc_validados where correcto='V')" +
             " and j1_numtra=v_clave " +
             " and v_relab=j1_tponom+2" +
             " group by v_rfc_rep" +
             " order by 1", 1)
        While a.rs.Read
            For x = 1 To 13
                If (Asc(Mid(a.rs!rfc, 1, 1)) >= 65 And Asc(Mid(a.rs!rfc, 1, 1)) <= 90) Or (Asc(Mid(a.rs!rfc, 1, 1)) >= 48 And Asc(Mid(a.rs!rfc, 1, 1)) <= 57) Then
                    rfc = rfc + Mid(a.rs!rfc, x, 1)
                End If
            Next
            sw.WriteLine(num.ToString + "|" + rfc + "|")
            rfc = ""
            num = num + 1
        End While
        MsgBox("Archivo creado: c:\temp\valida_" + tponom.ToString + ".txt")
        sw.Close()
    End Sub

    Private Sub CargarValidacionRFCSATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarValidacionRFCSATToolStripMenuItem.Click
        ofd_leer_timbrado.ShowDialog()
        Dim objReader As New StreamReader(ofd_leer_timbrado.FileName)
        Dim ln As String = ""
        Do
            ln = objReader.ReadLine
            a.qr("select * from rfc_validados where rfc='" + Mid(ln, InStr(ln, "|") + 1, 13) + "'", 1)
            If a.rs.HasRows Then
                a.qr("update rfc_validados set correcto='" + Mid(ln, InStr(ln, "|") + 15, 1) + "',fecha=getdate() where rfc='" + Mid(ln, InStr(ln, "|") + 1, 13) + "'", 2)
            Else
                a.qr("insert into rfc_validados values('" + Mid(ln, InStr(ln, "|") + 1, 13) + "',getdate(),'" + Mid(ln, InStr(ln, "|") + 15, 1) + "')", 2)
            End If
        Loop Until ln Is Nothing
        a.qr("delete from rfc_validados where len(rfc)=0", 2)
        objReader.Close()
        MsgBox("Proceso terminado")
    End Sub

    Private Sub ActualizarSaldosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SaldoDeRetencionesPorConceptoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldoDeRetencionesPorConceptoToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\saldo114cpto.txt"
        Dim wcpto = 0
        Dim wtponom = 1
        Dim wcuorec = 0
        Dim wsaldo = 0
        Dim wtcuorec = 0
        Dim wtsaldo = 0
        While True
            wcpto = InputBox("Concepto de Retención")
            If Val(wcpto) = 0 Then
                Exit While
            Else
                a.qr("select * from anom104 where g4_cpto=" + wcpto.ToString, 1)
                If a.rs.HasRows Then
                    Exit While
                End If
            End If
        End While
        file = System.IO.File.Create(fic)
        file.Close()
        a.qr("SELECT G1_NOMBRE,GETDATE() fec FROM ANOM101", 1)
        a.rs.Read()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("                   " + a.rs!g1_nombre + "           " + a.rs!fec.ToString)
        sw.WriteLine("                            REPORTE DE SALDOS DE RETENCION ANOM114")
        sw.WriteLine("")
        sw.WriteLine("==========================================================================================================")
        sw.WriteLine(" TPONOM  NUMTRA       NOMBRE                          SALDO ANTERIOR  DESCUENTO  SALDO ACTUAL    CUOTA")
        sw.WriteLine("==========================================================================================================")
        a.qr("select g14_cpto,g4_nombre,g14_tponom,g14_numtra,v_nombrerep,g14_saldo+g14_cuorec,g14_cuorec,g14_saldo,g14_cuota " +
             " from anom114 left join vacre102 on (v_clave=g14_numtra and v_relab=g14_tponom+2),anom104" +
            " where (g14_cuorec > 0 Or g14_saldo > 0)" +
            " and g14_cpto=" + wcpto.ToString +
            " and g14_cpto=g4_cpto" +
            " order by 1,3,4", 1)
        While a.rs.Read
            sw.WriteLine("  " + a.rs!g14_tponom.ToString + "      " +
                         String.Format("{0,-8}", a.rs!g14_numtra.ToString) +
                         String.Format("{0,-40}", a.rs!v_nombrerep) +
                         String.Format("{0,12:N2}", (a.rs!g14_saldo + a.rs!g14_cuorec)) +
                         String.Format("{0,12:N2}", a.rs!g14_cuorec) +
                         String.Format("{0,12:N2}", a.rs!g14_saldo) +
                         String.Format("{0,12:N2}", a.rs!g14_cuota))
            If a.rs!g14_tponom <> wtponom Then
                sw.WriteLine("")
                sw.WriteLine("                              SUBTOTAL TIPO DE NOMINA    " +
                         String.Format("{0,12:N2}", (wsaldo + wcuorec)) +
                         String.Format("{0,12:N2}", wcuorec) +
                         String.Format("{0,12:N2}", wsaldo))
                sw.WriteLine("")
                wsaldo = 0
                wcuorec = 0
            Else
                wsaldo += a.rs!g14_saldo
                wtsaldo += a.rs!g14_saldo
                wcuorec += a.rs!g14_cuorec
                wtcuorec += a.rs!g14_cuorec
            End If
            wtponom = a.rs!g14_tponom
        End While
        sw.WriteLine("")
        sw.WriteLine("                              SUBTOTAL TIPO DE NOMINA    " +
                 String.Format("{0,12:N0}", (wsaldo + wcuorec)) +
                 String.Format("{0,12:N0}", wcuorec) +
                 String.Format("{0,12:N0}", wsaldo))
        sw.WriteLine("")
        sw.WriteLine("                                        TOTAL GENERAL    " +
                 String.Format("{0,12:N0}", (wtsaldo + wtcuorec)) +
                 String.Format("{0,12:N0}", wtcuorec) +
                 String.Format("{0,12:N0}", wtsaldo))
        sw.Close()
        Process.Start("c:\temp\saldo114cpto.txt")
    End Sub

    Private Sub ActualizarSBCAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarSBCAToolStripMenuItem.Click
        Dim obj As StreamReader
        Dim cad, ban As String
        Dim wnumtra As Integer
        Dim wtponom As Integer
        Dim wsdi As Double
        Dim wsem = InputBox("Semana")
        If ofd_leer_timbrado.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            obj = New StreamReader(ofd_leer_timbrado.FileName)
            While obj.Peek() >= 0
                wtponom = 0
                cad = obj.ReadLine
                ban = "SalarioDiarioIntegrado|"
                If InStr(cad, ban) Then
                    wsdi = Mid(cad, Len(ban) + 1, Len(cad) - Len(ban))
                End If
                ban = "NumEmpleado|"
                If InStr(cad, ban) Then
                    wnumtra = Mid(cad, Len(ban) + 1, Len(cad) - Len(ban))
                End If
                ban = "TipoContrato|C"
                If InStr(cad, ban) Then
                    wtponom = 2
                End If
                ban = "TipoContrato|S"
                If InStr(cad, ban) Then
                    wtponom = 1
                End If
                If wtponom > 0 Then
                    a.qr("insert into sdi values(" + wsem.ToString + "," + wtponom.ToString + "," + wnumtra.ToString + "," + wsdi.ToString + ")", 2)
                    wtponom = 0
                End If
            End While
            obj.Close()
        End If
    End Sub

    Private Sub RespaldoSBCAYSDIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RespaldoSBCAYSDIToolStripMenuItem.Click
        Dim archivo As FileStream
        Dim nombre As String
        Dim sw As StreamWriter
        If sfd_archivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            nombre = sfd_archivo.FileName
            nombre += ".txt"
            archivo = File.Create(nombre)
            archivo.Close()
            sw = New StreamWriter(nombre)
            a.qr("select g5_tponom,g5_numtra,g5_sasegi,g5_sasegb from anom105", 1)
            While a.rs.Read
                sw.WriteLine(a.rs.Item(0).ToString + Chr(9) + a.rs.Item(1).ToString + Chr(9) + a.rs.Item(2).ToString + Chr(9) + a.rs.Item(3).ToString + Chr(9))
            End While
            sw.Close()
            MsgBox("Respaldo Terminado")
        End If
    End Sub
    Private Sub carga_asis()
        '###### DEFINICION DE VARIABLES
        Dim procesos As New procesos_carga
        Dim ini As Date = Now
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\tiempos_carga.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("Inicio        :" + Now.ToString)
        '###### COMIENZA LECTURA DE PARAMETROS
        procesos.lee_parametros()
        sw.WriteLine("lee param     :" + Now.ToString)
        '##### NOM207_301()
        procesos.nom207_301()
        sw.WriteLine("nom207_301    :" + Now.ToString)
        '##### RELOJ_301()
        procesos.reloj_301()
        sw.WriteLine("reloj 301     :" + Now.ToString)
        '##### DESC_FEST()
        procesos.desc_fest()
        sw.WriteLine("desc_fest     :" + Now.ToString)
        '##### INFONAVIT POR PORCENTAJE 
        procesos.infonavit()
        sw.WriteLine("Infonavit     :" + Now.ToString)
        '##### ADICIONA LOS MOVIMIENTOS EXTRAORDINARIOS
        procesos.detalle_301()
        sw.WriteLine("detalle 301   :" + Now.ToString)
        '##### LUZ GRAVADA
        procesos.luz_y_renta_301()
        sw.WriteLine("luz y renta   :" + Now.ToString)
        '##### SALDOS DEL 114
        'procesos.saldos_301()
        'sw.WriteLine("Saldos 301    :" + Now.ToString)
        sw.Close()
        bar_estado.BackColor = Color.LightGreen
        ToolStripStatusLabel1.Text = "Proceso terminado"
        MsgBox("Termina Carga de Asistencia: " + Chr(13) + "=========================" + Chr(13) + "Inicio: " + ini.ToString + Chr(13) + "Final: " + Now.ToString)
        a.qr("update anom301 set i1_tpotra=1 where i1_numtra in (select distinct h3_numtra from anom203 where h3_semana=" + lbl_sem_activa.Text + " and h3_depto=13022)", 2)
        bar_estado.BackColor = Color.LightGray
        ToolStripStatusLabel1.Text = "Activo"
    End Sub
    Private Sub proceso()
        Dim pro As New procesos_nomina
        Dim w_317a As SqlDataReader
        Dim ini As Date = Now
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\tiempos_proceso.txt"
        bar_estado.BackColor = Color.LightPink
        ToolStripStatusLabel1.Text = "Procesando calculos de nomina"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("update anom105 set g5_sasegi=(select i4_minimo*25 from anom304) where g5_sasegi>(select i4_minimo*25 from anom304)", 2)
        a.qr("select * from anom304", 1)
        a.rs.Read()
        w_317a = a.rs
        sw.WriteLine("Inicio        :" + Now.ToString)
        '##### PRIMA DOMINGO, HORA ALIMENTO, HORAS TURNO, COMZAF, COMREP, ALTURA
        pro.f_nom302()
        sw.WriteLine("Termina nom302:" + Now.ToString)
        '##### SEXTO Y SEPTIMO DIA CPTO 5 Y 6
        pro.f_nom303()
        sw.WriteLine("Termina nom303:" + Now.ToString)
        '##### DESCUENTOS CPTO 486 Y ACUERDO ASAMBLEA CPTO 401
        pro.f_nom304()
        sw.WriteLine("Termina nom304:" + Now.ToString)
        '##### REDISTRUBUYE CONCEPTOS GRAVADO Y EXENTO
        pro.f_nom305()
        sw.WriteLine("Termina nom305:" + Now.ToString)
        '##### DESCUENTOS ISPT 403, IMSS 406, CREDSAL 411, 457 SIND. INDEPEN.
        pro.f_nom306()
        sw.WriteLine("Termina nom306:" + Now.ToString)
        '##### DESCUENTOS DE ANOM114
        pro.f_nom307()
        sw.WriteLine("Termina nom307:" + Now.ToString)
        '##### CARGA 301 A 401
        sw.Close()
        bar_estado.BackColor = Color.LightGreen
        ToolStripStatusLabel1.Text = "Proceso terminado"
        MsgBox("Termina Calculo de Nomina: " + Chr(13) + "=========================" + Chr(13) + "Inicio: " + ini.ToString + Chr(13) + "Final: " + Now.ToString)
        bar_estado.BackColor = Color.LightGray
        ToolStripStatusLabel1.Text = "Activo"
    End Sub
    Private Sub procesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim pas() As String
        If username = "aherrerap" Or username = "jsanchezc" Or username = "fandrei" Then
            bot_guarda_114.Enabled = True
            bot_cerrar_saldos.Enabled = True
            bot_actual_114.Enabled = True
        End If
        'bot_guarda_114.Enabled = True
        a.qr("select i4_ano_sem from anom304", 1)
        a.rs.Read()
        lbl_sem_activa.Text = a.rs!i4_ano_sem.ToString
        txt_semana.Text = lbl_sem_activa.Text
        cmb_tponom.Items.Add("1-Sindicalizado")
        cmb_tponom.Items.Add("2-Confianza")
        cmb_tponom.Items.Add("3-Jubilados")
        cmb_tponom.Items.Add("4-Becarios")
        a.qr("select g3_cc,g3_nomlargo from anom103 where g3_cc between 11000 and 14999 order by g3_cc", 1)
        While a.rs.Read
            cmb_depto.Items.Add(a.rs!g3_cc.ToString + "-" + a.rs!g3_nomlargo)
        End While
        a.qr("select g2a_catego,g2a_nombrecorto from anom102a", 1)
        While a.rs.Read
            cmb_catego.Items.Add(a.rs!g2a_catego.ToString + "-" + a.rs!g2a_nombrecorto)
        End While
        a.qr("select g4_cpto,g4_nombre from anom104 where g4_cpto>0", 1)
        While a.rs.Read
            cmb_cpto.Items.Add(a.rs!g4_cpto.ToString + "-" + a.rs!g4_nombre)
            If a.rs!g4_cpto > 399 Then
                cmb_cpto_114.Items.Add(a.rs!g4_cpto.ToString + "-" + a.rs!g4_nombre)
            End If
        End While
        a.qr("select numtra,nombre from nombres order by 2", 1)
        While a.rs.Read
            cmb_numtra_114.Items.Add(a.rs!nombre + " - " + a.rs!numtra.ToString)
        End While
        estados()
    End Sub
    Sub estados()
        a.qr("select * from anom402 where j2_semana=" + lbl_sem_activa.Text, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            If a.rs!j2_procesado = "N" Then
                lbl_estado_extra.ForeColor = Color.Green
                lbl_estado_extra.Text = "Abierto"
            Else
                lbl_estado_extra.ForeColor = Color.Red
                lbl_estado_extra.Text = "Cerrado"
            End If
            If a.rs!j2_saldos = "N" Then
                lbl_estado_descuen.ForeColor = Color.Green
                lbl_estado_descuen.Text = "Abierto"
            Else
                lbl_estado_descuen.ForeColor = Color.Red
                lbl_estado_descuen.Text = "Cerrado"
            End If
        End If
    End Sub
    Private Sub RevisionTimbradoEncabezadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisionTimbradoEncabezadoToolStripMenuItem.Click
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
            a.qr("select j1_numtra,sum(case when j1_cpto=403 then j1_importe else 0 end) ispt,sum(case when j1_cpto=411 then j1_importe else 0 end) subsidio from anom401" +
                " where j1_semana = " + a.rs!sem.ToString +
                " and j1_tponom=" + wtponom.ToString +
                " and j1_cpto in (403,411)" +
                " and j1_tpo_emision<8" +
                " group by j1_numtra" +
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

    Private Sub DesgloseDeNominaConciliacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesgloseDeNominaConciliacionToolStripMenuItem.Click
        Dim tipnom = ""
        Dim nomina = ""
        While True
            tipnom = InputBox("Tipo Contrato:   (1) OBRERO   (2) EMPLEADOS   (3) ZUCARMEX")
            If Val(tipnom) >= 1 And Val(tipnom) <= 3 Then
                Exit While
            End If
        End While
        While True
            nomina = InputBox("Tipo Nomina: (1) NORMAL   (2) PREMIO")
            If Val(nomina) >= 1 And Val(nomina) <= 2 Then
                Exit While
            End If
        End While

        '################## REPORTE DE CORPORATIVO DE NOMINA NOM001.TXT

        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\NOM001_" + tipnom + ".txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("exec repnom " + tipnom + "," + nomina, 1)
        While a.rs.Read
            sw.WriteLine(a.rs.Item(0).ToString + Chr(9) + a.rs.Item(1).ToString + Chr(9) + a.rs.Item(2).ToString + Chr(9) + a.rs.Item(3).ToString + Chr(9) + a.rs.Item(4).ToString + Chr(9) +
                         a.rs.Item(5).ToString + Chr(9) + a.rs.Item(6).ToString + Chr(9) + a.rs.Item(7).ToString + Chr(9) + a.rs.Item(8).ToString + Chr(9) + a.rs.Item(9).ToString + Chr(9) +
                         a.rs.Item(10).ToString + Chr(9) + a.rs.Item(11).ToString + Chr(9) + a.rs.Item(12).ToString + Chr(9) + a.rs.Item(13).ToString + Chr(9))
        End While
        sw.Close()
        MsgBox("Reporte Creado")
    End Sub

    Private Sub CalculoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculoToolStripMenuItem.Click
        Dim c As New Clase
        Dim b As New Clase
        Dim cont = 1
        Dim total = 0
        Dim wimpo As Decimal
        Dim wdes As Decimal
        Dim ano = ""
        Dim wsem = ""
        Dim mes = ""
        a.qr("select valor from parametros where tipo=1 and clave='anoprem'", 1)
        a.rs.Read()
        ano = a.rs!valor
        While True
            mes = InputBox("Numero de mes a calcular (1-12)")
            If Len(mes) = 0 Then
                Exit Sub
            End If
            If Val(mes) > 0 And Val(mes) < 13 Then
                If Val(mes) < 10 Then
                    mes = "01/0" + mes + "/" + ano
                Else
                    mes = "01/" + mes + "/" + ano
                End If
                Exit While
            End If
        End While
        While True
            wsem = InputBox("Semana")
            If Len(wsem) = 0 Then
                Exit Sub
            End If
            a.qr("select * from anom201 where h1_semana=" + wsem, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While

        a.qr("despensa '" + mes + "'," + wsem, 2)

        '=== CALCULO DE PENSION ALIMENTICIA

        a.qr("insert into anom212 select g6_cveing,g6_tponom,g6_numtra,g6_conse,g6_porc,0," + wsem + ",1 from anom106 where g6_indica=1", 2)
        a.qr("select * from anom211 where d1_semana=" + wsem + " order by d1_tponom,d1_numtra", 1)
        While a.rs.Read
            c.qr("select d1_importe from anom211 where d1_semana=" + wsem + " and d1_tponom=" + a.rs!d1_tponom.ToString + " and d1_numtra=" + a.rs!d1_numtra.ToString, 1)
            c.rs.Read()
            wimpo = c.rs!d1_importe
            b.qr("select * from anom212 " +
            " where d2_tponom = " + a.rs!d1_tponom.ToString +
            " and d2_numtra= " + a.rs!d1_numtra.ToString +
            " and d2_semana=" + wsem +
            " order by d2_conse", 1)
            While b.rs.Read
                wdes = wimpo * b.rs!d2_porc / 100
                c.qr("update anom212 set d2_descto=" + wdes.ToString +
                     " where d2_semana=" + wsem +
                     " and d2_tponom=" + b.rs!d2_tponom.ToString +
                     " and d2_numtra=" + b.rs!d2_numtra.ToString +
                     " and d2_conse=" + b.rs!d2_conse.ToString, 2)
                wimpo = wimpo - wdes
            End While
            c.qr("update anom211 set d1_descuento=(select case when sum(d2_descto) is null then 0 else sum(d2_descto) end " +
                 " from anom212 where d2_semana=d1_semana and d2_numtra=d1_numtra and d2_tponom=d1_tponom) where d1_semana=" + wsem + " and d1_tponom=" + a.rs!d1_tponom.ToString + " and d1_numtra=" + a.rs!d1_numtra.ToString, 2)
        End While
        MsgBox("Proceso de calculo terminado")
    End Sub

    Private Sub ReportesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesToolStripMenuItem1.Click
        Dim wsem = ""
        Dim wfec = ""
        Dim wmes = ""
        Dim wano = ""
        Dim pag = ""
        While True
            wsem = InputBox("Semana:")
            If Len(wsem) = 0 Then
                Exit Sub
            End If
            a.qr("select * from anom201 where h1_semana=" + wsem.ToString, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        While True
            wfec = InputBox("Primer dia del mes de Despensa (DD/MM/AAAA): ")
            If Len(wfec) = 0 Then
                Exit Sub
            End If
            If IsDate(wfec) Then
                Exit While
            End If
        End While
        While True
            pag = InputBox("Fecha de pago (DD/MM/AAAA): ")
            If Len(pag) = 0 Then
                Exit Sub
            End If
            If IsDate(pag) Then
                Exit While
            End If
        End While
        wmes = Mid(wfec, 4, 2)
        wano = Mid(wfec, 7, 4)
        a.qr("insert into anom502" +
             " select d1_cveing,d1_numtra,d1_tponom,13000,3,200,'01/" + wmes + "/" + wano + "'" +
             ",CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,'01/" + wmes + "/" + wano + "'))),DATEADD(mm,1,'01/" + wmes + "/" + wano + "')),103) " +
             ",d1_importe,1,'S','" + pag + "','D'," + wsem + ",'01/" + wmes + "/" + wano + "' from anom211", 2)
        a.qr("insert into anom502" +
             " select d1_cveing,d1_numtra,d1_tponom,13000,3,415,'01/" + wmes +
             "/" + wano + "',CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,'01/" + wmes + "/" + wano + "'))),DATEADD(mm,1,'01/" + wmes +
             "/" + wano + "')),103) ,d1_descuento,1,'S','" + pag + "','D'," + wsem + ",'01/" + wmes + "/" + wano + "' from anom211 where d1_descuento>0", 2)
        a.qr("exec cargar_pension 5", 2)
        MsgBox("Proceso realizado")
    End Sub

    Private Sub DespensaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DespensaToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String
        Dim sw As StreamWriter
        Dim tot1, tot2, tot3, tot4 As Decimal
        fic = "c:\temp\despensa.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        a.qr("select * from rep_despensa order by 1,2", 1)
        sw = New System.IO.StreamWriter(fic)
        sw.WriteLine("Reporte despensa")
        sw.WriteLine("========================================================================================================")
        sw.WriteLine(" TPONOM  NUMTRA      NOMBRE                              DIAS   FACTOR  IMPORTE  DESCUENTO  NETO A PAGAR")
        sw.WriteLine("========================================================================================================")
        While a.rs.Read
            sw.WriteLine("    " + String.Format("{0,-5}", a.rs.Item(0)) +
                         String.Format("{0,-9}", a.rs.Item(1)) +
                         String.Format("{0,-35}", a.rs.Item(2)) +
                         String.Format("{0,8}", a.rs.Item(3)) +
                         String.Format("{0,8}", a.rs.Item(4)) +
                         String.Format("{0,10}", a.rs.Item(5)) +
                         String.Format("{0,10}", a.rs.Item(6)) +
                         String.Format("{0,10}", a.rs.Item(7)))
            tot1 += a.rs.Item(3)
            tot2 += a.rs.Item(5)
            tot3 += a.rs.Item(6)
            tot4 += a.rs.Item(7)
        End While
        sw.WriteLine("")
        sw.WriteLine("")
        sw.WriteLine("                       Total Dias:                " + String.Format("{0,15}", tot1))
        sw.WriteLine("                       Total Despensa:            " + String.Format("{0,15}", FormatCurrency(tot2)))
        sw.WriteLine("                       Total Pension Alimenticia: " + String.Format("{0,15}", FormatCurrency(tot3)))
        sw.WriteLine("                       Total Neto a pagar:        " + String.Format("{0,15}", FormatCurrency(tot4)))
        sw.Close()
        fic = "c:\temp\despensa_pensiones.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        a.qr("select * from rep_despensa_pension order by 1,2,3", 1)
        tot1 = 0
        sw = New System.IO.StreamWriter(fic)
        sw.WriteLine("Reporte despensa pensiones alimenticias")
        sw.WriteLine("====================================================================")
        sw.WriteLine(" TPONOM  NUMTRA   CLAVE     PENSIONADA                  NETO A PAGAR")
        sw.WriteLine("====================================================================")
        While a.rs.Read
            sw.WriteLine("   " + String.Format("{0,-5}", a.rs.Item(0)) +
             String.Format("{0,5}", a.rs.Item(1)) +
             String.Format("{0,7}", a.rs.Item(2)) + " " +
             Mid(String.Format("{0,-35}", a.rs.Item(3)), 1, 35) +
             String.Format("{0,8}", a.rs.Item(4)))
            tot1 += a.rs.Item(4)
        End While
        sw.WriteLine("")
        sw.WriteLine("")
        sw.WriteLine("                     Total Neto a pagar:        " + String.Format("{0,15}", FormatCurrency(tot1)))
        sw.Close()
        MsgBox("Reportes generados")
    End Sub

    Private Sub CalculoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculoToolStripMenuItem1.Click
        Dim obj As StreamReader
        Dim lin As String
        Dim normal, descanso, antig, prima As Decimal
        Dim band = 0
        Dim numtra = 0
        normal = 0
        descanso = 0
        antig = 0
        prima = 0
        a.qr("truncate table anom416", 2)
        ofd_leer_timbrado.ShowDialog()
        obj = New StreamReader(ofd_leer_timbrado.FileName)
        lin = obj.ReadLine
        While obj.Peek() > -1
            If Val(Mid(lin, 22, 6)) > 0 Then
                band = 1
                numtra = Val(Mid(lin, 22, 6))
            End If
            If band = 1 Then
                If Mid(lin, 80, 5) = "NORMA" Then
                    normal = Val(Replace(Mid(lin, 116, 16), ",", ""))
                End If
                If Mid(lin, 80, 5) = "DESCA" Then
                    descanso = Val(Replace(Mid(lin, 116, 16), ",", ""))
                End If
                If Mid(lin, 80, 5) = "PRIMA" Then
                    prima = Val(Replace(Mid(lin, 116, 16), ",", ""))
                End If
                If Mid(lin, 80, 5) = "ANTIG" Then
                    antig = Val(Replace(Mid(lin, 116, 16), ",", ""))
                End If
                If Mid(lin, 80, 5) = "T O T" Then
                    'MsgBox("GUARDA" + numtra.ToString + "    " + normal.ToString + "    " + descanso.ToString + "    " + prima.ToString + "    " + antig.ToString)
                    a.qr("insert into anom416 values(1," + numtra.ToString + "," + normal.ToString + "," + descanso.ToString + "," + antig.ToString + "," + prima.ToString + ")", 2)
                    normal = 0
                    descanso = 0
                    prima = 0
                    antig = 0
                    numtra = 0
                    band = 0
                End If
            End If
            lin = obj.ReadLine
        End While
        obj.Close()
        MsgBox("proceso terminado")
    End Sub

    Private Sub bot_visualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_visualizar.Click
        Dim wtipo = ""
        While True
            wtipo = InputBox("Tipo de Pago")
            If Len(wtipo) = 0 Then
                Exit Sub
            End If
            a.qr("select * from catalogos where familia=7 and tipo=" + wtipo, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        dgv_param.Rows.Clear()
        a.qr("select * from parametros where tipo=" + wtipo, 1)
        If a.rs.HasRows Then
            While a.rs.Read
                dgv_param.Rows.Add(a.rs.Item(0).ToString, a.rs.Item(1).ToString, a.rs.Item(2).ToString, a.rs.Item(3).ToString)
            End While
        Else
            MsgBox("Tipo de pago no cuenta con parametros dados de alta")
        End If
    End Sub

    Private Sub bot_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_actualizar.Click
        Dim wtope = dgv_param.RowCount
        While wtope > 0
            a.qr("update parametros set valor='" + dgv_param.Rows(wtope - 1).Cells(2).Value.ToString + "' where tipo=" + dgv_param.Rows(wtope - 1).Cells(0).Value.ToString +
                   " and clave='" + dgv_param.Rows(wtope - 1).Cells(1).Value.ToString + "'", 2)
            wtope -= 1
        End While
        MsgBox("Proceso terminado")
        dgv_param.Rows.Clear()
        bot_visualizar.PerformClick()
    End Sub

    Private Sub bot_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_nuevo.Click
        Dim wtipo = ""
        Dim wclave = ""
        Dim wvalor = ""
        Dim wdescrip = ""
        wtipo = InputBox("Tipo de pago:")
        wclave = InputBox("Clave:")
        wvalor = InputBox("Valor:")
        wdescrip = InputBox("Descripcion:")
        a.qr("insert into parametros values (" + wtipo + ",'" + wclave + "','" + wvalor + "','" + wdescrip + "')", 2)
        dgv_param.Rows.Clear()
        a.qr("select * from parametros where tipo=" + wtipo, 1)
        If a.rs.HasRows Then
            While a.rs.Read
                dgv_param.Rows.Add(a.rs.Item(0).ToString, a.rs.Item(1).ToString, a.rs.Item(2).ToString, a.rs.Item(3).ToString)
            End While
        Else
            MsgBox("Tipo de pago no cuenta con parametros dados de alta")
        End If
        MsgBox("Proceso ejecutado")
    End Sub

    Private Sub CalculoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculoToolStripMenuItem2.Click
        Dim b As New Clase
        tparam.Columns.Add("id")
        tparam.Columns.Add("valor")
        a.qr("select * from parametros where tipo=3 order by clave", 1)
        While a.rs.Read
            tparam.Rows.Add(a.rs!clave, a.rs!valor)
        End While
        Dim salprom = 0.0
        Dim diasrea = 0.0
        Dim diasvac = 0.0
        Dim diasdes = 0.0
        Dim diasant = 0.0
        Dim impvaca = 0.0
        Dim impdesc = 0.0
        Dim impanti = 0.0
        Dim impprim = 0.0
        a.qr("truncate table anom405", 2)
        a.qr("truncate table anom416", 2)
        a.qr("  insert into anom405" +
            " select 8," +
            " j1_tponom," +
            " j1_numtra," +
            " j1_ciclo," +
            " j1_depto," +
            " j1_cpto," +
            " j1_catego," +
            " j1_turno," +
            " j1_hrs_dom," +
            " j1_importe," +
            " j1_fecha," +
            " j1_semana" +
            " from anom401" +
            " where j1_tpo_emision != 7" +
            " and j1_tpo_emision != 9" +
            " and j1_nomina != 8 " +
            " and j1_tponom=1" +
            " and  (j1_cpto = 79 " +
            " or    j1_cpto = 75 " +
            " or    j1_cpto = 3  " +
            " or    j1_cpto = 9  " +
            " or    j1_cpto = 54 " +
            " or    j1_cpto = 55 " +
            " or   (j1_cpto = 36 and (j1_catego = 6 or j1_catego = 50)) " +
            " or    j1_cpto = 12  " +
            " or   (j1_cpto = 26 and j1_catego = 72)) " +
            " and   j1_semana between " + d("semini") + " and " + d("semfin"), 2)
        a.qr("select j5_numtra,v_nombrerep,g5_ingreso,g5_sindic,g5_plaza,0 j5_asig,j11_importe,sum(case when j5_cpto=3 then j5_dias else 0 end) j5_dias" +
             " ,sum(case when j5_cpto in (" + d("impnorm") + ") then j5_importe else 0 end) j5_normal," +
            " sum(case when j5_cpto in (" + d("horturno") + ") then j5_importe else 0 end) j5_turno" +
            " from anom405 left join anom411 on (j11_tponom=j5_tponom and j11_numtra=j5_numtra),anom105,vacre102" +
            " where j5_semana between " + d("semini") + " and " + d("semfin") +
            " and g5_tponom=1" +
            " and g5_numtra=j5_numtra" +
            " and g5_sindic=1" +
            " and v_relab=3" +
            " and v_clave=g5_numtra" +
            " group by j5_numtra,v_nombrerep,g5_ingreso,g5_sindic,g5_plaza,j11_importe" +
            " order by 1", 1)
        While a.rs.Read
            If a.rs!j5_dias > Val(d("diastot")) Then
                diasrea = Val(d("diastot"))
            Else
                diasrea = a.rs!j5_dias
            End If
            If IsDBNull(a.rs!j11_importe) Then
                salprom = a.rs!j5_normal / diasrea
                impprim = Math.Round((a.rs!j5_normal + a.rs!j5_turno) / diasrea, 2)
            Else
                salprom = a.rs!j11_importe
                impprim = Math.Round((salprom * diasrea) + a.rs!j5_turno, 2)
                impprim = Math.Round(impprim / diasrea, 2)
            End If
            diasvac = Math.Round(diasrea * Val(d("diasvac")) / Val(d("diastot")), 2)
            diasdes = Math.Round(diasrea * Val(d("diasdes")) / Val(d("diastot")), 2)
            diasant = DateDiff(DateInterval.Day, a.rs!g5_ingreso, CDate(d("fechacor")))
            diasant = diasant / 365
            If diasant < 29 Then
                diasant = 0
            Else
                diasant = Math.Round(diasant, 0)
            End If
            If diasant > 28 Then
                Select Case diasant
                    Case 29 To 33
                        diasant = 1
                    Case 34 To 38
                        diasant = 2
                    Case 39 To 43
                        diasant = 3
                    Case 44 To 48
                        diasant = 4
                    Case Else
                        diasant = 5
                End Select
            Else
                diasant = 0
            End If
            diasant = Math.Round(diasrea * diasant / Val(d("diastot")), 2)
            impanti = Math.Round(diasant * salprom, 2)
            impvaca = diasvac * salprom
            impdesc = diasdes * salprom
            impprim = Math.Round(impprim * (diasvac + diasdes + diasant), 2)
            impprim = Math.Round(impprim * Val(d("priobr")) / 100, 2)
            If diasrea = 0 Then
                b.qr("insert into anom416 values(1," + a.rs!j5_numtra.ToString +
                 ",0" + a.rs!j5_dias.ToString +
                 ",0" + a.rs!j5_normal.ToString +
                 ",0" + a.rs!j5_turno.ToString +
                 ",0" +
                 ",0" +
                 ",0" +
                 ",0" +
                 ",0" +
                 ",0" +
                 ",0" +
                 ",0" +
                 ",0)", 2)
            Else
                b.qr("insert into anom416 values(1," + a.rs!j5_numtra.ToString +
                 "," + a.rs!j5_dias.ToString +
                 "," + a.rs!j5_normal.ToString +
                 "," + a.rs!j5_turno.ToString +
                 ",0," +
                 salprom.ToString +
                 "," + diasvac.ToString +
                 "," + diasdes.ToString +
                 "," + diasant.ToString +
                 "," + impvaca.ToString +
                 "," + impdesc.ToString +
                 "," + impanti.ToString +
                 "," + impprim.ToString + ")", 2)
            End If
        End While
        MsgBox("Proceso terminado")
    End Sub
    Function d(ByVal texto As String)
        Dim row As DataRow
        d = ""
        For Each row In tparam.Rows
            If StrComp(LTrim(RTrim(row(0))), LTrim(RTrim(texto))) = 0 Then
                d = row(1)
            End If
        Next
    End Function

    Private Sub ActualizarSalariosIMSSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarSalariosIMSSToolStripMenuItem.Click
        If ofd_leer_timbrado.ShowDialog = MsgBoxResult.Ok Then
            ToolStripStatusLabel1.Text = "Procesando actualizacion de Salarios IMSS"
            bar_estado.BackColor = Color.LightPink
            trd_salimss = Nothing
            trd_salimss = New Thread(AddressOf salimss)
            trd_salimss.IsBackground = True
            trd_salimss.Start()
        End If
    End Sub
    Private Sub salimss()
        Dim ar As StreamReader
        Dim lin() As String
        ar = New StreamReader(ofd_leer_timbrado.FileName)
        lin = Split(ar.ReadLine, Chr(9))
        Dim cont = 0
        While Len(lin(0)) > 0
            If Len(lin(0)) > 0 Then
                a.qr("update anom105 set g5_sasegi=" + lin(2) + " where g5_tponom=" + lin(0) + " and g5_numtra=" + lin(1), 2)
            End If
            cont += 1
            lin = Split(ar.ReadLine, Chr(9))
        End While
        MsgBox("Proceso terminado, " + cont.ToString + " registros actualizados")
        ar.Close()
        ToolStripStatusLabel1.Text = "Activo"
        bar_estado.BackColor = Color.LightGray
    End Sub


    Private Sub SalariosIMSSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalariosIMSSToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\SDI_obreros.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select g5_tponom,g5_numtra,g5_sasegi from anom105 where g5_tponom=1", 1)
        While a.rs.Read
            sw.WriteLine(a.rs!g5_tponom.ToString + Chr(9) + a.rs!g5_numtra.ToString + Chr(9) + a.rs!g5_sasegi.ToString)
        End While
        sw.Close()
        fic = "c:\temp\SDI_empleados.txt"
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
    Private Sub AsistenciaSemanalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsistenciaSemanalToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\dias_trab.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        Dim semini = ""
        Dim semfin = ""
        Dim tponom = 1
        Dim numtra = 0
        Dim area = ""
        While True
            semini = InputBox("Semana Inicial")
            a.qr("select * from anom201 where h1_semana=" + semini, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        While True
            semfin = InputBox("Semana Final")
            a.qr("select * from anom201 where h1_semana=" + semfin, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        While True
            tponom = Val(InputBox("Tipo de nomina (1-Obrero, 2-Empleado"))
            If tponom = 1 Or tponom = 2 Then
                Exit While
            End If
        End While
        numtra = Val(InputBox("Numero de trabajador"))
        a.qr("exec dias_trab " + semini + "," + semfin + "," + tponom.ToString + "," + numtra.ToString, 1)
        sw.WriteLine("SEMANA   NUMTRA         NOMBRE                               CATEGO    DESCRIP       DIAS   CONCEPTO               DEPTO")
        sw.WriteLine("===============================================================================================================================")
        If tponom = 1 Then
            sw.WriteLine("                                     SINDICALIZADO")
        Else
            sw.WriteLine("                                     CONFIANZA")
        End If
        sw.WriteLine("===============================================================================================================================")
        While a.rs.Read
            sw.WriteLine("  " + a.rs!J1_SEMANA.ToString + "      " +
                String.Format("{0,-8}", a.rs!j1_numtra.ToString) +
                String.Format("{0,-40}", a.rs!v_nombrerep) +
                String.Format("{0,-5}", a.rs!j1_catego.ToString) +
                String.Format("{0,-20}", a.rs!g2a_nombrecorto) +
                String.Format("{0,-6}", a.rs!dias.ToString) +
                String.Format("{0,-20}", a.rs!concepto) +
                a.rs!j1_depto.ToString + " " + a.rs!g3_nomlargo)
        End While
        sw.Close()
        Process.Start("c:\temp\dias_trab.txt")
    End Sub

    Private Sub RevisionPersonalExtraordinarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RevisionPersonalExtraordinarioToolStripMenuItem.Click
        Dim b As New Clase
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\personal_extra.txt"
        Dim semini = ""
        Dim semfin = ""
        While True
            semini = InputBox("Semana Inicial")
            a.qr("select * from anom201 where h1_semana=" + semini, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        While True
            semfin = InputBox("Semana Final")
            a.qr("select * from anom201 where h1_semana=" + semfin, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        a.qr("select h1_semana,catego,g2a_nombrecorto,g2_sueldo,h2_fecha,count(*) num from escalafon,anom102a,anom102,anom201,anom202" +
            " where catego = g2a_catego" +
            " and g2_catego=catego" +
            " and g2_turno=2" +
            " and h1_semana between " + semini + " and " + semfin +
            " and h1_fecha_ini<=h2_fecha" +
            " and h1_fecha_fin>=h2_fecha" +
            " group by h1_semana,catego,g2a_nombrecorto,g2_sueldo,h2_fecha" +
            " order by 1,5,2", 1)
        'sw.WriteLine("SEMANA   FECHA    CATEGO        NOMBRE               CANT    IMPORTE")
        'sw.WriteLine("=========================================================================")
        While a.rs.Read
            b.qr("select count(*) real from anom203" +
                " where h3_fecha='" + Mid(a.rs!h2_fecha.ToString, 1, 10) + "'" +
                " and h3_tponom=1" +
                " and h3_catego=" + a.rs!catego.ToString +
                " and h3_tpotra=1", 1)
            If b.rs.HasRows Then
                b.rs.Read()
                If b.rs!real > a.rs!num Then
                    sw.WriteLine(a.rs!h1_semana.ToString + Chr(9) +
                                 Mid(a.rs!h2_fecha.ToString, 1, 10) + Chr(9) +
                                 a.rs!catego.ToString + Chr(9) +
                                 a.rs!g2a_nombrecorto + Chr(9) +
                                 (b.rs!real - a.rs!num).ToString + Chr(9) +
                                 ((b.rs!real - a.rs!num) * a.rs!g2_sueldo).ToString)
                End If
            End If
        End While
        sw.Close()
        MsgBox("Proceso Generado")
    End Sub

    Private Sub procesos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = "p" Then
            'MsgBox("OK")
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim b As New Clase
        If My.Computer.Name = "SC-AHERRERAP" Then
            a.qr("select turno,depto,puesto,dif,ccfeesa,h3_numtra from borra,cc_2019,anom203" +
                " where depto = cczucarmex" +
                " and h3_fecha=fecha" +
                " and h3_tponom=1" +
                " and h3_turno=2" +
                " and h3_tpotra=1" +
                " and h3_catego=puesto" +
                " and h3_depto=ccfeesa" +
                " and turno=1", 1)
            While a.rs.Read
                b.qr("", 1)
            End While
        End If
    End Sub

    Private Sub bot_cargar_movtos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_cargar_movtos.Click
        Dim archivo As String = ""
        Dim suma = 0.0
        Dim regs = 0
        Dim semana = 0
        If ofd_leer_timbrado.ShowDialog = Windows.Forms.DialogResult.OK Then
            archivo = ofd_leer_timbrado.FileName
        Else
            Exit Sub
        End If
        Dim xlsm As New Workbook
        xlsm.LoadFromFile(archivo)
        Dim hoja As Worksheet
        hoja = xlsm.Worksheets(0)
        semana = Val(lbl_sem_activa.Text)
        Dim fecha = ""
        a.qr("select h1_fecha_fin from anom201 where h1_semana=" + semana.ToString, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            fecha = a.rs!h1_fecha_fin.ToString
            txt_semana.Text = semana
        Else
            MsgBox("Semana no existe")
            hoja = Nothing
            xlsm = Nothing
            Exit Sub
        End If
        a.qr("select * from anom402 where j2_semana=" + semana.ToString, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            If a.rs!j2_procesado = "S" Then
                MsgBox("Semana ya fue procesada en nomina, revisar semana en hoja de trabajo")
                hoja = Nothing
                xlsm = Nothing
                Exit Sub
            End If
        End If
        a.qr("select *" +
            " from anom205, anom201" +
            " where h1_semana = " + semana.ToString +
            " and h1_fecha_ini<=h5_fecha" +
            " and h1_fecha_fin>=h5_fecha", 1)
        If a.rs.HasRows Then
            bot_mostrar.PerformClick()
            If MsgBox("Existen registros, continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                MsgBox("Proceso cancelado")
                Exit Sub
            End If
        End If
        Dim fila = 4
        Dim tpotra = "1"
        Dim tponom = 1
        Dim cadena = "insert into anom205 values (8,"
        While True
            'MsgBox(hoja.Range("A" + fila.ToString).Value)
            If Val(hoja.Range("A" + fila.ToString).Value) > 0 Then
                If Val(hoja.Range("A" + fila.ToString).Value) < 20000 Then
                    tponom = 1
                Else
                    If Val(hoja.Range("A" + fila.ToString).Value) < 30000 Then
                        tponom = 2
                    Else
                        tponom = 4
                    End If
                End If
                cadena = cadena + tponom.ToString + "," +
                                hoja.Range("D" + fila.ToString).Value.ToString + "," + tpotra + "," +
                                hoja.Range("A" + fila.ToString).Value.ToString + ",'V'," +
                                hoja.Range("H" + fila.ToString).Value.ToString + "," +
                                hoja.Range("F" + fila.ToString).Value.ToString + "," +
                                hoja.Range("F" + fila.ToString).Value.ToString + ",0," +
                                hoja.Range("J" + fila.ToString).Value.ToString + ",0," +
                                "'" + hoja.Range("L" + fila.ToString).Value.ToString + "','" +
                                Mid(fecha.ToString, 1, 10) + "'," +
                                hoja.Range("K" + fila.ToString).Value.ToString + "," +
                                hoja.Range("A" + fila.ToString).Value.ToString + "," +
                                fila.ToString + ")"
                a.qr(cadena, 2)
                regs += 1
                suma += Val(hoja.Range("J" + fila.ToString).Value)
                cadena = "insert into anom205 values (8,"
            Else
                Exit While
            End If
            fila += 1
        End While
        hoja = Nothing
        xlsm = Nothing
        MsgBox("Registros procesados: " + regs.ToString + Chr(13) + "Total procesado:" + suma.ToString)
        bot_mostrar.PerformClick()
    End Sub

    Private Sub bot_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_mostrar.Click
        Dim query = ""
        Dim op() As String
        dgv_pagosextras.Rows.Clear()
        txt_suma.Text = ""
        Dim suma = 0.0
        If Val(txt_semana.Text) > 0 Then
            a.qr("select * from anom201 where h1_semana=" + txt_semana.Text.ToString, 1)
            query = "select h5_tponom,h5_numtra,nombre,h5_catego,g2a_nombrelargo,h5_tpotra,h5_cpto,g4_nombre,h5_importe,h5_hoja,h5_depto,g3_nomlargo " +
                    " from anom205, anom102a, nombres, anom104, anom103, anom201" +
                    " where h5_catego = g2a_catego" +
                    " and h5_numtra=numtra" +
                    " and h5_tponom=tponom" +
                    " and h5_cpto=g4_cpto" +
                    " and h5_depto=g3_cc" +
                    " and h1_semana=" + txt_semana.Text.ToString +
                    " and h1_fecha_ini<=h5_fecha" +
                    " and h1_fecha_fin>=h5_fecha"
            If cmb_catego.Text <> "" Then
                op = Split(cmb_catego.Text, "-")
                query = query + " and h5_catego=" + op(0)
            End If
            If cmb_tponom.Text <> "" Then
                op = Split(cmb_tponom.Text, "-")
                query = query + " and h5_tponom=" + op(0)
            End If
            If cmb_cpto.Text <> "" Then
                op = Split(cmb_cpto.Text, "-")
                query = query + " and h5_cpto=" + op(0)
            End If
            If cmb_hoja.Text <> "" Then
                op = Split(cmb_hoja.Text, "-")
                query = query + " and h5_hoja=" + op(0)
            End If
            If cmb_depto.Text <> "" Then
                op = Split(cmb_depto.Text, "-")
                query = query + " and h5_depto=" + op(0)
            End If
            query = query + " order by h5_hoja,h5_numtra"
            If a.rs.HasRows Then
                a.qr(query, 1)
                While a.rs.Read
                    dgv_pagosextras.Rows.Add(a.rs!h5_tponom, a.rs!h5_numtra, a.rs!nombre, a.rs!h5_catego, a.rs!g2a_nombrelargo, a.rs!h5_depto, a.rs!g3_nomlargo, a.rs!h5_tpotra, a.rs!h5_cpto, a.rs!g4_nombre, a.rs!h5_importe, a.rs!h5_hoja)
                    suma += a.rs!h5_importe
                End While
                txt_suma.Text = Format(suma, "###,###,##0.00")
                cmb_hoja.Items.Clear()
                a.qr("select distinct h5_hoja" +
                    " from anom205, anom201" +
                    " where h1_semana = " + txt_semana.Text.ToString +
                    " and h1_fecha_ini<=h5_fecha" +
                    " and h1_fecha_fin>=h5_fecha" +
                    " order by h5_hoja", 1)
                While a.rs.Read
                    cmb_hoja.Items.Add(a.rs!h5_hoja.ToString)
                End While
            Else
                MsgBox("Semana incorrecta")
                txt_semana.Text = ""
                txt_semana.Focus()
            End If
        Else
            MsgBox("Semana incorrecta")
            txt_semana.Text = ""
            txt_semana.Focus()
        End If
    End Sub

    Private Sub bot_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_eliminar.Click
        Dim fecini = ""
        Dim fecfin = ""
        If Val(txt_semana.Text) > 0 Then
            a.qr("select * from anom201 where h1_semana=" + txt_semana.Text.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                fecini = Mid(a.rs!h1_fecha_ini.ToString, 1, 10)
                fecfin = Mid(a.rs!h1_fecha_fin.ToString, 1, 10)
                If MsgBox("Eliminar semana?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    a.qr("delete from anom205 where h5_fecha between '" + fecini + "' and '" + fecfin + "'", 2)
                    MsgBox("Semana borrada")
                End If
            End If
            bot_mostrar.PerformClick()
        Else
            MsgBox("Semana incorrecta")
        End If
    End Sub

    Private Sub bot_fabrica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_fabrica.Click
        Dim ar As StreamReader
        Dim lin() As String
        Dim semana = 0
        Dim cant = 1
        Dim tpotra = "1"
        Dim fecha = ""
        If ofd_leer_timbrado.ShowDialog = Windows.Forms.DialogResult.OK Then
            semana = Val(Mid(Mid(ofd_leer_timbrado.FileName, Len(ofd_leer_timbrado.FileName) - 9, 10), 1, 6))
            a.qr("select * from anom201 where h1_semana=" + semana.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                fecha = Mid(a.rs!h1_fecha_fin.ToString, 1, 10)
                txt_semana.Text = semana.ToString
                a.qr("select *" +
                    " from anom205, anom201" +
                    " where h1_semana = " + semana.ToString +
                    " and h1_fecha_ini<=h5_fecha" +
                    " and h1_fecha_fin>=h5_fecha", 1)
                If a.rs.HasRows Then
                    bot_mostrar.PerformClick()
                    If MsgBox("Existen registros, continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Semana no existe")
                Exit Sub
            End If
            ar = New StreamReader(ofd_leer_timbrado.FileName)
            While ar.Peek >= 0
                lin = Split(ar.ReadLine, "|")
                If Val(lin(6)) = 37 Or Val(lin(6)) = 78 Then
                    tpotra = "1"
                Else
                    a.qr("select * from anom105 where g5_tponom=1 and g5_plaza>1 and g5_numtra=" + lin(4), 1)
                    If a.rs.HasRows Then
                        tpotra = "2"
                    Else
                        tpotra = "1"
                    End If
                End If
                a.qr("insert into anom205 values (8," + lin(1) + "," + lin(2) + "," + tpotra + "," + lin(4) + ",'V'," + lin(6) + "," + lin(7) + "," + lin(8) + "," + lin(9) +
                       "," + lin(10) + "," + lin(11) + ",'" + lin(12) + "','" + fecha + "'," + lin(14) + "," + lin(15) + "," + cant.ToString + ")", 2)
                cant += 1
                tpotra = "1"
            End While
            ar.Close()
        End If
        bot_mostrar.PerformClick()
        MsgBox("Proceso terminado")
    End Sub

    Private Sub bot_convenios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_convenios.Click
        If Len(txt_semana.Text) = 0 Then
            MsgBox("Semana no existe, escribir correcta")
            txt_semana.Focus()
            Exit Sub
        End If
        a.qr("select * from anom201,anom205 where h1_semana=" + txt_semana.Text.ToString + " and h5_fecha=h1_fecha_fin and h5_hoja=10", 1)
        If a.rs.HasRows Then
            MsgBox("Convenios ya estan cargados, revisar hojas 10-19,501,502")
            Exit Sub
        Else
            If MsgBox("Cargar convenios semana " + txt_semana.Text.ToString + "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                a.qr("convenio " + txt_semana.Text.ToString + ",10,10", 2) ' DEP=13029, TPOTRA=1, CAT=TODO, CALC= 10 HR X DIA
                a.qr("convenio " + txt_semana.Text.ToString + ",11,28", 2) ' DEP=13038, TPOTRA=1, CAT=TODO, CALC= 10 HR X DIA
                a.qr("convenio " + txt_semana.Text.ToString + ",12,16", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",13,0", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",14,16", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",15,16", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",16,14", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",17,14", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",18,14", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",19,14", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",20,0", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",501,0", 2)
                a.qr("convenio " + txt_semana.Text.ToString + ",502,0", 2)
                MsgBox("Proceso terminado")
            End If
        End If
    End Sub

    Private Sub CargaDeAsistenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bot_mostrar_114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_mostrar_114.Click
        Dim op() As String
        Dim query = "select g14_tponom,g14_numtra,nombre,g14_cpto,g4_nombre,g14_compara,g14_saldo,g14_cuota from anom114,nombres,anom104" +
            " where g14_tponom = tponom" +
            " and g14_numtra=numtra" +
            " and g14_cpto=g4_cpto"
        If cmb_tponom_114.Text <> "" Then
            op = Split(cmb_tponom_114.Text, "-")
            query = query + " and g14_tponom=" + op(0)
        End If
        If cmb_numtra_114.Text <> "" Then
            If Val(cmb_numtra_114.Text) > 0 Then
                query = query + " and g14_numtra=" + cmb_numtra_114.Text
            Else
                op = Split(cmb_numtra_114.Text, "-")
                query = query + " and g14_numtra=" + op(1)
            End If
        End If
        If cmb_cpto_114.Text <> "" Then
            op = Split(cmb_cpto_114.Text, "-")
            query = query + " and g14_cpto=" + op(0)
        End If
        If cmb_saldo_114.Text <> "" Then
            op = Split(cmb_saldo_114.Text, "-")
            If op(0) = "1" Then
                query = query + " and g14_saldo>0"
            End If
        End If
        query = query + " order by 1,2"
        dgv_saldos_114.Rows.Clear()
        a.qr(query, 1)
        While a.rs.Read
            dgv_saldos_114.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4), a.rs.Item(5), a.rs.Item(6), a.rs.Item(7))
        End While
    End Sub

    Private Sub bot_guarda_114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_guarda_114.Click
        Dim wtope = dgv_saldos_114.RowCount
        While wtope > 0
            If dgv_saldos_114.Rows(wtope - 1).Cells(8).Value = True Then
                a.qr("update anom114 set g14_saldo=" + dgv_saldos_114.Rows(wtope - 1).Cells(6).Value.ToString +
                       ",g14_cuota=" + dgv_saldos_114.Rows(wtope - 1).Cells(7).Value.ToString +
                       " where g14_cpto=" + dgv_saldos_114.Rows(wtope - 1).Cells(3).Value.ToString +
                       " and g14_tponom=" + dgv_saldos_114.Rows(wtope - 1).Cells(0).Value.ToString +
                       " and g14_numtra=" + dgv_saldos_114.Rows(wtope - 1).Cells(1).Value.ToString, 2)
            End If
            wtope -= 1
        End While
        MsgBox("Proceso realizado")
        dgv_saldos_114.Rows.Clear()
        bot_mostrar_114.PerformClick()
    End Sub

    Private Sub bot_cerrar_sem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_cerrar_sem.Click
        If Len(txt_semana.Text) > 0 Then
            a.qr("select * from anom402 where j2_semana=" + txt_semana.Text.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                If a.rs!j2_procesado = "S" Then
                    MsgBox("Semana ya fue procesada en nomina")
                    Exit Sub
                End If
            End If
            a.qr("select * from anom201 where h1_semana=" + txt_semana.Text, 1)
            If a.rs.HasRows Then
                If MsgBox("cerrar semana pagos extras?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    a.qr("update anom402 set j2_procesado='S' where j2_semana=" + txt_semana.Text, 2)
                    estados()
                    MsgBox("Proceso realizado")
                End If
            Else
                MsgBox("la semana que esta la pestaña de pagos extras no esta correcta, corregir")
            End If
        Else
            MsgBox("la semana que esta la pestaña de pagos extras no esta correcta, corregir")
        End If
    End Sub


    Private Sub bot_actual_114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_actual_114.Click
        Dim wfecha = ""
        Dim wsemana = ""
        Dim valor = 0
        Dim lin() As String
        Dim ar As StreamReader
        a.qr("select i4_ano_sem,convert(char(10),getdate(),103) fecha from anom304", 1)
        a.rs.Read()
        wfecha = a.rs!fecha
        wsemana = a.rs!i4_ano_sem.ToString
        Dim wsn = "N"
        While True
            wsn = UCase(InputBox("sumar saldo?"))
            If wsn = "S" Or wsn = "N" Then
                Exit While
            End If
        End While
        If ofd_leer_timbrado.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ar = New StreamReader(ofd_leer_timbrado.FileName)
            Dim cont = 1
            While True
                lin = Split(ar.ReadLine, Chr(44))
                If Len(lin(0)) = 0 Then
                    Exit While
                End If
                Try
                    For x = 0 To 4
                        valor = Val(lin(x))
                    Next
                Catch ex As Exception
                    MsgBox("Error fila " + cont.ToString)
                End Try
                cont += 1
            End While
            ar = New StreamReader(ofd_leer_timbrado.FileName)
            While True
                lin = Split(ar.ReadLine, Chr(44))
                If Len(lin(0)) = 0 Then
                    Exit While
                End If
                a.qr("select * from anom114 where g14_numtra=" + lin(1).ToString + " and g14_tponom=" + lin(0).ToString + " and g14_cpto=" + lin(2).ToString, 1)
                If a.rs.HasRows Then
                    If wsn = "S" Then
                        a.qr("update anom114 set g14_saldo=g14_saldo+" + lin(3).ToString +
                            ",g14_sal_inic=g14_sal_inic+" + lin(3).ToString +
                            ",g14_cuota=" + lin(4).ToString +
                            " where g14_numtra=" + lin(1).ToString +
                            " and g14_tponom=" + lin(0).ToString +
                            " and g14_cpto=" + lin(2).ToString, 2)
                    End If
                    If wsn = "N" Then
                        a.qr("update anom114 set g14_saldo=" + lin(3).ToString +
                            ",g14_sal_inic=" + lin(3).ToString +
                            ",g14_cuota=" + lin(4).ToString +
                            " where g14_numtra=" + lin(1).ToString +
                            " and g14_tponom=" + lin(0).ToString +
                            " and g14_cpto=" + lin(2).ToString, 2)
                    End If

                Else
                    a.qr("insert into anom114 values(8," + wsemana + ",2,0,0," + lin(0) + "," + lin(1) + "," + lin(2) + ",0,'" + wfecha + "'," + lin(3) + "," + lin(3) + "," + lin(4) + ",0)", 2)
                End If
            End While
            MsgBox("Saldos actualizados")
            ar.Close()
        End If
    End Sub

    Private Sub DeduccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Proceso no procede")
        Exit Sub
        Dim b As New Clase
        Dim c As New Clase
        Dim wimpo As Double = 0.0
        Dim wdes As Double = 0.0
        Dim cont = 0
        bar_estado.BackColor = Color.Green
        ToolStripStatusLabel1.Text = "Procesando calculo de pensiones"
        a.qr("truncate table anom212", 2)
        a.qr("insert into anom212 select g6_cveing,g6_tponom,g6_numtra,g6_conse,g6_porc,0,1,1 from anom106 where g6_indica=1", 2)
        a.qr("select * from anom211 order by d1_tponom,d1_numtra", 1)
        While a.rs.Read
            c.qr("select d1_importe from anom211 where d1_tponom=" + a.rs!d1_tponom.ToString + " and d1_numtra=" + a.rs!d1_numtra.ToString, 1)
            c.rs.Read()
            wimpo = c.rs!d1_importe
            b.qr("select * from anom212 " +
            " where d2_tponom = " + a.rs!d1_tponom.ToString +
            " and d2_numtra= " + a.rs!d1_numtra.ToString +
            " order by d2_conse", 1)
            While b.rs.Read
                wdes = wimpo * b.rs!d2_porc / 100
                c.qr("update anom212 set d2_descto=" + wdes.ToString +
                     " where d2_tponom=" + b.rs!d2_tponom.ToString +
                     " and d2_numtra=" + b.rs!d2_numtra.ToString +
                     " and d2_conse=" + b.rs!d2_conse.ToString, 2)
                wimpo = wimpo - wdes
            End While
            c.qr("update anom211 set d1_descuento=(select case when sum(d2_descto) is null then 0 else sum(d2_descto) end " +
                 " from anom212 where d2_semana=d1_semana and d2_numtra=d1_numtra and d2_tponom=d1_tponom) where d1_tponom=" + a.rs!d1_tponom.ToString + " and d1_numtra=" + a.rs!d1_numtra.ToString, 2)
        End While
        MsgBox("Proceso terminado")
        bar_estado.BackColor = Color.LightGray
        ToolStripStatusLabel1.Text = "Activo"
    End Sub

    Private Sub CalculoDePensionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculoDePensionesToolStripMenuItem.Click
        Dim b As New Clase
        Dim c As New Clase
        Dim obj As StreamReader
        Dim lin As String
        Dim lines()
        Dim wimpo As Double = 0.0
        Dim wdes As Double = 0.0
        Dim cont = 0
        If ofd_leer_timbrado.ShowDialog() = MsgBoxResult.Ok Then
            obj = New StreamReader(ofd_leer_timbrado.FileName)
        Else
            MsgBox("Proceso cancelado")
            Exit Sub
        End If
        bar_estado.BackColor = Color.Green
        ToolStripStatusLabel1.Text = "Procesando calculo de pensiones"
        lin = obj.ReadLine()
        a.qr("truncate table anom211", 2)
        a.qr("truncate table anom212", 2)
        While Len(lin) > 0
            lines = Split(lin, Chr(9))
            a.qr("insert into anom211 values (8," + lines(0) + "," + lines(1) + ",0," + lines(2) + ",0,1,1,1)", 2)
            cont += 1
            lin = obj.ReadLine()
        End While
        obj.Close()
        MsgBox(cont.ToString + " registros leidos")
        a.qr("insert into anom212 select g6_cveing,g6_tponom,g6_numtra,g6_conse,g6_porc,0,1,1 from anom106 where g6_indica=1", 2)
        a.qr("select * from anom211 order by d1_tponom,d1_numtra", 1)
        While a.rs.Read
            c.qr("select d1_importe from anom211 where d1_tponom=" + a.rs!d1_tponom.ToString + " and d1_numtra=" + a.rs!d1_numtra.ToString, 1)
            c.rs.Read()
            wimpo = c.rs!d1_importe
            b.qr("select * from anom212 " +
            " where d2_tponom = " + a.rs!d1_tponom.ToString +
            " and d2_numtra= " + a.rs!d1_numtra.ToString +
            " order by d2_conse", 1)
            While b.rs.Read
                wdes = wimpo * b.rs!d2_porc / 100
                c.qr("update anom212 set d2_descto=" + wdes.ToString +
                     " where d2_tponom=" + b.rs!d2_tponom.ToString +
                     " and d2_numtra=" + b.rs!d2_numtra.ToString +
                     " and d2_conse=" + b.rs!d2_conse.ToString, 2)
                wimpo = wimpo - wdes
            End While
            c.qr("update anom211 set d1_descuento=(select case when sum(d2_descto) is null then 0 else sum(d2_descto) end " +
                 " from anom212 where d2_semana=d1_semana and d2_numtra=d1_numtra and d2_tponom=d1_tponom) where d1_tponom=" + a.rs!d1_tponom.ToString + " and d1_numtra=" + a.rs!d1_numtra.ToString, 2)
        End While
        MsgBox("Proceso terminado")
        bar_estado.BackColor = Color.LightGray
        ToolStripStatusLabel1.Text = "Activo"
    End Sub

    Private Sub CargaDeAsistenciaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargaDeAsistenciaToolStripMenuItem1.Click
        Dim mes = ""
        Dim ano = ""
        Dim unir = 0
        a.qr("select valor from parametros where tipo=1 and clave='anoprem'", 1)
        a.rs.Read()
        ano = a.rs!valor
        While True
            mes = InputBox("Numero de mes a calcular (1-12)")
            If Len(mes) = 0 Then
                Exit Sub
            End If
            If Val(mes) > 0 And Val(mes) < 13 Then
                If Val(mes) < 10 Then
                    mes = "01/0" + mes + "/" + ano
                Else
                    mes = "01/" + mes + "/" + ano
                End If
                Exit While
            End If
        End While
        a.qr("select j2_premio from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            If a.rs!j2_premio = "1" Or a.rs!j2_premio = "2" Then
                a.qr("truncate table anom210", 2)
                a.qr("insert into anom210 select * from anom210a", 2)
                a.qr("update anom402 set j2_premio='1' where j2_semana=(select i4_ano_sem from anom304)", 2)
            Else
                If a.rs!j2_premio = "0" Then
                    a.qr("truncate table anom210a", 2)
                    a.qr("insert into anom210a select * from anom210", 2)
                    a.qr("update anom402 set j2_premio='1' where j2_semana=(select i4_ano_sem from anom304)", 2)
                End If
            End If
            While True
                unir = Val(InputBox("Unir premio de zafra anterior, primer premio de la zafra, teclear semana:"))
                If unir = 0 Then
                    Exit While
                Else
                    a.qr("unir_premio_zafra " + unir.ToString, 2)
                End If
            End While
            a.qr("premio '" + mes + "'", 2)
            MsgBox("Proceso terminado")
        Else
            MsgBox("Semana no creada para proceso")
        End If
    End Sub
    Private Sub CambiarSemanaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarSemanaToolStripMenuItem.Click
        Dim sem = 0
        While True
            sem = Val(InputBox("Semana: "))
            a.qr("select * from anom201 where h1_semana=" + sem.ToString, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        a.qr("update anom304 set i4_ano_sem=" + sem.ToString, 2)
        a.qr("update anom304 set  i4_inisem=(select h1_fecha_ini from anom201 where h1_semana=i4_ano_sem)," +
                 " i4_finsem=(select h1_fecha_fin from anom201 where h1_semana=i4_ano_sem)," +
                 " i4_numfes=(select count(*) from anom202,anom201 where h2_festivo='S' and h2_fecha between h1_fecha_ini and h1_fecha_fin and h1_semana=i4_ano_sem)," +
                 " i4_ciclo=(select case when h1_ciclo=1 then 'Z' else 'R' end from anom201 where h1_semana=i4_ano_sem)," +
                 " i4_numsem=(select right(convert(char(6),i4_ano_sem),2))", 2)
        lbl_sem_activa.Text = sem.ToString
        estados()
        MsgBox("Proceso realizado")
    End Sub

    Private Sub DeduccionesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeduccionesToolStripMenuItem1.Click
        Dim sem = 202001
        a.qr("select j2_premio from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
        a.rs.Read()
        If Val(a.rs!j2_premio) < 2 Then
            MsgBox("Faltan procesos anteriores, revisar")
            Exit Sub
        End If
        a.qr("select i4_ano_sem from anom304", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            sem = a.rs!i4_ano_sem
            If MsgBox("Procesar deducciones " + sem.ToString + "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                a.qr("premio_deduc " + sem.ToString, 2)
                a.qr("update anom402 set j2_premio=3 where j2_semana=(select i4_ano_sem from anom304)", 2)
                MsgBox("Proceso realizado")
            End If
        End If
    End Sub

    Private Sub CierreDePremioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreDePremioToolStripMenuItem.Click
        Dim sem = 202001
        a.qr("select j2_premio from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
        a.rs.Read()
        If Val(a.rs!j2_premio) < 3 Then
            MsgBox("Faltan procesos anteriores, revisar")
            Exit Sub
        End If
        a.qr("select i4_ano_sem from anom304", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            sem = a.rs!i4_ano_sem
            If MsgBox("Cargar acumulado de nomina semana (anom401)" + sem.ToString + "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                a.qr("carga_301_401 " + sem.ToString + ",2", 2)
                a.qr("update anom402 set j2_premio=4 where j2_semana=(select i4_ano_sem from anom304)", 2)
                a.qr("exec cargar_pension 2", 2)
                correo("El proceso de premio ya fue ejecutado, por favor revisar los calculos para continuar el proceso.", "Proceso Nomina Semana " + sem.ToString)
                MsgBox("Proceso realizado")
            End If
        End If
    End Sub

    Private Sub DeduccionesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeduccionesToolStripMenuItem2.Click
        Dim sem = 0
        a.qr("select i4_ano_sem from anom304", 1)
        a.rs.Read()
        sem = a.rs!i4_ano_sem
        a.qr("select * from anom402 where j2_semana=" + sem.ToString, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            If a.rs!j2_saldos = "S" Then
                MsgBox("Semana ya procesada")
                Exit Sub
            End If
            If a.rs!j2_saldos = "N" Then
                MsgBox("Saldos no cerrados")
                Exit Sub
            End If
            If a.rs!j2_procesado = "N" Then
                MsgBox("Pagos extras no cerrados")
                Exit Sub
            End If
        Else
            MsgBox("Semana no creada aun (" + sem.ToString + ")")
        End If
        If MsgBox("Procesar deducciones " + sem.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            trd_nomina = Nothing
            trd_nomina = New Thread(AddressOf proceso)
            trd_nomina.IsBackground = True
            trd_nomina.Start()
        Else
            MsgBox("Proceso cancelado")
        End If
    End Sub

    Private Sub CargarAsistenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarAsistenciaToolStripMenuItem.Click
        Dim sem = 0
        a.qr("select i4_ano_sem from anom304", 1)
        a.rs.Read()
        sem = a.rs!i4_ano_sem
        a.qr("select count(*) from anom203 where h3_semana=" + sem.ToString + " group by h3_tponom,h3_numtra,h3_fecha having count(*)>1", 1)
        If a.rs.HasRows Then
            MsgBox("Trabajadores duplicados, revisar captura")
            Exit Sub
        End If
        a.qr("select * from anom402 where j2_semana=" + sem.ToString, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            If a.rs!j2_saldos = "S" Then
                MsgBox("Semana ya procesada")
                Exit Sub
            End If
            If a.rs!j2_saldos = "N" Then
                MsgBox("Saldos no cerrados")
                Exit Sub
            End If
            If a.rs!j2_procesado = "N" Then
                MsgBox("Pagos extras no cerrados")
                Exit Sub
            End If
        Else
            MsgBox("Semana no creada aun (" + sem.ToString + ")")
        End If
        If MsgBox("Cargar asistencia " + sem.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ToolStripStatusLabel1.Text = "Procesando carga de nomina"
            bar_estado.BackColor = Color.LightPink
            trd_carga = Nothing
            trd_carga = New Thread(AddressOf carga_asis)
            trd_carga.IsBackground = True
            trd_carga.Start()
        Else
            MsgBox("Proceso cancelado")
        End If
    End Sub

    Private Sub ActualizarSaldosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarSaldosToolStripMenuItem.Click
        Dim sem = 0
        a.qr("select i4_ano_sem from anom304", 1)
        a.rs.Read()
        sem = a.rs!i4_ano_sem
        a.qr("select j2_saldos from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            If a.rs!j2_saldos = "A" Then
                If MsgBox("Actualizar acumulado de saldos (Debe estar procesada la nomina de becarios y jubilados)?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    a.qr("actualiza_saldos_114 " + sem.ToString, 2)
                    a.qr("update anom402 set j2_saldos='S' where j2_semana=" + sem.ToString, 2)
                    a.qr("exec aplic_comite " + sem.ToString, 2)
                    a.qr("exec cargar_pension 1", 2)
                    a.qr("exec act_ultim_fec_catego", 2)
                    MsgBox("Proceso realizado")
                    correo("El proceso de nomina fue concluido.", "Nomina correcta semana " + sem.ToString)
                End If
            Else
                If a.rs!j2_saldos = "S" Then
                    MsgBox("Saldos cerrados")
                Else
                    MsgBox("Los saldos no estan cerrados")
                End If
            End If
        End If
    End Sub

    Private Sub GenerarAcumuladoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarAcumuladoToolStripMenuItem1.Click
        Dim sem = 202001
        a.qr("select j2_saldos from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            If a.rs!j2_saldos = "S" Then
                MsgBox("Semana ya procesada")
                Exit Sub
            End If
        End If
        a.qr("exec deptos_301", 2)
        a.qr("update anom301 set i1_cvenom=1", 2)
        a.qr("select i4_ano_sem from anom304", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            sem = a.rs!i4_ano_sem
            If MsgBox("Cargar acumulado de nomina semana (anom401)" + sem.ToString + "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                a.qr("carga_301_401 " + sem.ToString + ",1", 2)
                MsgBox("Proceso realizado")
                correo("El proceso de nomina ya fue ejecutado, por favor revisar los calculos para continuar el proceso.", "Proceso Nomina Semana " + sem.ToString)
            End If
        End If
    End Sub

    Private Sub bot_cerrar_saldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_cerrar_saldos.Click
        a.qr("select j2_saldos from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
        a.rs.Read()
        If a.rs!j2_saldos = "N" Then
            a.qr("truncate table anom114a", 2)
            a.qr("update anom114 set g14_cuorec=0,g14_semana=(select i4_ano_sem from anom304)", 2)
            a.qr("insert into anom114a select * from anom114", 2)
            a.qr("update anom402 set j2_saldos='A' where j2_semana=(select i4_ano_sem from anom304)", 2)
            MsgBox("Proceso realizado")
        Else
            estados()
            MsgBox("Saldos cerrados")
        End If
    End Sub
    Private Sub ReporteCorporativoDetalleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCorporativoDetalleToolStripMenuItem.Click
        Dim semana = 0
        Dim per = ""
        Dim ruta = ""
        Dim archivo = "c:\temp\rep_nomina_corp_"
        Dim hoja As Worksheet
        Dim libro As Workbook
        Dim fila = 5
        a.qr("select h1_semana sem,convert(char(10),h1_fecha_ini,103)+' AL '+convert(char(10),h1_fecha_fin,103) per,valor " +
            " from anom201,anom304,parametros" +
            " where i4_ano_sem=h1_semana" +
            " and tipo=1" +
            " and clave='reportes'", 1)
        a.rs.Read()
        semana = a.rs!sem
        per = a.rs!per
        archivo = archivo + semana.ToString + ".xlsx"
        Try
            If File.Exists(archivo) Then
                My.Computer.FileSystem.DeleteFile(archivo)
            End If
        Catch ex As Exception
            MsgBox("Archivo se encuentra abierto: " + archivo)
            Exit Sub
        End Try
        libro = New Workbook
        libro.LoadFromFile("\\192.168.80.4\Aplicaciones\Nomina\reportes\rep_corp_001.xlsx")
        hoja = libro.Worksheets(0)
        a.qr("exec rep_nomina_corp 1,1," + semana.ToString, 1)
        While a.rs.Read
            hoja.Range(fila, 1).NumberValue = a.rs.Item(0)
            hoja.Range(fila, 2).Text = a.rs.Item(1)
            hoja.Range(fila, 3).NumberValue = a.rs.Item(2)
            hoja.Range(fila, 4).Text = a.rs.Item(3)
            hoja.Range(fila, 5).NumberValue = a.rs.Item(4)
            hoja.Range(fila, 6).NumberValue = a.rs.Item(5)
            hoja.Range(fila, 7).NumberValue = a.rs.Item(6)
            hoja.Range(fila, 8).Text = Mid(a.rs.Item(7), 1, 10)
            hoja.Range(fila, 8).Style.NumberFormat = "DD/MM/yyyy"
            hoja.Range(fila, 9).NumberValue = a.rs.Item(8)
            hoja.Range(fila, 10).NumberValue = a.rs.Item(9)
            hoja.Range(fila, 11).Text = a.rs.Item(10)
            hoja.Range(fila, 12).NumberValue = a.rs.Item(11)
            hoja.Range(fila, 13).NumberValue = a.rs.Item(12)
            hoja.Range(fila, 14).NumberValue = a.rs.Item(13)
            fila += 1
        End While
        hoja.Range("b2").NumberValue = semana
        hoja.Range("b3").Text = per
        hoja.Range("H1").Formula = "=SUMAR.SI(C5:C40000," + Chr(34) + "<400" + Chr(34) + ",E5:E40000)"
        hoja.Range("L1").Formula = "=SUMAR.SI(C5:C40000," + Chr(34) + ">399" + Chr(34) + ",E5:E40000)*-1"
        hoja.Range("H2").Formula = "=H1-L1"
        hoja = libro.Worksheets(1)
        fila = 5
        a.qr("exec rep_nomina_corp 1,2," + semana.ToString, 1)
        While a.rs.Read
            hoja.Range(fila, 1).NumberValue = a.rs.Item(0)
            hoja.Range(fila, 2).Text = a.rs.Item(1)
            hoja.Range(fila, 3).NumberValue = a.rs.Item(2)
            hoja.Range(fila, 4).Text = a.rs.Item(3)
            hoja.Range(fila, 5).NumberValue = a.rs.Item(4)
            hoja.Range(fila, 6).NumberValue = a.rs.Item(5)
            hoja.Range(fila, 7).NumberValue = a.rs.Item(6)
            hoja.Range(fila, 8).Text = Mid(a.rs.Item(7), 1, 10)
            hoja.Range(fila, 8).Style.NumberFormat = "DD/MM/yyyy"
            hoja.Range(fila, 9).NumberValue = a.rs.Item(8)
            hoja.Range(fila, 10).NumberValue = a.rs.Item(9)
            hoja.Range(fila, 11).Text = a.rs.Item(10)
            hoja.Range(fila, 12).NumberValue = a.rs.Item(11)
            hoja.Range(fila, 13).NumberValue = a.rs.Item(12)
            hoja.Range(fila, 14).NumberValue = a.rs.Item(13)
            fila += 1
        End While
        hoja.Range("b2").NumberValue = semana
        hoja.Range("b3").Text = per
        hoja.Range("H1").Formula = "=SUMAR.SI(C5:C40000," + Chr(34) + "<400" + Chr(34) + ",E5:E40000)"
        hoja.Range("L1").Formula = "=SUMAR.SI(C5:C40000," + Chr(34) + ">399" + Chr(34) + ",E5:E40000)*-1"
        hoja.Range("H2").Formula = "=H1-L1"
        libro.SaveToFile(archivo, ExcelVersion.Version2010)
        MsgBox("Proceso terminado")
    End Sub
    Private Sub SaldosNom310ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosNom310ToolStripMenuItem.Click
        Dim semana = 0
        Dim per = ""
        Dim ruta = ""
        Dim archivo = "c:\temp\rep_nom310_"
        Dim currentFormula As String = String.Empty
        Dim hoja As Worksheet
        Dim libro As Workbook
        Dim fila = 6
        a.qr("select h1_semana sem,convert(char(10),h1_fecha_ini,103)+' AL '+convert(char(10),h1_fecha_fin,103) per,valor " +
            " from anom201,anom304,parametros" +
            " where i4_ano_sem=h1_semana" +
            " and tipo=1" +
            " and clave='reportes'", 1)
        a.rs.Read()
        semana = a.rs!sem
        per = a.rs!per
        ruta = a.rs!valor
        archivo = archivo + semana.ToString + ".xlsx"
        Try
            If File.Exists(archivo) Then
                My.Computer.FileSystem.DeleteFile(archivo)
            End If
        Catch ex As Exception
            MsgBox("Archivo se encuentra abierto: " + archivo)
            Exit Sub
        End Try
        libro = New Workbook
        '=========== REPORTE OBREROS

        hoja = libro.Worksheets(0)
        hoja.Range("A1").Text = "INDUSTRIAL AZUCARERA SAN CRISTOBAL S.A. DE C.V."
        hoja.Range("A1").Style.Font.Size = 16
        hoja.Range("A1").Style.Font.FontName = "Calibri"
        hoja.Range("A2").Text = "NOMINA NORMAL OBREROS SINDICALIZADOS"
        hoja.Range("A1:A2").Style.Font.IsBold = True
        hoja.Range("A1:Q1").Merge()
        hoja.Range("A2:Q2").Merge()
        hoja.Range("N3").Text = "SEMANA"
        hoja.Range("O3").Text = semana
        hoja.Range("P3").Text = per
        hoja.Range("P3:Q3").Merge()
        hoja.Range("N3:Q3").BorderAround(LineStyleType.Medium, Color.Black)
        hoja.Range("N3:Q3").BorderInside(LineStyleType.Medium, Color.Black)
        hoja.Range("N3:Q3").Style.Color = Color.Aquamarine
        hoja.Range("A5:Q5").Style.Font.IsBold = True
        hoja.Range("A5:Q5").BorderAround(LineStyleType.Medium, Color.Black)
        hoja.Range("A5:Q5").Style.Color = Color.DarkSeaGreen
        hoja.Range("A3:Q3").Style.HorizontalAlignment = HorizontalAlignment.Center
        hoja.Range("A5:Q5").Style.HorizontalAlignment = HorizontalAlignment.Center
        hoja.Range("A1:Q2").Style.HorizontalAlignment = HorizontalAlignment.Center
        'ENCABEZADOS
        hoja.Range("A5").Text = "NUMTRA"
        hoja.Range("B5").Text = "RFC"
        hoja.Range("C5").Text = "NOMBRE"
        hoja.Range("D5").Text = "DIAS"
        hoja.Range("E5").Text = "DEPTO"
        hoja.Range("F5").Text = "NOMDEPTO"
        hoja.Range("G5").Text = "NORMAL"
        hoja.Range("H5").Text = "6TO DIA"
        hoja.Range("I5").Text = "7MO DIA"
        hoja.Range("J5").Text = "OTROS"
        hoja.Range("K5").Text = "PERCEPCIONES"
        hoja.Range("L5").Text = "ISR"
        hoja.Range("M5").Text = "IMSS"
        hoja.Range("N5").Text = "COU.SINDI"
        hoja.Range("O5").Text = "OTROS"
        hoja.Range("P5").Text = "DEDUCCIONES"
        hoja.Range("Q5").Text = "NETO A PAGAR"
        a.qr("exec rep_nomina_310 1,1", 1)
        While a.rs.Read
            hoja.Range(fila, 1).NumberValue = a.rs.Item(1)
            hoja.Range(fila, 2).Text = a.rs.Item(2)
            hoja.Range(fila, 3).Text = a.rs.Item(3)
            hoja.Range(fila, 4).NumberValue = a.rs.Item(4)
            hoja.Range(fila, 5).NumberValue = a.rs.Item(5)
            hoja.Range(fila, 6).Text = a.rs.Item(6)
            hoja.Range(fila, 7).NumberValue = a.rs.Item(7)
            hoja.Range(fila, 8).NumberValue = a.rs.Item(8)
            hoja.Range(fila, 9).NumberValue = a.rs.Item(9)
            hoja.Range(fila, 10).NumberValue = a.rs.Item(10)
            hoja.Range(fila, 11).Formula = "=SUM(G" + fila.ToString + ":J" + fila.ToString + ")"
            hoja.Range(fila, 12).NumberValue = a.rs.Item(11)
            hoja.Range(fila, 13).NumberValue = a.rs.Item(12)
            hoja.Range(fila, 14).NumberValue = a.rs.Item(13)
            hoja.Range(fila, 15).NumberValue = a.rs.Item(14)
            hoja.Range(fila, 16).Formula = "=SUM(L" + fila.ToString + ":O" + fila.ToString + ")"
            hoja.Range(fila, 17).Formula = "=K" + fila.ToString + "-P" + fila.ToString
            fila += 1
        End While
        fila -= 1
        hoja.Range("J3").Text = "TOTAL"
        hoja.Range("K3").Formula = "=+SUM(Q6:Q5000)"
        hoja.Range("K3").NumberFormat = "#,##0.00"
        hoja.Range("J3:K3").BorderAround(LineStyleType.Medium, Color.Black)
        hoja.Range("J3:K3").BorderInside(LineStyleType.Medium, Color.Black)
        hoja.Range("J3:K3").Style.Color = Color.LightBlue
        hoja.Range("G6:Q5000").NumberFormat = "#,##0.00"
        hoja.Range("A5:Q" + fila.ToString).BorderInside(LineStyleType.Thin, Color.Black)
        hoja.Range("A5:Q" + fila.ToString).BorderAround(LineStyleType.Thin, Color.Black)
        hoja.AllocatedRange.AutoFitColumns()

        '=========== REPORTE EMPLEADOS
        fila = 6
        hoja = libro.Worksheets(1)
        hoja.Range("A1").Text = "INDUSTRIAL AZUCARERA SAN CRISTOBAL S.A. DE C.V."
        hoja.Range("A1").Style.Font.Size = 16
        hoja.Range("A1").Style.Font.FontName = "Calibri"
        hoja.Range("A2").Text = "NOMINA NORMAL PERSONAL DE CONFIANZA"
        hoja.Range("A1:A2").Style.Font.IsBold = True
        hoja.Range("A1:Q1").Merge()
        hoja.Range("A2:Q2").Merge()
        hoja.Range("N3").Text = "SEMANA"
        hoja.Range("O3").Text = semana
        hoja.Range("P3").Text = per
        hoja.Range("P3:Q3").Merge()
        hoja.Range("N3:Q3").BorderAround(LineStyleType.Medium, Color.Black)
        hoja.Range("N3:Q3").BorderInside(LineStyleType.Medium, Color.Black)
        hoja.Range("N3:Q3").Style.Color = Color.Aquamarine
        hoja.Range("A5:Q5").Style.Font.IsBold = True
        hoja.Range("A5:Q5").BorderAround(LineStyleType.Medium, Color.Black)
        hoja.Range("A5:Q5").Style.Color = Color.DarkSeaGreen
        hoja.Range("A3:Q3").Style.HorizontalAlignment = HorizontalAlignment.Center
        hoja.Range("A5:Q5").Style.HorizontalAlignment = HorizontalAlignment.Center
        hoja.Range("A1:Q2").Style.HorizontalAlignment = HorizontalAlignment.Center
        'ENCABEZADOS
        hoja.Range("A5").Text = "NUMTRA"
        hoja.Range("B5").Text = "RFC"
        hoja.Range("C5").Text = "NOMBRE"
        hoja.Range("D5").Text = "DIAS"
        hoja.Range("E5").Text = "DEPTO"
        hoja.Range("F5").Text = "NOMDEPTO"
        hoja.Range("G5").Text = "NORMAL"
        hoja.Range("H5").Text = "6TO DIA"
        hoja.Range("I5").Text = "7MO DIA"
        hoja.Range("J5").Text = "OTROS"
        hoja.Range("K5").Text = "PERCEPCIONES"
        hoja.Range("L5").Text = "ISR"
        hoja.Range("M5").Text = "IMSS"
        hoja.Range("N5").Text = "COU.SINDI"
        hoja.Range("O5").Text = "OTROS"
        hoja.Range("P5").Text = "DEDUCCIONES"
        hoja.Range("Q5").Text = "NETO A PAGAR"
        a.qr("exec rep_nomina_310 1,2", 1)
        While a.rs.Read
            hoja.Range(fila, 1).NumberValue = a.rs.Item(1)
            hoja.Range(fila, 2).Text = a.rs.Item(2)
            hoja.Range(fila, 3).Text = a.rs.Item(3)
            hoja.Range(fila, 4).NumberValue = a.rs.Item(4)
            hoja.Range(fila, 5).NumberValue = a.rs.Item(5)
            hoja.Range(fila, 6).Text = a.rs.Item(6)
            hoja.Range(fila, 7).NumberValue = a.rs.Item(7)
            hoja.Range(fila, 8).NumberValue = a.rs.Item(8)
            hoja.Range(fila, 9).NumberValue = a.rs.Item(9)
            hoja.Range(fila, 10).NumberValue = a.rs.Item(10)
            hoja.Range(fila, 11).Formula = "=SUM(G" + fila.ToString + ":J" + fila.ToString + ")"
            hoja.Range(fila, 12).NumberValue = a.rs.Item(11)
            hoja.Range(fila, 13).NumberValue = a.rs.Item(12)
            hoja.Range(fila, 14).NumberValue = a.rs.Item(13)
            hoja.Range(fila, 15).NumberValue = a.rs.Item(14)
            hoja.Range(fila, 16).Formula = "=SUM(L" + fila.ToString + ":O" + fila.ToString + ")"
            hoja.Range(fila, 17).Formula = "=K" + fila.ToString + "-P" + fila.ToString
            fila += 1
        End While
        fila -= 1
        hoja.Range("J3").Text = "TOTAL"
        hoja.Range("K3").Formula = "=+SUM(Q6:Q5000)"
        hoja.Range("K3").NumberFormat = "#,##0.00"
        hoja.Range("J3:K3").BorderAround(LineStyleType.Medium, Color.Black)
        hoja.Range("J3:K3").BorderInside(LineStyleType.Medium, Color.Black)
        hoja.Range("J3:K3").Style.Color = Color.LightBlue
        hoja.Range("G6:Q5000").NumberFormat = "#,##0.00"
        hoja.Range("A5:Q" + fila.ToString).BorderInside(LineStyleType.Thin, Color.Black)
        hoja.Range("A5:Q" + fila.ToString).BorderAround(LineStyleType.Thin, Color.Black)
        hoja.AllocatedRange.AutoFitColumns()

        ' ================== GUARDAR LIBRO

        libro.SaveToFile(archivo, ExcelVersion.Version2010)
        Process.Start(archivo)

    End Sub

    Private Sub CifraControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CifraControlToolStripMenuItem.Click
        Dim suma = 0.0
        Dim total = 0.0
        Dim tipo = 1
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\cifra_control_" + lbl_sem_activa.Text + ".txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("  INDUSTRIAL AZUCARERA SAN CRISTOBAL S.A. DE C.V.")
        sw.WriteLine("  CIFRA CONTROL DE LA NOMINA SEMANAL " + lbl_sem_activa.Text)
        sw.WriteLine(" ========================================================")
        sw.WriteLine("  TPONOM   CPTO  DESCRIP                      IMPORTE")
        sw.WriteLine(" ========================================================")
        sw.WriteLine("")
        sw.WriteLine(" == NOMINA OBREROS ==")
        sw.WriteLine("")
        a.qr("rep_cifracontrol 1,1", 1)
        While a.rs.Read
            If tipo = a.rs!tipo Then
                sw.WriteLine("  1       " +
                            String.Format("{0,3}", a.rs.Item(1)) + "    " +
                            String.Format("{0,-25}", Mid(a.rs.Item(2), 1, 25)) + "  " +
                            String.Format("{0,12}", a.rs.Item(3)))
                suma = suma + a.rs.Item(3)
                total = total + a.rs.Item(3)
            Else
                tipo = a.rs!tipo
                sw.WriteLine("")
                sw.WriteLine(String.Format("{0,56}", suma))
                sw.WriteLine("")
                sw.WriteLine("  1       " +
                            String.Format("{0,3}", a.rs.Item(1)) + "    " +
                            String.Format("{0,-25}", Mid(a.rs.Item(2), 1, 25)) + "  " +
                            String.Format("{0,12}", a.rs.Item(3)))
                suma = a.rs.Item(3)
                total = total + a.rs.Item(3)
            End If
        End While
        sw.WriteLine("")
        sw.WriteLine(String.Format("{0,56}", suma))
        sw.WriteLine("")
        sw.WriteLine(String.Format("{0,56}", total))
        sw.WriteLine("")
        sw.WriteLine(" == NOMINA EMPLEADOS ==")
        sw.WriteLine("")
        suma = 0
        total = 0
        tipo = 1
        a.qr("rep_cifracontrol 1,2", 1)
        While a.rs.Read
            If tipo = a.rs!tipo Then
                sw.WriteLine("  2       " +
                            String.Format("{0,3}", a.rs.Item(1)) + "    " +
                            String.Format("{0,-25}", Mid(a.rs.Item(2), 1, 25)) + "  " +
                            String.Format("{0,12}", a.rs.Item(3)))
                suma = suma + a.rs.Item(3)
                total = total + a.rs.Item(3)
            Else
                tipo = a.rs!tipo
                sw.WriteLine("")
                sw.WriteLine(String.Format("{0,56}", suma))
                sw.WriteLine("")
                sw.WriteLine("  2       " +
                            String.Format("{0,3}", a.rs.Item(1)) + "    " +
                            String.Format("{0,-25}", Mid(a.rs.Item(2), 1, 25)) + "  " +
                            String.Format("{0,12}", a.rs.Item(3)))
                suma = a.rs.Item(3)
                total = total + a.rs.Item(3)
            End If
        End While
        sw.WriteLine("")
        sw.WriteLine(String.Format("{0,56}", suma))
        sw.WriteLine("")
        sw.WriteLine(String.Format("{0,56}", total))
        sw.WriteLine("")
        suma = 0
        total = 0
        sw.Close()
        Process.Start(fic)
    End Sub

    Private Sub SaldosDesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosDesToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\saldos_semana_" + lbl_sem_activa.Text + ".csv"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("TPONOM,CPTO,DESCRIP,NUMTRA,NOMBRE,SALINI,SALANT,CUOREC,SALDO")
        a.qr("select * from rep_saldos_114 order by 1,2,4", 1)
        While a.rs.Read
            sw.WriteLine(
                    a.rs.Item(0).ToString + "," +
                    a.rs.Item(1).ToString + "," +
                    a.rs.Item(2).ToString + "," +
                    a.rs.Item(3).ToString + "," +
                    a.rs.Item(4).ToString + "," +
                    a.rs.Item(5).ToString + "," +
                    a.rs.Item(6).ToString + "," +
                    a.rs.Item(7).ToString + "," +
                    a.rs.Item(8).ToString + ","
                    )
        End While
        sw.Close()
        Process.Start(fic)
    End Sub

    Private Sub ReportesPremioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesPremioToolStripMenuItem.Click
        a.qr("dias_premio '01/08/2020'", 1)
        While a.rs.Read

        End While
    End Sub

    Private Sub CerrarNominaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarNominaToolStripMenuItem.Click
        If InputBox("Codigo de reproceso") = "146352" Then
            If MsgBox("Reprocesar nomina?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                a.qr("truncate table anom114", 2)
                a.qr("insert into anom114 select * from anom114a", 2)
                a.qr("delete from anom502 where k2_tponom in (5,6) and k2_semana=(select i4_ano_sem from anom304)", 2)
                a.qr("update anom402 set j2_saldos='A' where j2_semana=(select i4_ano_sem from anom304)", 2)
                MsgBox("Proceso realizado, se puede volver a correr proceso de nomina")
            End If
        Else
            MsgBox("Clave incorrecta")
        End If
    End Sub
    Private Sub DispersionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DispersionToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\disper_sem_" + lbl_sem_activa.Text + ".csv"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("TPONOM,NUMTRA,NOMBRE,CUENTA,PROPIAS,SPEI,SINCUENTA")
        a.qr("select * from rep_dispersion order by 1", 1)
        While a.rs.Read
            sw.WriteLine(
                a.rs.Item(0).ToString + "," +
                a.rs.Item(1).ToString + "," +
                a.rs.Item(2).ToString + "," +
                a.rs.Item(3).ToString + "," +
                a.rs.Item(4).ToString + "," +
                a.rs.Item(5).ToString + "," +
                a.rs.Item(6).ToString + ","
                )
        End While
        sw.Close()
        Process.Start(fic)
    End Sub

    Private Sub PensionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PensionesToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\pension_sem_" + lbl_sem_activa.Text + ".csv"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("TPONOM,NUMTRA,NOMBRE,CONSE,CLAVE,BENEFICIARIO,NOMBRE,IMPORTE")
        a.qr("rep_pensiones 1,1", 1)
        While a.rs.Read
            sw.WriteLine(
                    a.rs.Item(0).ToString + "," +
                    a.rs.Item(1).ToString + "," +
                    a.rs.Item(2).ToString + "," +
                    a.rs.Item(3).ToString + "," +
                    a.rs.Item(4).ToString + "," +
                    a.rs.Item(5).ToString + "," +
                    a.rs.Item(6).ToString + "," +
                    a.rs.Item(7).ToString
                    )
        End While
        a.qr("rep_pensiones 1,2", 1)
        While a.rs.Read
            sw.WriteLine(
                    a.rs.Item(0).ToString + "," +
                    a.rs.Item(1).ToString + "," +
                    a.rs.Item(2).ToString + "," +
                    a.rs.Item(3).ToString + "," +
                    a.rs.Item(4).ToString + "," +
                    a.rs.Item(5).ToString + "," +
                    a.rs.Item(6).ToString + "," +
                    a.rs.Item(7).ToString
                    )
        End While
        sw.Close()
        Process.Start(fic)
    End Sub

    Private Sub EnvioDeRecibosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvioDeRecibosToolStripMenuItem.Click
        Dim di As IO.DirectoryInfo
        Dim diar1 As IO.FileInfo()
        Dim dra As IO.FileInfo
        Dim cont = 0
        Dim numtra = 0
        Dim tipo = ""
        Dim archivo = ""
        Dim texto = "Industrial Azucarera San Cristobal S.A. de C.V." + Chr(13) + Chr(13)
        texto = texto + "Con el fin de dar cumplimiento a lo establecido en los artículos 29, fracción V del CFF y 99, fracción III de la Ley del ISR, a través del presente correo le hacemos llegar su CFDI (xml y representación impresa en pdf) correspondientes al período:"
        Dim semana = ""
        Dim ruta = ""
        a.qr("select valor from parametros where tipo=1 and clave='recibos'", 1)
        a.rs.Read()
        ruta = a.rs!valor
        While True
            semana = InputBox("Semana de pago:")
            a.qr("select ' semana '+convert(varchar,h1_semana)+', del '+convert(char(11),h1_fecha_ini,106)+' al '+convert(char(11),h1_fecha_fin,106) concepto from anom201 where h1_semana=" + semana.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                texto = texto + a.rs!concepto
                Exit While
            End If
        End While
        tipo = UCase(InputBox("Tipo de pago (N,A,P,...)"))
        numtra = Val(InputBox("Reenvio, numero de trabajador:"))
        If numtra > 0 Then
            a.qr("update bitacora_recibos set enviado=0 where semana=" + semana.ToString + " and numtra=" + numtra.ToString + " and tipo='" + tipo + "'", 2)
        End If
        If tipo = "N" Then
            a.qr("insert into bitacora_recibos" +
                " select distinct j1_numtra,null," + semana + ",0,2,'" + tipo + "' from anom401" +
                " where j1_semana = " + semana.ToString +
                " and j1_cpto<400" +
                " and j1_cpto>0" +
                " and j1_tponom=2" +
                " and j1_numtra not in (select numtra from bitacora_recibos where semana=" + semana + ")", 2)
        Else
            a.qr("select * from bitacora_recibos where semana=" + semana.ToString + " and tipo='" + tipo + "'", 1)
            If Not a.rs.HasRows Then
                a.qr("insert into bitacora_recibos" +
                    " select distinct k2_numtra,null,k2_semana,0,2,k2_tipo from anom502" +
                    " where k2_semana=" + semana.ToString +
                    " and k2_tponom=2" +
                    " and k2_tipo='" + tipo + "'", 2)
            End If
        End If
        If tipo = "N" Then
            If Directory.Exists(ruta + "empleados\" + semana.ToString) Then
                di = New IO.DirectoryInfo(ruta + "empleados\" + semana.ToString)
                diar1 = di.GetFiles("*.pdf")
                For Each dra In diar1
                    numtra = Val(Mid(dra.ToString, 25, 5))
                    archivo = Mid(dra.ToString, 1, Len(dra.ToString) - 3)
                    a.qr("select enviado from bitacora_recibos where numtra=" + numtra.ToString + " and semana=" + semana, 1)
                    If a.rs.HasRows Then
                        a.rs.Read()
                        If numtra > 0 And a.rs!enviado <> 1 Then
                            a.qr("select descrip from catalogos where familia=21 and tipo=" + numtra.ToString, 1)
                            If a.rs.HasRows Then
                                a.rs.Read()
                                correorecibo(a.rs!descrip, ruta + "empleados\" + semana.ToString + "\" + archivo, texto + Chr(13) + Chr(13), semana, "nomina")
                            End If
                        End If
                    End If
                Next
            End If
        Else
            If Directory.Exists(ruta + "empleados\" + semana.ToString + "\" + tipo) Then
                di = New IO.DirectoryInfo(ruta + "empleados\" + semana.ToString + "\" + tipo)
                diar1 = di.GetFiles("*.pdf")
                For Each dra In diar1
                    numtra = Val(Mid(dra.ToString, 25, 5))
                    archivo = Mid(dra.ToString, 1, Len(dra.ToString) - 3)
                    a.qr("select enviado from bitacora_recibos where numtra=" + numtra.ToString + " and semana=" + semana + " and tipo='" + tipo + "'", 1)
                    If a.rs.HasRows Then
                        a.rs.Read()
                        If numtra > 0 And a.rs!enviado <> 1 Then
                            a.qr("select descrip from catalogos where familia=21 and tipo=" + numtra.ToString, 1)
                            If a.rs.HasRows Then
                                a.rs.Read()
                                correorecibo(a.rs!descrip, ruta + "empleados\" + semana.ToString + "\" + tipo + "\" + archivo, texto + Chr(13) + Chr(13), semana, "aguinaldo")
                            End If
                        End If
                    End If
                Next
            End If
        End If
        MsgBox("Proceso de envio de recibos terminado")
    End Sub

    Private Sub Nom310PremioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom310PremioToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\nom310_premio_sem_" + lbl_sem_activa.Text + ".csv"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("NUMTRA,RFC,NOMBRE,DIAS,NORMAL,SEXTO,SEPTIMO,OTROS,PERCEP,ISR,IMSS,SINDICATO,OTROS,DEDUC,NETOPAGAR ")
        a.qr("rep_nomina_310 2,1", 1)
        While a.rs.Read
            sw.WriteLine(
                        a.rs.Item(1).ToString + "," +
                        a.rs.Item(2).ToString + "," +
                        a.rs.Item(3).ToString + "," +
                        a.rs.Item(4).ToString + "," +
                        a.rs.Item(7).ToString + "," +
                        a.rs.Item(8).ToString + "," +
                        a.rs.Item(9).ToString + "," +
                        a.rs.Item(10).ToString + "," +
                        (a.rs.Item(7) + a.rs.Item(8) + a.rs.Item(9) + a.rs.Item(10)).ToString + "," +
                        a.rs.Item(11).ToString + "," +
                        a.rs.Item(12).ToString + "," +
                        a.rs.Item(13).ToString + "," +
                        a.rs.Item(14).ToString + "," +
                        (a.rs.Item(11) + a.rs.Item(12) + a.rs.Item(13) + a.rs.Item(14)).ToString + "," +
                        (a.rs.Item(7) + a.rs.Item(8) + a.rs.Item(9) + a.rs.Item(10) - a.rs.Item(11) - a.rs.Item(12) - a.rs.Item(13) - a.rs.Item(14)).ToString
                        )
        End While
        sw.Close()
        Process.Start(fic)
    End Sub

    Private Sub CifraControlToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CifraControlToolStripMenuItem1.Click
        Dim suma = 0.0
        Dim total = 0.0
        Dim tipo = 1
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\cifra_control_" + lbl_sem_activa.Text + ".txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("  INDUSTRIAL AZUCARERA SAN CRISTOBAL S.A. DE C.V.")
        sw.WriteLine("  CIFRA CONTROL DE PREMIO SEMANA " + lbl_sem_activa.Text)
        sw.WriteLine(" ========================================================")
        sw.WriteLine("  TPONOM   CPTO  DESCRIP                      IMPORTE")
        sw.WriteLine(" ========================================================")
        sw.WriteLine("")
        sw.WriteLine(" == PREMIO OBREROS ==")
        sw.WriteLine("")
        a.qr("rep_cifracontrol 2,1", 1)
        While a.rs.Read
            If tipo = a.rs!tipo Then
                sw.WriteLine("  1       " +
                            String.Format("{0,3}", a.rs.Item(1)) + "    " +
                            String.Format("{0,-25}", Mid(a.rs.Item(2), 1, 25)) + "  " +
                            String.Format("{0,12}", a.rs.Item(3)))
                suma = suma + a.rs.Item(3)
                total = total + a.rs.Item(3)
            Else
                tipo = a.rs!tipo
                sw.WriteLine("")
                sw.WriteLine(String.Format("{0,56}", suma))
                sw.WriteLine("")
                sw.WriteLine("  1       " +
                            String.Format("{0,3}", a.rs.Item(1)) + "    " +
                            String.Format("{0,-25}", Mid(a.rs.Item(2), 1, 25)) + "  " +
                            String.Format("{0,12}", a.rs.Item(3)))
                suma = a.rs.Item(3)
                total = total + a.rs.Item(3)
            End If
        End While
        sw.WriteLine("")
        sw.WriteLine(String.Format("{0,56}", suma))
        sw.WriteLine("")
        sw.WriteLine(String.Format("{0,56}", total))
        sw.Close()
        Process.Start(fic)
    End Sub

    Private Sub EventualesCostoDomingoFestivoProyectosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventualesCostoDomingoFestivoProyectosToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\even_cost_domfes.csv"
        Dim sw As System.IO.StreamWriter
        file = System.IO.File.Create(fic)
        file.Close()
        sw = New System.IO.StreamWriter(fic)
        sw.WriteLine("DEPTO,EVENTUALES,COSTO,DOMFES")
        a.qr("rep_even_costo_domfes " + lbl_sem_activa.Text, 1)
        While a.rs.Read
            sw.WriteLine(a.rs.Item(0).ToString + Chr(44) +
                         a.rs.Item(1).ToString + Chr(44) +
                         a.rs.Item(2).ToString + Chr(44) +
                         a.rs.Item(3).ToString)
        End While
        sw.Close()
        MsgBox("Reporte creado: " + fic)
    End Sub

    Private Sub PensionAlimenticiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PensionAlimenticiaToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\pension_premio_" + lbl_sem_activa.Text + ".csv"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine("TPONOM,NUMTRA,NOMBRE,CONSE,CLAVE,BENEFICIARIO,NOMBRE,IMPORTE")
        a.qr("rep_pensiones 2,1", 1)
        While a.rs.Read
            sw.WriteLine(
                    a.rs.Item(0).ToString + "," +
                    a.rs.Item(1).ToString + "," +
                    a.rs.Item(2).ToString + "," +
                    a.rs.Item(3).ToString + "," +
                    a.rs.Item(4).ToString + "," +
                    a.rs.Item(5).ToString + "," +
                    a.rs.Item(6).ToString + "," +
                    a.rs.Item(7).ToString
                    )
        End While
        sw.Close()
        MsgBox("Reporte creado" + fic)
    End Sub

    Private Sub RetencionesContabilidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesContabilidadToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\reten_obrero.csv"
        Dim sw As System.IO.StreamWriter
        file = System.IO.File.Create(fic)
        file.Close()
        sw = New System.IO.StreamWriter(fic)
        sw.WriteLine("PLANTA,CONCEPTO,DESCRIP,DEPTO,IMPORTE")
        a.qr("rep_obreros_deducciones " + lbl_sem_activa.Text, 1)
        While a.rs.Read
            sw.WriteLine(a.rs.Item(0).ToString + Chr(44) +
                         a.rs.Item(1).ToString + Chr(44) +
                         a.rs.Item(2).ToString + Chr(44) +
                         a.rs.Item(3).ToString + Chr(44) +
                         a.rs.Item(4).ToString)
        End While
        sw.Close()
        MsgBox("Reporte creado: " + fic)
        fic = "c:\temp\reten_empleado.csv"
        file = System.IO.File.Create(fic)
        file.Close()
        sw = New System.IO.StreamWriter(fic)
        sw.WriteLine("AREA,CONCEPTO,DESCRIP,IMPORTE")
        a.qr("rep_empleados_deducciones " + lbl_sem_activa.Text, 1)
        While a.rs.Read
            sw.WriteLine(a.rs.Item(0).ToString + Chr(44) +
                         a.rs.Item(1).ToString + Chr(44) +
                         a.rs.Item(2).ToString + Chr(44) +
                         a.rs.Item(3).ToString)
        End While
        sw.Close()
        MsgBox("Reporte creado: " + fic)
    End Sub

    Private Sub lbl_estado_extra_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_estado_extra.DoubleClick
        Dim wb As New Spire.Xls.Workbook
        Dim hoja As Spire.Xls.Worksheet

        MsgBox("prueba de spreadsheetslight")
        If ofd_leer_timbrado.ShowDialog = Windows.Forms.DialogResult.OK Then
            wb.LoadFromFile(ofd_leer_timbrado.FileName)
            hoja = wb.Worksheets(0)
            MsgBox(hoja.Range("B5").Value.ToString)
        End If
        wb = Nothing
        hoja = Nothing
    End Sub

    Private Sub DispersionNominasExtraordinariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DispersionNominasExtraordinariasToolStripMenuItem.Click
        Dim wtipo = "C"
        Dim wtponom = 1
        Dim lin = 2
        Dim wb As New Workbook
        Dim hoja As Worksheet = wb.Worksheets(0)
        While True
            wtipo = InputBox("Tipo de pago:")
            a.qr("select letra from catalogos where familia=3 and letra='" + wtipo + "'", 1)
            If a.rs.HasRows Then
                Exit While
            End If
            If Len(wtipo) = 0 Then
                Exit Sub
            End If
        End While
        While True
            wtponom = Val(InputBox("Tipo de nomina"))
            If wtponom > 0 And wtponom < 20 Then
                Exit While
            End If
            If wtponom = 0 Then
                Exit While
            End If
        End While
        hoja.Range("A1").Text = "NUMTRA"
        hoja.Range("B1").Text = "NOMBRE"
        hoja.Range("C1").Text = "CUENTA"
        hoja.Range("D1").Text = "IMPORTE"
        hoja.Range("A1:D1").Style.Color = Color.LightGreen
        hoja.Range("A1:D1").Style.Font.IsBold = True
        hoja.Range("A1:D1").Style.HorizontalAlignment = HorizontalAlignType.Center
        hoja.SetColumnWidth(2, 50)
        hoja.SetColumnWidth(3, 20)
        hoja.SetColumnWidth(3, 12)
        a.qr("rep_cuentas_disper " + wtponom.ToString + "," + lbl_sem_activa.Text + ",'" + wtipo + "'", 1)
        If a.rs.HasRows Then
            While a.rs.Read
                hoja.Range("A" + lin.ToString).NumberValue = a.rs.Item(0)
                hoja.Range("B" + lin.ToString).Text = a.rs.Item(1)
                hoja.Range("C" + lin.ToString).Text = a.rs.Item(2)
                hoja.Range("D" + lin.ToString).NumberValue = a.rs.Item(3)
                lin += 1
            End While
        End If
        hoja.Range("A1:D" + (lin - 1).ToString).BorderInside(LineStyleType.Thin, Color.Black)
        hoja.Range("A1:D" + (lin - 1).ToString).BorderAround(LineStyleType.Thin, Color.Black)
        lin += 1
        hoja.Range("D" + lin.ToString).Formula = "=subtotal(9,D2:D" + (lin - 1).ToString + ")"
        wb.SaveToFile("C:\temp\dispersion_" + wtipo + "_" + lbl_sem_activa.Text + ".xlsx", ExcelVersion.Version2010)
        wb = Nothing
        hoja = Nothing
        MsgBox("Archivo creado: C:\temp\dispersion_" + wtipo + "_" + lbl_sem_activa.Text + ".xlsx")
    End Sub

    Private Sub ReenvioDeRecibosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim semana = ""
        Dim ruta = ""
        Dim texto = "Con el fin de dar cumplimiento a lo establecido en los artículos 29, fracción V del CFF y 99, fracción III de la Ley del ISR, a través del presente correo le hacemos llegar su CFDI (xml y representación impresa en pdf) correspondientes al período:"
        a.qr("select valor from parametros where tipo=1 and clave='recibos'", 1)
        a.rs.Read()
        ruta = a.rs!valor
        While True
            semana = InputBox("Semana de pago:")
            a.qr("select ' semana '+convert(varchar,h1_semana)+', del '+convert(char(11),h1_fecha_ini,106)+' al '+convert(char(11),h1_fecha_fin,106) concepto from anom201 where h1_semana=" + semana.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                texto = texto + a.rs!concepto
                Exit While
            End If
        End While
    End Sub

    Private Sub AbrirSaldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirSaldosToolStripMenuItem.Click
        If InputBox("Clave de reproceso") = "142563" Then
            a.qr("update anom402 set j2_saldos='N',j2_procesado='N' where j2_semana=(select i4_ano_sem from anom304)", 2)
            estados()
            MsgBox("Proceso ejecutado")
        End If
    End Sub

    Private Sub ReporteCorporativoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCorporativoToolStripMenuItem.Click
        Dim semana = 0
        Dim archivo = "c:\temp\rep_nomina_corp_"
        Dim hoja As Worksheet
        Dim libro As Workbook
        Dim fila = 5
        a.qr("select i4_ano_sem from anom304", 1)
        a.rs.Read()
        semana = a.rs!i4_ano_sem
        archivo = archivo + semana.ToString + ".xlsx"
        Try
            If File.Exists(archivo) Then
                My.Computer.FileSystem.DeleteFile(archivo)
            End If
        Catch ex As Exception
            MsgBox("Archivo se encuentra abierto: " + archivo)
            Exit Sub
        End Try
        libro = New Workbook
        libro.LoadFromFile("\\192.168.80.4\Aplicaciones\Nomina\reportes\rep_corp_001.xlsx")
        hoja = libro.Worksheets(2)
        a.qr("exec rep_nomina_corp 2,1," + semana.ToString, 1)
        While a.rs.Read
            hoja.Range(fila, 1).NumberValue = a.rs.Item(0)
            hoja.Range(fila, 2).Text = a.rs.Item(1)
            hoja.Range(fila, 3).NumberValue = a.rs.Item(2)
            hoja.Range(fila, 4).Text = a.rs.Item(3)
            hoja.Range(fila, 5).NumberValue = a.rs.Item(4)
            hoja.Range(fila, 6).NumberValue = a.rs.Item(5)
            hoja.Range(fila, 7).NumberValue = a.rs.Item(6)
            hoja.Range(fila, 8).Text = Mid(a.rs.Item(7), 1, 10)
            hoja.Range(fila, 8).Style.NumberFormat = "DD/MM/yyyy"
            hoja.Range(fila, 9).NumberValue = a.rs.Item(8)
            hoja.Range(fila, 10).NumberValue = a.rs.Item(9)
            hoja.Range(fila, 11).Text = a.rs.Item(10)
            hoja.Range(fila, 12).NumberValue = a.rs.Item(11)
            hoja.Range(fila, 13).NumberValue = a.rs.Item(12)
            hoja.Range(fila, 14).NumberValue = a.rs.Item(13)
            fila += 1
        End While
        hoja.Range("H1").Formula = "=SUMAR.SI(C5:C11992," + Chr(34) + "<400" + Chr(34) + ",E5:E11992)"
        hoja.Range("L1").Formula = "=SUMAR.SI(C5:C11992," + Chr(34) + ">399" + Chr(34) + ",E5:E11992)*-1"
        hoja.Range("H2").Formula = "=H1-L1"
        libro.SaveToFile(archivo, ExcelVersion.Version2010)
        MsgBox("Proceso terminado")
    End Sub

    Private Sub JubiladosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JubiladosToolStripMenuItem.Click
        Dim tipo = 1
        Dim mes = 0
        Dim quincena = 1
        If MsgBox("Procesar jubilados", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        While True
            mes = Val(InputBox("Mes (1-12)"))
            If mes > 0 And mes < 13 Then
                Exit While
            End If
        End While
        While True
            tipo = Val(InputBox("Quincenal (1)  Mensual (2)"))
            If tipo > 0 And tipo < 3 Then
                Exit While
            End If
        End While
        a.qr("truncate table anom503", 2)
        If tipo = 1 Then
            a.qr("insert into anom503 select 3,g11_numtra,152,0,0,g11_importe from anom111 where g11_tipo=1", 2)
        Else
            a.qr("insert into anom503 select 3,g11_numtra,152,0,0,g11_importe from anom111 where g11_tipo=2", 2)
        End If
        a.qr("exec calc_isrpen_recre", 2)
        a.qr("exec calculo_descuentos 3", 2)
        If tipo = 1 Then
            a.qr("delete from anom502 where k2_semana=" + lbl_sem_activa.Text + " and k2_tipo='J'", 2)
            a.qr("delete from anom502 where k2_semana=" + lbl_sem_activa.Text + " and k2_tponom=7", 2)
            While True
                quincena = Val(InputBox("Primera (1)  Segunda (2)"))
                If quincena > 0 And quincena < 3 Then
                    Exit While
                End If
            End While
            a.qr("exec cargar_503 'J'," + quincena.ToString + "," + mes.ToString, 2)
            a.qr("cargar_pension 3", 2)
        Else
            a.qr("delete from anom502 where k2_semana=" + lbl_sem_activa.Text + " and k2_tipo='G'", 2)
            a.qr("delete from anom502 where k2_semana=" + lbl_sem_activa.Text + " and k2_tponom=8", 2)
            a.qr("exec cargar_503 'G',3," + mes.ToString, 2)
            a.qr("cargar_pension 4", 2)
        End If
        a.qr("delete from anom502 where k2_importe=0 and k2_semana=" + lbl_sem_activa.Text, 2)
        MsgBox("Proceso realizado, revisar timbrado")
    End Sub

    Private Sub bot_pre_guardar_Click(sender As Object, e As EventArgs) Handles bot_pre_guardar.Click
        a.qr("insert into anom210b values (" + txt_pre_numtra.Text.ToString + ",52," + txt_pre_dias.Text.ToString + ")", 2)
        a.qr("insert into anom210b values (" + txt_pre_numtra.Text.ToString + ",53," + txt_pre_dias.Text.ToString + ")", 2)
        bot_pre_mostrar.PerformClick()
        txt_pre_numtra.Text = ""
        txt_pre_dias.Text = ""
    End Sub

    Private Sub txt_pre_numtra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_pre_numtra.KeyPress
        If e.KeyChar = Chr(13) Then
            a.qr("select nombre from nombres where numtra=" + txt_pre_numtra.Text.ToString + " and tponom=1", 1)
            If a.rs.HasRows Then
                a.rs.Read()
                txt_pre_nombre.Text = a.rs!nombre
                txt_pre_dias.Focus()
            Else
                MsgBox("Trabajador no existe")
            End If
        End If
    End Sub

    Private Sub txt_pre_dias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_pre_dias.KeyPress
        If e.KeyChar = Chr(13) Then
            bot_pre_guardar.Focus()
        End If
    End Sub

    Private Sub bot_pre_mostrar_Click(sender As Object, e As EventArgs) Handles bot_pre_mostrar.Click
        dgv_premio.Rows.Clear()
        a.qr("select a.numtra,nombre,g4_cpto,g4_nombre,dias from anom210b a,nombres b,anom104" +
            " where a.numtra=b.numtra" +
            " and tponom=1" +
            " and cpto=g4_cpto" +
            " order by 1,3", 1)
        While a.rs.Read
            dgv_premio.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4))
        End While
        dgv_diasno.Rows.Clear()
        a.qr("select convert(char(10),fecha,103) from diasno order by 1", 1)
        While a.rs.Read
            dgv_diasno.Rows.Add(a.rs.Item(0))
        End While
    End Sub

    Private Sub bot_pre_guardar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bot_pre_guardar.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_pre_numtra.Focus()
        End If
    End Sub

    Private Sub dgv_premio_DoubleClick(sender As Object, e As EventArgs) Handles dgv_premio.DoubleClick
        Dim numtra = 0
        numtra = dgv_premio.Rows(dgv_premio.CurrentCellAddress.Y).Cells(0).Value
        If MsgBox("Borrar trabajador: " + numtra.ToString + "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("delete from anom210b where numtra=" + numtra.ToString, 2)
        End If
        bot_pre_mostrar.PerformClick()
    End Sub

    Private Sub bot_pre_procesar_Click(sender As Object, e As EventArgs) Handles bot_pre_procesar.Click
        a.qr("select j2_premio from anom402 where j2_semana=(select i4_ano_sem from anom304)", 1)
        a.rs.Read()
        If a.rs!j2_premio = 1 Then
            a.qr("exec premio_captura", 2)
            a.qr("update anom402 set j2_premio=2 where j2_semana=" + lbl_sem_activa.Text, 2)
            MsgBox("Proceso realizado")
        Else
            MsgBox("Proceso no realizado, cargar asistencia")
        End If
    End Sub

    Private Sub ReporteDeEventualesCorporativoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeEventualesCorporativoToolStripMenuItem.Click
        Dim lin = 4
        Dim wb As New Workbook
        Dim hoja As Worksheet = wb.Worksheets(0)
        hoja.Range("A1").Text = "Reporte de eventuales semana " + lbl_sem_activa.Text
        hoja.Range("A3").Text = "Plantilla personal de confianza"
        a.qr("rep_even_resumen " + lbl_sem_activa.Text + ",1", 1)
        While a.rs.Read
            hoja.Range("A" + lin.ToString).Text = a.rs.Item(0)
            hoja.Range("B" + lin.ToString).NumberValue = a.rs.Item(1)
            lin += 1
        End While
        lin += 1
        hoja.Range("A" + lin.ToString).Text = "Personal extra obreros"
        lin += 1
        hoja.Range("A" + lin.ToString).Text = "DIA"
        hoja.Range("B" + lin.ToString).Text = "CANTIDAD"
        lin += 1
        a.qr("rep_even_resumen " + lbl_sem_activa.Text + ",2", 1)
        While a.rs.Read
            hoja.Range("A" + lin.ToString).Text = a.rs.Item(0)
            hoja.Range("B" + lin.ToString).NumberValue = a.rs.Item(1)
            lin += 1
        End While
        lin += 1
        hoja.Range("A" + lin.ToString).Text = "Personal proyectos obreros"
        lin += 1
        hoja.Range("A" + lin.ToString).Text = "DIA"
        hoja.Range("B" + lin.ToString).Text = "CANTIDAD"
        lin += 1
        a.qr("rep_even_resumen " + lbl_sem_activa.Text + ",3", 1)
        While a.rs.Read
            hoja.Range("A" + lin.ToString).Text = a.rs.Item(0)
            hoja.Range("B" + lin.ToString).NumberValue = a.rs.Item(1)
            lin += 1
        End While

        wb.SaveToFile("C:\temp\eventuales_" + lbl_sem_activa.Text + ".xlsx", ExcelVersion.Version2010)
        wb = Nothing
        hoja = Nothing
        MsgBox("Archivo creado: C:\temp\eventuales_" + lbl_sem_activa.Text + ".xlsx")
    End Sub

    Private Sub BecariosSemanalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BecariosSemanalToolStripMenuItem.Click
        Dim wb As New Workbook
        Dim hoja As Worksheet = wb.Worksheets(0)
        Dim cols = 0
        Dim fil = 0
        Dim fic = "C:\temp\rep_anom503_" + lbl_sem_activa.Text + ".xlsx"
        Dim query = ""
        a.qr("select count(distinct k3_cpto) cols from anom503", 1)
        a.rs.Read()
        cols = a.rs!cols - 1
        Dim encabe(cols) As String
        Dim cptos(cols) As Int16
        a.qr("select distinct k3_cpto,substring(g4_nombre,1,11) cpto from anom503,anom104 where k3_cpto=g4_cpto order by 1", 1)
        While a.rs.Read
            encabe(fil) = a.rs!cpto
            cptos(fil) = a.rs!k3_cpto
            fil = fil + 1
        End While
        fil = 1
        query += "select k3_numtra,nombre,sum(case when k3_cpto=" + cptos(0).ToString + " then k3_importe else 0 end) '" + encabe(0) + "'"
        For fil = 1 To cols
            query += ",sum(case when k3_cpto=" + cptos(fil).ToString + " then k3_importe else 0 end) '" + encabe(fil) + "'"
        Next
        query += " from anom503,nombres" +
                " where k3_numtra=numtra" +
                " and k3_tponom=tponom" +
                " group by k3_numtra,nombre" +
                " order by 1,2"
        a.qr(query, 1)
        hoja.Range(1, 1).Text = "NUMTRA"
        hoja.Range(1, 2).Text = "NOMBRE"
        hoja.Range(1, 3).Text = cptos(0).ToString + "-" + encabe(0)
        For fil = 1 To cols
            hoja.Range(1, fil + 3).Text = cptos(fil).ToString + "-" + encabe(fil)
        Next
        fil = 2
        While a.rs.Read
            Try
                hoja.Range(fil, 1).NumberValue = a.rs.Item(0).ToString
                hoja.Range(fil, 2).Text = a.rs.Item(1).ToString
                hoja.Range(fil, 3).NumberValue = a.rs.Item(2).ToString
                hoja.Range(fil, 3).NumberFormat = "#,##0.00"
                For x = 1 To cols
                    hoja.Range(fil, x + 3).NumberValue = a.rs.Item(x + 2).ToString
                    hoja.Range(fil, x + 3).NumberFormat = "#,##0.00"
                Next
                fil += 1
            Catch ex As Exception
                MsgBox(fil)
            End Try
        End While
        fil -= 1
        hoja.Range("A1:" + a.letra(cols + 3) + "1").Style.Color = Color.DarkSeaGreen
        hoja.Range("A1:" + a.letra(cols + 3) + "1").Style.Font.IsBold = True
        hoja.Range("A1:" + a.letra(cols + 3) + fil.ToString).BorderInside(LineStyleType.Thin, Color.Black)
        hoja.Range("A1:" + a.letra(cols + 3) + fil.ToString).BorderAround(LineStyleType.Thin, Color.Black)
        hoja.Range("A1:" + a.letra(cols + 3) + fil.ToString).Style.Font.FontName = "Calibri"
        hoja.Range("A1:" + a.letra(cols + 3) + fil.ToString).Style.Font.Size = 11
        hoja.AllocatedRange.AutoFitColumns()
        wb.SaveToFile(fic, ExcelVersion.Version2010)
        wb = Nothing
        hoja = Nothing
        MsgBox("Archivo creado: " + fic)
    End Sub

    Private Sub BecariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BecariosToolStripMenuItem.Click
        If MsgBox("Procesar becarios semana " + lbl_sem_activa.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        a.qr("exec calculo_becarios", 2)
        a.qr("exec calculo_descuentos 4", 2)
        a.qr("delete from anom502 where k2_semana=" + lbl_sem_activa.Text + " and k2_tipo='E'", 2)
        a.qr("exec cargar_503 'E',4,1", 2)
        MsgBox("Proceso realizado")
    End Sub

    Private Sub bot_diasno_eliminar_Click(sender As Object, e As EventArgs) Handles bot_diasno_eliminar.Click
        If MsgBox("Eliminar captura dias e incidencias?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("truncate table diasno", 2)
            a.qr("truncate table anom210b", 2)
            bot_pre_mostrar.PerformClick()
        End If
    End Sub

    Private Sub bot_diasno_agregar_Click(sender As Object, e As EventArgs) Handles bot_diasno_agregar.Click
        Dim fecha = ""
        While True
            fecha = InputBox("fecha para excepcion (DD/MM/AAAA): ")
            If Not IsDate(fecha) Then
                Exit While
            End If
            a.qr("select * from diasno where fecha='" + fecha + "'", 1)
            If Not a.rs.HasRows Then
                a.qr("insert into diasno values ('" + fecha + "')", 2)
            End If
            bot_pre_mostrar.PerformClick()
        End While
    End Sub

    Private Sub ISRSubsidioTimbradoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISRSubsidioTimbradoToolStripMenuItem.Click
        Dim objReader As StreamReader
        Dim sLine As String = ""
        Dim isr As Decimal = 0
        Dim subs As Decimal = 0
        Dim bandera = 0
        Dim timbrado = ""
        Dim cad(2) As String
        If ofd_leer_timbrado.ShowDialog = DialogResult.OK Then
            objReader = New StreamReader(ofd_leer_timbrado.FileName)
        Else
            Exit Sub
        End If
        Do
            sLine = objReader.ReadLine()
            cad = Split(sLine, "|")
            If cad(0) = "MonImpR" Then
                isr += Val(cad(1))
            End If
            If cad(0) = "Clave" Then
                If cad(1) = "411" Then
                    bandera = 1
                End If
            End If
            If bandera = 1 Then
                If cad(0) = "ImporteOtroPago" Then
                    subs += Val(cad(1))
                    bandera = 0
                End If
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        MsgBox("ISR: " + isr.ToString + Chr(13) +
               "SUBSIDIO: " + subs.ToString)
    End Sub

    Private Sub CargaDePercepcionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargaDePercepcionesToolStripMenuItem.Click
        Dim ar As StreamReader
        Dim lin() As String
        Dim semana = 0
        Dim cant = 0
        Dim query = ""
        Dim tpotra = "1"
        Dim tponom = 0
        Dim tpopen = 0
        Dim fecha = ""
        a.qr("truncate table anom503", 2)
        If ofd_leer_timbrado.ShowDialog = Windows.Forms.DialogResult.OK Then
            semana = Val(lbl_sem_activa.Text)
            a.qr("select * from anom201 where h1_semana=" + semana.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                fecha = Mid(a.rs!h1_fecha_fin.ToString, 1, 10)
            Else
                MsgBox("Semana no existe")
                Exit Sub
            End If
            ar = New StreamReader(ofd_leer_timbrado.FileName)
            While ar.Peek >= 0
                lin = Split(ar.ReadLine, Chr(9))
                If Val(lin(0)) > 0 Then
                    a.qr("insert into anom503 values (" + lin(0).ToString +
                                "," + lin(1).ToString +
                                "," + lin(2).ToString +
                                ",0,0," + lin(3).ToString + ")", 2)
                    cant += 1
                    If lin(0) > 0 Then
                        tponom = lin(0)
                    End If
                End If
            End While
            ar.Close()
        End If
        If tponom > 0 Then
            a.qr("select * from anom503 where k3_tponom=" + tponom.ToString + " and k3_cpto in (66,166)", 1)
            If a.rs.HasRows And tponom = 1 Then
                tpopen = 11
            End If
            a.qr("select * from anom503 where k3_tponom=" + tponom.ToString + " and k3_cpto in (66,166)", 1)
            If a.rs.HasRows And tponom = 2 Then
                tpopen = 14
            End If
        End If
        a.qr("exec calc_isrpen_recre", 2)
        a.qr("delete from anom502 where k2_tponom=" + tpopen.ToString + " and k2_semana=" + semana.ToString, 2)
        a.qr("exec cargar_pension " + tpopen.ToString, 2)
        MsgBox("Proceso terminado con " + cant.ToString + " registros, pension cargada con tipo " + tpopen.ToString + ".")
    End Sub

    Private Sub CargaDeduccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargaDeduccionesToolStripMenuItem.Click
        Dim ar As StreamReader
        Dim lin() As String
        Dim semana = 0
        Dim cant = 0
        Dim query = ""
        Dim tpotra = "1"
        Dim fecha = ""
        If ofd_leer_timbrado.ShowDialog = Windows.Forms.DialogResult.OK Then
            semana = Val(lbl_sem_activa.Text)
            a.qr("select * from anom201 where h1_semana=" + semana.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                fecha = Mid(a.rs!h1_fecha_fin.ToString, 1, 10)
            Else
                MsgBox("Semana no existe")
                Exit Sub
            End If
            ar = New StreamReader(ofd_leer_timbrado.FileName)
            While ar.Peek >= 0
                lin = Split(ar.ReadLine, Chr(9))
                If Val(lin(0)) > 0 Then
                    a.qr("insert into anom503 values (" + lin(0).ToString +
                                "," + lin(1).ToString +
                                "," + lin(2).ToString +
                                ",0,0," + lin(3).ToString + ")", 2)
                    cant += 1
                End If
            End While
            ar.Close()
        End If
        MsgBox("Proceso terminado con " + cant.ToString + " registros.")
    End Sub

    Private Sub TimbradoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TimbradoToolStripMenuItem1.Click
        Dim letra = ""
        While True
            letra = Mid(InputBox("Letra para timbrado"), 1, 1)
            a.qr("select letra from catalogos where familia=3 and letra='" + letra + "'", 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        a.qr("cargar_503 '" + letra + "',2,11", 2)
        MsgBox("Proceso terminado")
    End Sub
End Class