Public Class deducciones
    Public a As New Clase
    Function cpto_403(ByVal importe As Decimal, ByVal activa As Boolean, ByVal numtra As Integer, ByVal tpnom As Integer)
        Dim ingresos As Decimal
        Dim resul As Decimal
        Dim dias As Integer
        Dim c As New Clase
        c.qr("select * from anom304", 1)
        c.rs.Read()
        If activa Then
            a.qr("select count(*) w_dias_t from anom301 " + _
                " where i1_numtra = 775" + _
                " and i1_tponom=2" + _
                " and i1_cpto in (3)" + _
                " and i1_tpo_emision<8", 1)
            a.rs.Read()
            dias = a.rs!w_dias_t
            ingresos = (importe / dias) * 30.4
            a.qr("select * from anom108 where g8_inferior<=" + ingresos.ToString + " and g8_superior>=" + ingresos.ToString, 1)
            a.rs.Read()
            resul = Math.Round(ingresos - a.rs!g8_inferior, 2)
            resul = Math.Round(resul * a.rs!g8_porc / 100, 2)
            resul = a.rs!g8_cuota + resul
            resul = Math.Round(resul / 30.4 * dias, 2)
            cpto_403 = resul
        Else
            cpto_403 = 0
        End If
    End Function
End Class
