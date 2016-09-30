Imports Oracle.DataAccess.Client
Public Class NewLaundry

#Region "Variabel"
    Public status As String = "", kategori, tipe, nama_barang, pewangi, lain2, tglMasuk, tglSelesai, geser, namaCust, namacustomer
    Public subTotal As Double = 0, grandTotal, jumlahDiskon, diskon, bayar
    Public beratCucian As Integer = 0
    Public kodeTrans As String = ""
    Dim ds As DataSet
    Dim dt As DataTable
    Dim da As OracleDataAdapter
    Dim flag As String
#End Region
#Region "prosedur"
    Sub cektotal()
        Try
            refreshdaftarharga()
            If kategoriLaundry.SelectedItem = "Kiloan" Then
                If RadioButton3.Checked Then
                    subTotal = (berat.Value / 5) * CDec(CInt(harga_cuciBasah.Text))
                ElseIf RadioButton4.Checked Then
                    subTotal = (berat.Value / 5) * CDec(CInt(harga_cuciKering.Text))
                ElseIf RadioButton5.Checked Then
                    subTotal = (berat.Value / 5) * CDec(CInt(harga_cuciSetrika.Text))
                End If

                Dim checkedRadioButton As RadioButton
                checkedRadioButton = GroupBox1.Controls.OfType(Of RadioButton)().Where(Function(r) r.Checked = True).FirstOrDefault()
                tipe = checkedRadioButton.Text

            ElseIf kategoriLaundry.SelectedItem = "Laundry" Then
                subTotal = (berat.Value / 5) * CDec(CInt(harga_laundry.Text))
                tipe = "Laundry"
            End If
            subTotal_txt.Text = Format(Val(subTotal), "#,###")

            If RadioButton1.Checked And TextBox1.Enabled = False Then
                diskon = subTotal * (jumlahDiskon / 100)
                diskon_txt.Text = Format(Val(diskon), "#,###")
            Else
                diskon = 0
                diskon_txt.Text = diskon
            End If

            grandTotal = subTotal - diskon
            grandTotal_txt.Text = Format(Val(grandTotal), "#,###")

            kategori = kategoriLaundry.SelectedItem
            nama_barang = TextBox2.Text
            beratCucian = berat.Value
            'RichTextBox1.Text = RichTextBox1.Text.Replace(vbNewLine, ",")
            lain2 = RichTextBox1.Text
            tglMasuk = DateTimePicker1.Value
            tglSelesai = DateTimePicker2.Value
            DateTimePicker2.Value = DateTimePicker1.Value.AddDays((berat.Value \ 4) + 1)

            If bayar_txt.Text = "" Then
                bayar_txt.Text = "0"
            Else
                kembali_txt.Text = Format(Val(CDec(bayar_txt.Text) - grandTotal), "#,###")
            End If

            bayar = CDec(bayar_txt.Text)
            If bayar_txt.Text = "0" Or bayar_txt.Text = "" Or bayar < grandTotal Then
                status = "Belum Lunas"
            Else
                If bayar = grandTotal Then
                    kembali_txt.Text = 0
                End If
                status = "Lunas"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub refreshdaftarharga()
        FormLogin.lc.refreshHarga(harga_cuciBasah.Text, harga_cuciKering.Text, harga_cuciSetrika.Text, harga_laundry.Text, jumlahDiskon)
    End Sub

    Sub cleardgv()
        FormLogin.lc.cleardgv()
        FormLogin.lc.tampildetail(DataGridView1)

    End Sub

#End Region

    Private Sub NewLaundry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub NewLaundry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        namaCust = "Non Member"
        FormLogin.lc.loadpewangi(cbPewangi)
        status = "Belum Lunas"
        Panel3.Visible = False
        kategoriLaundry.SelectedIndex = 0
        DateTimePicker1.Value = DateTime.Now
        'CheckedListBox1.SetSelected(0, True)
        cbPewangi.SelectedIndex = -1
        simpan_btn.Enabled = False
        print_btn.Enabled = False
        'CheckedListBox1.SetItemChecked(0, True)
        pewangi = cbPewangi.SelectedItem
        cektotal()
        FormLogin.lc.tampildetail(DataGridView1)
        kodeTrans = FormLogin.lc.autogenkodetrans()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim v As New ViewMember()
            v.ShowDialog()
            If v.tutup = False Then
                TextBox1.Text = v.id
                Button1_Click(sender, e)
                ViewMember.Dispose()
                Button2.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            FormLogin.lc.loadusertrans(TextBox1.Text, namacustomer)

            If TextBox1.Text.ToUpper() <> "NON MEMBER" Then
                Label3.Visible = True
                Label3.Text = "Member: " & namacustomer
                namaCust = namacustomer
                TextBox1.Enabled = False
                Button1.Enabled = False
                Panel4.Enabled = True
            Else
                Label3.Visible = True
                Label3.Text = namacustomer
                Panel4.Enabled = False
            End If

            cektotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        DataGridView1.Columns(e.Column.DisplayIndex).SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            Panel3.Visible = True
            TextBox1.Focus()
            Panel4.Enabled = False
            Label8.Visible = True
        Else
            namaCust = "Non Member"
            Panel4.Enabled = True
            Panel3.Visible = False
            Label3.Visible = False
            TextBox1.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = True
            TextBox1.Text = ""
            PictureBox1.BackgroundImage = Nothing
            Label8.Visible = False
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar).Equals(Keys.Enter) Then
            Button1_Click(sender, e)
        End If
    End Sub


    Private Sub kategoriLaundry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles kategoriLaundry.SelectedIndexChanged
        Try
            If kategoriLaundry.SelectedIndex = 0 Then
                GroupBox1.Visible = True
                TextBox2.Text = "Kiloan"
                TextBox2.Enabled = False
                TextBox2.Width = 159
            Else
                GroupBox1.Visible = False
                TextBox2.Enabled = True
                TextBox2.Width = 353
                TextBox2.Text = ""
                TextBox2.Focus()
            End If
            'cekTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbPewangi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPewangi.SelectedIndexChanged
        Try
            pewangi = cbPewangi.SelectedItem
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles berat.ValueChanged, DateTimePicker1.ValueChanged
        Try
            cektotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked Then
                bayar_txt.Enabled = True
                bayar_txt.Focus()
                If bayar_txt.Text <> "" Then
                    bayar_txt.Text = CDec(bayar_txt.Text)
                End If
                bayar_txt.SelectAll()
            Else
                bayar_txt.Enabled = False
                bayar_txt.Text = "0"
                bayar = 0
                status = "Belum Lunas"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged, RadioButton4.CheckedChanged, RadioButton5.CheckedChanged
        Try
            cektotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles bayar_txt.Validating
        Try
            Dim angka As Decimal
            If bayar_txt.Text = "0" Or bayar_txt.Text = "" Then
                bayar_txt.Text = "0"
            ElseIf Not Decimal.TryParse(Me.bayar_txt.Text, _
                                    Globalization.NumberStyles.Currency, _
                                    Nothing, _
                                    angka) Then

                With Me.bayar_txt
                    .HideSelection = False
                    .SelectAll()

                    MessageBox.Show("Masukkan Angka Yang Benar", _
                                    "Inputan Salah", _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Error)

                    .HideSelection = True
                End With

                e.Cancel = True
            End If
            Me.bayar_txt.Text = Format(Val(bayar_txt.Text), "#,###")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox3_Validated(sender As Object, e As EventArgs) Handles bayar_txt.Validated
        Try
            If bayar_txt.Text = "" Then
                bayar_txt.Text = "0"
            Else
                kembali_txt.Text = Format(Val(CDec(bayar_txt.Text) - grandTotal), "#,###")
            End If

            bayar = CDec(bayar_txt.Text)
            If bayar_txt.Text = "0" Or bayar_txt.Text = "" Or bayar < grandTotal Then
                status = "Belum Lunas"
            Else
                If bayar = grandTotal Then
                    kembali_txt.Text = 0
                End If
                status = "Lunas"
            End If
            cektotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bayar_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bayar_txt.KeyPress
        Try
            If Asc(e.KeyChar).Equals(Keys.Enter) Then
                simpan_btn.Focus()
                'simpan_btn_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bayar_txt_MouseClick(sender As Object, e As MouseEventArgs) Handles bayar_txt.MouseClick
        Try
            If bayar_txt.Text <> "" Then
                bayar_txt.Text = CDec(bayar_txt.Text)
            End If
            bayar_txt.SelectAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub bayar_txt_Enter(sender As Object, e As EventArgs) Handles bayar_txt.Enter
        Try
            If bayar_txt.Text <> "" Then
                bayar_txt.Text = CDec(bayar_txt.Text)
            End If
            bayar_txt.SelectAll()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub add_btn_Click(sender As Object, e As EventArgs) Handles add_btn.Click
        Try
            Dim nama_detergen As String = "Rinso Matic"
            Dim s As String = "On Process"
            If bayar_txt.Text <> "" Then
                bayar_txt.Text = CDec(bayar_txt.Text)
                bayar_txt.SelectAll()
                bayar_txt.Text = Format(Val(bayar_txt.Text), "#,###")
                TextBox3_Validated(sender, e)
            End If
            cektotal()

            flag = "Valid"
            FormLogin.lc.adddetail(dt, kodeTrans, FormLogin.lc.Username, namaCust, nama_barang, tglMasuk, kategori, tipe, nama_detergen, beratCucian, pewangi, tglSelesai, lain2, grandTotal, bayar, status, s, flag)
            
            simpan_btn.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub simpan_btn_Click(sender As Object, e As EventArgs) Handles simpan_btn.Click
        Try
            If bayar_txt.Text <> "" Then
                bayar_txt.Text = CDec(bayar_txt.Text)
                bayar_txt.SelectAll()
                bayar_txt.Text = Format(Val(bayar_txt.Text), "#,###")
                TextBox3_Validated(sender, e)
            End If
            cektotal()
            Dim k As New KonfirmasiNewLaundry
            k.lbKode.Text = FormLogin.lc.autogenkodetrans()
            k.lbCustomer.Text = namaCust
            k.lbKategori.Text = kategori
            k.lbTipe.Text = tipe
            k.lbNamaBrg.Text = nama_barang
            k.lbBerat.Text = beratCucian & " kg"
            k.lbPewangi.Text = pewangi
            k.lbLain2.Text = lain2
            k.lbTglMasuk.Text = DateTimePicker1.Text
            k.lbTglKeluar.Text = DateTimePicker2.Text
            k.lbTotal.Text = "Rp. " & Format(Val(grandTotal), "#,###")
            If bayar <> 0 Then
                k.lbBayar.Text = "Rp. " & Format(Val(bayar), "#,###")
            Else
                k.lbBayar.Text = "Rp. 0"
            End If
            k.lbStatus.Text = status
            If status = "Belum Lunas" Then
                k.lbKurang.Visible = True
                k.lbKurang0.Visible = True
                k.lbKurang1.Visible = True
                k.lbKurang.Text = "Rp. " & kembali_txt.Text
            End If
            k.ShowDialog(Me)
            If k.DialogResult = DialogResult.OK Then
                FormLogin.lc.saveTrans()
            End If
            simpan_btn.Enabled = Not simpan_btn.Enabled
            print_btn.Enabled = Not print_btn.Enabled
            print_btn.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cleardgv()
        FormLogin.lc.tampildetail(DataGridView1)

    End Sub

    Private Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
        Try
            Dim f As New FormStrukPrint()
            f.subtotal = subTotal
            f.diskon = diskon
            f.kembali = CInt(CDec(kembali_txt.Text))
            f.ShowDialog()
            simpan_btn.Enabled = Not simpan_btn.Enabled
            print_btn.Enabled = Not print_btn.Enabled
            CheckBox1.Checked = False
            RadioButton2.Checked = True
            bayar_txt.Text = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class