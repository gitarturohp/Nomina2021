<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lecturaxml
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
        Me.bot_leer = New System.Windows.Forms.Button()
        Me.dgv_xmls = New System.Windows.Forms.DataGridView()
        Me.rfc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uuid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofd_archivo = New System.Windows.Forms.OpenFileDialog()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.LeerXMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_registros = New System.Windows.Forms.Label()
        CType(Me.dgv_xmls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bot_leer
        '
        Me.bot_leer.Location = New System.Drawing.Point(28, 43)
        Me.bot_leer.Name = "bot_leer"
        Me.bot_leer.Size = New System.Drawing.Size(75, 23)
        Me.bot_leer.TabIndex = 0
        Me.bot_leer.Text = "Leer XML"
        Me.bot_leer.UseVisualStyleBackColor = True
        '
        'dgv_xmls
        '
        Me.dgv_xmls.AllowUserToAddRows = False
        Me.dgv_xmls.AllowUserToDeleteRows = False
        Me.dgv_xmls.AllowUserToOrderColumns = True
        Me.dgv_xmls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_xmls.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rfc, Me.nombre, Me.uuid, Me.importe})
        Me.dgv_xmls.Location = New System.Drawing.Point(28, 84)
        Me.dgv_xmls.Name = "dgv_xmls"
        Me.dgv_xmls.Size = New System.Drawing.Size(531, 284)
        Me.dgv_xmls.TabIndex = 1
        '
        'rfc
        '
        Me.rfc.HeaderText = "rfc"
        Me.rfc.Name = "rfc"
        '
        'nombre
        '
        Me.nombre.HeaderText = "nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.Width = 200
        '
        'uuid
        '
        Me.uuid.HeaderText = "uuid"
        Me.uuid.Name = "uuid"
        '
        'importe
        '
        Me.importe.HeaderText = "importe"
        Me.importe.Name = "importe"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.ReportesToolStripMenuItem, Me.AcercaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(594, 24)
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
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeerXMLToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'AcercaToolStripMenuItem
        '
        Me.AcercaToolStripMenuItem.Name = "AcercaToolStripMenuItem"
        Me.AcercaToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.AcercaToolStripMenuItem.Text = "Acerca"
        '
        'ofd_archivo
        '
        Me.ofd_archivo.FileName = "OpenFileDialog1"
        '
        'LeerXMLToolStripMenuItem
        '
        Me.LeerXMLToolStripMenuItem.Name = "LeerXMLToolStripMenuItem"
        Me.LeerXMLToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LeerXMLToolStripMenuItem.Text = "Leer XML"
        '
        'lbl_registros
        '
        Me.lbl_registros.AutoSize = True
        Me.lbl_registros.Location = New System.Drawing.Point(25, 382)
        Me.lbl_registros.Name = "lbl_registros"
        Me.lbl_registros.Size = New System.Drawing.Size(88, 13)
        Me.lbl_registros.TabIndex = 4
        Me.lbl_registros.Text = "Registro leidos: 0"
        '
        'lecturaxml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 420)
        Me.Controls.Add(Me.lbl_registros)
        Me.Controls.Add(Me.dgv_xmls)
        Me.Controls.Add(Me.bot_leer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "lecturaxml"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lectura XML"
        CType(Me.dgv_xmls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bot_leer As System.Windows.Forms.Button
    Friend WithEvents dgv_xmls As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofd_archivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents rfc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uuid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeerXMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
End Class
