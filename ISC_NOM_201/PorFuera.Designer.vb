<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PorFuera
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PorFuera))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bot_reporte = New System.Windows.Forms.Button()
        Me.bot_carga_xml = New System.Windows.Forms.Button()
        Me.bot_cfdi_junto = New System.Windows.Forms.Button()
        Me.bot_limpiar = New System.Windows.Forms.Button()
        Me.arc_carga_txt = New System.Windows.Forms.OpenFileDialog()
        Me.cd = New System.Windows.Forms.OpenFileDialog()
        Me.bot_borrar = New System.Windows.Forms.Button()
        Me.bot_procesados = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timbrado2017ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timbrado201733ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSemanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReactivarSemanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarPensionesDispersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevisionTimbradoEncabezadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevisionTimbradoDetalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumenPorPersonaYConceptoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofd_leer_timbrado = New System.Windows.Forms.OpenFileDialog()
        Me.prb_estado = New System.Windows.Forms.ProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tab_timbrado = New System.Windows.Forms.TabControl()
        Me.tab_timbre = New System.Windows.Forms.TabPage()
        Me.lbl_cargando = New System.Windows.Forms.Label()
        Me.lbl_neto = New System.Windows.Forms.Label()
        Me.txt_neto_pagar = New System.Windows.Forms.TextBox()
        Me.dgr_conceptos = New System.Windows.Forms.DataGridView()
        Me.tponom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_eliminacion = New System.Windows.Forms.TabPage()
        Me.lbl_eli_semana = New System.Windows.Forms.Label()
        Me.bot_elim_ajuste = New System.Windows.Forms.Button()
        Me.bot_elim_borrar = New System.Windows.Forms.Button()
        Me.bot_elim_buscar = New System.Windows.Forms.Button()
        Me.lbl_eli_letra = New System.Windows.Forms.Label()
        Me.lbl_eli_tipo = New System.Windows.Forms.Label()
        Me.lbl_eli_numtra = New System.Windows.Forms.Label()
        Me.txt_eli_semana = New System.Windows.Forms.TextBox()
        Me.txt_eli_letra = New System.Windows.Forms.TextBox()
        Me.cmb_eli_tponom = New System.Windows.Forms.ComboBox()
        Me.txt_eli_numtra = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_eli_importe = New System.Windows.Forms.TextBox()
        Me.dgv_eliminar = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_ajustes = New System.Windows.Forms.TabPage()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_timbrado.SuspendLayout()
        Me.tab_timbre.SuspendLayout()
        CType(Me.dgr_conceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_eliminacion.SuspendLayout()
        CType(Me.dgv_eliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bot_reporte
        '
        Me.bot_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_reporte.Location = New System.Drawing.Point(149, 81)
        Me.bot_reporte.Name = "bot_reporte"
        Me.bot_reporte.Size = New System.Drawing.Size(105, 22)
        Me.bot_reporte.TabIndex = 23
        Me.bot_reporte.Text = "REPORTE"
        Me.bot_reporte.UseVisualStyleBackColor = True
        '
        'bot_carga_xml
        '
        Me.bot_carga_xml.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_carga_xml.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bot_carga_xml.Location = New System.Drawing.Point(260, 51)
        Me.bot_carga_xml.Name = "bot_carga_xml"
        Me.bot_carga_xml.Size = New System.Drawing.Size(105, 22)
        Me.bot_carga_xml.TabIndex = 29
        Me.bot_carga_xml.Text = "CARGA"
        Me.bot_carga_xml.UseVisualStyleBackColor = True
        '
        'bot_cfdi_junto
        '
        Me.bot_cfdi_junto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_cfdi_junto.Location = New System.Drawing.Point(38, 53)
        Me.bot_cfdi_junto.Name = "bot_cfdi_junto"
        Me.bot_cfdi_junto.Size = New System.Drawing.Size(105, 22)
        Me.bot_cfdi_junto.TabIndex = 31
        Me.bot_cfdi_junto.Text = "CFDI 3.3"
        Me.bot_cfdi_junto.UseVisualStyleBackColor = True
        '
        'bot_limpiar
        '
        Me.bot_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_limpiar.Location = New System.Drawing.Point(149, 53)
        Me.bot_limpiar.Name = "bot_limpiar"
        Me.bot_limpiar.Size = New System.Drawing.Size(105, 22)
        Me.bot_limpiar.TabIndex = 32
        Me.bot_limpiar.Text = "LIMPIAR"
        Me.bot_limpiar.UseVisualStyleBackColor = True
        '
        'arc_carga_txt
        '
        Me.arc_carga_txt.FileName = "OpenFileDialog1"
        '
        'cd
        '
        Me.cd.FileName = "OpenFileDialog1"
        '
        'bot_borrar
        '
        Me.bot_borrar.Enabled = False
        Me.bot_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_borrar.Location = New System.Drawing.Point(260, 81)
        Me.bot_borrar.Name = "bot_borrar"
        Me.bot_borrar.Size = New System.Drawing.Size(105, 22)
        Me.bot_borrar.TabIndex = 34
        Me.bot_borrar.Text = "BORRAR"
        Me.bot_borrar.UseVisualStyleBackColor = True
        '
        'bot_procesados
        '
        Me.bot_procesados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_procesados.Location = New System.Drawing.Point(38, 81)
        Me.bot_procesados.Name = "bot_procesados"
        Me.bot_procesados.Size = New System.Drawing.Size(105, 22)
        Me.bot_procesados.TabIndex = 35
        Me.bot_procesados.Text = "PROCESADOS"
        Me.bot_procesados.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(676, 24)
        Me.MenuStrip1.TabIndex = 36
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
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Timbrado2017ToolStripMenuItem, Me.Timbrado201733ToolStripMenuItem, Me.CerrarSemanaToolStripMenuItem, Me.ReactivarSemanaToolStripMenuItem, Me.CargarPensionesDispersionToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'Timbrado2017ToolStripMenuItem
        '
        Me.Timbrado2017ToolStripMenuItem.Enabled = False
        Me.Timbrado2017ToolStripMenuItem.Name = "Timbrado2017ToolStripMenuItem"
        Me.Timbrado2017ToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.Timbrado2017ToolStripMenuItem.Text = "Timbrado 2017 3.2"
        '
        'Timbrado201733ToolStripMenuItem
        '
        Me.Timbrado201733ToolStripMenuItem.Name = "Timbrado201733ToolStripMenuItem"
        Me.Timbrado201733ToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.Timbrado201733ToolStripMenuItem.Text = "Timbrado 2017 3.3"
        '
        'CerrarSemanaToolStripMenuItem
        '
        Me.CerrarSemanaToolStripMenuItem.Name = "CerrarSemanaToolStripMenuItem"
        Me.CerrarSemanaToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.CerrarSemanaToolStripMenuItem.Text = "Cerrar Semana"
        '
        'ReactivarSemanaToolStripMenuItem
        '
        Me.ReactivarSemanaToolStripMenuItem.Name = "ReactivarSemanaToolStripMenuItem"
        Me.ReactivarSemanaToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ReactivarSemanaToolStripMenuItem.Text = "Reactivar Semana"
        '
        'CargarPensionesDispersionToolStripMenuItem
        '
        Me.CargarPensionesDispersionToolStripMenuItem.Name = "CargarPensionesDispersionToolStripMenuItem"
        Me.CargarPensionesDispersionToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.CargarPensionesDispersionToolStripMenuItem.Text = "Cargar pensiones dispersion"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RevisionTimbradoEncabezadoToolStripMenuItem, Me.RevisionTimbradoDetalleToolStripMenuItem, Me.ResumenPorPersonaYConceptoToolStripMenuItem, Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'RevisionTimbradoEncabezadoToolStripMenuItem
        '
        Me.RevisionTimbradoEncabezadoToolStripMenuItem.Name = "RevisionTimbradoEncabezadoToolStripMenuItem"
        Me.RevisionTimbradoEncabezadoToolStripMenuItem.Size = New System.Drawing.Size(270, 22)
        Me.RevisionTimbradoEncabezadoToolStripMenuItem.Text = "Revision timbrado encabezado"
        '
        'RevisionTimbradoDetalleToolStripMenuItem
        '
        Me.RevisionTimbradoDetalleToolStripMenuItem.Name = "RevisionTimbradoDetalleToolStripMenuItem"
        Me.RevisionTimbradoDetalleToolStripMenuItem.Size = New System.Drawing.Size(270, 22)
        Me.RevisionTimbradoDetalleToolStripMenuItem.Text = "Revision timbrado detalle"
        '
        'ResumenPorPersonaYConceptoToolStripMenuItem
        '
        Me.ResumenPorPersonaYConceptoToolStripMenuItem.Name = "ResumenPorPersonaYConceptoToolStripMenuItem"
        Me.ResumenPorPersonaYConceptoToolStripMenuItem.Size = New System.Drawing.Size(270, 22)
        Me.ResumenPorPersonaYConceptoToolStripMenuItem.Text = "Resumen por persona y concepto"
        '
        'AcumuladoPorTrabajadorConceptoToolStripMenuItem
        '
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem.Name = "AcumuladoPorTrabajadorConceptoToolStripMenuItem"
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem.Size = New System.Drawing.Size(270, 22)
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem.Text = "Acumulado por trabajador, concepto"
        '
        'ofd_leer_timbrado
        '
        Me.ofd_leer_timbrado.FileName = "OpenFileDialog1"
        '
        'prb_estado
        '
        Me.prb_estado.Location = New System.Drawing.Point(40, 508)
        Me.prb_estado.Name = "prb_estado"
        Me.prb_estado.Size = New System.Drawing.Size(600, 23)
        Me.prb_estado.TabIndex = 37
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(510, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(126, 108)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'tab_timbrado
        '
        Me.tab_timbrado.Controls.Add(Me.tab_timbre)
        Me.tab_timbrado.Controls.Add(Me.tab_eliminacion)
        Me.tab_timbrado.Controls.Add(Me.tab_ajustes)
        Me.tab_timbrado.Location = New System.Drawing.Point(38, 141)
        Me.tab_timbrado.Name = "tab_timbrado"
        Me.tab_timbrado.SelectedIndex = 0
        Me.tab_timbrado.Size = New System.Drawing.Size(602, 359)
        Me.tab_timbrado.TabIndex = 39
        '
        'tab_timbre
        '
        Me.tab_timbre.Controls.Add(Me.lbl_cargando)
        Me.tab_timbre.Controls.Add(Me.lbl_neto)
        Me.tab_timbre.Controls.Add(Me.txt_neto_pagar)
        Me.tab_timbre.Controls.Add(Me.dgr_conceptos)
        Me.tab_timbre.Location = New System.Drawing.Point(4, 22)
        Me.tab_timbre.Name = "tab_timbre"
        Me.tab_timbre.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_timbre.Size = New System.Drawing.Size(594, 333)
        Me.tab_timbre.TabIndex = 0
        Me.tab_timbre.Text = "Timbrado"
        Me.tab_timbre.UseVisualStyleBackColor = True
        '
        'lbl_cargando
        '
        Me.lbl_cargando.AutoSize = True
        Me.lbl_cargando.Font = New System.Drawing.Font("Arial Black", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_cargando.ForeColor = System.Drawing.Color.Green
        Me.lbl_cargando.Location = New System.Drawing.Point(50, 269)
        Me.lbl_cargando.Name = "lbl_cargando"
        Me.lbl_cargando.Size = New System.Drawing.Size(242, 38)
        Me.lbl_cargando.TabIndex = 37
        Me.lbl_cargando.Text = "CARGANDO . . ."
        Me.lbl_cargando.Visible = False
        '
        'lbl_neto
        '
        Me.lbl_neto.AutoSize = True
        Me.lbl_neto.Location = New System.Drawing.Point(336, 286)
        Me.lbl_neto.Name = "lbl_neto"
        Me.lbl_neto.Size = New System.Drawing.Size(87, 13)
        Me.lbl_neto.TabIndex = 36
        Me.lbl_neto.Text = "NETO A PAGAR"
        '
        'txt_neto_pagar
        '
        Me.txt_neto_pagar.Location = New System.Drawing.Point(434, 283)
        Me.txt_neto_pagar.Name = "txt_neto_pagar"
        Me.txt_neto_pagar.Size = New System.Drawing.Size(134, 20)
        Me.txt_neto_pagar.TabIndex = 35
        Me.txt_neto_pagar.Text = "0.00"
        Me.txt_neto_pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgr_conceptos
        '
        Me.dgr_conceptos.AllowUserToAddRows = False
        Me.dgr_conceptos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgr_conceptos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgr_conceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgr_conceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tponom, Me.tipo, Me.CONCEPTO, Me.cant, Me.IMPORTE})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgr_conceptos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgr_conceptos.Location = New System.Drawing.Point(22, 23)
        Me.dgr_conceptos.Name = "dgr_conceptos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgr_conceptos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgr_conceptos.Size = New System.Drawing.Size(546, 239)
        Me.dgr_conceptos.TabIndex = 34
        '
        'tponom
        '
        Me.tponom.HeaderText = "TPONOM"
        Me.tponom.Name = "tponom"
        '
        'tipo
        '
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.Name = "tipo"
        '
        'CONCEPTO
        '
        Me.CONCEPTO.HeaderText = "CONCEPTO"
        Me.CONCEPTO.Name = "CONCEPTO"
        '
        'cant
        '
        Me.cant.HeaderText = "CANTIDAD"
        Me.cant.Name = "cant"
        '
        'IMPORTE
        '
        Me.IMPORTE.HeaderText = "IMPORTE"
        Me.IMPORTE.Name = "IMPORTE"
        '
        'tab_eliminacion
        '
        Me.tab_eliminacion.Controls.Add(Me.lbl_eli_semana)
        Me.tab_eliminacion.Controls.Add(Me.bot_elim_ajuste)
        Me.tab_eliminacion.Controls.Add(Me.bot_elim_borrar)
        Me.tab_eliminacion.Controls.Add(Me.bot_elim_buscar)
        Me.tab_eliminacion.Controls.Add(Me.lbl_eli_letra)
        Me.tab_eliminacion.Controls.Add(Me.lbl_eli_tipo)
        Me.tab_eliminacion.Controls.Add(Me.lbl_eli_numtra)
        Me.tab_eliminacion.Controls.Add(Me.txt_eli_semana)
        Me.tab_eliminacion.Controls.Add(Me.txt_eli_letra)
        Me.tab_eliminacion.Controls.Add(Me.cmb_eli_tponom)
        Me.tab_eliminacion.Controls.Add(Me.txt_eli_numtra)
        Me.tab_eliminacion.Controls.Add(Me.Label1)
        Me.tab_eliminacion.Controls.Add(Me.txt_eli_importe)
        Me.tab_eliminacion.Controls.Add(Me.dgv_eliminar)
        Me.tab_eliminacion.Location = New System.Drawing.Point(4, 22)
        Me.tab_eliminacion.Name = "tab_eliminacion"
        Me.tab_eliminacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_eliminacion.Size = New System.Drawing.Size(594, 333)
        Me.tab_eliminacion.TabIndex = 1
        Me.tab_eliminacion.Text = "Eliminacion"
        Me.tab_eliminacion.UseVisualStyleBackColor = True
        '
        'lbl_eli_semana
        '
        Me.lbl_eli_semana.AutoSize = True
        Me.lbl_eli_semana.Location = New System.Drawing.Point(204, 16)
        Me.lbl_eli_semana.Name = "lbl_eli_semana"
        Me.lbl_eli_semana.Size = New System.Drawing.Size(46, 13)
        Me.lbl_eli_semana.TabIndex = 49
        Me.lbl_eli_semana.Text = "Semana"
        '
        'bot_elim_ajuste
        '
        Me.bot_elim_ajuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_elim_ajuste.Location = New System.Drawing.Point(190, 284)
        Me.bot_elim_ajuste.Name = "bot_elim_ajuste"
        Me.bot_elim_ajuste.Size = New System.Drawing.Size(77, 22)
        Me.bot_elim_ajuste.TabIndex = 48
        Me.bot_elim_ajuste.Text = "Ajuste"
        Me.bot_elim_ajuste.UseVisualStyleBackColor = True
        '
        'bot_elim_borrar
        '
        Me.bot_elim_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_elim_borrar.Location = New System.Drawing.Point(107, 284)
        Me.bot_elim_borrar.Name = "bot_elim_borrar"
        Me.bot_elim_borrar.Size = New System.Drawing.Size(77, 22)
        Me.bot_elim_borrar.TabIndex = 47
        Me.bot_elim_borrar.Text = "Eliminar"
        Me.bot_elim_borrar.UseVisualStyleBackColor = True
        '
        'bot_elim_buscar
        '
        Me.bot_elim_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_elim_buscar.Location = New System.Drawing.Point(24, 284)
        Me.bot_elim_buscar.Name = "bot_elim_buscar"
        Me.bot_elim_buscar.Size = New System.Drawing.Size(77, 22)
        Me.bot_elim_buscar.TabIndex = 40
        Me.bot_elim_buscar.Text = "Buscar"
        Me.bot_elim_buscar.UseVisualStyleBackColor = True
        '
        'lbl_eli_letra
        '
        Me.lbl_eli_letra.AutoSize = True
        Me.lbl_eli_letra.Location = New System.Drawing.Point(153, 16)
        Me.lbl_eli_letra.Name = "lbl_eli_letra"
        Me.lbl_eli_letra.Size = New System.Drawing.Size(31, 13)
        Me.lbl_eli_letra.TabIndex = 46
        Me.lbl_eli_letra.Text = "Letra"
        '
        'lbl_eli_tipo
        '
        Me.lbl_eli_tipo.AutoSize = True
        Me.lbl_eli_tipo.Location = New System.Drawing.Point(93, 16)
        Me.lbl_eli_tipo.Name = "lbl_eli_tipo"
        Me.lbl_eli_tipo.Size = New System.Drawing.Size(46, 13)
        Me.lbl_eli_tipo.TabIndex = 45
        Me.lbl_eli_tipo.Text = "Tponom"
        '
        'lbl_eli_numtra
        '
        Me.lbl_eli_numtra.AutoSize = True
        Me.lbl_eli_numtra.Location = New System.Drawing.Point(33, 16)
        Me.lbl_eli_numtra.Name = "lbl_eli_numtra"
        Me.lbl_eli_numtra.Size = New System.Drawing.Size(41, 13)
        Me.lbl_eli_numtra.TabIndex = 44
        Me.lbl_eli_numtra.Text = "Numtra"
        '
        'txt_eli_semana
        '
        Me.txt_eli_semana.Location = New System.Drawing.Point(190, 33)
        Me.txt_eli_semana.Name = "txt_eli_semana"
        Me.txt_eli_semana.Size = New System.Drawing.Size(76, 20)
        Me.txt_eli_semana.TabIndex = 43
        '
        'txt_eli_letra
        '
        Me.txt_eli_letra.Location = New System.Drawing.Point(154, 33)
        Me.txt_eli_letra.Name = "txt_eli_letra"
        Me.txt_eli_letra.Size = New System.Drawing.Size(30, 20)
        Me.txt_eli_letra.TabIndex = 42
        '
        'cmb_eli_tponom
        '
        Me.cmb_eli_tponom.FormattingEnabled = True
        Me.cmb_eli_tponom.Items.AddRange(New Object() {"1 - Sindicalizado", "2 - Confianza", "3 - Jubilado", "4 - Becario "})
        Me.cmb_eli_tponom.Location = New System.Drawing.Point(88, 33)
        Me.cmb_eli_tponom.Name = "cmb_eli_tponom"
        Me.cmb_eli_tponom.Size = New System.Drawing.Size(59, 21)
        Me.cmb_eli_tponom.TabIndex = 41
        '
        'txt_eli_numtra
        '
        Me.txt_eli_numtra.Location = New System.Drawing.Point(24, 33)
        Me.txt_eli_numtra.Name = "txt_eli_numtra"
        Me.txt_eli_numtra.Size = New System.Drawing.Size(58, 20)
        Me.txt_eli_numtra.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(338, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "NETO A PAGAR"
        '
        'txt_eli_importe
        '
        Me.txt_eli_importe.Location = New System.Drawing.Point(436, 286)
        Me.txt_eli_importe.Name = "txt_eli_importe"
        Me.txt_eli_importe.Size = New System.Drawing.Size(134, 20)
        Me.txt_eli_importe.TabIndex = 38
        Me.txt_eli_importe.Text = "0.00"
        Me.txt_eli_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_eliminar
        '
        Me.dgv_eliminar.AllowUserToAddRows = False
        Me.dgv_eliminar.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_eliminar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_eliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_eliminar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.numtra, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_eliminar.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_eliminar.Location = New System.Drawing.Point(24, 74)
        Me.dgv_eliminar.Name = "dgv_eliminar"
        Me.dgv_eliminar.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_eliminar.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_eliminar.Size = New System.Drawing.Size(546, 191)
        Me.dgv_eliminar.TabIndex = 37
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "TPONOM"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'numtra
        '
        Me.numtra.HeaderText = "NUMTRA"
        Me.numtra.Name = "numtra"
        Me.numtra.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "TIPO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "SEMANA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "IMPORTE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'tab_ajustes
        '
        Me.tab_ajustes.Location = New System.Drawing.Point(4, 22)
        Me.tab_ajustes.Name = "tab_ajustes"
        Me.tab_ajustes.Size = New System.Drawing.Size(594, 333)
        Me.tab_ajustes.TabIndex = 2
        Me.tab_ajustes.Text = "Conciliacion"
        Me.tab_ajustes.UseVisualStyleBackColor = True
        '
        'PorFuera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 555)
        Me.Controls.Add(Me.tab_timbrado)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.prb_estado)
        Me.Controls.Add(Me.bot_procesados)
        Me.Controls.Add(Me.bot_borrar)
        Me.Controls.Add(Me.bot_limpiar)
        Me.Controls.Add(Me.bot_cfdi_junto)
        Me.Controls.Add(Me.bot_carga_xml)
        Me.Controls.Add(Me.bot_reporte)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PorFuera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nomina Extraordinaria"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_timbrado.ResumeLayout(False)
        Me.tab_timbre.ResumeLayout(False)
        Me.tab_timbre.PerformLayout()
        CType(Me.dgr_conceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_eliminacion.ResumeLayout(False)
        Me.tab_eliminacion.PerformLayout()
        CType(Me.dgv_eliminar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bot_reporte As System.Windows.Forms.Button
    Friend WithEvents bot_carga_xml As System.Windows.Forms.Button
    Friend WithEvents bot_cfdi_junto As System.Windows.Forms.Button
    Friend WithEvents bot_limpiar As System.Windows.Forms.Button
    Friend WithEvents arc_carga_txt As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents bot_borrar As System.Windows.Forms.Button
    Friend WithEvents bot_procesados As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timbrado2017ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSemanaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofd_leer_timbrado As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ReactivarSemanaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents prb_estado As System.Windows.Forms.ProgressBar
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevisionTimbradoEncabezadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevisionTimbradoDetalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timbrado201733ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargarPensionesDispersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumenPorPersonaYConceptoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcumuladoPorTrabajadorConceptoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tab_timbrado As TabControl
    Friend WithEvents tab_timbre As TabPage
    Friend WithEvents lbl_cargando As Label
    Friend WithEvents lbl_neto As Label
    Friend WithEvents txt_neto_pagar As TextBox
    Friend WithEvents dgr_conceptos As DataGridView
    Friend WithEvents tponom As DataGridViewTextBoxColumn
    Friend WithEvents tipo As DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTO As DataGridViewTextBoxColumn
    Friend WithEvents cant As DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE As DataGridViewTextBoxColumn
    Friend WithEvents tab_eliminacion As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_eli_importe As TextBox
    Friend WithEvents dgv_eliminar As DataGridView
    Friend WithEvents bot_elim_ajuste As Button
    Friend WithEvents bot_elim_borrar As Button
    Friend WithEvents bot_elim_buscar As Button
    Friend WithEvents lbl_eli_letra As Label
    Friend WithEvents lbl_eli_tipo As Label
    Friend WithEvents lbl_eli_numtra As Label
    Friend WithEvents txt_eli_semana As TextBox
    Friend WithEvents txt_eli_letra As TextBox
    Friend WithEvents cmb_eli_tponom As ComboBox
    Friend WithEvents txt_eli_numtra As TextBox
    Friend WithEvents tab_ajustes As TabPage
    Friend WithEvents lbl_eli_semana As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents numtra As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
