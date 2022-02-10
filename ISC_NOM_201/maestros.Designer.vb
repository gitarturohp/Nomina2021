<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class maestros
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(maestros))
        Me.tab_catalogos = New System.Windows.Forms.TabControl()
        Me.tab_fisica = New System.Windows.Forms.TabPage()
        Me.lbl_clave_fisica = New System.Windows.Forms.Label()
        Me.txt_fisica = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtb_fec_nac = New System.Windows.Forms.MaskedTextBox()
        Me.bot_fis_buscar = New System.Windows.Forms.Button()
        Me.bot_fis_eliminar = New System.Windows.Forms.Button()
        Me.bot_fis_guarda = New System.Windows.Forms.Button()
        Me.cmb_edocivil = New System.Windows.Forms.ComboBox()
        Me.cmb_sexo = New System.Windows.Forms.ComboBox()
        Me.dgv_fisicas = New System.Windows.Forms.DataGridView()
        Me.iden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rfc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_imss = New System.Windows.Forms.TextBox()
        Me.txt_curp = New System.Windows.Forms.TextBox()
        Me.txt_rfc = New System.Windows.Forms.TextBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.txt_materno = New System.Windows.Forms.TextBox()
        Me.txt_paterno = New System.Windows.Forms.TextBox()
        Me.tab_relacion = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_nom_repre = New System.Windows.Forms.TextBox()
        Me.txt_rel_nom = New System.Windows.Forms.TextBox()
        Me.bot_rel_bus = New System.Windows.Forms.Button()
        Me.bot_rel_elim = New System.Windows.Forms.Button()
        Me.bot_rel_guardar = New System.Windows.Forms.Button()
        Me.dgv_relaciones = New System.Windows.Forms.DataGridView()
        Me.relab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.person = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fisica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nom_relab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rfc_relab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtb_repre = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_rel_numtra = New System.Windows.Forms.MaskedTextBox()
        Me.cmb_relacion = New System.Windows.Forms.ComboBox()
        Me.mtb_rel_clave = New System.Windows.Forms.MaskedTextBox()
        Me.cmb_tipoper = New System.Windows.Forms.ComboBox()
        Me.tab_pensiones = New System.Windows.Forms.TabPage()
        Me.cmb_conse = New System.Windows.Forms.ComboBox()
        Me.lbl_bene_nom = New System.Windows.Forms.Label()
        Me.lbl_bene = New System.Windows.Forms.Label()
        Me.txt_nom_bene = New System.Windows.Forms.TextBox()
        Me.mtb_bene = New System.Windows.Forms.MaskedTextBox()
        Me.bot_pen_buscar = New System.Windows.Forms.Button()
        Me.bot_pen_eliminar = New System.Windows.Forms.Button()
        Me.bot_pen_guardar = New System.Windows.Forms.Button()
        Me.dgv_pensiones = New System.Windows.Forms.DataGridView()
        Me.tponom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nom_pen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Consec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Benef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_importe = New System.Windows.Forms.Label()
        Me.lbl_aplica = New System.Windows.Forms.Label()
        Me.lbl_indicador = New System.Windows.Forms.Label()
        Me.lbl_conse = New System.Windows.Forms.Label()
        Me.lbl_pen_nom = New System.Windows.Forms.Label()
        Me.lbl_pen_numtra = New System.Windows.Forms.Label()
        Me.lbl_pen_tponom = New System.Windows.Forms.Label()
        Me.mtb_importe = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_pen_numtra = New System.Windows.Forms.MaskedTextBox()
        Me.cmb_aplica = New System.Windows.Forms.ComboBox()
        Me.cmb_pen_indica = New System.Windows.Forms.ComboBox()
        Me.txt_pen_nom = New System.Windows.Forms.TextBox()
        Me.cmb_pen_tponom = New System.Windows.Forms.ComboBox()
        Me.tab_trabajadores = New System.Windows.Forms.TabPage()
        Me.txt_105_sdi = New System.Windows.Forms.TextBox()
        Me.lbl_105_sdi = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.mtb_105_escala = New System.Windows.Forms.MaskedTextBox()
        Me.dtp_105_jubpen = New System.Windows.Forms.DateTimePicker()
        Me.lbl_105_jubpen = New System.Windows.Forms.Label()
        Me.dtp_105_baja = New System.Windows.Forms.DateTimePicker()
        Me.lbl_105_baja = New System.Windows.Forms.Label()
        Me.dtp_105_alta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_105_alta = New System.Windows.Forms.Label()
        Me.dtp_105_perma = New System.Windows.Forms.DateTimePicker()
        Me.lbl_105_permanente = New System.Windows.Forms.Label()
        Me.dtp_105_tempo = New System.Windows.Forms.DateTimePicker()
        Me.lbl_105_temporal = New System.Windows.Forms.Label()
        Me.dtp_105_ingreso = New System.Windows.Forms.DateTimePicker()
        Me.lbl_105_ingreso = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmb_105_sindic = New System.Windows.Forms.ComboBox()
        Me.bot_105_buscar = New System.Windows.Forms.Button()
        Me.bot_105_elimin = New System.Windows.Forms.Button()
        Me.bot_105_guardar = New System.Windows.Forms.Button()
        Me.cmb_105_plaza = New System.Windows.Forms.ComboBox()
        Me.mtb_105_deprep = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_105_depzaf = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_105_catrep = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_105_catzaf = New System.Windows.Forms.MaskedTextBox()
        Me.txt_105_id = New System.Windows.Forms.TextBox()
        Me.txt_105_nombre = New System.Windows.Forms.TextBox()
        Me.mtb_105_numtra = New System.Windows.Forms.MaskedTextBox()
        Me.cmb_105_tponom = New System.Windows.Forms.ComboBox()
        Me.tab_jubilados = New System.Windows.Forms.TabPage()
        Me.lbl_jub_total = New System.Windows.Forms.Label()
        Me.txt_jub_total = New System.Windows.Forms.TextBox()
        Me.lbl_jub_tipo = New System.Windows.Forms.Label()
        Me.lbl_jub_importe = New System.Windows.Forms.Label()
        Me.lbl_jub_nombre = New System.Windows.Forms.Label()
        Me.lbl_jub_numtra = New System.Windows.Forms.Label()
        Me.cmb_jub_tipo = New System.Windows.Forms.ComboBox()
        Me.txt_jub_importe = New System.Windows.Forms.TextBox()
        Me.txt_jub_nombre = New System.Windows.Forms.TextBox()
        Me.txt_jub_numtra = New System.Windows.Forms.TextBox()
        Me.bot_jub_buscar = New System.Windows.Forms.Button()
        Me.bot_jub_eliminar = New System.Windows.Forms.Button()
        Me.bot_jub_guardar = New System.Windows.Forms.Button()
        Me.dgv_jubilados = New System.Windows.Forms.DataGridView()
        Me.jub_numtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jun_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jub_quin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.jub_mes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tab_becarios = New System.Windows.Forms.TabPage()
        Me.txt_bec_sdi = New System.Windows.Forms.TextBox()
        Me.lbl_bec_estado = New System.Windows.Forms.Label()
        Me.lbl_bec_total = New System.Windows.Forms.Label()
        Me.txt_bec_total = New System.Windows.Forms.TextBox()
        Me.lbl_bec_importe = New System.Windows.Forms.Label()
        Me.lbl_bec_nombre = New System.Windows.Forms.Label()
        Me.lbl_bec_numtra = New System.Windows.Forms.Label()
        Me.txt_bec_importe = New System.Windows.Forms.TextBox()
        Me.txt_bec_nombre = New System.Windows.Forms.TextBox()
        Me.txt_bec_numtra = New System.Windows.Forms.TextBox()
        Me.bot_bec_buscar = New System.Windows.Forms.Button()
        Me.bot_bec_eliminar = New System.Windows.Forms.Button()
        Me.bot_bec_guardar = New System.Windows.Forms.Button()
        Me.dgv_becarios = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sdi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_categorias = New System.Windows.Forms.TabPage()
        Me.lbl_cat_laboro = New System.Windows.Forms.Label()
        Me.txt_cat_laboro = New System.Windows.Forms.TextBox()
        Me.lbl_cat_tponom = New System.Windows.Forms.Label()
        Me.cmb_cat_tponom = New System.Windows.Forms.ComboBox()
        Me.dgv_categorias = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.catego = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.turno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sueldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Altura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hrstur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alimento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comzaf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comrep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_cat_comrep = New System.Windows.Forms.Label()
        Me.lbl_cat_comzaf = New System.Windows.Forms.Label()
        Me.lbl_cat_altura = New System.Windows.Forms.Label()
        Me.lbl_cat_sueldo = New System.Windows.Forms.Label()
        Me.lbl_cat_nombre = New System.Windows.Forms.Label()
        Me.lbl_cat_catego = New System.Windows.Forms.Label()
        Me.chk_cat_alimento = New System.Windows.Forms.CheckBox()
        Me.txt_cat_comrep = New System.Windows.Forms.TextBox()
        Me.txt_cat_comzaf = New System.Windows.Forms.TextBox()
        Me.txt_cat_altura = New System.Windows.Forms.TextBox()
        Me.txt_cat_sueldo = New System.Windows.Forms.TextBox()
        Me.txt_cat_nombre = New System.Windows.Forms.TextBox()
        Me.txt_cat_catego = New System.Windows.Forms.TextBox()
        Me.bot_cat_buscar = New System.Windows.Forms.Button()
        Me.bot_cat_guardar = New System.Windows.Forms.Button()
        Me.men_maestros = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MantenimientoABaseDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Nom105ListadoTrabajadoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nom102CategoriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeCorreosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tab_catalogos.SuspendLayout()
        Me.tab_fisica.SuspendLayout()
        CType(Me.dgv_fisicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_relacion.SuspendLayout()
        CType(Me.dgv_relaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_pensiones.SuspendLayout()
        CType(Me.dgv_pensiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_trabajadores.SuspendLayout()
        Me.tab_jubilados.SuspendLayout()
        CType(Me.dgv_jubilados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_becarios.SuspendLayout()
        CType(Me.dgv_becarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_categorias.SuspendLayout()
        CType(Me.dgv_categorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.men_maestros.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab_catalogos
        '
        Me.tab_catalogos.Controls.Add(Me.tab_fisica)
        Me.tab_catalogos.Controls.Add(Me.tab_relacion)
        Me.tab_catalogos.Controls.Add(Me.tab_pensiones)
        Me.tab_catalogos.Controls.Add(Me.tab_trabajadores)
        Me.tab_catalogos.Controls.Add(Me.tab_jubilados)
        Me.tab_catalogos.Controls.Add(Me.tab_becarios)
        Me.tab_catalogos.Controls.Add(Me.tab_categorias)
        Me.tab_catalogos.Location = New System.Drawing.Point(33, 44)
        Me.tab_catalogos.Name = "tab_catalogos"
        Me.tab_catalogos.SelectedIndex = 0
        Me.tab_catalogos.Size = New System.Drawing.Size(729, 435)
        Me.tab_catalogos.TabIndex = 0
        '
        'tab_fisica
        '
        Me.tab_fisica.BackColor = System.Drawing.Color.LightGray
        Me.tab_fisica.Controls.Add(Me.lbl_clave_fisica)
        Me.tab_fisica.Controls.Add(Me.txt_fisica)
        Me.tab_fisica.Controls.Add(Me.Label9)
        Me.tab_fisica.Controls.Add(Me.Label8)
        Me.tab_fisica.Controls.Add(Me.Label7)
        Me.tab_fisica.Controls.Add(Me.Label6)
        Me.tab_fisica.Controls.Add(Me.Label5)
        Me.tab_fisica.Controls.Add(Me.Label4)
        Me.tab_fisica.Controls.Add(Me.Label3)
        Me.tab_fisica.Controls.Add(Me.Label2)
        Me.tab_fisica.Controls.Add(Me.Label1)
        Me.tab_fisica.Controls.Add(Me.mtb_fec_nac)
        Me.tab_fisica.Controls.Add(Me.bot_fis_buscar)
        Me.tab_fisica.Controls.Add(Me.bot_fis_eliminar)
        Me.tab_fisica.Controls.Add(Me.bot_fis_guarda)
        Me.tab_fisica.Controls.Add(Me.cmb_edocivil)
        Me.tab_fisica.Controls.Add(Me.cmb_sexo)
        Me.tab_fisica.Controls.Add(Me.dgv_fisicas)
        Me.tab_fisica.Controls.Add(Me.txt_imss)
        Me.tab_fisica.Controls.Add(Me.txt_curp)
        Me.tab_fisica.Controls.Add(Me.txt_rfc)
        Me.tab_fisica.Controls.Add(Me.txt_nombre)
        Me.tab_fisica.Controls.Add(Me.txt_materno)
        Me.tab_fisica.Controls.Add(Me.txt_paterno)
        Me.tab_fisica.Location = New System.Drawing.Point(4, 22)
        Me.tab_fisica.Name = "tab_fisica"
        Me.tab_fisica.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_fisica.Size = New System.Drawing.Size(721, 409)
        Me.tab_fisica.TabIndex = 0
        Me.tab_fisica.Text = "Persona fisica"
        '
        'lbl_clave_fisica
        '
        Me.lbl_clave_fisica.AutoSize = True
        Me.lbl_clave_fisica.Location = New System.Drawing.Point(344, 27)
        Me.lbl_clave_fisica.Name = "lbl_clave_fisica"
        Me.lbl_clave_fisica.Size = New System.Drawing.Size(34, 13)
        Me.lbl_clave_fisica.TabIndex = 24
        Me.lbl_clave_fisica.Text = "Clave"
        '
        'txt_fisica
        '
        Me.txt_fisica.Enabled = False
        Me.txt_fisica.Location = New System.Drawing.Point(347, 44)
        Me.txt_fisica.Name = "txt_fisica"
        Me.txt_fisica.Size = New System.Drawing.Size(100, 20)
        Me.txt_fisica.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(244, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Fecha Nacimiento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(138, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Estado Civil"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Sexo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(138, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "NSS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "CURP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "RFC"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Materno"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Paterno"
        '
        'mtb_fec_nac
        '
        Me.mtb_fec_nac.Location = New System.Drawing.Point(241, 131)
        Me.mtb_fec_nac.Mask = "00/00/0000"
        Me.mtb_fec_nac.Name = "mtb_fec_nac"
        Me.mtb_fec_nac.Size = New System.Drawing.Size(100, 20)
        Me.mtb_fec_nac.TabIndex = 13
        Me.mtb_fec_nac.ValidatingType = GetType(Date)
        '
        'bot_fis_buscar
        '
        Me.bot_fis_buscar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_fis_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_fis_buscar.Location = New System.Drawing.Point(612, 88)
        Me.bot_fis_buscar.Name = "bot_fis_buscar"
        Me.bot_fis_buscar.Size = New System.Drawing.Size(75, 23)
        Me.bot_fis_buscar.TabIndex = 12
        Me.bot_fis_buscar.Text = "Buscar"
        Me.bot_fis_buscar.UseVisualStyleBackColor = False
        '
        'bot_fis_eliminar
        '
        Me.bot_fis_eliminar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_fis_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_fis_eliminar.Location = New System.Drawing.Point(612, 57)
        Me.bot_fis_eliminar.Name = "bot_fis_eliminar"
        Me.bot_fis_eliminar.Size = New System.Drawing.Size(75, 23)
        Me.bot_fis_eliminar.TabIndex = 11
        Me.bot_fis_eliminar.Text = "Eliminar"
        Me.bot_fis_eliminar.UseVisualStyleBackColor = False
        '
        'bot_fis_guarda
        '
        Me.bot_fis_guarda.BackColor = System.Drawing.SystemColors.Control
        Me.bot_fis_guarda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_fis_guarda.Location = New System.Drawing.Point(612, 28)
        Me.bot_fis_guarda.Name = "bot_fis_guarda"
        Me.bot_fis_guarda.Size = New System.Drawing.Size(75, 23)
        Me.bot_fis_guarda.TabIndex = 10
        Me.bot_fis_guarda.Text = "Guardar"
        Me.bot_fis_guarda.UseVisualStyleBackColor = False
        '
        'cmb_edocivil
        '
        Me.cmb_edocivil.FormattingEnabled = True
        Me.cmb_edocivil.Items.AddRange(New Object() {"1-SOLTERO", "2-CASADO"})
        Me.cmb_edocivil.Location = New System.Drawing.Point(135, 131)
        Me.cmb_edocivil.Name = "cmb_edocivil"
        Me.cmb_edocivil.Size = New System.Drawing.Size(100, 21)
        Me.cmb_edocivil.TabIndex = 8
        '
        'cmb_sexo
        '
        Me.cmb_sexo.FormattingEnabled = True
        Me.cmb_sexo.Items.AddRange(New Object() {"1-MASCULINO", "2-FEMENINO"})
        Me.cmb_sexo.Location = New System.Drawing.Point(29, 131)
        Me.cmb_sexo.Name = "cmb_sexo"
        Me.cmb_sexo.Size = New System.Drawing.Size(100, 21)
        Me.cmb_sexo.TabIndex = 7
        '
        'dgv_fisicas
        '
        Me.dgv_fisicas.AllowUserToAddRows = False
        Me.dgv_fisicas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_fisicas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_fisicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_fisicas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iden, Me.Pat, Me.mat, Me.nom, Me.rfc})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_fisicas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_fisicas.Location = New System.Drawing.Point(29, 180)
        Me.dgv_fisicas.Name = "dgv_fisicas"
        Me.dgv_fisicas.ReadOnly = True
        Me.dgv_fisicas.Size = New System.Drawing.Size(658, 160)
        Me.dgv_fisicas.TabIndex = 6
        '
        'iden
        '
        Me.iden.HeaderText = "Clave"
        Me.iden.Name = "iden"
        Me.iden.ReadOnly = True
        Me.iden.Width = 40
        '
        'Pat
        '
        Me.Pat.HeaderText = "Paterno"
        Me.Pat.Name = "Pat"
        Me.Pat.ReadOnly = True
        Me.Pat.Width = 150
        '
        'mat
        '
        Me.mat.HeaderText = "Materno"
        Me.mat.Name = "mat"
        Me.mat.ReadOnly = True
        Me.mat.Width = 150
        '
        'nom
        '
        Me.nom.HeaderText = "Nombre"
        Me.nom.Name = "nom"
        Me.nom.ReadOnly = True
        Me.nom.Width = 150
        '
        'rfc
        '
        Me.rfc.HeaderText = "RFC"
        Me.rfc.Name = "rfc"
        Me.rfc.ReadOnly = True
        '
        'txt_imss
        '
        Me.txt_imss.Location = New System.Drawing.Point(134, 88)
        Me.txt_imss.Name = "txt_imss"
        Me.txt_imss.Size = New System.Drawing.Size(100, 20)
        Me.txt_imss.TabIndex = 5
        '
        'txt_curp
        '
        Me.txt_curp.Location = New System.Drawing.Point(241, 88)
        Me.txt_curp.Name = "txt_curp"
        Me.txt_curp.Size = New System.Drawing.Size(206, 20)
        Me.txt_curp.TabIndex = 4
        '
        'txt_rfc
        '
        Me.txt_rfc.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_rfc.Location = New System.Drawing.Point(29, 88)
        Me.txt_rfc.Name = "txt_rfc"
        Me.txt_rfc.Size = New System.Drawing.Size(100, 20)
        Me.txt_rfc.TabIndex = 3
        '
        'txt_nombre
        '
        Me.txt_nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_nombre.Location = New System.Drawing.Point(241, 44)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(100, 20)
        Me.txt_nombre.TabIndex = 2
        '
        'txt_materno
        '
        Me.txt_materno.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_materno.Location = New System.Drawing.Point(135, 44)
        Me.txt_materno.Name = "txt_materno"
        Me.txt_materno.Size = New System.Drawing.Size(100, 20)
        Me.txt_materno.TabIndex = 1
        '
        'txt_paterno
        '
        Me.txt_paterno.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_paterno.Location = New System.Drawing.Point(29, 44)
        Me.txt_paterno.Name = "txt_paterno"
        Me.txt_paterno.Size = New System.Drawing.Size(100, 20)
        Me.txt_paterno.TabIndex = 0
        '
        'tab_relacion
        '
        Me.tab_relacion.BackColor = System.Drawing.Color.LightGray
        Me.tab_relacion.Controls.Add(Me.Label16)
        Me.tab_relacion.Controls.Add(Me.Label15)
        Me.tab_relacion.Controls.Add(Me.Label14)
        Me.tab_relacion.Controls.Add(Me.Label13)
        Me.tab_relacion.Controls.Add(Me.Label12)
        Me.tab_relacion.Controls.Add(Me.Label11)
        Me.tab_relacion.Controls.Add(Me.Label10)
        Me.tab_relacion.Controls.Add(Me.txt_nom_repre)
        Me.tab_relacion.Controls.Add(Me.txt_rel_nom)
        Me.tab_relacion.Controls.Add(Me.bot_rel_bus)
        Me.tab_relacion.Controls.Add(Me.bot_rel_elim)
        Me.tab_relacion.Controls.Add(Me.bot_rel_guardar)
        Me.tab_relacion.Controls.Add(Me.dgv_relaciones)
        Me.tab_relacion.Controls.Add(Me.mtb_repre)
        Me.tab_relacion.Controls.Add(Me.mtb_rel_numtra)
        Me.tab_relacion.Controls.Add(Me.cmb_relacion)
        Me.tab_relacion.Controls.Add(Me.mtb_rel_clave)
        Me.tab_relacion.Controls.Add(Me.cmb_tipoper)
        Me.tab_relacion.Location = New System.Drawing.Point(4, 22)
        Me.tab_relacion.Name = "tab_relacion"
        Me.tab_relacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_relacion.Size = New System.Drawing.Size(721, 409)
        Me.tab_relacion.TabIndex = 1
        Me.tab_relacion.Text = "Relacion"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(130, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Nombre representante"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Representante"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(149, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Numtra"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(25, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Relacion"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(114, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Clave"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(231, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Nombre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Persona"
        '
        'txt_nom_repre
        '
        Me.txt_nom_repre.Location = New System.Drawing.Point(133, 131)
        Me.txt_nom_repre.Name = "txt_nom_repre"
        Me.txt_nom_repre.Size = New System.Drawing.Size(312, 20)
        Me.txt_nom_repre.TabIndex = 21
        '
        'txt_rel_nom
        '
        Me.txt_rel_nom.Location = New System.Drawing.Point(173, 40)
        Me.txt_rel_nom.Name = "txt_rel_nom"
        Me.txt_rel_nom.Size = New System.Drawing.Size(272, 20)
        Me.txt_rel_nom.TabIndex = 20
        '
        'bot_rel_bus
        '
        Me.bot_rel_bus.BackColor = System.Drawing.SystemColors.Control
        Me.bot_rel_bus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_rel_bus.Location = New System.Drawing.Point(612, 83)
        Me.bot_rel_bus.Name = "bot_rel_bus"
        Me.bot_rel_bus.Size = New System.Drawing.Size(75, 23)
        Me.bot_rel_bus.TabIndex = 19
        Me.bot_rel_bus.Text = "Buscar"
        Me.bot_rel_bus.UseVisualStyleBackColor = False
        '
        'bot_rel_elim
        '
        Me.bot_rel_elim.BackColor = System.Drawing.SystemColors.Control
        Me.bot_rel_elim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_rel_elim.Location = New System.Drawing.Point(612, 54)
        Me.bot_rel_elim.Name = "bot_rel_elim"
        Me.bot_rel_elim.Size = New System.Drawing.Size(75, 23)
        Me.bot_rel_elim.TabIndex = 18
        Me.bot_rel_elim.Text = "Eliminar"
        Me.bot_rel_elim.UseVisualStyleBackColor = False
        '
        'bot_rel_guardar
        '
        Me.bot_rel_guardar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_rel_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_rel_guardar.Location = New System.Drawing.Point(612, 25)
        Me.bot_rel_guardar.Name = "bot_rel_guardar"
        Me.bot_rel_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_rel_guardar.TabIndex = 17
        Me.bot_rel_guardar.Text = "Guardar"
        Me.bot_rel_guardar.UseVisualStyleBackColor = False
        '
        'dgv_relaciones
        '
        Me.dgv_relaciones.AllowUserToAddRows = False
        Me.dgv_relaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_relaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_relaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_relaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.relab, Me.cve, Me.person, Me.fisica, Me.nom_relab, Me.rfc_relab})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_relaciones.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_relaciones.Location = New System.Drawing.Point(24, 177)
        Me.dgv_relaciones.Name = "dgv_relaciones"
        Me.dgv_relaciones.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_relaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_relaciones.Size = New System.Drawing.Size(663, 166)
        Me.dgv_relaciones.TabIndex = 5
        '
        'relab
        '
        Me.relab.HeaderText = "Relab"
        Me.relab.Name = "relab"
        Me.relab.ReadOnly = True
        Me.relab.Width = 40
        '
        'cve
        '
        Me.cve.HeaderText = "Clave"
        Me.cve.Name = "cve"
        Me.cve.ReadOnly = True
        Me.cve.Width = 40
        '
        'person
        '
        Me.person.HeaderText = "Persona"
        Me.person.Name = "person"
        Me.person.ReadOnly = True
        Me.person.Width = 40
        '
        'fisica
        '
        Me.fisica.HeaderText = "Fisica"
        Me.fisica.Name = "fisica"
        Me.fisica.ReadOnly = True
        Me.fisica.Width = 40
        '
        'nom_relab
        '
        Me.nom_relab.HeaderText = "Nombre"
        Me.nom_relab.Name = "nom_relab"
        Me.nom_relab.ReadOnly = True
        Me.nom_relab.Width = 250
        '
        'rfc_relab
        '
        Me.rfc_relab.HeaderText = "RFC"
        Me.rfc_relab.Name = "rfc_relab"
        Me.rfc_relab.ReadOnly = True
        '
        'mtb_repre
        '
        Me.mtb_repre.Location = New System.Drawing.Point(24, 131)
        Me.mtb_repre.Mask = "99999"
        Me.mtb_repre.Name = "mtb_repre"
        Me.mtb_repre.Size = New System.Drawing.Size(100, 20)
        Me.mtb_repre.TabIndex = 4
        Me.mtb_repre.ValidatingType = GetType(Integer)
        '
        'mtb_rel_numtra
        '
        Me.mtb_rel_numtra.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtb_rel_numtra.Location = New System.Drawing.Point(151, 86)
        Me.mtb_rel_numtra.Mask = "99999"
        Me.mtb_rel_numtra.Name = "mtb_rel_numtra"
        Me.mtb_rel_numtra.Size = New System.Drawing.Size(100, 20)
        Me.mtb_rel_numtra.TabIndex = 3
        Me.mtb_rel_numtra.ValidatingType = GetType(Integer)
        '
        'cmb_relacion
        '
        Me.cmb_relacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmb_relacion.FormattingEnabled = True
        Me.cmb_relacion.Items.AddRange(New Object() {"03-Obrero", "04-Empleado", "11-Pension", "14-Jubilado", "15-Becario"})
        Me.cmb_relacion.Location = New System.Drawing.Point(22, 86)
        Me.cmb_relacion.Name = "cmb_relacion"
        Me.cmb_relacion.Size = New System.Drawing.Size(121, 21)
        Me.cmb_relacion.TabIndex = 2
        '
        'mtb_rel_clave
        '
        Me.mtb_rel_clave.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtb_rel_clave.Location = New System.Drawing.Point(106, 41)
        Me.mtb_rel_clave.Mask = "99999"
        Me.mtb_rel_clave.Name = "mtb_rel_clave"
        Me.mtb_rel_clave.Size = New System.Drawing.Size(60, 20)
        Me.mtb_rel_clave.TabIndex = 1
        Me.mtb_rel_clave.ValidatingType = GetType(Integer)
        '
        'cmb_tipoper
        '
        Me.cmb_tipoper.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmb_tipoper.FormattingEnabled = True
        Me.cmb_tipoper.Items.AddRange(New Object() {"1-Moral", "2-Fisica"})
        Me.cmb_tipoper.Location = New System.Drawing.Point(25, 40)
        Me.cmb_tipoper.Name = "cmb_tipoper"
        Me.cmb_tipoper.Size = New System.Drawing.Size(74, 21)
        Me.cmb_tipoper.TabIndex = 0
        '
        'tab_pensiones
        '
        Me.tab_pensiones.BackColor = System.Drawing.Color.LightGray
        Me.tab_pensiones.Controls.Add(Me.cmb_conse)
        Me.tab_pensiones.Controls.Add(Me.lbl_bene_nom)
        Me.tab_pensiones.Controls.Add(Me.lbl_bene)
        Me.tab_pensiones.Controls.Add(Me.txt_nom_bene)
        Me.tab_pensiones.Controls.Add(Me.mtb_bene)
        Me.tab_pensiones.Controls.Add(Me.bot_pen_buscar)
        Me.tab_pensiones.Controls.Add(Me.bot_pen_eliminar)
        Me.tab_pensiones.Controls.Add(Me.bot_pen_guardar)
        Me.tab_pensiones.Controls.Add(Me.dgv_pensiones)
        Me.tab_pensiones.Controls.Add(Me.lbl_importe)
        Me.tab_pensiones.Controls.Add(Me.lbl_aplica)
        Me.tab_pensiones.Controls.Add(Me.lbl_indicador)
        Me.tab_pensiones.Controls.Add(Me.lbl_conse)
        Me.tab_pensiones.Controls.Add(Me.lbl_pen_nom)
        Me.tab_pensiones.Controls.Add(Me.lbl_pen_numtra)
        Me.tab_pensiones.Controls.Add(Me.lbl_pen_tponom)
        Me.tab_pensiones.Controls.Add(Me.mtb_importe)
        Me.tab_pensiones.Controls.Add(Me.mtb_pen_numtra)
        Me.tab_pensiones.Controls.Add(Me.cmb_aplica)
        Me.tab_pensiones.Controls.Add(Me.cmb_pen_indica)
        Me.tab_pensiones.Controls.Add(Me.txt_pen_nom)
        Me.tab_pensiones.Controls.Add(Me.cmb_pen_tponom)
        Me.tab_pensiones.Location = New System.Drawing.Point(4, 22)
        Me.tab_pensiones.Name = "tab_pensiones"
        Me.tab_pensiones.Size = New System.Drawing.Size(721, 409)
        Me.tab_pensiones.TabIndex = 2
        Me.tab_pensiones.Text = "Pensiones"
        '
        'cmb_conse
        '
        Me.cmb_conse.FormattingEnabled = True
        Me.cmb_conse.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7"})
        Me.cmb_conse.Location = New System.Drawing.Point(30, 87)
        Me.cmb_conse.Name = "cmb_conse"
        Me.cmb_conse.Size = New System.Drawing.Size(99, 21)
        Me.cmb_conse.TabIndex = 3
        '
        'lbl_bene_nom
        '
        Me.lbl_bene_nom.AutoSize = True
        Me.lbl_bene_nom.Location = New System.Drawing.Point(109, 122)
        Me.lbl_bene_nom.Name = "lbl_bene_nom"
        Me.lbl_bene_nom.Size = New System.Drawing.Size(118, 13)
        Me.lbl_bene_nom.TabIndex = 22
        Me.lbl_bene_nom.Text = "Nombre del beneficiario"
        '
        'lbl_bene
        '
        Me.lbl_bene.AutoSize = True
        Me.lbl_bene.Location = New System.Drawing.Point(32, 122)
        Me.lbl_bene.Name = "lbl_bene"
        Me.lbl_bene.Size = New System.Drawing.Size(62, 13)
        Me.lbl_bene.TabIndex = 21
        Me.lbl_bene.Text = "Beneficiario"
        '
        'txt_nom_bene
        '
        Me.txt_nom_bene.Enabled = False
        Me.txt_nom_bene.Location = New System.Drawing.Point(106, 138)
        Me.txt_nom_bene.Name = "txt_nom_bene"
        Me.txt_nom_bene.Size = New System.Drawing.Size(383, 20)
        Me.txt_nom_bene.TabIndex = 20
        '
        'mtb_bene
        '
        Me.mtb_bene.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtb_bene.Location = New System.Drawing.Point(29, 138)
        Me.mtb_bene.Mask = "99999"
        Me.mtb_bene.Name = "mtb_bene"
        Me.mtb_bene.Size = New System.Drawing.Size(59, 20)
        Me.mtb_bene.TabIndex = 7
        Me.mtb_bene.ValidatingType = GetType(Integer)
        '
        'bot_pen_buscar
        '
        Me.bot_pen_buscar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_pen_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_pen_buscar.Location = New System.Drawing.Point(610, 100)
        Me.bot_pen_buscar.Name = "bot_pen_buscar"
        Me.bot_pen_buscar.Size = New System.Drawing.Size(75, 23)
        Me.bot_pen_buscar.TabIndex = 10
        Me.bot_pen_buscar.Text = "Buscar"
        Me.bot_pen_buscar.UseVisualStyleBackColor = False
        '
        'bot_pen_eliminar
        '
        Me.bot_pen_eliminar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_pen_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_pen_eliminar.Location = New System.Drawing.Point(610, 71)
        Me.bot_pen_eliminar.Name = "bot_pen_eliminar"
        Me.bot_pen_eliminar.Size = New System.Drawing.Size(75, 23)
        Me.bot_pen_eliminar.TabIndex = 9
        Me.bot_pen_eliminar.Text = "Eliminar"
        Me.bot_pen_eliminar.UseVisualStyleBackColor = False
        '
        'bot_pen_guardar
        '
        Me.bot_pen_guardar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_pen_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_pen_guardar.Location = New System.Drawing.Point(610, 39)
        Me.bot_pen_guardar.Name = "bot_pen_guardar"
        Me.bot_pen_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_pen_guardar.TabIndex = 8
        Me.bot_pen_guardar.Text = "Guardar"
        Me.bot_pen_guardar.UseVisualStyleBackColor = False
        '
        'dgv_pensiones
        '
        Me.dgv_pensiones.AllowUserToAddRows = False
        Me.dgv_pensiones.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pensiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_pensiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pensiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tponom, Me.numtra, Me.nom_pen, Me.Consec, Me.Benef, Me.Nombre})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_pensiones.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_pensiones.Location = New System.Drawing.Point(29, 181)
        Me.dgv_pensiones.Name = "dgv_pensiones"
        Me.dgv_pensiones.ReadOnly = True
        Me.dgv_pensiones.Size = New System.Drawing.Size(656, 175)
        Me.dgv_pensiones.TabIndex = 15
        '
        'tponom
        '
        Me.tponom.HeaderText = "Nom"
        Me.tponom.Name = "tponom"
        Me.tponom.ReadOnly = True
        Me.tponom.Width = 40
        '
        'numtra
        '
        Me.numtra.HeaderText = "Numtra"
        Me.numtra.Name = "numtra"
        Me.numtra.ReadOnly = True
        Me.numtra.Width = 40
        '
        'nom_pen
        '
        Me.nom_pen.HeaderText = "Nombre"
        Me.nom_pen.Name = "nom_pen"
        Me.nom_pen.ReadOnly = True
        Me.nom_pen.Width = 215
        '
        'Consec
        '
        Me.Consec.HeaderText = "Conse"
        Me.Consec.Name = "Consec"
        Me.Consec.ReadOnly = True
        Me.Consec.Width = 40
        '
        'Benef
        '
        Me.Benef.HeaderText = "Benef"
        Me.Benef.Name = "Benef"
        Me.Benef.ReadOnly = True
        Me.Benef.Width = 40
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 215
        '
        'lbl_importe
        '
        Me.lbl_importe.AutoSize = True
        Me.lbl_importe.Location = New System.Drawing.Point(392, 71)
        Me.lbl_importe.Name = "lbl_importe"
        Me.lbl_importe.Size = New System.Drawing.Size(42, 13)
        Me.lbl_importe.TabIndex = 14
        Me.lbl_importe.Text = "Importe"
        '
        'lbl_aplica
        '
        Me.lbl_aplica.AutoSize = True
        Me.lbl_aplica.Location = New System.Drawing.Point(265, 71)
        Me.lbl_aplica.Name = "lbl_aplica"
        Me.lbl_aplica.Size = New System.Drawing.Size(70, 13)
        Me.lbl_aplica.TabIndex = 13
        Me.lbl_aplica.Text = "Aplica premio"
        '
        'lbl_indicador
        '
        Me.lbl_indicador.AutoSize = True
        Me.lbl_indicador.Location = New System.Drawing.Point(138, 72)
        Me.lbl_indicador.Name = "lbl_indicador"
        Me.lbl_indicador.Size = New System.Drawing.Size(51, 13)
        Me.lbl_indicador.TabIndex = 12
        Me.lbl_indicador.Text = "Indicador"
        '
        'lbl_conse
        '
        Me.lbl_conse.AutoSize = True
        Me.lbl_conse.Location = New System.Drawing.Point(30, 72)
        Me.lbl_conse.Name = "lbl_conse"
        Me.lbl_conse.Size = New System.Drawing.Size(66, 13)
        Me.lbl_conse.TabIndex = 11
        Me.lbl_conse.Text = "Consecutivo"
        '
        'lbl_pen_nom
        '
        Me.lbl_pen_nom.AutoSize = True
        Me.lbl_pen_nom.Location = New System.Drawing.Point(192, 24)
        Me.lbl_pen_nom.Name = "lbl_pen_nom"
        Me.lbl_pen_nom.Size = New System.Drawing.Size(119, 13)
        Me.lbl_pen_nom.TabIndex = 10
        Me.lbl_pen_nom.Text = "Nombre del pensionado"
        '
        'lbl_pen_numtra
        '
        Me.lbl_pen_numtra.AutoSize = True
        Me.lbl_pen_numtra.Location = New System.Drawing.Point(127, 24)
        Me.lbl_pen_numtra.Name = "lbl_pen_numtra"
        Me.lbl_pen_numtra.Size = New System.Drawing.Size(41, 13)
        Me.lbl_pen_numtra.TabIndex = 9
        Me.lbl_pen_numtra.Text = "Numtra"
        '
        'lbl_pen_tponom
        '
        Me.lbl_pen_tponom.AutoSize = True
        Me.lbl_pen_tponom.Location = New System.Drawing.Point(30, 24)
        Me.lbl_pen_tponom.Name = "lbl_pen_tponom"
        Me.lbl_pen_tponom.Size = New System.Drawing.Size(46, 13)
        Me.lbl_pen_tponom.TabIndex = 8
        Me.lbl_pen_tponom.Text = "Tponom"
        '
        'mtb_importe
        '
        Me.mtb_importe.Location = New System.Drawing.Point(389, 87)
        Me.mtb_importe.Mask = "99999.99"
        Me.mtb_importe.Name = "mtb_importe"
        Me.mtb_importe.Size = New System.Drawing.Size(100, 20)
        Me.mtb_importe.TabIndex = 6
        '
        'mtb_pen_numtra
        '
        Me.mtb_pen_numtra.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtb_pen_numtra.Location = New System.Drawing.Point(127, 40)
        Me.mtb_pen_numtra.Mask = "99999"
        Me.mtb_pen_numtra.Name = "mtb_pen_numtra"
        Me.mtb_pen_numtra.Size = New System.Drawing.Size(59, 20)
        Me.mtb_pen_numtra.TabIndex = 1
        Me.mtb_pen_numtra.ValidatingType = GetType(Integer)
        '
        'cmb_aplica
        '
        Me.cmb_aplica.FormattingEnabled = True
        Me.cmb_aplica.Items.AddRange(New Object() {"0-No", "1-Si"})
        Me.cmb_aplica.Location = New System.Drawing.Point(262, 87)
        Me.cmb_aplica.Name = "cmb_aplica"
        Me.cmb_aplica.Size = New System.Drawing.Size(121, 21)
        Me.cmb_aplica.TabIndex = 5
        '
        'cmb_pen_indica
        '
        Me.cmb_pen_indica.FormattingEnabled = True
        Me.cmb_pen_indica.Items.AddRange(New Object() {"1-Porcentaje", "2-Importe"})
        Me.cmb_pen_indica.Location = New System.Drawing.Point(135, 88)
        Me.cmb_pen_indica.Name = "cmb_pen_indica"
        Me.cmb_pen_indica.Size = New System.Drawing.Size(121, 21)
        Me.cmb_pen_indica.TabIndex = 4
        '
        'txt_pen_nom
        '
        Me.txt_pen_nom.Enabled = False
        Me.txt_pen_nom.Location = New System.Drawing.Point(192, 40)
        Me.txt_pen_nom.Name = "txt_pen_nom"
        Me.txt_pen_nom.Size = New System.Drawing.Size(297, 20)
        Me.txt_pen_nom.TabIndex = 2
        '
        'cmb_pen_tponom
        '
        Me.cmb_pen_tponom.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmb_pen_tponom.FormattingEnabled = True
        Me.cmb_pen_tponom.Items.AddRange(New Object() {"1-Obrero", "2-Empleado", "3-Jubilados"})
        Me.cmb_pen_tponom.Location = New System.Drawing.Point(30, 40)
        Me.cmb_pen_tponom.Name = "cmb_pen_tponom"
        Me.cmb_pen_tponom.Size = New System.Drawing.Size(92, 21)
        Me.cmb_pen_tponom.TabIndex = 0
        '
        'tab_trabajadores
        '
        Me.tab_trabajadores.BackColor = System.Drawing.Color.LightGray
        Me.tab_trabajadores.Controls.Add(Me.txt_105_sdi)
        Me.tab_trabajadores.Controls.Add(Me.lbl_105_sdi)
        Me.tab_trabajadores.Controls.Add(Me.Label27)
        Me.tab_trabajadores.Controls.Add(Me.mtb_105_escala)
        Me.tab_trabajadores.Controls.Add(Me.dtp_105_jubpen)
        Me.tab_trabajadores.Controls.Add(Me.lbl_105_jubpen)
        Me.tab_trabajadores.Controls.Add(Me.dtp_105_baja)
        Me.tab_trabajadores.Controls.Add(Me.lbl_105_baja)
        Me.tab_trabajadores.Controls.Add(Me.dtp_105_alta)
        Me.tab_trabajadores.Controls.Add(Me.lbl_105_alta)
        Me.tab_trabajadores.Controls.Add(Me.dtp_105_perma)
        Me.tab_trabajadores.Controls.Add(Me.lbl_105_permanente)
        Me.tab_trabajadores.Controls.Add(Me.dtp_105_tempo)
        Me.tab_trabajadores.Controls.Add(Me.lbl_105_temporal)
        Me.tab_trabajadores.Controls.Add(Me.dtp_105_ingreso)
        Me.tab_trabajadores.Controls.Add(Me.lbl_105_ingreso)
        Me.tab_trabajadores.Controls.Add(Me.Label26)
        Me.tab_trabajadores.Controls.Add(Me.Label25)
        Me.tab_trabajadores.Controls.Add(Me.Label24)
        Me.tab_trabajadores.Controls.Add(Me.Label23)
        Me.tab_trabajadores.Controls.Add(Me.Label22)
        Me.tab_trabajadores.Controls.Add(Me.Label21)
        Me.tab_trabajadores.Controls.Add(Me.Label20)
        Me.tab_trabajadores.Controls.Add(Me.Label19)
        Me.tab_trabajadores.Controls.Add(Me.Label18)
        Me.tab_trabajadores.Controls.Add(Me.Label17)
        Me.tab_trabajadores.Controls.Add(Me.cmb_105_sindic)
        Me.tab_trabajadores.Controls.Add(Me.bot_105_buscar)
        Me.tab_trabajadores.Controls.Add(Me.bot_105_elimin)
        Me.tab_trabajadores.Controls.Add(Me.bot_105_guardar)
        Me.tab_trabajadores.Controls.Add(Me.cmb_105_plaza)
        Me.tab_trabajadores.Controls.Add(Me.mtb_105_deprep)
        Me.tab_trabajadores.Controls.Add(Me.mtb_105_depzaf)
        Me.tab_trabajadores.Controls.Add(Me.mtb_105_catrep)
        Me.tab_trabajadores.Controls.Add(Me.mtb_105_catzaf)
        Me.tab_trabajadores.Controls.Add(Me.txt_105_id)
        Me.tab_trabajadores.Controls.Add(Me.txt_105_nombre)
        Me.tab_trabajadores.Controls.Add(Me.mtb_105_numtra)
        Me.tab_trabajadores.Controls.Add(Me.cmb_105_tponom)
        Me.tab_trabajadores.Location = New System.Drawing.Point(4, 22)
        Me.tab_trabajadores.Name = "tab_trabajadores"
        Me.tab_trabajadores.Size = New System.Drawing.Size(721, 409)
        Me.tab_trabajadores.TabIndex = 3
        Me.tab_trabajadores.Text = "Trabajadores"
        '
        'txt_105_sdi
        '
        Me.txt_105_sdi.Location = New System.Drawing.Point(394, 73)
        Me.txt_105_sdi.Name = "txt_105_sdi"
        Me.txt_105_sdi.Size = New System.Drawing.Size(85, 20)
        Me.txt_105_sdi.TabIndex = 4
        '
        'lbl_105_sdi
        '
        Me.lbl_105_sdi.AutoSize = True
        Me.lbl_105_sdi.Location = New System.Drawing.Point(391, 57)
        Me.lbl_105_sdi.Name = "lbl_105_sdi"
        Me.lbl_105_sdi.Size = New System.Drawing.Size(25, 13)
        Me.lbl_105_sdi.TabIndex = 46
        Me.lbl_105_sdi.Text = "SDI"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(482, 57)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(54, 13)
        Me.Label27.TabIndex = 45
        Me.Label27.Text = "Escalafon"
        '
        'mtb_105_escala
        '
        Me.mtb_105_escala.Location = New System.Drawing.Point(485, 73)
        Me.mtb_105_escala.Mask = "99999"
        Me.mtb_105_escala.Name = "mtb_105_escala"
        Me.mtb_105_escala.Size = New System.Drawing.Size(85, 20)
        Me.mtb_105_escala.TabIndex = 5
        '
        'dtp_105_jubpen
        '
        Me.dtp_105_jubpen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_105_jubpen.Location = New System.Drawing.Point(485, 170)
        Me.dtp_105_jubpen.Name = "dtp_105_jubpen"
        Me.dtp_105_jubpen.Size = New System.Drawing.Size(85, 20)
        Me.dtp_105_jubpen.TabIndex = 17
        '
        'lbl_105_jubpen
        '
        Me.lbl_105_jubpen.AutoSize = True
        Me.lbl_105_jubpen.Location = New System.Drawing.Point(482, 154)
        Me.lbl_105_jubpen.Name = "lbl_105_jubpen"
        Me.lbl_105_jubpen.Size = New System.Drawing.Size(94, 13)
        Me.lbl_105_jubpen.TabIndex = 42
        Me.lbl_105_jubpen.Text = "Jubilacion pension"
        '
        'dtp_105_baja
        '
        Me.dtp_105_baja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_105_baja.Location = New System.Drawing.Point(394, 170)
        Me.dtp_105_baja.Name = "dtp_105_baja"
        Me.dtp_105_baja.Size = New System.Drawing.Size(85, 20)
        Me.dtp_105_baja.TabIndex = 16
        '
        'lbl_105_baja
        '
        Me.lbl_105_baja.AutoSize = True
        Me.lbl_105_baja.Location = New System.Drawing.Point(391, 154)
        Me.lbl_105_baja.Name = "lbl_105_baja"
        Me.lbl_105_baja.Size = New System.Drawing.Size(57, 13)
        Me.lbl_105_baja.TabIndex = 40
        Me.lbl_105_baja.Text = "Baja IMSS"
        '
        'dtp_105_alta
        '
        Me.dtp_105_alta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_105_alta.Location = New System.Drawing.Point(303, 170)
        Me.dtp_105_alta.Name = "dtp_105_alta"
        Me.dtp_105_alta.Size = New System.Drawing.Size(85, 20)
        Me.dtp_105_alta.TabIndex = 15
        '
        'lbl_105_alta
        '
        Me.lbl_105_alta.AutoSize = True
        Me.lbl_105_alta.Location = New System.Drawing.Point(300, 154)
        Me.lbl_105_alta.Name = "lbl_105_alta"
        Me.lbl_105_alta.Size = New System.Drawing.Size(54, 13)
        Me.lbl_105_alta.TabIndex = 38
        Me.lbl_105_alta.Text = "Alta IMSS"
        '
        'dtp_105_perma
        '
        Me.dtp_105_perma.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_105_perma.Location = New System.Drawing.Point(212, 170)
        Me.dtp_105_perma.Name = "dtp_105_perma"
        Me.dtp_105_perma.Size = New System.Drawing.Size(85, 20)
        Me.dtp_105_perma.TabIndex = 14
        '
        'lbl_105_permanente
        '
        Me.lbl_105_permanente.AutoSize = True
        Me.lbl_105_permanente.Location = New System.Drawing.Point(209, 154)
        Me.lbl_105_permanente.Name = "lbl_105_permanente"
        Me.lbl_105_permanente.Size = New System.Drawing.Size(64, 13)
        Me.lbl_105_permanente.TabIndex = 36
        Me.lbl_105_permanente.Text = "Permanente"
        '
        'dtp_105_tempo
        '
        Me.dtp_105_tempo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_105_tempo.Location = New System.Drawing.Point(121, 170)
        Me.dtp_105_tempo.Name = "dtp_105_tempo"
        Me.dtp_105_tempo.Size = New System.Drawing.Size(85, 20)
        Me.dtp_105_tempo.TabIndex = 13
        '
        'lbl_105_temporal
        '
        Me.lbl_105_temporal.AutoSize = True
        Me.lbl_105_temporal.Location = New System.Drawing.Point(121, 154)
        Me.lbl_105_temporal.Name = "lbl_105_temporal"
        Me.lbl_105_temporal.Size = New System.Drawing.Size(51, 13)
        Me.lbl_105_temporal.TabIndex = 34
        Me.lbl_105_temporal.Text = "Temporal"
        '
        'dtp_105_ingreso
        '
        Me.dtp_105_ingreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_105_ingreso.Location = New System.Drawing.Point(30, 170)
        Me.dtp_105_ingreso.Name = "dtp_105_ingreso"
        Me.dtp_105_ingreso.Size = New System.Drawing.Size(85, 20)
        Me.dtp_105_ingreso.TabIndex = 12
        '
        'lbl_105_ingreso
        '
        Me.lbl_105_ingreso.AutoSize = True
        Me.lbl_105_ingreso.Location = New System.Drawing.Point(27, 154)
        Me.lbl_105_ingreso.Name = "lbl_105_ingreso"
        Me.lbl_105_ingreso.Size = New System.Drawing.Size(74, 13)
        Me.lbl_105_ingreso.TabIndex = 32
        Me.lbl_105_ingreso.Text = "Fecha ingreso"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(482, 102)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 13)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "Sindicalizado"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(391, 103)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Plaza"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(300, 103)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 13)
        Me.Label24.TabIndex = 28
        Me.Label24.Text = "Depto repara"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(209, 103)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 13)
        Me.Label23.TabIndex = 27
        Me.Label23.Text = "Depto zafra"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(118, 103)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 13)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "Catego Repara"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(27, 103)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 13)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Catego Zafra"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(148, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Nombre"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(86, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Clave"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(27, 57)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Numtra"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(27, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Tponom"
        '
        'cmb_105_sindic
        '
        Me.cmb_105_sindic.FormattingEnabled = True
        Me.cmb_105_sindic.Items.AddRange(New Object() {"1-Sindicalizado", "2-Confianza"})
        Me.cmb_105_sindic.Location = New System.Drawing.Point(485, 119)
        Me.cmb_105_sindic.Name = "cmb_105_sindic"
        Me.cmb_105_sindic.Size = New System.Drawing.Size(85, 21)
        Me.cmb_105_sindic.TabIndex = 11
        '
        'bot_105_buscar
        '
        Me.bot_105_buscar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_105_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_105_buscar.Location = New System.Drawing.Point(598, 102)
        Me.bot_105_buscar.Name = "bot_105_buscar"
        Me.bot_105_buscar.Size = New System.Drawing.Size(75, 23)
        Me.bot_105_buscar.TabIndex = 20
        Me.bot_105_buscar.Text = "Buscar"
        Me.bot_105_buscar.UseVisualStyleBackColor = False
        '
        'bot_105_elimin
        '
        Me.bot_105_elimin.BackColor = System.Drawing.SystemColors.Control
        Me.bot_105_elimin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_105_elimin.Location = New System.Drawing.Point(598, 73)
        Me.bot_105_elimin.Name = "bot_105_elimin"
        Me.bot_105_elimin.Size = New System.Drawing.Size(75, 23)
        Me.bot_105_elimin.TabIndex = 19
        Me.bot_105_elimin.Text = "Eliminar"
        Me.bot_105_elimin.UseVisualStyleBackColor = False
        '
        'bot_105_guardar
        '
        Me.bot_105_guardar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_105_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_105_guardar.Location = New System.Drawing.Point(598, 44)
        Me.bot_105_guardar.Name = "bot_105_guardar"
        Me.bot_105_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_105_guardar.TabIndex = 18
        Me.bot_105_guardar.Text = "Guardar"
        Me.bot_105_guardar.UseVisualStyleBackColor = False
        '
        'cmb_105_plaza
        '
        Me.cmb_105_plaza.FormattingEnabled = True
        Me.cmb_105_plaza.Items.AddRange(New Object() {"1-Permanente", "2-Temporal", "3-Eventual"})
        Me.cmb_105_plaza.Location = New System.Drawing.Point(394, 119)
        Me.cmb_105_plaza.Name = "cmb_105_plaza"
        Me.cmb_105_plaza.Size = New System.Drawing.Size(85, 21)
        Me.cmb_105_plaza.TabIndex = 10
        '
        'mtb_105_deprep
        '
        Me.mtb_105_deprep.Location = New System.Drawing.Point(303, 119)
        Me.mtb_105_deprep.Mask = "99999"
        Me.mtb_105_deprep.Name = "mtb_105_deprep"
        Me.mtb_105_deprep.Size = New System.Drawing.Size(85, 20)
        Me.mtb_105_deprep.TabIndex = 9
        '
        'mtb_105_depzaf
        '
        Me.mtb_105_depzaf.Location = New System.Drawing.Point(212, 119)
        Me.mtb_105_depzaf.Mask = "99999"
        Me.mtb_105_depzaf.Name = "mtb_105_depzaf"
        Me.mtb_105_depzaf.Size = New System.Drawing.Size(85, 20)
        Me.mtb_105_depzaf.TabIndex = 8
        '
        'mtb_105_catrep
        '
        Me.mtb_105_catrep.Location = New System.Drawing.Point(121, 119)
        Me.mtb_105_catrep.Mask = "999"
        Me.mtb_105_catrep.Name = "mtb_105_catrep"
        Me.mtb_105_catrep.Size = New System.Drawing.Size(85, 20)
        Me.mtb_105_catrep.TabIndex = 7
        '
        'mtb_105_catzaf
        '
        Me.mtb_105_catzaf.Location = New System.Drawing.Point(30, 119)
        Me.mtb_105_catzaf.Mask = "999"
        Me.mtb_105_catzaf.Name = "mtb_105_catzaf"
        Me.mtb_105_catzaf.Size = New System.Drawing.Size(85, 20)
        Me.mtb_105_catzaf.TabIndex = 6
        '
        'txt_105_id
        '
        Me.txt_105_id.Location = New System.Drawing.Point(89, 73)
        Me.txt_105_id.Name = "txt_105_id"
        Me.txt_105_id.Size = New System.Drawing.Size(53, 20)
        Me.txt_105_id.TabIndex = 2
        '
        'txt_105_nombre
        '
        Me.txt_105_nombre.Location = New System.Drawing.Point(148, 73)
        Me.txt_105_nombre.Name = "txt_105_nombre"
        Me.txt_105_nombre.Size = New System.Drawing.Size(240, 20)
        Me.txt_105_nombre.TabIndex = 3
        '
        'mtb_105_numtra
        '
        Me.mtb_105_numtra.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtb_105_numtra.Location = New System.Drawing.Point(30, 73)
        Me.mtb_105_numtra.Mask = "99999"
        Me.mtb_105_numtra.Name = "mtb_105_numtra"
        Me.mtb_105_numtra.Size = New System.Drawing.Size(53, 20)
        Me.mtb_105_numtra.TabIndex = 1
        '
        'cmb_105_tponom
        '
        Me.cmb_105_tponom.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmb_105_tponom.FormattingEnabled = True
        Me.cmb_105_tponom.Items.AddRange(New Object() {"1-Sindicalizado", "2-Confianza"})
        Me.cmb_105_tponom.Location = New System.Drawing.Point(30, 30)
        Me.cmb_105_tponom.Name = "cmb_105_tponom"
        Me.cmb_105_tponom.Size = New System.Drawing.Size(121, 21)
        Me.cmb_105_tponom.TabIndex = 0
        '
        'tab_jubilados
        '
        Me.tab_jubilados.BackColor = System.Drawing.Color.LightGray
        Me.tab_jubilados.Controls.Add(Me.lbl_jub_total)
        Me.tab_jubilados.Controls.Add(Me.txt_jub_total)
        Me.tab_jubilados.Controls.Add(Me.lbl_jub_tipo)
        Me.tab_jubilados.Controls.Add(Me.lbl_jub_importe)
        Me.tab_jubilados.Controls.Add(Me.lbl_jub_nombre)
        Me.tab_jubilados.Controls.Add(Me.lbl_jub_numtra)
        Me.tab_jubilados.Controls.Add(Me.cmb_jub_tipo)
        Me.tab_jubilados.Controls.Add(Me.txt_jub_importe)
        Me.tab_jubilados.Controls.Add(Me.txt_jub_nombre)
        Me.tab_jubilados.Controls.Add(Me.txt_jub_numtra)
        Me.tab_jubilados.Controls.Add(Me.bot_jub_buscar)
        Me.tab_jubilados.Controls.Add(Me.bot_jub_eliminar)
        Me.tab_jubilados.Controls.Add(Me.bot_jub_guardar)
        Me.tab_jubilados.Controls.Add(Me.dgv_jubilados)
        Me.tab_jubilados.Location = New System.Drawing.Point(4, 22)
        Me.tab_jubilados.Name = "tab_jubilados"
        Me.tab_jubilados.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_jubilados.Size = New System.Drawing.Size(721, 409)
        Me.tab_jubilados.TabIndex = 4
        Me.tab_jubilados.Text = "Jubilados"
        '
        'lbl_jub_total
        '
        Me.lbl_jub_total.AutoSize = True
        Me.lbl_jub_total.Location = New System.Drawing.Point(590, 334)
        Me.lbl_jub_total.Name = "lbl_jub_total"
        Me.lbl_jub_total.Size = New System.Drawing.Size(31, 13)
        Me.lbl_jub_total.TabIndex = 31
        Me.lbl_jub_total.Text = "Total"
        '
        'txt_jub_total
        '
        Me.txt_jub_total.Location = New System.Drawing.Point(593, 351)
        Me.txt_jub_total.Name = "txt_jub_total"
        Me.txt_jub_total.Size = New System.Drawing.Size(100, 20)
        Me.txt_jub_total.TabIndex = 30
        '
        'lbl_jub_tipo
        '
        Me.lbl_jub_tipo.AutoSize = True
        Me.lbl_jub_tipo.Location = New System.Drawing.Point(478, 21)
        Me.lbl_jub_tipo.Name = "lbl_jub_tipo"
        Me.lbl_jub_tipo.Size = New System.Drawing.Size(28, 13)
        Me.lbl_jub_tipo.TabIndex = 29
        Me.lbl_jub_tipo.Text = "Tipo"
        '
        'lbl_jub_importe
        '
        Me.lbl_jub_importe.AutoSize = True
        Me.lbl_jub_importe.Location = New System.Drawing.Point(372, 21)
        Me.lbl_jub_importe.Name = "lbl_jub_importe"
        Me.lbl_jub_importe.Size = New System.Drawing.Size(42, 13)
        Me.lbl_jub_importe.TabIndex = 28
        Me.lbl_jub_importe.Text = "Importe"
        '
        'lbl_jub_nombre
        '
        Me.lbl_jub_nombre.AutoSize = True
        Me.lbl_jub_nombre.Location = New System.Drawing.Point(103, 21)
        Me.lbl_jub_nombre.Name = "lbl_jub_nombre"
        Me.lbl_jub_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_jub_nombre.TabIndex = 27
        Me.lbl_jub_nombre.Text = "Nombre"
        '
        'lbl_jub_numtra
        '
        Me.lbl_jub_numtra.AutoSize = True
        Me.lbl_jub_numtra.Location = New System.Drawing.Point(37, 21)
        Me.lbl_jub_numtra.Name = "lbl_jub_numtra"
        Me.lbl_jub_numtra.Size = New System.Drawing.Size(41, 13)
        Me.lbl_jub_numtra.TabIndex = 26
        Me.lbl_jub_numtra.Text = "Numtra"
        '
        'cmb_jub_tipo
        '
        Me.cmb_jub_tipo.FormattingEnabled = True
        Me.cmb_jub_tipo.Items.AddRange(New Object() {"Quincenal", "Mensual"})
        Me.cmb_jub_tipo.Location = New System.Drawing.Point(481, 38)
        Me.cmb_jub_tipo.Name = "cmb_jub_tipo"
        Me.cmb_jub_tipo.Size = New System.Drawing.Size(87, 21)
        Me.cmb_jub_tipo.TabIndex = 25
        '
        'txt_jub_importe
        '
        Me.txt_jub_importe.Location = New System.Drawing.Point(375, 38)
        Me.txt_jub_importe.Name = "txt_jub_importe"
        Me.txt_jub_importe.Size = New System.Drawing.Size(100, 20)
        Me.txt_jub_importe.TabIndex = 24
        '
        'txt_jub_nombre
        '
        Me.txt_jub_nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_jub_nombre.Location = New System.Drawing.Point(106, 38)
        Me.txt_jub_nombre.Name = "txt_jub_nombre"
        Me.txt_jub_nombre.Size = New System.Drawing.Size(263, 20)
        Me.txt_jub_nombre.TabIndex = 23
        '
        'txt_jub_numtra
        '
        Me.txt_jub_numtra.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_jub_numtra.Location = New System.Drawing.Point(40, 38)
        Me.txt_jub_numtra.Name = "txt_jub_numtra"
        Me.txt_jub_numtra.Size = New System.Drawing.Size(60, 20)
        Me.txt_jub_numtra.TabIndex = 22
        '
        'bot_jub_buscar
        '
        Me.bot_jub_buscar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_jub_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_jub_buscar.Location = New System.Drawing.Point(603, 96)
        Me.bot_jub_buscar.Name = "bot_jub_buscar"
        Me.bot_jub_buscar.Size = New System.Drawing.Size(75, 23)
        Me.bot_jub_buscar.TabIndex = 21
        Me.bot_jub_buscar.Text = "Buscar"
        Me.bot_jub_buscar.UseVisualStyleBackColor = False
        '
        'bot_jub_eliminar
        '
        Me.bot_jub_eliminar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_jub_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_jub_eliminar.Location = New System.Drawing.Point(603, 67)
        Me.bot_jub_eliminar.Name = "bot_jub_eliminar"
        Me.bot_jub_eliminar.Size = New System.Drawing.Size(75, 23)
        Me.bot_jub_eliminar.TabIndex = 20
        Me.bot_jub_eliminar.Text = "Eliminar"
        Me.bot_jub_eliminar.UseVisualStyleBackColor = False
        '
        'bot_jub_guardar
        '
        Me.bot_jub_guardar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_jub_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_jub_guardar.Location = New System.Drawing.Point(603, 35)
        Me.bot_jub_guardar.Name = "bot_jub_guardar"
        Me.bot_jub_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_jub_guardar.TabIndex = 19
        Me.bot_jub_guardar.Text = "Guardar"
        Me.bot_jub_guardar.UseVisualStyleBackColor = False
        '
        'dgv_jubilados
        '
        Me.dgv_jubilados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_jubilados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jub_numtra, Me.jun_nombre, Me.importe, Me.jub_quin, Me.jub_mes})
        Me.dgv_jubilados.Location = New System.Drawing.Point(40, 78)
        Me.dgv_jubilados.Name = "dgv_jubilados"
        Me.dgv_jubilados.Size = New System.Drawing.Size(528, 293)
        Me.dgv_jubilados.TabIndex = 0
        '
        'jub_numtra
        '
        Me.jub_numtra.HeaderText = "Numtra"
        Me.jub_numtra.Name = "jub_numtra"
        Me.jub_numtra.Width = 50
        '
        'jun_nombre
        '
        Me.jun_nombre.HeaderText = "Nombre"
        Me.jun_nombre.Name = "jun_nombre"
        Me.jun_nombre.Width = 250
        '
        'importe
        '
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        Me.importe.Width = 60
        '
        'jub_quin
        '
        Me.jub_quin.HeaderText = "Quincenal"
        Me.jub_quin.Name = "jub_quin"
        Me.jub_quin.Width = 60
        '
        'jub_mes
        '
        Me.jub_mes.HeaderText = "Mensual"
        Me.jub_mes.Name = "jub_mes"
        Me.jub_mes.Width = 50
        '
        'tab_becarios
        '
        Me.tab_becarios.BackColor = System.Drawing.Color.LightGray
        Me.tab_becarios.Controls.Add(Me.txt_bec_sdi)
        Me.tab_becarios.Controls.Add(Me.lbl_bec_estado)
        Me.tab_becarios.Controls.Add(Me.lbl_bec_total)
        Me.tab_becarios.Controls.Add(Me.txt_bec_total)
        Me.tab_becarios.Controls.Add(Me.lbl_bec_importe)
        Me.tab_becarios.Controls.Add(Me.lbl_bec_nombre)
        Me.tab_becarios.Controls.Add(Me.lbl_bec_numtra)
        Me.tab_becarios.Controls.Add(Me.txt_bec_importe)
        Me.tab_becarios.Controls.Add(Me.txt_bec_nombre)
        Me.tab_becarios.Controls.Add(Me.txt_bec_numtra)
        Me.tab_becarios.Controls.Add(Me.bot_bec_buscar)
        Me.tab_becarios.Controls.Add(Me.bot_bec_eliminar)
        Me.tab_becarios.Controls.Add(Me.bot_bec_guardar)
        Me.tab_becarios.Controls.Add(Me.dgv_becarios)
        Me.tab_becarios.Location = New System.Drawing.Point(4, 22)
        Me.tab_becarios.Name = "tab_becarios"
        Me.tab_becarios.Size = New System.Drawing.Size(721, 409)
        Me.tab_becarios.TabIndex = 5
        Me.tab_becarios.Text = "Becarios"
        '
        'txt_bec_sdi
        '
        Me.txt_bec_sdi.Location = New System.Drawing.Point(481, 38)
        Me.txt_bec_sdi.Name = "txt_bec_sdi"
        Me.txt_bec_sdi.Size = New System.Drawing.Size(87, 20)
        Me.txt_bec_sdi.TabIndex = 46
        '
        'lbl_bec_estado
        '
        Me.lbl_bec_estado.AutoSize = True
        Me.lbl_bec_estado.Location = New System.Drawing.Point(478, 20)
        Me.lbl_bec_estado.Name = "lbl_bec_estado"
        Me.lbl_bec_estado.Size = New System.Drawing.Size(25, 13)
        Me.lbl_bec_estado.TabIndex = 45
        Me.lbl_bec_estado.Text = "SDI"
        '
        'lbl_bec_total
        '
        Me.lbl_bec_total.AutoSize = True
        Me.lbl_bec_total.Location = New System.Drawing.Point(590, 334)
        Me.lbl_bec_total.Name = "lbl_bec_total"
        Me.lbl_bec_total.Size = New System.Drawing.Size(31, 13)
        Me.lbl_bec_total.TabIndex = 43
        Me.lbl_bec_total.Text = "Total"
        '
        'txt_bec_total
        '
        Me.txt_bec_total.Location = New System.Drawing.Point(593, 351)
        Me.txt_bec_total.Name = "txt_bec_total"
        Me.txt_bec_total.Size = New System.Drawing.Size(100, 20)
        Me.txt_bec_total.TabIndex = 42
        '
        'lbl_bec_importe
        '
        Me.lbl_bec_importe.AutoSize = True
        Me.lbl_bec_importe.Location = New System.Drawing.Point(372, 21)
        Me.lbl_bec_importe.Name = "lbl_bec_importe"
        Me.lbl_bec_importe.Size = New System.Drawing.Size(42, 13)
        Me.lbl_bec_importe.TabIndex = 41
        Me.lbl_bec_importe.Text = "Importe"
        '
        'lbl_bec_nombre
        '
        Me.lbl_bec_nombre.AutoSize = True
        Me.lbl_bec_nombre.Location = New System.Drawing.Point(103, 21)
        Me.lbl_bec_nombre.Name = "lbl_bec_nombre"
        Me.lbl_bec_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_bec_nombre.TabIndex = 40
        Me.lbl_bec_nombre.Text = "Nombre"
        '
        'lbl_bec_numtra
        '
        Me.lbl_bec_numtra.AutoSize = True
        Me.lbl_bec_numtra.Location = New System.Drawing.Point(37, 21)
        Me.lbl_bec_numtra.Name = "lbl_bec_numtra"
        Me.lbl_bec_numtra.Size = New System.Drawing.Size(41, 13)
        Me.lbl_bec_numtra.TabIndex = 39
        Me.lbl_bec_numtra.Text = "Numtra"
        '
        'txt_bec_importe
        '
        Me.txt_bec_importe.Location = New System.Drawing.Point(375, 38)
        Me.txt_bec_importe.Name = "txt_bec_importe"
        Me.txt_bec_importe.Size = New System.Drawing.Size(100, 20)
        Me.txt_bec_importe.TabIndex = 38
        '
        'txt_bec_nombre
        '
        Me.txt_bec_nombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_bec_nombre.Location = New System.Drawing.Point(106, 38)
        Me.txt_bec_nombre.Name = "txt_bec_nombre"
        Me.txt_bec_nombre.Size = New System.Drawing.Size(263, 20)
        Me.txt_bec_nombre.TabIndex = 37
        '
        'txt_bec_numtra
        '
        Me.txt_bec_numtra.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_bec_numtra.Location = New System.Drawing.Point(40, 38)
        Me.txt_bec_numtra.Name = "txt_bec_numtra"
        Me.txt_bec_numtra.Size = New System.Drawing.Size(60, 20)
        Me.txt_bec_numtra.TabIndex = 36
        '
        'bot_bec_buscar
        '
        Me.bot_bec_buscar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_bec_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_bec_buscar.Location = New System.Drawing.Point(603, 96)
        Me.bot_bec_buscar.Name = "bot_bec_buscar"
        Me.bot_bec_buscar.Size = New System.Drawing.Size(75, 23)
        Me.bot_bec_buscar.TabIndex = 35
        Me.bot_bec_buscar.Text = "Buscar"
        Me.bot_bec_buscar.UseVisualStyleBackColor = False
        '
        'bot_bec_eliminar
        '
        Me.bot_bec_eliminar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_bec_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_bec_eliminar.Location = New System.Drawing.Point(603, 67)
        Me.bot_bec_eliminar.Name = "bot_bec_eliminar"
        Me.bot_bec_eliminar.Size = New System.Drawing.Size(75, 23)
        Me.bot_bec_eliminar.TabIndex = 34
        Me.bot_bec_eliminar.Text = "Eliminar"
        Me.bot_bec_eliminar.UseVisualStyleBackColor = False
        '
        'bot_bec_guardar
        '
        Me.bot_bec_guardar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_bec_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_bec_guardar.Location = New System.Drawing.Point(603, 35)
        Me.bot_bec_guardar.Name = "bot_bec_guardar"
        Me.bot_bec_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_bec_guardar.TabIndex = 33
        Me.bot_bec_guardar.Text = "Guardar"
        Me.bot_bec_guardar.UseVisualStyleBackColor = False
        '
        'dgv_becarios
        '
        Me.dgv_becarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_becarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.dias, Me.sdi})
        Me.dgv_becarios.Location = New System.Drawing.Point(40, 78)
        Me.dgv_becarios.Name = "dgv_becarios"
        Me.dgv_becarios.Size = New System.Drawing.Size(528, 293)
        Me.dgv_becarios.TabIndex = 32
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Numtra"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Salario"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'dias
        '
        Me.dias.HeaderText = "Dias"
        Me.dias.Name = "dias"
        Me.dias.Width = 50
        '
        'sdi
        '
        Me.sdi.HeaderText = "SDI"
        Me.sdi.Name = "sdi"
        Me.sdi.Width = 60
        '
        'tab_categorias
        '
        Me.tab_categorias.BackColor = System.Drawing.Color.LightGray
        Me.tab_categorias.Controls.Add(Me.lbl_cat_laboro)
        Me.tab_categorias.Controls.Add(Me.txt_cat_laboro)
        Me.tab_categorias.Controls.Add(Me.lbl_cat_tponom)
        Me.tab_categorias.Controls.Add(Me.cmb_cat_tponom)
        Me.tab_categorias.Controls.Add(Me.dgv_categorias)
        Me.tab_categorias.Controls.Add(Me.lbl_cat_comrep)
        Me.tab_categorias.Controls.Add(Me.lbl_cat_comzaf)
        Me.tab_categorias.Controls.Add(Me.lbl_cat_altura)
        Me.tab_categorias.Controls.Add(Me.lbl_cat_sueldo)
        Me.tab_categorias.Controls.Add(Me.lbl_cat_nombre)
        Me.tab_categorias.Controls.Add(Me.lbl_cat_catego)
        Me.tab_categorias.Controls.Add(Me.chk_cat_alimento)
        Me.tab_categorias.Controls.Add(Me.txt_cat_comrep)
        Me.tab_categorias.Controls.Add(Me.txt_cat_comzaf)
        Me.tab_categorias.Controls.Add(Me.txt_cat_altura)
        Me.tab_categorias.Controls.Add(Me.txt_cat_sueldo)
        Me.tab_categorias.Controls.Add(Me.txt_cat_nombre)
        Me.tab_categorias.Controls.Add(Me.txt_cat_catego)
        Me.tab_categorias.Controls.Add(Me.bot_cat_buscar)
        Me.tab_categorias.Controls.Add(Me.bot_cat_guardar)
        Me.tab_categorias.Location = New System.Drawing.Point(4, 22)
        Me.tab_categorias.Name = "tab_categorias"
        Me.tab_categorias.Size = New System.Drawing.Size(721, 409)
        Me.tab_categorias.TabIndex = 6
        Me.tab_categorias.Text = "Categorias"
        '
        'lbl_cat_laboro
        '
        Me.lbl_cat_laboro.AutoSize = True
        Me.lbl_cat_laboro.Location = New System.Drawing.Point(251, 87)
        Me.lbl_cat_laboro.Name = "lbl_cat_laboro"
        Me.lbl_cat_laboro.Size = New System.Drawing.Size(40, 13)
        Me.lbl_cat_laboro.TabIndex = 55
        Me.lbl_cat_laboro.Text = "Laboro"
        '
        'txt_cat_laboro
        '
        Me.txt_cat_laboro.Location = New System.Drawing.Point(254, 103)
        Me.txt_cat_laboro.Name = "txt_cat_laboro"
        Me.txt_cat_laboro.Size = New System.Drawing.Size(64, 20)
        Me.txt_cat_laboro.TabIndex = 54
        '
        'lbl_cat_tponom
        '
        Me.lbl_cat_tponom.AutoSize = True
        Me.lbl_cat_tponom.Location = New System.Drawing.Point(34, 35)
        Me.lbl_cat_tponom.Name = "lbl_cat_tponom"
        Me.lbl_cat_tponom.Size = New System.Drawing.Size(46, 13)
        Me.lbl_cat_tponom.TabIndex = 53
        Me.lbl_cat_tponom.Text = "Tponom"
        '
        'cmb_cat_tponom
        '
        Me.cmb_cat_tponom.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmb_cat_tponom.FormattingEnabled = True
        Me.cmb_cat_tponom.Items.AddRange(New Object() {"1 - Sindicalizado", "2 - Confianza"})
        Me.cmb_cat_tponom.Location = New System.Drawing.Point(37, 51)
        Me.cmb_cat_tponom.Name = "cmb_cat_tponom"
        Me.cmb_cat_tponom.Size = New System.Drawing.Size(67, 21)
        Me.cmb_cat_tponom.TabIndex = 52
        '
        'dgv_categorias
        '
        Me.dgv_categorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_categorias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.catego, Me.DataGridViewTextBoxColumn5, Me.turno, Me.Sueldo, Me.Altura, Me.hrstur, Me.alimento, Me.comzaf, Me.comrep})
        Me.dgv_categorias.Location = New System.Drawing.Point(37, 152)
        Me.dgv_categorias.Name = "dgv_categorias"
        Me.dgv_categorias.Size = New System.Drawing.Size(644, 222)
        Me.dgv_categorias.TabIndex = 51
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Tponom"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 40
        '
        'catego
        '
        Me.catego.HeaderText = "Catego"
        Me.catego.Name = "catego"
        Me.catego.Width = 40
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'turno
        '
        Me.turno.HeaderText = "Turno"
        Me.turno.Name = "turno"
        Me.turno.Width = 40
        '
        'Sueldo
        '
        Me.Sueldo.HeaderText = "Sueldo"
        Me.Sueldo.Name = "Sueldo"
        Me.Sueldo.Width = 50
        '
        'Altura
        '
        Me.Altura.HeaderText = "Altura"
        Me.Altura.Name = "Altura"
        Me.Altura.Width = 50
        '
        'hrstur
        '
        Me.hrstur.HeaderText = "hrstur"
        Me.hrstur.Name = "hrstur"
        Me.hrstur.Width = 50
        '
        'alimento
        '
        Me.alimento.HeaderText = "Alimento"
        Me.alimento.Name = "alimento"
        Me.alimento.Width = 50
        '
        'comzaf
        '
        Me.comzaf.HeaderText = "ComZaf"
        Me.comzaf.Name = "comzaf"
        Me.comzaf.Width = 50
        '
        'comrep
        '
        Me.comrep.HeaderText = "ComRep"
        Me.comrep.Name = "comrep"
        Me.comrep.Width = 50
        '
        'lbl_cat_comrep
        '
        Me.lbl_cat_comrep.AutoSize = True
        Me.lbl_cat_comrep.Location = New System.Drawing.Point(184, 87)
        Me.lbl_cat_comrep.Name = "lbl_cat_comrep"
        Me.lbl_cat_comrep.Size = New System.Drawing.Size(60, 13)
        Me.lbl_cat_comrep.TabIndex = 50
        Me.lbl_cat_comrep.Text = "Comp. Rep"
        '
        'lbl_cat_comzaf
        '
        Me.lbl_cat_comzaf.AutoSize = True
        Me.lbl_cat_comzaf.Location = New System.Drawing.Point(109, 88)
        Me.lbl_cat_comzaf.Name = "lbl_cat_comzaf"
        Me.lbl_cat_comzaf.Size = New System.Drawing.Size(56, 13)
        Me.lbl_cat_comzaf.TabIndex = 49
        Me.lbl_cat_comzaf.Text = "Comp. Zaf"
        '
        'lbl_cat_altura
        '
        Me.lbl_cat_altura.AutoSize = True
        Me.lbl_cat_altura.Location = New System.Drawing.Point(36, 88)
        Me.lbl_cat_altura.Name = "lbl_cat_altura"
        Me.lbl_cat_altura.Size = New System.Drawing.Size(34, 13)
        Me.lbl_cat_altura.TabIndex = 48
        Me.lbl_cat_altura.Text = "Altura"
        '
        'lbl_cat_sueldo
        '
        Me.lbl_cat_sueldo.AutoSize = True
        Me.lbl_cat_sueldo.Location = New System.Drawing.Point(357, 35)
        Me.lbl_cat_sueldo.Name = "lbl_cat_sueldo"
        Me.lbl_cat_sueldo.Size = New System.Drawing.Size(40, 13)
        Me.lbl_cat_sueldo.TabIndex = 47
        Me.lbl_cat_sueldo.Text = "Sueldo"
        '
        'lbl_cat_nombre
        '
        Me.lbl_cat_nombre.AutoSize = True
        Me.lbl_cat_nombre.Location = New System.Drawing.Point(181, 35)
        Me.lbl_cat_nombre.Name = "lbl_cat_nombre"
        Me.lbl_cat_nombre.Size = New System.Drawing.Size(44, 13)
        Me.lbl_cat_nombre.TabIndex = 46
        Me.lbl_cat_nombre.Text = "Nombre"
        '
        'lbl_cat_catego
        '
        Me.lbl_cat_catego.AutoSize = True
        Me.lbl_cat_catego.Location = New System.Drawing.Point(107, 35)
        Me.lbl_cat_catego.Name = "lbl_cat_catego"
        Me.lbl_cat_catego.Size = New System.Drawing.Size(52, 13)
        Me.lbl_cat_catego.TabIndex = 45
        Me.lbl_cat_catego.Text = "Categoria"
        '
        'chk_cat_alimento
        '
        Me.chk_cat_alimento.AutoSize = True
        Me.chk_cat_alimento.Location = New System.Drawing.Point(332, 105)
        Me.chk_cat_alimento.Name = "chk_cat_alimento"
        Me.chk_cat_alimento.Size = New System.Drawing.Size(121, 17)
        Me.chk_cat_alimento.TabIndex = 44
        Me.chk_cat_alimento.Text = "Media hora alimento"
        Me.chk_cat_alimento.UseVisualStyleBackColor = True
        '
        'txt_cat_comrep
        '
        Me.txt_cat_comrep.Location = New System.Drawing.Point(184, 103)
        Me.txt_cat_comrep.Name = "txt_cat_comrep"
        Me.txt_cat_comrep.Size = New System.Drawing.Size(64, 20)
        Me.txt_cat_comrep.TabIndex = 43
        '
        'txt_cat_comzaf
        '
        Me.txt_cat_comzaf.Location = New System.Drawing.Point(110, 104)
        Me.txt_cat_comzaf.Name = "txt_cat_comzaf"
        Me.txt_cat_comzaf.Size = New System.Drawing.Size(68, 20)
        Me.txt_cat_comzaf.TabIndex = 42
        '
        'txt_cat_altura
        '
        Me.txt_cat_altura.Location = New System.Drawing.Point(37, 104)
        Me.txt_cat_altura.Name = "txt_cat_altura"
        Me.txt_cat_altura.Size = New System.Drawing.Size(67, 20)
        Me.txt_cat_altura.TabIndex = 41
        '
        'txt_cat_sueldo
        '
        Me.txt_cat_sueldo.Location = New System.Drawing.Point(360, 51)
        Me.txt_cat_sueldo.Name = "txt_cat_sueldo"
        Me.txt_cat_sueldo.Size = New System.Drawing.Size(93, 20)
        Me.txt_cat_sueldo.TabIndex = 40
        '
        'txt_cat_nombre
        '
        Me.txt_cat_nombre.Location = New System.Drawing.Point(184, 51)
        Me.txt_cat_nombre.Name = "txt_cat_nombre"
        Me.txt_cat_nombre.Size = New System.Drawing.Size(170, 20)
        Me.txt_cat_nombre.TabIndex = 39
        '
        'txt_cat_catego
        '
        Me.txt_cat_catego.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_cat_catego.Location = New System.Drawing.Point(110, 51)
        Me.txt_cat_catego.Name = "txt_cat_catego"
        Me.txt_cat_catego.Size = New System.Drawing.Size(68, 20)
        Me.txt_cat_catego.TabIndex = 38
        '
        'bot_cat_buscar
        '
        Me.bot_cat_buscar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_cat_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_cat_buscar.Location = New System.Drawing.Point(606, 89)
        Me.bot_cat_buscar.Name = "bot_cat_buscar"
        Me.bot_cat_buscar.Size = New System.Drawing.Size(75, 23)
        Me.bot_cat_buscar.TabIndex = 37
        Me.bot_cat_buscar.Text = "Buscar"
        Me.bot_cat_buscar.UseVisualStyleBackColor = False
        '
        'bot_cat_guardar
        '
        Me.bot_cat_guardar.BackColor = System.Drawing.SystemColors.Control
        Me.bot_cat_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_cat_guardar.Location = New System.Drawing.Point(606, 51)
        Me.bot_cat_guardar.Name = "bot_cat_guardar"
        Me.bot_cat_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_cat_guardar.TabIndex = 36
        Me.bot_cat_guardar.Text = "Guardar"
        Me.bot_cat_guardar.UseVisualStyleBackColor = False
        '
        'men_maestros
        '
        Me.men_maestros.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.men_maestros.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.men_maestros.Location = New System.Drawing.Point(0, 0)
        Me.men_maestros.Name = "men_maestros"
        Me.men_maestros.Size = New System.Drawing.Size(800, 24)
        Me.men_maestros.TabIndex = 7
        Me.men_maestros.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.MantenimientoABaseDeDatosToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "&Procesos"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(237, 6)
        '
        'MantenimientoABaseDeDatosToolStripMenuItem
        '
        Me.MantenimientoABaseDeDatosToolStripMenuItem.Name = "MantenimientoABaseDeDatosToolStripMenuItem"
        Me.MantenimientoABaseDeDatosToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MantenimientoABaseDeDatosToolStripMenuItem.Text = "Mantenimiento a Base de datos"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator5, Me.ToolStripSeparator4, Me.Nom105ListadoTrabajadoresToolStripMenuItem, Me.Nom102CategoriasToolStripMenuItem, Me.ReporteDeCorreosToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(222, 6)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(222, 6)
        '
        'Nom105ListadoTrabajadoresToolStripMenuItem
        '
        Me.Nom105ListadoTrabajadoresToolStripMenuItem.Name = "Nom105ListadoTrabajadoresToolStripMenuItem"
        Me.Nom105ListadoTrabajadoresToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.Nom105ListadoTrabajadoresToolStripMenuItem.Text = "Nom105 listado trabajadores"
        '
        'Nom102CategoriasToolStripMenuItem
        '
        Me.Nom102CategoriasToolStripMenuItem.Name = "Nom102CategoriasToolStripMenuItem"
        Me.Nom102CategoriasToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.Nom102CategoriasToolStripMenuItem.Text = "Nom102 Categorias"
        '
        'ReporteDeCorreosToolStripMenuItem
        '
        Me.ReporteDeCorreosToolStripMenuItem.Name = "ReporteDeCorreosToolStripMenuItem"
        Me.ReporteDeCorreosToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ReporteDeCorreosToolStripMenuItem.Text = "Reporte de correos"
        '
        'maestros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 514)
        Me.Controls.Add(Me.men_maestros)
        Me.Controls.Add(Me.tab_catalogos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "maestros"
        Me.Text = "Catalogos Maestros"
        Me.tab_catalogos.ResumeLayout(False)
        Me.tab_fisica.ResumeLayout(False)
        Me.tab_fisica.PerformLayout()
        CType(Me.dgv_fisicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_relacion.ResumeLayout(False)
        Me.tab_relacion.PerformLayout()
        CType(Me.dgv_relaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_pensiones.ResumeLayout(False)
        Me.tab_pensiones.PerformLayout()
        CType(Me.dgv_pensiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_trabajadores.ResumeLayout(False)
        Me.tab_trabajadores.PerformLayout()
        Me.tab_jubilados.ResumeLayout(False)
        Me.tab_jubilados.PerformLayout()
        CType(Me.dgv_jubilados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_becarios.ResumeLayout(False)
        Me.tab_becarios.PerformLayout()
        CType(Me.dgv_becarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_categorias.ResumeLayout(False)
        Me.tab_categorias.PerformLayout()
        CType(Me.dgv_categorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.men_maestros.ResumeLayout(False)
        Me.men_maestros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tab_catalogos As System.Windows.Forms.TabControl
    Friend WithEvents tab_fisica As System.Windows.Forms.TabPage
    Friend WithEvents tab_relacion As System.Windows.Forms.TabPage
    Friend WithEvents bot_fis_guarda As System.Windows.Forms.Button
    Friend WithEvents cmb_edocivil As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_sexo As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_fisicas As System.Windows.Forms.DataGridView
    Friend WithEvents txt_imss As System.Windows.Forms.TextBox
    Friend WithEvents txt_curp As System.Windows.Forms.TextBox
    Friend WithEvents txt_rfc As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_materno As System.Windows.Forms.TextBox
    Friend WithEvents txt_paterno As System.Windows.Forms.TextBox
    Friend WithEvents bot_fis_buscar As System.Windows.Forms.Button
    Friend WithEvents bot_fis_eliminar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mtb_fec_nac As System.Windows.Forms.MaskedTextBox
    Friend WithEvents men_maestros As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents iden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rfc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tab_pensiones As System.Windows.Forms.TabPage
    Friend WithEvents lbl_bene_nom As System.Windows.Forms.Label
    Friend WithEvents lbl_bene As System.Windows.Forms.Label
    Friend WithEvents txt_nom_bene As System.Windows.Forms.TextBox
    Friend WithEvents mtb_bene As System.Windows.Forms.MaskedTextBox
    Friend WithEvents bot_pen_buscar As System.Windows.Forms.Button
    Friend WithEvents bot_pen_eliminar As System.Windows.Forms.Button
    Friend WithEvents bot_pen_guardar As System.Windows.Forms.Button
    Friend WithEvents dgv_pensiones As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_importe As System.Windows.Forms.Label
    Friend WithEvents lbl_aplica As System.Windows.Forms.Label
    Friend WithEvents lbl_indicador As System.Windows.Forms.Label
    Friend WithEvents lbl_conse As System.Windows.Forms.Label
    Friend WithEvents lbl_pen_nom As System.Windows.Forms.Label
    Friend WithEvents lbl_pen_numtra As System.Windows.Forms.Label
    Friend WithEvents lbl_pen_tponom As System.Windows.Forms.Label
    Friend WithEvents mtb_importe As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_pen_numtra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmb_aplica As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_pen_indica As System.Windows.Forms.ComboBox
    Friend WithEvents txt_pen_nom As System.Windows.Forms.TextBox
    Friend WithEvents cmb_pen_tponom As System.Windows.Forms.ComboBox
    Friend WithEvents tponom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numtra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nom_pen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Benef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_nom_repre As System.Windows.Forms.TextBox
    Friend WithEvents txt_rel_nom As System.Windows.Forms.TextBox
    Friend WithEvents bot_rel_bus As System.Windows.Forms.Button
    Friend WithEvents bot_rel_elim As System.Windows.Forms.Button
    Friend WithEvents bot_rel_guardar As System.Windows.Forms.Button
    Friend WithEvents dgv_relaciones As System.Windows.Forms.DataGridView
    Friend WithEvents mtb_repre As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_rel_numtra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmb_relacion As System.Windows.Forms.ComboBox
    Friend WithEvents mtb_rel_clave As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmb_tipoper As System.Windows.Forms.ComboBox
    Friend WithEvents relab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents person As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fisica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nom_relab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rfc_relab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmb_conse As System.Windows.Forms.ComboBox
    Friend WithEvents tab_trabajadores As System.Windows.Forms.TabPage
    Friend WithEvents cmb_105_sindic As System.Windows.Forms.ComboBox
    Friend WithEvents bot_105_buscar As System.Windows.Forms.Button
    Friend WithEvents bot_105_elimin As System.Windows.Forms.Button
    Friend WithEvents bot_105_guardar As System.Windows.Forms.Button
    Friend WithEvents cmb_105_plaza As System.Windows.Forms.ComboBox
    Friend WithEvents mtb_105_deprep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_105_depzaf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_105_catrep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_105_catzaf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_105_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_105_nombre As System.Windows.Forms.TextBox
    Friend WithEvents mtb_105_numtra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmb_105_tponom As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbl_clave_fisica As System.Windows.Forms.Label
    Friend WithEvents txt_fisica As System.Windows.Forms.TextBox
    Friend WithEvents Nom105ListadoTrabajadoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtp_105_jubpen As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_105_jubpen As System.Windows.Forms.Label
    Friend WithEvents dtp_105_baja As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_105_baja As System.Windows.Forms.Label
    Friend WithEvents dtp_105_alta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_105_alta As System.Windows.Forms.Label
    Friend WithEvents dtp_105_perma As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_105_permanente As System.Windows.Forms.Label
    Friend WithEvents dtp_105_tempo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_105_temporal As System.Windows.Forms.Label
    Friend WithEvents dtp_105_ingreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_105_ingreso As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents mtb_105_escala As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_105_sdi As System.Windows.Forms.TextBox
    Friend WithEvents lbl_105_sdi As System.Windows.Forms.Label
    Friend WithEvents tab_jubilados As TabPage
    Friend WithEvents bot_jub_buscar As Button
    Friend WithEvents bot_jub_eliminar As Button
    Friend WithEvents bot_jub_guardar As Button
    Friend WithEvents dgv_jubilados As DataGridView
    Friend WithEvents jub_numtra As DataGridViewTextBoxColumn
    Friend WithEvents jun_nombre As DataGridViewTextBoxColumn
    Friend WithEvents importe As DataGridViewTextBoxColumn
    Friend WithEvents jub_quin As DataGridViewCheckBoxColumn
    Friend WithEvents jub_mes As DataGridViewCheckBoxColumn
    Friend WithEvents lbl_jub_tipo As Label
    Friend WithEvents lbl_jub_importe As Label
    Friend WithEvents lbl_jub_nombre As Label
    Friend WithEvents lbl_jub_numtra As Label
    Friend WithEvents cmb_jub_tipo As ComboBox
    Friend WithEvents txt_jub_importe As TextBox
    Friend WithEvents txt_jub_nombre As TextBox
    Friend WithEvents txt_jub_numtra As TextBox
    Friend WithEvents lbl_jub_total As Label
    Friend WithEvents txt_jub_total As TextBox
    Friend WithEvents tab_becarios As TabPage
    Friend WithEvents lbl_bec_total As Label
    Friend WithEvents txt_bec_total As TextBox
    Friend WithEvents lbl_bec_importe As Label
    Friend WithEvents lbl_bec_nombre As Label
    Friend WithEvents lbl_bec_numtra As Label
    Friend WithEvents txt_bec_importe As TextBox
    Friend WithEvents txt_bec_nombre As TextBox
    Friend WithEvents txt_bec_numtra As TextBox
    Friend WithEvents bot_bec_buscar As Button
    Friend WithEvents bot_bec_eliminar As Button
    Friend WithEvents bot_bec_guardar As Button
    Friend WithEvents dgv_becarios As DataGridView
    Friend WithEvents lbl_bec_estado As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents dias As DataGridViewTextBoxColumn
    Friend WithEvents sdi As DataGridViewTextBoxColumn
    Friend WithEvents txt_bec_sdi As TextBox
    Friend WithEvents Nom102CategoriasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tab_categorias As TabPage
    Friend WithEvents bot_cat_buscar As Button
    Friend WithEvents bot_cat_guardar As Button
    Friend WithEvents lbl_cat_laboro As Label
    Friend WithEvents txt_cat_laboro As TextBox
    Friend WithEvents lbl_cat_tponom As Label
    Friend WithEvents cmb_cat_tponom As ComboBox
    Friend WithEvents dgv_categorias As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents catego As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents turno As DataGridViewTextBoxColumn
    Friend WithEvents Sueldo As DataGridViewTextBoxColumn
    Friend WithEvents Altura As DataGridViewTextBoxColumn
    Friend WithEvents hrstur As DataGridViewTextBoxColumn
    Friend WithEvents alimento As DataGridViewTextBoxColumn
    Friend WithEvents comzaf As DataGridViewTextBoxColumn
    Friend WithEvents comrep As DataGridViewTextBoxColumn
    Friend WithEvents lbl_cat_comrep As Label
    Friend WithEvents lbl_cat_comzaf As Label
    Friend WithEvents lbl_cat_altura As Label
    Friend WithEvents lbl_cat_sueldo As Label
    Friend WithEvents lbl_cat_nombre As Label
    Friend WithEvents lbl_cat_catego As Label
    Friend WithEvents chk_cat_alimento As CheckBox
    Friend WithEvents txt_cat_comrep As TextBox
    Friend WithEvents txt_cat_comzaf As TextBox
    Friend WithEvents txt_cat_altura As TextBox
    Friend WithEvents txt_cat_sueldo As TextBox
    Friend WithEvents txt_cat_nombre As TextBox
    Friend WithEvents txt_cat_catego As TextBox
    Friend WithEvents MantenimientoABaseDeDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeCorreosToolStripMenuItem As ToolStripMenuItem
End Class
