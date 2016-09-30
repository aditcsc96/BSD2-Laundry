Imports Oracle.DataAccess.Client
Public Class FormLogin
    Dim conn As New OracleConnection
    Public lc As New LaundryClass
   
#Region "prosedur"
    Public Sub kosongtext()
        tb_username.Text = ""
        tb_password.Text = ""
        tb_username.Focus()
    End Sub
#End Region

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Try
            If tb_username.Text = "" Then
                If tb_password.Text = "" Then
                    MsgBox("Harap Isi Username dan Password!")
                Else
                    MsgBox("Harap Isi Username!")
                End If
            ElseIf tb_password.Text = "" Then
                MsgBox("Harap Isi Password!")
            ElseIf lc.koneksi(tb_username.Text, tb_password.Text) Then
                If lc.cekhakakses(tb_username.Text) Then
                    MsgBox("Selamat Datang, " + tb_username.Text, MsgBoxStyle.Information)
                    FormUtama.Show()
                    Me.Hide()
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        kosongtext()
    End Sub
End Class