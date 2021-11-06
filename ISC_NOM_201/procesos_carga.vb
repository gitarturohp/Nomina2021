Public Class procesos_carga
    Public Structure wfec
        Dim w_dia1, w_dia2, w_dia3, w_dia4, w_dia5, w_dia6, w_dia7 As Integer
        Dim w_fec1, w_fec2, w_fec3, w_fec4, w_fec5, w_fec6, w_fec7 As Date
        Dim w_fes1, w_fes2, w_fes3, w_fes4, w_fes5, w_fes6, w_fes7 As String
    End Structure
    Public a As New Clase
    Public b As New Clase
    Public w_ciclo As Char
    Public w_fec As wfec
    Public w_cta_fes
    Public w_festisd
    Sub lee_parametros() '##### LEE PARAMETROS
        Dim w_semana = ""
        Dim param As New Clase
        Dim wtponom = "3"
        While True
            a.qr("select i4_ano_sem,valor from anom304 with(nolock),parametros with(nolock) where tipo=1 and clave='calculo'", 1)
            a.rs.Read()
            w_semana = a.rs!i4_ano_sem.ToString
            wtponom = a.rs!valor.ToString
            a.qr("select * from anom201 with(nolock) where h1_semana=" + w_semana, 1)
            If a.rs.HasRows Then
                a.qr("select * from anom304 with(nolock) where i4_ano_sem=" + w_semana, 1)
                If a.rs.HasRows Then
                    Exit While
                End If
                MsgBox("Semana no corresponde a parametros 304")
            End If
        End While
        a.qr("select * from anom201 with(nolock) where h1_semana=" + w_semana, 1)
        a.rs.Read()
        w_ciclo = a.rs!h1_ciclo
        param.qr("select * from anom304 with(nolock)", 1)
        param.rs.Read()
        a.qr("select * from anom202 with(nolock) where h2_fecha between '" + Mid(param.rs!i4_inisem.ToString, 1, 10) + "' and '" + Mid(param.rs!i4_finsem.ToString, 1, 10) + "'", 1)
        While a.rs.Read
            Select Case a.rs!h2_dia
                Case 1
                    w_fec.w_dia1 = 1
                    w_fec.w_fec1 = a.rs!h2_fecha
                    w_fec.w_fes1 = a.rs!h2_festivo
                Case 2
                    w_fec.w_dia2 = 2
                    w_fec.w_fec2 = a.rs!h2_fecha
                    w_fec.w_fes2 = a.rs!h2_festivo
                Case 3
                    w_fec.w_dia3 = 3
                    w_fec.w_fec3 = a.rs!h2_fecha
                    w_fec.w_fes3 = a.rs!h2_festivo
                Case 4
                    w_fec.w_dia4 = 4
                    w_fec.w_fec4 = a.rs!h2_fecha
                    w_fec.w_fes4 = a.rs!h2_festivo
                Case 5
                    w_fec.w_dia5 = 5
                    w_fec.w_fec5 = a.rs!h2_fecha
                    w_fec.w_fes5 = a.rs!h2_festivo
                Case 6
                    w_fec.w_dia6 = 6
                    w_fec.w_fec6 = a.rs!h2_fecha
                    w_fec.w_fes6 = a.rs!h2_festivo
                Case 7
                    w_fec.w_dia7 = 7
                    w_fec.w_fec7 = a.rs!h2_fecha
                    w_fec.w_fes7 = a.rs!h2_festivo
            End Select
        End While
        a.qr("select count(*) num from anom202 with(nolock) where h2_fecha between '" +
             Mid(param.rs!i4_inisem.ToString, 1, 10) + "' and '" + Mid(param.rs!i4_finsem.ToString, 1, 10) + "' and h2_festivo='S'", 1)
        a.rs.Read()
        w_cta_fes = a.rs!num
        If w_cta_fes > 1 Then
            If w_fec.w_fes6 = "S" Then
                w_festisd = 1
            End If
            If w_fec.w_fes7 = "S" Then
                w_festisd = 1
            End If
        End If
        a.qr("exec separa_301 '" + Mid(param.rs!i4_inisem.ToString, 1, 10) + "','" + Mid(param.rs!i4_finsem.ToString, 1, 10) + "'," + wtponom, 2)
        a.qr("exec crea_301", 2)
    End Sub
    Sub nom207_301()    '##### NOM207_301
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\NOM207_error.txt"
        file = System.IO.File.Create(fic)
        file.Close()
        Dim sw As New System.IO.StreamWriter(fic)
        Dim w_uno = 1
        Dim w_cta = 1
        a.qr("exec crea_207", 1)
        w_uno = 1
        w_cta = 1
        a.qr("select h3_numtra,h3_area,count(*) num from anom23b with(nolock) group by h3_numtra,h3_area having count(*)>7", 1)
        While a.rs.Read
            sw.WriteLine(" MAS REGISTROS TRABAJADOS, NUMTRA: " + a.rs!h3_numtra.ToString + ", AREA: " + a.rs!h3_area.ToString)
        End While
        sw.Close()
        a.qr("insert into anom207 select distinct 8,h3_tponom,h3_numtra,0,0,0,'',0,0,0,0,0,'',0,0,0,0,0,'',0,0,0,0,0,'',0,0,0,0,0,'',0,0,0,0,0,'',0,0,0,0,0,'',0,0,0,h3_area,0 from anom23b", 2)
        a.qr("select * from anom23b with(nolock) order by h3_numtra,h3_area,h3_dia", 1)
        While a.rs.Read
            Select Case a.rs!h3_dia
                Case 1
                    b.qr("update anom207 set h7_turno_1=" + a.rs!h3_turno.ToString + ",h7_catego_1=" + a.rs!h3_catego.ToString + ",h7_cta2_1=" + a.rs!h3_depto.ToString + _
                         ",h7_cta4_1='" + a.rs!h3_aplic + "',h7_tpotra_1=" + a.rs!h3_tpotra.ToString + ",h7_sot_1=" + a.rs!h3_sot.ToString + " where h7_numtra=" + _
                         a.rs!h3_numtra.ToString + " and h7_tponom=" + a.rs!h3_tponom.ToString + " and h7_cta3='" + a.rs!h3_area.ToString + "'", 2)
                Case 2
                    b.qr("update anom207 set h7_turno_2=" + a.rs!h3_turno.ToString + ",h7_catego_2=" + a.rs!h3_catego.ToString + ",h7_cta2_2=" + a.rs!h3_depto.ToString + _
                         ",h7_cta4_2='" + a.rs!h3_aplic.ToString + "',h7_tpotra_2=" + a.rs!h3_tpotra.ToString + ",h7_sot_2=" + a.rs!h3_sot.ToString + " where h7_numtra=" + _
                         a.rs!h3_numtra.ToString + " and h7_tponom=" + a.rs!h3_tponom.ToString + " and h7_cta3='" + a.rs!h3_area.ToString + "'", 2)
                Case 3
                    b.qr("update anom207 set h7_turno_3=" + a.rs!h3_turno.ToString + ",h7_catego_3=" + a.rs!h3_catego.ToString + ",h7_cta2_3=" + a.rs!h3_depto.ToString + _
                         ",h7_cta4_3='" + a.rs!h3_aplic.ToString + "',h7_tpotra_3=" + a.rs!h3_tpotra.ToString + ",h7_sot_3=" + a.rs!h3_sot.ToString + " where h7_numtra=" + _
                         a.rs!h3_numtra.ToString + " and h7_tponom=" + a.rs!h3_tponom.ToString + " and h7_cta3='" + a.rs!h3_area.ToString + "'", 2)
                Case 4
                    b.qr("update anom207 set h7_turno_4=" + a.rs!h3_turno.ToString + ",h7_catego_4=" + a.rs!h3_catego.ToString + ",h7_cta2_4=" + a.rs!h3_depto.ToString + _
                         ",h7_cta4_4='" + a.rs!h3_aplic.ToString + "',h7_tpotra_4=" + a.rs!h3_tpotra.ToString + ",h7_sot_4=" + a.rs!h3_sot.ToString + " where h7_numtra=" + _
                         a.rs!h3_numtra.ToString + " and h7_tponom=" + a.rs!h3_tponom.ToString + " and h7_cta3='" + a.rs!h3_area.ToString + "'", 2)
                Case 5
                    b.qr("update anom207 set h7_turno_5=" + a.rs!h3_turno.ToString + ",h7_catego_5=" + a.rs!h3_catego.ToString + ",h7_cta2_5=" + a.rs!h3_depto.ToString + _
                         ",h7_cta4_5='" + a.rs!h3_aplic.ToString + "',h7_tpotra_5=" + a.rs!h3_tpotra.ToString + ",h7_sot_5=" + a.rs!h3_sot.ToString + " where h7_numtra=" + _
                         a.rs!h3_numtra.ToString + " and h7_tponom=" + a.rs!h3_tponom.ToString + " and h7_cta3='" + a.rs!h3_area.ToString + "'", 2)
                Case 6
                    b.qr("update anom207 set h7_turno_6=" + a.rs!h3_turno.ToString + ",h7_catego_6=" + a.rs!h3_catego.ToString + ",h7_cta2_6=" + a.rs!h3_depto.ToString + _
                         ",h7_cta4_6='" + a.rs!h3_aplic.ToString + "',h7_tpotra_6=" + a.rs!h3_tpotra.ToString + ",h7_sot_6=" + a.rs!h3_sot.ToString + " where h7_numtra=" + _
                         a.rs!h3_numtra.ToString + " and h7_tponom=" + a.rs!h3_tponom.ToString + " and h7_cta3='" + a.rs!h3_area.ToString + "'", 2)
                Case Else
                    b.qr("update anom207 set h7_turno_7=" + a.rs!h3_turno.ToString + ",h7_catego_7=" + a.rs!h3_catego.ToString + ",h7_cta2_7=" + a.rs!h3_depto.ToString + _
                         ",h7_cta4_7='" + a.rs!h3_aplic.ToString + "',h7_tpotra_7=" + a.rs!h3_tpotra.ToString + ",h7_sot_7=" + a.rs!h3_sot.ToString + ",h7_horas=8.00,h7_cifra=8 where h7_numtra=" + _
                         a.rs!h3_numtra.ToString + " and h7_tponom=" + a.rs!h3_tponom.ToString + " and h7_cta3='" + a.rs!h3_area.ToString + "'", 2)
            End Select
        End While
    End Sub
    Sub reloj_301()     '##### RELOJ_301
        Dim w_cta = 1
        Dim w_aplic As String = ""
        Dim w_tpotra As Integer = 0
        Dim w_sot As Integer = 0
        Dim w_dia = 1
        Dim w_festi = w_cta_fes * 1
        Dim w_depto = 0
        Dim wx_si = "N"
        Dim w_turno, w_catego, wc_cta4, wc_depto, wc_parti, w_area, w_aplicac, w_fecha, w_fes
        Dim w_tpocon = ""
        Dim w_cpto = 0
        Dim w_horas As Double = 0.0
        Dim w_vaca = 0
        a.qr("select * from anom207 with(nolock)", 1)
        While a.rs.Read
            For x = 1 To 7
                wx_si = "N"
                w_depto = 0
                Select Case x
                    Case 1
                        If a.rs!h7_catego_1 > 0 Then
                            w_turno = a.rs!h7_turno_1
                            w_catego = a.rs!h7_catego_1
                            w_tpotra = a.rs!h7_tpotra_1
                            w_sot = a.rs!h7_sot_1
                            w_cta = a.rs!h7_cta2_1
                            wc_cta4 = a.rs!h7_cta4_1
                            wc_depto = a.rs!h7_cta2_1
                            w_depto = a.rs!h7_cta2_1
                            wc_parti = Mid(wc_cta4, 3, 2)
                            w_area = a.rs!h7_cta3
                            w_aplicac = a.rs!h7_cta4_1
                            w_fecha = w_fec.w_fec1
                            w_fes = w_fec.w_fes1
                            wx_si = "S"
                        End If
                    Case 2
                        If a.rs!h7_catego_2 > 0 Then
                            w_turno = a.rs!h7_turno_2
                            w_catego = a.rs!h7_catego_2
                            w_tpotra = a.rs!h7_tpotra_2
                            w_sot = a.rs!h7_sot_2
                            w_cta = a.rs!h7_cta2_2
                            wc_cta4 = a.rs!h7_cta4_2
                            wc_depto = a.rs!h7_cta2_2
                            w_depto = a.rs!h7_cta2_2
                            wc_parti = Mid(wc_cta4, 3, 2)
                            w_area = a.rs!h7_cta3
                            w_aplicac = a.rs!h7_cta4_2
                            w_fecha = w_fec.w_fec2
                            w_fes = w_fec.w_fes2
                            wx_si = "S"
                        End If
                    Case 3
                        If a.rs!h7_catego_3 > 0 Then
                            w_turno = a.rs!h7_turno_3
                            w_catego = a.rs!h7_catego_3
                            w_tpotra = a.rs!h7_tpotra_3
                            w_sot = a.rs!h7_sot_3
                            w_cta = a.rs!h7_cta2_3
                            wc_cta4 = a.rs!h7_cta4_3
                            wc_depto = a.rs!h7_cta2_3
                            w_depto = a.rs!h7_cta2_3
                            wc_parti = Mid(wc_cta4, 3, 2)
                            w_area = a.rs!h7_cta3
                            w_aplicac = a.rs!h7_cta4_3
                            w_fecha = w_fec.w_fec3
                            w_fes = w_fec.w_fes3
                            wx_si = "S"
                        End If
                    Case 4
                        If a.rs!h7_catego_4 > 0 Then
                            w_turno = a.rs!h7_turno_4
                            w_catego = a.rs!h7_catego_4
                            w_tpotra = a.rs!h7_tpotra_4
                            w_sot = a.rs!h7_sot_4
                            w_cta = a.rs!h7_cta2_4
                            wc_cta4 = a.rs!h7_cta4_4
                            wc_depto = a.rs!h7_cta2_4
                            w_depto = a.rs!h7_cta2_4
                            wc_parti = Mid(wc_cta4, 3, 2)
                            w_area = a.rs!h7_cta3
                            w_aplicac = a.rs!h7_cta4_4
                            w_fecha = w_fec.w_fec4
                            w_fes = w_fec.w_fes4
                            wx_si = "S"
                        End If
                    Case 5
                        If a.rs!h7_catego_5 > 0 Then
                            w_turno = a.rs!h7_turno_5
                            w_catego = a.rs!h7_catego_5
                            w_tpotra = a.rs!h7_tpotra_5
                            w_sot = a.rs!h7_sot_5
                            w_cta = a.rs!h7_cta2_5
                            wc_cta4 = a.rs!h7_cta4_5
                            wc_depto = a.rs!h7_cta2_5
                            w_depto = a.rs!h7_cta2_5
                            wc_parti = Mid(wc_cta4, 3, 2)
                            w_area = a.rs!h7_cta3
                            w_aplicac = a.rs!h7_cta4_5
                            w_fecha = w_fec.w_fec5
                            w_fes = w_fec.w_fes5
                            wx_si = "S"
                        End If
                    Case 6
                        If a.rs!h7_catego_6 > 0 Then
                            w_turno = a.rs!h7_turno_6
                            w_catego = a.rs!h7_catego_6
                            w_tpotra = a.rs!h7_tpotra_6
                            w_sot = a.rs!h7_sot_6
                            w_cta = a.rs!h7_cta2_6
                            wc_cta4 = a.rs!h7_cta4_6
                            wc_depto = a.rs!h7_cta2_6
                            w_depto = a.rs!h7_cta2_6
                            wc_parti = Mid(wc_cta4, 3, 2)
                            w_area = a.rs!h7_cta3
                            w_aplicac = a.rs!h7_cta4_6
                            w_fecha = w_fec.w_fec6
                            w_fes = w_fec.w_fes6
                            wx_si = "S"
                        End If
                    Case Else
                        If a.rs!h7_catego_7 > 0 Then
                            w_turno = a.rs!h7_turno_7
                            w_catego = a.rs!h7_catego_7
                            w_tpotra = a.rs!h7_tpotra_7
                            w_sot = a.rs!h7_sot_7
                            w_cta = a.rs!h7_cta2_7
                            wc_cta4 = a.rs!h7_cta4_7
                            wc_depto = a.rs!h7_cta2_7
                            w_depto = a.rs!h7_cta2_7
                            wc_parti = Mid(wc_cta4, 3, 2)
                            w_area = a.rs!h7_cta3
                            w_aplicac = a.rs!h7_cta4_7
                            w_fecha = w_fec.w_fec7
                            w_fes = w_fec.w_fes7
                            wx_si = "S"
                        End If
                End Select
                w_dia = x
                If wx_si = "S" Then
                    w_tpocon = " "
                    w_cpto = 0
                    w_horas = 0
                    If w_fes = "S" Then
                        w_tpocon = "V"
                        w_cpto = 27
                        'If a.rs!h7_tponom = 1 Then
                        w_horas = 8
                        'End If
                    Else
                        w_tpocon = "V"
                        w_cpto = 3
                        w_horas = 0
                    End If
                    '########### SABADO TRABAJADO CPTO 4
                    Select Case w_dia
                        Case 6
                            If w_ciclo = "2" Then
                                If w_fes = "N" Then
                                    If w_turno <= 4 Then
                                        w_tpocon = "V"
                                        w_cpto = 4
                                        w_horas = 8
                                    Else
                                        If w_turno < 3 Then
                                            w_tpocon = "V"
                                            w_cpto = 4
                                            w_horas = 8
                                        Else
                                            w_tpocon = "V"
                                            w_cpto = 4
                                            w_horas = 8
                                        End If
                                    End If
                                Else
                                    w_tpocon = "V"
                                    w_cpto = 27
                                    w_horas = 8
                                End If
                            Else
                                If w_turno >= 3 Then
                                    If w_fes = "N" Then
                                        'w_tpocon = "V"
                                        'w_cpto = 19
                                    End If
                                End If
                            End If
                            If w_fes = "S" Then
                                w_tpocon = "V"
                                w_cpto = 27
                                w_horas = 8
                            End If
                            '########## DOMINGO TRABAJADO CPTO 21
                        Case 7
                            w_horas = a.rs!h7_horas
                            w_tpocon = "V"
                            w_cpto = 21
                    End Select
                    w_vaca = 0
                    If w_dia < 6 Then
                        If w_fes = "S" Then
                            If w_turno >= 3 Then
                                w_vaca = 1
                            End If
                        End If
                    End If
                    If w_vaca = 0 Then
                        b.qr("insert into anom301 values(" + _
                             "8," + _
                             "1," + _
                             a.rs!h7_tponom.ToString + "," + _
                             w_depto.ToString + "," + _
                             a.rs!h7_numtra.ToString + "," + _
                             "0," + _
                             "'" + w_tpocon + "'," + _
                             w_cpto.ToString + "," + _
                             w_horas.ToString + _
                             ",0.0,''," + _
                             w_turno.ToString + _
                             ",0," + _
                             w_catego.ToString + "," + _
                             "'" + Mid(w_fecha, 1, 10) + "',0,0,0,0," + _
                             w_tpotra.ToString + "," + _
                             w_sot.ToString + ",0,0,0,0,0)", 2)
                    End If
                End If

                Dim w_dia_a = 0
                If w_dia <= 5 And wx_si = "S" Then
                    w_dia_a = 0
                    Select Case w_dia
                        Case 1
                            If w_fec.w_fes2 = "S" Then
                                w_dia_a = 1
                            End If
                        Case 2
                            If w_fec.w_fes3 = "S" Then
                                w_dia_a = 1
                            End If
                        Case 3
                            If w_fec.w_fes4 = "S" Then
                                w_dia_a = 1
                            End If
                        Case 4
                            If w_fec.w_fes5 = "S" Then
                                w_dia_a = 1
                            End If
                        Case 5
                            If w_fec.w_fes6 = "S" Then
                                w_dia_a = 1
                            End If
                    End Select
                    w_vaca = 0
                    If w_fes = "S" Then
                        If w_turno >= 3 Then
                            w_tpocon = "V"
                            w_cpto = 27
                            w_horas = 8
                            w_vaca = 1
                        End If
                    End If
                    Dim w_f = ""
                    If w_dia_a = 1 Then
                        If w_turno = 3 Then
                            w_f = "F"
                            w_tpocon = "V"
                            w_cpto = 27
                            w_horas = 8
                            w_vaca = 0
                        Else
                            If w_turno > 3 Then
                                w_f = "F"
                                w_tpocon = "V"
                                w_cpto = 27
                                w_horas = 8
                                w_vaca = 0
                            End If
                        End If
                    End If
                    If w_festisd = 0 Then
                        w_festi = 1
                    End If
                    If w_vaca = 1 And w_festi = 1 Then
                        b.qr("insert into anom301 values(" + _
                        "8," + _
                        "1," + _
                        a.rs!h7_tponom.ToString + "," + _
                        w_depto.ToString + "," + _
                        a.rs!h7_numtra.ToString + "," + _
                        "0," + _
                        "'" + w_tpocon + "'," + _
                        w_cpto.ToString + "," + _
                        w_horas.ToString + _
                        ",0.0,'" + w_f + "'," + _
                        w_turno.ToString + _
                        ",0," + _
                        w_catego.ToString + "," + _
                        "'" + Mid(w_fecha, 1, 10) + "',0,0,0,0," + _
                        w_tpotra.ToString + "," + _
                        w_sot.ToString + ",0,0,0,0,0)", 2)
                        w_f = ""
                    End If
                    If w_vaca = 1 Then
                        w_festi = w_festi - 1
                    End If
                End If
            Next
        End While
    End Sub
    Sub detalle_301()     '##### DETALLE_301
        Dim w_uno = 1
        Dim fecini = ""
        Dim fecfin = ""
        a.qr("select i4_inisem,i4_finsem from anom304", 1)
        a.rs.Read()
        fecini = Mid(a.rs!i4_inisem.ToString, 1, 10)
        fecfin = Mid(a.rs!i4_finsem.ToString, 1, 10)
        a.qr("select valor from parametros where tipo=1 and clave='calculo'", 1)
        a.rs.Read()
        Select Case a.rs!valor
            Case 1
                a.qr("select * from anom205 with(nolock) where h5_tponom=1 and h5_fecha>='" + fecini + "' and h5_fecha<='" + fecfin + "'", 1)
            Case 2
                a.qr("select * from anom205 with(nolock) where h5_tponom=2  and h5_fecha>='" + fecini + "' and h5_fecha<='" + fecfin + "'", 1)
            Case 3
                a.qr("select * from anom205 with(nolock) where h5_tponom in (1,2) and h5_fecha>='" + fecini + "' and h5_fecha<='" + fecfin + "'", 1)
        End Select
        While a.rs.Read
            b.qr("insert into anom301 values(" + _
            "8," + _
            "3," + _
            a.rs!h5_tponom.ToString + "," + _
            a.rs!h5_depto.ToString + "," + _
            a.rs!h5_numtra.ToString + "," + _
            "0," + _
            "'" + a.rs!h5_tpocon + "'," + _
            a.rs!h5_cpto.ToString + "," + _
            a.rs!h5_horas.ToString + "," + _
            a.rs!h5_importe.ToString + _
            ",''," + _
            "2,'" + _
            a.rs!h5_aplic.ToString + "'," + _
            a.rs!h5_catego.ToString + "," + _
            "'" + Mid(a.rs!h5_fecha.ToString, 1, 10) + "'," + _
            "0," + _
            "0," + _
            "0," + _
            "0," + _
            a.rs!h5_tpotra.ToString + "," + _
            a.rs!h5_sot.ToString + "," + _
            "0," + _
            "0," + _
            "0," + _
            "0," + _
            "0)", 2)
        End While
    End Sub
    Sub desc_fest()  '#### DESC_FEST
        Dim w_fecha_fes As Date
        Dim w_fecha_ant As Date
        Dim w_sindic
        Dim w_sueldo As Double
        Dim w_dias

        a.qr("select h2_fecha from anom304 with(nolock),anom201 with(nolock),anom202 with(nolock)" + _
            " where i4_ano_sem = h1_semana" + _
            " and h2_fecha between h1_fecha_ini and h1_fecha_fin" + _
            " and h2_festivo='S'", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            w_fecha_fes = a.rs!h2_fecha
            w_fecha_ant = w_fecha_fes
            w_fecha_ant = w_fecha_ant.AddDays(-1)
            a.qr("select h3_tponom,h3_numtra,h3_fecha,h3_catego,h3_turno,h3_depto from anom23b with(nolock) where (h3_fecha='" + Mid(w_fecha_fes.ToString, 1, 10) + "' or h3_fecha='" + Mid(w_fecha_ant.ToString, 1, 10) + "')", 1)
            While a.rs.Read
                b.qr("select g5_sindic from anom105 with(nolock) where g5_tponom=" + a.rs!h3_tponom.ToString + " and g5_numtra=" + a.rs!h3_numtra.ToString, 1)
                If b.rs.HasRows Then
                    b.rs.Read()
                    w_sindic = b.rs!g5_sindic
                    If w_sindic = 1 Then
                        b.qr("select g2_sueldo from anom102 with(nolock) where g2_catego=" + a.rs!h3_catego.ToString + " and g2_turno=" + a.rs!h3_turno.ToString, 1)
                        If b.rs.HasRows Then
                            w_sueldo = w_sueldo / 8
                            Select Case a.rs!h3_turno
                                Case 1
                                    If a.rs!h3_fecha = w_fecha_fes Then
                                        w_dias = 8
                                        w_sueldo = w_sueldo * 8
                                    Else
                                        w_dias = 0
                                        w_sueldo = 0
                                    End If
                                Case 2
                                    If a.rs!h3_fecha = w_fecha_fes Then
                                        w_dias = 8
                                        w_sueldo = w_sueldo * 8
                                    Else
                                        w_dias = 0
                                        w_sueldo = 0
                                    End If
                                Case 3
                                    If a.rs!h3_fecha = w_fecha_fes Then
                                        w_dias = 2
                                        w_sueldo = w_sueldo * 2
                                    Else
                                        If a.rs!h3_fecha = w_fecha_ant Then
                                            w_dias = 6
                                            w_sueldo = w_sueldo * 6
                                        Else
                                            w_dias = 0
                                            w_sueldo = 0
                                        End If
                                    End If
                                Case 4
                                    If a.rs!h3_fecha = w_fecha_fes Then
                                        w_dias = 2
                                        w_sueldo = w_sueldo * 2
                                    Else
                                        If a.rs!h3_fecha = w_fecha_ant Then
                                            w_dias = 6
                                            w_sueldo = w_sueldo * 6
                                        Else
                                            w_dias = 0
                                            w_sueldo = 0
                                        End If
                                    End If
                            End Select
                            If w_sueldo > 0 Then
                                b.qr("insert into anom301 values(" + _
                                "8," + _
                                "1," + _
                                a.rs!h3_tponom.ToString + "," + _
                                a.rs!h3_depto.ToString + "," + _
                                a.rs!h3_numtra.ToString + "," + _
                                "0," + _
                                "'V'," + _
                                "401," + _
                                w_dias.ToString + "," + _
                                w_sueldo.ToString + _
                                ",''," + _
                                a.rs!h3_turno.ToString + _
                                ",0," + _
                                a.rs!h3_catego.ToString + "," + _
                                "'" + a.rs!h3_fecha.ToString + "'," + _
                                "0," + _
                                "0," + _
                                "0," + _
                                "0," + _
                                "1," + _
                                "0," + _
                                "0," + _
                                "0," + _
                                "0," + _
                                "0," + _
                                "0)", 2)
                            End If
                        End If
                    End If
                End If
            End While
        End If
    End Sub
    Sub infonavit()
        Dim w_minimo As Double = 0
        Dim w_festivo = 0
        Dim w_fac_dias As Double = 0
        Dim w_dias As Double = 0
        Dim w_depto = 0
        Dim w_dias_b = 0
        Dim w_fecha As String = "01/01/2016"
        Dim query = "h2_dia<6"
        a.qr("select i4_minimo, i4_numfes,i4_finsem from anom304 with(nolock)", 1)
        a.rs.Read()
        w_minimo = a.rs!i4_minimo
        w_festivo = a.rs!i4_numfes
        w_fecha = a.rs!i4_finsem
        a.qr("select h13_tponom,h13_numtra,h13_porc,g5_sasegi,g5_dptoz,g5_dptor from anom213 with(nolock),anom105 with(nolock) where h13_tponom = g5_tponom and h13_numtra = g5_numtra", 1)
        While a.rs.Read
            If w_ciclo = "1" Then
                Select Case w_festivo
                    Case 0
                        w_fac_dias = 1.166667
                    Case 1
                        w_fac_dias = 1.4
                    Case 2
                        w_fac_dias = 1.75
                End Select
                query = " and h2_dia<7"
                w_depto = a.rs!g5_dptoz.ToString
            Else
                Select Case w_festivo
                    Case 0
                        w_fac_dias = 1.4
                    Case 1
                        w_fac_dias = 1.75
                    Case 2
                        w_fac_dias = 2.33
                End Select
                query = " and h2_dia<6"
                w_depto = a.rs!g5_dptor.ToString
            End If
            b.qr("select count(distinct h2_fecha) dias from anom202 with(nolock),anom201 with(nolock),anom304 with(nolock),anom23b with(nolock)" + _
                " where h1_semana = i4_ano_sem" + _
                " and h2_fecha between h1_fecha_ini and h1_fecha_fin" + _
                query + _
                " and h2_festivo='N'" + _
                " and h2_fecha=h3_fecha" + _
                " and h3_numtra=" + a.rs!h13_numtra.ToString + _
                " and h3_tponom=" + a.rs!h13_tponom.ToString, 1)
            b.rs.Read()
            w_dias_b = Math.Round(b.rs!dias, 0)
            w_fac_dias = Math.Round(w_fac_dias * b.rs!dias, 0)
            b.qr("select g18_porc_aplic w_porc_aplic from anom118 with(nolock)" + _
                " where g18_salmin_inf <= " + Math.Round(a.rs!g5_sasegi / w_minimo, 2).ToString + _
                " and g18_salmin_sup >= " + Math.Round(a.rs!g5_sasegi / w_minimo, 2).ToString + _
                " and g18_porc_asig = " + a.rs!h13_porc.ToString, 1)
            If b.rs.HasRows Then
                b.rs.Read()
                w_fac_dias = w_fac_dias * a.rs!g5_sasegi * (b.rs!w_porc_aplic / 100)
                b.qr("insert into anom301 values(" + _
                    "8," + _
                    "4," + _
                    a.rs!h13_tponom.ToString + "," + _
                    w_depto.ToString + "," + _
                    a.rs!h13_numtra.ToString + "," + _
                    "0," + _
                    "'I'," + _
                    "459," + _
                    w_dias_b.ToString + "," + _
                    w_fac_dias.ToString + _
                    ",''," + _
                    "2" + _
                    ",0," + _
                    "0," + _
                    "'" + w_fecha + "'," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "1," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0)", 2)
            End If
        End While
    End Sub
    Sub luz_y_renta_301()
        Dim w_numfes = 0
        Dim w_ciclo = ""
        Dim w_dias_luz = 0
        a.qr("select i4_numfes,i4_ciclo from anom304 with(nolock)", 1)
        a.rs.Read()
        w_numfes = a.rs!i4_numfes
        w_ciclo = a.rs!i4_ciclo
        a.qr("select i1_numtra,i1_tpocon,min(i1_fecha) i1_fecha,count(i1_hrs_dom) i1_dias " + _
         " from anom301 with(nolock), anom105 with(nolock)" + _
         " where g5_numtra = i1_numtra" + _
         " and g5_tponom=i1_tponom" + _
         " and g5_sindic=1" + _
         " and i1_cpto=3" + _
         " and g5_plaza!=3" + _
         " group by i1_numtra,i1_tpocon" + _
         " order by 1", 1)
        While a.rs.Read
            If w_ciclo = "Z" Then
                If a.rs!i1_dias = 1 Then
                    w_dias_luz = 0
                Else
                    If a.rs!i1_dias >= 3 Then
                        w_dias_luz = a.rs!i1_dias + 1
                    Else
                        w_dias_luz = a.rs!i1_dias
                    End If
                End If
            Else
                If a.rs!i1_dias = 1 Then
                    w_dias_luz = 2
                Else
                    If a.rs!i1_dias > 1 Then
                        w_dias_luz = a.rs!i1_dias + 2
                    End If
                End If
            End If
            w_dias_luz = w_numfes + w_dias_luz
            If w_dias_luz > 0 Then
                b.qr("insert into anom301 values(" + _
                    "8," + _
                    "1," + _
                    "1," + _
                    "13000," + _
                    a.rs!i1_numtra.ToString + "," + _
                    "0," + _
                    "'V'," + _
                    "115," + _
                    "0," + _
                    Math.Round(w_dias_luz * 0.32877, 2).ToString + _
                    ",''," + _
                    "2" + _
                    ",0," + _
                    "0," + _
                    "'" + Mid(a.rs!i1_fecha.ToString, 1, 10) + "'," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "1," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0," + _
                    "0)", 2)
            End If
        End While
    End Sub
    Sub saldos_301()
        Dim g14_cuota As Decimal
        Dim w_semana As Integer
        Dim wcic As Char = ""
        Dim wfecha As String = ""
        a.qr("select i4_ano_sem,i4_ciclo,i4_inisem from anom304 with(nolock)", 1)
        a.rs.Read()
        w_semana = a.rs!i4_ano_sem.ToString
        wcic = a.rs!i4_ciclo
        wfecha = a.rs!i4_inisem.ToString
        a.qr("select g14_tponom," + _
            " g14_numtra," + _
            " g14_cpto," + _
            " g14_cuota," + _
            " g14_saldo," + _
            " g14_compara," + _
            " g14_depto" + _
            " from anom114 with(nolock)" + _
            " where g14_cuota != 0" + _
            " and g14_perded = 2", 1)
        While a.rs.Read
            If a.rs!g14_compara = 0 Then
                g14_cuota = a.rs!g14_cuota
                If a.rs!g14_cuota > a.rs!g14_saldo Then
                    g14_cuota = a.rs!g14_saldo
                End If
            End If
            If g14_cuota <> 0 Then
                b.qr("insert into anom301 values(" + _
                "8," + _
                "5," + _
                a.rs!g14_tponom.ToString + "," + _
                "13000," + _
                a.rs!g14_numtra.ToString + "," + _
                "0," + _
                "''," + _
                a.rs!g14_cpto.ToString + "," + _
                "0," + _
                g14_cuota.ToString + _
                ",''," + _
                "2" + _
                ",0," + _
                "0," + _
                "'" + Mid(wfecha, 1, 10) + "'," + _
                "0," + _
                "0," + _
                "0," + _
                "0," + _
                "1," + _
                "0," + _
                "0," + _
                "0," + _
                "0," + _
                "0," + _
                "1)", 2)
            End If
        End While
    End Sub
End Class
