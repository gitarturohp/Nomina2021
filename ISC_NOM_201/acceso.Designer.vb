<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class acceso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(acceso))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_pass = New System.Windows.Forms.Label()
        Me.lbl_usuario = New System.Windows.Forms.Label()
        Me.txt_pass = New System.Windows.Forms.TextBox()
        Me.txt_clave = New System.Windows.Forms.TextBox()
        Me.bot_salir = New System.Windows.Forms.Button()
        Me.bot_entra = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_pass)
        Me.GroupBox1.Controls.Add(Me.lbl_usuario)
        Me.GroupBox1.Controls.Add(Me.txt_pass)
        Me.GroupBox1.Controls.Add(Me.txt_clave)
        Me.GroupBox1.Controls.Add(Me.bot_salir)
        Me.GroupBox1.Controls.Add(Me.bot_entra)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(194, 169)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Usuario"
        '
        'lbl_pass
        '
        Me.lbl_pass.AutoSize = True
        Me.lbl_pass.Location = New System.Drawing.Point(42, 68)
        Me.lbl_pass.Name = "lbl_pass"
        Me.lbl_pass.Size = New System.Drawing.Size(61, 13)
        Me.lbl_pass.TabIndex = 11
        Me.lbl_pass.Text = "Contraseña"
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.Location = New System.Drawing.Point(42, 29)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(43, 13)
        Me.lbl_usuario.TabIndex = 10
        Me.lbl_usuario.Text = "Usuario"
        '
        'txt_pass
        '
        Me.txt_pass.Location = New System.Drawing.Point(45, 85)
        Me.txt_pass.Name = "txt_pass"
        Me.txt_pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_pass.Size = New System.Drawing.Size(100, 20)
        Me.txt_pass.TabIndex = 7
        '
        'txt_clave
        '
        Me.txt_clave.Location = New System.Drawing.Point(45, 46)
        Me.txt_clave.Name = "txt_clave"
        Me.txt_clave.Size = New System.Drawing.Size(100, 20)
        Me.txt_clave.TabIndex = 6
        '
        'bot_salir
        '
        Me.bot_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_salir.Location = New System.Drawing.Point(99, 120)
        Me.bot_salir.Name = "bot_salir"
        Me.bot_salir.Size = New System.Drawing.Size(75, 23)
        Me.bot_salir.TabIndex = 9
        Me.bot_salir.Text = "Salir"
        Me.bot_salir.UseVisualStyleBackColor = True
        '
        'bot_entra
        '
        Me.bot_entra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bot_entra.Location = New System.Drawing.Point(18, 120)
        Me.bot_entra.Name = "bot_entra"
        Me.bot_entra.Size = New System.Drawing.Size(75, 23)
        Me.bot_entra.TabIndex = 8
        Me.bot_entra.Text = "Entrar"
        Me.bot_entra.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(236, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(127, 195)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'lbl_version
        '
        Me.lbl_version.AutoSize = True
        Me.lbl_version.Location = New System.Drawing.Point(169, 16)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(50, 13)
        Me.lbl_version.TabIndex = 8
        Me.lbl_version.Text = "Ver. 2.12"
        '
        'acceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 219)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "acceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Acceso a Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_pass As System.Windows.Forms.Label
    Friend WithEvents lbl_usuario As System.Windows.Forms.Label
    Friend WithEvents txt_pass As System.Windows.Forms.TextBox
    Friend WithEvents txt_clave As System.Windows.Forms.TextBox
    Friend WithEvents bot_salir As System.Windows.Forms.Button
    Friend WithEvents bot_entra As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_version As Label
End Class
