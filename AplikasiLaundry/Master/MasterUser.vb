Public Class MasterUser
    Private Sub MasterUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub
    Private Sub MasterUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormLogin.lc.loaduser(DataGridView1)
        tb_username.Clear()
        tb_password.Clear()
        tb_password.ReadOnly = False
        cmb_hakakses.SelectedIndex = -1
    End Sub

    Private Sub insertbtn_Click(sender As Object, e As EventArgs) Handles insertbtn.Click
        Try
            If tb_username.Text <> "" And tb_password.Text <> "" Then
                FormLogin.lc.insuser(tb_username.Text, tb_password.Text, cmb_hakakses.SelectedItem)
            End If
        Catch ex As Exception

        End Try
        MasterUser_Load(sender, e)
    End Sub

   
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim barisdgv As Integer = e.RowIndex

        If barisdgv >= 0 Then

            tb_username.Text = DataGridView1.Item(0, barisdgv).Value
            tb_password.ReadOnly = True
            cmb_hakakses.SelectedItem = DataGridView1.Item(1, barisdgv).Value
        End If
    End Sub

    Private Sub deletebtn_Click(sender As Object, e As EventArgs) Handles deletebtn.Click
        Try
            If tb_username.Text <> "" Then
                Dim iya As Integer = MessageBox.Show("Anda Yakin Delete User " & tb_username.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.deluser(tb_username.Text)
                End If
            End If
        Catch ex As Exception

        End Try
        MasterUser_Load(sender, e)
    End Sub
End Class