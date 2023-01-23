<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class nomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(nomina))
        Me.bot_poliza_cont = New System.Windows.Forms.Button()
        Me.fbd_carpeta = New System.Windows.Forms.FolderBrowserDialog()
        Me.bot_cargar = New System.Windows.Forms.Button()
        Me.bot_carga = New System.Windows.Forms.Button()
        Me.cd = New System.Windows.Forms.OpenFileDialog()
        Me.lbl_cargando = New System.Windows.Forms.Label()
        Me.bot_borrar = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PolizasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevisarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LectorXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarPolizasDeNominaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorCuentasSAPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorCuentasSIZToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tab_polizas = New System.Windows.Forms.TabControl()
        Me.tab_SIZ = New System.Windows.Forms.TabPage()
        Me.dgv_polizas = New System.Windows.Forms.DataGridView()
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.docto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.abono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_SAP = New System.Windows.Forms.TabPage()
        Me.dgv_sap_polizas = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bot_polizas_SAP = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_polizas.SuspendLayout()
        Me.tab_SIZ.SuspendLayout()
        CType(Me.dgv_polizas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_SAP.SuspendLayout()
        CType(Me.dgv_sap_polizas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bot_poliza_cont
        '
        Me.bot_poliza_cont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_poliza_cont.Location = New System.Drawing.Point(134, 72)
        Me.bot_poliza_cont.Name = "bot_poliza_cont"
        Me.bot_poliza_cont.Size = New System.Drawing.Size(113, 30)
        Me.bot_poliza_cont.TabIndex = 2
        Me.bot_poliza_cont.Text = "Crear Polizas SIZ"
        Me.bot_poliza_cont.UseVisualStyleBackColor = True
        '
        'bot_cargar
        '
        Me.bot_cargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_cargar.Location = New System.Drawing.Point(15, 72)
        Me.bot_cargar.Name = "bot_cargar"
        Me.bot_cargar.Size = New System.Drawing.Size(113, 30)
        Me.bot_cargar.TabIndex = 8
        Me.bot_cargar.Text = "Revision Polizas"
        Me.bot_cargar.UseVisualStyleBackColor = True
        '
        'bot_carga
        '
        Me.bot_carga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_carga.Location = New System.Drawing.Point(15, 36)
        Me.bot_carga.Name = "bot_carga"
        Me.bot_carga.Size = New System.Drawing.Size(113, 30)
        Me.bot_carga.TabIndex = 9
        Me.bot_carga.Text = "Cargar Polizas"
        Me.bot_carga.UseVisualStyleBackColor = True
        '
        'cd
        '
        Me.cd.FileName = "archivo.xls"
        '
        'lbl_cargando
        '
        Me.lbl_cargando.AutoSize = True
        Me.lbl_cargando.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cargando.ForeColor = System.Drawing.Color.Green
        Me.lbl_cargando.Location = New System.Drawing.Point(140, 37)
        Me.lbl_cargando.Name = "lbl_cargando"
        Me.lbl_cargando.Size = New System.Drawing.Size(171, 27)
        Me.lbl_cargando.TabIndex = 10
        Me.lbl_cargando.Text = "CARGANDO . . ."
        Me.lbl_cargando.Visible = False
        '
        'bot_borrar
        '
        Me.bot_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_borrar.Location = New System.Drawing.Point(15, 108)
        Me.bot_borrar.Name = "bot_borrar"
        Me.bot_borrar.Size = New System.Drawing.Size(113, 30)
        Me.bot_borrar.TabIndex = 11
        Me.bot_borrar.Text = "Borrar Polizas "
        Me.bot_borrar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(473, 24)
        Me.MenuStrip1.TabIndex = 12
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
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PolizasToolStripMenuItem, Me.LectorXMLToolStripMenuItem, Me.ImportarPolizasDeNominaToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'PolizasToolStripMenuItem
        '
        Me.PolizasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargarToolStripMenuItem, Me.RevisarToolStripMenuItem, Me.CreacionToolStripMenuItem, Me.BorrarToolStripMenuItem})
        Me.PolizasToolStripMenuItem.Name = "PolizasToolStripMenuItem"
        Me.PolizasToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.PolizasToolStripMenuItem.Text = "Polizas"
        '
        'CargarToolStripMenuItem
        '
        Me.CargarToolStripMenuItem.Name = "CargarToolStripMenuItem"
        Me.CargarToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.CargarToolStripMenuItem.Text = "Cargar"
        '
        'RevisarToolStripMenuItem
        '
        Me.RevisarToolStripMenuItem.Name = "RevisarToolStripMenuItem"
        Me.RevisarToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.RevisarToolStripMenuItem.Text = "Revisar"
        '
        'CreacionToolStripMenuItem
        '
        Me.CreacionToolStripMenuItem.Name = "CreacionToolStripMenuItem"
        Me.CreacionToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.CreacionToolStripMenuItem.Text = "Creacion"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'LectorXMLToolStripMenuItem
        '
        Me.LectorXMLToolStripMenuItem.Name = "LectorXMLToolStripMenuItem"
        Me.LectorXMLToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.LectorXMLToolStripMenuItem.Text = "Lector XML"
        '
        'ImportarPolizasDeNominaToolStripMenuItem
        '
        Me.ImportarPolizasDeNominaToolStripMenuItem.Name = "ImportarPolizasDeNominaToolStripMenuItem"
        Me.ImportarPolizasDeNominaToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ImportarPolizasDeNominaToolStripMenuItem.Text = "Importar polizas de Nomina"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErrorCuentasSAPToolStripMenuItem, Me.ErrorCuentasSIZToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'ErrorCuentasSAPToolStripMenuItem
        '
        Me.ErrorCuentasSAPToolStripMenuItem.Name = "ErrorCuentasSAPToolStripMenuItem"
        Me.ErrorCuentasSAPToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ErrorCuentasSAPToolStripMenuItem.Text = "Error cuentas SAP "
        '
        'ErrorCuentasSIZToolStripMenuItem
        '
        Me.ErrorCuentasSIZToolStripMenuItem.Name = "ErrorCuentasSIZToolStripMenuItem"
        Me.ErrorCuentasSIZToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ErrorCuentasSIZToolStripMenuItem.Text = "Error cuentas SIZ"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(336, 44)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 97)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'tab_polizas
        '
        Me.tab_polizas.Controls.Add(Me.tab_SIZ)
        Me.tab_polizas.Controls.Add(Me.tab_SAP)
        Me.tab_polizas.Location = New System.Drawing.Point(15, 144)
        Me.tab_polizas.Name = "tab_polizas"
        Me.tab_polizas.SelectedIndex = 0
        Me.tab_polizas.Size = New System.Drawing.Size(443, 350)
        Me.tab_polizas.TabIndex = 14
        '
        'tab_SIZ
        '
        Me.tab_SIZ.Controls.Add(Me.dgv_polizas)
        Me.tab_SIZ.Location = New System.Drawing.Point(4, 22)
        Me.tab_SIZ.Name = "tab_SIZ"
        Me.tab_SIZ.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_SIZ.Size = New System.Drawing.Size(435, 324)
        Me.tab_SIZ.TabIndex = 0
        Me.tab_SIZ.Text = "SIZ"
        Me.tab_SIZ.UseVisualStyleBackColor = True
        '
        'dgv_polizas
        '
        Me.dgv_polizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_polizas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.docto, Me.serie, Me.cargo, Me.abono})
        Me.dgv_polizas.Location = New System.Drawing.Point(18, 22)
        Me.dgv_polizas.Name = "dgv_polizas"
        Me.dgv_polizas.Size = New System.Drawing.Size(398, 280)
        Me.dgv_polizas.TabIndex = 7
        '
        'num
        '
        Me.num.HeaderText = "Num"
        Me.num.Name = "num"
        Me.num.Width = 50
        '
        'docto
        '
        Me.docto.HeaderText = "Documento"
        Me.docto.Name = "docto"
        Me.docto.Width = 50
        '
        'serie
        '
        Me.serie.HeaderText = "Serie"
        Me.serie.Name = "serie"
        Me.serie.Width = 50
        '
        'cargo
        '
        Me.cargo.HeaderText = "Cargo"
        Me.cargo.Name = "cargo"
        '
        'abono
        '
        Me.abono.HeaderText = "Abono"
        Me.abono.Name = "abono"
        '
        'tab_SAP
        '
        Me.tab_SAP.Controls.Add(Me.dgv_sap_polizas)
        Me.tab_SAP.Location = New System.Drawing.Point(4, 22)
        Me.tab_SAP.Name = "tab_SAP"
        Me.tab_SAP.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_SAP.Size = New System.Drawing.Size(435, 324)
        Me.tab_SAP.TabIndex = 1
        Me.tab_SAP.Text = "SAP"
        Me.tab_SAP.UseVisualStyleBackColor = True
        '
        'dgv_sap_polizas
        '
        Me.dgv_sap_polizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sap_polizas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgv_sap_polizas.Location = New System.Drawing.Point(18, 22)
        Me.dgv_sap_polizas.Name = "dgv_sap_polizas"
        Me.dgv_sap_polizas.Size = New System.Drawing.Size(398, 280)
        Me.dgv_sap_polizas.TabIndex = 8
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Num"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Documento"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Serie"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cargo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Abono"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'bot_polizas_SAP
        '
        Me.bot_polizas_SAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_polizas_SAP.Location = New System.Drawing.Point(134, 108)
        Me.bot_polizas_SAP.Name = "bot_polizas_SAP"
        Me.bot_polizas_SAP.Size = New System.Drawing.Size(113, 30)
        Me.bot_polizas_SAP.TabIndex = 15
        Me.bot_polizas_SAP.Text = "Crear Polizas SAP"
        Me.bot_polizas_SAP.UseVisualStyleBackColor = True
        '
        'nomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 506)
        Me.Controls.Add(Me.bot_polizas_SAP)
        Me.Controls.Add(Me.tab_polizas)
        Me.Controls.Add(Me.lbl_cargando)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bot_borrar)
        Me.Controls.Add(Me.bot_carga)
        Me.Controls.Add(Me.bot_cargar)
        Me.Controls.Add(Me.bot_poliza_cont)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "nomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Polizas Contables"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_polizas.ResumeLayout(False)
        Me.tab_SIZ.ResumeLayout(False)
        CType(Me.dgv_polizas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_SAP.ResumeLayout(False)
        CType(Me.dgv_sap_polizas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bot_poliza_cont As System.Windows.Forms.Button
    Friend WithEvents fbd_carpeta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents bot_cargar As System.Windows.Forms.Button
    Friend WithEvents bot_carga As System.Windows.Forms.Button
    Friend WithEvents cd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbl_cargando As System.Windows.Forms.Label
    Friend WithEvents bot_borrar As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PolizasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevisarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LectorXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportarPolizasDeNominaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tab_polizas As TabControl
    Friend WithEvents tab_SIZ As TabPage
    Friend WithEvents dgv_polizas As DataGridView
    Friend WithEvents num As DataGridViewTextBoxColumn
    Friend WithEvents docto As DataGridViewTextBoxColumn
    Friend WithEvents serie As DataGridViewTextBoxColumn
    Friend WithEvents cargo As DataGridViewTextBoxColumn
    Friend WithEvents abono As DataGridViewTextBoxColumn
    Friend WithEvents tab_SAP As TabPage
    Friend WithEvents dgv_sap_polizas As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ErrorCuentasSAPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ErrorCuentasSIZToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents bot_polizas_SAP As Button
End Class
