Imports Spire.Xls
Imports System.IO
Public Class maestros
    Public a As New Clase
    Private Sub bot_fis_guarda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_fis_guarda.Click
        Dim wclave = 0
        If Len(txt_paterno.Text) = 0 Then
            MsgBox("Falta apellido paterno")
            Exit Sub
        End If
        If Len(txt_materno.Text) = 0 Then
            MsgBox("Falta apellido materno")
            Exit Sub
        End If
        If Len(txt_nombre.Text) = 0 Then
            MsgBox("Falta nombre")
            Exit Sub
        End If
        If Len(txt_rfc.Text) = 0 Or Len(txt_rfc.Text) <> 13 Then
            MsgBox("Rfc incompleto")
            Exit Sub
        End If
        If cmb_sexo.SelectedIndex = -1 Then
            MsgBox("Seleccionar sexo")
            Exit Sub
        End If
        If Len(txt_curp.Text) <> 18 Or Len(txt_curp.Text) = 0 Then
            MsgBox("Curp incompleto")
            Exit Sub
        End If
        If cmb_edocivil.SelectedIndex = -1 Then
            cmb_edocivil.SelectedIndex = 0
        End If
        'ACTUALIZACION DE PERSONA FISICA
        If Len(txt_fisica.Text) > 0 Then
            a.qr("update aing102 set " +
                 "i2_paterno='" + txt_paterno.Text + "'," +
                 "i2_materno='" + txt_materno.Text + "'," +
                 "i2_nombre='" + txt_nombre.Text + "'," +
                 "i2_rfc='" + txt_rfc.Text + "'," +
                 "i2_curp='" + txt_curp.Text + "'," +
                 "i2_imss='" + txt_imss.Text + "'," +
                 "i2_nacimiento='" + mtb_fec_nac.Text + "'," +
                 "i2_edocivil=" + Mid(cmb_edocivil.Text, 1, 1) + "," +
                 "i2_ultmovimiento=getdate()," +
                 "i2_sexo=" + Mid(cmb_sexo.Text, 1, 1) +
                 " where i2_fisica=" + txt_fisica.Text, 2)
            a.qr("exec actnombres", 2)
            MsgBox("Actualizacion realizada")
        Else

            'AGREGAR NUEVA PERSONA FISICA

            a.qr("select * from aing102 where substring(i2_rfc,1,10)='" + Mid(txt_rfc.Text, 1, 10) + "'", 1)
            If a.rs.HasRows Then
                a.rs.Read()
                MsgBox("Existe una persona con ese RFC: " + a.rs!i2_fisica.ToString)
                Exit Sub
                bot_fis_buscar.PerformClick()
            End If
            a.qr("select max(i2_fisica) num from aing102", 1)
            a.rs.Read()
            wclave = a.rs!num + 1
            a.qr("insert into aing102 values (2," + wclave.ToString +
                 ",'" + txt_paterno.Text +
                 "','" + txt_materno.Text +
                 "','" + txt_nombre.Text +
                 "','" + txt_rfc.Text +
                 "','" + txt_curp.Text +
                 "','" + txt_imss.Text +
                 "','" + mtb_fec_nac.Text + "'," + Mid(cmb_edocivil.Text, 1, 1) +
                 ",getdate()," + Mid(cmb_sexo.Text, 1, 1) + ",'','')", 2)
            MsgBox("Proceso realizado, Clave nueva:" + wclave.ToString)
        End If
        borrai102()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub bot_fis_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_fis_buscar.Click
        dgv_fisicas.Rows.Clear()
        Dim query = "select i2_fisica,i2_paterno,i2_materno,i2_nombre,i2_rfc from aing102 where i2_tipopersona = 2"
        If Len(txt_paterno.Text) > 0 Then
            query = query + " and i2_paterno like '" + txt_paterno.Text + "%'"
        End If
        If Len(txt_materno.Text) > 0 Then
            query = query + " and i2_materno like '" + txt_materno.Text + "%'"
        End If
        If Len(txt_nombre.Text) > 0 Then
            query = query + " and i2_nombre like '" + txt_nombre.Text + "%'"
        End If
        If Len(txt_rfc.Text) > 0 Then
            query = query + " and i2_rfc like '" + txt_rfc.Text + "%'"
        End If
        query = query + "order by 2,3,4"
        a.qr(query, 1)
        While a.rs.Read
            dgv_fisicas.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4))
        End While
    End Sub

    Private Sub bot_pen_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_pen_buscar.Click
        Dim query = "select g6_tponom,g6_numtra,nombre,g6_conse,g6_clave,v_nombreprop from anom106,nombres,vacre102" +
                    " where g6_tponom = tponom" +
                    " and g6_numtra=numtra" +
                    " and v_relab=11" +
                    " and g6_clave=v_fisica"
        If Len(cmb_pen_tponom.Text) > 0 Then
            query = query + " and g6_tponom=" + Mid(cmb_pen_tponom.Text, 1, 1)
        End If
        If Len(mtb_pen_numtra.Text) > 0 Then
            query += " and g6_numtra=" + mtb_pen_numtra.Text
        End If
        If Len(mtb_bene.Text) > 0 Then
            query += " and g6_clave=" + mtb_bene.Text
        End If
        query = query + " order by 1,2,4"
        dgv_pensiones.Rows.Clear()
        a.qr(query, 1)
        While a.rs.Read
            dgv_pensiones.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4), a.rs.Item(5))
        End While
    End Sub

    Private Sub bot_rel_bus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_rel_bus.Click
        Dim query = "select v_relab,v_clave,v_tipopersona,v_propietario,v_nombreprop,v_rfc_prop from vacre102 where v_relab in (3,4,11,14,15)"
        If Len(cmb_tipoper.Text) > 0 Then
            query = query + " and v_tipopersona=" + Mid(cmb_tipoper.Text, 1, 1)
        End If
        If Len(cmb_relacion.Text) > 0 Then
            query += " and v_relab=" + Mid(cmb_relacion.Text, 1, 2)
        End If
        If Len(mtb_rel_clave.Text) > 0 Then
            query += " and v_propietario=" + mtb_rel_clave.Text
        End If
        If Len(mtb_rel_numtra.Text) > 0 Then
            query += " and v_clave=" + mtb_rel_numtra.Text
        End If
        query = query + "order by 1,convert(int,v_clave),3,4"
        dgv_relaciones.Rows.Clear()
        a.qr(query, 1)
        While a.rs.Read
            dgv_relaciones.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4), a.rs.Item(5))
        End While
    End Sub

    Private Sub bot_rel_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_rel_guardar.Click
        If cmb_tipoper.SelectedIndex = -1 Then
            MsgBox("Selecciona tipo de persona")
            Exit Sub
        End If
        If Len(mtb_rel_clave.Text) = 0 Then
            MsgBox("Falta numero de persona fisica")
            Exit Sub
        End If
        If cmb_relacion.SelectedIndex = -1 Then
            MsgBox("Falta relacion con la empresa")
            Exit Sub
        End If
        If Len(mtb_rel_numtra.Text) = 0 Then
            MsgBox("Falta numero de trabajador")
            Exit Sub
        End If
        If Len(mtb_repre.Text) = 0 Then
            mtb_repre.Text = mtb_rel_clave.Text
        End If
        a.qr("select * from aing103 where i3_relab=" + Mid(cmb_relacion.Text, 1, 2) + " and i3_clave=" + mtb_rel_numtra.Text, 1)
        If a.rs.HasRows Then
            MsgBox("Ya existe una relacion con la empresa")
            Exit Sub
        End If
        a.qr("insert into aing103 values (" +
             Mid(cmb_relacion.Text, 1, 2) +
             "," + Mid(cmb_tipoper.Text, 1, 1) +
             "," + mtb_rel_clave.Text +
             "," + mtb_rel_numtra.Text +
             ",getdate()," + mtb_repre.Text + ")", 2)
        a.qr("actnombres", 2)
        MsgBox("proceso realizado")
        borrai103()
    End Sub

    Private Sub mtb_rel_clave_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtb_rel_clave.Leave
        If Val(mtb_rel_clave.Text) > 0 Then
            a.qr("select * from aing102 where i2_fisica=" + mtb_rel_clave.Text, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                txt_rel_nom.Text = a.rs!i2_paterno + " " + a.rs!i2_materno + " " + a.rs!i2_nombre
            End If
        End If
    End Sub

    Private Sub mtb_repre_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtb_repre.Leave
        If Val(mtb_repre.Text) > 0 Then
            a.qr("select * from aing102 where i2_fisica=" + mtb_repre.Text, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                txt_nom_repre.Text = a.rs!i2_paterno + " " + a.rs!i2_materno + " " + a.rs!i2_nombre
            Else
                MsgBox("clave de persona no existe", MsgBoxStyle.Exclamation)
                mtb_repre.SelectAll()
                mtb_repre.Focus()
            End If
        End If
    End Sub

    Private Sub mtb_pen_numtra_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtb_pen_numtra.Leave
        If Len(mtb_pen_numtra.Text) > 0 Then
            If Len(cmb_pen_tponom.Text) = 0 Then
                MsgBox("Seleccionar tipo de empleado")
                Exit Sub
            Else
                a.qr("select * from nombres where tponom=" + Mid(cmb_pen_tponom.Text, 1, 1) + " and numtra=" + mtb_pen_numtra.Text, 1)
                If a.rs.HasRows Then
                    a.rs.Read()
                    txt_pen_nom.Text = a.rs!nombre
                Else
                    MsgBox("No existe numero de trabajador")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub mtb_bene_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtb_bene.Leave
        If Len(mtb_bene.Text) > 0 Then
            a.qr("select * from aing102 where i2_fisica=" + mtb_bene.Text, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                txt_nom_bene.Text = a.rs!i2_paterno + " " + a.rs!i2_materno + " " + a.rs!i2_nombre
            Else
                MsgBox("Numero de persona fisica no existe")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub bot_pen_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_pen_guardar.Click
        If cmb_pen_tponom.SelectedIndex = -1 Then
            MsgBox("Seleccionar tipo de nomina")
            Exit Sub
        End If
        If Len(mtb_pen_numtra.Text) = 0 Then
            MsgBox("falta numero de trabajador pensionado")
            Exit Sub
        End If
        If Len(mtb_bene.Text) = 0 Then
            MsgBox("falta numero de beneficiario")
            Exit Sub
        End If
        a.qr("select * from anom106" +
            " where g6_tponom = " + Mid(cmb_pen_tponom.Text, 1, 1) +
            " and g6_numtra=" + mtb_pen_numtra.Text +
            " and g6_conse=" + cmb_conse.Text.ToString +
            " and g6_clave=" + mtb_bene.Text, 1)
        If a.rs.HasRows Then
            If cmb_pen_indica.SelectedIndex = -1 Then
                MsgBox("Seleccionar indicador porcentaje importe")
                Exit Sub
            End If
            If cmb_aplica.SelectedIndex = -1 Then
                MsgBox("Seleccionar aplica a premio")
                Exit Sub
            End If
            If Len(mtb_importe.Text) = 0 Then
                MsgBox("Falta porcentaje / importe")
                Exit Sub
            End If
            a.qr("update anom106 set g6_premio=" + Mid(cmb_aplica.Text, 1, 1) +
                   ",g6_indica=" + Mid(cmb_pen_indica.Text, 1, 1) +
                   ",g6_porc=" + mtb_importe.Text +
                   ",g6_captura=getdate()" +
                    " where g6_tponom = " + Mid(cmb_pen_tponom.Text, 1, 1) +
                    " and g6_numtra=" + mtb_pen_numtra.Text +
                    " and g6_clave=" + mtb_bene.Text +
                    " and g6_conse=" + cmb_conse.Text.ToString, 2)
            MsgBox("Registro actualizado")
        Else
            If cmb_conse.SelectedIndex = -1 Then
                MsgBox("Seleccionar consecutivo")
                Exit Sub
            End If
            If cmb_pen_indica.SelectedIndex = -1 Then
                MsgBox("Seleccionar indicador porcentaje importe")
                Exit Sub
            End If
            If cmb_aplica.SelectedIndex = -1 Then
                MsgBox("Seleccionar aplica a premio")
                Exit Sub
            End If
            If Len(mtb_importe.Text) = 0 Then
                MsgBox("Falta porcentaje / importe")
                Exit Sub
            End If
            a.qr("select * from anom106" +
                " where g6_tponom = " + Mid(cmb_pen_tponom.Text, 1, 1) +
                " and g6_numtra=" + mtb_pen_numtra.Text +
                " and g6_conse=" + Mid(cmb_conse.Text, 1, 1), 1)
            If a.rs.HasRows Then
                MsgBox("Consecutivo ya existe")
                Exit Sub
            End If
            a.qr("insert into anom106 values (8," +
                 Mid(cmb_pen_tponom.Text, 1, 1) + "," +
                 mtb_pen_numtra.Text + "," +
                 Mid(cmb_conse.Text, 1, 1) + "," +
                 Mid(cmb_aplica.Text, 1, 1) + "," +
                 Mid(cmb_pen_indica.Text, 1, 1) + "," +
                 mtb_importe.Text + ", " +
                 mtb_bene.Text + ",getdate(),0)", 2)
            MsgBox("Registro agregado")
        End If
        borra106()
    End Sub

    Private Sub bot_105_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_105_guardar.Click
        a.qr("select * from anom105 where g5_tponom = " + Mid(cmb_105_tponom.Text, 1, 1) + " and g5_numtra=" + mtb_105_numtra.Text, 1)
        If a.rs.HasRows Then
            a.qr("update anom105 set g5_catz=" + mtb_105_catzaf.Text +
                 ",g5_catr=" + mtb_105_catrep.Text +
                 ",g5_dptoz=" + mtb_105_depzaf.Text +
                 ",g5_dptor=" + mtb_105_deprep.Text +
                 ",g5_plaza=" + Mid(cmb_105_plaza.Text, 1, 1) +
                 ",g5_sindic=" + Mid(cmb_105_sindic.Text, 1, 1) +
                 ",g5_escala=" + mtb_105_escala.Text +
                 ",g5_ingreso='" + dtp_105_ingreso.Text + "'" +
                 ",g5_sasegi=" + txt_105_sdi.Text +
                 ",g5_permanente='" + dtp_105_perma.Text + "'" +
                 ",g5_temporal='" + dtp_105_tempo.Text + "'" +
                 ",g5_altaimss='" + dtp_105_alta.Text + "'" +
                 ",g5_bajaimss='" + dtp_105_baja.Text + "'" +
                 ",g5_jubilado='" + dtp_105_jubpen.Text + "'" +
                 " where g5_tponom = " + Mid(cmb_105_tponom.Text, 1, 1) +
                 " and g5_numtra=" + mtb_105_numtra.Text, 2)
            MsgBox("Proceso actualizado")
            borra105()
        Else
            If MsgBox("Trabajador no existe, crear numero?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                a.qr("alta_anom105 " + Mid(cmb_105_tponom.Text, 1, 1) + "," + mtb_105_numtra.Text, 2)
                a.qr("update anom105 set g5_molino=0 where g5_molino is null", 2)
                a.qr("update anom105 set g5_trenes=0 where g5_trenes is null", 2)
                MsgBox("Proceso realizado, actualizar sus datos")
                borra105()
            End If
        End If
        a.qr("update anom105 set g5_molino=0 where g5_molino is null", 2)
        a.qr("update anom105 set g5_trenes=0 where g5_trenes is null", 2)
    End Sub
    Function valida_105()
        Dim werror = 0
        a.qr("select * from anom102 where g2_catego=" + mtb_105_catzaf.Text, 1)
        If Not a.rs.HasRows Then
            werror = 1
            MsgBox("Categoria zafra no existe")
        End If
        a.qr("select * from anom102 where g2_catego=" + mtb_105_catrep.Text, 1)
        If Not a.rs.HasRows Then
            werror = 2
            MsgBox("Categoria reparacion no existe")
        End If
        a.qr("select * from anom103 where g3_cc=" + mtb_105_depzaf.Text, 1)
        If Not a.rs.HasRows Then
            werror = 3
            MsgBox("Departamento zafra no existe")
        End If
        a.qr("select * from anom103 where g3_cc=" + mtb_105_deprep.Text, 1)
        If Not a.rs.HasRows Then
            werror = 4
            MsgBox("Departamento reparacion no existe")
        End If
        Return werror
    End Function

    Private Sub bot_105_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_105_buscar.Click
        If Len(cmb_105_tponom.Text) = 0 Then
            MsgBox("Seleccione tipo de nomina")
            Exit Sub
        End If
        If Len(mtb_105_numtra.Text) = 0 Then
            MsgBox("Escribir numero de trabajador")
            Exit Sub
        End If
        a.qr("select * from anom105,nombres" +
            " where g5_tponom = " + Mid(cmb_105_tponom.Text, 1, 1) +
            " and g5_numtra=" + mtb_105_numtra.Text +
            " and g5_tponom=tponom" +
            " and g5_numtra=numtra", 1)
        If a.rs.HasRows Then
            a.rs.Read()
            mtb_105_catzaf.Text = a.rs!g5_catz.ToString
            mtb_105_catrep.Text = a.rs!g5_catr.ToString
            mtb_105_depzaf.Text = a.rs!g5_dptoz.ToString
            mtb_105_deprep.Text = a.rs!g5_dptor.ToString
            mtb_105_escala.Text = a.rs!g5_escala.ToString
            txt_105_nombre.Text = a.rs!nombre
            txt_105_sdi.Text = a.rs!g5_sasegi
            cmb_105_plaza.SelectedIndex = a.rs!g5_plaza - 1
            cmb_105_sindic.SelectedIndex = a.rs!g5_sindic - 1
            dtp_105_ingreso.Text = a.rs!g5_ingreso
            dtp_105_tempo.Text = a.rs!g5_temporal
            dtp_105_perma.Text = a.rs!g5_permanente
            dtp_105_alta.Text = a.rs!g5_altaimss
            dtp_105_baja.Text = a.rs!g5_bajaimss
            dtp_105_jubpen.Text = a.rs!g5_jubilado
        Else
            MsgBox("Trabajador no existe")
            Exit Sub
        End If
        a.qr("select v_fisica from vacre102 where v_relab=" + Mid(cmb_105_tponom.Text, 1, 1) + "+2 and v_clave=" + mtb_105_numtra.Text, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            txt_105_id.Text = a.rs!v_fisica.ToString
        End If
    End Sub

    Private Sub dgv_fisicas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_fisicas.CellDoubleClick
        Dim clave = 0
        clave = dgv_fisicas.Rows(dgv_fisicas.CurrentCellAddress.Y).Cells(0).Value
        a.qr("select * from aing102 where i2_fisica=" + clave.ToString, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            txt_fisica.Text = a.rs!i2_fisica
            txt_paterno.Text = a.rs!i2_paterno
            txt_materno.Text = a.rs!i2_materno
            txt_nombre.Text = a.rs!i2_nombre
            txt_curp.Text = a.rs!i2_curp
            txt_rfc.Text = a.rs!i2_rfc
            txt_imss.Text = a.rs!i2_imss
            mtb_fec_nac.Text = a.rs!i2_nacimiento.ToString
            cmb_edocivil.SelectedIndex = a.rs!i2_edocivil - 1
            cmb_sexo.SelectedIndex = a.rs!i2_sexo - 1
        Else
            MsgBox("No existe")
        End If
    End Sub
    Public Sub borra105()
        cmb_105_tponom.SelectedIndex = -1
        cmb_105_plaza.SelectedIndex = -1
        cmb_105_sindic.SelectedIndex = -1
        mtb_105_numtra.Text = ""
        txt_105_id.Text = ""
        mtb_105_escala.Text = ""
        txt_105_nombre.Text = ""
        mtb_105_catzaf.Text = ""
        mtb_105_catrep.Text = ""
        mtb_105_deprep.Text = ""
        mtb_105_depzaf.Text = ""
        txt_105_sdi.Text = "0.00"
        dtp_105_ingreso.Text = "01/01/1900"
        dtp_105_tempo.Text = "01/01/1900"
        dtp_105_perma.Text = "01/01/1900"
        dtp_105_alta.Text = "01/01/1900"
        dtp_105_baja.Text = "01/01/1900"
        dtp_105_jubpen.Text = "01/01/1900"
    End Sub
    Public Sub borra106()
        cmb_pen_tponom.SelectedIndex = -1
        mtb_pen_numtra.Text = ""
        mtb_bene.Text = ""
        cmb_conse.SelectedIndex = -1
        cmb_pen_indica.SelectedIndex = -1
        cmb_aplica.SelectedIndex = -1
        mtb_importe.Text = ""
        txt_pen_nom.Text = ""
        txt_nom_bene.Text = ""
        dgv_pensiones.Rows.Clear()
    End Sub
    Public Sub borrai102()
        txt_paterno.Text = ""
        txt_materno.Text = ""
        txt_nombre.Text = ""
        txt_fisica.Text = ""
        txt_rfc.Text = ""
        txt_imss.Text = ""
        txt_curp.Text = ""
        cmb_sexo.SelectedIndex = -1
        cmb_edocivil.SelectedIndex = -1
        mtb_fec_nac.Text = ""
        dgv_fisicas.Rows.Clear()
    End Sub
    Public Sub borrai103()
        cmb_tipoper.SelectedIndex = -1
        mtb_rel_clave.Text = ""
        txt_rel_nom.Text = ""
        cmb_relacion.SelectedIndex = -1
        mtb_rel_numtra.Text = ""
        mtb_repre.Text = ""
        txt_nom_repre.Text = ""
        dgv_relaciones.Rows.Clear()
    End Sub

    Private Sub bot_rel_elim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_rel_elim.Click
        If Len(mtb_rel_numtra.Text) = 0 Then
            MsgBox("Falta numero de trabajador")
            Exit Sub
        End If
        If cmb_relacion.SelectedIndex = -1 Then
            MsgBox("Seleccionar relacion con la empresa")
            Exit Sub
        End If
        If MsgBox("Borrar relacion con la empresa?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("select * from aing103 where i3_relab=" + Mid(cmb_relacion.Text, 1, 2) + " and i3_clave=" + mtb_rel_numtra.Text, 1)
            If a.rs.HasRows Then
                a.qr("delete from aing103 where i3_relab=" + Mid(cmb_relacion.Text, 1, 2) + " and i3_clave=" + mtb_rel_numtra.Text, 2)
                MsgBox("Relacion eliminada")
            End If
        End If
    End Sub
    Private Sub dgv_pensiones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_pensiones.CellDoubleClick
        Dim tponom = 0
        Dim numtra = 0
        Dim bene = 0
        tponom = dgv_pensiones.Rows(dgv_pensiones.CurrentCellAddress.Y).Cells(0).Value
        numtra = dgv_pensiones.Rows(dgv_pensiones.CurrentCellAddress.Y).Cells(1).Value
        bene = dgv_pensiones.Rows(dgv_pensiones.CurrentCellAddress.Y).Cells(4).Value
        a.qr("select * from anom106,vacre102,nombres" +
            " where g6_tponom = " + tponom.ToString +
            " and g6_numtra=" + numtra.ToString +
            " and g6_clave=" + bene.ToString +
            " and v_relab=11" +
            " and tponom=g6_tponom" +
            " and numtra=g6_numtra" +
            " and v_fisica=g6_clave", 1)
        a.rs.Read()
        cmb_pen_tponom.SelectedIndex = a.rs!g6_tponom - 1
        mtb_pen_numtra.Text = a.rs!g6_numtra
        txt_pen_nom.Text = a.rs!nombre
        cmb_conse.SelectedIndex = a.rs!g6_conse - 1
        cmb_pen_indica.SelectedIndex = a.rs!g6_indica - 1
        cmb_aplica.SelectedIndex = a.rs!g6_premio
        mtb_importe.Text = String.Format("{0,8}", a.rs!g6_porc)
        mtb_bene.Text = a.rs!g6_clave
        txt_nom_bene.Text = a.rs!v_nombreprop
    End Sub

    Private Sub bot_pen_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bot_pen_eliminar.Click
        If cmb_pen_tponom.SelectedIndex = -1 Then
            MsgBox("Seleccionar tipo de nomina")
            Exit Sub
        End If
        If Len(mtb_pen_numtra.Text) = 0 Then
            MsgBox("falta numero de trabajador pensionado")
            Exit Sub
        End If
        If Len(mtb_bene.Text) = 0 Then
            MsgBox("falta numero de beneficiario")
            Exit Sub
        End If
        a.qr("select * from anom106" +
            " where g6_tponom = " + Mid(cmb_pen_tponom.Text, 1, 1) +
            " and g6_numtra=" + mtb_pen_numtra.Text +
            " and g6_clave=" + mtb_bene.Text, 1)
        If a.rs.HasRows Then
            a.qr("select v_nombreprop,g6_porc from anom106,vacre102" +
                " where g6_tponom = " + Mid(cmb_pen_tponom.Text, 1, 1) +
                " and g6_numtra=" + mtb_pen_numtra.Text +
                " and g6_clave=" + mtb_bene.Text +
                " and g6_clave=v_fisica" +
                " and v_relab=11", 1)
            a.rs.Read()
            If MsgBox("Eliminar pension: " + a.rs!v_nombreprop.ToString + ", " + a.rs!g6_porc.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MsgBox("delete from anom106" +
                " where g6_tponom = " + Mid(cmb_pen_tponom.Text, 1, 1) +
                " and g6_numtra=" + mtb_pen_numtra.Text +
                " and g6_clave=" + mtb_bene.Text, 2)
                MsgBox("Borrado con exito")
                borra106()
            End If
        Else
            MsgBox("No existe pension, revisar")
        End If
    End Sub

    Private Sub Nom105ListadoTrabajadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom105ListadoTrabajadoresToolStripMenuItem.Click
        Dim file As System.IO.FileStream
        Dim fic As String = "c:\temp\anom205.csv"
        Dim sw As System.IO.StreamWriter

        file = System.IO.File.Create(fic)
        file.Close()

        sw = New System.IO.StreamWriter(fic)
        sw.WriteLine("TPONOM,NUMTRA,NOMBRE,CURP,RFC,NSS,PLAZA,REGIMEN,GRUIMSS,CLINICA,INGRESO,TEMPORAL,PERMANENTE,DPTOZ,DPTOR,CATZ,CATR,ESCALAFON")
        a.qr("REP_ANOM105 1", 1)
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
                         Mid(a.rs.Item(10).ToString, 1, 10) + "," +
                         Mid(a.rs.Item(11).ToString, 1, 10) + "," +
                         Mid(a.rs.Item(12).ToString, 1, 10) + "," +
                         a.rs.Item(13).ToString + "," +
                         a.rs.Item(14).ToString + "," +
                         a.rs.Item(15).ToString + "," +
                         a.rs.Item(16).ToString + "," +
                         a.rs.Item(17).ToString + ","
                         )
        End While
        sw.Close()
        MsgBox("Proceso terminado, reporte generado en " + fic)
    End Sub

    Private Sub txt_105_sdi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_105_sdi.Leave
        If Not IsNumeric(txt_105_sdi.Text) Then
            MsgBox("Valor SDI no valido")
            txt_105_sdi.Text = "0.00"
        End If
    End Sub

    Private Sub mtb_105_numtra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtb_105_numtra.KeyPress
        If e.KeyChar = Chr(13) Then
            bot_105_buscar.PerformClick()
        End If
    End Sub

    Private Sub bot_jub_buscar_Click(sender As Object, e As EventArgs) Handles bot_jub_buscar.Click
        dgv_jubilados.Rows.Clear()
        Dim importe = ""
        Dim query = ""
        If Len(cmb_jub_tipo.Text) > 0 Then
            If Mid(cmb_jub_tipo.Text, 1, 1) = "Q" Then
                query = query + "and g11_tipo=1"
                a.qr("select convert(varchar, convert(money, sum(g11_importe)), 1) importe from anom111 where g11_tipo=1", 1)
                a.rs.Read()
                importe = a.rs!importe
            End If
            If Mid(cmb_jub_tipo.Text, 1, 1) = "M" Then
                query = query + "and g11_tipo=2"
                a.qr("select convert(varchar, convert(money, sum(g11_importe)), 1) importe from anom111 where g11_tipo=2", 1)
                a.rs.Read()
                importe = a.rs!importe
            End If
        Else
            a.qr("select convert(varchar, convert(money, sum(g11_importe)), 1) importe from anom111 where g11_tipo>0", 1)
            a.rs.Read()
            importe = a.rs!importe
        End If
        If Len(txt_jub_numtra.Text) > 0 Then
            query = query + " and g11_numtra=" + txt_jub_numtra.Text
        End If
        If Len(txt_jub_nombre.Text) > 0 Then
            query = query + " and nombre like '%" + txt_jub_nombre.Text + "%'"
        End If
        a.qr("select g11_numtra,nombre,sum(g11_importe),sum(case when g11_tipo=1 then 1 else 0 end),sum(case when g11_tipo=2 then 1 else 0 end) " +
             "from anom111,nombres " +
             "where tponom=3 " + query +
             "and g11_numtra=numtra " +
             "group by g11_numtra,nombre " +
             "order by 1", 1)
        If a.rs.HasRows Then
            While a.rs.Read
                dgv_jubilados.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4))
            End While
        End If
        txt_jub_total.Text = importe
    End Sub

    Private Sub bot_bec_buscar_Click(sender As Object, e As EventArgs) Handles bot_bec_buscar.Click
        dgv_becarios.Rows.Clear()
        Dim importe = ""
        Dim query = ""
        If Len(txt_bec_numtra.Text) > 0 Then
            query = query + " and g13_numtra=" + txt_bec_numtra.Text
        End If
        If Len(txt_bec_nombre.Text) > 0 Then
            query = query + " and nombre like '%" + txt_bec_nombre.Text + "%'"
        End If
        a.qr("select g13_numtra,nombre,g13_importe,g13_dias,g13_sdi from anom113,nombres " +
             " where tponom=4 and numtra=g13_numtra" + query, 1)
        If a.rs.HasRows Then
            While a.rs.Read
                dgv_becarios.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4))
            End While
        End If
        a.qr("select sum(g13_importe) importe from anom113 ", 1)
        a.rs.Read()
        txt_bec_total.Text = FormatNumber(a.rs!importe)
    End Sub

    Private Sub bot_jub_eliminar_Click(sender As Object, e As EventArgs) Handles bot_jub_eliminar.Click
        Dim numtra = 0
        numtra = dgv_jubilados.Rows(dgv_jubilados.CurrentCellAddress.Y).Cells(0).Value
        If MsgBox("Eliminar jubilado: " + numtra.ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("delete from anom111 where g11_numtra=" + numtra.ToString, 2)
            dgv_jubilados.Rows.Clear()
            bot_jub_buscar.PerformClick()
        End If
    End Sub
    Private Sub dgv_jubilados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_jubilados.CellDoubleClick
        Dim numtra = 0
        numtra = dgv_jubilados.Rows(dgv_jubilados.CurrentCellAddress.Y).Cells(0).Value
        a.qr("select g11_numtra,nombre,g11_importe,g11_tipo from anom111,nombres" +
            " where tponom=3" +
            " and g11_numtra=numtra" +
            " and g11_numtra=" + numtra.ToString, 1)
        If a.rs.HasRows Then
            a.rs.Read()
            txt_jub_numtra.Text = a.rs!g11_numtra
            txt_jub_nombre.Text = a.rs!nombre
            txt_jub_importe.Text = a.rs!g11_importe
            If a.rs!g11_tipo = 1 Then
                cmb_jub_tipo.SelectedIndex = 0
            End If
            If a.rs!g11_tipo = 2 Then
                cmb_jub_tipo.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub bot_jub_guardar_Click(sender As Object, e As EventArgs) Handles bot_jub_guardar.Click
        If IsNumeric(txt_jub_numtra.Text) Then
            a.qr("select * from anom111 where g11_numtra=" + txt_jub_numtra.Text.ToString, 1)
            If a.rs.HasRows Then
                If Len(cmb_jub_tipo.Text) = 0 Then
                    MsgBox("Seleccionar tipo")
                    Exit Sub
                End If
                If Val(txt_jub_importe.Text) > 0 Then
                    If MsgBox("Actualizar registro", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If Mid(cmb_jub_tipo.Text, 1, 1) = "Q" Then
                            a.qr("update anom111 set g11_fecha=getdate(),g11_tipo=1,g11_importe=" + txt_jub_importe.Text.ToString + " where g11_numtra=" + txt_jub_numtra.Text.ToString, 2)
                        Else
                            a.qr("update anom111 set g11_fecha=getdate(),g11_tipo=2,g11_importe=" + txt_jub_importe.Text.ToString + " where g11_numtra=" + txt_jub_numtra.Text.ToString, 2)
                        End If
                    End If
                Else
                    MsgBox("Importe erroneo")
                    Exit Sub
                End If
            Else
                If Len(cmb_jub_tipo.Text) = 0 Then
                    MsgBox("Seleccionar tipo")
                    Exit Sub
                End If
                If Not IsNumeric(txt_jub_importe.Text) Then
                    MsgBox("Importe incorrecto")
                    Exit Sub
                End If
                a.qr("select * from vacre102 where v_relab=14 and v_clave=" + txt_jub_numtra.Text.ToString, 1)
                If a.rs.HasRows Then
                    If Mid(cmb_jub_tipo.Text, 1, 1) = "Q" Then
                        a.qr("insert into anom111 values (" + txt_jub_numtra.Text.ToString + "," + txt_jub_importe.Text.ToString + ",1,getdate())", 2)
                    Else
                        a.qr("insert into anom111 values (" + txt_jub_numtra.Text.ToString + "," + txt_jub_importe.Text.ToString + ",2,getdate())", 2)
                    End If
                Else
                    MsgBox("Numero de trabajador no cuenta con relacion con la empresa como jubilado")
                    Exit Sub
                End If
            End If
            dgv_jubilados.Rows.Clear()
            bot_jub_buscar.PerformClick()
            txt_jub_importe.Text = ""
            txt_jub_numtra.Text = ""
            txt_jub_nombre.Text = ""
            cmb_jub_tipo.SelectedIndex = -1
        End If
    End Sub

    Private Sub bot_bec_guardar_Click(sender As Object, e As EventArgs) Handles bot_bec_guardar.Click
        Dim y = 0
        Dim total = dgv_becarios.Rows.Count
        If Len(txt_bec_numtra.Text) > 0 Then
            a.qr("select * from anom113 where g13_numtra=" + txt_bec_numtra.Text.ToString, 1)
            If Not a.rs.HasRows Then
                If Len(txt_bec_importe.Text) = 0 Then
                    MsgBox("Capturar salario diario")
                    Exit Sub
                End If
                If Len(txt_bec_sdi.Text) = 0 Then
                    MsgBox("Capturar salario diario integrado")
                    Exit Sub
                End If
                a.qr("select * from nombres where tponom=4 and numtra=" + txt_bec_numtra.Text.ToString, 1)
                If a.rs.HasRows Then
                    a.qr("insert into anom113 values (" + txt_bec_numtra.Text.ToString + "," + txt_bec_importe.Text.ToString + ",1,getdate()," + txt_bec_sdi.Text.ToString + ",0,13001)", 2)
                    txt_bec_numtra.Text = ""
                    txt_bec_nombre.Text = ""
                    txt_bec_importe.Text = ""
                    txt_bec_sdi.Text = ""
                    bot_bec_buscar.PerformClick()
                Else
                    MsgBox("Numero de trabajador no existe")
                    Exit Sub
                End If
            End If
        End If
        'y = dgv_becarios.Rows(dgv_becarios.CurrentCellAddress.Y).Cells(0).Value
        While y < total - 1
            'MsgBox(dgv_becarios.Rows(dgv_becarios.CurrentCellAddress.Y).Cells(0).Value)
            a.qr("update anom113 set g13_sdi=" + dgv_becarios.Rows(y).Cells(4).Value.ToString +
                 ",g13_dias=" + dgv_becarios.Rows(y).Cells(3).Value.ToString +
                 ",g13_importe=" + dgv_becarios.Rows(y).Cells(2).Value.ToString +
                 " where g13_numtra=" + dgv_becarios.Rows(y).Cells(0).Value.ToString, 2)
            y += 1
        End While
        bot_bec_buscar.PerformClick()
        MsgBox("Proceso terminado")
    End Sub

    Private Sub bot_bec_eliminar_Click(sender As Object, e As EventArgs) Handles bot_bec_eliminar.Click
        Dim numtra = dgv_becarios.Rows(dgv_becarios.CurrentCellAddress.Y).Cells(0).Value
        If MsgBox("Eliminar registro: " + numtra.ToString + "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            a.qr("delete from anom113 where g13_numtra=" + numtra.ToString, 2)
            bot_bec_buscar.PerformClick()
            MsgBox("Registro eliminado")
        End If
    End Sub

    Private Sub txt_bec_numtra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_bec_numtra.KeyPress
        If e.KeyChar = Chr(13) Then
            a.qr("select * from nombres where tponom=4 and numtra=" + txt_bec_numtra.Text.ToString, 1)
            If a.rs.HasRows Then
                a.rs.Read()
                txt_bec_nombre.Text = a.rs!nombre
            Else
                MsgBox("Numero de trabajador no existe")
            End If
            txt_bec_importe.Focus()
        End If
    End Sub

    Private Sub txt_bec_importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_bec_importe.KeyPress
        If e.KeyChar = Chr(13) Then
            txt_bec_sdi.Focus()
        End If
    End Sub

    Private Sub txt_bec_sdi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_bec_sdi.KeyPress
        If e.KeyChar = Chr(13) Then
            bot_bec_guardar.Focus()
        End If
    End Sub

    Private Sub Nom102CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Nom102CategoriasToolStripMenuItem.Click
        Dim archivo = "c:\temp\rep_nom102x.xlsx"
        Dim fila = 5
        Dim hoja As Worksheet
        Dim libro As Workbook
        Dim libnew As Workbook
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
        hoja.Range("A1").Text = "INDUSTRIAL AZUCARERA SAN CRISTOBAL S.A. DE C.V."
        hoja.Range("A1").Style.Font.Size = 16
        hoja.Range("A1").Style.Font.FontName = "Calibri"
        hoja.Range("A2").Text = "REPORTE DE CATEGORIAS"
        hoja.Range("A1:A2").Style.Font.IsBold = True
        hoja.Range("a1:a2").Style.HorizontalAlignment = HorizontalAlignType.Center
        hoja.Range("A1:H1").Merge()
        hoja.Range("A2:H2").Merge()
        hoja.Range("A4").Text = "CATEGO"
        hoja.Range("B4").Text = "NOMBRE"
        hoja.Range("C4").Text = "TPONOM"
        hoja.Range("D4").Text = "SUELDO"
        hoja.Range("E4").Text = "ALIMENTO"
        hoja.Range("F4").Text = "ALTURA"
        hoja.Range("G4").Text = "COM.ZAFRA"
        hoja.Range("H4").Text = "COM.REPAR"
        hoja.Range("A4:H4").Style.Font.IsBold = True
        hoja.Range("A4:H4").BorderAround(LineStyleType.Medium, Color.Black)
        a.qr("select g2_catego,g2a_nombrelargo,g2_tponom,g2_sueldo,g2_horali,g2_comalt,g2_comzaf,g2_comrep from anom102,anom102a" +
                " where g2_catego=g2a_catego" +
                " and g2_turno=2" +
                " order by 3,1", 1)
        While a.rs.Read
            hoja.Range("A" + fila.ToString).Text = a.rs.Item(0)
            hoja.Range("B" + fila.ToString).Text = a.rs.Item(1)
            hoja.Range("C" + fila.ToString).Text = a.rs.Item(2)
            hoja.Range("D" + fila.ToString).NumberValue = a.rs.Item(3)
            hoja.Range("E" + fila.ToString).NumberValue = a.rs.Item(4)
            hoja.Range("F" + fila.ToString).NumberValue = a.rs.Item(5)
            hoja.Range("G" + fila.ToString).NumberValue = a.rs.Item(6)
            hoja.Range("H" + fila.ToString).NumberValue = a.rs.Item(7)
            fila += 1
        End While
        fila -= 1
        hoja.Range("A4:H4").Style.Color = Color.LightBlue
        hoja.Range("A4:H" + fila.ToString).BorderAround(LineStyleType.Thin, Color.Black)
        hoja.Range("A4:H" + fila.ToString).BorderInside(LineStyleType.Thin, Color.Black)
        hoja.Range("D5:H" + fila.ToString).NumberFormat = "#,##0.00"
        hoja.AllocatedRange.AutoFitColumns()
        libro.SaveToFile(archivo, ExcelVersion.Version2010)
        libnew = New Workbook
        libnew.LoadFromFile(archivo)
        libnew.Worksheets(1).Remove()
        libnew.Worksheets(1).Remove()
        libnew.Worksheets(1).Remove()
        libnew.SaveToFile(archivo, ExcelVersion.Version2010)
        Process.Start(archivo)
    End Sub

    Private Sub bot_cat_buscar_Click(sender As Object, e As EventArgs) Handles bot_cat_buscar.Click
        dgv_categorias.Rows.Clear()
        Dim query = "Select g2_tponom,g2_catego,g2a_nombrelargo,g2_turno,g2_sueldo,g2_comalt,g2_hormix,g2_horali,g2_comzaf,g2_comrep from anom102a,anom102" +
            " where g2a_catego=g2_catego" +
            " And g2_catego>0"
        If Len(cmb_cat_tponom.Text) > 0 Then
            query += " and g2_tponom=" + Mid(cmb_cat_tponom.Text, 1, 1)
        End If
        If Len(txt_cat_catego.Text) > 0 Then
            query += " and g2_catego=" + txt_cat_catego.Text.ToString
        End If
        query += " order by g2_tponom,g2_catego,g2_turno"
        a.qr(query, 1)
        While a.rs.Read
            dgv_categorias.Rows.Add(a.rs.Item(0), a.rs.Item(1), a.rs.Item(2), a.rs.Item(3), a.rs.Item(4), a.rs.Item(5), a.rs.Item(6), a.rs.Item(7), a.rs.Item(8), a.rs.Item(9))
        End While
    End Sub
    Public Sub borra_catego()
        cmb_cat_tponom.SelectedIndex = -1
        txt_cat_catego.Text = ""
        txt_cat_nombre.Text = ""
        txt_cat_sueldo.Text = ""
        txt_cat_altura.Text = ""
        txt_cat_comrep.Text = ""
        txt_cat_comzaf.Text = ""
        txt_cat_laboro.Text = ""
        chk_cat_alimento.Checked = False
        dgv_categorias.Rows.Clear()
    End Sub

    Private Sub bot_cat_guardar_Click(sender As Object, e As EventArgs) Handles bot_cat_guardar.Click
        Dim wtponom = 0
        Dim wcatego = 0
        Dim wnombre = ""
        Dim wsueldo = 0.00
        Dim walt = 0.00
        Dim wali = 0
        Dim wcomz = 0.00
        Dim wcomr = 0.00
        wcatego = txt_cat_catego.Text
        wsueldo = Val(txt_cat_sueldo.Text)
        walt = Val(txt_cat_altura.Text)
        wcomz = Val(txt_cat_comzaf.Text)
        wcomr = Val(txt_cat_comrep.Text)
        If chk_cat_alimento.Checked = True Then
            wali = 1
        End If
        If Not Val(wcatego) > 0 Then
            MsgBox("Categoria no existe")
            Exit Sub
        End If
        If wcatego < 400 Then
            wtponom = 1
        Else
            wtponom = 2
        End If
        If Len(txt_cat_nombre.Text) > 4 Then
            wnombre = UCase(txt_cat_nombre.Text)
        Else
            MsgBox("Nombre no valido")
            Exit Sub
        End If
        a.qr("exec act_catego " + wcatego.ToString + ",'" +
                                    wnombre.ToString + "'," +
                                    wsueldo.ToString + "," +
                                    wali.ToString + "," +
                                    walt.ToString + "," +
                                    wcomr.ToString + "," +
                                    wcomz.ToString, 2)
        MsgBox("proceso relizado")
        borra_catego()
    End Sub

    Private Sub txt_cat_catego_Leave(sender As Object, e As EventArgs) Handles txt_cat_catego.Leave
        If Len(txt_cat_catego.Text) > 0 Then
            a.qr("select g2_catego,g2a_nombrelargo,g2_tponom,g2_sueldo,g2_comalt,g2_horali,g2_comzaf,g2_comrep,convert(char(10),g2a_ultimo,103) g2a_ultimo from anom102a,anom102" +
                " where g2a_catego=g2_catego" +
                " and g2_catego=" + txt_cat_catego.Text.ToString +
                " and g2_catego>0" +
                " and g2_turno=2", 1)
            If a.rs.HasRows Then
                a.rs.Read()
                If a.rs!g2_tponom = 1 Then
                    cmb_cat_tponom.SelectedIndex = 0
                Else
                    cmb_cat_tponom.SelectedIndex = 1
                End If
                If a.rs!g2_horali > 0 Then
                    chk_cat_alimento.Checked = True
                End If
                txt_cat_catego.Text = a.rs!g2_catego
                txt_cat_nombre.Text = a.rs!g2a_nombrelargo
                txt_cat_sueldo.Text = a.rs!g2_sueldo
                txt_cat_altura.Text = a.rs!g2_comalt
                txt_cat_comzaf.Text = a.rs!g2_comzaf
                txt_cat_comrep.Text = a.rs!g2_comrep
                txt_cat_laboro.Text = a.rs!g2a_ultimo
            Else
                borra_catego()
            End If
        End If
    End Sub

    Private Sub MantenimientoABaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoABaseDeDatosToolStripMenuItem.Click
        a.qr("backup log san_cristobal with truncate_only DBCC SHRINKDATABASE (san_cristobal , TRUNCATEONLY) ", 2)
        MsgBox("Proceso realizado", MsgBoxStyle.Exclamation)
    End Sub
End Class