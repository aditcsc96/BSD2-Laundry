Public Class ViewMember
    Public id As String = ""
    Public tutup As Boolean = True
    Private Sub ViewMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComboBox1.SelectedIndex = 0
            FormLogin.lc.loadMember("", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim baris As Integer = e.RowIndex
            id = DataGridView1.Item(0, baris).Value.ToString()
            tutup = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If ComboBox1.SelectedIndex > 0 Then
                Select Case ComboBox1.SelectedIndex
                    Case 1
                        FormLogin.lc.loadMember(" AND idmember LIKE '%" & TextBox1.Text & "%'", DataGridView1)
                    Case 2
                        FormLogin.lc.loadMember(" AND nama LIKE '%" & TextBox1.Text & "%'", DataGridView1)
                End Select
            Else
                FormLogin.lc.loadMember("", DataGridView1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            FormLogin.lc.loadMember("", DataGridView1)
        End If
    End Sub
End Class