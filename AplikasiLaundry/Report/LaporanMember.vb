Public Class LaporanMember

    Private Sub LaporanMember_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub
End Class