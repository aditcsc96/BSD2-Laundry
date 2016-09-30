<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterUser))
        Me.deletebtn = New System.Windows.Forms.Button()
        Me.insertbtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tb_password = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_hakakses = New System.Windows.Forms.ComboBox()
        Me.tb_username = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'deletebtn
        '
        Me.deletebtn.Font = New System.Drawing.Font("Lucida Handwriting", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deletebtn.Image = CType(resources.GetObject("deletebtn.Image"), System.Drawing.Image)
        Me.deletebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.deletebtn.Location = New System.Drawing.Point(356, 480)
        Me.deletebtn.Name = "deletebtn"
        Me.deletebtn.Size = New System.Drawing.Size(97, 36)
        Me.deletebtn.TabIndex = 37
        Me.deletebtn.Text = "Delete"
        Me.deletebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.deletebtn.UseVisualStyleBackColor = True
        '
        'insertbtn
        '
        Me.insertbtn.Font = New System.Drawing.Font("Lucida Handwriting", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.insertbtn.Image = CType(resources.GetObject("insertbtn.Image"), System.Drawing.Image)
        Me.insertbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.insertbtn.Location = New System.Drawing.Point(356, 438)
        Me.insertbtn.Name = "insertbtn"
        Me.insertbtn.Size = New System.Drawing.Size(97, 36)
        Me.insertbtn.TabIndex = 35
        Me.insertbtn.Text = "Insert"
        Me.insertbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.insertbtn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.tb_password)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmb_hakakses)
        Me.Panel1.Controls.Add(Me.tb_username)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(14, 424)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 159)
        Me.Panel1.TabIndex = 34
        '
        'tb_password
        '
        Me.tb_password.Location = New System.Drawing.Point(177, 64)
        Me.tb_password.Name = "tb_password"
        Me.tb_password.Size = New System.Drawing.Size(125, 20)
        Me.tb_password.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Handwriting", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(10, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Password :"
        '
        'cmb_hakakses
        '
        Me.cmb_hakakses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_hakakses.FormattingEnabled = True
        Me.cmb_hakakses.Items.AddRange(New Object() {"admin", "user"})
        Me.cmb_hakakses.Location = New System.Drawing.Point(177, 97)
        Me.cmb_hakakses.Name = "cmb_hakakses"
        Me.cmb_hakakses.Size = New System.Drawing.Size(119, 21)
        Me.cmb_hakakses.TabIndex = 15
        '
        'tb_username
        '
        Me.tb_username.Location = New System.Drawing.Point(177, 37)
        Me.tb_username.Name = "tb_username"
        Me.tb_username.Size = New System.Drawing.Size(125, 20)
        Me.tb_username.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Lucida Handwriting", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(12, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Jabatan :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Handwriting", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(12, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Username :"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(14, 87)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(463, 331)
        Me.DataGridView1.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Handwriting", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 69)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Master User"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MasterUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(491, 599)
        Me.Controls.Add(Me.deletebtn)
        Me.Controls.Add(Me.insertbtn)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MasterUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MasterUser"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents deletebtn As System.Windows.Forms.Button
    Friend WithEvents insertbtn As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tb_password As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_hakakses As System.Windows.Forms.ComboBox
    Friend WithEvents tb_username As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
