<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Asistencia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Asistencia))
        Me.cd = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargaAsistenciaDeRelojToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CapturaDeAsistenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarIncapacidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalariosIMSSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeAsistenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_reloj = New System.Windows.Forms.TabPage()
        Me.bot_tab1_mostrar = New System.Windows.Forms.Button()
        Me.dgv_reloj = New System.Windows.Forms.DataGridView()
        Me.numtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.domfes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Domrep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_captura = New System.Windows.Forms.TabPage()
        Me.chk_domrep = New System.Windows.Forms.CheckBox()
        Me.txt_correo = New System.Windows.Forms.TextBox()
        Me.lbl_correo = New System.Windows.Forms.Label()
        Me.chk_domfes = New System.Windows.Forms.CheckBox()
        Me.chk_reloj = New System.Windows.Forms.CheckBox()
        Me.chk_fijo = New System.Windows.Forms.CheckBox()
        Me.txt_nom_numtra = New System.Windows.Forms.TextBox()
        Me.txt_numtra = New System.Windows.Forms.TextBox()
        Me.lbl_nomnumtra = New System.Windows.Forms.Label()
        Me.lbl_numtra = New System.Windows.Forms.Label()
        Me.bot_guardar = New System.Windows.Forms.Button()
        Me.tab_incapacidad = New System.Windows.Forms.TabPage()
        Me.txt_inc_catego = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.bot_inc_eliminar = New System.Windows.Forms.Button()
        Me.bot_inc_guardar = New System.Windows.Forms.Button()
        Me.txt_inc_dias = New System.Windows.Forms.TextBox()
        Me.lbl_inc_dias = New System.Windows.Forms.Label()
        Me.txt_inc_fecha = New System.Windows.Forms.TextBox()
        Me.lbl_inc_fecha = New System.Windows.Forms.Label()
        Me.bot_mostrar = New System.Windows.Forms.Button()
        Me.cmb_inc_estado = New System.Windows.Forms.ComboBox()
        Me.lbl_inc_estado = New System.Windows.Forms.Label()
        Me.cmb_inc_rama = New System.Windows.Forms.ComboBox()
        Me.lbl_inc_rama = New System.Windows.Forms.Label()
        Me.txt_inc_numtra = New System.Windows.Forms.TextBox()
        Me.lbl_inc_numtra = New System.Windows.Forms.Label()
        Me.dgv_incapacidades = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.catego = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_semana = New System.Windows.Forms.Label()
        Me.EnrolamientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tab_reloj.SuspendLayout()
        CType(Me.dgv_reloj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_captura.SuspendLayout()
        Me.tab_incapacidad.SuspendLayout()
        CType(Me.dgv_incapacidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cd
        '
        Me.cd.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(598, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargaAsistenciaDeRelojToolStripMenuItem, Me.CapturaDeAsistenciaToolStripMenuItem, Me.CargarIncapacidadesToolStripMenuItem, Me.EnrolamientoToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'CargaAsistenciaDeRelojToolStripMenuItem
        '
        Me.CargaAsistenciaDeRelojToolStripMenuItem.Name = "CargaAsistenciaDeRelojToolStripMenuItem"
        Me.CargaAsistenciaDeRelojToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.CargaAsistenciaDeRelojToolStripMenuItem.Text = "Carga asistencia de reloj"
        '
        'CapturaDeAsistenciaToolStripMenuItem
        '
        Me.CapturaDeAsistenciaToolStripMenuItem.Name = "CapturaDeAsistenciaToolStripMenuItem"
        Me.CapturaDeAsistenciaToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.CapturaDeAsistenciaToolStripMenuItem.Text = "Enviar asistencia a nomina"
        '
        'CargarIncapacidadesToolStripMenuItem
        '
        Me.CargarIncapacidadesToolStripMenuItem.Name = "CargarIncapacidadesToolStripMenuItem"
        Me.CargarIncapacidadesToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.CargarIncapacidadesToolStripMenuItem.Text = "Cargar incapacidades"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalariosIMSSToolStripMenuItem, Me.ReporteDeAsistenciaToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'SalariosIMSSToolStripMenuItem
        '
        Me.SalariosIMSSToolStripMenuItem.Name = "SalariosIMSSToolStripMenuItem"
        Me.SalariosIMSSToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SalariosIMSSToolStripMenuItem.Text = "Salarios IMSS"
        '
        'ReporteDeAsistenciaToolStripMenuItem
        '
        Me.ReporteDeAsistenciaToolStripMenuItem.Name = "ReporteDeAsistenciaToolStripMenuItem"
        Me.ReporteDeAsistenciaToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ReporteDeAsistenciaToolStripMenuItem.Text = "Reporte de asistencia"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(459, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 103)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_reloj)
        Me.TabControl1.Controls.Add(Me.tab_captura)
        Me.TabControl1.Controls.Add(Me.tab_incapacidad)
        Me.TabControl1.Location = New System.Drawing.Point(31, 122)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 465)
        Me.TabControl1.TabIndex = 8
        '
        'tab_reloj
        '
        Me.tab_reloj.Controls.Add(Me.bot_tab1_mostrar)
        Me.tab_reloj.Controls.Add(Me.dgv_reloj)
        Me.tab_reloj.Location = New System.Drawing.Point(4, 22)
        Me.tab_reloj.Name = "tab_reloj"
        Me.tab_reloj.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_reloj.Size = New System.Drawing.Size(532, 439)
        Me.tab_reloj.TabIndex = 0
        Me.tab_reloj.Text = "Catalogo de personal"
        Me.tab_reloj.UseVisualStyleBackColor = True
        '
        'bot_tab1_mostrar
        '
        Me.bot_tab1_mostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_tab1_mostrar.Location = New System.Drawing.Point(27, 399)
        Me.bot_tab1_mostrar.Name = "bot_tab1_mostrar"
        Me.bot_tab1_mostrar.Size = New System.Drawing.Size(75, 23)
        Me.bot_tab1_mostrar.TabIndex = 15
        Me.bot_tab1_mostrar.Text = "Mostrar"
        Me.bot_tab1_mostrar.UseVisualStyleBackColor = True
        '
        'dgv_reloj
        '
        Me.dgv_reloj.AllowUserToAddRows = False
        Me.dgv_reloj.AllowUserToDeleteRows = False
        Me.dgv_reloj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_reloj.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numtra, Me.nombre, Me.fijo, Me.reloj, Me.domfes, Me.Domrep})
        Me.dgv_reloj.Location = New System.Drawing.Point(27, 18)
        Me.dgv_reloj.Name = "dgv_reloj"
        Me.dgv_reloj.Size = New System.Drawing.Size(475, 365)
        Me.dgv_reloj.TabIndex = 6
        '
        'numtra
        '
        Me.numtra.HeaderText = "Numtra"
        Me.numtra.Name = "numtra"
        Me.numtra.Width = 50
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.Width = 190
        '
        'fijo
        '
        Me.fijo.HeaderText = "Fijos"
        Me.fijo.Name = "fijo"
        Me.fijo.Width = 45
        '
        'reloj
        '
        Me.reloj.HeaderText = "Reloj"
        Me.reloj.Name = "reloj"
        Me.reloj.Width = 45
        '
        'domfes
        '
        Me.domfes.HeaderText = "DomFes"
        Me.domfes.Name = "domfes"
        Me.domfes.Width = 45
        '
        'Domrep
        '
        Me.Domrep.HeaderText = "DomRep"
        Me.Domrep.Name = "Domrep"
        Me.Domrep.Width = 45
        '
        'tab_captura
        '
        Me.tab_captura.Controls.Add(Me.chk_domrep)
        Me.tab_captura.Controls.Add(Me.txt_correo)
        Me.tab_captura.Controls.Add(Me.lbl_correo)
        Me.tab_captura.Controls.Add(Me.chk_domfes)
        Me.tab_captura.Controls.Add(Me.chk_reloj)
        Me.tab_captura.Controls.Add(Me.chk_fijo)
        Me.tab_captura.Controls.Add(Me.txt_nom_numtra)
        Me.tab_captura.Controls.Add(Me.txt_numtra)
        Me.tab_captura.Controls.Add(Me.lbl_nomnumtra)
        Me.tab_captura.Controls.Add(Me.lbl_numtra)
        Me.tab_captura.Controls.Add(Me.bot_guardar)
        Me.tab_captura.Location = New System.Drawing.Point(4, 22)
        Me.tab_captura.Name = "tab_captura"
        Me.tab_captura.Size = New System.Drawing.Size(532, 439)
        Me.tab_captura.TabIndex = 1
        Me.tab_captura.Text = "Captura"
        Me.tab_captura.UseVisualStyleBackColor = True
        '
        'chk_domrep
        '
        Me.chk_domrep.AutoSize = True
        Me.chk_domrep.Location = New System.Drawing.Point(77, 270)
        Me.chk_domrep.Name = "chk_domrep"
        Me.chk_domrep.Size = New System.Drawing.Size(147, 17)
        Me.chk_domrep.TabIndex = 29
        Me.chk_domrep.Text = "Domingos reparacion fijos"
        Me.chk_domrep.UseVisualStyleBackColor = True
        '
        'txt_correo
        '
        Me.txt_correo.Location = New System.Drawing.Point(77, 164)
        Me.txt_correo.Name = "txt_correo"
        Me.txt_correo.Size = New System.Drawing.Size(375, 20)
        Me.txt_correo.TabIndex = 28
        '
        'lbl_correo
        '
        Me.lbl_correo.AutoSize = True
        Me.lbl_correo.Location = New System.Drawing.Point(75, 148)
        Me.lbl_correo.Name = "lbl_correo"
        Me.lbl_correo.Size = New System.Drawing.Size(93, 13)
        Me.lbl_correo.TabIndex = 27
        Me.lbl_correo.Text = "Correo electronico"
        '
        'chk_domfes
        '
        Me.chk_domfes.AutoSize = True
        Me.chk_domfes.Location = New System.Drawing.Point(77, 247)
        Me.chk_domfes.Name = "chk_domfes"
        Me.chk_domfes.Size = New System.Drawing.Size(162, 17)
        Me.chk_domfes.TabIndex = 26
        Me.chk_domfes.Text = "Domingos, festivos zafra fijos"
        Me.chk_domfes.UseVisualStyleBackColor = True
        '
        'chk_reloj
        '
        Me.chk_reloj.AutoSize = True
        Me.chk_reloj.Location = New System.Drawing.Point(77, 224)
        Me.chk_reloj.Name = "chk_reloj"
        Me.chk_reloj.Size = New System.Drawing.Size(144, 17)
        Me.chk_reloj.TabIndex = 25
        Me.chk_reloj.Text = "Asistencia reloj checador"
        Me.chk_reloj.UseVisualStyleBackColor = True
        '
        'chk_fijo
        '
        Me.chk_fijo.AutoSize = True
        Me.chk_fijo.Location = New System.Drawing.Point(77, 201)
        Me.chk_fijo.Name = "chk_fijo"
        Me.chk_fijo.Size = New System.Drawing.Size(147, 17)
        Me.chk_fijo.TabIndex = 24
        Me.chk_fijo.Text = "Asistencia fija (Gerencias)"
        Me.chk_fijo.UseVisualStyleBackColor = True
        '
        'txt_nom_numtra
        '
        Me.txt_nom_numtra.Enabled = False
        Me.txt_nom_numtra.Location = New System.Drawing.Point(77, 115)
        Me.txt_nom_numtra.Name = "txt_nom_numtra"
        Me.txt_nom_numtra.Size = New System.Drawing.Size(375, 20)
        Me.txt_nom_numtra.TabIndex = 23
        '
        'txt_numtra
        '
        Me.txt_numtra.Location = New System.Drawing.Point(77, 65)
        Me.txt_numtra.Name = "txt_numtra"
        Me.txt_numtra.Size = New System.Drawing.Size(119, 20)
        Me.txt_numtra.TabIndex = 22
        '
        'lbl_nomnumtra
        '
        Me.lbl_nomnumtra.AutoSize = True
        Me.lbl_nomnumtra.Location = New System.Drawing.Point(75, 99)
        Me.lbl_nomnumtra.Name = "lbl_nomnumtra"
        Me.lbl_nomnumtra.Size = New System.Drawing.Size(111, 13)
        Me.lbl_nomnumtra.TabIndex = 21
        Me.lbl_nomnumtra.Text = "Nombre del trabajador"
        '
        'lbl_numtra
        '
        Me.lbl_numtra.AutoSize = True
        Me.lbl_numtra.Location = New System.Drawing.Point(75, 49)
        Me.lbl_numtra.Name = "lbl_numtra"
        Me.lbl_numtra.Size = New System.Drawing.Size(109, 13)
        Me.lbl_numtra.TabIndex = 20
        Me.lbl_numtra.Text = "Numero de trabajador"
        '
        'bot_guardar
        '
        Me.bot_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_guardar.Location = New System.Drawing.Point(77, 303)
        Me.bot_guardar.Name = "bot_guardar"
        Me.bot_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_guardar.TabIndex = 19
        Me.bot_guardar.Text = "Guardar"
        Me.bot_guardar.UseVisualStyleBackColor = True
        '
        'tab_incapacidad
        '
        Me.tab_incapacidad.Controls.Add(Me.txt_inc_catego)
        Me.tab_incapacidad.Controls.Add(Me.lbl)
        Me.tab_incapacidad.Controls.Add(Me.bot_inc_eliminar)
        Me.tab_incapacidad.Controls.Add(Me.bot_inc_guardar)
        Me.tab_incapacidad.Controls.Add(Me.txt_inc_dias)
        Me.tab_incapacidad.Controls.Add(Me.lbl_inc_dias)
        Me.tab_incapacidad.Controls.Add(Me.txt_inc_fecha)
        Me.tab_incapacidad.Controls.Add(Me.lbl_inc_fecha)
        Me.tab_incapacidad.Controls.Add(Me.bot_mostrar)
        Me.tab_incapacidad.Controls.Add(Me.cmb_inc_estado)
        Me.tab_incapacidad.Controls.Add(Me.lbl_inc_estado)
        Me.tab_incapacidad.Controls.Add(Me.cmb_inc_rama)
        Me.tab_incapacidad.Controls.Add(Me.lbl_inc_rama)
        Me.tab_incapacidad.Controls.Add(Me.txt_inc_numtra)
        Me.tab_incapacidad.Controls.Add(Me.lbl_inc_numtra)
        Me.tab_incapacidad.Controls.Add(Me.dgv_incapacidades)
        Me.tab_incapacidad.Location = New System.Drawing.Point(4, 22)
        Me.tab_incapacidad.Name = "tab_incapacidad"
        Me.tab_incapacidad.Size = New System.Drawing.Size(532, 439)
        Me.tab_incapacidad.TabIndex = 2
        Me.tab_incapacidad.Text = "Incapacidades"
        Me.tab_incapacidad.UseVisualStyleBackColor = True
        '
        'txt_inc_catego
        '
        Me.txt_inc_catego.BackColor = System.Drawing.Color.White
        Me.txt_inc_catego.Location = New System.Drawing.Point(189, 101)
        Me.txt_inc_catego.Name = "txt_inc_catego"
        Me.txt_inc_catego.Size = New System.Drawing.Size(62, 20)
        Me.txt_inc_catego.TabIndex = 37
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(140, 102)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(41, 13)
        Me.lbl.TabIndex = 36
        Me.lbl.Text = "Catego"
        '
        'bot_inc_eliminar
        '
        Me.bot_inc_eliminar.Location = New System.Drawing.Point(429, 63)
        Me.bot_inc_eliminar.Name = "bot_inc_eliminar"
        Me.bot_inc_eliminar.Size = New System.Drawing.Size(75, 23)
        Me.bot_inc_eliminar.TabIndex = 35
        Me.bot_inc_eliminar.Text = "Eliminar"
        Me.bot_inc_eliminar.UseVisualStyleBackColor = True
        '
        'bot_inc_guardar
        '
        Me.bot_inc_guardar.Location = New System.Drawing.Point(429, 30)
        Me.bot_inc_guardar.Name = "bot_inc_guardar"
        Me.bot_inc_guardar.Size = New System.Drawing.Size(75, 23)
        Me.bot_inc_guardar.TabIndex = 34
        Me.bot_inc_guardar.Text = "Guardar"
        Me.bot_inc_guardar.UseVisualStyleBackColor = True
        '
        'txt_inc_dias
        '
        Me.txt_inc_dias.BackColor = System.Drawing.Color.White
        Me.txt_inc_dias.Location = New System.Drawing.Point(73, 100)
        Me.txt_inc_dias.Name = "txt_inc_dias"
        Me.txt_inc_dias.Size = New System.Drawing.Size(56, 20)
        Me.txt_inc_dias.TabIndex = 33
        '
        'lbl_inc_dias
        '
        Me.lbl_inc_dias.AutoSize = True
        Me.lbl_inc_dias.Location = New System.Drawing.Point(27, 101)
        Me.lbl_inc_dias.Name = "lbl_inc_dias"
        Me.lbl_inc_dias.Size = New System.Drawing.Size(28, 13)
        Me.lbl_inc_dias.TabIndex = 32
        Me.lbl_inc_dias.Text = "Dias"
        '
        'txt_inc_fecha
        '
        Me.txt_inc_fecha.BackColor = System.Drawing.Color.White
        Me.txt_inc_fecha.Location = New System.Drawing.Point(73, 65)
        Me.txt_inc_fecha.Name = "txt_inc_fecha"
        Me.txt_inc_fecha.Size = New System.Drawing.Size(56, 20)
        Me.txt_inc_fecha.TabIndex = 31
        '
        'lbl_inc_fecha
        '
        Me.lbl_inc_fecha.AutoSize = True
        Me.lbl_inc_fecha.Location = New System.Drawing.Point(26, 66)
        Me.lbl_inc_fecha.Name = "lbl_inc_fecha"
        Me.lbl_inc_fecha.Size = New System.Drawing.Size(37, 13)
        Me.lbl_inc_fecha.TabIndex = 30
        Me.lbl_inc_fecha.Text = "Fecha"
        '
        'bot_mostrar
        '
        Me.bot_mostrar.Location = New System.Drawing.Point(429, 96)
        Me.bot_mostrar.Name = "bot_mostrar"
        Me.bot_mostrar.Size = New System.Drawing.Size(75, 23)
        Me.bot_mostrar.TabIndex = 29
        Me.bot_mostrar.Text = "Mostrar"
        Me.bot_mostrar.UseVisualStyleBackColor = True
        '
        'cmb_inc_estado
        '
        Me.cmb_inc_estado.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmb_inc_estado.FormattingEnabled = True
        Me.cmb_inc_estado.Items.AddRange(New Object() {"Vigente", "Todos"})
        Me.cmb_inc_estado.Location = New System.Drawing.Point(189, 65)
        Me.cmb_inc_estado.Name = "cmb_inc_estado"
        Me.cmb_inc_estado.Size = New System.Drawing.Size(62, 21)
        Me.cmb_inc_estado.TabIndex = 28
        '
        'lbl_inc_estado
        '
        Me.lbl_inc_estado.AutoSize = True
        Me.lbl_inc_estado.Location = New System.Drawing.Point(139, 66)
        Me.lbl_inc_estado.Name = "lbl_inc_estado"
        Me.lbl_inc_estado.Size = New System.Drawing.Size(40, 13)
        Me.lbl_inc_estado.TabIndex = 27
        Me.lbl_inc_estado.Text = "Estado"
        '
        'cmb_inc_rama
        '
        Me.cmb_inc_rama.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmb_inc_rama.FormattingEnabled = True
        Me.cmb_inc_rama.Items.AddRange(New Object() {"AT", "EG"})
        Me.cmb_inc_rama.Location = New System.Drawing.Point(189, 30)
        Me.cmb_inc_rama.Name = "cmb_inc_rama"
        Me.cmb_inc_rama.Size = New System.Drawing.Size(62, 21)
        Me.cmb_inc_rama.TabIndex = 26
        '
        'lbl_inc_rama
        '
        Me.lbl_inc_rama.AutoSize = True
        Me.lbl_inc_rama.Location = New System.Drawing.Point(143, 30)
        Me.lbl_inc_rama.Name = "lbl_inc_rama"
        Me.lbl_inc_rama.Size = New System.Drawing.Size(35, 13)
        Me.lbl_inc_rama.TabIndex = 25
        Me.lbl_inc_rama.Text = "Rama"
        '
        'txt_inc_numtra
        '
        Me.txt_inc_numtra.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_inc_numtra.Location = New System.Drawing.Point(73, 30)
        Me.txt_inc_numtra.Name = "txt_inc_numtra"
        Me.txt_inc_numtra.Size = New System.Drawing.Size(56, 20)
        Me.txt_inc_numtra.TabIndex = 24
        '
        'lbl_inc_numtra
        '
        Me.lbl_inc_numtra.AutoSize = True
        Me.lbl_inc_numtra.Location = New System.Drawing.Point(26, 30)
        Me.lbl_inc_numtra.Name = "lbl_inc_numtra"
        Me.lbl_inc_numtra.Size = New System.Drawing.Size(41, 13)
        Me.lbl_inc_numtra.TabIndex = 23
        Me.lbl_inc_numtra.Text = "Numtra"
        '
        'dgv_incapacidades
        '
        Me.dgv_incapacidades.AllowUserToAddRows = False
        Me.dgv_incapacidades.AllowUserToDeleteRows = False
        Me.dgv_incapacidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_incapacidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.catego})
        Me.dgv_incapacidades.Location = New System.Drawing.Point(29, 152)
        Me.dgv_incapacidades.Name = "dgv_incapacidades"
        Me.dgv_incapacidades.Size = New System.Drawing.Size(475, 250)
        Me.dgv_incapacidades.TabIndex = 7
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
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Dias"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 45
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Rama"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 45
        '
        'catego
        '
        Me.catego.HeaderText = "Cat"
        Me.catego.Name = "catego"
        Me.catego.Width = 40
        '
        'lbl_semana
        '
        Me.lbl_semana.AutoSize = True
        Me.lbl_semana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_semana.Location = New System.Drawing.Point(29, 54)
        Me.lbl_semana.Name = "lbl_semana"
        Me.lbl_semana.Size = New System.Drawing.Size(110, 31)
        Me.lbl_semana.TabIndex = 9
        Me.lbl_semana.Text = "999999"
        '
        'EnrolamientoToolStripMenuItem
        '
        Me.EnrolamientoToolStripMenuItem.Name = "EnrolamientoToolStripMenuItem"
        Me.EnrolamientoToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.EnrolamientoToolStripMenuItem.Text = "Enrolamiento"
        '
        'Asistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 618)
        Me.Controls.Add(Me.lbl_semana)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Asistencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asistencia de Personal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tab_reloj.ResumeLayout(False)
        CType(Me.dgv_reloj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_captura.ResumeLayout(False)
        Me.tab_captura.PerformLayout()
        Me.tab_incapacidad.ResumeLayout(False)
        Me.tab_incapacidad.PerformLayout()
        CType(Me.dgv_incapacidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargaAsistenciaDeRelojToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CapturaDeAsistenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalariosIMSSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_reloj As System.Windows.Forms.TabPage
    Friend WithEvents dgv_reloj As System.Windows.Forms.DataGridView
    Friend WithEvents ReporteDeAsistenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_semana As System.Windows.Forms.Label
    Friend WithEvents bot_tab1_mostrar As System.Windows.Forms.Button
    Friend WithEvents tab_captura As System.Windows.Forms.TabPage
    Friend WithEvents chk_domfes As System.Windows.Forms.CheckBox
    Friend WithEvents chk_reloj As System.Windows.Forms.CheckBox
    Friend WithEvents chk_fijo As System.Windows.Forms.CheckBox
    Friend WithEvents txt_nom_numtra As System.Windows.Forms.TextBox
    Friend WithEvents txt_numtra As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nomnumtra As System.Windows.Forms.Label
    Friend WithEvents lbl_numtra As System.Windows.Forms.Label
    Friend WithEvents bot_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_correo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_correo As System.Windows.Forms.Label
    Friend WithEvents numtra As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents fijo As DataGridViewTextBoxColumn
    Friend WithEvents reloj As DataGridViewTextBoxColumn
    Friend WithEvents domfes As DataGridViewTextBoxColumn
    Friend WithEvents Domrep As DataGridViewTextBoxColumn
    Friend WithEvents chk_domrep As CheckBox
    Friend WithEvents CargarIncapacidadesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tab_incapacidad As TabPage
    Friend WithEvents bot_mostrar As Button
    Friend WithEvents cmb_inc_estado As ComboBox
    Friend WithEvents lbl_inc_estado As Label
    Friend WithEvents cmb_inc_rama As ComboBox
    Friend WithEvents lbl_inc_rama As Label
    Friend WithEvents txt_inc_numtra As TextBox
    Friend WithEvents lbl_inc_numtra As Label
    Friend WithEvents dgv_incapacidades As DataGridView
    Friend WithEvents bot_inc_eliminar As Button
    Friend WithEvents bot_inc_guardar As Button
    Friend WithEvents txt_inc_dias As TextBox
    Friend WithEvents lbl_inc_dias As Label
    Friend WithEvents txt_inc_fecha As TextBox
    Friend WithEvents lbl_inc_fecha As Label
    Friend WithEvents txt_inc_catego As TextBox
    Friend WithEvents lbl As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents catego As DataGridViewTextBoxColumn
    Friend WithEvents EnrolamientoToolStripMenuItem As ToolStripMenuItem
End Class
