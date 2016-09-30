<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.tb_password = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_username = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_reset
        '
        Me.btn_reset.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_reset.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_reset.Font = New System.Drawing.Font("Lucida Handwriting", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reset.Image = CType(resources.GetObject("btn_reset.Image"), System.Drawing.Image)
        Me.btn_reset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_reset.Location = New System.Drawing.Point(368, 188)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(88, 43)
        Me.btn_reset.TabIndex = 0
        Me.btn_reset.Text = "Reset"
        Me.btn_reset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_reset.UseVisualStyleBackColor = False
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_login.Font = New System.Drawing.Font("Lucida Handwriting", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login.Image = CType(resources.GetObject("btn_login.Image"), System.Drawing.Image)
        Me.btn_login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_login.Location = New System.Drawing.Point(248, 188)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(90, 43)
        Me.btn_login.TabIndex = 9
        Me.btn_login.Text = "Login"
        Me.btn_login.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'tb_password
        '
        Me.tb_password.Location = New System.Drawing.Point(331, 147)
        Me.tb_password.Name = "tb_password"
        Me.tb_password.Size = New System.Drawing.Size(175, 20)
        Me.tb_password.TabIndex = 8
        Me.tb_password.Text = "adminlaundry"
        Me.tb_password.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(215, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Password :"
        '
        'tb_username
        '
        Me.tb_username.Location = New System.Drawing.Point(331, 121)
        Me.tb_username.Name = "tb_username"
        Me.tb_username.Size = New System.Drawing.Size(175, 20)
        Me.tb_username.TabIndex = 6
        Me.tb_username.Text = "adminlaundry"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(215, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Username :"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(551, 99)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'FormLogin
        '
        Me.AcceptButton = Me.btn_login
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(551, 314)
        Me.Controls.Add(Me.btn_reset)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.tb_password)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_username)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormLogin-Renda Laundry"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_reset As System.Windows.Forms.Button
    Friend WithEvents btn_login As System.Windows.Forms.Button
    Friend WithEvents tb_password As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_username As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
