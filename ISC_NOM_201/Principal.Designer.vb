<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.salvar = New System.Windows.Forms.SaveFileDialog()
        Me.bot_porfuera = New System.Windows.Forms.Button()
        Me.cargar = New System.Windows.Forms.OpenFileDialog()
        Me.bot_nomina = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.bot_dispersion = New System.Windows.Forms.Button()
        Me.bot_asistencia = New System.Windows.Forms.Button()
        Me.bot_procesos = New System.Windows.Forms.Button()
        Me.men_principal = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogosMaestrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NominaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdinariaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtraordinariaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DispersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PolizasContablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsistenciaDePersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bot_maestros = New System.Windows.Forms.Button()
        Me.men_principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'bot_porfuera
        '
        Me.bot_porfuera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_porfuera.Location = New System.Drawing.Point(31, 110)
        Me.bot_porfuera.Name = "bot_porfuera"
        Me.bot_porfuera.Size = New System.Drawing.Size(137, 25)
        Me.bot_porfuera.TabIndex = 2
        Me.bot_porfuera.Text = "Nomina extraordinaria"
        Me.bot_porfuera.UseVisualStyleBackColor = True
        '
        'cargar
        '
        Me.cargar.FileName = "archivo.txt"
        '
        'bot_nomina
        '
        Me.bot_nomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_nomina.Location = New System.Drawing.Point(31, 172)
        Me.bot_nomina.Name = "bot_nomina"
        Me.bot_nomina.Size = New System.Drawing.Size(137, 23)
        Me.bot_nomina.TabIndex = 4
        Me.bot_nomina.Text = "Polizas Contables"
        Me.bot_nomina.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'bot_dispersion
        '
        Me.bot_dispersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_dispersion.Location = New System.Drawing.Point(31, 141)
        Me.bot_dispersion.Name = "bot_dispersion"
        Me.bot_dispersion.Size = New System.Drawing.Size(137, 25)
        Me.bot_dispersion.TabIndex = 3
        Me.bot_dispersion.Text = "Dispersion"
        Me.bot_dispersion.UseVisualStyleBackColor = True
        '
        'bot_asistencia
        '
        Me.bot_asistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_asistencia.Location = New System.Drawing.Point(31, 201)
        Me.bot_asistencia.Name = "bot_asistencia"
        Me.bot_asistencia.Size = New System.Drawing.Size(137, 23)
        Me.bot_asistencia.TabIndex = 5
        Me.bot_asistencia.Text = "Asistencia"
        Me.bot_asistencia.UseVisualStyleBackColor = True
        '
        'bot_procesos
        '
        Me.bot_procesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_procesos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bot_procesos.Location = New System.Drawing.Point(31, 79)
        Me.bot_procesos.Name = "bot_procesos"
        Me.bot_procesos.Size = New System.Drawing.Size(137, 25)
        Me.bot_procesos.TabIndex = 1
        Me.bot_procesos.Text = "Nomina ordinaria"
        Me.bot_procesos.UseVisualStyleBackColor = True
        '
        'men_principal
        '
        Me.men_principal.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.men_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.AcercaToolStripMenuItem})
        Me.men_principal.Location = New System.Drawing.Point(0, 0)
        Me.men_principal.Name = "men_principal"
        Me.men_principal.Size = New System.Drawing.Size(202, 24)
        Me.men_principal.TabIndex = 6
        Me.men_principal.Text = "MenuStrip1"
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
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CatalogosMaestrosToolStripMenuItem, Me.NominaToolStripMenuItem, Me.DispersionToolStripMenuItem, Me.PolizasContablesToolStripMenuItem, Me.AsistenciaDePersonalToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'CatalogosMaestrosToolStripMenuItem
        '
        Me.CatalogosMaestrosToolStripMenuItem.Name = "CatalogosMaestrosToolStripMenuItem"
        Me.CatalogosMaestrosToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CatalogosMaestrosToolStripMenuItem.Text = "Catalogos Maestros"
        '
        'NominaToolStripMenuItem
        '
        Me.NominaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdinariaToolStripMenuItem, Me.ExtraordinariaToolStripMenuItem})
        Me.NominaToolStripMenuItem.Name = "NominaToolStripMenuItem"
        Me.NominaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.NominaToolStripMenuItem.Text = "Nomina"
        '
        'OrdinariaToolStripMenuItem
        '
        Me.OrdinariaToolStripMenuItem.Name = "OrdinariaToolStripMenuItem"
        Me.OrdinariaToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OrdinariaToolStripMenuItem.Text = "Ordinaria"
        '
        'ExtraordinariaToolStripMenuItem
        '
        Me.ExtraordinariaToolStripMenuItem.Name = "ExtraordinariaToolStripMenuItem"
        Me.ExtraordinariaToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExtraordinariaToolStripMenuItem.Text = "Extraordinaria"
        '
        'DispersionToolStripMenuItem
        '
        Me.DispersionToolStripMenuItem.Name = "DispersionToolStripMenuItem"
        Me.DispersionToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.DispersionToolStripMenuItem.Text = "Dispersion"
        '
        'PolizasContablesToolStripMenuItem
        '
        Me.PolizasContablesToolStripMenuItem.Name = "PolizasContablesToolStripMenuItem"
        Me.PolizasContablesToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.PolizasContablesToolStripMenuItem.Text = "Polizas Contables"
        '
        'AsistenciaDePersonalToolStripMenuItem
        '
        Me.AsistenciaDePersonalToolStripMenuItem.Name = "AsistenciaDePersonalToolStripMenuItem"
        Me.AsistenciaDePersonalToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AsistenciaDePersonalToolStripMenuItem.Text = "Asistencia de Personal"
        '
        'AcercaToolStripMenuItem
        '
        Me.AcercaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VersionToolStripMenuItem})
        Me.AcercaToolStripMenuItem.Name = "AcercaToolStripMenuItem"
        Me.AcercaToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.AcercaToolStripMenuItem.Text = "Acerca"
        '
        'VersionToolStripMenuItem
        '
        Me.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem"
        Me.VersionToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.VersionToolStripMenuItem.Text = "Version"
        '
        'bot_maestros
        '
        Me.bot_maestros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_maestros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bot_maestros.Location = New System.Drawing.Point(31, 48)
        Me.bot_maestros.Name = "bot_maestros"
        Me.bot_maestros.Size = New System.Drawing.Size(137, 25)
        Me.bot_maestros.TabIndex = 0
        Me.bot_maestros.Text = "Archivos maestros"
        Me.bot_maestros.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(202, 250)
        Me.Controls.Add(Me.bot_maestros)
        Me.Controls.Add(Me.bot_procesos)
        Me.Controls.Add(Me.bot_asistencia)
        Me.Controls.Add(Me.bot_dispersion)
        Me.Controls.Add(Me.bot_nomina)
        Me.Controls.Add(Me.bot_porfuera)
        Me.Controls.Add(Me.men_principal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.men_principal
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "   Sistema de Nominas"
        Me.men_principal.ResumeLayout(False)
        Me.men_principal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents salvar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents bot_porfuera As System.Windows.Forms.Button
    Friend WithEvents cargar As System.Windows.Forms.OpenFileDialog
    Friend WithEvents bot_nomina As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bot_dispersion As System.Windows.Forms.Button
    Friend WithEvents bot_asistencia As System.Windows.Forms.Button
    Friend WithEvents bot_procesos As System.Windows.Forms.Button
    Friend WithEvents men_principal As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NominaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdinariaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtraordinariaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DispersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PolizasContablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsistenciaDePersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bot_maestros As System.Windows.Forms.Button
    Friend WithEvents CatalogosMaestrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
