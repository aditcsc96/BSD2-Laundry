Imports Oracle.DataAccess.Client
Imports System.IO
Public Class LaundryClass
    Public conn As New OracleConnection
    Public Jabatan As String
    Public Username As String = ""
    'Public dsTrans As DataSet
    'Public dataTrans As DataRow
    'Public daTrans As New OracleDataAdapter
    Dim ds As New DataSet
    Dim da As OracleDataAdapter
    Dim dt As DataTable
    Public idbarang As String

    Public Function koneksi(ByVal user As String, ByVal pass As String) As Boolean
        Try
            Dim sr As New StreamReader("DBName.txt")
            conn.ConnectionString = "Data Source=" & sr.ReadLine() & ";user id=" & user & ";password=" & pass
            sr.Close()
            'If conn.State = te.Open Then
            '    conn.Close()
            '    conn.Open()
            'Else
            conn.Open()
            'End If
            MsgBox("Berhasil Koneksi!")
            Return True
        Catch ex As OracleException
            If ex.Number = 1017 Then
                MsgBox("User belum terdaftar/user salah")
            Else
                MsgBox("Gagal Koneksi krn " & ex.Message)
            End If

            Return False
        End Try
        'conn.Close()
    End Function

    Public Function cekhakakses(ByVal user As String) As Boolean
        Try

                Dim cmd As New OracleCommand
                cmd.Connection = conn

            cmd.CommandText = "select iduser, fitur from thakakses where iduser='" & user & "'"
                Dim reader As OracleDataReader = cmd.ExecuteReader()
                While reader.Read()     'Jika data ditemukan
                'Jabatan = reader.GetString(1)
                If reader("fitur") = "admin" Then
                    Jabatan = "admin"
                ElseIf reader("fitur") = "user" Then
                    Jabatan = "user"
                End If
                Username = reader("iduser")
                End While

            'MsgBox(Jabatan)
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        'conn.Close()
    End Function

    Public Function ceklogout() As Boolean
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function insmember(ByVal idmember As String, ByVal nama As String, ByVal alamat As String, ByVal telp As String, ByVal tgllahir As String, ByVal jk As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand
            cmd.Connection = conn


            cmd.CommandText = "insert into tmember(idmember, nama, alamat, telp, tgllahir, jk) values(:idmember,:nama,:alamat,:telp,TO_DATE(:tgllahir, 'dd-mm-yyyy'),:jk)"
            cmd.Parameters.Add(New OracleParameter(":idmember", OracleDbType.Varchar2, 6, idmember, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":nama", OracleDbType.Varchar2, 20, nama, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":alamat", OracleDbType.Varchar2, 30, alamat, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":telp", OracleDbType.Varchar2, 7, telp, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":tgllahir", OracleDbType.Date, tgllahir, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":jk", OracleDbType.Varchar2, 10, jk, ParameterDirection.Input))
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function updmember(ByVal idmember As String, ByVal nama As String, ByVal alamat As String, ByVal telp As String, ByVal tgllahir As String, ByVal jk As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand
            cmd.Connection = conn


            cmd.CommandText = "update tmember set idmember=:idmember,nama=:nama,alamat=:alamat,telp=:telp,tgllahir=TO_DATE(:tgllahir, 'dd-mm-yyyy'),jk=:jk where idmember=:idmember"
            'cmd.Parameters.Add(":idmember", OracleDbType.Varchar2, 6).Value = idmember
            'cmd.Parameters.Add(":nama", OracleDbType.Varchar2, 20).Value = nama
            'cmd.Parameters.Add(":alamat", OracleDbType.Varchar2, 30).Value = alamat
            'cmd.Parameters.Add(":telp", OracleDbType.Varchar2, 7).Value = telp
            'cmd.Parameters.Add(":tgllahir", OracleDbType.Date).Value = tgllahir
            'cmd.Parameters.Add(":jk", OracleDbType.Varchar2, 10).Value = jk
            cmd.Parameters.Add(New OracleParameter(":idmember", OracleDbType.Varchar2, 6, idmember, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":nama", OracleDbType.Varchar2, 20, nama, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":alamat", OracleDbType.Varchar2, 30, alamat, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":telp", OracleDbType.Varchar2, 7, telp, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":tgllahir", OracleDbType.Date, tgllahir, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":jk", OracleDbType.Varchar2, 10, jk, ParameterDirection.Input))
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function delmember(ByVal idmember As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand
            cmd.Connection = conn


            cmd.CommandText = "delete from tmember where idmember=:idmember"
            'cmd.Parameters.Add(":idmember", OracleDbType.Varchar2, 6).Value = idmember
            'cmd.Parameters.Add(":nama", OracleDbType.Varchar2, 20).Value = nama
            'cmd.Parameters.Add(":alamat", OracleDbType.Varchar2, 30).Value = alamat
            'cmd.Parameters.Add(":telp", OracleDbType.Varchar2, 7).Value = telp
            'cmd.Parameters.Add(":tgllahir", OracleDbType.Date).Value = tgllahir
            'cmd.Parameters.Add(":jk", OracleDbType.Varchar2, 10).Value = jk
            cmd.Parameters.Add(New OracleParameter(":idmember", OracleDbType.Varchar2, 6, idmember, ParameterDirection.Input))
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function autogenidmember() As String
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            'call function
            Dim cmd As New OracleCommand()
            cmd.Connection = conn
            cmd.CommandText = "autogenidmember"
            cmd.CommandType = CommandType.StoredProcedure

            'output kembalian
            Dim paramReturn = New OracleParameter
            paramReturn.OracleDbType = OracleDbType.Varchar2
            paramReturn.Size = 10
            paramReturn.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(paramReturn)


            cmd.ExecuteNonQuery()
            Return paramReturn.Value.ToString()
        Catch ex As OracleException
            Return "000"
        End Try
    End Function

    Public Function lihatmember() As DataSet
        Try
            Dim cmd As New OracleCommand
            cmd.Connection = conn
            cmd.CommandText = "SELECT * FROM tmember where idmember <> 'Non Member'"
            Dim da As New OracleDataAdapter
            da.SelectCommand = cmd
            Dim ds As New DataSet
            da.Fill(ds, "member")
            Return ds
        Catch ex As Exception
            MsgBox("Gagal")
        End Try
    End Function

    Public Function updateHarga(ByVal cubas As String, ByVal cukar As String, ByVal cuset As String, ByRef laund As String, ByRef diskon As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand
            cmd.Connection = conn


            cmd.CommandText = "update harga set cb=:cb,ck=:ck,cs=:cs,laundry=:laundry,disc=:disc"
            cmd.Parameters.Add(New OracleParameter(":cb", OracleDbType.Int16, 10, CInt(cubas), ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":ck", OracleDbType.Int16, 10, CInt(cukar), ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":cs", OracleDbType.Int16, 10, CInt(cuset), ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":laundry", OracleDbType.Int16, 10, CInt(laund), ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":disc", OracleDbType.Int16, 10, CInt(diskon), ParameterDirection.Input))
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function refreshHarga(ByRef cubas As String, ByRef cuker As String, ByRef cuset As String, ByRef laund As String, ByRef disc As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand("SELECT * FROM tharga", conn)
            Dim reader As OracleDataReader = cmd.ExecuteReader()

            While reader.Read
                cubas = Format(Val(reader("cb").ToString), "#,###")

                cuker = Format(Val(reader("ck").ToString), "#,###")

                cuset = Format(Val(reader("cs").ToString), "#,###")

                laund = Format(Val(reader("laundry").ToString), "#,###")

                disc = Format(Val(reader("disc").ToString), "#,###")

            End While
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function loadMember(ByVal input As String, ByRef smrg As DataGridView) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim adp As New OracleDataAdapter("SELECT idmember AS IDMember, nama AS NamaMember FROM tmember WHERE idmember <> 'Non Member'" & input, conn)
            Dim ds As New DataSet
            adp.Fill(ds)
            smrg.DataSource = ds.Tables(0)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function loaduser(ByRef dgv As DataGridView) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim adp As New OracleDataAdapter("SELECT * from hakakses", conn)
            Dim ds As New DataSet
            adp.Fill(ds)
            dgv.DataSource = ds.Tables(0)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function insuser(ByVal username As String, ByVal password As String, ByVal hakakses As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand
            cmd.Connection = conn
            Dim cmd2 As New OracleCommand
            cmd2.Connection = conn


            cmd.CommandText = "create user " & username & " identified by " & password & ""
            cmd.ExecuteNonQuery()
            'sMsgBox(hakakses)
            If hakakses = "admin" Then
                
                cmd2.CommandText = "grant dba to " & username
                cmd2.ExecuteNonQuery()

            ElseIf hakakses = "user" Then
                cmd2.CommandText = "grant pegawai to " & username
                cmd2.ExecuteNonQuery()
            End If
            'MsgBox(cmd.CommandText)
            'MsgBox(cmd2.CommandText)
            Try
                Dim cmd3 As New OracleCommand
                cmd3.Connection = conn
                cmd3.CommandText = "insert into hakakses(iduser,fitur) values(:iduser,:fitur)"
                cmd3.Parameters.Add(New OracleParameter(":iduser", OracleDbType.Varchar2, 20, username, ParameterDirection.Input))
                cmd3.Parameters.Add(New OracleParameter(":fitur", OracleDbType.Varchar2, 30, hakakses, ParameterDirection.Input))
                cmd3.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            MsgBox("Add User Berhasil!")
            Return True
        Catch ex As OracleException
            If ex.Number = 1 Then
                MsgBox("Data Yang Anda Masukkan Sudah Ada")
            Else
                MsgBox(ex.Message)
            End If
            Return False
        End Try
    End Function

    Public Function deluser(ByVal username As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand
            cmd.Connection = conn
            Dim cmd2 As New OracleCommand
            cmd2.Connection = conn

            cmd2.CommandText = "delete from hakakses where iduser=:iduser"
            cmd2.Parameters.Add(New OracleParameter(":iduser", OracleDbType.Varchar2, 20, username, ParameterDirection.Input))
            'MsgBox(cmd2.CommandText)
            cmd2.ExecuteNonQuery()
            cmd.CommandText = "drop user " & username
            'MsgBox(cmd.CommandText)
            cmd.ExecuteNonQuery()


            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function loadusertrans(ByVal idmember As String, ByRef namamember As String) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand
            cmd.Connection = conn
            cmd.CommandText = "select idmember, nama from tmember where idmember='" & idmember & "'"
            Dim reader As OracleDataReader
            reader = cmd.ExecuteReader()
                If reader.Read = True Then
                    namamember = reader("nama")
                ElseIf reader.Read = False Then
                    namamember = "Inputan Salah"
                End If

            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function

    Public Function loadpewangi(ByRef cmbpewangi As ComboBox) As Boolean
        Try
            '
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand("SELECT idbarang, namabarang FROM tbarang WHERE idbarang LIKE '%PWG%'", conn)
            Dim rd As OracleDataReader = cmd.ExecuteReader()
            While rd.Read
                idbarang = rd("idbarang")
                cmbpewangi.Items.Add(rd("namabarang"))
            End While
            cmbpewangi.SelectedIndex = 0
            Return True

        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try

    End Function

    'Function tampilDetail(ByVal input1 As String, ByVal input2 As String, ByRef datagridv As DataGridView) As Boolean
    '    Try
    '        If conn.State = ConnectionState.Closed Then
    '            conn.Open()
    '        End If

    '        Dim cmd As New OracleCommand("SELECT t.kodetrans, h.iduser, m.nama, t.tglmasuk, t.kategorilaundry, t.tipelaundry, t.namacucian, t.berat, t.pewangi, t.tgl_selesai, t.lainnya, t.total, t.bayar, t.status_bayar FROM ttransaksi t, thakakses h, tmember m WHERE t.iduser = h.iduser AND t.idmember = m.idmember " & input1 & "AND t.status_cucian = 'On Process' ORDER BY LEFT(kodetrans,2) ASC, MID(kodetrans,5,2) ASC, MID(kodetrans,3,2) ASC" & input2 & "AND 1=2", conn)
    '        da = New OracleDataAdapter(cmd)
    '        da.Fill(ds, "detailTrans")
    '        datagridv.DataSource = ds
    '        datagridv.DataMember = "detailTrans"
    '        With datagridv
    '            .Columns(0).HeaderCell.Value = "Kode Transaksi"
    '            .Columns(1).HeaderCell.Value = "Petugas"
    '            .Columns(2).HeaderCell.Value = "Customer"
    '            .Columns(3).HeaderCell.Value = "Tgl Masuk"
    '            .Columns(4).HeaderCell.Value = "Kategori"
    '            .Columns(5).HeaderCell.Value = "Tipe"
    '            .Columns(6).HeaderCell.Value = "Nama Cucian"
    '            .Columns(7).HeaderCell.Value = "Berat"
    '            .Columns(8).HeaderCell.Value = "Pewangi"
    '            .Columns(9).HeaderCell.Value = "Tgl Selesai"
    '            .Columns(10).HeaderCell.Value = "Ket Lain"
    '            .Columns(11).HeaderCell.Value = "Total"
    '            .Columns(12).HeaderCell.Value = "Bayar"
    '            .Columns(13).HeaderCell.Value = "Status Bayar"
    '        End With
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False

    '    End Try
    'End Function

    Public Function tampildetail(ByRef dgv As DataGridView) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim cmd As New OracleCommand("select * from ttransaksi where 1=2", conn)
            da = New OracleDataAdapter(cmd)
            da.Fill(ds, "detailTransaksi")
            dgv.DataSource = ds
            dgv.DataMember = "detailTransaksi"
            With dgv
                .Columns(0).HeaderCell.Value = "Kode Trans"
                .Columns(1).HeaderCell.Value = "Nama User"
                .Columns(2).HeaderCell.Value = "Nama Member"
                .Columns(3).HeaderCell.Value = "Nama Barang"
                .Columns(4).HeaderCell.Value = "Tanggal Masuk"
                .Columns(5).HeaderCell.Value = "Kategori Laundry"
                .Columns(6).HeaderCell.Value = "Tipe Laundry"
                .Columns(7).HeaderCell.Value = "Nama Cucian"
                .Columns(8).HeaderCell.Value = "Berat"
                .Columns(9).HeaderCell.Value = "Pewangi"
                .Columns(10).HeaderCell.Value = "Tanggal Selesai"
                .Columns(11).HeaderCell.Value = "Keterangan"
                .Columns(12).HeaderCell.Value = "Total"
                .Columns(13).HeaderCell.Value = "Jumlah Bayar"
                .Columns(14).HeaderCell.Value = "Status Bayar"
                .Columns(15).HeaderCell.Value = "Status Cucian"
                .Columns(16).HeaderCell.Value = "Valid/Not Valid"

            End With
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function adddetail(ByVal dt As DataTable, ByVal input0 As String, ByVal input1 As String, ByVal input2 As String, ByVal input3 As String, ByVal input4 As Date, ByVal input5 As String, ByVal input6 As String, ByVal input7 As String, ByVal input8 As Integer, ByVal input9 As String, ByVal input10 As Date, ByVal input11 As String, ByVal input12 As Integer, ByVal input13 As Integer, ByVal input14 As String, ByVal input15 As String, ByVal input16 As String) As Boolean
        Try
            dt = ds.Tables(0)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = input0
            dr(1) = input1
            dr(2) = input2
            dr(3) = input3
            dr(4) = input4
            dr(5) = input5
            dr(6) = input6
            dr(7) = input7
            dr(8) = input8
            dr(9) = input9
            dr(10) = input10
            dr(11) = input11
            dr(12) = input12
            dr(13) = input13
            dr(14) = input14
            dr(15) = input15
            dr(16) = input16
            dt.Rows.Add(dr)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try

    End Function
    Public Function autogenkodetrans() As String
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If


            'call function
            Dim cmd As New OracleCommand()
            cmd.Connection = conn
            cmd.CommandText = "autogenkodetrans"
            cmd.CommandType = CommandType.StoredProcedure

            'output kembalian
            Dim paramReturn = New OracleParameter
            paramReturn.OracleDbType = OracleDbType.Varchar2
            paramReturn.Size = 10
            paramReturn.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(paramReturn)

            'input ke parameter function
            Dim paramInput = New OracleParameter
            paramInput.OracleDbType = OracleDbType.Varchar2
            paramInput.Size = 10
            paramInput.Direction = ParameterDirection.Input
            paramInput.Value = System.DateTime.Now.ToString("yyMMdd")
            cmd.Parameters.Add(paramInput)


            cmd.ExecuteNonQuery()
            Return paramReturn.Value.ToString()
        Catch ex As OracleException
            Return "000"
        End Try
    End Function
    Public Function saveTrans() As Boolean
        Dim trans As OracleTransaction = conn.BeginTransaction
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If


            Dim builder As New OracleCommandBuilder(da)
            da.InsertCommand = builder.GetInsertCommand
            da.UpdateCommand = builder.GetUpdateCommand
            da.DeleteCommand = builder.GetDeleteCommand
            da.Update(ds.Tables("detailTransaksi"))
            trans.Commit()
            MsgBox("data berhasil di insert ke database, harap print struk")
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            trans.Rollback()
            Return False
        End Try
    End Function

    Public Sub cleardgv()
        ds.Clear()
    End Sub
    Public Function loadTransaksi(ByVal input As String, ByRef smrg As DataGridView) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim adp As New OracleDataAdapter("SELECT * from ttransaksi where kodetrans <> ' '" & input, conn)
            Dim ds As New DataSet
            adp.Fill(ds)
            smrg.DataSource = ds.Tables(0)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function deleteTrans(ByVal kode As String) As Boolean
        Try
            Dim cmd5 As New OracleCommand

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd5.CommandText = "update ttransaksi set statustrans= 'Tidak Valid' where kodetrans='" + kode + "'"
            cmd5.Connection = conn
            MsgBox("Data berhasil diupdate")
            cmd5.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function loadtransambilcucian(ByVal input As String, ByRef dgview As DataGridView) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim query As String = "SELECT kodetrans, idmember FROM ttransaksi WHERE status_cucian = 'On Process'" & input
            Dim adp As New OracleDataAdapter("", conn)
            adp.SelectCommand.CommandText = query
            Dim ds As New DataSet
            adp.Fill(ds)
            dgview.DataSource = ds.Tables(0)
            Return True
        Catch ex As OracleException
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function kliksubmit(ByVal input As String, ByVal panel3 As Panel, ByRef total As Integer, ByRef bayar As Integer, ByRef namacust As String, ByRef tglmasuk As String, ByRef tglselesai As String, ByRef tipe As String, ByRef namacucian As String, ByRef lain As String, ByRef panel5 As Panel, ByRef kurang As Integer, ByVal panel4 As Panel) As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand("", conn)
            Dim rd As OracleDataReader
            cmd.CommandText = "select * from ttransaksi where kodetrans=" & input
            rd = cmd.ExecuteReader()

            If rd.Read() Then
                panel3.Visible = True
                total = rd("total")
                bayar = rd("bayar")

                'isi label dimari
                namacust = rd("idmember")
                tglmasuk = rd("tglmasuk")
                tglselesai = rd("tglselesai")
                tipe = rd("tipelaundry")
                namacucian = rd("namacucian")
                lain = rd("lainnya").ToString
                If bayar >= total And rd("status_bayar") = "Lunas" Then
                    panel5.Visible = False
                    kurang = 0
                Else
                    panel5.Visible = True
                End If
                AmbilCucian.cekTotal()
                panel4.Enabled = False
            Else
                MsgBox("Data Tidak Ditemukan")
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function updateStatuscucian(ByVal bayar As Integer, ByVal statusbayar As String, ByVal statuscucian As String, ByVal kodetrans As String) As Boolean
        Try

            'update database
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As New OracleCommand("", conn)
            cmd.CommandText = "UPDATE ttransaksi SET bayar = :bayar, status_bayar = :statusbayar, status_cucian = :statuscucian WHERE kodetrans = :kodetrans"
            cmd.Parameters.Add(New OracleParameter(":bayar", OracleDbType.Int16, 10, bayar, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":statusbayar", OracleDbType.Varchar2, 20, statusbayar, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":statuscucian", OracleDbType.Varchar2, 20, statuscucian, ParameterDirection.Input))
            cmd.Parameters.Add(New OracleParameter(":kodetrans", OracleDbType.Varchar2, 20, kodetrans, ParameterDirection.Input))
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

End Class
