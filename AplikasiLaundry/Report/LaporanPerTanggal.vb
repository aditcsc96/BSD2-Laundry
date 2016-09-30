Public Class LaporanPerTanggal

    Private Sub LaporanPerTanggal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormTransTanggal.TransaksiPerTanggal1.SetParameterValue("awal", DateTimePicker1.Value)
        FormTransTanggal.TransaksiPerTanggal1.SetParameterValue("akhir", DateTimePicker2.Value)
        If FormUtama.IsOpen("FormTransTanggal") = False Then
            Dim frm As New FormTransTanggal
            frm.MdiParent = FormUtama
            frm.Show()
            FormUtama.ChildNumber += 1
        End If
        Me.Dispose()
    End Sub

End Class