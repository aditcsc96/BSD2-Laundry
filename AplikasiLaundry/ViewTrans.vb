Public Class ViewTrans
    Public kodetr As String = ""
    Public tutup As Boolean = True
    Private Sub ViewTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormLogin.lc.loadtransambilcucian("", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            FormLogin.lc.loadtransambilcucian(" AND kodetrans LIKE '%" & TextBox1.Text & "%'", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim baris As Integer = e.RowIndex
            kodetr = DataGridView1.Item(0, baris).Value
            tutup = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class