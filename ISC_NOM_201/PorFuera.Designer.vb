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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PorFuera))
        Me.dgr_conceptos = New System.Windows.Forms.DataGridView()
        Me.tponom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_neto_pagar = New System.Windows.Forms.TextBox()
        Me.lbl_neto = New System.Windows.Forms.Label()
        Me.bot_reporte = New System.Windows.Forms.Button()
        Me.bot_carga_xml = New System.Windows.Forms.Button()
        Me.bot_cfdi_junto = New System.Windows.Forms.Button()
        Me.bot_limpiar = New System.Windows.Forms.Button()
        Me.arc_carga_txt = New System.Windows.Forms.OpenFileDialog()
        Me.cd = New System.Windows.Forms.OpenFileDialog()
        Me.lbl_cargando = New System.Windows.Forms.Label()
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
        Me.ofd_leer_timbrado = New System.Windows.Forms.OpenFileDialog()
        Me.prb_estado = New System.Windows.Forms.ProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgr_conceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgr_conceptos
        '
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
        Me.dgr_conceptos.Location = New System.Drawing.Point(38, 138)
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
        Me.dgr_conceptos.TabIndex = 16
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
        'txt_neto_pagar
        '
        Me.txt_neto_pagar.Location = New System.Drawing.Point(450, 398)
        Me.txt_neto_pagar.Name = "txt_neto_pagar"
        Me.txt_neto_pagar.Size = New System.Drawing.Size(134, 20)
        Me.txt_neto_pagar.TabIndex = 17
        Me.txt_neto_pagar.Text = "0.00"
        Me.txt_neto_pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_neto
        '
        Me.lbl_neto.AutoSize = True
        Me.lbl_neto.Location = New System.Drawing.Point(352, 401)
        Me.lbl_neto.Name = "lbl_neto"
        Me.lbl_neto.Size = New System.Drawing.Size(87, 13)
        Me.lbl_neto.TabIndex = 18
        Me.lbl_neto.Text = "NETO A PAGAR"
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
        'lbl_cargando
        '
        Me.lbl_cargando.AutoSize = True
        Me.lbl_cargando.Font = New System.Drawing.Font("Arial Black", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_cargando.ForeColor = System.Drawing.Color.Green
        Me.lbl_cargando.Location = New System.Drawing.Point(66, 384)
        Me.lbl_cargando.Name = "lbl_cargando"
        Me.lbl_cargando.Size = New System.Drawing.Size(242, 38)
        Me.lbl_cargando.TabIndex = 33
        Me.lbl_cargando.Text = "CARGANDO . . ."
        Me.lbl_cargando.Visible = False
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
        Me.MenuStrip1.Size = New System.Drawing.Size(623, 24)
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
        'ofd_leer_timbrado
        '
        Me.ofd_leer_timbrado.FileName = "OpenFileDialog1"
        '
        'prb_estado
        '
        Me.prb_estado.Location = New System.Drawing.Point(0, 431)
        Me.prb_estado.Name = "prb_estado"
        Me.prb_estado.Size = New System.Drawing.Size(623, 23)
        Me.prb_estado.TabIndex = 37
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(461, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(126, 108)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'AcumuladoPorTrabajadorConceptoToolStripMenuItem
        '
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem.Name = "AcumuladoPorTrabajadorConceptoToolStripMenuItem"
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem.Size = New System.Drawing.Size(270, 22)
        Me.AcumuladoPorTrabajadorConceptoToolStripMenuItem.Text = "Acumulado por trabajador, concepto"
        '
        'PorFuera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 455)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.prb_estado)
        Me.Controls.Add(Me.bot_procesados)
        Me.Controls.Add(Me.bot_borrar)
        Me.Controls.Add(Me.lbl_cargando)
        Me.Controls.Add(Me.bot_limpiar)
        Me.Controls.Add(Me.bot_cfdi_junto)
        Me.Controls.Add(Me.bot_carga_xml)
        Me.Controls.Add(Me.bot_reporte)
        Me.Controls.Add(Me.lbl_neto)
        Me.Controls.Add(Me.txt_neto_pagar)
        Me.Controls.Add(Me.dgr_conceptos)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PorFuera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nomina Extraordinaria"
        CType(Me.dgr_conceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgr_conceptos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_neto_pagar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_neto As System.Windows.Forms.Label
    Friend WithEvents bot_reporte As System.Windows.Forms.Button
    Friend WithEvents bot_carga_xml As System.Windows.Forms.Button
    Friend WithEvents bot_cfdi_junto As System.Windows.Forms.Button
    Friend WithEvents bot_limpiar As System.Windows.Forms.Button
    Friend WithEvents arc_carga_txt As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tponom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbl_cargando As System.Windows.Forms.Label
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
End Class
