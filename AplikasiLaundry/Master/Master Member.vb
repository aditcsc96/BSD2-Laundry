Imports Oracle.DataAccess.Client
Public Class MasterMember
    Public idmember As String = " "
#Region "modul master member"

    Sub refreshTabel()
        DataGridView1.DataSource = FormLogin.lc.lihatmember().Tables("member")
        DataGridView1.Refresh()
        With DataGridView1
            .Columns(0).HeaderCell.Value = "ID Member"
            .Columns(1).HeaderCell.Value = "Nama"
            .Columns(2).HeaderCell.Value = "Alamat"
            .Columns(3).HeaderCell.Value = "Telepon"
            .Columns(4).HeaderCell.Value = "Tgl Lahir"
            .Columns(5).HeaderCell.Value = "Jenis Kelamin"
        End With
        FormLogin.lc.conn.Close()
    End Sub

    Function textBoxTerisiSemua() As Boolean
        If tb_nama.Text <> "" And tb_alamat.Text <> "" And MaskedTextBox1.Text <> "" And DateTimePicker1.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub loadulang()
        'tb_idmember.Text = FormLogin.lc.autogenidmember
        tb_nama.Clear()
        tb_alamat.Clear()
        MaskedTextBox1.Clear()
        DateTimePicker1.Value = Now
        RadioButton1.Checked = True
    End Sub
#End Region
    Private Sub MasterMember_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim baris As Integer = e.RowIndex
        If baris >= 0 Then
            tb_idmember.Text = DataGridView1.Item(0, baris).Value
            tb_nama.Text = DataGridView1.Item(1, baris).Value
            tb_alamat.Text = DataGridView1.Item(2, baris).Value
            MaskedTextBox1.Text = DataGridView1.Item(3, baris).Value
            'DateTimePicker1.Value = DateTime.ParseExact(DataGridView1.Item(4, baris).Value.ToString(), "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None)
            DateTimePicker1.Value = DataGridView1.Item(4, baris).Value
            Dim jk As String = DataGridView1.Item(5, baris).Value.ToString()
            If jk = "Pria" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
        End If
    End Sub
    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        Dim tgllhr As String
        Dim jeniskelamin As String
        If RadioButton1.Checked Then
            jeniskelamin = "Pria"
        Else
            jeniskelamin = "Wanita"
        End If
        tgllhr = DateTimePicker1.Value.ToString("dd-MM-yyyy")
        Dim msk As String = MaskedTextBox1.Text
        msk = msk.Replace("(", "").Replace(")", "").Replace(" ", "")
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Insert Member " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.insmember(idmember, tb_nama.Text, tb_alamat.Text, msk, tgllhr, jeniskelamin)
                End If
            Catch ex As OracleException
                If ex.Number = 1 Then
                    MsgBox("Data Yang Anda Masukkan Sudah Ada")
                ElseIf ex.Number = 947 Then
                    MsgBox("Data Yang Dimasukkan Terlalu Panjang")
                Else
                    MsgBox(ex.Message)
                End If
            End Try
            FormLogin.lc.conn.Close()
        Else
            MsgBox("Harap Isi Data Yang Kosong")
        End If
        refreshTabel()
        loadulang()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim tgllhr As String
        Dim jeniskelamin As String
        If RadioButton1.Checked Then
            jeniskelamin = "Pria"
        Else
            jeniskelamin = "Wanita"
        End If
        tgllhr = DateTimePicker1.Value.ToString("dd-MM-yyyy")
        Dim msk As String = MaskedTextBox1.Text
        msk = msk.Replace("(", "").Replace(")", "").Replace(" ", "")
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Update Member " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.updmember(tb_idmember.Text, tb_nama.Text, tb_alamat.Text, msk, tgllhr, jeniskelamin)

                End If
            Catch ex As OracleException
                If ex.Number = 1 Then
                    MsgBox("Data Yang Anda Masukkan Sudah Ada")
                ElseIf ex.Number = 947 Then
                    MsgBox("Data Yang Dimasukkan Terlalu Panjang")
                Else
                    MsgBox(ex.Message)
                End If
            End Try
            FormLogin.lc.conn.Close()
        Else
            MsgBox("Harap Isi Data Yang Kosong")
        End If
        refreshTabel()
        loadulang()
    End Sub
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If tb_idmember.Text <> "" Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Delete Member " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.delmember(tb_idmember.Text)

                End If
            Catch ex As OracleException
                If ex.Number = 1 Then
                    MsgBox("Data Yang Anda Masukkan Sudah Ada")
                ElseIf ex.Number = 947 Then
                    MsgBox("Data Yang Dimasukkan Terlalu Panjang")
                Else
                    MsgBox(ex.Message)
                End If
            End Try
            FormLogin.lc.conn.Close()
        Else
            MsgBox("Harap Isi Data Yang Kosong")
        End If
        refreshTabel()
        loadulang()
    End Sub

    Private Sub MasterMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadulang()
        refreshTabel()
    End Sub

End Class