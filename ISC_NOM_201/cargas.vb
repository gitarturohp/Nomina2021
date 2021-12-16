Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.Mail
Imports SYLKHSBC
Public Class cargas
    Public a As New Clase
    Public c As New xml_liquida
    Public ruta As String
    Public ar As New StreamReader("\\192.168.80.4\Aplicaciones\SistemasLocales\pas.ini")
    Public conexion As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim wtponom = ""
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        While True
            wtponom = InputBox("Tipo de Nomina : (1) Sindicalizado  (2) Confianza")
            If Val(wtponom) = 1 Or Val(wtponom) = 2 Then
                wrelab = Val(wtponom) + 2
                Exit While
            End If
        End While
        a.qr("select top 1 right(convert(char(6),j1_semana),2) semana from anom401b", 1)
        a.rs.Read()
        cn.ConnectionString = "Provider=sqloledb;Data Source=SANCRIS6\ISC;Initial Catalog=san_cristobal;User ID=aherrera;Password=Hepa1981"
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select right('0000000000'+i8_cuenta,10) cuenta,sum(case when j1_cpto<=400 then j1_importe  else j1_importe*-1 end) " + _
            " importe,'Pago nomina " + a.rs!semana.ToString + " HSBCNET' concepto ,substring(replace(v_nombrerep,'Ñ','N'),1,35) beneficiario from anom401b," + _
            " vacre102, aing108" + _
            " where j1_tpo_emision < 8" + _
            " and v_relab=" + wrelab.ToString + _
            " and v_clave=j1_numtra " + _
            " and v_fisica=i8_persona " + _
            " and i8_banco=18 " + _
            " and v_relab = i8_relab " + _
            " and j1_nomina = 1 " + _
            " and j1_importe! = 0 " + _
            " and j1_tponom = " + wtponom.ToString + _
            " and j1_cpto! = 498 " + _
            " and i8_tipopersona = 2 " + _
            " and len(i8_cuenta)>0 " + _
            " group by i8_cuenta,substring(replace(v_nombrerep,'Ñ','N'),1,35) " + _
            " having sum(case when j1_cpto<=400 then j1_importe  else j1_importe*-1 end) > 0" + _
            " order by 4")
        If Val(wtponom) = 1 Then
            lay.Layout_HSBC_PROPIAS(rs, "c:\hsbc_propias_sin")
        Else
            lay.Layout_HSBC_PROPIAS(rs, "c:\hsbc_propias_con")
        End If
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub bot_spei_hsbc_Click(sender As System.Object, e As System.EventArgs)
        Dim wtponom = ""
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim connom
        Dim wfec = "2015"
        wfec = InputBox("Fecha referencia (AAMMDD): ")
        While True
            wtponom = InputBox("Tipo de Nomina : (1) Sindicalizado  (2) Confianza")
            If Val(wtponom) = 1 Or Val(wtponom) = 2 Then
                wrelab = Val(wtponom) + 2
                Exit While
            End If
        End While
        a.qr("select top 1 j1_semana from anom401b", 1)
        a.rs.Read()
        connom = "Pago de Nomina " + a.rs!j1_semana.ToString
        cn.ConnectionString = "Provider=sqloledb;Data Source=SANCRIS6\ISC;Initial Catalog=san_cristobal;User ID=aherrera;Password=Hepa1981"
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc," + _
            " rtrim(ltrim(   right('00000000000000000000'+convert(varchar,i8_clabe),20)    )) clabe," + _
            " sum(case when j1_cpto<=400 then j1_importe  else j1_importe*-1 end) importe, " + wfec.ToString + " referencia," + _
            " '" + connom.ToString + "' concepto" + _
            " from anom401b, vacre102, aing108" + _
            " where j1_tpo_emision < 8" + _
            " and v_relab= " + wrelab.ToString + _
            " and v_clave=j1_numtra " + _
            " and v_fisica=i8_persona " + _
            " and v_relab=i8_relab " + _
            " and j1_nomina=1 " + _
            " and j1_importe!=0 " + _
            " and j1_tponom= " + wtponom.ToString + _
            " and j1_cpto!=498 " + _
            " and i8_tipopersona=2" + _
            " and i8_banco!=18 " + _
            " and len(i8_clabe)>0 " + _
            " group by j1_numtra,i8_tarjeta,v_rfc_rep,i8_clabe,substring(replace(v_nombrerep,'Ñ','N'),1,34),v_nombrerep " + _
            " having sum(case when j1_cpto<=400 then j1_importe  else j1_importe*-1 end)>0 " + _
            " order by substring(replace(v_nombrerep,'Ñ','N'),1,34)")
        If Val(wtponom) = 1 Then
            lay.Layout_HSBC_SPEI(rs, "c:\hsbc_spei_sin")
        Else
            lay.Layout_HSBC_SPEI(rs, "c:\hsbc_spei_con")
        End If
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub bot_pen_bec_Click(sender As System.Object, e As System.EventArgs) Handles bot_pen_bec.Click

        '==============================  CUENTAS PROPIAS DE JUBILADOS ================================

        Dim wtponom = ""
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim concep = "", wquery, connom
        Dim wsem = ""
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
            concep = InputBox("Concepto: (1) Quincenal  (2) Mensual")
            If Len(concep) = 0 Then
                Exit Sub
            End If
            If Val(concep) = 1 Or Val(concep) = 2 Then
                Exit While
            End If
        End While
        If Val(concep) = 1 Then
            connom = "Nom Jubs Qui " + wsem
            wquery = " and convert(int,k2_fec_fin-k2_fec_ini)<20 and k2_tipo='J'"
        Else
            connom = "Nom Jubs Mes " + wsem
            wquery = " and convert(int,k2_fec_fin-k2_fec_ini)>20 and k2_tipo='G'"
        End If
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,right('0000000000'+i8_cuenta,10) cuenta," + _
            " sum(case when k2_cpto<=400 then k2_importe  else k2_importe*-1 end) importe," + _
            " 'Pago nomina jub qui " + wsem + " HSBCNET' concepto ," + _
            " substring(replace(v_nombrerep,'Ñ','N'),1,35) beneficiario " + _
            " from anom502, vacre102, aing108" + _
            " where k2_semana = " + wsem + _
            " and v_clave=k2_numtra" + _
            " and v_relab=14" + _
            wquery + _
            " and i8_relab!=3 " + _
            " and k2_tponom=3 " + _
            " and i8_clave=k2_numtra" + _
            " and i8_banco=18" + _
            " and i8_tipopersona=2" + _
            " and i8_persona=v_fisica" + _
            " group by i8_cuenta,substring(replace(v_nombrerep,'Ñ','N'),1,35)" + _
            " order by 4")
        If Val(concep) = 1 Then
            lay.Layout_HSBC_PROPIAS(rs, ruta + "07-hsbc_prop_jubs_qui")
            lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_07-hsbc_prop_jub_qui.csv")
        Else
            lay.Layout_HSBC_PROPIAS(rs, ruta + "13-hsbc_prop_jubs_mes")
            lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_13-hsbc_prop_jub_mes.csv")
        End If
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles bot_jubs.Click

        '====================== CUENTAS EXTERNAS JUBILADOS ==============================

        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim connom
        Dim wquery = ""
        Dim wfec = "2016"
        Dim concep = ""
        Dim wsem = ""
        While True
            wfec = InputBox("Fecha (AAMMDD): ")
            If Len(wfec) = 0 Then
                Exit Sub
            End If
            If IsDate(Mid(wfec, 5, 2) + "/" + Mid(wfec, 3, 2) + "/20" + Mid(wfec, 1, 2)) Then
                Exit While
            End If
        End While
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
            concep = InputBox("Concepto: (1) Quincenal  (2) Mensual")
            If Len(concep) = 0 Then
                Exit Sub
            End If
            If Val(concep) = 1 Or Val(concep) = 2 Then
                Exit While
            End If
        End While
        If Val(concep) = 1 Then
            connom = "Nom Jubs Qui " + wsem
            wquery = " and convert(int,k2_fec_fin-k2_fec_ini)<20 "
        Else
            connom = "Nom Jubs Mes " + wsem
            wquery = " and convert(int,k2_fec_fin-k2_fec_ini)>20"
        End If
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc,rtrim(ltrim(right('00000000000000000000'+i8_clabe,20))) clabe," + _
            " sum(case when k2_cpto<400 then k2_importe else k2_importe*-1 end) importe," + wfec + " referencia,'" + connom + "' concepto," + _
            " substring(i8_clabe,1,3) banco,substring(replace(v_nombrerep,'Ñ','N'),1,34) beneficiario " + _
            " from anom502, vacre102, aing108" + _
            " where k2_tipo in ('G','J') " + _
            " and k2_tponom=3 " + _
            wquery + _
            " and k2_semana=" + wsem + _
            " and k2_numtra=v_clave" + _
            " and k2_numtra=i8_clave" + _
            " and i8_banco!=18" + _
            " and i8_relab=v_relab" + _
            " and v_relab=14 " + _
            " group by i8_clabe,v_nombrerep")
        If Val(concep) = 1 Then
            lay.Layout_HSBC_SPEI(rs, ruta + "08-hsbc_spei_jub_qui")
            lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_08-hsbc_spei_jub_qui.csv")
        Else
            lay.Layout_HSBC_SPEI(rs, ruta + "14-hsbc_spei_jub_mes")
            lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_14-hsbc_spei_jub_mes.csv")
        End If
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub bot_becarios_502_Click(sender As System.Object, e As System.EventArgs) Handles bot_becarios_502.Click

        '============================= CUENTAS EXTERNAS BECARIOS ============================

        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim connom
        Dim wfec = ""
        Dim wsem = ""
        While True
            wfec = InputBox("Fecha (AAMMDD): ")
            If Len(wfec) = 0 Then
                Exit Sub
            End If
            If IsDate(Mid(wfec, 5, 2) + "/" + Mid(wfec, 3, 2) + "/20" + Mid(wfec, 1, 2)) Then
                Exit While
            End If
        End While
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
        connom = "Nomina Becarios " + wsem
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc,rtrim(ltrim(   right('00000000000000000000'+convert(varchar,i8_clabe),20)    )) clabe," + _
            " sum(case when k2_cpto<400 then k2_importe else k2_importe*-1 end) importe," + wfec + " referencia,'" + connom + "' concepto,substring(i8_clabe,1,3) banco,substring(replace(v_nombrerep,'Ñ','N'),1,34) beneficiario " + _
            " from anom502, vacre102, aing108" + _
            " where k2_tipo = 'E' " + _
            " and k2_semana=" + wsem + _
            " and k2_numtra=v_clave" + _
            " and k2_numtra=i8_clave" + _
            " and i8_relab=v_relab" + _
            " and i8_banco!=18" + _
            " and v_relab=15" + _
            " group by i8_clabe,v_nombrerep")
        lay.Layout_HSBC_SPEI(rs, ruta + "12-hsbc_spei_becarios")
        lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_12-hsbc_spei_becarios.csv")
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub bot_pension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_pension.Click


        '=============================== CUENTAS EXTRAORDINARIAS PENSIONES ALIMENTICIAS ====================================

        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim connom = ""
        Dim wtponom = ""
        Dim wfec = ""
        Dim wsem = ""
        While True
            wfec = InputBox("Fecha (AAMMDD): ")
            If Len(wfec) = 0 Then
                Exit Sub
            End If
            If IsDate(Mid(wfec, 5, 2) + "/" + Mid(wfec, 3, 2) + "/20" + Mid(wfec, 1, 2)) Then
                Exit While
            End If
        End While
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
            wtponom = InputBox("Tipo de Pension : (5)-Sindicalizado  (6)-Confianza  (7)-Jub Quincenal (8)-Jub Mensual (9)-Premio  (10)-Despensa  (11)-Aguinaldo obrero  (12)-Fondo Obr  (13)-Fondo Emp  (14)-Aguinaldo empleado")
            If Len(wtponom) = 0 Then
                Exit Sub
            End If
            a.qr("select *  from catalogos  where familia=6 and letra='P' and tipo=" + wtponom, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                connom = Mid(a.rs!descrip, 1, 20) + " " + wsem
                Exit While
            End If
        End While
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc,rtrim(ltrim(   right('00000000000000000000'+convert(varchar,i8_clabe),20)    )) clabe," + _
            " sum(case when k2_cpto<400 then k2_importe else k2_importe*-1 end) importe," + wfec + " referencia,'" + connom + "' concepto,substring(i8_clabe,1,3) banco,substring(replace(v_nombrerep,'Ñ','N'),1,34) beneficiario " + _
            " from anom502, vacre102, aing108" + _
            " where k2_tipo = 'P' " + _
            " and k2_tponom=" + wtponom + _
            " and k2_semana=" + wsem + _
            " and k2_numtra=v_clave" + _
            " and k2_numtra=i8_clave" + _
            " and i8_relab=v_relab" + _
            " and i8_banco<>18" + _
            " and v_relab=11" + _
            " group by i8_clabe,v_nombrerep")
        Select Case wtponom
            Case "5"
                lay.Layout_HSBC_SPEI(rs, ruta + "09-hsbc_spei_pension_obr")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_09-hsbc_spei_pension_obr.csv")
            Case "6"
                lay.Layout_HSBC_SPEI(rs, ruta + "10-hsbc_spei_pension_emp")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_10-hsbc_spei_pension_emp.csv")
            Case "7"
                lay.Layout_HSBC_SPEI(rs, ruta + "11-hsbc_spei_pen_jub_qui")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_11-hsbc_spei_pen_jub_qui.csv")
            Case "8"
                lay.Layout_HSBC_SPEI(rs, ruta + "15-hsbc_spei_pen_jub_mes")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_15-hsbc_spei_pen_jub_mes.csv")
            Case "9"
                lay.Layout_HSBC_SPEI(rs, ruta + "16-hsbc_spei_pen_premio")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_16-hsbc_spei_pen_premio.csv")
            Case "10"
                lay.Layout_HSBC_SPEI(rs, ruta + "17-hsbc_spei_pen_despensa")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_17-hsbc_spei_pen_despensa.csv")
            Case "11"
                lay.Layout_HSBC_SPEI(rs, ruta + "18-hsbc_spei_pen_agui")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_18-hsbc_spei_pen_agui.csv")
            Case "12"
                lay.Layout_HSBC_SPEI(rs, ruta + "27-hsbc_spei_pen_fon_obr")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_27-hsbc_spei_pen_fon_obr.csv")
            Case "13"
                lay.Layout_HSBC_SPEI(rs, ruta + "28-hsbc_spei_pen_fon_emp")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_28-hsbc_spei_pen_fon_emp.csv")
            Case "14"
                lay.Layout_HSBC_SPEI(rs, ruta + "28-hsbc_spei_pen_util_obr")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_28-hsbc_spei_pen_util_obr.csv")
            Case "15"
                lay.Layout_HSBC_SPEI(rs, ruta + "28-hsbc_spei_pen_util_emp")
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_28-hsbc_spei_pen_util_emp.csv")
        End Select
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub bot_nomina_propias_Click(sender As System.Object, e As System.EventArgs) Handles bot_nomina_propias.Click

        '======== NOMINA ORDINARIA CUENTAS PROPIAS

        Dim wtponom = ""
        Dim premio = "1"
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim wsem = ""
        While True
            wsem = InputBox("Semana:")
            If Len(wsem) = 0 Then
                Exit Sub
            End If
            If Len(wsem) = 0 Then
                Exit Sub
            End If
            a.qr("select * from anom201 where h1_semana=" + wsem.ToString, 1)
            If a.rs.HasRows Then
                Exit While
            End If
        End While
        a.qr("select top 1 * from anom401b where j1_semana=" + wsem, 1)
        If Not a.rs.HasRows Then
            MsgBox("Esta semana no esta cargada, cargarla en procesos de nomina")
            Exit Sub
        End If
        While True
            wtponom = InputBox("Tipo de Nomina : (1) Sindicalizado  (2) Confianza")
            If Len(wtponom) = 0 Then
                Exit Sub
            End If
            If Val(wtponom) = 1 Or Val(wtponom) = 2 Then
                wrelab = Val(wtponom) + 2
                If wrelab = 5 Then
                    wrelab = 4
                End If
                Exit While
            End If
        End While
        If Val(wtponom) = 1 Then
            If MsgBox("Presencia fisica y Puntualidad", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                premio = "2"
            End If
        End If
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,right('0000000000'+i8_cuenta,10) cuenta,sum(j1_importe) " + _
                    " importe,'Pago nomina " + wsem + "' concepto ,substring(replace(v_nombrerep,'Ñ','N'),1,35) beneficiario" + _
                    " from pagos, anom105, vacre102, aing108" + _
                    " where j1_tponom = g5_tponom " + _
                    " and j1_nomina=" + premio.ToString + _
                    " and j1_numtra=g5_numtra" + _
                    " and j1_importe!=0" + _
                    " and g5_sindic=" + wtponom.ToString + _
                    " and v_clave=j1_numtra" + _
                    " and v_relab=(j1_tponom+2)" + _
                    " and i8_clave=v_clave" + _
                    " and i8_relab=v_relab" + _
                    " and i8_tipopersona=2" + _
                    " and i8_banco=18" + _
                    " and len(ltrim(rtrim(i8_cuenta)))>0" + _
                    " group by i8_cuenta,substring(replace(v_nombrerep,'Ñ','N'),1,35)" + _
                    " having sum(j1_importe)>0")
        If premio = "2" Then
            premio = "premio"
        Else
            premio = ""
        End If
        Select Case Val(wtponom)
            Case 1
                lay.Layout_HSBC_PROPIAS(rs, ruta + "01-hsbc_propias_obr_" + premio)
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_01-hsbc_propias_obr_" + premio + ".csv")
            Case 2
                lay.Layout_HSBC_PROPIAS(rs, ruta + "03-hsbc_propias_emp_" + premio)
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_03-hsbc_propias_emp_" + premio + ".csv")
            Case 3
                lay.Layout_HSBC_PROPIAS(rs, ruta + "05-hsbc_propias_zuc_" + premio)
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_05-hsbc_propias_zuc_" + premio + ".csv")
        End Select
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub bot_nominas_spei_Click(sender As System.Object, e As System.EventArgs) Handles bot_nominas_spei.Click

        '======================== NOMINA ORDINARIA CUENTAS EXTERNAS ==================================

        Dim wtponom = ""
        Dim premio = "1"
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim connom
        Dim wfec = ""
        Dim wsem = ""
        While True
            wfec = InputBox("Fecha (AAMMDD): ")
            If Len(wfec) = 0 Then
                Exit Sub
            End If
            If IsDate(Mid(wfec, 5, 2) + "/" + Mid(wfec, 3, 2) + "/20" + Mid(wfec, 1, 2)) Then
                Exit While
            End If
        End While
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
            wtponom = InputBox("Tipo de Nomina : (1) Sindicalizado  (2) Confianza")
            If Len(wtponom) = 0 Then
                Exit Sub
            End If
            If Val(wtponom) = 1 Or Val(wtponom) = 2 Then
                wrelab = Val(wtponom) + 2
                If wrelab = 5 Then
                    wrelab = 4
                End If
                Exit While
            End If
        End While
        If Val(wtponom) = 1 Then
            If MsgBox("Presencia fisica y Puntualidad", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                premio = "2"
            End If
        End If
        connom = "Nomina " + WSEM
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc," + _
            " rtrim(ltrim(   right('00000000000000000000'+convert(varchar,i8_clabe),20  ))) clabe," + _
            " sum(j1_importe) importe, " + wfec.ToString + " referencia," + _
            " '" + connom.ToString + "' concepto,substring(i8_clabe,1,3) banco,substring(replace(v_nombrerep,'Ñ','N'),1,34) beneficiario " + _
            " from pagos, anom105, vacre102, aing108" + _
            " where(j1_tponom = g5_tponom)" + _
            " and j1_nomina=" + premio.ToString + _
            " and j1_numtra=g5_numtra" + _
            " and j1_importe!=0" + _
            " and g5_sindic=" + wtponom.ToString + _
            " and v_clave=j1_numtra" + _
            " and v_relab=(j1_tponom+2)" + _
            " and i8_clave=v_clave" + _
            " and i8_relab=v_relab" + _
            " and i8_tipopersona=2" + _
            " and i8_banco!=18" + _
            " and len(ltrim(rtrim(i8_clabe)))>0" + _
            " group by j1_numtra,v_rfc_rep,i8_clabe,substring(replace(v_nombrerep,'Ñ','N'),1,34),v_nombrerep" + _
            " having sum(j1_importe)>0" + _
            " order by substring(replace(v_nombrerep,'Ñ','N'),1,34)")
        If premio = "2" Then
            premio = "premio"
        Else
            premio = ""
        End If
        Select Case Val(wtponom)
            Case 1
                lay.Layout_HSBC_SPEI(rs, ruta + "02-hsbc_spei_obr_" + premio)
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_02-hsbc_spei_obr_" + premio + ".csv")
            Case 2
                lay.Layout_HSBC_SPEI(rs, ruta + "04-hsbc_spei_emp" + premio)
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_04-hsbc_spei_emp" + premio + ".csv")
            Case 3
                lay.Layout_HSBC_SPEI(rs, ruta + "06-hsbc_spei_zuc" + premio)
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_06-hsbc_spei_zuc" + premio + ".csv")
        End Select
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub
    Private Sub bot_spei_nom_502_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_spei_nom_502.Click
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim connom = ""
        Dim wtponom = "1"
        Dim wfec = "2015"
        While True
            wtponom = InputBox("Tipo de Nomina : (1) Sindicalizado  (2) Confianza  (3) Zucarmex")
            If Val(wtponom) = 1 Or Val(wtponom) = 2 Or Val(wtponom) = 3 Then
                Exit While
            End If
        End While
        wfec = InputBox("Fecha (AAMMDD): ")
        a.qr("select top 1 j1_semana from anom401b", 1)
        a.rs.Read()
        connom = "Nomina SPEI Zucarmex " + a.rs!j1_semana.ToString
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc,rtrim(ltrim(   right('00000000000000000000'+convert(varchar,i8_clabe),20)    )) clabe," + _
            " sum(case when k2_cpto<400 then k2_importe else k2_importe*-1 end) importe," + wfec + " referencia,'" + connom + "' concepto,v_nombrerep " + _
            " from anom502, vacre102, aing108" + _
            " where k2_tipo = 'N' " + _
            " and k2_tponom=" + wtponom.ToString + _
            " and k2_semana=" + a.rs!j1_semana.ToString + _
            " and k2_numtra=v_clave" + _
            " and k2_numtra=i8_clave" + _
            " and i8_relab=v_relab" + _
            " and v_relab=4" + _
            " group by i8_clabe,v_nombrerep")
        Select Case wtponom
            Case "1"
                lay.Layout_HSBC_SPEI(rs, "c:\hsbc_spei_nom_obr_zc")
            Case "2"
                lay.Layout_HSBC_SPEI(rs, "c:\hsbc_spei_nom_emp_zc")
            Case "3"
                lay.Layout_HSBC_SPEI(rs, "c:\hsbc_spei_nom_zuc")
        End Select
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Dim wtponom = ""
        Dim premio = "1"
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim connom
        Dim wfec = "2015"
        wfec = InputBox("Fecha referencia (AAMMDD): ")
        While True
            wtponom = InputBox("Tipo de Nomina : (1) Sindicalizado  (2) Confianza (3) Zucarmex")
            If Val(wtponom) = 1 Or Val(wtponom) = 2 Or Val(wtponom) = 3 Then
                wrelab = Val(wtponom) + 2
                If wrelab = 5 Then
                    wrelab = 4
                End If
                Exit While
            End If
        End While
        If MsgBox("Presencia fisica y Puntualidad", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            premio = "2"
        End If
        a.qr("select top 1 j1_semana from anom401b", 1)
        a.rs.Read()
        connom = "Pago de Nomina Semana " + a.rs!j1_semana.ToString
        cn.ConnectionString = "Provider=sqloledb;Data Source=SANCRIS6\ISC;Initial Catalog=san_cristobal;User ID=aherrera;Password=Hepa1981"
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc," + _
            " rtrim(ltrim(   right('00000000000000000000'+convert(varchar,i8_clabe),20))) clabe," + _
            " sum(case when j1_cpto<=400 then j1_importe  else j1_importe*-1 end) importe, " + wfec.ToString + " referencia," + _
            " '" + connom.ToString + "' concepto,substring(i8_clabe,1,3) banco,substring(replace(v_nombrerep,'Ñ','N'),1,34) beneficiario " + _
            " from anom401b, anom105, vacre102, aing108" + _
            " where(j1_tponom = g5_tponom)" + _
            " and j1_nomina=" + premio.ToString + _
            " and j1_numtra=g5_numtra" + _
            " and j1_tpo_emision<8" + _
            " and j1_cpto!=498" + _
            " and j1_importe!=0" + _
            " and g5_sindic=" + wtponom.ToString + _
            " and v_clave=j1_numtra" + _
            " and v_relab=(j1_tponom+2)" + _
            " and i8_clave=v_clave" + _
            " and i8_relab=v_relab" + _
            " and i8_tipopersona=2" + _
            " and i8_banco!=18" + _
            " and len(ltrim(rtrim(i8_clabe)))>0" + _
            " group by j1_numtra,v_rfc_rep,i8_clabe,substring(replace(v_nombrerep,'Ñ','N'),1,34),v_nombrerep" + _
            " having sum(case WHEN j1_cpto<400 then j1_importe else j1_importe*-1 END)>0" + _
            " order by substring(replace(v_nombrerep,'Ñ','N'),1,34)")
        If premio = "2" Then
            premio = "premio"
        Else
            premio = ""
        End If
        Select Case Val(wtponom)
            Case 1
                'lay.Layout_HSBC_SPEI(rs, "c:\02-hsbc_spei_obr" + premio)
                lay.LayoutNET_HSBC_SPEI(rs, "c:\prueba_spei.csv")
            Case 2
                lay.Layout_HSBC_SPEI(rs, "c:\04-hsbc_spei_emp" + premio)
            Case 3
                lay.Layout_HSBC_SPEI(rs, "c:\06-hsbc_spei_zuc" + premio)
        End Select
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados LLANES.")

    End Sub

    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs)
        Dim wtponom = ""
        Dim premio = "1"
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        While True
            wtponom = InputBox("Tipo de Nomina : (1) Sindicalizado  (2) Confianza  (3) Zucarmex")
            If Val(wtponom) = 1 Or Val(wtponom) = 2 Or Val(wtponom) = 3 Then
                wrelab = Val(wtponom) + 2
                If wrelab = 5 Then
                    wrelab = 4
                End If
                Exit While
            End If
        End While
        If MsgBox("Presencia fisica y Puntualidad", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            premio = "2"
        End If
        a.qr("select top 1 right(convert(char(6),j1_semana),2) semana from anom401b", 1)
        a.rs.Read()
        cn.ConnectionString = "Provider=sqloledb;Data Source=SANCRIS6\ISC;Initial Catalog=san_cristobal;User ID=aherrera;Password=Hepa1981"
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,right('0000000000'+i8_cuenta,10) cuenta,sum(case when j1_cpto<=400 then j1_importe  else j1_importe*-1 end) " + _
                    " importe,'Pago nomina " + a.rs!semana.ToString + "' concepto ,substring(replace(v_nombrerep,'Ñ','N'),1,40) beneficiario" + _
                    " from anom401b, anom105, vacre102, aing108" + _
                    " where j1_tponom = g5_tponom " + _
                    " and j1_nomina=" + premio.ToString + _
                    " and j1_numtra=g5_numtra" + _
                    " and j1_tpo_emision<8" + _
                    " and j1_cpto!=498" + _
                    " and j1_importe!=0" + _
                    " and g5_sindic=" + wtponom.ToString + _
                    " and v_clave=j1_numtra" + _
                    " and v_relab=(j1_tponom+2)" + _
                    " and i8_clave=v_clave" + _
                    " and i8_relab=v_relab" + _
                    " and i8_tipopersona=2" + _
                    " and i8_banco=18" + _
                    " and len(ltrim(rtrim(i8_cuenta)))>0" + _
                    " group by i8_cuenta,substring(replace(v_nombrerep,'Ñ','N'),1,40)" + _
                    " having sum(case WHEN j1_cpto<400 then j1_importe else j1_importe*-1 END)>0")
        If premio = "2" Then
            premio = "premio"
        Else
            premio = ""
        End If
        Try
            Select Case Val(wtponom)
                Case 1
                    lay.Layout_HSBC_PROPIAS(rs, "c:\01-hsbc_propias_obr_" + premio)
                    'lay.LayoutNET_HSBC_PROPIAS(rs, "c:\prueba_propias.csv")
                Case 2
                    lay.Layout_HSBC_PROPIAS(rs, "c:\03-hsbc_propias_emp" + premio)
                Case 3
                    lay.Layout_HSBC_PROPIAS(rs, "c:\05-hsbc_propias_zuc" + premio)
            End Select
            MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados LLANES.")
        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub cargas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        a.qr("select g1_timbrado from anom101", 1)
        a.rs.Read()
        ruta = a.rs!g1_timbrado.ToString
        ar.ReadLine()
        conexion = ar.ReadLine
    End Sub
    Private Sub bot_prest_Click(sender As System.Object, e As System.EventArgs) Handles bot_prest.Click
        Dim wtponom = ""
        Dim wrelab = 1
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim concep = ""
        Dim tipo = ""
        Dim wsem = ""
        Dim letra = ""
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
            tipo = InputBox("Tipo: (1) Obrero  (2) Empleado")
            If Len(tipo) = 0 Then
                Exit Sub
            End If
            If Val(tipo) = 1 Or Val(tipo) = 2 Then
                If Val(tipo) = 3 Then
                    tipo = "2"
                End If
                Exit While
            End If
        End While
        While True
            letra = InputBox("Tipo de Pago (letra)")
            If Len(letra) = 0 Then
                Exit Sub
            End If
            a.qr("select * from catalogos where familia=3 and letra='" + letra + "'", 1)
            If a.rs.HasRows Then
                a.rs.Read()
                concep = Mid(a.rs!descrip, 1, 10)
                Exit While
            End If
        End While
        a.qr("select * from anom502,aing108 where k2_semana=" + wsem + " and k2_tponom=" + tipo + " and k2_tipo='" + UCase(letra) + "' and i8_relab=k2_tponom+2 and k2_numtra=i8_clave and i8_banco=18", 1)
        If Not a.rs.HasRows Then
            MsgBox("No se cuenta con registros para estas opciones o banco no es cuenta propia")
            Exit Sub
        End If
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,right('0000000000'+i8_cuenta,10) cuenta," + _
            " sum(case when k2_cpto<=400 then k2_importe  else k2_importe*-1 end) importe," + _
            " '" + concep + " " + wsem + " ' concepto ," + _
            " substring(replace(v_nombrerep,'Ñ','N'),1,35) beneficiario " + _
            " from anom502, vacre102, aing108,anom105" + _
            " where k2_semana=" + wsem + _
            " and v_clave=k2_numtra" + _
            " and v_relab=(case when g5_sindic=1 then 3 else 4 end)" + _
            " and k2_tponom=g5_tponom " + _
            " and k2_numtra=g5_numtra " + _
            " and k2_tponom=" + tipo + _
            " and k2_tipo in ('" + UCase(letra) + "')" + _
            " and i8_relab=v_relab " + _
            " and i8_clave=k2_numtra" + _
            " and i8_banco=18" + _
            " and i8_tipopersona=2" + _
            " and i8_persona=v_fisica" + _
            " group by i8_cuenta,substring(replace(v_nombrerep,'Ñ','N'),1,35)" + _
            " order by 4")
        If Val(tipo) = 1 Then
            lay.Layout_HSBC_PROPIAS(rs, ruta + "21-hsbc_fon_obr_2_" + letra)
            lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_21-hsbc_fon_obr_2_" + letra + ".csv")
        Else
            If Val(tipo) = 2 Then
                lay.Layout_HSBC_PROPIAS(rs, ruta + "22-hsbc_fon_empl_2_" + letra)
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_22-hsbc_fon_empl_2_" + letra + ".csv ")
            Else
                lay.Layout_HSBC_PROPIAS(rs, ruta + "23-hsbc_fon_zuc_" + letra)
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_23-hsbc_fon_zuc_" + letra + ".csv")
            End If
        End If
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub bot_spei_Click(sender As System.Object, e As System.EventArgs) Handles bot_spei.Click
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim wquery = ""
        Dim wfec = "2015"
        Dim wsem = ""
        Dim concep = ""
        Dim tipo = ""
        Dim letra = ""
        While True
            wfec = InputBox("Fecha (AAMMDD): ")
            If Len(wfec) = 0 Then
                Exit Sub
            End If
            If IsDate(Mid(wfec, 5, 2) + "/" + Mid(wfec, 3, 2) + "/20" + Mid(wfec, 1, 2)) Then
                Exit While
            End If
        End While
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
            tipo = InputBox("tipo: (1) Obrero  (2) Empleado")
            If Len(tipo) = 0 Then
                Exit Sub
            End If
            If Val(tipo) = 1 Or Val(tipo) = 2 Then
                Exit While
            End If
        End While
        While True
            letra = InputBox("Tipo de Pago (letra)")
            If Len(letra) = 0 Then
                Exit Sub
            End If
            a.qr("select * from catalogos where familia=3 and letra='" + letra + "'", 1)
            If a.rs.HasRows Then
                a.rs.Read()
                concep = Mid(a.rs!descrip, 1, 10) + " " + wsem
                Exit While
            End If
        End While
        a.qr("select * from anom502,aing108 where k2_semana=" + wsem + " and k2_tponom=" + tipo + " and k2_tipo='" + UCase(letra) + "' and i8_relab=k2_tponom+2 and k2_numtra=i8_clave and i8_banco!=18", 1)
        If Not a.rs.HasRows Then
            MsgBox("No se cuenta con registros para estas opciones o banco no es cuenta propia")
            Exit Sub
        End If
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,rtrim(ltrim('IAS150623KV3')) rfc,rtrim(ltrim(right('00000000000000000000'+i8_clabe,20))) clabe," + _
            " sum(case when k2_cpto<400 then k2_importe else k2_importe*-1 end) importe," + wfec + " referencia,'" + concep + "' concepto," + _
            " substring(i8_clabe,1,3) banco,substring(replace(v_nombrerep,'Ñ','N'),1,34) beneficiario " + _
            " from anom502, vacre102, aing108,anom105" + _
            " where k2_tipo in ('" + letra + "') " + _
            " and g5_tponom=" + tipo.ToString + _
            " and k2_semana=" + wsem.ToString + _
            " and k2_numtra=v_clave" + _
            " and k2_numtra=i8_clave" + _
            " and k2_numtra=g5_numtra" + _
            " and k2_tponom=g5_tponom" + _
            " and i8_banco!=18" + _
            " and len(i8_clabe)>0" + _
            " and i8_relab=v_relab" + _
            " and v_relab=(case when g5_sindic=1 then 3 else 4 end) " + _
            " group by i8_clabe,v_nombrerep")
        If Val(tipo) = 1 Then
            lay.Layout_HSBC_SPEI(rs, ruta + "24-fon_spei_obr" + letra)
            lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_24-fon_spei_obr_" + letra + ".csv")
        Else
            If Val(tipo) = 2 Then
                lay.Layout_HSBC_SPEI(rs, ruta + "25-fon_spei_emp_" + letra)
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_25-fon_spei_emp_" + letra + ".csv")
            Else
                lay.Layout_HSBC_SPEI(rs, ruta + "26-fon_spei_prest_" + letra)
                lay.LayoutNET_HSBC_SPEI(rs, ruta + "a_26-fon_spei_prest_" + letra + ".csv")
            End If
        End If
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub Button1_Click_3(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        '========================= CUENTAS PROPIAS BECARIOS

        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim wsem = ""
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
        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,right('0000000000'+i8_cuenta,10) cuenta," +
            " sum(case when k2_cpto<=400 then k2_importe  else k2_importe*-1 end) importe," +
            " 'becarios" + wsem + " HSBCNET' concepto ," +
            " substring(replace(v_nombrerep,'Ñ','N'),1,35) beneficiario " +
            " from anom502, vacre102, aing108" +
            " where k2_semana =" + wsem +
            " and v_clave=k2_numtra" +
            " and v_relab=15" +
            " and k2_tipo='E'" +
            " and k2_tponom=4 " +
            " and i8_clave=k2_numtra" +
            " and i8_banco=18" +
            " and i8_persona=v_fisica" +
            " group by i8_cuenta,substring(replace(v_nombrerep,'Ñ','N'),1,35)" +
            " order by 4")
        lay.Layout_HSBC_PROPIAS(rs, ruta + "29-hsbc_prop_beca")
        lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_29-hsbc_prop_beca.csv")
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub bot_propias_pen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_propias_pen.Click
        Dim wtponom
        Dim connom
        Dim lay As New SYLKHSBC.bus_Layouts
        Dim cn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim wsem = ""
        '========================= CUENTAS PROPIAS PENSIONADOS

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
            wtponom = InputBox("Tipo de Pension : (5) Sindicalizado  (6) Confianza  (7) Jub Quincenal (8) Jub Mensual (9) Premio  (10) Despensa  (11) Aguinaldo Obrero (12) Fondo Obr  (13) Fondo Emp  (14) Aguinaldo Empleado")
            If Len(wtponom) = 0 Then
                Exit Sub
            End If
            a.qr("select *  from catalogos  where familia=6 and letra='P' and tipo=" + wtponom, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                connom = Mid(a.rs!descrip, 1, 20) + " " + wsem
                Exit While
            End If
        End While

        cn.ConnectionString = conexion
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        cn.ConnectionTimeout = 0
        cn.Open()
        rs = cn.Execute("select 4058257080 ordenante,right('0000000000'+i8_cuenta,10) cuenta," + _
            " sum(case when k2_cpto<=400 then k2_importe  else k2_importe*-1 end) importe," + _
            " 'pensiones " + wsem + " HSBCNET' concepto ," + _
            " substring(replace(v_nombrerep,'Ñ','N'),1,35) beneficiario " + _
            " from anom502, vacre102, aing108" + _
            " where k2_semana =" + wsem + _
            " and v_clave=k2_numtra" + _
            " and v_relab=11" + _
            " and k2_tponom= " + wtponom.ToString + _
            " and i8_clave=k2_numtra" + _
            " and i8_banco=18" + _
            " and i8_persona=v_fisica" + _
            " group by i8_cuenta,substring(replace(v_nombrerep,'Ñ','N'),1,35)" + _
            " order by 4")
        Select Case wtponom
            Case 5
                lay.Layout_HSBC_PROPIAS(rs, ruta + "31-hsbc_pen_obr")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_31-hsbc_pen_obr.csv")
            Case 6
                lay.Layout_HSBC_PROPIAS(rs, ruta + "32-hsbc_pen_emp")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_32-hsbc_pen_emp.csv")
            Case 7
                lay.Layout_HSBC_PROPIAS(rs, ruta + "33-hsbc_pen_jubquin")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_33-hsbc_pen_jubquin.csv")
            Case 8
                lay.Layout_HSBC_PROPIAS(rs, ruta + "34-hsbc_pen_jubmes")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_34-hsbc_pen_jubmes.csv")
            Case 9
                lay.Layout_HSBC_PROPIAS(rs, ruta + "35-hsbc_pen_pen_premio")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_35-hsbc_pen_pen_premio.csv")
            Case 10
                lay.Layout_HSBC_PROPIAS(rs, ruta + "36-hsbc_pen_despen")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_36-hsbc_pen_despen.csv")
            Case 11
                lay.Layout_HSBC_PROPIAS(rs, ruta + "37-hsbc_pen_agui")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_37-hsbc_pen_agui.csv")
            Case 12
                lay.Layout_HSBC_PROPIAS(rs, ruta + "38-hsbc_pen_fonobr")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_38-hsbc_pen_fonobr.csv")
            Case 13
                lay.Layout_HSBC_PROPIAS(rs, ruta + "39-hsbc_pen_fonemp")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_39-hsbc_pen_fonemp.csv")
            Case 14
                lay.Layout_HSBC_PROPIAS(rs, ruta + "38-hsbc_pen_ptuobr")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_38-hsbc_pen_ptuobr.csv")
            Case 15
                lay.Layout_HSBC_PROPIAS(rs, ruta + "39-hsbc_pen_ptuemp")
                lay.LayoutNET_HSBC_PROPIAS(rs, ruta + "a_39-hsbc_pen_ptuemp.csv")
        End Select
        MsgBox("Proceso Terminado con " + rs.RecordCount.ToString + " registros procesados.")
    End Sub
End Class