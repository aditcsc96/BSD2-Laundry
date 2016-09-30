Public Class FormUtama
    Public ChildNumber As Integer = 0

#Region "Prosedur"
    '==========================================================================================================================
    Public Function IsOpen(ByVal nameForm As String) As Boolean
        Dim frm As Form
        For Each frm In Me.MdiChildren
            If frm.Name = nameForm Then
                frm.Activate()
                frm.WindowState = FormWindowState.Normal
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Private Sub logout()
        FormLogin.Show()
        FormLogin.kosongtext()
    End Sub
#End Region
    Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(FormLogin.lc.Jabatan)
        If FormLogin.lc.Jabatan = "admin" Then
            MasterDataToolStripMenuItem.Visible = True
            ReportToolStripMenuItem.Visible = True
            ViewTransaksiToolStripMenuItem.Visible = True
            ToolStripButton1.Visible = True
            ToolStripButton2.Visible = True
            ToolStripButton3.Visible = True
            ToolStripButton4.Visible = True
            ToolStripButton5.Visible = True
            ToolStripButton6.Visible = True

        ElseIf FormLogin.lc.Jabatan = "user" Then
            MasterDataToolStripMenuItem.Visible = False
            ReportToolStripMenuItem.Visible = False
            ViewTransaksiToolStripMenuItem.Visible = False
            ToolStripButton1.Visible = True
            ToolStripButton2.Visible = True
            ToolStripButton3.Visible = True
            ToolStripButton4.Visible = False
            ToolStripButton5.Visible = False
            ToolStripButton6.Visible = False
        End If
        ToolStripStatusLabelHakAkses.Text = FormLogin.lc.Jabatan.ToUpper
        ToolStripStatusLabelDate.Text = System.DateTime.Now.ToString("dd MMMM yyyy")
        Timer1.Start()
        Me.Text = "Renda Laundry - " + FormLogin.lc.Username.ToUpper
    End Sub
    Private Sub FormUtama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ChildNumber = 0 Then
            Dim jwb As Integer = MsgBox("Keluar Aplikasi?", MsgBoxStyle.YesNo, "Exit")
            If jwb = DialogResult.Yes Then
                logout()
            Else
                e.Cancel = True
            End If
        Else
            MsgBox("Please..Close all form!!!", MsgBoxStyle.Information)
            e.Cancel = True
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If ChildNumber = 0 Then
            MsgBox("See you later, " + FormLogin.lc.Username)
            Me.Dispose()
            logout()
        Else
            MsgBox("Please..Close all form!!!", MsgBoxStyle.Information)
        End If
        FormLogin.lc.conn.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If IsOpen("NewMember") = False Then
            Dim frm As New NewMember
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1
        End If
    End Sub

    Private Sub MemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberToolStripMenuItem.Click, ToolStripButton4.Click
        If IsOpen("MasterMember") = False Then
            Dim frm As New MasterMember
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1
        End If
    End Sub

    Private Sub HargaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HargaToolStripMenuItem.Click, ToolStripButton5.Click
        If IsOpen("MasterHarga") = False Then
            Dim frm As New MasterHarga
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1
        End If
    End Sub
    Private Sub OrderCucianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderCucianToolStripMenuItem.Click, ToolStripButton2.Click
        If IsOpen("NewLaundry") = False Then
            Dim frm As New NewLaundry
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1
        End If
    End Sub
    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click, ToolStripButton6.Click
        If IsOpen("MasterUser") = False Then
            Dim frm As New MasterUser
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1
        End If
    End Sub
    Private Sub ViewTransaksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTransaksiToolStripMenuItem.Click
        If IsOpen("ViewAllTransaksi") = False Then
            Dim frm As New ViewAllTransaksi
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1

        End If
    End Sub
    Private Sub AmbilCucianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AmbilCucianToolStripMenuItem.Click, ToolStripButton3.Click
        If IsOpen("AmbilCucian") = False Then
            Dim frm As New AmbilCucian
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1

        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ToolStripStatusLabelTime.Text = System.DateTime.Now.ToString("HH:mm:ss")

    End Sub

  
    Private Sub UserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem1.Click
        If IsOpen("LaporanMember") = False Then
            Dim frm As New LaporanMember
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1
        End If
    End Sub

    Private Sub TransaksiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem1.Click
        If IsOpen("LaporanPerTanggal") = False Then
            Dim frm As New LaporanPerTanggal
            frm.MdiParent = Me
            frm.Show()
            ChildNumber += 1
        End If
    End Sub
End Class
