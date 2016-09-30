Public Class AmbilCucian
    Dim total, bayar, kembali, kurang As Integer
#Region "variable"
    public Sub cekTotal()
        total_txt.Text = Format(Val(total), "#,###").ToString()
        If bayar >= total Then
            kurang_txt.Text = 0
        Else
            kurang = total - bayar
            kurang_txt.Text = Format(Val(kurang), "#,###").ToString()
        End If
        kembali = bayar - total
        If kembali = 0 Then
            kembali_txt.Text = CStr(0)
        Else
            kembali_txt.Text = Format(Val(kembali), "#,###").ToString()
        End If
    End Sub
#End Region
    Private Sub AmbilCucian_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AmbilCucian_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub
    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            FormLogin.lc.kliksubmit(TextBox1.Text, Panel3, total, bayar, namaCust_txt.Text, tglMasuk_txt.Text, tglSelesai_txt.Text, tipe_txt.Text, namaCucian_txt.Text, lain_txt.Text, Panel5, kurang_txt.Text, Panel4)
            cekTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ViewTrans.ShowDialog()
            If ViewTrans.tutup = False Then
                TextBox1.Text = ViewTrans.kodetr
                ViewTrans.Dispose()
                Submit_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Panel3.Visible = False
            Panel4.Enabled = True
            TextBox1.Text = vbNullString
            TextBox1.Focus()
            TextBox2.Text = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        Try
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox2_Validated(sender As Object, e As EventArgs) Handles TextBox2.Validated
        Try
            Dim curTextBox As TextBox = sender
            If curTextBox.Text = vbNullString Or curTextBox.Text = "0" Then
                curTextBox.Text = "0"
            Else
                curTextBox.Text = Format(Val(curTextBox.Text), "#,###")
            End If
            FormLogin.lc.kliksubmit(TextBox1.Text, Panel3, total, bayar, namaCust_txt.Text, tglMasuk_txt.Text, tglSelesai_txt.Text, tipe_txt.Text, namaCucian_txt.Text, lain_txt.Text, Panel5, kurang_txt.Text, Panel4)
            bayar += CInt(TextBox2.Text)
            cekTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox2_MouseClick(sender As Object, e As EventArgs) Handles TextBox2.MouseClick, TextBox2.Enter
        Try
            Dim curTextBox As TextBox = sender
            If curTextBox.Text <> "0" Then
                curTextBox.Text = CDec(curTextBox.Text)
            End If
            curTextBox.SelectAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        Try
            If CInt(kurang_txt.Text) > 0 Then
                MsgBox("Harap Lunasi Pembayaran")
            Else
                Dim jwb As Integer = MessageBox.Show("Proses Cucian" & vbNewLine & "Kode Transaksi" & vbTab & TextBox1.Text, "Konfirmasi", MessageBoxButtons.OKCancel)
                If jwb = DialogResult.OK Then
                    FormLogin.lc.updateStatuscucian(bayar, "Lunas", "Sudah diambil", TextBox1.Text)
                    MsgBox("Barang telah diambil, terima kasih telah menggunakan jasa kami")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            FormLogin.lc.kliksubmit(TextBox1.Text, Panel3, total, bayar, namaCust_txt.Text, tglMasuk_txt.Text, tglSelesai_txt.Text, tipe_txt.Text, namaCucian_txt.Text, lain_txt.Text, Panel5, kurang_txt.Text, Panel4)
            bayar += CInt(TextBox2.Text)
            cekTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class