Imports Oracle.DataAccess.Client
Public Class MasterHarga
#Region "modul daftar harga"

#End Region
    Private Sub MasterHarga_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub MasterHarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormLogin.lc.refreshHarga(cb_txt.Text, ck_txt.Text, cs_txt.Text, laund_txt.Text, disk_txt.Text)
            'cb_txt.Text = CInt(cb_txt.Text)
            'ck_txt.Text = CInt(ck_txt.Text)
            'cs_txt.Text = CInt(cs_txt.Text)
            'laund_txt.Text = CInt(laund_txt.Text)
            'disk_txt.Text = CInt(disk_txt.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub keyPressEvent(sender As Object, e As KeyPressEventArgs) Handles cb_txt.KeyPress, ck_txt.KeyPress, cs_txt.KeyPress, laund_txt.KeyPress, disk_txt.KeyPress
        Try
            '97 - 122 = Ascii codes utk alphabet
            '65 - 90  = Ascii codes utk huruf besar
            '48 - 57  = Ascii codes utk angka
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub textBoxValidating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cb_txt.Validating, ck_txt.Validating, cs_txt.Validating, laund_txt.Validating, disk_txt.Validating
        Try

            If sender.Name = "disk_txt" And CType(sender, TextBox).Text <> vbNullString Then
                If disk_txt.Text >= 100 Then
                    MsgBox("Diskon harus kurang dari 100%" & vbNewLine & "Enake gratis broo..")
                    e.Cancel = True
                    disk_txt.SelectAll()
                    'ElseIf disk_txt.Text.Contains("00") Then
                    '    MsgBox("Diskon Harus Kurang dari 0")
                    '    e.Cancel = True
                    '    disk_txt.SelectAll()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub textBoxValidated(sender As Object, e As EventArgs) Handles cb_txt.Validated, ck_txt.Validated, cs_txt.Validated, laund_txt.Validated, disk_txt.Validated
        Try
            Dim currTextBox As TextBox = sender
            If currTextBox.Text = vbNullString Or currTextBox.Text = "0" Then
                currTextBox.Text = "0"
            Else
                currTextBox.Text = Format(Val(currTextBox.Text), "#,###")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        Try
            Dim cb As Integer = 0, ck = 0, cs = 0, laund = 0, disk = 0
            cb = CInt(CDec(cb_txt.Text))
            ck = CInt(CDec(ck_txt.Text))
            cs = CInt(CDec(cs_txt.Text))
            laund = CInt(CDec(laund_txt.Text))
            disk = CInt(CDec(disk_txt.Text))

            Dim result As Integer = MessageBox.Show("Anda Yakin Ingin Update?" & vbNewLine & vbNewLine & _
                                                    "Cuci Basah" & vbTab & "= Rp. " & Format(Val(cb), "#,###") & vbNewLine & _
                                                    "Cuci Kering" & vbTab & "= Rp. " & Format(Val(ck), "#,###") & vbNewLine & _
                                                    "Cuci Setrika" & vbTab & "= Rp. " & Format(Val(cs), "#,###") & vbNewLine & _
                                                    "Laundry" & vbTab & vbTab & "= Rp. " & Format(Val(laund), "#,###") & vbNewLine & _
                                                    "Diskon Member" & vbTab & "= " & disk & "%", _
                                                    "Konfirmasi", _
                                                    MessageBoxButtons.OKCancel, _
                                                    MessageBoxIcon.Warning)
            If result = MsgBoxResult.Ok Then
                If FormLogin.lc.updateHarga(cb_txt.Text, ck_txt.Text, cs_txt.Text, laund_txt.Text, disk_txt.Text) Then
                End If

            End If
            FormLogin.lc.refreshHarga(cb_txt.Text, ck_txt.Text, cs_txt.Text, laund_txt.Text, disk_txt.Text)
    
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class