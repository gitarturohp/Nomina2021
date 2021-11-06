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
        Me.dgv_polizas = New System.Windows.Forms.DataGridView()
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.docto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.abono = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dgv_polizas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bot_poliza_cont
        '
        Me.bot_poliza_cont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_poliza_cont.Location = New System.Drawing.Point(26, 98)
        Me.bot_poliza_cont.Name = "bot_poliza_cont"
        Me.bot_poliza_cont.Size = New System.Drawing.Size(113, 30)
        Me.bot_poliza_cont.TabIndex = 2
        Me.bot_poliza_cont.Text = "Creacion Polizas "
        Me.bot_poliza_cont.UseVisualStyleBackColor = True
        '
        'dgv_polizas
        '
        Me.dgv_polizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_polizas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.docto, Me.serie, Me.cargo, Me.abono})
        Me.dgv_polizas.Location = New System.Drawing.Point(26, 139)
        Me.dgv_polizas.Name = "dgv_polizas"
        Me.dgv_polizas.Size = New System.Drawing.Size(395, 308)
        Me.dgv_polizas.TabIndex = 6
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
        'bot_cargar
        '
        Me.bot_cargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_cargar.Location = New System.Drawing.Point(26, 62)
        Me.bot_cargar.Name = "bot_cargar"
        Me.bot_cargar.Size = New System.Drawing.Size(113, 30)
        Me.bot_cargar.TabIndex = 8
        Me.bot_cargar.Text = "Revision Polizas"
        Me.bot_cargar.UseVisualStyleBackColor = True
        '
        'bot_carga
        '
        Me.bot_carga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_carga.Location = New System.Drawing.Point(26, 26)
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
        Me.lbl_cargando.Location = New System.Drawing.Point(158, 36)
        Me.lbl_cargando.Name = "lbl_cargando"
        Me.lbl_cargando.Size = New System.Drawing.Size(171, 27)
        Me.lbl_cargando.TabIndex = 10
        Me.lbl_cargando.Text = "CARGANDO . . ."
        Me.lbl_cargando.Visible = False
        '
        'bot_borrar
        '
        Me.bot_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_borrar.Location = New System.Drawing.Point(145, 98)
        Me.bot_borrar.Name = "bot_borrar"
        Me.bot_borrar.Size = New System.Drawing.Size(113, 30)
        Me.bot_borrar.TabIndex = 11
        Me.bot_borrar.Text = "Borrar Polizas "
        Me.bot_borrar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(448, 24)
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
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(318, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 97)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'nomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 468)
        Me.Controls.Add(Me.lbl_cargando)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bot_borrar)
        Me.Controls.Add(Me.bot_carga)
        Me.Controls.Add(Me.bot_cargar)
        Me.Controls.Add(Me.dgv_polizas)
        Me.Controls.Add(Me.bot_poliza_cont)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "nomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Polizas Contables"
        CType(Me.dgv_polizas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bot_poliza_cont As System.Windows.Forms.Button
    Friend WithEvents fbd_carpeta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dgv_polizas As System.Windows.Forms.DataGridView
    Friend WithEvents bot_cargar As System.Windows.Forms.Button
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents docto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents abono As System.Windows.Forms.DataGridViewTextBoxColumn
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
End Class
