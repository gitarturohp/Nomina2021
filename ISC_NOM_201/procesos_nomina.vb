Imports System.Data.SqlClient
Public Class procesos_nomina
    Public a As New Clase
    Public b As New Clase
    Public c As New Clase
    Public w_302a, w_302b, w_302c, w_302d As SqlDataReader
    Sub f_nom302()
        a.qr("select * from anom301 with(nolock) where i1_importe=0 and i1_cpto<400 order by i1_tponom,i1_numtra", 1)
        While a.rs.Read
            valoriza_302()
        End While
    End Sub
    Sub valoriza_302()
        Dim w_ciclo, w_festivo, w_sabado_festivo
        w_302a = a.rs
        b.qr("select i4_ciclo w_ciclo,i4_lun_fest w_festivo,i4_sab_fest w_sabado_festivo from anom304 with(nolock)", 1)
        b.rs.Read()
        w_ciclo = b.rs!w_ciclo
        w_festivo = b.rs!w_festivo
        w_sabado_festivo = b.rs!w_sabado_festivo
        Dim w_importe As Double
        Dim w_cpto As Short
        b.qr("select g2_catego,g2_sueldo,g2_horext,g2_hormix,g2_horali,g2_comzaf,g2_comrep,g2_comalt from anom102 with(nolock)" + _
             " where g2_cveing=8 " + _
             " and g2_catego=" + w_302a!i1_catego.ToString + _
             " and g2_turno=" + w_302a!i1_turno.ToString, 1)
        b.rs.Read()
        If w_302a!i1_cpto = 3 Then
            c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                 "," + w_302a!i1_numtra.ToString + _
                 ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                 "'," + w_302a!i1_cpto.ToString + _
                 "," + b.rs!g2_sueldo.ToString + ",1," + w_302a!i1_cpto.ToString, 2)
        End If
        If w_302a!i1_cpto = 19 Then
            If w_sabado_festivo = "N" Then
                c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                     "," + w_302a!i1_numtra.ToString + _
                     ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                     "',19" + _
                     "," + b.rs!g2_sueldo.ToString + ",1,3", 2)
            Else
                c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                     "," + w_302a!i1_numtra.ToString + _
                     ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                     "',19" + _
                     "," + (b.rs!g2_sueldo / 8 * 4).ToString + ",2,27", 2)
            End If
            w_cpto = 21
            w_importe = b.rs!g2_sueldo / 8 * 6
            inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, 2, 0)
            w_cpto = 24
            w_importe = b.rs!g2_sueldo / 8 * 6 * 0.25
            inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, 0, 0)
        End If
        '#############   SABADO TRABAJADO
        If w_302a!i1_cpto = 4 Then
            w_importe = w_302a!i1_hrs_dom * b.rs!g2_horext * 0.5
            c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                 "," + w_302a!i1_numtra.ToString + _
                 ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                 "'," + w_302a!i1_cpto.ToString + _
                 "," + w_importe.ToString + _
                 "," + w_302a!i1_hrs_dom.ToString + _
                 "," + w_302a!i1_cpto.ToString, 2)
            '########## PRIMA SABATINA
            If w_ciclo = "R" And w_302a!i1_hrs_dom >= 8 Then
                w_importe = b.rs!g2_horext * 0.5 * 8 * 0.4
                w_cpto = 20
                inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, w_302a!i1_hrs_dom, 0)
            End If
        End If
        '########## DOMINGO TRABAJADO
        Dim w_diadom As SByte = 0
        If w_302a!i1_cpto = 21 Then
            '########## TURNO 1 O 2
            Try
                If w_302a!i1_turno = 1 Or w_302a!i1_turno = 2 Then
                    w_importe = w_302a!i1_hrs_dom * b.rs!g2_horext
                    c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                         "," + w_302a!i1_numtra.ToString + _
                         ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                         "'," + w_302a!i1_cpto.ToString + _
                         "," + w_importe.ToString + _
                         "," + w_302a!i1_hrs_dom.ToString + _
                         "," + w_302a!i1_cpto.ToString, 2)
                End If
            Catch ex As Exception
                MsgBox(w_302a!i1_numtra)
            End Try
            '########## TURNO 3
            If w_302a!i1_turno = 3 Then
                If w_302a!i1_hrs_dom > 4 Then
                    w_diadom = w_302a!i1_hrs_dom + 2
                    If w_festivo = "S" Then
                        w_diadom = w_diadom + 6
                    End If
                End If
                If w_302a!i1_hrs_dom <= 4 Then
                    w_diadom = w_302a!i1_hrs_dom * 2
                End If
                w_importe = w_diadom * b.rs!g2_horext * 0.5
                c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                     "," + w_302a!i1_numtra.ToString + _
                     ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                     "'," + w_302a!i1_cpto.ToString + _
                     "," + w_importe.ToString + _
                     "," + w_302a!i1_hrs_dom.ToString + _
                     "," + w_302a!i1_cpto.ToString, 2)
            End If
            '########## TURNO 4
            If w_302a!i1_turno = 4 Then
                If w_302a!i1_hrs_dom > 2 Then
                    'w_diadom = w_302a!i1_hrs_dom + 2
                    w_diadom = w_302a!i1_hrs_dom
                End If
                If w_302a!i1_hrs_dom <= 2 Then
                    w_diadom = w_302a!i1_hrs_dom * 2
                End If
                If w_festivo = "S" Then
                    w_diadom = w_302a!i1_hrs_dom + 6
                End If
                'w_importe = w_diadom * b.rs!g2_horext * 0.5
                w_importe = w_diadom * b.rs!g2_horext
                c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                     "," + w_302a!i1_numtra.ToString + _
                     ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                     "'," + w_302a!i1_cpto.ToString + _
                     "," + w_importe.ToString + _
                     "," + w_302a!i1_hrs_dom.ToString + _
                     "," + w_302a!i1_cpto.ToString, 2)
            End If
        End If
        '########## PRIMA DOMINICAL CPTO (24)
        If w_302a!i1_cpto = 21 Then
            If w_302a!i1_turno = 1 Or w_302a!i1_turno = 2 Then
                If w_302a!i1_hrs_dom > 8 Then
                    w_importe = b.rs!g2_sueldo * 0.25
                Else
                    w_importe = b.rs!g2_sueldo * 0.25
                End If
                w_cpto = 24
                Try
                    inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, w_302a!i1_hrs_dom, 0)
                Catch ex As Exception
                    MsgBox(w_302a!i1_numtra)
                End Try

            End If
            If w_302a!i1_turno = 3 And w_302a!i1_hrs_dom > 4 Then
                'w_importe = b.rs!g2_sueldo * 0.25 * (4 / 8)
                w_importe = b.rs!g2_sueldo * 0.25
                w_cpto = 24
                inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, w_302a!i1_hrs_dom, 0)
            End If
            If w_302a!i1_turno = 4 Then
                If w_302a!i1_hrs_dom > 2 Then
                    'w_importe = b.rs!g2_sueldo * 0.25 * (2 / 8)
                    w_importe = b.rs!g2_sueldo * 0.25
                    w_cpto = 24
                    inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, w_302a!i1_hrs_dom, 0)
                End If
            End If
        End If
        '########## TIEMPO EXTRA DOBLE (16) HORAS TURNO (9)
        Dim w_difer As Double = 0
        Dim w_imp_htrip As Double
        Dim w_imp_hdobl As Double
        If w_302a!i1_cpto = 16 Or w_302a!i1_cpto = 9 Then
            w_importe = w_302a!i1_hrs_dom * b.rs!g2_horext
            c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                 "," + w_302a!i1_numtra.ToString + _
                 ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                 "'," + w_302a!i1_cpto.ToString + _
                 "," + w_importe.ToString + _
                 "," + w_302a!i1_hrs_dom.ToString + _
                 "," + w_302a!i1_cpto.ToString, 2)
        End If
        If w_302a!i1_cpto = 15 Then
            If w_302a!i1_hrs_dom > 9 Then
                w_difer = w_302a!i1_hrs_dom - 9
                w_imp_htrip = (b.rs!g2_horext / 2) * 3 * w_difer
                w_imp_hdobl = (b.rs!g2_horext / 2) * 2 * 9
                w_importe = w_imp_hdobl
                w_cpto = 15
                c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                     "," + w_302a!i1_numtra.ToString + _
                     ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                     "'," + w_302a!i1_cpto.ToString + _
                     "," + w_importe.ToString + _
                     "," + "9" + _
                     "," + w_302a!i1_cpto.ToString, 2)
                w_importe = w_imp_htrip
                w_cpto = 18
                c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                     "," + w_302a!i1_numtra.ToString + _
                     ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                     "'," + w_302a!i1_cpto.ToString + _
                     "," + w_importe.ToString + _
                     "," + w_difer.ToString + _
                     "," + w_cpto.ToString, 2)
            Else
                w_imp_hdobl = w_302a!i1_hrs_dom * b.rs!g2_horext
                w_importe = w_imp_hdobl
                w_cpto = 15
                c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                     "," + w_302a!i1_numtra.ToString + _
                     ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                     "'," + w_302a!i1_cpto.ToString + _
                     "," + w_importe.ToString + _
                     "," + w_difer.ToString + _
                     "," + w_cpto.ToString, 2)
            End If
        End If
        '######### HORAS TURNO GENERA ALIMENTOS (CPTO 9 Y 12)
        If w_302a!i1_f <> "F" Then
            If w_302a!i1_cpto = 3 Or
                w_302a!i1_cpto = 4 Or
                w_302a!i1_cpto = 21 Or
                w_302a!i1_cpto = 27 Or
                w_302a!i1_cpto = 19 Then
                If b.rs!g2_hormix > 0 Then
                    w_importe = b.rs!g2_hormix
                    w_cpto = 9
                    inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, 1, 0)
                End If
                If b.rs!g2_horali > 0 Then
                    w_importe = b.rs!g2_horali
                    w_cpto = 12
                    inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, 0.5, 0)
                End If
            End If
        End If
        If w_302a!i1_cpto = 34 Then
            w_importe = w_302a!i1_hrs_dom * b.rs!g2_horext
            c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                 "," + w_302a!i1_numtra.ToString + _
                 ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                 "'," + w_302a!i1_cpto.ToString + _
                 "," + w_importe.ToString + _
                 "," + w_302a!i1_hrs_dom.ToString + _
                 "," + w_302a!i1_cpto.ToString, 2)
        End If
        If w_302a!i1_cpto = 30 Or
            w_302a!i1_cpto = 33 Or
            w_302a!i1_cpto = 36 Or
            w_302a!i1_cpto = 37 Then
            w_importe = w_302a!i1_hrs_dom * b.rs!g2_horext * 0.5
            c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                 "," + w_302a!i1_numtra.ToString + _
                 ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                 "'," + w_302a!i1_cpto.ToString + _
                 "," + w_importe.ToString + _
                 "," + w_302a!i1_hrs_dom.ToString + _
                 "," + w_302a!i1_cpto.ToString, 2)
        End If
        '##### AJUSTE DE SALARIO CPTO 78
        If w_302a!i1_cpto = 79 Or w_302a!i1_cpto = 78 Then
            w_importe = w_302a!i1_hrs_dom * b.rs!g2_sueldo
            c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                 "," + w_302a!i1_numtra.ToString + _
                 ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                 "'," + w_302a!i1_cpto.ToString + _
                 "," + w_importe.ToString + _
                 "," + w_302a!i1_hrs_dom.ToString + _
                 "," + w_302a!i1_cpto.ToString, 2)
        End If
        '##### FESTIVO TRABAJADO CPTO 27
        If w_302a!i1_cpto = 27 And w_302a!i1_tpo_emision = 1 Then
            If w_festivo = "S" Then
                w_importe = w_302a!i1_hrs_dom * b.rs!g2_horext
            Else
                w_importe = w_302a!i1_hrs_dom * b.rs!g2_horext
            End If
            c.qr("exec actualiza_301 " + w_302a!i1_tponom.ToString + _
                 "," + w_302a!i1_numtra.ToString + _
                 ",'" + Mid(w_302a!i1_fecha.ToString, 1, 10) + _
                 "'," + w_302a!i1_cpto.ToString + _
                 "," + w_importe.ToString + _
                 "," + w_302a!i1_hrs_dom.ToString + _
                 "," + w_302a!i1_cpto.ToString, 2)
        End If
        '##### COMPENSACION ZAFRA CPTO 25
        If w_ciclo = "Z" And w_302a!i1_f <> "F" Then
            Try
                If b.rs!g2_comzaf > 0 And
                    (w_302a!i1_cpto = 3 Or
                     w_302a!i1_cpto = 19 Or
                     w_302a!i1_cpto = 27 Or
                     (w_302a!i1_cpto = 21 And w_302a!i1_hrs_dom >= 8)) Then
                    w_importe = b.rs!g2_comzaf
                    w_cpto = 25
                    inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, 0, 0)
                End If
            Catch ex As Exception
                MsgBox(w_302a!i1_numtra.ToString)
            End Try
        End If
        '##### COMPENSACION REPARACION CPTO 26
        If w_ciclo = "R" And w_302a!i1_f <> "F" Then
            If b.rs!g2_comzaf > 0 And
                (w_302a!i1_cpto = 3 Or
                 w_302a!i1_cpto = 4 Or
                 w_302a!i1_cpto = 19 Or
                 w_302a!i1_cpto = 27 Or
                 (w_302a!i1_cpto = 21 And w_302a!i1_hrs_dom >= 8)) Then
                w_importe = b.rs!g2_comzaf
                w_cpto = 26
                inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, 0, 0)
            End If
        End If
        '##### ALTURA CPTO 36
        If w_302a!i1_f <> "F" Then
            Try
                If b.rs!g2_comalt > 0 And (w_302a!i1_cpto = 3 Or
                                           w_302a!i1_cpto = 4 Or
                                           w_302a!i1_cpto = 19 Or
                                           w_302a!i1_cpto = 27 Or
                                           (w_302a!i1_cpto = 21 And w_302a!i1_hrs_dom >= 8)) Then
                    w_importe = b.rs!g2_comalt
                    w_cpto = 36
                    inserta_301x(w_302a!i1_tponom, w_302a!i1_numtra, w_302a!i1_depto, w_302a!i1_fecha, w_cpto, w_importe, 0, 0)
                End If
            Catch ex As Exception
                MsgBox(w_302a!i1_numtra.ToString)
            End Try

        End If
    End Sub
    Sub f_nom303()     '######### CALCULO DE SEXTO Y SEPTIMO DIA
        Dim w_importe As Double = 0
        Dim w_sueldia As Double = 0
        Dim w_numfes = 0
        Dim w_importe2 As Double = 0
        Dim w_sabado_festivo = ""
        Dim w_ciclo = "X"
        a.qr("select i4_ciclo,i4_numfes,i4_sab_fest from anom304 with(nolock)", 1)
        a.rs.Read()
        w_ciclo = a.rs!i4_ciclo
        w_numfes = a.rs!i4_numfes
        w_sabado_festivo = a.rs!i4_sab_fest
        a.qr("select i1_tponom,i1_numtra,sum(i1_hrs_dom) i1_hrs_dom,sum(i1_importe) i1_importe from anom301 with(nolock) where i1_cpto=3 group by i1_tponom,i1_numtra", 1)
        While a.rs.Read
            w_importe = a.rs!i1_importe
            Dim w_hortur = 0
            b.qr("select case when sum(i1_importe) is null then 0 else sum(i1_importe) end horas from anom301 with(nolock)" + _
                 " where i1_tponom=" + a.rs!i1_tponom.ToString + " and i1_numtra=" + a.rs!i1_numtra.ToString + " and i1_cpto=9", 1)
            b.rs.Read()
            w_importe = w_importe + b.rs!horas
            w_sueldia = Math.Round(w_importe / a.rs!i1_hrs_dom, 2, MidpointRounding.AwayFromZero)
            w_importe = 0
            If w_ciclo = "R" Then
                ' ================ Reparacion
                b.qr("select g19_septimo from anom119 with(nolock) where g19_ciclo='R' and g19_festivo=" + w_numfes.ToString + " and g19_dias=" + a.rs!i1_hrs_dom.ToString, 1)
                b.rs.Read()
                w_importe = w_sueldia * b.rs!g19_septimo
                w_importe2 = Math.Round(w_importe * a.rs!i1_hrs_dom, 2, MidpointRounding.AwayFromZero)
                b.qr("select top 1 * from anom301 with(nolock) where i1_tponom=" + a.rs!i1_tponom.ToString + " and i1_numtra=" + a.rs!i1_numtra.ToString + " order by i1_cpto", 1)
                b.rs.Read()
                If w_sabado_festivo <> "S" Then
                    inserta_301x(b.rs!i1_tponom, b.rs!i1_numtra, b.rs!i1_depto, b.rs!i1_fecha, 5, w_importe2, b.rs!i1_hrs_dom, 0)
                End If
                inserta_301x(b.rs!i1_tponom, b.rs!i1_numtra, b.rs!i1_depto, b.rs!i1_fecha, 6, w_importe2, b.rs!i1_hrs_dom, 0)
                For x = 1 To w_numfes
                    inserta_301x(b.rs!i1_tponom, b.rs!i1_numtra, b.rs!i1_depto, b.rs!i1_fecha, 28, w_importe2, b.rs!i1_hrs_dom, 0)
                Next
            Else
                ' ================ Zafra
                b.qr("select g19_septimo from anom119 with(nolock) where g19_ciclo='Z' and g19_festivo=" + w_numfes.ToString + " and g19_dias=" + a.rs!i1_hrs_dom.ToString, 1)
                b.rs.Read()
                w_importe = w_sueldia * b.rs!g19_septimo
                w_importe2 = w_importe * a.rs!i1_hrs_dom
                b.qr("select top 1 * from anom301 with(nolock) where i1_tponom=" + a.rs!i1_tponom.ToString + " and i1_numtra=" + a.rs!i1_numtra.ToString + " order by i1_cpto", 1)
                b.rs.Read()
                inserta_301x(b.rs!i1_tponom, b.rs!i1_numtra, b.rs!i1_depto, b.rs!i1_fecha, 6, w_importe2, b.rs!i1_hrs_dom, 0)
                For x = 1 To w_numfes
                    inserta_301x(b.rs!i1_tponom, b.rs!i1_numtra, b.rs!i1_depto, b.rs!i1_fecha, 28, w_importe2, b.rs!i1_hrs_dom, 0)
                Next
            End If
        End While
    End Sub
    Sub f_nom304()
        Dim w_304a(5) As Double
        a.qr("select i4_con_obr,i4_imp_obr,i4_con_emp,i4_imp_emp,i4_dias_descto,i4_desc_fest from anom304 with(nolock)", 1)
        a.rs.Read()
        w_304a(0) = a.rs!i4_con_obr
        w_304a(1) = a.rs!i4_imp_obr
        w_304a(2) = a.rs!i4_con_emp
        w_304a(3) = a.rs!i4_imp_emp
        w_304a(4) = a.rs!i4_dias_descto
        a.qr("select i1_tponom,i1_numtra,max(i1_depto) i1_depto,sum(i1_hrs_dom) i1_hrs_dom,sum(i1_importe) i1_importe,min(i1_fecha) i1_fecha from anom301 with(nolock) where i1_cpto=3 group by i1_tponom,i1_numtra", 1)
        While a.rs.Read
            b.qr("select g5_sindic from anom105 with(nolock) where g5_tponom=" + a.rs!i1_tponom.ToString + " and g5_numtra=" + a.rs!i1_numtra.ToString, 1)
            b.rs.Read()
            Try
                calc_304(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, b.rs!g5_sindic, a.rs!i1_importe, a.rs!i1_hrs_dom, w_304a, a.rs!i1_fecha)
            Catch ex As Exception
                MsgBox(a.rs!i1_numtra)
            End Try

        End While
    End Sub
    Sub calc_304(ByVal w_tponom As SByte, ByVal w_numtra As Short, ByVal w_depto As Short, ByVal w_sindic As SByte, ByVal w_importe As Double, ByVal w_hrs_dom As SByte, ByRef w304a() As Double, ByVal fecha As Date)
        If w_sindic = 1 Then
            If w_tponom = 1 Then
                If w304a(1) > 0 Then
                    inserta_301x(w_tponom, w_numtra, w_depto, fecha, w304a(0), w304a(1), 1, 0)
                End If
            Else
                If w304a(3) > 0 Then
                    inserta_301x(w_tponom, w_numtra, w_depto, fecha, w304a(2), w304a(3), 1, 0)
                End If
            End If
            If w304a(4) > 0 Then
                inserta_301x(w_tponom, w_numtra, w_depto, fecha, 401, (w_importe / w_hrs_dom) * w304a(4), 1, 0)
            End If
        End If
    End Sub
    Sub f_nom305()
        Dim w_min5, w_min15, w_min30, w_minimo, w_imp50, w_imp17 As Double
        a.qr("select i4_minimo from anom304 with(nolock)", 1)
        a.rs.Read()
        w_min5 = a.rs!i4_minimo * 5
        w_min15 = a.rs!i4_minimo * 7.5
        w_min30 = a.rs!i4_minimo * 30
        w_minimo = a.rs!i4_minimo
        w_imp17 = 0
        a.qr("update anom301 set i1_tpo_emision=8 where i1_cpto in (4,15,16,20,21,24,27,45,66)", 2)
        a.qr("select i1_tponom,i1_numtra,g5_sindic,max(i1_depto) i1_depto," +
           " sum(case when i1_cpto=4 then i1_hrs_dom else 0 end) i1_horas4," +
           " sum(case when i1_cpto=15 then i1_hrs_dom else 0 end) i1_horas15," +
           " sum(case when i1_cpto=20 then i1_hrs_dom else 0 end) i1_horas20," +
           " sum(case when i1_cpto=16 then i1_hrs_dom else 0 end) i1_horas16," +
           " sum(case when i1_cpto=21 then i1_hrs_dom else 0 end) i1_horas21," +
           " sum(case when i1_cpto=24 then i1_hrs_dom else 0 end) i1_horas24," +
           " sum(case when i1_cpto=27 then i1_hrs_dom else 0 end) i1_horas27," +
           " sum(case when i1_cpto=45 then i1_hrs_dom else 0 end) i1_horas45," +
           " sum(case when i1_cpto=66 then i1_hrs_dom else 0 end) i1_horas66," +
           " sum(case when i1_cpto=4 then i1_importe else 0 end) i1_importe4," +
           " sum(case when i1_cpto=15 then i1_importe else 0 end) i1_importe15," +
           " sum(case when i1_cpto=20 then i1_importe else 0 end) i1_importe20," +
           " sum(case when i1_cpto=16 then i1_importe else 0 end) i1_importe16," +
           " sum(case when i1_cpto=21 then i1_importe else 0 end) i1_importe21," +
           " sum(case when i1_cpto=24 then i1_importe else 0 end) i1_importe24," +
           " sum(case when i1_cpto=27 then i1_importe else 0 end) i1_importe27," +
           " sum(case when i1_cpto=45 then i1_importe else 0 end) i1_importe45," +
           " sum(case when i1_cpto=66 then i1_importe else 0 end) i1_importe66," +
           " min(i1_fecha) i1_fecha " +
           " from anom301 with(nolock),anom105 with(nolock) where i1_cpto in (4,15,20,16,21,24,27,45,66) " +
           " and g5_tponom=i1_tponom" +
           " and g5_numtra=i1_numtra" +
           " and i1_tpo_emision=8" +
           " group by i1_tponom,i1_numtra,g5_sindic" +
           " order by i1_tponom,i1_numtra", 1)
        While a.rs.Read
            If a.rs!i1_importe24 > 0 Then
                If a.rs!i1_importe24 > w_minimo Then
                    inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 24, a.rs!i1_importe24 - w_minimo, a.rs!i1_horas24, 0)
                    inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 23, w_minimo, 0, 0)
                Else
                    inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 23, a.rs!i1_importe24, 0, 0)
                End If
            End If
            If a.rs!i1_importe66 > 0 Then
                If a.rs!i1_importe66 > w_minimo Then
                    inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 66, a.rs!i1_importe66 - w_min30, a.rs!i1_horas66, 0)
                    inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 166, w_min30, 0, 0)
                Else
                    inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 166, a.rs!i1_importe66, a.rs!i1_horas66, 0)
                End If
            End If
            w_imp50 = Math.Round((a.rs!i1_importe4 + a.rs!i1_importe15 + a.rs!i1_importe16 + a.rs!i1_importe20 + a.rs!i1_importe21 + a.rs!i1_importe27) / 2, 2)
            If w_imp50 > w_min5 Then
                w_imp50 = w_min5
            End If
            If w_imp50 > a.rs!i1_importe21 Then
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 22, a.rs!i1_importe21, 0, 0)
                w_imp50 = w_imp50 - a.rs!i1_importe21
            Else
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 21, a.rs!i1_importe21 - w_imp50, a.rs!i1_horas21, 0)
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 22, w_imp50, 0, 0)
                w_imp50 = 0
            End If
            If w_imp50 > a.rs!i1_importe27 Then
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 29, a.rs!i1_importe27, 0, 0)
                w_imp50 = w_imp50 - a.rs!i1_importe27
            Else
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 27, a.rs!i1_importe27 - w_imp50, a.rs!i1_horas27, 0)
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 29, w_imp50, 0, 0)
                w_imp50 = 0
            End If
            If w_imp50 > a.rs!i1_importe4 Then
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 7, a.rs!i1_importe4, 0, 0)
                w_imp50 = w_imp50 - a.rs!i1_importe4
            Else
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 4, a.rs!i1_importe4 - w_imp50, a.rs!i1_horas4, 0)
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 7, w_imp50, 0, 0)
                w_imp50 = 0
            End If
            If w_imp50 > a.rs!i1_importe20 Then
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 19, a.rs!i1_importe20, 0, 0)
                w_imp50 = w_imp50 - a.rs!i1_importe4
            Else
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 20, a.rs!i1_importe20 - w_imp50, a.rs!i1_horas20, 0)
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 19, w_imp50, 0, 0)
                w_imp50 = 0
            End If
            If w_imp50 > a.rs!i1_importe15 Then
                w_imp17 = a.rs!i1_importe15
                w_imp50 = w_imp50 - a.rs!i1_importe15
            Else
                inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 15, a.rs!i1_importe15 - w_imp50, a.rs!i1_horas15, 0)
                w_imp17 = w_imp50
                w_imp50 = 0
            End If
            inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 16, a.rs!i1_importe16 - w_imp50, a.rs!i1_horas16, 0)
            inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, a.rs!i1_depto, a.rs!i1_fecha, 17, w_imp17 + w_imp50, 0, 0)
        End While
        a.qr("delete from anom301 where i1_importe=0 and i1_tpo_emision=7", 2)
    End Sub
    Sub f_nom306()
        Dim w_ispt = 0.0
        Dim devispt = 0.0
        Dim dias = 0.0
        Dim wfecha As Date
        Dim cpto_pension = ""
        Dim cpto_457 = ""
        Dim cpto_clubes = ""
        Dim receso = 0
        Dim wsalmin As Decimal
        a.qr("select valor from parametros where clave='receso' and tipo=1", 1)
        a.rs.Read()
        receso = a.rs!valor
        a.qr("select * from anom101 with(nolock)", 1)
        a.rs.Read()
        cpto_pension = a.rs!g1_pension
        cpto_clubes = a.rs!g1_clubes
        cpto_457 = "3,42,48,45,75"
        a.qr("select * from anom304 with(nolock)", 1)
        a.rs.Read()
        wfecha = a.rs!i4_inisem
        wsalmin = a.rs!i4_minimo
        a.qr("exec crea_301b", 2)
        a.qr("insert into anom301b select distinct i1_tponom,i1_numtra,0.00,0,0 from anom301", 2)
        a.qr("update anom301b set i1b_ispt=(select sum(i1_importe) " + _
             " from anom301 " + _
             " where i1_numtra=i1b_numtra" + _
             " and i1_tponom=i1b_tponom " + _
             " and i1_cpto<116 " + _
             " and i1_cpto not in (select g4_cpto from anom104 where g4_exento=1 and g4_cpto<116) " + _
             " and i1_tpo_emision<8)", 2)
        a.qr("update anom301b set i1b_diasispt=(select count(*) from anom301 where i1_numtra=i1b_numtra and i1_tponom=i1b_tponom and i1_cpto=3 and i1_tpo_emision<8)", 2)
        a.qr("update anom301b set i1b_diasispt=(select g19_factor from anom119,anom304 where g19_ciclo=i4_ciclo and g19_festivo=i4_numfes and g19_dias=i1b_diasispt)", 2)
        a.qr("select * from anom301b with(nolock) where i1b_ispt>0", 1)
        While a.rs.Read
            dias = a.rs!i1b_diasispt
            b.qr("select count(*) x from anom301 with(nolock) where i1_tponom=" + a.rs!i1b_tponom.ToString + " and i1_numtra=" + a.rs!i1b_numtra.ToString + " and i1_cpto in (4,21,27) and i1_tpo_emision<8", 1)
            b.rs.Read()
            If b.rs!x > 0 Then
                If a.rs!i1b_diasispt = 1 Then
                    dias = 0
                End If
            End If
            dias = dias + b.rs!x
            If dias = 0 Then
                dias = 7
            End If
            If dias > 7 Then
                dias = 7
            End If

            '##### CALCULO DE IMPUESTO CPTO 403

            b.qr("select g7_inferior," +
                " g7_cuota," +
                " g7_porc" +
                " from anom107 with(nolock)" +
                " where g7_cveing = 8" +
                " and g7_tipo='S'" +
                " and g7_inferior <= " + a.rs!i1b_ispt.ToString +
                " and g7_superior >= " + a.rs!i1b_ispt.ToString, 1)
            b.rs.Read()
            w_ispt = Math.Round(a.rs!i1b_ispt - b.rs!g7_inferior, 2)
            w_ispt = Math.Round(w_ispt * (b.rs!g7_porc / 100), 2)
            w_ispt = Math.Round(w_ispt + b.rs!g7_cuota, 2)
            inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 403, Math.Round(w_ispt, 2), 1, 0)

            '##### DEVOLUCION DE IMPUESTO CPTO 440

            If w_ispt > 0 Then
                b.qr("select g14_saldo from anom114" + _
                     " where g14_cpto = 440" + _
                     " and g14_tponom=" + a.rs!i1b_tponom.ToString + _
                     " and g14_numtra=" + a.rs!i1b_numtra.ToString, 1)
                If b.rs.HasRows Then
                    b.rs.Read()
                    If b.rs!g14_saldo > 0 Then
                        If w_ispt > b.rs!g14_saldo Then
                            devispt = b.rs!g14_saldo
                        Else
                            devispt = w_ispt
                        End If
                        inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 440, Math.Round(devispt * -1, 2), 1, 0)
                    Else
                        devispt = 0
                    End If
                End If
            End If


            '##### CALCULO DE CREDITO AL SALARIO CPTO 411

            Dim w_credsal = 0.0
            b.qr("select * from anom110 with(nolock)" +
                " where g10_cveing = 8" +
                " and g10_tipo='S'" +
                " and g10_inferior <= " + a.rs!i1b_ispt.ToString +
                " and g10_superior >= " + a.rs!i1b_ispt.ToString, 1)
            b.rs.Read()
            w_credsal = b.rs!g0_cuota
            w_credsal = w_credsal * -1
            If w_credsal < 0 Then
                inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 411, Math.Round(w_credsal, 2), 1, 0)
            End If

            '##### CALCULO DEL IMSS CPTO 406
            If receso = 0 Then
                Dim w_imss As Double = 0.0
                b.qr("select round((g5_sasegi*(select i4_fac_imss_event from anom304))*" +
                    " (select g19_factor from anom304,anom119" +
                    " where g19_ciclo = i4_ciclo" +
                    " and g19_cveing=8" +
                    " and g19_festivo=i4_numfes" +
                    " and g19_dias=" +
                        " (" +
                        " select case when count(*)>7 then 7 else count(*) end from anom301" +
                        " where i1_numtra=" + a.rs!i1b_numtra.ToString +
                        " and i1_tpo_emision<8" +
                        " and i1_cpto in (3,28,4,21)" +
                        " and i1_tponom=" + a.rs!i1b_tponom.ToString +
                        " )" +
                    "),2) imss from anom105 where g5_cveing=8 and g5_numtra=" + a.rs!i1b_numtra.ToString + " and g5_tponom=" + a.rs!i1b_tponom.ToString, 1)
                b.rs.Read()
                Try
                    w_imss = b.rs!imss
                Catch ex As Exception
                    MsgBox("Error en IMSS: " + a.rs!i1b_numtra.ToString)
                End Try
                b.qr("select g5_sasegi,round(g19_factor*round((g5_sasegi-(" + wsalmin.ToString + "*3))*.004,2),2) excede from anom304,anom119,anom105" +
                     " where g19_ciclo = i4_ciclo" +
                     " and g19_cveing=8" +
                     " and g19_festivo=i4_numfes" +
                     " and g19_dias=" +
                         "(" +
                         " select case when count(*)>7 then 7 else count(*) end from anom301" +
                         " where i1_numtra=" + a.rs!i1b_numtra.ToString +
                         " and i1_tpo_emision<8" +
                         " and i1_cpto in (3,28,4,21)" +
                         " and i1_tponom=" + a.rs!i1b_tponom.ToString +
                         ")" +
                    " and g5_numtra=" + a.rs!i1b_numtra.ToString +
                    " and g5_tponom=" + a.rs!i1b_tponom.ToString, 1)
                b.rs.Read()
                If b.rs!g5_sasegi > (wsalmin * 3) Then
                    If Not IsDBNull(b.rs!excede) Then
                        w_imss = w_imss + b.rs!excede
                    End If
                End If
                If w_imss > 0 Then
                    inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 406, Math.Round(w_imss, 2), 1, 0)
                Else
                    Try
                        b.qr("select round(sum(i1_importe*i4_fac_imss_event),2) imss,g5_sasegi " +
                         " from anom301,anom304,anom105" +
                         " where i1_numtra=" + a.rs!i1b_numtra.ToString +
                         " and i1_tponom=" + a.rs!i1b_tponom.ToString +
                         " and i1_cpto<100" +
                         " and i1_tpo_emision<8" +
                         " and i1_tponom=g5_tponom" +
                         " and i1_numtra=g5_numtra" +
                         " group by g5_sasegi", 1)
                        b.rs.Read()
                        w_imss = b.rs!imss
                    Catch ex As Exception
                        MsgBox("Error imss: " + a.rs!i1b_numtra.ToString)
                    End Try
                    If w_imss > 0 And b.rs!g5_sasegi = 0 Then
                        inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 406, Math.Round(w_imss, 2), 1, 0)
                    End If
                End If
            End If

            '##### CALCULO DE FONDO DE AHORRO OBRERO CPTO 498, EMPLEADO CPTO 557

            Dim w_fondo As Double = 0
            Dim w_sueldia As Double = 0
            Dim w_suelnor As Double = 0
            Dim w_festivo = 0
            Dim w_dias = 0
            Dim w_ciclo = ""
            Dim w_sabafes = 0
            Dim w_minimo As Double = 0
            Dim w_suelfin As Double = 0
            b.qr("select i4_numfes,i4_ciclo,round(i4_minimo*10*7*.13,2) min from anom304 with(nolock)", 1)
            b.rs.Read()
            w_festivo = b.rs!i4_numfes
            w_ciclo = b.rs!i4_ciclo
            w_minimo = b.rs!min
            b.qr("select count(*) saba_fes from anom202 with(nolock),anom304 with(nolock)" + _
                " where h2_fecha between i4_inisem and i4_finsem" + _
                " and h2_festivo='S' and h2_dia=6", 1)
            b.rs.Read()
            w_sabafes = b.rs!saba_fes
            b.qr("select sum(i1_importe) suel,count(*) dias from anom301 with(nolock) where i1_tpo_emision<8 " + _
                 " and i1_tponom=" + a.rs!i1b_tponom.ToString + _
                 " and i1_numtra=" + a.rs!i1b_numtra.ToString + _
                 " and i1_cpto in (3)", 1)
            b.rs.Read()
            If b.rs!dias > 0 Then
                w_sueldia = b.rs!suel / b.rs!dias
                w_suelnor = b.rs!suel + w_sueldia * w_festivo
                w_dias = b.rs!dias + w_festivo + (w_sabafes * -1)
                w_sueldia = w_suelnor / w_dias
                w_suelnor = 0
                If w_ciclo = "R" Then
                    Select Case w_dias
                        Case 1
                            w_suelnor = w_sueldia * 0.2
                        Case 2
                            w_suelnor = w_sueldia * 0.2
                        Case 3
                            w_suelnor = w_sueldia * 0.25
                        Case 4
                            w_suelnor = w_sueldia * 0.25
                        Case 5
                            w_suelnor = w_sueldia * 0.2
                        Case 6
                            w_suelnor = w_sueldia * 0.2
                        Case 7
                            w_suelnor = w_sueldia * 0.2
                    End Select
                    w_suelnor = w_suelnor * w_dias
                    w_suelfin = 0
                    If w_sabafes = 0 Then
                        w_suelfin = w_suelfin + w_suelnor
                    End If
                    w_suelfin = w_suelfin + w_suelnor
                Else
                    Select Case w_dias
                        Case 1
                            w_suelnor = w_sueldia * 0.166666
                        Case 2
                            w_suelnor = w_sueldia * 0.166666
                        Case 3
                            w_suelnor = w_sueldia * 0.166666
                        Case 4
                            w_suelnor = w_sueldia * 0.1875
                        Case 5
                            w_suelnor = w_sueldia * 0.2
                        Case 6
                            w_suelnor = w_sueldia * 0.166666
                        Case 7
                            w_suelnor = w_sueldia * 0.166666
                    End Select
                    w_suelnor = w_suelnor * w_dias
                    w_suelfin = w_suelnor
                End If
                Dim w_imp1 As Double = 0
                w_imp1 = b.rs!suel
                If w_festivo > 0 Then
                    w_imp1 = b.rs!suel + (w_suelnor * w_festivo)
                End If
                w_imp1 = w_imp1 + w_suelfin
                b.qr("select g5_plaza,i4_inisem from anom105 with(nolock),anom304 with(nolock) where g5_cveing=8 and g5_tponom=" + a.rs!i1b_tponom.ToString + " and g5_numtra=" + a.rs!i1b_numtra.ToString, 1)
                b.rs.Read()
                If a.rs!i1b_tponom = 1 Then
                    If receso = 0 Then
                        If w_ciclo = "Z" Then
                            If b.rs!g5_plaza = 1 Or b.rs!g5_plaza = 2 Then
                                If Math.Round((w_imp1) * 0.0685, 2) > w_minimo Then
                                    inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, b.rs!i4_inisem, 498, w_minimo, 1, 0)
                                Else
                                    inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, b.rs!i4_inisem, 498, Math.Round((w_imp1) * 0.0685, 2), 1, 0)
                                End If
                            End If
                        Else
                            If b.rs!g5_plaza = 1 Then
                                If Math.Round((w_imp1) * 0.0685, 2) > w_minimo Then
                                    inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, b.rs!i4_inisem, 498, w_minimo, 1, 0)
                                Else
                                    inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, b.rs!i4_inisem, 498, Math.Round((w_imp1) * 0.0685, 2), 1, 0)
                                End If
                            End If
                        End If
                    End If
                Else
                    If b.rs!g5_plaza = 1 Or b.rs!g5_plaza = 2 Then
                        If Math.Round((w_imp1) * 0.072, 2) > w_minimo Then
                            inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, b.rs!i4_inisem, 557, w_minimo, 1, 0)
                        Else
                            inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, b.rs!i4_inisem, 557, Math.Round((w_imp1) * 0.072, 2), 1, 0)
                        End If
                    End If
                End If
            Else
            End If

            '##### CUOTA SINDICAL INDEPENDIENTE CPTO 457

            b.qr("select min(g5_sindic) sindic,COUNT(*) num,rtrim(ltrim(max(g5_identi))) identi from anom301 with(nolock),anom105 with(nolock) where i1_tponom=" + a.rs!i1b_tponom.ToString + _
                 " and i1_numtra=" + a.rs!i1b_numtra.ToString + _
                 " and i1_cpto in (3) " + _
                 " and i1_tpo_emision<8" + _
                 " and g5_cveing=8" + _
                 " and g5_tponom=i1_tponom " + _
                 " and g5_numtra=i1_numtra", 1)
            b.rs.Read()
            If b.rs!num > 1 Then
                If b.rs!sindic = 1 And b.rs!identi <> "2" Then
                    b.qr("select COUNT(*) num from anom301 with(nolock) where i1_tpo_emision<8 and i1_cpto=3 and i1_tponom=" + a.rs!i1b_tponom.ToString + " and i1_numtra=" + a.rs!i1b_numtra.ToString, 1)
                    b.rs.Read()
                    If b.rs!num > 0 Then
                        b.qr("select sum(i1_importe) w_imp7 from anom301 with(nolock) where i1_tpo_emision<8 " + _
                             "and i1_numtra=" + a.rs!i1b_numtra.ToString + _
                             " and i1_tponom=" + a.rs!i1b_tponom.ToString + _
                             " and i1_cpto in (3,5,6,28)", 1)
                        b.rs.Read()
                        inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 457, Math.Round(b.rs!w_imp7 * 0.03, 2), 0, 0)
                    End If
                End If
            End If

            '##### PENSION ALIMENTICIA CPTO 415

            Dim w_importe As Double = 0
            b.qr("select sum(case when i1_cpto<400 then i1_importe else i1_importe*-1 end) importe from anom301 with(nolock) where (i1_cpto<100 or i1_cpto in (" + cpto_pension + ")) " +
                 " and i1_tponom=" + a.rs!i1b_tponom.ToString + _
                 " and i1_tpo_emision<8" + _
                 " and i1_numtra=" + a.rs!i1b_numtra.ToString, 1)
            b.rs.Read()
            If IsDBNull(b.rs!importe) Then
                w_importe = 0
            Else
                w_importe = b.rs!importe
            End If
            b.qr("select g6_porc,g6_indica,g6_conse from anom106 with(nolock) " +
                    " where g6_cveing=8 " +
                    " and g6_tponom=" + a.rs!i1b_tponom.ToString +
                    " and g6_numtra = " + a.rs!i1b_numtra.ToString +
                    " order by g6_conse", 1)
            While b.rs.Read
                If b.rs!g6_indica = 1 Then
                    inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 415, Math.Round(w_importe * b.rs!g6_porc / 100, 2), 0, b.rs!g6_conse)
                    w_importe = w_importe - Math.Round(w_importe * b.rs!g6_porc / 100, 2)
                Else
                    If w_importe > b.rs!g6_porc Then
                        inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 415, Math.Round(b.rs!g6_porc, 2), 0, b.rs!g6_conse)
                        w_importe = w_importe - b.rs!g6_porc
                    End If
                End If
            End While
            w_importe = Nothing

            '##### CLUBES DE TRENES CPTO 497 Y MOLINOS CPTO 494

            Dim w_trenes = 0
            Dim w_molinos = 0
            b.qr("select g5_trenes,g5_molino from anom105 with(nolock)" + _
                 " where g5_cveing=8 " + _
                 " and g5_tponom=" + a.rs!i1b_tponom.ToString + _
                 " and g5_numtra=" + a.rs!i1b_numtra.ToString, 1)
            b.rs.Read()
            w_trenes = b.rs!g5_trenes
            w_molinos = b.rs!g5_molino
            w_importe = 0
            b.qr("select sum(case when i1_cpto<400 then i1_importe else i1_importe*-1 end) importe from anom301 with(nolock)" + _
                " where i1_tpo_emision<8 " + _
                " and i1_tponom= " + a.rs!i1b_tponom.ToString + _
                " and i1_numtra=" + a.rs!i1b_numtra.ToString + _
                " and (i1_cpto<100 and i1_cpto not in (" + cpto_clubes + "))", 1)
            b.rs.Read()
            If IsDBNull(b.rs!importe) Then
                w_importe = 0
            Else
                w_importe = b.rs!importe
            End If

            If w_trenes > 0 Then
                inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 497, Math.Round(w_importe * w_trenes / 100, 2), 0, 0)
            End If
            If w_molinos > 0 Then
                inserta_301x(a.rs!i1b_tponom, a.rs!i1b_numtra, 0, wfecha, 494, Math.Round(w_importe * w_molinos / 100, 2), 0, 0)
            End If
        End While
    End Sub
    Sub f_nom307()

        '##### DESCUENTO DE ANOM114

        Dim w_numtra = 0
        Dim w_neto As Double = 0
        Dim w_descto As Double = 0
        Dim wfecha As Date
        a.qr("select * from anom304 with(nolock)", 1)
        a.rs.Read()
        wfecha = a.rs!i4_inisem
        a.qr("select i1_tponom,i1_numtra,sum(case when i1_cpto<400 then i1_importe else i1_importe*-1 end) imp " +
             " from anom301 with(nolock) where i1_tpo_emision<8 group by i1_tponom,i1_numtra order by 1,2", 1)
        While a.rs.Read
            b.qr("select * from anom114 with(nolock) left join anom213 on (g14_tponom=h13_tponom And g14_numtra=h13_numtra)" +
                " where g14_cveing=8 " +
                " And g14_tponom= " + a.rs!i1_tponom.ToString +
                " And g14_numtra = " + a.rs!i1_numtra.ToString +
                " and g14_cpto<>440 " +
                " And g14_perded=2 " +
                " order by g14_cpto", 1)
            While b.rs.Read
                If b.rs!g14_compara = 0 Then
                    If b.rs!g14_saldo > 0 And b.rs!g14_saldo >= b.rs!g14_cuota Then
                        w_descto = b.rs!g14_cuota
                    End If
                    If b.rs!g14_saldo > 0 And b.rs!g14_saldo < b.rs!g14_cuota Then
                        w_descto = b.rs!g14_saldo
                    End If
                Else
                    If b.rs!g14_cuota > 0 Then
                        w_descto = b.rs!g14_cuota
                    Else
                        If Not IsDBNull(b.rs!h13_porc) Then
                            w_descto = 0
                        End If
                    End If
                End If
                If w_descto > 0 Then
                    inserta_301x(a.rs!i1_tponom, a.rs!i1_numtra, 0, wfecha, b.rs!g14_cpto, Math.Round(w_descto, 2), 0, 0)
                End If
                w_descto = 0
            End While
        End While

        '##### MARCA CONCEPTOS QUE NO SE LLEGAN A DESCONTAR CON TIPO DE EMISION 9

        w_numtra = 1
        a.qr("select i1_tpo_emision,i1_tponom,i1_numtra,i1_cpto,i1_importe from anom301 with(nolock) where i1_tpo_emision<8 And i1_cpto Not in (119,498,199) order by i1_tponom,i1_numtra,i1_cpto", 1)
        While a.rs.Read
            If w_numtra <> a.rs!i1_numtra Then
                If a.rs!i1_cpto < 400 Then
                    w_neto = a.rs!i1_importe
                Else
                    w_neto = a.rs!i1_importe * -1
                End If
            Else
                If a.rs!i1_cpto > 399 Then
                    w_neto = w_neto - a.rs!i1_importe
                Else
                    w_neto = w_neto + a.rs!i1_importe
                End If
            End If
            If w_neto < 0 Then
                If a.rs!i1_cpto = 459 Or a.rs!i1_cpto = 471 Then
                    w_neto = w_neto + a.rs!i1_importe
                    b.qr("update anom301 set i1_importe=" + w_neto.ToString +
                         " where i1_tpo_emision=" + a.rs!i1_tpo_emision.ToString +
                         " And i1_tponom=" + a.rs!i1_tponom.ToString +
                         " And i1_numtra=" + a.rs!i1_numtra.ToString +
                         " And i1_cpto=" + a.rs!i1_cpto.ToString, 1)
                    w_neto = 0
                Else
                    w_neto = w_neto + a.rs!i1_importe
                    b.qr("update anom301 set i1_tpo_emision=9 " +
                         " where i1_tpo_emision=" + a.rs!i1_tpo_emision.ToString +
                         " And i1_tponom=" + a.rs!i1_tponom.ToString +
                         " And i1_numtra=" + a.rs!i1_numtra.ToString +
                         " And i1_cpto=" + a.rs!i1_cpto.ToString, 1)
                End If
            End If
            w_numtra = a.rs!i1_numtra
        End While
    End Sub
    '#################################################################################################################################################################################
    '###########################################################  COMIENZAN FUNCIONES DE INSERTAR  ###################################################################################
    '#################################################################################################################################################################################
    Sub inserta_301x(ByVal tponom As SByte, ByVal numtra As Short, ByVal depto As Short, ByVal fecha As String, ByVal cpto As Short, ByVal importe As Double, ByVal horas As Double, ByVal catego As Short)
        c.qr("inserta_301 " +
            tponom.ToString + "," +
            numtra.ToString + "," +
            depto.ToString + "," +
            "'" + fecha + "'," +
            cpto.ToString + "," +
            Math.Round(importe, 2).ToString + "," +
            horas.ToString + "," +
            catego.ToString, 2)
    End Sub
    Sub inserta_301b(ByVal tponom As SByte, ByVal numtra As Short, ByVal fecha As Date, ByVal cpto As Short, ByVal importe As Double, ByVal horas As Double, ByVal cptonuevo As Short)
        Dim d As SqlDataReader
        Dim w_tpo_emision = 1
        Dim w_catego = ""
        If cptonuevo = 21 Then
            c.qr("select top 1 * from anom301 with(nolock) where i1_numtra=" + numtra.ToString + " and i1_tponom=" + tponom.ToString + " and i1_cpto<400 and i1_cpto=21 order by i1_catego desc", 1)
        Else
            c.qr("select top 1 * from anom301 with(nolock) where i1_tponom=" + tponom.ToString + _
                 " and i1_numtra=" + numtra.ToString, 1)
        End If
        c.rs.Read()
        d = c.rs
        If cpto = 9 Or cpto = 15 Or cpto = 16 Or cpto = 10 Or cpto = 17 Or cpto = 21 Or cpto = 22 Or cpto = 27 Or cpto = 29 Then
            w_tpo_emision = 7
        End If
        If cpto = 498 Then
            w_tpo_emision = 9
        End If
        c.qr("insert into anom301 values(" + _
            "8," + _
            w_tpo_emision.ToString + "," + _
            d!i1_tponom.ToString + "," + _
            d!i1_depto.ToString + "," + _
            d!i1_numtra.ToString + "," + _
            "0," + _
            "'" + d!i1_tpocon + "'," + _
            cptonuevo.ToString + "," + _
            horas.ToString + "," + _
            importe.ToString + "," + _
            "''," + _
            d!i1_turno.ToString + "," + _
            d!i1_aplic.ToString + "," + _
            d!i1_catego.ToString + "," + _
            "'" + Mid(d!i1_fecha.ToString, 1, 10) + "'," + _
            "0," + _
            "0," + _
            "0," + _
            "0," + _
            d!i1_tpotra.ToString + "," + _
            d!i1_sot.ToString + "," + _
            "0," + _
            "0," + _
            "0," + _
            "0," + _
            "0)", 2)
        d = Nothing
    End Sub

End Class
