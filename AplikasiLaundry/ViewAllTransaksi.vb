Public Class ViewAllTransaksi
    Public kodetrans As String = ""
    Public tutup As Boolean = True
    Private Sub ViewAllTransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComboBox1.SelectedIndex = 0
            FormLogin.lc.loadTransaksi("", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim baris As Integer = e.RowIndex
            kodetrans = DataGridView1.Item(0, baris).Value.ToString()
            'MsgBox(kodetrans)
            'tutup = False
            'Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If ComboBox1.SelectedIndex > 0 Then
                Select Case ComboBox1.SelectedIndex
                    Case 1
                        FormLogin.lc.loadTransaksi(" AND kodetrans LIKE '%" & TextBox1.Text & "%'", DataGridView1)
                    Case 2
                        FormLogin.lc.loadTransaksi(" AND idmember LIKE '%" & TextBox1.Text & "%'", DataGridView1)
                End Select
            Else
                FormLogin.lc.loadTransaksi("", DataGridView1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            FormLogin.lc.loadTransaksi("", DataGridView1)
        End If
    End Sub

    Private Sub ViewAllTransaksi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub


    Private Sub delete_btn_Click(sender As Object, e As EventArgs) Handles delete_btn.Click
        FormLogin.lc.deleteTrans(kodetrans)
        ViewAllTransaksi_Load(sender, e)
    End Sub
End Class
